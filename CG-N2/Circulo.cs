/**
  Autor: Gustavo Spiess
**/

using OpenTK.Graphics.OpenGL;
using CG_Biblioteca;

namespace gcgcg
{
  internal class Circulo : ObjetoGeometria
  {
    public Circulo(string rotulo, Objeto paiRef, Ponto4D ptoOrig, double raio) : base(rotulo, paiRef)
    {

      for (int i = 0; i < 72; i++) 
      {
        base.PontosAdicionar(Matematica.GerarPtosCirculo(i*360/72, raio) + ptoOrig);
      }
    }

    protected override void DesenharObjeto()
    {
      GL.Color3(255,255,255);
      GL.Begin(base.PrimitivaTipo);
      foreach (Ponto4D pto in pontosLista)
      {
        GL.Vertex2(pto.X, pto.Y);
      }
      GL.End();
    }
    public override string ToString()
    {
      string retorno;
      retorno = "__ Objeto Circulo: " + base.rotulo + "\n";
      for (var i = 0; i < pontosLista.Count; i++)
      {
        retorno += "P" + i + "[" + pontosLista[i].X + "," + pontosLista[i].Y + "," + pontosLista[i].Z + "," + pontosLista[i].W + "]" + "\n";
      }
      return (retorno);
    }

  }
}
