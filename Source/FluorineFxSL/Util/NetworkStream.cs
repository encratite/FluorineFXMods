/*
	FluorineFx open source library 
	Copyright (C) 2007 Zoltan Csibi, zoltan@TheSilentGroup.com, FluorineFx.com 
	
	This library is free software; you can redistribute it and/or
	modify it under the terms of the GNU Lesser General Public
	License as published by the Free Software Foundation; either
	version 2.1 of the License, or (at your option) any later version.
	
	This library is distributed in the hope that it will be useful,
	but WITHOUT ANY WARRANTY; without even the implied warranty of
	MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the GNU
	Lesser General Public License for more details.
	
	You should have received a copy of the GNU Lesser General Public
	License along with this library; if not, write to the Free Software
	Foundation, Inc., 59 Temple Place, Suite 330, Boston, MA  02111-1307  USA
*/
using System;
using System.Collections;
using System.Collections.Specialized;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Threading;

namespace FluorineFx.Util
{
    class NetworkStream : Stream
    {
        private bool m_CleanedUp;
        private int m_CloseTimeout;
        private int m_CurrentReadTimeout;
        private int m_CurrentWriteTimeout;
        private bool m_OwnsSocket;
        private bool m_Readable;
        private Socket m_StreamSocket;
        private bool m_Writeable;

        internal NetworkStream()
        {
            m_CloseTimeout = -1;
            m_CurrentReadTimeout = -1;
            m_CurrentWriteTimeout = -1;
            m_OwnsSocket = true;
        }

        public NetworkStream(Socket socket)
        {
            m_CloseTimeout = -1;
            m_CurrentReadTimeout = -1;
            m_CurrentWriteTimeout = -1;
            if (socket == null)
                throw new ArgumentNullException("socket");
            InitNetworkStream(socket, FileAccess.ReadWrite);
        }

        internal NetworkStream(NetworkStream networkStream, bool ownsSocket)
        {
            m_CloseTimeout = -1;
            m_CurrentReadTimeout = -1;
            m_CurrentWriteTimeout = -1;
            Socket socket = networkStream.Socket;
            if (socket == null)
                throw new ArgumentNullException("networkStream");
            InitNetworkStream(socket, FileAccess.ReadWrite);
            m_OwnsSocket = ownsSocket;
        }

        public NetworkStream(Socket socket, bool ownsSocket)
        {
            m_CloseTimeout = -1;
            m_CurrentReadTimeout = -1;
            m_CurrentWriteTimeout = -1;
            if (socket == null)
                throw new ArgumentNullException("socket");
            InitNetworkStream(socket, FileAccess.ReadWrite);
            m_OwnsSocket = ownsSocket;
        }

        public NetworkStream(Socket socket, FileAccess access)
        {
            m_CloseTimeout = -1;
            m_CurrentReadTimeout = -1;
            m_CurrentWriteTimeout = -1;
            if (socket == null)
                throw new ArgumentNullException("socket");
            InitNetworkStream(socket, access);
        }

        public NetworkStream(Socket socket, FileAccess access, bool ownsSocket)
        {
            m_CloseTimeout = -1;
            m_CurrentReadTimeout = -1;
            m_CurrentWriteTimeout = -1;
            if (socket == null)
                throw new ArgumentNullException("socket");
            InitNetworkStream(socket, access);
            m_OwnsSocket = ownsSocket;
        }

        class UserToken
        {
            Socket _socket;
            AsyncResult<int> _ar;

            public UserToken(Socket socket, AsyncResult<int> ar)
            {
                _socket = socket;
                _ar = ar;
            }

            public Socket Socket { get { return _socket; } }
            public AsyncResult<int> AsyncResult { get { return _ar; } }
        }

