
/**
  Autor: Gustavo Spiess
**/

using System.Collections.Generic;
using System;
using OpenTK;
using OpenTK.Graphics.OpenGL;
using CG_Biblioteca;

namespace gcgcg
{
  internal class ObjetoSpline: ObjetoGeometriaListPontos
  {

    public ObjetoSpline(string rotulo, Objeto paiRef) : base(rotulo, paiRef)
    {}

    public int qtLinhas = 25;
    public int pontoSel = -1;

    public void move(Ponto4D sum)
    {
      if (this.pontoSel > -1)
      {
        this.pontosLista[this.pontoSel] += sum;
      }
    }

    protected override void DesenharObjeto()
    {


      GL.LineWidth(2);
      GL.PointSize(2);
      GL.Color3(Color.LightBlue);
      GL.Begin(PrimitiveType.LineStrip);

      for (int i = 0; i < this.pontosLista.Count; i++)
      {
        Ponto4D pto = this.pontosLista[i];
        GL.Vertex2(pto.X, pto.Y);
      }
      GL.End();

      GL.LineWidth(this.PrimitivaLargura*2);
      GL.PointSize(this.PrimitivaLargura*2);
      GL.Begin(PrimitiveType.Points);
      for (int i = 0; i < this.pontosLista.Count; i++)
      {
        Ponto4D pto = this.pontosLista[i];

        if (i == this.pontoSel)
        {
          GL.Color3(Color.Red);
        }
        else
        {
          GL.Color3(Color.Black);
        }
        GL.Vertex2(pto.X, pto.Y);
      }
      GL.End();


      GL.LineWidth(2);
      GL.PointSize(2);
      GL.Color3(Color.LightYellow);
      GL.Begin(PrimitiveType.LineStrip);

      Ponto4D before = this.pontosLista[0];
      GL.Vertex2(this.pontosLista[0].X, this.pontosLista[0].Y);
      for (double j = 0; j < this.qtLinhas; j++)
      {
        Ponto4D[] ptos = this.pontosLista.ToArray();
        while (ptos.Length > 1)
        {
          List<Ponto4D> ptos_novos = new List<Ponto4D>();
          for (int i = 1; i < ptos.Length; i++)
          {
            Ponto4D a = ptos[i-1];
            Ponto4D b = ptos[i];
            double x = this.interpolate(a.X, b.X, j/this.qtLinhas);
            double y = this.interpolate(a.Y, b.Y, j/this.qtLinhas);
            ptos_novos.Add(new Ponto4D(x, y));
          }
          ptos = ptos_novos.ToArray();
        }
        GL.Vertex2(ptos[0].X, ptos[0].Y);
        // Console.WriteLine(ptos[0].X + ","+ptos[0].Y);
      }
      GL.Vertex2(this.pontosLista[pontosLista.Count-1].X, this.pontosLista[pontosLista.Count-1].Y);

      GL.End();
    }

    private double interpolate(double a, double b, double t)
    {
      return a+(b-a)*t;
    }

  }
}
