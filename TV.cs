using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartHomeSystem
{
    internal class TV : Device
    {
        public int Volume;
        private int DefaultVolume = 50;

        public TV(string name, bool status) 
            : base(name, status)
        {
            this.Volume = DefaultVolume;
        }


        /*
            if volume level is more than 0 and input is - then decrement the value
            else if the volume level is less than 100 and input is +, increment the value
            else output error message
         */
        public void AdjustVolume(string input)//Method to check for volume levels & increment/decrement
        {
            if (Volume > 0 && input == "-")
            {
                Volume--;
            }
            else if (Volume < 100 && input == "+")
            {
                Volume++;
            }
            else
            {
                Console.WriteLine("Cant peform that action!");
            }
        }
    }
}
