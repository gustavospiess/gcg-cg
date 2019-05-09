using System;
using OpenTK.Graphics.OpenGL;
using System.Drawing;

namespace gcgcg
{
  class Mundo
  {
    private Objeto objeto = new Objeto();
    public Mundo()
    {
    }

    public void Desenha()
    {
      // Console.WriteLine("[6] .. Desenha");

      SRU3D();

      objeto.Desenha();
    }
    //FIXME: não está considerando o NDC
    public void MouseMove(int x, int y)
    {
      //* Invertendo a coordenada y do espaço de tela para o espaço do mundo */
      objeto.Move(x, 600-y);
    }
    private void SRU3D()
    {
      // Console.WriteLine("[5] .. SRU3D");

      GL.LineWidth(1);
      GL.Begin(PrimitiveType.Lines);
      GL.Color3(Color.Red);
      GL.Vertex3(0, 0, 0); GL.Vertex3(200, 0, 0);
      GL.Color3(Color.Green);
      GL.Vertex3(0, 0, 0); GL.Vertex3(0, 200, 0);
      GL.Color3(Color.Blue);
      GL.Vertex3(0, 0, 0); GL.Vertex3(0, 0, 200);
      GL.End();
    }
  }

}