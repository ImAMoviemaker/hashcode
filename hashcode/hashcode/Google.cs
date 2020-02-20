using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace hashcode
{
    /// <summary>
    /// Processing the books/deliveries
    /// </summary>
    class Google
    {
        private Library[] libs;
        private int bCount;
        private int lCount;
        private int dCount;
        private List<int> idPoints;

        private Dictionary<int, List<int>> sLibs = new Dictionary<int, List<int>>();

         public void start()
        {
            Console.WriteLine("Starting");
            //readInput("E:\\google\\in\\a_example.txt");
            //readInput("E:\\google\\in\\b_read_on.txt");
            readInput("E:\\google\\in\\c_incunabula.txt");
            //readInput("E:\\google\\in\\d_tough_choices.txt");
            //readInput("E:\\google\\in\\e_so_many_books.txt");
            //readInput("E:\\google\\in\\f_libraries_of_the_world.txt");

            //Logic
            logicOneToOneWithFirstBig();

            //Output
            createOutput("E:\\google\\out\\a_example.txt", sLibs);
        }


        private void logicOneToOneMapping()
        {
            int libCount = 0;
            foreach(Library lib in libs)
            {
                sLibs.Add(libCount, lib.ids);
                libCount++;
                Console.WriteLine("Library: " + libCount);
            }
        }

        private void logicOneToOneWithFirstBig()
        {
            foreach (Library lib in libs.OrderBy(it => it.proDays).OrderBy(it => it.bDay))
            {
                sLibs.Add(lib.libId, lib.ids.OrderBy(it => idPoints[it]).ToList());
                Console.WriteLine("Library: " + lib.libId);
            }
        }

        private void readInput(string path)
        {
            // Read file
            string[] lines = System.IO.File.ReadAllLines(path);

            //Init Array
            libs = new Library[(lines.Length - 2)/2];
            //Get Book, Lib and day count
            bCount = Convert.ToInt32(lines[0].Split(' ')[0]);
            lCount = Convert.ToInt32(lines[0].Split(' ')[1]);
            dCount = Convert.ToInt32(lines[0].Split(' ')[2]);

            //Get score points
            idPoints = lines[1].Split(' ').Select(Int32.Parse).ToList() ;

            int libCounter = 0;
            for(int i = 2; i < lines.Length; i = i + 2)
            {
                libs[libCounter] = new Library(libCounter, Convert.ToInt32(lines[i].Split(' ')[0]), Convert.ToInt32(lines[i].Split(' ')[1]), Convert.ToInt32(lines[i].Split(' ')[2]), lines[i + 1].Split(' ').Select(Int32.Parse).ToList());
                libCounter++;
            }

            Console.WriteLine("Reading finished");
        }

        private void createOutput(string path, Dictionary<int, List<int>> libsOut)
        {
            string outText;

            using (StreamWriter outputFile = new StreamWriter(Path.GetFullPath(path)))
            {

                outputFile.WriteLine(libsOut.Count.ToString());
                foreach (KeyValuePair<int, List<int>> libOut in libsOut)
                {
                    Console.WriteLine("---------------- Writing Library -------------------");
                    outputFile.WriteLine(libOut.Key + " " + libOut.Value.Count);
                    outText = "";
                    foreach (int id in libOut.Value)
                    {
                        Console.WriteLine("New book");
                        outText += id + " ";
                    }
                    outputFile.WriteLine(outText.Substring(0, outText.Length - 1));
                }
            }
            Console.WriteLine("File written");
        }
    }
}