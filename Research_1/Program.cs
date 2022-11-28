using System;
using System.IO;

namespace Research_1
{
    class Program
    {
        
        public static void Main()
        {
            World world = new World();
            world.init(0, 4, 1, 100);
            Test test = new Test();
            test.Test1(world);
        }
        
    }
}
