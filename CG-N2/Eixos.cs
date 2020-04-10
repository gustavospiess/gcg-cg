/**
  Autor: Gustavo Spiess
**/

using OpenTK.Graphics.OpenGL;
using CG_Biblioteca;

namespace gcgcg
{
  internal class Eixos : ObjetoGeometria
  {
    public Eixos(string rotulo, Objeto paiRef) : base(rotulo, paiRef)
    {
    }
    protected override void DesenharObjeto()
    {

      GL.Begin(PrimitiveType.Lines);
        GL.Color3(255,0,0);
        GL.Vertex2(0, 0);
        GL.Vertex2(0, 250);
      GL.End();

      GL.Begin(PrimitiveType.Lines);
        GL.Color3(0,255,0);
        GL.Vertex2(0, 0);
        GL.Vertex2(250, 0);
      GL.End();

    }
    //TODO: melhorar para exibir não só a lsita de pontos (geometria), mas também a topologia ... poderia ser listado estilo OBJ da Wavefrom
    public override string ToString()
    {
      string retorno;
      retorno = "__ Objeto Eixos: " + base.rotulo + "\n";
      return (retorno);
    }

  }
}
