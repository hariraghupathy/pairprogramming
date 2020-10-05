using System;
using MarsRover.Model;
using MarsRover.Service;
namespace MarsRover.BusinessLogic
{
    public class RoverLogic : IRoverLogic
    {
        public IRoverService roverService { get; set; }

        public Position MoveRover(Position current, Coordinates upperright, Rover.Instructions inst)
        {
            try
            {
                Position retPos = null;
                switch (inst)
                {
                    case Rover.Instructions.MoveForward:
                        retPos = this.roverService.MoveInDirection(current, current.pos);
                        // if (this.CheckIfRoverOutOfPlateau(retPos, upperright))
                        //     throw new Exception("Plateau out of bounds");
                        break;
                    case Rover.Instructions.SpinLeft:
                        retPos = this.roverService.SpinLeft(current);
                        break;
                    case Rover.Instructions.SpinRight:
                        retPos = this.roverService.SpinRight(current);
                        break;
                    default:
                        break;
                }
                return retPos;
            }
            catch (Exception e)
            {
                // handle excpetion if the rover moves out of the plateau
                // later use a separate class for exception handling
                throw e;
            }
        }


        public bool CheckIfRoverOutOfPlateau(Position current, Coordinates upperright)
        {
            if (current.coords.x < 0 || current.coords.x > upperright.x || current.coords.y < 0 || current.coords.y > upperright.y)
                return false;
            else
                return true;
        }
    }
}