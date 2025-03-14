using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartHomeSystem
{
    internal class MyProgram
    {
        internal void Run() //Ahmad
        {
            bool isRunning;
            isRunning = true;

            //create device instances
            Lamp mainLamp = new Lamp("main lamp", false);
            Lamp livingRoomLamp = new Lamp("living room lamp", false);
            Lamp bathRoomLamp = new Lamp("bathroom lamp", true);
            Door mainDoor = new Door("door", true);
            TV tV = new TV("samsung tv", false);

            Child child = new Child();
            Owner owner = new Owner();
            Guest guest = new Guest();

            //create list of instances
            object[] lampInstances = new object[] //lamp list to cut down total code
            {
                mainLamp,
                livingRoomLamp,
                bathRoomLamp
            };

            object[] deviceInstances = new object[]
            {
                mainLamp,
                livingRoomLamp,
                bathRoomLamp,
                mainDoor,
                tV,
            };

            object[] userInstances = new object[]
            {
                child,
                owner,
                guest
            };

            /*
                choose user type
                    have access and no access to certain devices depending on user type
                    if lamp chosen, choose which lamp
                        adjust its brightness and status
                    if tv chosen
                        adjust status and volume
                    if door chosen
                        adjust doors status
             */

            void LampInterface(Lamp mainLamp, Lamp livingLamp, Lamp bathLamp) //interface for lamps
            {
                /*
                    Display lamps on screen
                    loop through lamp array untill finding chosen lamp
                    show the lamps actions and status based on which lamp it is
                 */

                Console.WriteLine("Select which lamp you want to control:");
                Console.WriteLine("");
                Console.WriteLine(mainLamp.Name);
                Console.WriteLine(livingLamp.Name);
                Console.WriteLine(bathLamp.Name);
                string userInput;
                userInput = Console.ReadLine();

                ChosenLamp(LoopThroughLamp(userInput));
            }

            Lamp LoopThroughLamp(string input) //loop through lamps to cut down code
            {
                /*
                    loop through lamp array untill input matches then return its value
                    if not, return null
                 */

                Lamp value;
                value = null;

                foreach (Lamp item in lampInstances) //checks when input matches lamps name and sets value to lamp and returns it, which uses it in ChosenLamp()
                {
                    if (item.Name == input.ToLower())
                    {
                        value = item;
                    }
                }
                return value;
            }

            void ChosenLamp(Lamp lamp) //output the chosen lamp
            {
                /*
                    Display available lamp actions
                    take user input
                 */

                Console.WriteLine("Choose your actions:");
                Console.WriteLine("");
                Console.WriteLine("1. Increase brightness. Current brightness: " + lamp.Brightness);
                Console.WriteLine("2. Decrease brightness.");
                Console.WriteLine("3. Turn lamp on/off. Lamp currently " + lamp.CheckForStatus());

                LampAction(int.Parse(Console.ReadLine()), lamp);
            }

            void LampAction(int input, Lamp lamp) // actions of lamps
            {
                /*
                    checks input and based on input have specific actions
                 */

                if (input == 1)
                {
                    lamp.AdjustBrightness("+");
                }
                else if (input == 2)
                {
                    lamp.AdjustBrightness("-");
                }
                else if (input == 3)
                {
                    lamp.TurnOnOrOff();
                }

                Console.WriteLine(lamp.Brightness);
                Console.WriteLine(lamp.CheckForStatus());
                Console.WriteLine("adasdak dada")
                Console.WriteLine("askdakdasd asdsadla");
            }

            void DoorInterface(Door door) //interface for door
            {
                /*
                    display on the screen for the user to be able to select different actions
                    actions only appear based on if door is closed or not
                 */
                Console.WriteLine("Choose your actions!");
                if (door.CheckForStatus() == "open")
                {
                    Console.WriteLine("1. Close door");
                }
                else if (door.CheckForStatus() == "closed")
                {
                    Console.WriteLine("1. Open door");
                }
                DoorAction(int.Parse(Console.ReadLine()), door);
            }

            void DoorAction(int action, Door door) //action for door
            {
                /*
                    checks input and based on input have specific actions
                 */
                if (action == 1 && door.CheckForStatus() == "closed")
                {
                    door.TurnOnOrOff();//sets status to false
                    Console.WriteLine("Opened door");
                }
                else if (action == 1 && door.CheckForStatus() == "open")
                {
                    door.TurnOnOrOff();//sets status to true
                    Console.WriteLine("Closed door");
                } 
                else
                {
                    Console.WriteLine("Broken");
                }
            }

            void TVInterface(TV tv) //interface to choose actions
            {
                /*
                    display on the screen for the user to be able to select different actions
                    actions only appear based on if tv is on or off
                 */
                Console.WriteLine("Choose your action!");
                
                if (tv.CheckForStatus() == "on")
                {
                    Console.WriteLine("1. Increase volume!");
                    Console.WriteLine("2. Decrease volume!");
                    Console.WriteLine("3. Close TV");
                }
                else if (tv.CheckForStatus() == "off")
                {
                    Console.WriteLine("1. Turn on TV");
                }
                TVAction(int.Parse(Console.ReadLine()), tv);
            }

            void TVAction(int action, TV tv) //action for user input
            {
                /*
                    checks input and based on input have specific actions
                 */

                if (action == 1 && tv.CheckForStatus() == "on")
                {
                    tv.AdjustVolume("+");
                }
                else if (action == 2 && tv.CheckForStatus() == "on")
                {
                    tv.AdjustVolume("-");
                }
                else if (action == 3 && tv.CheckForStatus() == "on")
                {
                    tv.TurnOnOrOff();
                    Console.WriteLine("Turned TV off");
                }
                else if (action == 1 && tv.CheckForStatus() == "off")
                {
                    tv.TurnOnOrOff();
                    Console.WriteLine("Turned TV on");
                }
                else
                {
                    Console.WriteLine("TV broken");
                }
            }

            void FirstOutput()
            {
                Console.WriteLine("Devices available:\n");
                Console.WriteLine("Lamps");
                Console.WriteLine("Door");
                Console.WriteLine("TV");
                Console.WriteLine("Enter what you want to control!");
            }

            void PlayAsUser(string input)//interface to play as a user
            {
                FirstOutput();

                string userInput;
                userInput = Console.ReadLine();

                if (input.ToLower() == "child" && userInstances.Contains(child) && userInstances[0] is Child childInstance) //userInstances[0] is Child item, casting item to be child so it cant be used 
                {//child user type
                    
                    if (userInput == "TV" && childInstance.TVPerm != true) //reject access TV
                    {
                        Console.WriteLine("Access Denied");
                    }
                    else if (userInput.ToLower() == "lamps" && childInstance.LampPerm == true && deviceInstances[0] is Lamp mainLamp && deviceInstances[1] is Lamp livingLamp && deviceInstances[2] is Lamp bathLamp) // check for access
                    { //lamps
                        LampInterface(mainLamp, livingLamp, bathLamp);
                    }
                    else if (userInput.ToLower() == "door" && childInstance.DoorPerm == true && deviceInstances[3] is Door door)
                    {//door
                        DoorInterface(door);
                    }
                    else
                    {
                        Console.WriteLine("Device not found");
                    }
                }
                else if (input.ToLower() == "owner" && userInstances.Contains(owner) && userInstances[1] is Owner ownerInstance)
                {
                    FirstOutput();

                    if (userInput.ToLower() == "tv" && ownerInstance.TVPerm == true && deviceInstances[4] is TV tv)
                    {
                        TVInterface(tv);
                    }
                    else if (userInput.ToLower() == "lamps" && ownerInstance.LampPerm == true && deviceInstances[0] is Lamp mainLamp && deviceInstances[1] is Lamp livingLamp && deviceInstances[2] is Lamp bathLamp)
                    {
                        LampInterface(mainLamp, livingLamp, bathLamp);
                    }
                    else if (userInput.ToLower() == "door" && ownerInstance.DoorPerm == true && deviceInstances[3] is Door door)
                    {
                        DoorInterface(door);
                    }
                    else
                    {
                        Console.WriteLine("Device not found");
                    }
                }
                else if (input.ToLower() == "guest" && userInstances.Contains(guest) && userInstances[2] is Guest guestInstance)
                {
                    FirstOutput();

                    if (userInput.ToLower() == "tv" && guestInstance.TVPerm == true && deviceInstances[4] is TV tv)
                    {
                        TVInterface(tv);
                    }
                    else if (userInput.ToLower() == "lamps" && guestInstance.LampPerm == true && deviceInstances[0] is Lamp mainLamp && deviceInstances[1] is Lamp livingLamp && deviceInstances[2] is Lamp bathLamp)
                    {
                        LampInterface(mainLamp, livingLamp, bathLamp);
                    }
                    else if (userInput.ToLower() == "door" && guestInstance.DoorPerm != true && deviceInstances[3] is Door door)
                    {
                        Console.WriteLine("Denied access");
                    }
                    else
                    {
                        Console.WriteLine("Device not found");
                    }
                }
                else
                {
                    Console.WriteLine("User not found");
                }
            }

            void UserInterface() //starting user interface
            {
                Console.WriteLine("Type the user that you want to be!");
                Console.WriteLine("");
                Console.WriteLine("Owner");
                Console.WriteLine("Child");
                Console.WriteLine("Guest");
                string userInput;
                userInput = Console.ReadLine();
                PlayAsUser(userInput);
            }

            while (isRunning) //program when its running
            {
                UserInterface();
            }

            if (true)
            {
                return true;
            } 
            else if (false)
            {
                return false;
            }
        }
    }
}
