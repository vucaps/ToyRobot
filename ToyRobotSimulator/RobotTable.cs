using System;
using System.Drawing;

namespace ToyRobotSimulator
{
    public class RobotTable
    {
        #region Members
        Size _size;
        #endregion

        #region Properties
        public Size Size { get => _size; }
        #endregion

        #region Constractors
        //
        // Summary:
        //     Initializes a new instance of the Table from the specified
        //     dimensions.
        //
        // Parameters:
        //   width:
        //     The width component of the new Table.
        //
        //   height:
        //     The height component of the new Table.
        public RobotTable()
        {
            _size = new Size(5, 5);
        }
        public RobotTable(int width, int height)
        {
            if (width <= 0 || height <= 0)
                throw new ArgumentOutOfRangeException("Invalid table size");

            _size = new Size(width, height);
        }
		//
		// Summary:
		//     Initializes a new instance of the Table from the specified
		//     System.Drawing.Point structure.
		//
		// Parameters:
		//   point:
		//     The System.Drawing.Point structure from which to initialize this Table.
		public RobotTable(Point point)
		{
			if (point == null || point.X <= 0 || point.Y <= 0)
				throw new ArgumentOutOfRangeException("Invalid table size");

			_size = new Size(point.X, point.Y);
		}

		public RobotTable(Size size)
		{
			if (size == null || size.Width <= 0 || size.Height <= 0)
				throw new ArgumentOutOfRangeException("Invalid table size");

			_size = size;
		}

		#endregion

		#region Methods

		public bool IsValidTable()
        {
            return _size != null;
        }

        public bool IsPositionExist(Point position)
        {
            return IsPositionExist(position.X, position.Y);
        }

        public bool IsPositionExist(int X, int Y)
        {
            return (X <= Size.Width && X >= 0) && (Y <= Size.Height && Y >= 0);
        }
        #endregion
    }
}