        public override IAsyncResult BeginRead(byte[] buffer, int offset, int size, AsyncCallback callback, object state)
        {
            IAsyncResult result = null;
            if (m_CleanedUp)
                throw new ObjectDisposedException(base.GetType().FullName);
            if (buffer == null)
                throw new ArgumentNullException("buffer");
            if ((offset < 0) || (offset > buffer.Length))
                throw new ArgumentOutOfRangeException("offset");
            if ((size < 0) || (size > (buffer.Length - offset)))
                throw new ArgumentOutOfRangeException("size");
            if (!this.CanRead)
                throw new InvalidOperationException();
            if (m_StreamSocket == null)
                throw new IOException();
            try
            {
                //result = m_StreamSocket.BeginReceive(buffer, offset, size, SocketFlags.None, callback, state);
                SocketAsyncEventArgs args = new SocketAsyncEventArgs();
                AsyncResult<int> ar = new AsyncResult<int>(callback, state);
                UserToken userToken = new UserToken(m_StreamSocket, ar);
                args.UserToken = userToken;
                args.SetBuffer(buffer, offset, size);
                args.Completed += new EventHandler<SocketAsyncEventArgs>(OnSocketReceive);
                m_StreamSocket.ReceiveAsync(args);
                result = ar;
            }
            catch (Exception exception)
            {
                if (exception is ThreadAbortException || exception is StackOverflowException || exception is OutOfMemoryException)
                    throw;
                throw new IOException(exception.Message, exception);
            }
            return result;
        }

        private void OnSocketReceive(object sender, SocketAsyncEventArgs e)
        {
            AsyncResult<int> ar = (e.UserToken as UserToken).AsyncResult;
            try
            {
                ar.SetAsCompleted(e.BytesTransferred, false);
            }
            catch (Exception ex)
            {
                // If operation fails, set the exception
                ar.SetAsCompleted(ex, false);
            }
        }

        public override int EndRead(IAsyncResult asyncResult)
        {
            int bytesRead;
            AsyncResult<int> ar = asyncResult as AsyncResult<int>;
            if (m_CleanedUp)
                throw new ObjectDisposedException(base.GetType().FullName);
            if (asyncResult == null)
                throw new ArgumentNullException("asyncResult");
            if (m_StreamSocket == null)
                throw new IOException();
            try
            {
                //bytesRead = m_StreamSocket.EndReceive(asyncResult);
                bytesRead = ar.EndInvoke();
            }
            catch (Exception exception)
            {
                if (exception is ThreadAbortException || exception is StackOverflowException || exception is OutOfMemoryException)
                    throw;
                throw new IOException(exception.Message, exception);
            }
            return bytesRead;
        }

        public override int Read(byte[] buffer, int offset, int size)
        {
            int bytesRead;
            if (m_CleanedUp)
                throw new ObjectDisposedException(base.GetType().FullName);
            if (buffer == null)
                throw new ArgumentNullException("buffer");
            if ((offset < 0) || (offset > buffer.Length))
                throw new ArgumentOutOfRangeException("offset");
            if ((size < 0) || (size > (buffer.Length - offset)))
                throw new ArgumentOutOfRangeException("size");
            if (!this.CanRead)
                throw new InvalidOperationException();
            Socket streamSocket = this.m_StreamSocket;
            if (m_StreamSocket == null)
                throw new IOException();
            try
            {
                //bytesRead = m_StreamSocket.Receive(buffer, offset, size, SocketFlags.None);
                IAsyncResult asyncResult = this.BeginRead(buffer, offset, size, null, null);
                AsyncResult<int> ar = asyncResult as AsyncResult<int>;
                bytesRead = ar.EndInvoke();
            }
            catch (Exception exception)
            {
                if (exception is ThreadAbortException || exception is StackOverflowException || exception is OutOfMemoryException)
                    throw;
                throw new IOException(exception.Message, exception);
            }
            return bytesRead;
        }

