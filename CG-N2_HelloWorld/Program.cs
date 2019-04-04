using System;
using OpenTK;
using OpenTK.Graphics.OpenGL;
using System.Drawing;

namespace gcgcg
{
  class Render : GameWindow
  {
    Mundo mundo = new Mundo();
    public Render(int width, int height) : base(width, height) { }

    protected override void OnLoad(EventArgs e)
    {
      base.OnLoad(e);
Console.WriteLine("[2] .. OnLoad");
    }
    protected override void OnUpdateFrame(FrameEventArgs e)
    {
      base.OnUpdateFrame(e);
Console.WriteLine("[3] .. OnUpdateFrame");

      GL.MatrixMode(MatrixMode.Projection);
      GL.LoadIdentity();
      GL.Ortho(-400, 400, -400, 400, -1, 1);
    }
    protected override void OnRenderFrame(FrameEventArgs e)
    {
      base.OnRenderFrame(e);
Console.WriteLine("[4] .. OnRenderFrame");
      
      GL.Clear(ClearBufferMask.ColorBufferBit);
      GL.ClearColor(Color.White);
      GL.MatrixMode(MatrixMode.Modelview);

      mundo.SRU3D();
      mundo.Desenha();

      this.SwapBuffers();
    }
  }

  class Program
  {
    static void Main(string[] args)
    {
Console.WriteLine("[1] .. Main");

      Render window = new Render(800, 800);
      window.Run();
        window.Run(1.0/60.0);
    }
  }

}
