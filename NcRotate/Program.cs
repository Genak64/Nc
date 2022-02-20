using System;
using NcLibrary;

namespace NcRotate
{
    class Program
    {
        static void Main(string[] args)
        {
            foreach (string item in args) Console.WriteLine(item);

            Console.WriteLine(args.Length);

            Instantiation inst = new Instantiation();
           
            decimal angle = 0;


            switch (args.Length)
            {
                case 0:
                    return;

                case 1:
                    Console.WriteLine("Введите угол поворота");
                    return;

                case 2:
                    if (Decimal.TryParse(args[1],out angle))
                    {
                        angle = angle < 1 ? 1 : angle;
                        var code = GcodeIO.Load(args[0]);
                        if (code == null)
                        {
                            Console.WriteLine("out of file");
                            return;
                        }

                        GcodeIO.Save(args[0], inst.MoveToWorkField(inst.CopyToRotate(code,angle)));

                        
                        Console.WriteLine($"{args[0]} saved");
                        return;
                    }
                    else
                    {
                        Console.WriteLine("угол поворота должно быть числом");
                        return;
                    }
 
            }

        }
    }
}
