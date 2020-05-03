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
  internal class ObjetoCor: ObjetoGeometriaListPontos
  {

    public ObjetoCor(string rotulo, Objeto paiRef) : base(rotulo, paiRef)
    {}

    protected List<Color> listaCor = new List<Color>();

    protected override void DesenharObjeto()
    {
      GL.LineWidth(this.PrimitivaLargura);
      GL.PointSize(this.PrimitivaLargura);
      GL.Begin(this.PrimitivaTipo);

      for (int i = 0; i < this.pontosLista.Count; i++)
      {
        Ponto4D pto = this.pontosLista[i];
        Color cor = this.listaCor[i];

        GL.Color3(cor);
        double cos = Math.Cos(Math.PI * Angulo / -180.0);
        double sin = Math.Sin(Math.PI * Angulo / -180.0);
        
        Ponto4D ptoTam = new Ponto4D(pto.X*this.PrimitivaTamanho, pto.Y*this.PrimitivaTamanho);
        Ponto4D ptoRot = new Ponto4D(ptoTam.X*cos + ptoTam.Y*sin, -1 * sin * ptoTam.X + ptoTam.Y * cos);
        Ponto4D ptoMov = ptoRot + this.Posicao;

        GL.Vertex2(ptoMov.X, ptoMov.Y);
      }
      GL.End();
    }

    public new void PontosAdicionar(Ponto4D pto)
    {
      this.listaCor.Add(this.Cor);
      base.PontosAdicionar(pto);
    }

    public void PontosAdicionar(Ponto4D pto, Color cor)
    {
      this.listaCor.Add(cor);
      base.PontosAdicionar(pto);
    }

  }
}
