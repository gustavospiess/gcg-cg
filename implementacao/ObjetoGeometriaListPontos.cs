/**
  Autor: Gustavo Spiess
**/

using OpenTK.Graphics.OpenGL;
using CG_Biblioteca;
using System.Collections.Generic;
using System;

namespace gcgcg
{
  internal class ObjetoGeometriaListPontos: ObjetoGeometria
  {

    protected List<Ponto4D> pontosLista = new List<Ponto4D>();

    public ObjetoGeometriaListPontos(string rotulo, Objeto paiRef) : base(rotulo, paiRef)
    {}

    protected override void DesenharObjeto()
    {
      GL.Color3(this.Cor);
      GL.LineWidth(this.PrimitivaLargura);
      GL.PointSize(this.PrimitivaLargura);
      GL.Begin(this.PrimitivaTipo);
      foreach (Ponto4D pto in pontosLista)
      {
        double cos = Math.Cos(Math.PI * Angulo / -180.0);
        double sin = Math.Sin(Math.PI * Angulo / -180.0);
        
        Ponto4D ptoTam = new Ponto4D(pto.X*this.PrimitivaTamanho, pto.Y*this.PrimitivaTamanho);
        Ponto4D ptoRot = new Ponto4D(ptoTam.X*cos + ptoTam.Y*sin, -1 * sin * ptoTam.X + ptoTam.Y * cos);
        Ponto4D ptoMov = ptoRot + this.Posicao;

        GL.Vertex2(ptoMov.X, ptoMov.Y);
      }
      GL.End();
    }

    public override string ToString()
    {
      string retorno;
      retorno = "__ Objeto " + this.GetType().Name + ": " + base.rotulo + "\n";
      for (var i = 0; i < pontosLista.Count; i++)
      {
        retorno += "P" + i + "[" + pontosLista[i].X + "," + pontosLista[i].Y + "," + pontosLista[i].Z + "," + pontosLista[i].W + "]" + "\n";
      }
      return (retorno);
    }

    public void PontosAdicionar(Ponto4D pto)
    {
      pontosLista.Add(pto);
      if (pontosLista.Count.Equals(1))
        base.BBox.Atribuir(pto);
      else
        base.BBox.Atualizar(pto);
      base.BBox.ProcessarCentro();
    }

    public override Ponto4D PontosUltimo()
    {
      return pontosLista[pontosLista.Count - 1];
    }
  }
}
