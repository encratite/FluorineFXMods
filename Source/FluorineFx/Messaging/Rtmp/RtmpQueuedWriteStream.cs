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
using log4net;

namespace FluorineFx.Messaging.Rtmp
{
    /// <summary>
    /// This type supports the Fluorine infrastructure and is not intended to be used directly from your code.
    /// </summary>
    class RtmpQueuedWriteStream : System.IO.Stream
    {
        private System.IO.Stream _innerStream;
        private Queue _outgoingQueue = new Queue();
        private volatile bool _isWriting;


        public RtmpQueuedWriteStream(System.IO.Stream innerStream)
        {
            _innerStream = innerStream;
        }

        public override IAsyncResult BeginRead(byte[] buffer, int offset, int count, AsyncCallback callback, object state)
        {
            return _innerStream.BeginRead(buffer, offset, count, callback, state);
        }

        public override IAsyncResult BeginWrite(byte[] buffer, int offset, int count, AsyncCallback callback, object state)
        {
            RtmpAsyncResult asyncResult = new RtmpAsyncResult(callback, state, buffer, offset, count);
            lock (_outgoingQueue)
            {
                _outgoingQueue.Enqueue(asyncResult);
            }
            TryBeginWrite();
            return asyncResult;
        }

        private IAsyncResult InternalBeginWrite(byte[] buffer, int offset, int count, AsyncCallback callback, object state)
        {
            return this.InnerStream.BeginWrite(buffer, offset, count, callback, state);
        }

        private void InternalEndWrite(IAsyncResult asyncResult)
        {
            this.InnerStream.EndWrite(asyncResult);
        }

        private void TryBeginWrite()
        {
            if(!_isWriting)
            {
                RtmpAsyncResult asyncResult;
                lock (_outgoingQueue)
                {
                    if (_isWriting)
                        return;
                    if (_outgoingQueue.Count > 0)
                    {
                        asyncResult = _outgoingQueue.Dequeue() as RtmpAsyncResult;
                        _isWriting = true;
                    }
                    else
                        asyncResult = null;
                }
                try
                {
                    if (asyncResult != null)
                        this.InternalBeginWrite(asyncResult.Buffer, asyncResult.Offset, asyncResult.Count, new AsyncCallback(this.BeginWriteCallback), asyncResult);
                }
                catch (Exception exception)
                {
                    lock (_outgoingQueue)
                    {
                        _isWriting = false;
                    }
                    if(asyncResult != null)
                        asyncResult.SetComplete(exception);
                    throw;
                }
            }
        }

        private void BeginWriteCallback(IAsyncResult asyncResult)
        {
            RtmpAsyncResult asyncState = asyncResult.AsyncState as RtmpAsyncResult;
            if (asyncState != null)
            {
                try
                {
                    this.InternalEndWrite(asyncResult);
                    lock (_outgoingQueue)
                    {
                        _isWriting = false;
                    }
                    asyncState.SetComplete(null);
                }
                catch (Exception exception)
                {
                    lock (_outgoingQueue)
                    {
                        _isWriting = false;
                    }
                    asyncState.SetComplete(exception);
                }
                finally
                {
                    try
                    {
                        this.TryBeginWrite();
                    }
                    catch
                    {
                    }
                }
            }
        }

        public override void EndWrite(IAsyncResult asyncResult)
        {
            RtmpAsyncResult result = asyncResult as RtmpAsyncResult;
            try
            {
                if (!asyncResult.IsCompleted)
                {
                    asyncResult.AsyncWaitHandle.WaitOne();
                    /*
                    if (!asyncResult.AsyncWaitHandle.WaitOne(milliseconds, false))
                    {
                        throw new TimeoutException();
                    }
                    */
                }
                if (result.HasException())
                {
                    throw result.Exception;
                }
            }
            finally
            {
                TryBeginWrite();
            }
        }


