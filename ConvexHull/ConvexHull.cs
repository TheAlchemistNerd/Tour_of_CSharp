using System;
using System.Collections.generic;

namespace ConvexHull {
    class Point : Icomparable<Point> {
        private x, y;

        public Point(int x, int y) {
            this.x = x
            this.y = y
        }

        public int X {get => X; set => x = value;}
        public int X {get => X; set => x = value;}

        public int CompareTo(Point other) {
            return x.CompareTo(other.x);
        }

        public override string ToString() {
            return string.Format("({0}, {1})", x, y)
        }
    }
}