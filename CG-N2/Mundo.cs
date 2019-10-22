using System;
using OpenTK;
using OpenTK.Graphics.OpenGL;
using System.Drawing;
using System.Collections.Generic;
using OpenTK.Input;
using CG_Biblioteca;

namespace gcgcg
{
  class Mundo : GameWindow
  {
    private static Mundo instanciaMundo = null;

    private Mundo(int width, int height) : base(width, height) { }

    public static Mundo GetInstance(int width, int height)
    {
      if (instanciaMundo == null)
        instanciaMundo = new Mundo(width, height);
      return instanciaMundo;
    }

    private Camera camera = new Camera();
    protected List<Objeto> objetosLista = new List<Objeto>();
    private bool mouseMoverPto = false;
    //FIXME: estes objetos não devem ser atributos do Mundo
    private Retangulo obj_RetanguloA;
    private Retangulo obj_RetanguloB;

    protected override void OnLoad(EventArgs e)
    {
      base.OnLoad(e);

      obj_RetanguloA = new Retangulo("A", new Ponto4D(50, 50, 0), new Ponto4D(150, 150, 0));
      objetosLista.Add(obj_RetanguloA);
      obj_RetanguloB = new Retangulo("B", new Ponto4D(50, 150, 0), new Ponto4D(150, 250, 0));
      objetosLista.Add(obj_RetanguloB);

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
      Sru3D();
      for (var i = 0; i < objetosLista.Count; i++)
      {
        objetosLista[i].Desenhar();
      }
      this.SwapBuffers();
    }

    protected override void OnKeyDown(OpenTK.Input.KeyboardKeyEventArgs e)
    {
      if (e.Key == Key.Escape)
        Exit();
      else if (e.Key == Key.E)
      {
        for (var i = 0; i < objetosLista.Count; i++)
        {
          objetosLista[i].PontosExibirObjeto();
        }
      }
      else if (e.Key == Key.V)
      {
        mouseMoverPto = !mouseMoverPto;
      }
    }

    //FIXME: não está considerando o NDC
    protected override void OnMouseMove(MouseMoveEventArgs e)
    {
      if (mouseMoverPto)
      {
        //* Invertendo a coordenada y do espaço de tela para o espaço do mundo */
        obj_RetanguloB.MoverPtoSupDir(new Ponto4D(e.Position.X, 600 - e.Position.Y, 0));
      }
    }

    private void Sru3D()
    {
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
  class Program
  {
    static void Main(string[] args)
    {
      Mundo window = Mundo.GetInstance(600, 600);
      window.Title = "CG-N2";
      window.Run(1.0 / 60.0);
    }
  }
}
