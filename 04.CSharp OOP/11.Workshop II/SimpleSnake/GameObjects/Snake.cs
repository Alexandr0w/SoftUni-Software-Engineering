using System.Collections.Generic;

namespace SimpleSnake.GameObjects
{
    public class Snake
    {
        private readonly Queue<Point> _body = new Queue<Point>();

        public Snake(Point initialHead, Point direction)
        {
            this.SetHead(initialHead);
            this.Direction = direction;
        }

        public Point Head { get; private set; }
        public Point Direction { get; set; }

        public void Grow()
        {
            Point newHead = new Point(this.Head.X + this.Direction.X, this.Head.Y + this.Direction.Y);

            this.SetHead(newHead);
        }

        public void Shorten()
        {

        }

        private void SetHead(Point headPosition)
        {
            this.Head = headPosition;
            this._body.Enqueue(headPosition);
        }
    }
}
