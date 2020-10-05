using MarsRover.Model;
using MarsRover.Service;
namespace MarsRover.BusinessLogic
{
    public interface IRoverLogic
    {
        IRoverService roverService { get; set; }
        Position MoveRover(Position current, Coordinates upperright, Rover.Instructions inst);
        bool CheckIfRoverOutOfPlateau(Position current, Coordinates upperright);
    }
}