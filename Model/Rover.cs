namespace MarsRover.Model
{

    public class Rover
    {

        public Coordinates upperright;
        public Position startPos;

        public string operations;

        public string Opeartions
        {
            get
            {
                return operations;
            }
            set
            {
                // here do if any validation is required
                // opeartions should be one of the enum values
                operations = value;
            }

        }
        public enum Instructions
        {
            SpinLeft = 'L',
            SpinRight = 'R',
            MoveForward = 'M'
        }

        public enum Directions
        {
            North = 'N',
            South = 'S',
            West = 'W',
            East = 'E'
        }
    }
}