/**
  Autor: Gustavo Spiess
**/

using OpenTK.Graphics.OpenGL;
using CG_Biblioteca;

namespace gcgcg
{
  internal class SegReta : ObjetoGeometria
  {
    public SegReta(string rotulo, Objeto paiRef, Ponto4D ptoOrig, Ponto4D ptoDest) : base(rotulo, paiRef)
    {
      base.PontosAdicionar(ptoOrig);
      base.PontosAdicionar(ptoDest);
    }

    protected override void DesenharObjeto()
    {
      GL.Color3(255,255,255);
      GL.Begin(PrimitiveType.Lines);
      foreach (Ponto4D pto in pontosLista)
      {
        GL.Vertex2(pto.X, pto.Y);
      }
      GL.End();
    }
    //TODO: melhorar para exibir não só a lsita de pontos (geometria), mas também a topologia ... poderia ser listado estilo OBJ da Wavefrom
    public override string ToString()
    {
      string retorno;
      retorno = "__ Objeto SegReta: " + base.rotulo + "\n";
      for (var i = 0; i < pontosLista.Count; i++)
      {
        retorno += "P" + i + "[" + pontosLista[i].X + "," + pontosLista[i].Y + "," + pontosLista[i].Z + "," + pontosLista[i].W + "]" + "\n";
      }
      return (retorno);
    }

  }
}
