using System;
using OpenTK;
using OpenTK.Graphics.OpenGL;
using System.Drawing;


namespace GCG
{
  class Game : GameWindow
  {
    private Point4D ptoEsqBai = new Point4D(-100, -100);
    private Point4D ptoDirBai = new Point4D(100, -100);
    private Point4D ptoDirCim = new Point4D(100, 100);
    private Point4D ptoEsqCim = new Point4D(-100, 100);
    Color corFundo = Color.White;


    public Game(int width, int height) : base(width, height) { }

    protected override void OnLoad(EventArgs e)
    {
      base.OnLoad(e);
    }

    protected override void OnUpdateFrame(FrameEventArgs e)
    {
      base.OnUpdateFrame(e);
      GL.MatrixMode(MatrixMode.Projection);
      GL.LoadIdentity();
      GL.Ortho(-400,400,400,-400,-1,1);
    }

    protected override void OnRenderFrame(FrameEventArgs e)
    {
      base.OnRenderFrame(e);
      GL.Clear(ClearBufferMask.ColorBufferBit);
      GL.ClearColor(corFundo);
      GL.MatrixMode(MatrixMode.Modelview);

      SRU3D();
      Desenha();

      this.SwapBuffers();
    }

    private void Desenha() {
      GL.LineWidth(5);
      GL.PointSize(10);
      GL.Color3(Color.Black);

      GL.Begin(PrimitiveType.Points);
        GL.Vertex2(ptoEsqBai.X,ptoEsqBai.Y);
        GL.Vertex2(ptoDirBai.X,ptoDirBai.Y);
        GL.Vertex2(ptoDirCim.X,ptoDirCim.Y);
        GL.Vertex2(ptoEsqCim.X,ptoEsqCim.Y);
      GL.End();
    }

    private void SRU3D() {
        GL.LineWidth(1);
        GL.Begin(PrimitiveType.Lines);
          GL.Color3(Color.Red);
          GL.Vertex3(0,0,0); GL.Vertex3(200,0,0);
          GL.Color3(Color.Green);
          GL.Vertex3(0,0,0); GL.Vertex3(0,200,0);
          GL.Color3(Color.Blue);
          GL.Vertex3(0,0,0); GL.Vertex3(0,0,200);
        GL.End();
    }
  }
}