        public override void Close()
        {
            _innerStream.Close();
            base.Close();
        }

#if NET_2_0
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                lock (_outgoingQueue)
                {
                    _outgoingQueue.Clear();
                }
            }
            base.Dispose(disposing);
        }
#endif

        public override int EndRead(IAsyncResult asyncResult)
        {
            return _innerStream.EndRead(asyncResult);
        }

        public override void Flush()
        {
            _innerStream.Flush();
        }

        public override int Read(byte[] buffer, int offset, int count)
        {
            return _innerStream.Read(buffer, offset, count);
        }

        public override int ReadByte()
        {
            return _innerStream.ReadByte();
        }

        public override long Seek(long offset, SeekOrigin origin)
        {
            return _innerStream.Seek(offset, origin);
        }

        public override void SetLength(long value)
        {
            _innerStream.SetLength(value);
        }

        public override void Write(byte[] buffer, int offset, int count)
        {
            this.EndWrite(this.BeginWrite(buffer, offset, count, null, null));
        }

        public override void WriteByte(byte value)
        {
            _innerStream.WriteByte(value);
        }

        public override bool CanRead
        {
            get
            {
                return _innerStream.CanRead;
            }
        }

        public override bool CanSeek
        {
            get
            {
                return _innerStream.CanSeek;
            }
        }

		public override bool CanWrite
		{
			get
			{
				return _innerStream.CanWrite;
			}
		}

#if NET_2_0
        public override bool CanTimeout
        {
            get
            {
                return _innerStream.CanTimeout;
            }
        }


        public override int ReadTimeout
        {
            get
            {
                return _innerStream.ReadTimeout;
            }
            set
            {
                _innerStream.ReadTimeout = value;
            }
        }

        public override int WriteTimeout
        {
            get
            {
                return _innerStream.WriteTimeout;
            }
            set
            {
                _innerStream.WriteTimeout = value;
            }
        }
#endif
        public System.IO.Stream InnerStream
        {
            get
            {
                return _innerStream;
            }
        }

        public override long Length
        {
            get
            {
                return _innerStream.Length;
            }
        }

        public override long Position
        {
            get
            {
                return _innerStream.Position;
            }
            set
            {
                _innerStream.Position = value;
            }
        }
    }

    sealed class RtmpAsyncResult : IAsyncResult
    {
        private Exception _exception;
        private ManualResetEvent _handle;
        private volatile bool _isComplete;
        private byte[] _buffer;
        private int _offset;
        private int _count;
        private AsyncCallback _callback;
        private object _state;

        internal RtmpAsyncResult(AsyncCallback callback, object state, byte[] buffer, int offset, int count)
        {
            _callback = callback;
            _state = state;
            _buffer = buffer;
            _offset = offset;
            _count = count;
        }

        internal bool HasException()
        {
            return _exception != null;
        }

        internal void SetComplete(Exception ex)
        {
            _exception = ex;
            lock (this)
            {
                if(_isComplete)
                    return;
                _isComplete = true;
                if(_handle != null)
                    _handle.Set();
            }
            if (_callback != null)
                _callback(this);
        }

        internal Exception Exception
        {
            get
            {
                return _exception;
            }
        }

        internal byte[] Buffer
        {
            get
            {
                return _buffer;
            }
        }

        internal int Offset
        {
            get
            {
                return _offset;
            }
        }

        internal int Count
        {
            get
            {
                return _count;
            }
        }

        public object AsyncState
        {
            get
            {
                return _state;
            }
        }

        public WaitHandle AsyncWaitHandle
        {
            get
            {
                lock (this)
                {
                    if(_handle == null)
                        _handle = new ManualResetEvent(_isComplete);
                }
                return _handle;
            }
        }

        public bool CompletedSynchronously
        {
            get
            {
                return false;
            }
        }

        public bool IsCompleted
        {
            get
            {
                lock (this)
                    return _isComplete;
            }
        }
    }

}