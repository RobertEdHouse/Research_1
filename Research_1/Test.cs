using System;
using System.Collections.Generic;
using System.Text;

namespace Research_1
{
    class Test
    {
        public void Test1(World world)
        {
            OutputInfo(world.Patients[0]);

            NextDay(world);
            Ask(world);
            Ask(world);
            Ask(world);
            Ask(world);
            Ask(world);
            Ask(world);
            Ask(world);
            Ask(world);
            printDialogs(world);
        }
        public void OutputInfo(Patient patient)
        {
            Console.WriteLine(patient.FirstName + " " + patient.LastName);
            Console.WriteLine("Brain " + patient.Brain);
            Console.WriteLine("Heart " + patient.Heart);
            Console.WriteLine("Liver " + patient.Liver);
            Console.WriteLine("Lungs " + patient.Lungs);
            Console.WriteLine("Stomach " + patient.Stomach);
            Console.WriteLine("Temperature " + patient.Temperature);
            Console.WriteLine(" ");
        }
        public void Ask(World world)
        {
            world.Avatar.ask(world.Questions[0], world.Patients[0], world.CurrentDay);
            world.Avatar.ask(world.Questions[1], world.Patients[0], world.CurrentDay);
            
        }
        public void NextDay(World world)
        {
            world.nextDay();
            
        }
        public void printDialogs(World world)
        {
            List<Dialog> dialog = world.Avatar.getDialogs(world.Patients[0]);
            foreach (Dialog d in dialog)
            {
                Console.WriteLine("Питання: " + d.Question);
                Console.WriteLine("Вiдповiдь: " + d.Answer);
                Console.WriteLine(" ");
            }
            
        }
    }
   

}
