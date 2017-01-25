using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CsvSerializer
{
    [System.AttributeUsage(AttributeTargets.All, Inherited = false, AllowMultiple = false)]
    sealed class CsvOrderAttribute : Attribute
    {
        readonly int OrderValue;

        public CsvOrderAttribute(int order)
        {
            this.OrderValue = order;
        }

        public int Order
        {
            get { return OrderValue; }
        }
    }
}

