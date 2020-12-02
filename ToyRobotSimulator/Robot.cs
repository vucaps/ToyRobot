using System;
using System.Drawing;


namespace ToyRobotSimulator
{
    public class Robot 
	{
        #region Members

        private Guid? _id;
        private Point _position;
        private int _currentAngle;
        private Direction _direction;
        private const int TOTAL_ANGLES = 360;
        #endregion

        #region Constractors
        public Robot()
        {
			_id = new Guid();
			_position = new Point(0, 0);
            _currentAngle = 0;
            _direction = Direction.South;
        }
        public Robot(Point point, Direction direction)
        {
			_id = new Guid();
			_position = point;
            _currentAngle = (int)direction;
            _direction = direction;
        }

		#endregion

		#region Properties

		public string ID { get => _id?.ToString();  }
		public Point Position { get => _position; }
		public Direction Direction { get => _direction; }

		#endregion

		#region Methods
		       
        public void RotateLeft()
        {
            Rotate(MoveTo.Left);
        }

        public void RotateRight()
        {
            Rotate(MoveTo.Right);
        }

        private void Rotate(MoveTo moveTo)
        {
            _direction = (Direction)(((int)_direction + (int)moveTo) % TOTAL_ANGLES);

            if (_direction < 0)
                _direction = (Direction)((int)_direction + TOTAL_ANGLES);

            _currentAngle = (int)_direction;
        }
	               
		public void Move()
		{
			if (_position == null)
				throw new ArgumentOutOfRangeException("Invalid existing position");
			
			switch (_direction)
			{
				case Direction.North:
					_position.Y += 1;
					break;
				case Direction.East:
					_position.X += 1;
					break;
				case Direction.South:
					_position.Y -= 1;
					break;
				case Direction.West:
					_position.X -= 1;
					break;
			}			
		}

		public void Hop(Point position)
		{
			if (_position == null)
				throw new ArgumentOutOfRangeException("Invalid existing position");

			_position = position;
		}

		public void Hop(Point position, Direction direction)
		{
			if (position == null || position.X < 0 || position.Y < 0)
				throw new ArgumentOutOfRangeException("Invalid table size");

			_direction = direction;
			_position = position;
		}

		public Point GetNextPosition()
		{
			if (_position == null)
				throw new ArgumentOutOfRangeException("Invalid existing position");

			Point newPosition = new Point(_position.X, _position.Y);
			switch (_direction)
			{
				case Direction.North:
					newPosition.Y = newPosition.Y + 1;
					break;
				case Direction.East:
					newPosition.X = newPosition.X + 1;
					break;
				case Direction.South:
					newPosition.Y = newPosition.Y - 1;
					break;
				case Direction.West:
					newPosition.X = newPosition.X - 1;
					break;
			}
			return newPosition;
		}

		#endregion

	}
}
