using System;
using CG_Biblioteca;

namespace gcgcg
{
  internal class Circulo : ObjetoAramado
  {
    private Ponto4D ptoCentro;
    private double raio;

    public Circulo(string rotulo, Ponto4D ptoCentro, double raio) : base(rotulo)
    {
      this.ptoCentro = ptoCentro;
      this.raio = raio;
      base.TransladarXY(ptoCentro.X,ptoCentro.Y);
      geraPtosCirculo();
    }

    private void geraPtosCirculo()
    {
      Matematica mat = new Matematica();
      for (int angulo = 0; angulo < 360; angulo += 10)
      {
        base.PontosAdicionar(mat.ptoCirculo(angulo, raio));
      }
    }
  }
}