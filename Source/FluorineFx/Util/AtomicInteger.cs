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
using System.Threading;

namespace FluorineFx.Util
{
    class AtomicInteger
    {
        int _counter;

        public AtomicInteger()
            : this(0)
        {
        }

        public AtomicInteger(int initialValue)
        {
            _counter = initialValue;
        }

        public int Value
        {
            get
            {
                //Reading int32 is atomic already on both 32 and 64 bit systems
                return _counter;
            }
            set
            {
                Interlocked.Exchange(ref _counter, value);
            }
        }

        /// <summary>
        /// Atomically increment by one the current value.
        /// </summary>
        /// <returns></returns>
        public int Increment()
        {
			return Interlocked.Increment(ref _counter);
        }
        /// <summary>
        /// Atomically decrement by one the current value.
        /// </summary>
        /// <returns></returns>
        public int Decrement()
        {
			return Interlocked.Decrement(ref _counter);
        }

        public int PostDecrement()
        {
			return Interlocked.Decrement(ref _counter) + 1;
        }

        public int PostIncrement()
        {
			return Interlocked.Increment(ref _counter) - 1;
        }

#if NET_1_1
#else
        /// <summary>
        /// Atomically add the given value to current value.
        /// </summary>
        /// <param name="delta"></param>
        /// <returns></returns>
        public int Increment(int delta)
        {
            return Interlocked.Add(ref _counter, delta);
        }

		public int Decrement(int delta)
        {
            return Interlocked.Add(ref _counter, -delta);
        }

        public int PostDecrement(int delta)
        {
            return Interlocked.Add(ref _counter, -delta) + delta;
        }

        public int PostIncrement(int delta)
        {
            return (Interlocked.Add(ref _counter, delta) - delta);
        }
#endif

        public override string ToString()
        {
            return this.Value.ToString();
        }
    }
}
