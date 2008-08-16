using System;
using System.Collections;
using System.Globalization;

#if NET_1_1
using FluorineFx.Util.Nullables;
#else
using NullableDateTime = System.Nullable<System.DateTime>;
#endif

namespace FluorineFx.Scheduling
{
    /// <summary>
    /// A context bundle containing handles to various environment information, that
    /// is given to a <see cref="ScheduledJobDetail" /> instance as it is
    /// executed, and to a <see cref="Trigger" /> instance after the
    /// execution completes.
    /// </summary>
    public class ScheduledJobContext
    {
    }
}
