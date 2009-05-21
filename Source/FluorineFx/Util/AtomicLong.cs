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
    public class AtomicLong
    {
        long _counter;

        public AtomicLong()
            : this(0)
        {
        }

        public AtomicLong(long initialValue)
        {
            _counter = initialValue;
        }

        public long Value
        {
            get
            {
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
        public long Increment()
        {
            return Interlocked.Increment(ref _counter);
        }
        /// <summary>
        /// Atomically decrement by one the current value.
        /// </summary>
        /// <returns></returns>
        public long Decrement()
        {
            return Interlocked.Decrement(ref _counter);
        }

        public long PostDecrement()
        {
            return Interlocked.Decrement(ref _counter) + 1;
        }

        public long PostIncrement()
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
        public long Increment(long delta)
        {
            return Interlocked.Add(ref _counter, delta);
        }

        public long Decrement(long delta)
        {
            return Interlocked.Add(ref _counter, -delta);
        }

        public long PostDecrement(long delta)
        {
            return Interlocked.Add(ref _counter, -delta) + delta;
        }

        public long PostIncrement(long delta)
        {
            return (Interlocked.Add(ref _counter, delta) - delta);
        }
#endif

        public long CompareExchange(long value, long comparand)
        {
            return Interlocked.CompareExchange(ref _counter, value, comparand);
        }

        public bool CompareAndSet(long old, long newValue)
        {
            return old == Interlocked.CompareExchange(ref _counter, newValue, old);
        }

        public long Exchange(long value)
        {
            return Interlocked.Exchange(ref _counter, value);
        }

        public override string ToString()
        {
            return this.Value.ToString();
        }
    }
}
