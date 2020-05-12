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
    public Poligono objetoSelecionado = null;

    protected override void OnLoad(EventArgs e)
    {
      base.OnLoad(e);
      Console.WriteLine(" --- Ajuda / Teclas: ");
      Console.WriteLine(" [  H     ] mostra teclas usadas. ");

      GL.ClearColor(Color.Gray);
      
      camera.xmin = 0;
      camera.xmax = 600;
      camera.ymin = 0;
      camera.ymax = 600;
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
        base.OnMouseMove(e);
    }

    protected override void OnMouseDown(MouseButtonEventArgs e)
    {
      base.OnMouseDown(e);
      Ponto4D pto = new Ponto4D(e.Mouse.X, 600-e.Mouse.Y);

      if (e.Button == MouseButton.Left)
      {
        if (this.objetoSelecionado == null)
        {
          this.objetoSelecionado = new Poligono("Poligono " + this.objetosLista.Count, null);
          this.objetosLista.Add(this.objetoSelecionado);
        }
        this.objetoSelecionado.PontosAdicionar(pto);
      }
      else
      {
        this.objetoSelecionado = null;

        foreach (Poligono objeto in this.objetosLista) {
          bool inBB = Utilitario.insideBBox(pto, objeto.BBox);

          if (inBB)
          {
            if (Utilitario.insidePol(pto, objeto.PontosLista))
            {
              this.objetoSelecionado = objeto;
              return;
            }
          }
        } 
      }
    }

  }

}
