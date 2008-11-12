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

namespace FluorineFx.IO.Mp3
{
    /// <summary>
    /// Header of an Mp3 frame.
    /// http://mpgedit.org/mpgedit/mpeg_format/mpeghdr.htm
    /// </summary>
    class Mp3Header
    {
        /// <summary>
        /// MP3 bitrates
        /// </summary>
        private static int[,] BITRATES = new int[,]{
			{ 0, 32, 64, 96, 128, 160, 192, 224, 256, 288, 320, 352, 384, 416, 448, -1 },
			{ 0, 32, 48, 56, 64, 80, 96, 112, 128, 160, 192, 224, 256, 320, 384, -1 },
			{ 0, 32, 40, 48, 56, 64, 80, 96, 112, 128, 160, 192, 224, 256, 320, -1 },
			{ 0, 32, 48, 56, 64, 80, 96, 112, 128, 144, 160, 176, 192, 224, 256, -1 },
			{ 0, 8, 16, 24, 32, 40, 48, 56, 64, 80, 96, 112, 128, 144, 160, -1 }
        };
        /// <summary>
        /// Sample rates
        /// </summary>
        private static int[,] SAMPLERATES = {
	        // Version 2.5
			{ 11025, 12000, 8000, -1 },
			// Unknown version
			{ -1, -1, -1, -1 },
			// Version 2
			{ 22050, 24000, 16000, -1 },
			// Version 1
			{ 44100, 48000, 32000, -1 }, };

        /// <summary>
        /// Frame sync data
        /// </summary>
        private int _data;
        /// <summary>
        /// Audio version id
        /// </summary>
        private byte _audioVersionId;
        /// <summary>
        /// Layer description
        /// </summary>
        private byte _layerDescription;
        /// <summary>
        /// Protection bit
        /// </summary>
        private bool _protectionBit;
        /// <summary>
        /// Bitrate used (index in array of bitrates)
        /// </summary>
        private byte _bitRateIndex;
        /// <summary>
        /// Sampling rate used (index in array of sample rates)
        /// </summary>
        private byte _samplingRateIndex;
        /// <summary>
        /// Padding bit
        /// </summary>
        private bool _paddingBit;
        /// <summary>
        /// Channel mode
        /// </summary>
        private byte _channelMode;

        public Mp3Header(int data)
        {
            if ((data & 0xffe00000) != 0xffe00000)
                throw new Exception("Invalid frame sync word");
            _data = data;
            // Strip signed bit
            data &= 0x1fffff;
            _audioVersionId = (byte)((data >> 19) & 3);
            _layerDescription = (byte)((data >> 17) & 3);
            _protectionBit = ((data >> 16) & 1) == 0;
            _bitRateIndex = (byte)((data >> 12) & 15);
            _samplingRateIndex = (byte)((data >> 10) & 3);
            _paddingBit = ((data >> 9) & 1) != 0;
            _channelMode = (byte)((data >> 6) & 3);
        }

        public int Data
        {
            get { return _data; }
        }

        public bool IsStereo
        {
            get { return _channelMode != 3; }
        }

        public bool IsProtected
        {
            get { return _protectionBit; }
        }

        public int BitRate
        {
            get
            {
                int result;
                switch (_audioVersionId)
                {
                    case 1:
                        // Unknown
                        return -1;
                    case 0:
                    case 2:
                        // Version 2 or 2.5
                        if (_layerDescription == 3)
                        {
                            // Layer 1
                            result = BITRATES[3,_bitRateIndex];
                        }
                        else if (_layerDescription == 2 || _layerDescription == 1)
                        {
                            // Layer 2 or 3
                            result = BITRATES[4, _bitRateIndex];
                        }
                        else
                        {
                            // Unknown layer
                            return -1;
                        }
                        break;
                    case 3:
                        // Version 1
                        if (_layerDescription == 3)
                        {
                            // Layer 1
                            result = BITRATES[0,_bitRateIndex];
                        }
                        else if (_layerDescription == 2)
                        {
                            // Layer 2
                            result = BITRATES[1,_bitRateIndex];
                        }
                        else if (_layerDescription == 1)
                        {
                            // Layer 3
                            result = BITRATES[2, _bitRateIndex];
                        }
                        else
                        {
                            // Unknown layer
                            return -1;
                        }
                        break;
                    default:
                        // Unknown version
                        return -1;
                }
                return result * 1000;
            }
        }

        public int SampleRate
        {
            get
            {
                return SAMPLERATES[_audioVersionId, _samplingRateIndex];
            }
        }

        public int FrameSize
        {
            get
            {
                switch (_layerDescription)
                {
                    case 3:
                        // Layer 1
                        return (12 * BitRate / SampleRate + (_paddingBit ? 1 : 0)) * 4;
                    case 2:
                    case 1:
                        // Layer 2 and 3
                        if (_audioVersionId == 3)
                        {
                            // MPEG 1
                            return 144 * BitRate / SampleRate + (_paddingBit ? 1 : 0);
                        }
                        else
                        {
                            // MPEG 2 or 2.5
                            return 72 * BitRate / SampleRate + (_paddingBit ? 1 : 0);
                        }
                    default:
                        // Unknown
                        return -1;
                }
            }
        }

        public double FrameDuration
        {
            get
            {
                switch (_layerDescription)
                {
                    case 3:
                        // Layer 1
                        return 384 / (SampleRate * 0.001);

                    case 2:
                    case 1:
                        if (_audioVersionId == 3)
                        {
                            // MPEG 1, Layer 2 and 3
                            return 1152 / (SampleRate * 0.001);
                        }
                        else
                        {
                            // MPEG 2 or 2.5, Layer 2 and 3
                            return 576 / (SampleRate * 0.001);
                        }

                    default:
                        // Unknown
                        return -1;
                }
            }
        }
    }
}
