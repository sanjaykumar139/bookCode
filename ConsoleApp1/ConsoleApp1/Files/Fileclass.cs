using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace ConsoleApp1.Files
{
    class Fileclass
    {
        public static void MainE()
        {
            MyyDriveInfo();
        }
        static void ShowWindowsDirectoryInfo()
        {
            // Dump directory information. If you are not on Windows, plug in another directory
            DirectoryInfo dir = new DirectoryInfo($@"C{Path.VolumeSeparatorChar}{Path.DirectorySeparatorChar}Windows");
            Console.WriteLine("***** Directory Info *****");
            Console.WriteLine("FullName: {0}", dir.FullName);
            Console.WriteLine("Name: {0}", dir.Name);
            Console.WriteLine("Parent: {0}", dir.Parent);
            Console.WriteLine("Creation: {0}", dir.CreationTime);
            Console.WriteLine("Attributes: {0}", dir.Attributes);
            Console.WriteLine("Root: {0}", dir.Root);
            Console.WriteLine("**************************\n");

            Console.Read();
        }
        static void DisplayImageFiles()
        {
            DirectoryInfo dir = new
            DirectoryInfo(@"C:\Windows\Web\Wallpaper");
            // Get all files with a *.jpg extension.
            FileInfo[] imageFiles = dir.GetFiles("*.jpg", SearchOption.AllDirectories);
            // How many were found?
            Console.WriteLine("Found {0} *.jpg files\n", imageFiles.Length);
            // Now print out info for each file.
            foreach (FileInfo f in imageFiles)
            {
                Console.WriteLine("***************************");
                Console.WriteLine("File name: {0}", f.Name);
                Console.WriteLine("File size: {0}", f.Length);
                Console.WriteLine("Creation: {0}", f.CreationTime);
                Console.WriteLine("Attributes: {0}", f.Attributes);
                Console.WriteLine("***************************\n");
            }
        }
        static void MyyDriveInfo()
        {
            // Get info regarding all drives.
            DriveInfo[] myDrives = DriveInfo.GetDrives();
            // Now print drive stats.
            foreach (DriveInfo d in myDrives)
            {
                Console.WriteLine("Name: {0}", d.Name);
                Console.WriteLine("Type: {0}", d.DriveType);
                // Check to see whether the drive is mounted.
                if (d.IsReady)
                {
                    Console.WriteLine("Free space: {0}", d.TotalFreeSpace);
                    Console.WriteLine("Format: {0}", d.DriveFormat);
                    Console.WriteLine("Label: {0}", d.VolumeLabel);
                }
                Console.WriteLine();
            }
            Console.ReadLine();
        }
    }
}

namespace ConsoleApp1.Files1
{
    class Fileclass
    {
        public static void MainR()
        {
            FileSystemWatcherInfo();
        }

        public enum NotifyFilters1
        {
            Attributes, CreationTime,
            DirectoryName, FileName,
            LastAccess, LastWrite,
            Security, Size
        }

        static void FileSystemWatcherInfo()
        {
            Console.WriteLine("***** The Amazing File Watcher App *****\n");

            // Establish the path to the directory to watch.
            FileSystemWatcher watcher = new FileSystemWatcher();
            try
            {
                watcher.Path = @".";
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine(ex.Message);
                return;
            }
            // Set up the things to be on the lookout for.
            watcher.NotifyFilter = NotifyFilters.LastAccess | NotifyFilters.LastWrite | NotifyFilters.FileName | NotifyFilters.DirectoryName;
            
            // Only watch text files.
            watcher.Filter = "*.txt";
            
            // Add event handlers.
            // Specify what is done when a file is changed, created, or deleted.
            watcher.Changed += (s, e) =>
            Console.WriteLine($"File: {e.FullPath} {e.ChangeType}!");
            watcher.Created += (s, e) =>
            Console.WriteLine($"File: {e.FullPath} {e.ChangeType}!");
            watcher.Deleted += (s, e) =>
            Console.WriteLine($"File: {e.FullPath} {e.ChangeType}!");
            // Specify what is done when a file is renamed.
            watcher.Renamed += (s, e) =>
            Console.WriteLine($"File: {e.OldFullPath} renamed to {e.FullPath}");
            
            
            // Begin watching the directory.
            watcher.EnableRaisingEvents = true;
            // Wait for the user to quit the program.
            Console.WriteLine(@"Press 'q' to quit app.");
            
            // Raise some events.
            using (var sw = File.CreateText("Test.txt"))
            {
                sw.Write("This is some text");
            }
            
            File.Move("Test.txt", "Test2.txt");
            File.Delete("Test2.txt");
            
            while (Console.Read() != 'q') ;
        }
    }
}