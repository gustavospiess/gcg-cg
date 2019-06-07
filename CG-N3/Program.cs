/*
  Autor: Dalton Solano dos Reis
*/

using System;
using OpenTK;
using OpenTK.Graphics.OpenGL;
using System.Drawing;
using OpenTK.Input;

namespace gcgcg
{
  class Render : GameWindow
  {
    Mundo mundo = Mundo.getInstance();
    //* Usando os valores padrão da câmera para não ter problemas com o NDC */
    CG_Biblioteca.Camera camera = new CG_Biblioteca.Camera();
    bool mouse = false;
    public Render(int width, int height) : base(width, height) { }

    protected override void OnLoad(EventArgs e)
    {
      base.OnLoad(e);
      
      GL.ClearColor(Color.Gray);
    }
    protected override void OnUpdateFrame(FrameEventArgs e)
    {
      base.OnUpdateFrame(e);

      GL.MatrixMode(MatrixMode.Projection);
      GL.LoadIdentity();
      GL.Ortho(camera.xmin, camera.xmax, camera.ymin, camera.ymax, camera.zmin, camera.zmax);
    }
    protected override void OnRenderFrame(FrameEventArgs e)
    {
      base.OnRenderFrame(e);

      GL.Clear(ClearBufferMask.ColorBufferBit);
      GL.MatrixMode(MatrixMode.Modelview);
      GL.LoadIdentity();

      mundo.Desenha();

      this.SwapBuffers();
    }

    protected override void OnKeyDown(OpenTK.Input.KeyboardKeyEventArgs e)
    {
      if (e.Key == Key.Escape)
        mouse = !mouse;

      mundo.OnKeyDown(e);
    }

    protected override void OnMouseMove(MouseMoveEventArgs e)
    {
      if (mouse)
      {
        mundo.MouseMove(e.Position.X, e.Position.Y);
      }
    }
  }

  class Program
  {
    static void Main(string[] args)
    {
      //* Usando os valores padrão da câmera para não ter problemas com o NDC */
      Render window = new Render(600, 600);
      window.Run();
      window.Run(1.0 / 60.0);
    }
  }

}
