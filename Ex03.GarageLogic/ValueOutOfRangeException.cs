using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex03.GarageLogic
{
    public class ValueOutOfRangeException : Exception
    {
        private float m_BottomRange;
        private float m_TopRange;
        public ValueOutOfRangeException(float i_BottomRange, float i_TopRange)
            : base(string.Format(@"Value received out of range: {0} - {1}", i_BottomRange, i_TopRange))
        {
            m_BottomRange = i_BottomRange;
            m_TopRange = i_TopRange;
        }

    }
}
