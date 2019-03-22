namespace gcgcg
{
  internal class Ponto4D
  {
    private double x;
    private double y;
    private double z;
    private double w;
    public Ponto4D(double x = 0.0, double y = 0.0, double z = 0.0)
    {
      this.x = x;
      this.y = y;
      this.z = z;
      this.w = 1;
    }

    // Operator overloaded
    public static Ponto4D operator +(Ponto4D pto1, Ponto4D pto2) => new Ponto4D(pto1.X + pto2.X, pto1.Y + pto2.Y, pto1.Z + pto2.Z);

    public static Ponto4D operator --(Ponto4D pto) => new Ponto4D(-pto.X, -pto.Y, -pto.Z);

    //TODO: Testar estas funções e ver se precisam existir
    // public static bool operator ==(Ponto4D pto1, Ponto4D pto2) {
    //   return ((pto1.X == pto2.X) && (pto1.Y == pto2.Y) && (pto1.Z == pto2.Z));
    // }
    // public static bool operator !=(Ponto4D pto1, Ponto4D pto2) {
    //   return ((pto1.X != pto2.X) && (pto1.Y != pto2.Y) && (pto1.Z != pto2.Z));
    // }
    public double X { get => x; set => x = value; }
    public double Y { get => y; set => y = value; }
    public double Z { get => z; set => z = value; }

  }
}