        public override IAsyncResult BeginWrite(byte[] buffer, int offset, int size, AsyncCallback callback, object state)
        {
            IAsyncResult result = null;
            if (m_CleanedUp)
                throw new ObjectDisposedException(base.GetType().FullName);
            if (buffer == null)
                throw new ArgumentNullException("buffer");
            if ((offset < 0) || (offset > buffer.Length))
                throw new ArgumentOutOfRangeException("offset");
            if ((size < 0) || (size > (buffer.Length - offset)))
                throw new ArgumentOutOfRangeException("size");
            if (!this.CanWrite)
                throw new InvalidOperationException();
            if (m_StreamSocket == null)
                throw new IOException();
            try
            {
                //result = m_StreamSocket.BeginSend(buffer, offset, size, SocketFlags.None, callback, state);
                SocketAsyncEventArgs args = new SocketAsyncEventArgs();
                AsyncResult<int> ar = new AsyncResult<int>(callback, state);
                UserToken userToken = new UserToken(m_StreamSocket, ar);
                args.UserToken = userToken;
                args.SetBuffer(buffer, offset, size);
                args.Completed += new EventHandler<SocketAsyncEventArgs>(OnSocketSend);
                m_StreamSocket.SendAsync(args);
                result = ar;
            }
            catch (Exception exception)
            {
                if (exception is ThreadAbortException || exception is StackOverflowException || exception is OutOfMemoryException)
                    throw;
                throw new IOException(exception.Message, exception);
            }
            return result;
        }

        private void OnSocketSend(object sender, SocketAsyncEventArgs e)
        {
            AsyncResult<int> ar = (e.UserToken as UserToken).AsyncResult;
            try
            {
                ar.SetAsCompleted(e.BytesTransferred, false);
            }
            catch (Exception ex)
            {
                // If operation fails, set the exception
                ar.SetAsCompleted(ex, false);
            }
        }

        public override void EndWrite(IAsyncResult asyncResult)
        {
            if (m_CleanedUp)
                throw new ObjectDisposedException(base.GetType().FullName);
            if (asyncResult == null)
                throw new ArgumentNullException("asyncResult");
            AsyncResult<int> ar = asyncResult as AsyncResult<int>;
            if (m_StreamSocket == null)
                throw new IOException();
            try
            {
                //m_StreamSocket.EndSend(asyncResult);
                ar.EndInvoke();
            }
            catch (Exception exception)
            {
                if (exception is ThreadAbortException || exception is StackOverflowException || exception is OutOfMemoryException)
                    throw;
                throw new IOException(exception.Message, exception);
            }
        }

        public override void Write(byte[] buffer, int offset, int size)
        {
            if (m_CleanedUp)
                throw new ObjectDisposedException(base.GetType().FullName);
            if (buffer == null)
                throw new ArgumentNullException("buffer");
            if ((offset < 0) || (offset > buffer.Length))
                throw new ArgumentOutOfRangeException("offset");
            if ((size < 0) || (size > (buffer.Length - offset)))
                throw new ArgumentOutOfRangeException("size");
            if (!this.CanWrite)
                throw new InvalidOperationException();
            Socket streamSocket = this.m_StreamSocket;
            if (m_StreamSocket == null)
            {
                throw new IOException();
            }
            try
            {
                //m_StreamSocket.Send(buffer, offset, size, SocketFlags.None);
                IAsyncResult asyncResult = this.BeginWrite(buffer, offset, size, null, null);
                AsyncResult<int> ar = asyncResult as AsyncResult<int>;
                ar.EndInvoke();
            }
            catch (Exception exception)
            {
                if (exception is ThreadAbortException || exception is StackOverflowException || exception is OutOfMemoryException)
                    throw;
                throw new IOException(exception.Message, exception);
            }
        }

        public void Close(int timeout)
        {
            if (timeout < -1)
                throw new ArgumentOutOfRangeException("timeout");
            m_CloseTimeout = timeout;
            this.Close();
        }

        protected override void Dispose(bool disposing)
        {
            if ((!m_CleanedUp && disposing) && (m_StreamSocket != null))
            {
                m_Readable = false;
                m_Writeable = false;
                if (m_OwnsSocket)
                {
                    if (m_StreamSocket != null)
                    {
                        //m_StreamSocket.InternalShutdown(SocketShutdown.Both);
                        m_StreamSocket.Close(this.m_CloseTimeout);
                    }
                }
            }
            m_CleanedUp = true;
            base.Dispose(disposing);
        }

        ~NetworkStream()
        {
            this.Dispose(false);
        }

        public override void Flush()
        {
        }

