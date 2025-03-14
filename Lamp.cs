using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartHomeSystem
{
    internal class Lamp : Device
    {
        public int Brightness;
        private int DefaultBrightness = 70;
        public string Name;

        public Lamp(string name, bool status)
            : base(name, status)
        {
            this.Name = name;
            this.Brightness = DefaultBrightness;
        }

        /*
            if brightness level is more than 0 and input is - then decrement the value
            else if the brightness level is less than 100 and input is +, increment the value
            else output error message
         */

        public void AdjustBrightness(string input) //Method to check for brightness levels & increment/decrement
        {
            if (Brightness > 0 && input == "-")
            {
                Brightness--;
            }
            else if (Brightness < 100 && input == "+")
            {
                Brightness++;
            } 
            else
            {
                Console.WriteLine("Cant peform that action!");
            }
        }
    }
}
