namespace FileTree
{
    using System;
    using System.IO;

    public class DirectoryTree
    {
        public static void Main()
        {
            // This directory is too large. You can change this string to traverse some smaller directory
            const string RootDirectory = "C:\\Windows";
            const string FilePattern = "*.*";

            Folder root = new Folder(RootDirectory);
            CreateFolders(root, FilePattern);

            Console.WriteLine("Folder: " + root.Name);
            Console.WriteLine("Size in bytes: " + root.GetFilesSize());
        }

        private static void CreateFolders(FileTree.Folder root, string filePattern)
        {
            try
            {
                string[] files = Directory.GetFiles(root.Name, filePattern);
                string[] folders = Directory.GetDirectories(root.Name);
                if (files.Length == 0 && folders.Length == 0)
                {
                    return;
                }
                else
                {
                    FileInfo fileInfo;
                    long size;
                    foreach (var fileName in files)
                    {
                        fileInfo = new FileInfo(fileName);
                        size = fileInfo.Length;
                        root.AddFile(fileName, size);
                    }

                    foreach (var folderName in folders)
                    {
                        root.AddFolder(folderName);
                        CreateFolders(root.ChildFolders[root.ChildFolders.Count - 1], filePattern);
                    }
                }
            }
            catch (UnauthorizedAccessException)
            {
            }
        }
    }
}