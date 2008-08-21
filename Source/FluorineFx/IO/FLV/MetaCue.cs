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
using System.IO;
using FluorineFx.Util;
using FluorineFx.IO;

namespace FluorineFx.IO.FLV
{
    /// <summary>
    /// Cue point is metadata marker used to control and accompany video playback with client-side application
    /// events. Each cue point have at least one attribute, timestamp. Timestamp specifies position of cue point in
    /// FLV file.
    /// 
    /// <p>Cue points are usually used as event triggers down video flow or navigation points in a file. Cue points are of two types:
    /// <ul>
    /// <li>Embedded into FLV or SWF</li>
    /// <li>External, or added on fly (e.g. with FLVPlayback component or ActionScript) on both server-side and client-side.</li>
    /// </ul>
    /// </p>
    /// 
    /// <p>To add cue point trigger event listener at client-side in Flex/Flash application, use NetStream.onCuePoint event handler.</p>
    /// </summary>
    public class MetaCue : Hashtable, IComparable
    {
        /// <summary>
        /// Cue point type of event.
        /// </summary>
        public const string EVENT = "event";
        /// <summary>
        /// Cue point type of navigation.
        /// </summary>
        public const string NAVIGATION = "navigation";
        /// <summary>
        /// Gets or sets the cue point name.
        /// </summary>
        public string Name
        {
            get { return this["name"] as string; }
            set { this["name"] = value; }
        }
        /// <summary>
        /// Gets or sets the type. Type can be "event" or "navigation".
        /// </summary>
        public string Type
        {
            get { return this["type"] as string; }
            set { this["type"] = value; }
        }
        /// <summary>
        /// Gets or sets the time.
        /// </summary>
        public double Time
        {
            get { return (double)this["time"]; }
            set { this["time"] = value; }
        }


        #region IComparable Members

        public int CompareTo(object obj)
        {
            MetaCue cp = obj as MetaCue;
            double cpTime = cp.Time;
            double time = this.Time;

            if (cpTime > time)
            {
                return -1;
            }
            else if (cpTime < time)
            {
                return 1;
            }
            return 0;
        }

        #endregion
    }
}
