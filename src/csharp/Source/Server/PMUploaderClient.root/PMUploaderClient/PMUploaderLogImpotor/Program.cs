using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace Broadleaf.Application.Partsman.Developers
{
    class Program
    {
        static void Main(string[] args)
        {
            if (args.Length != 3)
            {
                Console.WriteLine("PMUploaderLogImpotor.exe srcdir dstdir [option]");
                Console.WriteLine("[option]");
                Console.WriteLine(" /Z    unzipcommand");
                Console.WriteLine(" /I    importcommand");
            }
            DirectoryInfo src = new DirectoryInfo(args[0]);
            DirectoryInfo dst = new DirectoryInfo(args[1]);
            if (args[2] == "/Z")
            {
                UnZipMergeCommand cmd = new UnZipMergeCommand(src, dst);
                cmd.Execute();
            }
            else if (args[2] == "/I")
            {
                SqlImportCommand cmd = new SqlImportCommand(src, dst);
                cmd.Execute();
            }
        }
    }
}
