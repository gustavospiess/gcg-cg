/**
  Autor: Dalton Solano dos Reis
**/

using OpenTK.Graphics.OpenGL;
using System.Drawing;
using CG_Biblioteca;

// ATENÇÃO: remover: "Privado_"
namespace gcgcg
{
  internal class Poligono : ObjetoGeometria
  {
    public Poligono(string rotulo, Objeto paiRef) : base(rotulo, paiRef)
    {
    }

    protected override void DesenharObjeto()
    {
      GL.Color3(Color.White);
      GL.Begin(base.PrimitivaTipo);
      foreach (Ponto4D pto in pontosLista)
      {
        GL.Vertex2(pto.X, pto.Y);
      }
      GL.End();
    }

  }
}