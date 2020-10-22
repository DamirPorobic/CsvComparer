using System;
using System.IO;

namespace ExcelComparer
{
    internal class Program
    {
        private static readonly char _separator = ';';
        private static readonly string _filePath1 = @"C:\Path\To\File1.CSV";
        private static readonly string _filePath2 = @"C:\Path\To\File2.CSV";
        private static readonly string _logFile = @"C:\Path\To\Log.txt";

        static void Main(string[] args)
        {
            using (var file1 = File.OpenText(_filePath1))
            {
                using (var file2 = File.OpenText(_filePath2))
                {
                    var row = 0;
                    string line1;
                    string line2;
                    string[] headers = { };

                    ClearLog();

                    WriteOutput($@"Checking files '{_filePath1}' and '{_filePath2}'");
                    
                    while ((line1 = file1.ReadLine()) != null && (line2 = file2.ReadLine()) != null)
                    {
                        row++;
                        var cells1 = line1.Split(_separator);
                        var cells2 = line2.Split(_separator);

                        if (row == 3)
                        {
                            headers = line1.Split(_separator);
                        }

                        if (cells1.Length != cells2.Length)
                        {
                            WriteOutput($@"Rows have different Cell count --> {cells1.Length}  !=  {cells2.Length}");
                        }
                        else
                        {
                            for (var cell = 0; cell < cells1.Length; cell++)
                            {
                                if (cells1[cell].Trim() != cells2[cell].Trim())
                                {
                                    WriteOutput($@"Differ at {row}:{headers[cell]} --> '{cells1[cell]}'  !=  '{cells2[cell]}'");
                                }
                            }
                        }
                    }

                    WriteOutput($@"Finished! Rows checked: {row}");

                    Console.WriteLine("Press any key to close");
                    Console.ReadKey();
                }
            }

        }

        private static void ClearLog()
        {
            File.WriteAllText(_logFile, string.Empty);
        }

        private static void WriteOutput(string text)
        {
            Console.WriteLine(text);

            using (var file = new StreamWriter(_logFile, true))
            {
                file.WriteLine(text);
            }
        }
    }
}
