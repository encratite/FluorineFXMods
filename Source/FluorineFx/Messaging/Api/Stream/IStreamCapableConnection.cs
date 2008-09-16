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

namespace FluorineFx.Messaging.Api.Stream
{
    /// <summary>
    /// A connection that supports streaming.
    /// </summary>
    [CLSCompliant(false)]
    public interface IStreamCapableConnection : IConnection, IBWControllable
    {
        /// <summary>
        /// Returns a reserved stream id for use.
        /// According to FCS/FMS regulation, the base is 1.
        /// </summary>
        /// <returns>Reserved stream id.</returns>
        int ReserveStreamId();
        /// <summary>
        /// Unreserve this id for future use.
        /// </summary>
        /// <param name="streamId">ID of stream to unreserve.</param>
        void UnreserveStreamId(int streamId);
        /// <summary>
        /// Deletes the stream with the given id.
        /// </summary>
        /// <param name="streamId">Id of stream to delete.</param>
        void DeleteStreamById(int streamId);
        /// <summary>
        /// Get a stream by its id.
        /// </summary>
        /// <param name="streamId">Stream id.</param>
        /// <returns>Stream with given id.</returns>
        IClientStream GetStreamById(int streamId);
        /// <summary>
        /// Creates a stream that can play only one item.
        /// </summary>
        /// <param name="streamId">Stream id.</param>
        /// <returns>New subscriber stream that can play only one item.</returns>
        ISingleItemSubscriberStream NewSingleItemSubscriberStream(int streamId);
        /// <summary>
        /// Creates a stream that can play a list.
        /// </summary>
        /// <param name="streamId">Stream id.</param>
        /// <returns>New stream that can play sequence of items.</returns>
        IPlaylistSubscriberStream NewPlaylistSubscriberStream(int streamId);
        /// <summary>
        /// Creates a broadcast stream.
        /// </summary>
        /// <param name="streamId">Stream id.</param>
        /// <returns>New broadcast stream.</returns>
        IClientBroadcastStream NewBroadcastStream(int streamId);
        /// <summary>
        /// Total number of video messages that are pending to be sent to a stream.
        /// </summary>
        /// <param name="streamId">Stream id.</param>
        /// <returns>Number of pending video messages.</returns>
        long GetPendingVideoMessages(int streamId);

        IClientStream GetStreamByChannelId(int channelId);
        ICollection GetStreams();
    }
}
