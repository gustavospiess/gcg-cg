using System;

namespace GCG
{
  class Program
  {
    static void Main(string[] args)
    {
      Game window = new Game(800, 800);
      window.Run();



      Point4D pto1 = new Point4D(10, 20, 30);
      Console.WriteLine("PTO1 ... x: " + pto1.X + " - y: " + pto1.Y + " - z: " + pto1.Z);

      Point4D pto2 = new Point4D(10, 20, 30);
      Console.WriteLine("PTO2 ... x: " + pto2.X + " - y: " + pto2.Y + " - z: " + pto2.Z);

      if (pto1 == pto2)
        Console.WriteLine("true");
      else
        Console.WriteLine("false");

      pto2 += pto1;
      Console.WriteLine("PTO ... x: " + pto2.X + " - y: " + pto2.Y + " - z: " + pto2.Z);

      var pto = new Point4D(1, -2, 3);
      pto--;
      Console.WriteLine("PTO Negativo ... x: " + pto.X + " - y: " + pto.Y + " - z: " + pto.Z);


    }
  }
}