        internal void InitNetworkStream(Socket socket, FileAccess Access)
        {
            /*
            if (!socket.Blocking)
                throw new IOException();
            if (socket.SocketType != SocketType.Stream)
                throw new IOException();
            */
            if (!socket.Connected)
                throw new IOException();
            m_StreamSocket = socket;
            switch (Access)
            {
                case FileAccess.Read:
                    m_Readable = true;
                    return;

                case FileAccess.Write:
                    m_Writeable = true;
                    return;
            }
            m_Readable = true;
            m_Writeable = true;
        }

        public override long Seek(long offset, SeekOrigin origin)
        {
            throw new NotSupportedException();
        }

        public override void SetLength(long value)
        {
            throw new NotSupportedException();
        }

        /*
        internal void SetSocketTimeoutOption(SocketShutdown mode, int timeout, bool silent)
        {
            if (timeout < 0)
                timeout = 0;
            if (m_StreamSocket != null)
            {
                if (((mode == SocketShutdown.Send) || (mode == SocketShutdown.Both)) && (timeout != m_CurrentWriteTimeout))
                {
                    m_StreamSocket.SetSocketOption(SocketOptionLevel.Socket, SocketOptionName.SendTimeout, timeout, silent);
                    m_CurrentWriteTimeout = timeout;
                }
                if (((mode == SocketShutdown.Receive) || (mode == SocketShutdown.Both)) && (timeout != m_CurrentReadTimeout))
                {
                    m_StreamSocket.SetSocketOption(SocketOptionLevel.Socket, SocketOptionName.ReceiveTimeout, timeout, silent);
                    m_CurrentReadTimeout = timeout;
                }
            }
        }
        */

        public override bool CanRead
        {
            get
            {
                return this.m_Readable;
            }
        }

        public override bool CanSeek
        {
            get
            {
                return false;
            }
        }

        public override bool CanTimeout
        {
            get
            {
                return true;
            }
        }

        public override bool CanWrite
        {
            get
            {
                return this.m_Writeable;
            }
        }

        internal bool Connected
        {
            get
            {
                return ((!this.m_CleanedUp && (m_StreamSocket != null)) && m_StreamSocket.Connected);
            }
        }

        /*
        public virtual bool DataAvailable
        {
            get
            {
                if (m_CleanedUp)
                    throw new ObjectDisposedException(base.GetType().FullName);
                if (m_StreamSocket == null)
                    throw new IOException();
                return (m_StreamSocket.Available != 0);
            }
        }
        */

        public override long Length
        {
            get
            {
                throw new NotSupportedException();
            }
        }

        public override long Position
        {
            get
            {
                throw new NotSupportedException();
            }
            set
            {
                throw new NotSupportedException();
            }
        }

        protected bool Readable
        {
            get
            {
                return m_Readable;
            }
            set
            {
                m_Readable = value;
            }
        }

        /*
        public override int ReadTimeout
        {
            get
            {
                int socketOption = (int)m_StreamSocket.GetSocketOption(SocketOptionLevel.Socket, SocketOptionName.ReceiveTimeout);
                if (socketOption == 0)
                    return -1;
                return socketOption;
            }
            set
            {
                if ((value <= 0) && (value != -1))
                    throw new ArgumentOutOfRangeException();
                SetSocketTimeoutOption(SocketShutdown.Receive, value, false);
            }
        }
        */

        protected Socket Socket
        {
            get
            {
                return m_StreamSocket;
            }
        }

        protected bool Writeable
        {
            get
            {
                return m_Writeable;
            }
            set
            {
                m_Writeable = value;
            }
        }

        /*
        public override int WriteTimeout
        {
            get
            {
                int socketOption = (int)m_StreamSocket.GetSocketOption(SocketOptionLevel.Socket, SocketOptionName.SendTimeout);
                if (socketOption == 0)
                    return -1;
                return socketOption;
            }
            set
            {
                if ((value <= 0) && (value != -1))
                    throw new ArgumentOutOfRangeException();
                SetSocketTimeoutOption(SocketShutdown.Send, value, false);
            }
        }
        */
    }
}
