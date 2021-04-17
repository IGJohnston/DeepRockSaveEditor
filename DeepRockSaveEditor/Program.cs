using System;
using System.IO;
using System.Linq;
using System.Collections;
using System.Collections.Generic;

namespace DeepRockSaveEditor
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(BitConverter.IsLittleEndian);
            byte[] reader = File.ReadAllBytes("c:/DRG.sav");
            var saveData = reader.ToList();

            var selectedRess = new List<int>();
            var selectedQtys = new List<int>();

            

            Console.WriteLine("Select resource:\n0 Barley Bulb\n1 Yeast Cone\n2 Malt Star\n3 Starch Nut\n4 Magnite\n5 Bismor\n6 Umanite\n7 Croppa\n8 Enor Pearl\n9 Jadiz\n10 Error Cube\n-1 Finish selection");
            
            var selectedRes = int.Parse(Console.ReadLine());
            while (selectedRes != -1)
            {
                selectedRess.Add(selectedRes);
                selectedRes = int.Parse(Console.ReadLine());
            }

            for (int i = 0; i < selectedRess.Count; i++)
            {
                Console.WriteLine("How many do you want?");
                selectedQtys.Add(int.Parse(Console.ReadLine()));
            }

            //foreach (var item in selectedRess)
            //{
            //    Console.WriteLine(item);
            //}
            //
            //foreach (var item in selectedQtys)
            //{
            //    Console.WriteLine(item);
            //}

            for (int i = 0; i < selectedRess.Count; i++)
            {
                Selector selector = new Selector(selectedRess[i]);
                var targetIndex = selector.getIndex(reader);
                var targetValue = selector.getReplacementBytes(selectedQtys[i]);
                saveData.RemoveRange(targetIndex + 16, 4);
                saveData.InsertRange(targetIndex + 16, targetValue);
            }
            
            var output = saveData.ToArray();
            File.WriteAllBytes("d:/DRGout.sav" ,output);



            //var selectedRes = int.Parse(Console.ReadLine());
            //Console.WriteLine("How many do you want?");
            //var selectedQty = int.Parse(Console.ReadLine());

            //Selector selector = new Selector(selectedRes);
            //var test = selector.getIndex(reader);
            //Console.WriteLine(test);
            //for (int i = test; i < test+20; i++)
            //{
            //    if (i >= test+16){
            //        Console.Write("{0:X}", saveData[i]);
            //        Console.Write(" ");
            //    }
            //}

            //var targetIndex = selector.getIndex(reader);
            //var targetValue = selector.getReplacementBytes(selectedQty);
            //
            //
            //saveData.RemoveRange(targetIndex + 16, 4);
            //saveData.InsertRange(targetIndex + 16, targetValue);
            //var output = saveData.ToArray();
            //File.WriteAllBytes("d:/DRGout.sav" ,output);
        }
    }
}