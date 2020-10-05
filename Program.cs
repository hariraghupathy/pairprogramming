using System;
using MarsRover.BusinessLogic;
using MarsRover.Model;
using MarsRover.Service;
using Microsoft.Extensions.DependencyInjection;
// Mission object
// Rover Position and Location => (x,y,Z) where Z in {N, E, W, S}
// Plateau: Grid of positions => { x, y, Z }, where (0,0,N) => (x=0, y=0, Z=N)
// Message: String of characters (xxxxxx), where x in { L,R,M } => (L=SpinLeft, R=SpinRight, M=MoveForward)
// Input = 5 Lines: if(upper-right) 
namespace MarsRover
{
    class Program
    {
        static void Main(string[] args)
        {
            // setting up dependency injection
            var serviceProvider = new ServiceCollection().
                                 AddSingleton<IRoverLogic, RoverLogic>().
                                 AddSingleton<IRoverService, RoverService>().
                                 BuildServiceProvider();
            var businessInstance = serviceProvider.GetService<IRoverLogic>();
            var serviceInstance = serviceProvider.GetService<IRoverService>();
            businessInstance.roverService = serviceInstance;

            string[] output = new string[2]; 
            // get the upper coordinates
            Console.WriteLine("Enter the upper right coordinates");
            string upperrighcoords = Console.ReadLine();
            Coordinates upperRight = new Coordinates();
            string[] splitCoors = upperrighcoords.Split(' ');
            if (splitCoors.Length != 2)
            {
                Console.WriteLine("Invalid input");
                return;
            }
            upperRight.x = Convert.ToInt32(splitCoors[0]);
            upperRight.y = Convert.ToInt32(splitCoors[1]);

            // // test code
            // Position initPos = new Position();
            //  initPos.coords = new Coordinates();
            //  initPos.coords.x = 3;
            //  initPos.coords.y = 3;
            //  initPos.pos = Rover.Directions.East;
            //  Rover.Instructions inst;
            //  Position retPos;
            //  char[] charPos = { 'M', 'M', 'R', 'M', 'M', 'R', 'M', 'R', 'R', 'M' };
            //     retPos = initPos;
            //     for(int j=0;j<charPos.Length;j++) {
            //         switch(charPos[j]) {
            //             case 'L':
            //               inst = Rover.Instructions.SpinLeft;
            //               break;
            //             case 'R' :
            //               inst = Rover.Instructions.SpinRight;
            //               break;
            //             case 'M' :
            //               inst = Rover.Instructions.MoveForward;
            //               break;
            //             default : 
            //               throw new Exception();
            //         }
            //         retPos = businessInstance.MoveRover(retPos, upperRight, inst);
            //         Console.WriteLine(retPos.coords.x.ToString() + ' ' + retPos.coords.y.ToString() + ' ' + retPos.pos.ToString());
            //     }
                

            //injection by property
            for (int i = 0; i < 2; i++)
            {
                Console.WriteLine("Enter the initial position of the rover :");
                string initPosString = Console.ReadLine();
                string[] initPosArray = initPosString.Split(' ');
                if (initPosArray.Length != 3)
                {
                    Console.WriteLine("Invalid input");
                    break;
                }
                Position initPos = new Position();
                initPos.coords = new Coordinates();
                initPos.coords.x = Convert.ToInt32(initPosArray[0]);
                initPos.coords.y = Convert.ToInt32(initPosArray[1]);
                switch (initPosArray[2])
                {
                    case "N":
                        initPos.pos = Rover.Directions.North;
                        break;
                    case "S":
                        initPos.pos = Rover.Directions.South;
                        break;
                    case "W":
                        initPos.pos = Rover.Directions.West;
                        break;
                    case "E":
                        initPos.pos = Rover.Directions.East;
                        break;
                }
                Console.WriteLine("Enter the sequence of operations :");
                string operString = Console.ReadLine();
                Position retPos = null;
                Rover.Instructions inst;
                char[] operArray = operString.ToCharArray();
                retPos = initPos;
                for(int j=0;j<operArray.Length;j++) {
                    switch(operArray[j]) {
                        case 'L':
                          inst = Rover.Instructions.SpinLeft;
                          break;
                        case 'R' :
                          inst = Rover.Instructions.SpinRight;
                          break;
                        case 'M' :
                          inst = Rover.Instructions.MoveForward;
                          break;
                        default : 
                          inst = Rover.Instructions.SpinRight;
                          break;
                    }
                    retPos = businessInstance.MoveRover(retPos, upperRight, inst);
                }
                // finally we get the result position
                output[i] =  retPos.coords.x.ToString() + ' ' + retPos.coords.y.ToString() + ' ' + retPos.pos.ToString();
            }

            Console.WriteLine("Output");
            for(int i= 0; i< output.Length; i++) {
                Console.WriteLine(output[i]);
            }

        }
    }
}
