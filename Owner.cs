using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartHomeSystem
{
    internal class Owner : User
    {

        public Owner() 
            : base(true, true, true) { }
    }
}
