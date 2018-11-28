using System;

namespace CG {
  internal class Point4D {
    double x;
    double y;
    double z;
    double w;
    public Point4D(double x=0.0, double y=0.0, double z=0.0) {
      this.x = x;
      this.y = y;
      this.z = z;
      this.w = 1;
      Console.WriteLine(" .. w: "+this.w);      
    }


    // Operator overloaded
    public static Point4D operator +(Point4D pto1, Point4D pto2) => new Point4D(pto1.X + pto2.X, pto1.Y + pto2.Y, pto1.Z + pto2.Z);

    public static Point4D operator --(Point4D pto) => new Point4D(-pto.X, -pto.Y, -pto.Z);

    public static bool operator ==(Point4D pto1, Point4D pto2) {
      return ((pto1.X == pto2.X) && (pto1.Y == pto2.Y) && (pto1.Z == pto2.Z));
    }
    public static bool operator !=(Point4D pto1, Point4D pto2) {
      return ((pto1.X != pto2.X) && (pto1.Y != pto2.Y) && (pto1.Z != pto2.Z));
    }


    public double X { get => x; set => x = value; }
    public double Y { get => y; set => y = value; }
    public double Z { get => z; set => z = value; }

  }
}