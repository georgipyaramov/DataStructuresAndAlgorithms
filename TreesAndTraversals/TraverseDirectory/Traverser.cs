// 2. Write a program to traverse the directory C:\WINDOWS and all its 
// subdirectories recursively and to display all files matching the mask *.exe. 
// Use the class System.IO.Directory.

namespace TraverseDirectory
{
    using System;
    using System.IO;

    public class Traverser
    {
        static void Main()
        {
            TraverseAllDirectories("C:\\Windows");
        }
      
        private static void TraverseAllDirectories(string path)
        {
            string[] subDirectory = null;
            try
            {
                subDirectory = Directory.GetDirectories(path);
            }
            catch (UnauthorizedAccessException)
            {
                Console.WriteLine("Unauthorized Access");
                return;
            }

            PrintExeFiles(path);

            foreach (var subDir in subDirectory)
            {
                TraverseAllDirectories(subDir);
            }
        }

        private static void PrintExeFiles(string path)
        {
            string[] allExeFiles = Directory.GetFiles(path, "*.exe");
            if (allExeFiles.Length > 0)
            {
                Console.WriteLine(string.Join("\n", allExeFiles));
            }

        }
    }
}
