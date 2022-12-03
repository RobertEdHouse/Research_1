using System;
using System.Collections.Generic;
using System.Text;

namespace Research_1
{
    class Test
    {
        public void Test1(World world)
        {
            TestGame(world);
            //TestDays(world);
            //Ask(world);
            //Ask(world);
            //Ask(world);
            //Ask(world);
            //Ask(world);
            //Ask(world);
            //Ask(world);
            //Ask(world);
            //printDialogs(world);
        }
        public void OutputInfo(Patient patient)
        {
            Console.WriteLine(patient.FirstName + " " + patient.LastName);
            Console.WriteLine("Brain " + patient.Brain);
            Console.WriteLine("Heart " + patient.Heart);
            Console.WriteLine("Intestines " + patient.Intestines);
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

        public void printDialog(World world)
        {
            List<Dialog> dialog = world.Avatar.getDialogs(world.CurrentDay,world.Patients[0]);
            foreach (Dialog d in dialog)
            {
                Console.WriteLine("Питання: " + d.Question);
                Console.WriteLine("Вiдповiдь: " + d.Answer);
                Console.WriteLine(" ");
            }

        }
        public void TestGame(World world)
        {
            //while (true)
            //{
            //    if (!world.isGame)
            //        return;
            //    Console.WriteLine("День: " + world.CurrentDay);
            //    OutputInfo(world.Patients[0]);            
            //    NextDay(world);
            //    if(world.Avatar.Medicines.Count>=0)
            //        world.Avatar.giveMedicine(world.Patients[0], world.Avatar.Medicines[0]);
            //    Console.WriteLine("Ліки прийнято\n");
            //}
            
                if (!world.isGame)
                    return;
                Console.WriteLine("День: " + world.CurrentDay);
                OutputInfo(world.Patients[0]);
                NextDay(world);

            if (!world.isGame)
                return;
            Console.WriteLine("День: " + world.CurrentDay);
            OutputInfo(world.Patients[0]);
            if (world.Avatar.Medicines.Count == 0)
                world.Avatar.buyMedicine(new Medicine(0, "Панкреатин", 3, 100));
            world.Avatar.giveMedicine(world.Patients[0], world.Avatar.Medicines[0]);
            Console.WriteLine("Лiки прийнято\n");
            NextDay(world);

            if (!world.isGame)
                return;
            Console.WriteLine("День: " + world.CurrentDay);
            OutputInfo(world.Patients[0]);
            NextDay(world);

            if (!world.isGame)
                return;
            Console.WriteLine("День: " + world.CurrentDay);
            OutputInfo(world.Patients[0]);




        }

        public void TestDays(World world)
        {
            for (int i = 0; i < 4; i++)
            {
                NextDay(world);
                if (!world.isGame)
                    return;
                Console.WriteLine("День: " + world.CurrentDay);
                OutputInfo(world.Patients[0]);
                Console.WriteLine(" ");
                Ask(world);
                printDialog(world);
            }
            
        }

       
    }
   

}
