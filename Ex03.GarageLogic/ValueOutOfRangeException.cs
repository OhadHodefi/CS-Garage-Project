using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex03.GarageLogic
{
    public class ValueOutOfRangeException : Exception
    {

        public ValueOutOfRangeException(Exception i_InnerException, float i_MaxValue)
            :base (string.Format(@"Value received exceeded range {0}", i_MaxValue), i_InnerException)
        { }

        public ValueOutOfRangeException(Exception i_InnerException, int i_BottomRange, int i_TopRange)
            : base(string.Format(@"Value received exceeded range: {0} - {1}", i_InnerException , i_BottomRange), i_InnerException)
        { }

    }
}
