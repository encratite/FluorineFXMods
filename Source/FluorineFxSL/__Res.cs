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
using System.Resources;

namespace FluorineFx
{
	/// <summary>
	/// This type supports the Fluorine infrastructure and is not intended to be used directly from your code.
	/// </summary>
	internal class __Res
	{
		private static ResourceManager _resMgr;

        internal const string Fluorine_Fatal = "Fluorine_Fatal";

        internal const string Amf_Begin = "Amf_Begin";
        internal const string Amf_End = "Amf_End";
        internal const string Amf_Fatal = "Amf_Fatal";
        internal const string Amf_Fatal404 = "Amf_Fatal404";
        internal const string Amf_ReadBodyFail = "Amf_ReadBodyFail";
        internal const string Amf_SerializationFail = "Amf_SerializationFail";
        internal const string Amf_ResponseFail = "Amf_ResponseFail";

        internal const string Rtmpt_Begin = "Rtmpt_Begin";
        internal const string Rtmpt_End = "Rtmpt_End";
        internal const string Rtmpt_Fatal = "Rtmpt_Fatal";
        internal const string Rtmpt_Fatal404 = "Rtmpt_Fatal404";
        internal const string Rtmpt_CommandBadRequest = "Rtmpt_CommandBadRequest";
        internal const string Rtmpt_CommandNotSupported = "Rtmpt_CommandNotSupported";
        internal const string Rtmpt_CommandOpen = "Rtmpt_CommandOpen";
        internal const string Rtmpt_CommandSend = "Rtmpt_CommandSend";
        internal const string Rtmpt_CommandIdle = "Rtmpt_CommandIdle";
        internal const string Rtmpt_CommandClose = "Rtmpt_CommandClose";
        internal const string Rtmpt_ReturningMessages = "Rtmpt_ReturningMessages";
        internal const string Rtmpt_NotifyError = "Rtmpt_NotifyError";
        internal const string Rtmpt_UnknownClient = "Rtmpt_UnknownClient";

        internal const string Rtmp_HSInitBuffering = "Rtmp_HSInitBuffering";
        internal const string Rtmp_HSReplyBuffering = "Rtmp_HSReplyBuffering";
        internal const string Rtmp_HeaderBuffering = "Rtmp_HeaderBuffering";
        internal const string Rtmp_ChunkSmall = "Rtmp_ChunkSmall";
        internal const string Rtmp_DecodeHeader = "Rtmp_DecodeHeader";
        internal const string Rtmp_ServerAddMapping = "Rtmp_ServerAddMapping";
        internal const string Rtmp_ServerRemoveMapping = "Rtmp_ServerRemoveMapping";
        internal const string Rtmp_SocketListenerAccept = "Rtmp_SocketListenerAccept";
        internal const string Rtmp_SocketBeginReceive = "Rtmp_SocketBeginReceive";
        internal const string Rtmp_SocketReceiveProcessing = "Rtmp_SocketReceiveProcessing";
        internal const string Rtmp_SocketBeginRead = "Rtmp_SocketBeginRead";
        internal const string Rtmp_SocketReadProcessing = "Rtmp_SocketReadProcessing";
        internal const string Rtmp_SocketBeginSend = "Rtmp_SocketBeginSend";
        internal const string Rtmp_SocketSendProcessing = "Rtmp_SocketSendProcessing";
        internal const string Rtmp_SocketConnectionReset = "Rtmp_SocketConnectionReset";
        internal const string Rtmp_SocketDisconnectProcessing = "Rtmp_SocketDisconnectProcessing";
        internal const string Rtmp_ConnectionClose = "Rtmp_ConnectionClose";
        internal const string Rtmp_CouldNotProcessMessage = "Rtmp_CouldNotProcessMessage";

        internal const string Arg_Mismatch = "Arg_Mismatch";

        internal const string Cache_Hit = "Cache_Hit";
        internal const string Cache_HitKey = "Cache_HitKey";

        internal const string Compiler_Error = "Compiler_Error";

        internal const string ClassDefinition_Loaded = "ClassDefinition_Loaded";
        internal const string ClassDefinition_LoadedUntyped = "ClassDefinition_LoadedUntyped";
        internal const string Externalizable_CastFail = "Externalizable_CastFail";
        internal const string TypeIdentifier_Loaded = "TypeIdentifier_Loaded";
        internal const string TypeLoad_ASO = "TypeLoad_ASO";
        internal const string TypeMapping_Write = "TypeMapping_Write";
        internal const string TypeSerializer_NotFound = "TypeSerializer_NotFound";

        internal const string Endpoint_BindFail = "Endpoint_BindFail";
        internal const string Endpoint_Bind = "Endpoint_Bind";

        internal const string Type_InitError = "Type_InitError";
        internal const string Type_Mismatch = "Type_Mismatch";
        internal const string Type_MismatchMissingSource = "Type_MismatchMissingSource";

        internal const string Destination_NotFound = "Destination_NotFound";

        internal const string Subtopic_Invalid = "Subtopic_Invalid";
        internal const string Selector_InvalidResult = "Selector_InvalidResult";

        internal const string SubscriptionManager_Remove = "SubscriptionManager_Remove";
        internal const string SubscriptionManager_CacheExpired = "SubscriptionManager_CacheExpired";

