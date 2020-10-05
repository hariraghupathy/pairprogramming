using MarsRover.Model;
namespace MarsRover.Service {
    public interface IRoverService {
         Position MoveInDirection(Position pos,  Rover.Directions dir);
         Position SpinLeft(Position pos);
         Position SpinRight(Position pos);

    }
}