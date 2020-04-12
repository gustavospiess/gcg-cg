/**
  Autor: Gustavo Spiess
**/

using OpenTK.Graphics.OpenGL;
using CG_Biblioteca;

namespace gcgcg
{
  internal class ObjetoGeometriaListPontos: ObjetoGeometria
  {

    public ObjetoGeometriaListPontos(string rotulo, Objeto paiRef) : base(rotulo, paiRef)
    {}

    protected override void DesenharObjeto()
    {
      GL.Color3(this.Cor);
      GL.LineWidth(this.PrimitivaTamanho);
      GL.PointSize(this.PrimitivaTamanho);
      GL.Begin(this.PrimitivaTipo);
      foreach (Ponto4D pto in pontosLista)
      {
        GL.Vertex2(pto.X, pto.Y);
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

  }
}
