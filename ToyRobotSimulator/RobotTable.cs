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

		public RobotTable(Size size)
		{
			if (size == null || size.Width <= 0 || size.Height <= 0)
				throw new ArgumentOutOfRangeException("Invalid table size");

			_size = size;
		}

		#endregion

		#region Methods

		public bool IsTableValid()
        {
            return _size != null;
        }

        public bool IsTablePositionExist(Point position)
        {
            return IsTablePositionExist(position.X, position.Y);
        }

        public bool IsTablePositionExist(int x, int y)
        {
            return (x <= Size.Width && x >= 0) && (y <= Size.Height && y >= 0);
        }
        #endregion
    }
}
