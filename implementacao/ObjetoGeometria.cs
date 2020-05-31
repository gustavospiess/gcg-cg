/**
  Autor: Dalton Solano dos Reis
**/

using OpenTK.Graphics.OpenGL;
using CG_Biblioteca;
using System.Collections.Generic;
using System;
using OpenTK;

namespace gcgcg
{
  internal class ObjetoGeometria : Objeto
  {

    public ListaPontos pontos;

    public ObjetoGeometria(string rotulo) : base(rotulo)
    {
      pontos = new ListaPontos();
    }


    public override void Desenhar()
    {
      GL.Color3(this.Cor);
      GL.LineWidth(4);
      GL.PointSize(4);
      GL.Begin(PrimitiveType.LineLoop);
      
      List<Ponto4D> ptos = this.pontos.pontos(this.Transformacao);

      foreach (Ponto4D pto in ptos)
      {
        GL.Vertex2(pto.X, pto.Y);
      }
      GL.End();

      Ponto4D ptoSel = this.pontos.pontoSel(this.Transformacao);
      if (ptoSel != null && this.Selecionado)
      {
        GL.Color3(Color.Purple);
        GL.LineWidth(10);
        GL.PointSize(10);
        GL.Begin(PrimitiveType.Points);
        GL.Vertex2(ptoSel.X, ptoSel.Y);
        GL.Vertex2(ptoSel.X, ptoSel.Y);
        GL.End();
      }
    }

    public override BBox bbox()
    {
      double maxX = this.pontos.maxX(this.Transformacao);
      double minX = this.pontos.minX(this.Transformacao);
      double maxY = this.pontos.maxY(this.Transformacao);
      double minY = this.pontos.minY(this.Transformacao);
      return new BBox(minX, minY, 0, maxX, maxY, 0);
    }

  }
}
