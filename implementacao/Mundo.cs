#define CG_Gizmo

using System;
using OpenTK;
using OpenTK.Graphics.OpenGL;
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

    private CameraOrtho camera = new CameraOrtho();
    protected List<Objeto> objetosLista = new List<Objeto>();
    public Objeto objetoSelecionado = null;

    protected override void OnLoad(EventArgs e)
    {
      base.OnLoad(e);
      Console.WriteLine(" --- Ajuda / Teclas: ");
      Console.WriteLine(" [  H     ] mostra teclas usadas. ");

      GL.ClearColor(Color.Gray);
      
      camera.xmin = -100;
      camera.xmax = 500;
      camera.ymin = -100;
      camera.ymax = 500;
    }

    public void addObjeto(Objeto o)
    {
      objetosLista.Add(o);
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

      for (var i = 0; i < objetosLista.Count; i++)
      {
        objetosLista[i].Desenhar();
      }

      if (objetoSelecionado != null)
      {
        objetoSelecionado.BBox.Desenhar();
      }

      if (Mouse.GetState().RightButton == Mouse.GetState().LeftButton)
      {
          this.objetosLista[this.objetosLista.Count-1].Posicao = new Ponto4D(250, 250);
          this.objetosLista[this.objetosLista.Count-1].Cor = Color.Black;
      }

      this.SwapBuffers();
    }

    protected override void OnKeyDown(OpenTK.Input.KeyboardKeyEventArgs e)
    {
      if (e.Key == Key.H)
      {
        Utilitario.AjudaTeclado();
      }
      else if (e.Key == Key.Escape)
      {
        Exit();
      }
      else
      {
        Console.WriteLine(" __ Tecla não implementada.");
      }
    }

    protected override void OnMouseMove(MouseMoveEventArgs e)
    {
      Objeto ultimo = this.objetosLista[this.objetosLista.Count-1];
      bool inBB = true;
      if (ultimo.Posicao.X > this.objetoSelecionado.BBox.obterMaiorX)
      {
        inBB = false;
      }
      else if (ultimo.Posicao.Y > this.objetoSelecionado.BBox.obterMaiorY)
      {
        inBB = false;
      }
      else if (ultimo.Posicao.X < this.objetoSelecionado.BBox.obterMenorX)
      {
        inBB = false;
      }
      else if (ultimo.Posicao.Y < this.objetoSelecionado.BBox.obterMenorY)
      {
        inBB = false;
      }
      
      if (inBB)
      {
        ultimo.Cor = Color.Black;
      }
      else
      {
        ultimo.Cor = Color.Red;
      }


      if (e.Mouse.LeftButton == e.Mouse.RightButton)
      {
        return;
      }

      if (inBB)
      {
        ultimo.Posicao += new Ponto4D(e.XDelta, -1 * e.YDelta);
        return;
      }

      Ponto4D c = this.objetoSelecionado.BBox.obterCentro;
      Ponto4D p = ultimo.Posicao + new Ponto4D(e.XDelta, -1 * e.YDelta);
      double x = p.X-c.X;
      double y = p.Y-c.Y;
      if (x*x+y*y < 40000)
      {
        ultimo.Posicao = p;
        return;
      }

      c = this.objetoSelecionado.BBox.obterCentro;
      p = ultimo.Posicao + new Ponto4D(e.XDelta, 0);
      x = p.X-c.X;
      y = p.Y-c.Y;
      if (x*x+y*y < 40000)
      {
        ultimo.Posicao = p;
        return;
      }

      c = this.objetoSelecionado.BBox.obterCentro;
      p = ultimo.Posicao + new Ponto4D(0, -1 * e.YDelta);
      x = p.X-c.X;
      y = p.Y-c.Y;
      if (x*x+y*y < 40000)
      {
        ultimo.Posicao = p;
        return;
      }

    }
  }

}
