using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartHomeSystem
{
    internal class Door : Device
    {

        public Door(string name, bool status) 
            : base(name, true) { }

        public override string CheckForStatus() //overrides off/on to open/closed
        {
            string value;

            if (Status == false)
            {
                value = "open";
            }
            else if (Status == true)
            {
                value = "closed";
            }
            else
            {
                value = "broken!";
            }

            return value;
        }
    }
}
