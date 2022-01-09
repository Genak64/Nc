using System;
using System.Globalization;
using System.Text;
using System.Collections.Generic;
using NcLibrary;

namespace Nc
{
    class Program
    {
        static void Main(string[] args)
        {
            foreach (string item in args) Console.WriteLine(item);

            Console.WriteLine(args.Length);

            Instantiation inst = new Instantiation();
            int Xquantity = 1;
            int Yquantity = 1;
            decimal offset = 0;


            switch (args.Length)
            {
                case 0:
                    return;

                case 1:
                    Console.WriteLine("Введите количество копий");
                    return;

                case 2:
                    if (int.TryParse(args[1], out Xquantity))
                    {
                        Xquantity = Xquantity < 1 ? 1 : Xquantity;
                        var code = GcodeIO.Load(args[0]);
                        if (code == null)
                        {
                            Console.WriteLine("out of file");
                            return;
                        }
                        GcodeIO.Save(GcodeIO.CreateOutName(args[0], Xquantity, Yquantity), inst.CreateCopyXY(code, Xquantity, Yquantity, offset));
                        Console.WriteLine($"{GcodeIO.CreateOutName(args[0], Xquantity, Yquantity)} saved");
                        return;
                    }
                    else
                    {
                        Console.WriteLine("количество копий должно быть целым числом");
                        return;
                    }
                case 3:
                    if (int.TryParse(args[1], out Xquantity) && int.TryParse(args[2], out Yquantity))
                    {
                        Xquantity = Xquantity < 1 ? 1 : Xquantity;
                        Yquantity = Yquantity < 1 ? 1 : Yquantity;
                        var code = GcodeIO.Load(args[0]);
                        if (code == null)
                        {
                            Console.WriteLine("out of file");
                            return;
                        }
                        GcodeIO.Save(GcodeIO.CreateOutName(args[0], Xquantity, Yquantity), inst.CreateCopyXY(code, Xquantity, Yquantity, offset));
                        Console.WriteLine($"{GcodeIO.CreateOutName(args[0], Xquantity, Yquantity)} saved");
                        return;
                    }
                    else
                    {
                        Console.WriteLine("количество копий должно быть целым числом");
                        return;
                    }
                case 4:
                    if (int.TryParse(args[1], out Xquantity) && int.TryParse(args[2], out Yquantity) && decimal.TryParse(args[3], out offset))
                    {
                        Xquantity = Xquantity < 1 ? 1 : Xquantity;
                        Yquantity = Yquantity < 1 ? 1 : Yquantity;
                        var code = GcodeIO.Load(args[0]);
                        if (code == null)
                        {
                            Console.WriteLine("out of file");
                            return;
                        }
                        GcodeIO.Save(GcodeIO.CreateOutName(args[0], Xquantity, Yquantity), inst.CreateCopyXY(code, Xquantity, Yquantity, offset));
                        Console.WriteLine($"{GcodeIO.CreateOutName(args[0], Xquantity, Yquantity)} saved");
                        return;
                    }
                    else
                    {
                        Console.WriteLine("количество копий должно быть целым числом");
                        return;
                    }

            }

        }



    }
}