        internal const string Invalid_Destination = "Invalid_Destination";

        internal const string Security_AccessNotAllowed = "Security_AccessNotAllowed";
        internal const string Security_LoginMissing = "Security_LoginMissing";
        internal const string Security_ConstraintRefNotFound = "Security_ConstraintRefNotFound";
        internal const string Security_ConstraintSectionNotFound = "Security_ConstraintSectionNotFound";
        internal const string Security_AuthenticationFailed = "Security_AuthenticationFailed";

        internal const string SocketServer_Start = "SocketServer_Start";
        internal const string SocketServer_Started = "SocketServer_Started";
        internal const string SocketServer_Stopping = "SocketServer_Stopping";
        internal const string SocketServer_Stopped = "SocketServer_Stopped";
        internal const string SocketServer_Failed = "SocketServer_Failed";
        internal const string SocketServer_ListenerFail = "SocketServer_ListenerFail";
        internal const string SocketServer_SocketOptionFail = "SocketServer_SocketOptionFail";

        internal const string RtmpEndpoint_Start = "RtmpEndpoint_Start";
        internal const string RtmpEndpoint_Starting = "RtmpEndpoint_Starting";
        internal const string RtmpEndpoint_Started = "RtmpEndpoint_Started";
        internal const string RtmpEndpoint_Stopping = "RtmpEndpoint_Stopping";
        internal const string RtmpEndpoint_Stopped = "RtmpEndpoint_Stopped";
        internal const string RtmpEndpoint_Failed = "RtmpEndpoint_Failed";
        internal const string RtmpEndpoint_Error = "RtmpEndpoint_Error";

        internal const string Scope_Connect = "Scope_Connect";
        internal const string Scope_NotFound = "Scope_NotFound";
        internal const string Scope_ChildNotFound = "Scope_ChildNotFound";
        internal const string Scope_Check = "Scope_Check";
        internal const string Scope_CheckHostPath = "Scope_CheckHostPath";
        internal const string Scope_CheckWildcardHostPath = "Scope_CheckWildcardHostPath";
        internal const string Scope_CheckHostNoPath = "Scope_CheckHostNoPath";
        internal const string Scope_CheckDefaultHostPath = "Scope_CheckDefaultHostPath";
        internal const string Scope_UnregisterError = "Scope_UnregisterError";
        internal const string Scope_DisconnectError = "Scope_DisconnectError";

        internal const string SharedObject_Delete = "SharedObject_Delete";
        internal const string SharedObject_DeleteError = "SharedObject_DeleteError";
        internal const string SharedObject_StoreError = "SharedObject_StoreError";
        internal const string SharedObject_Sync = "SharedObject_Sync";
        internal const string SharedObject_SyncConnError = "SharedObject_SyncConnError";

        internal const string SharedObjectService_CreateStore = "SharedObjectService_CreateStore";
        internal const string SharedObjectService_CreateStoreError = "SharedObjectService_CreateStoreError";

        internal const string DataDestination_RemoveSubscriber = "DataDestination_RemoveSubscriber";

        internal const string DataService_Unknown = "DataService_Unknown";

        internal const string Service_NotFound = "Service_NotFound";

        internal const string Identity_Failed = "Identity_Failed";

        internal const string Invoke_Method = "Invoke_Method";
        internal const string Invocation_Failed = "Invocation_Failed";

        internal const string Channel_NotFound = "Channel_NotFound";

        internal const string Service_Mapping = "Service_Mapping";

        internal const string TypeHelper_Probing = "TypeHelper_Probing";
        internal const string TypeHelper_LoadDllFail = "TypeHelper_LoadDllFail";
        internal const string TypeHelper_ConversionFail = "TypeHelper_ConversionFail";

        internal const string Invocation_NoSuitableMethod = "Invocation_NoSuitableMethod";
        internal const string Invocation_Ambiguity = "Invocation_Ambiguity";
        internal const string Invocation_ParameterType = "Invocation_ParameterType";

        internal const string Reflection_MemberNotFound = "Reflection_MemberNotFound";
        internal const string Reflection_PropertyReadOnly = "Reflection_PropertyReadOnly";
        internal const string Reflection_PropertySetFail = "Reflection_PropertySetFail";
        internal const string Reflection_PropertyIndexFail = "Reflection_PropertyIndexFail";
        internal const string Reflection_FieldSetFail = "Reflection_FieldSetFail";

        internal const string Compress_Info = "Compress_Info";

        internal const string ServiceAdapter_MissingSettings = "ServiceAdapter_MissingSettings";
        internal const string ServiceAdapter_Stop = "ServiceAdapter_Stop";

		internal static string GetString(string key)
		{
			if (_resMgr == null)
			{
                _resMgr = new ResourceManager("FluorineFx.Resources.Resource", typeof(__Res).Assembly);
			}
			string text = _resMgr.GetString(key);
			if (text == null)
			{
				throw new Exception("Missing resource from FluorineFx library!  Key: " + key);
			}
			return text;
		}

		internal static string GetString(string key, params object[] inserts)
		{
			return string.Format(GetString(key), inserts);
		}
	}
}
