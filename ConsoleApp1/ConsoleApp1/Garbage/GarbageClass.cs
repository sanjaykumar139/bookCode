using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp1.Garbage
{
    class GarbageClass
    {
        static void MainWqaw(string[] args)
        {
            Console.WriteLine("***** Fun with System.GC *****");
            // Print out estimated number of bytes on heap.
            Console.WriteLine("Estimated bytes on heap: {0}", GC.GetTotalMemory(false));

            // MaxGeneration is zero based, so add 1 for display purposes.
            Console.WriteLine("This OS has {0} object generations.\n", (GC.MaxGeneration + 1));

            Car refToMyCar = new Car("Zippy", 100);
            Console.WriteLine(refToMyCar.ToString());

            // Print out generation of refToMyCar object.
            Console.WriteLine("Generation of refToMyCar is: {0}", GC.GetGeneration(refToMyCar));
            Console.ReadLine();
        }

        static void MainWqaws(string[] args)
        {
            Console.WriteLine("***** Fun with System.GC *****");
            // Print out estimated number of bytes on heap.
            Console.WriteLine("Estimated bytes on heap: {0}", GC.GetTotalMemory(false));

            // MaxGeneration is zero based.
            Console.WriteLine("This OS has {0} object generations.\n", (GC.MaxGeneration + 1));

            Car refToMyCar = new Car("Zippy", 100);
            Console.WriteLine(refToMyCar.ToString());

            // Print out generation of refToMyCar.
            Console.WriteLine("\nGeneration of refToMyCar is: {0}", GC.GetGeneration(refToMyCar));

            // Make a ton of objects for testing purposes.
            object[] tonsOfObjects = new object[50000];
            for (int i = 0; i < 50000; i++)
                tonsOfObjects[i] = new object();
            Console.WriteLine("Generation of tonsOfObjects[9000] is: {0}", GC.GetGeneration(tonsOfObjects[9000]));


            // Collect only gen 0 objects.
            GC.Collect(0, GCCollectionMode.Forced);
            GC.WaitForPendingFinalizers();

            // Print out generation of refToMyCar.
            Console.WriteLine("Generation of refToMyCar is: {0}",
            GC.GetGeneration(refToMyCar));

            // See if tonsOfObjects[9000] is still alive.
            if (tonsOfObjects[9000] != null)
            {
                Console.WriteLine("Generation of tonsOfObjects[9000] is: {0}", GC.GetGeneration(tonsOfObjects[3000]));
            }
            else
                Console.WriteLine("tonsOfObjects[9000] is no longer alive.");

            // Print out how many times a generation has been swept.
            Console.WriteLine("\nGen 0 has been swept {0} times", GC.CollectionCount(0));
            Console.WriteLine("Gen 1 has been swept {0} times", GC.CollectionCount(1));
            Console.WriteLine("Gen 2 has been swept {0} times", GC.CollectionCount(2));
            Console.ReadLine();
        }

        static void MainQqa(string[] args)
        {
            Console.WriteLine("***** Fun with Finalizers *****\n");
            Console.WriteLine("Hit the return key to shut down this app");
            Console.WriteLine("and force the GC to invoke Finalize()");
            Console.WriteLine("for finalizable objects created in this AppDomain.");
            Console.ReadLine();
            MyResourceWrapper rw = new MyResourceWrapper();
        }
    }

    // Override System.Object.Finalize() via finalizer syntax.
    class MyResourceWrapper
    {
        // Clean up unmanaged resources here.
        // Beep when destroyed (testing purposes only!)
        ~MyResourceWrapper() => Console.Beep();
    }
    class Car
    {
        public string PetName { get; set; } = "";
        public string Color { get; set; } = "";
        public int Speed { get; set; }
        public string Make { get; set; } = "";
        public Car(string PetName, int Speed)
        {
            this.PetName = PetName;
            this.Speed = Speed;
        }
    }
}

namespace ConsoleApp1.Lazy
{
    class Myabc
    {
        static void MainQqa(string[] args)
        {
            Console.WriteLine("***** Fun with Lazy Instantiation *****\n");
            // This caller does not care about getting all songs,
            // but indirectly created 10,000 objects!
            MediaPlayer myPlayer = new MediaPlayer();
            myPlayer.Play();
            Console.ReadLine();
        }
    }

    // Represents a single song.
    class Song
    {
        public string Artist { get; set; }
        public string TrackName { get; set; }
        public double TrackLength { get; set; }
    }

    // Represents all songs on a player.
    class AllTracks
    {
        // Our media player can have a maximum
        // of 10,000 songs.
        private Song[] allSongs = new Song[10000];
        public AllTracks()
        {
            // Assume we fill up the array
            // of Song objects here.
            Console.WriteLine("Filling up the songs!");
        }
    }
    // The MediaPlayer has-an AllTracks object.
    class MediaPlayer
    {
        // Assume these methods do something useful.
        public void Play() { /* Play a song */ }
        public void Pause() { /* Pause the song */ }
        public void Stop() { /* Stop playback */ }
        private AllTracks allSongs = new AllTracks();
        public AllTracks GetAllTracks()
        {
            // Return all of the songs.
            return allSongs;
        }
    }
}