using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartHomeSystem
{
    internal class User
    {

        /*
            defualt values are set to true
                derived classes modify default values
            be able to read values from derived classes
         */


        public bool LampPerm = true;
        public bool TVPerm = true;
        public bool DoorPerm = true;

        public User(bool lampPerm, bool tVPerm, bool doorPerm)
        {
            this.LampPerm = lampPerm;
            this.TVPerm = tVPerm;
            this.DoorPerm = doorPerm;
        }
    }
}
