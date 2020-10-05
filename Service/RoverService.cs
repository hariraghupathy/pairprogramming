using MarsRover.Model;
namespace MarsRover.Service
{
    public class RoverService : IRoverService
    {

        public Position MoveInDirection(Position pos, Rover.Directions dir)
        {
            Position retPos = new Position();
            retPos.coords = new Coordinates();
            switch (dir)
            {
                case Rover.Directions.North:
                    retPos.coords.x = pos.coords.x;
                    retPos.coords.y = pos.coords.y + 1;
                    retPos.pos = pos.pos;
                    break;
                case Rover.Directions.South:
                    retPos.coords.x = pos.coords.x;
                    retPos.coords.y = pos.coords.y - 1;
                    retPos.pos = pos.pos;
                    break;
                case Rover.Directions.West:
                    retPos.coords.x = pos.coords.x - 1;
                    retPos.coords.y = pos.coords.y;
                    retPos.pos = pos.pos;
                    break;
                case Rover.Directions.East:
                    retPos.coords.x = pos.coords.x + 1;
                    retPos.coords.y = pos.coords.y;
                    retPos.pos = pos.pos;
                    break;
                default:
                    break;
            }
            return retPos;
        }

        public Position SpinLeft(Position pos)
        {
             Position retPos = new Position();
             retPos.coords = new Coordinates();
             retPos.coords.x = pos.coords.x;
             retPos.coords.y = pos.coords.y;
            switch (pos.pos)
            {
                case Rover.Directions.North:
                    retPos.pos = Rover.Directions.West;
                    break;
                case Rover.Directions.South:
                    retPos.pos = Rover.Directions.East;
                    break;
                case Rover.Directions.West:
                    retPos.pos = Rover.Directions.South;
                    break;
                case Rover.Directions.East:
                    retPos.pos = Rover.Directions.North;
                    break;
                default:
                    break;
            }
            return retPos;
        }
        public Position SpinRight(Position pos)
        {
             Position retPos = new Position();
             retPos.coords = new Coordinates();
             retPos.coords.x = pos.coords.x;
             retPos.coords.y = pos.coords.y;
            switch (pos.pos)
            {
                case Rover.Directions.North:
                    retPos.pos = Rover.Directions.East;
                    break;
                case Rover.Directions.South:
                    retPos.pos = Rover.Directions.West;
                    break;
                case Rover.Directions.West:
                    retPos.pos = Rover.Directions.North;
                    break;
                case Rover.Directions.East:
                    retPos.pos = Rover.Directions.South;
                    break;
                default:
                    break;
            }
            return retPos;
        }

    }
}