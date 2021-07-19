using FacadePattern;
using FacadePattern.RobotParts;
using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp2design.Facade
{
     class FacadePattern
    {
         static void MainQeww(string[] args)
        {
            Console.WriteLine("***Facade Pattern Demo***\n");

            //Creating Robots
            RobotFacade rf1 = new RobotFacade();
            rf1.ConstructMilanoRobot();

            RobotFacade rf2 = new RobotFacade();
            rf2.ConstructRobonautRobot();

            //Destroying robots
            rf1.DestroyMilanoRobot();
            rf2.DestroyRobonautRobot();

            Console.ReadLine();
        }
    }
}

// RobotBody.cs

namespace FacadePattern.RobotParts
{
    public class RobotBody
    {
        public void CreateHands()
        {
            Console.WriteLine("Hands manufactured");
        }
        public void CreateRemainingParts()
        {
            Console.WriteLine("Remaining parts (other than hands) are  created");
        }
        public void DestroyHands()
        {
            Console.WriteLine("The robot's hands are destroyed");
        }
        public void DestroyRemainingParts()
        {
            Console.WriteLine("The robot's remaining parts are destroyed");
        }
    }
}
//RobotColor.cs

namespace FacadePattern.RobotParts
{
    public class RobotColor
    {
        public void SetDefaultColor()
        {
            Console.WriteLine("This is steel color robot.");
        }
        public void SetGreenColor()
        {
            Console.WriteLine("This is a green color robot.");
        }
    }
}
// RobotHands.cs

namespace FacadePattern.RobotParts
{
    public class RobotHands
    {
        public void SetMilanoHands()
        {
            Console.WriteLine("The robot will have EH1 Milano hands");
        }
        public void SetRobonautHands()
        {
            Console.WriteLine("The robot will have Robonaut hands");
        }
        public void ResetMilanoHands()
        {
            Console.WriteLine("EH1 Milano hands are about to be  destroyed");
        }
        public void ResetRobonautHands()
        {
            Console.WriteLine("Robonaut hands are about to be destroyed");
        }
    }
}
// RobotFacade.cs

//using FacadePattern.RobotParts;
namespace FacadePattern
{
    public class RobotFacade
    {
        RobotColor rc;
        RobotHands rh;
        RobotBody rb;
        public RobotFacade()
        {
            rc = new RobotColor();
            rh = new RobotHands();
            rb = new RobotBody();
        }
        public void ConstructMilanoRobot()
        {
            Console.WriteLine("Creation of a Milano Robot Start");
            rc.SetDefaultColor();
            rh.SetMilanoHands();
            rb.CreateHands();
            rb.CreateRemainingParts();
            Console.WriteLine("Milano Robot Creation End");
            Console.WriteLine();
        }
        public void ConstructRobonautRobot()
        {
            Console.WriteLine("Initiating the creational process of a Robonaut Robot");
            rc.SetGreenColor();
            rh.SetRobonautHands(); rb.CreateHands();
            rb.CreateRemainingParts();
            Console.WriteLine("A Robonaut Robot is created");
            Console.WriteLine();
        }
        public void DestroyMilanoRobot()
        {
            Console.WriteLine("Milano Robot's destruction process is started");
            rh.ResetMilanoHands();
            rb.DestroyHands();
            rb.DestroyRemainingParts();
            Console.WriteLine("Milano Robot's destruction process is over");
            Console.WriteLine();
        }
        public void DestroyRobonautRobot()
        {
            Console.WriteLine("Initiating a Robonaut Robot's destruction process.");
            rh.ResetRobonautHands();
            rb.DestroyHands();
            rb.DestroyRemainingParts();
            Console.WriteLine("A Robonaut Robot is destroyed");
            Console.WriteLine();
        }
    }
}
