using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    // abstract class can have public constructor but can't be instantiated directly
    abstract class Features
    {
        //Make it protected as it will be called by only child classes

        //we can have it public as well but, since cannot be instantiated there is no need to make it public

        //On creation of every child's this constructor will always be called
        // to initialize libraries.
        // Constructor in abstract class C# example
        protected Features()
        {
            Console.WriteLine("Abstract class constructor");
            //initialize library 1, library 2 etc.
            Console.WriteLine("Initializing Music/Video database library");
        }

        //Have some implementation function
        public void login(String username, String password)
        {
            //implementation
        }
        //defer implementation to child classes
        public abstract void download();

    }

    class Music : Features
    {
        public Music()
        {
            Console.WriteLine("Music Constructor");
        }

        public override void download()
        {
            //download music from here http://www............
            Console.WriteLine("Music downloading..\n.");
        }

    }

    class Video : Features
    {
        public Video()
        {
            Console.WriteLine("Video Constructor");
        }

        public override void download()
        {
            //download music from here http://www............
            Console.WriteLine("Video downloading...");
        }

    }

    //Test

    class AbstractConstructor
    {
        static void Main(string[] args)
        {
            Music m = new Music();
            m.download();

            //process videos
            Video v = new Video();
            v.download();

        }
    }
    /*
     https://stackoverflow.com/questions/46801776/mock-static-class-using-moq
     */
}

