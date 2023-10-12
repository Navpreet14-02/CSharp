using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Oct_12
{
    internal class Properties
    {

        private int _age;
        public int Age
        {
            get { return _age; }
            set { _age = value; }
        }
        public string Name { get; init; }
    }
}
