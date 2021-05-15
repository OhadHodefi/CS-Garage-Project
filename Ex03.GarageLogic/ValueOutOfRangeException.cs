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
        private string m_ObjectName; // The object name that threw the exception

        public ValueOutOfRangeException(float i_BottomRange, float i_TopRange, string i_ObjectName)
            : base(string.Format(@"Value received out of range: {0} - {1}", i_BottomRange, i_TopRange))
        {
            m_BottomRange = i_BottomRange;
            m_TopRange = i_TopRange;
            m_ObjectName = i_ObjectName;
        }

        public override string Source 
        {
            get { return m_ObjectName; } 
        }
    }
}
