using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartHomeSystem
{
    public class Device
    {
        /*
            has name andstatus variables
            method to set status true or false
                if status false
                    set true
                if status true
                    set false
            method to return on/off instead of true or false
                if true return on
                if false return off
            virtual method to override return of on/off to open/closed
                if true return open
                if false return closed
         */

        public string Name;
        public bool Status;

        public Device(string name, bool status)
        {
            this.Name = name;
            this.Status = status;
        }

        public void TurnOnOrOff() //sets devices on or off based on what is currently
        {
            if (this.Status == false)
            {
                this.Status = true;
            }
            else if (this.Status == true)
            {
                this.Status = false;
            }
        }

        public virtual string CheckForStatus() //sends on/off instead true/false
        {
            string value;

            if (Status == false)
            {
                value = "off";
            }
            else if (Status == true)
            {
                value = "on";
            }
            else
            {
                value = "Broken!";
            }

            return value;
        }
    }
}
