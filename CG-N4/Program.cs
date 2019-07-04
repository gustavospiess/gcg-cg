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
    CG_Biblioteca.Camera camera = new CG_Biblioteca.Camera();
    //FIXME: levar atributos da câmera para classe Camera.
    Vector3 eye = Vector3.Zero, target = Vector3.Zero, up = Vector3.UnitY;

    public Render(int width, int height) : base(width, height) { }

    protected override void OnLoad(EventArgs e)
    {
      base.OnLoad(e);

      GL.ClearColor(Color.Gray);                        // Aqui é melhor
      GL.Enable(EnableCap.DepthTest);                   // NOVO
      GL.Enable(EnableCap.CullFace);                    // NOVO

      eye.X = eye.Y = eye.Z = 15;

    }
    protected override void OnResize(EventArgs e)
    {
      base.OnResize(e);

      GL.Viewport(ClientRectangle.X, ClientRectangle.Y, ClientRectangle.Width, ClientRectangle.Height);

      Matrix4 projection = Matrix4.CreatePerspectiveFieldOfView((float)Math.PI / 4, Width / (float)Height, 1.0f, 50.0f);
      GL.MatrixMode(MatrixMode.Projection);
      GL.LoadMatrix(ref projection);
    }

    protected override void OnUpdateFrame(FrameEventArgs e)
    {
      base.OnUpdateFrame(e);
    }
    protected override void OnRenderFrame(FrameEventArgs e)
    {
      base.OnRenderFrame(e);

      GL.Clear(ClearBufferMask.ColorBufferBit | ClearBufferMask.DepthBufferBit); // GL.Clear(ClearBufferMask.ColorBufferBit); // NOVO

      Matrix4 modelview = Matrix4.LookAt(eye, target, up);
      GL.MatrixMode(MatrixMode.Modelview);
      GL.LoadMatrix(ref modelview);

      mundo.Desenha();

      this.SwapBuffers();
    }

    //TODO: passar estas mundanças de valores de camera para Classe camera.
    //TODO: criar um padrão único para todos os exemplos de uso de teclas e mouse. Deixar em um arquivo na biblioteca para ser usado. Criar um imagem no PlantUML
    protected override void OnKeyDown(OpenTK.Input.KeyboardKeyEventArgs e)
    {
      if (e.Key == Key.Escape)
        this.Exit();
      else
      // if (e.Key == Key.Q)
      //   eye.X = eye.Y = eye.Z = 15;
      // else
      //   if (e.Key == Key.E)
      //   eye.X = eye.Y = eye.Z = 5;
      // else
      //     if (e.Key == Key.R)
      //   eye.X = eye.Y = eye.Z = 0;
      // else
      //       if (e.Key == Key.T)
      //   eye.X = eye.Y = eye.Z = -5;
      // else
      //       if (e.Key == Key.T)
      //   eye.X = eye.Y = eye.Z = -5;
      // else
      //       if (e.Key == Key.Y)
      //   eye.X = eye.Y = eye.Z = -10;
      // else
      //       if (e.Key == Key.U)
      //   eye.X = eye.Y = eye.Z = -15;
      // else
      //       if (e.Key == Key.A)
      //   target.X = target.Y = target.Z = 15;
      // else
      //       if (e.Key == Key.S)
      //   target.X = target.Y = target.Z = 10;
      // else
      //       if (e.Key == Key.D)
      //   target.X = target.Y = target.Z = 5;
      // else
      //       if (e.Key == Key.F)
      //   target.X = target.Y = target.Z = 0;
      // else
      //       if (e.Key == Key.G)
      //   target.X = target.Y = target.Z = -5;
      // else
      //       if (e.Key == Key.H)
      //   target.X = target.Y = target.Z = -10;
      // else
      //       if (e.Key == Key.J)
      //   target.X = target.Y = target.Z = -15;
      // else
            if (e.Key == Key.C)
        CameraExibeValores();

      mundo.OnKeyDown(e);

    }
    private void CameraExibeValores() {
      Console.WriteLine(" eye["+ eye.X+","+eye.Y+","+eye.Z+"]");
      Console.WriteLine(" target["+ target.X+","+target.Y+","+target.Z+"]");
      Console.WriteLine(" up["+ up.X+","+up.Y+","+up.Z+"]");
    }

    protected override void OnMouseMove(MouseMoveEventArgs e)
    {
    }
  }

  class Program
  {
    static void Main(string[] args)
    {
      Render window = new Render(600, 600);
      window.Run();
      window.Run(1.0 / 60.0);
    }
  }

}
