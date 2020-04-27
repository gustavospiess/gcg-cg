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
    public ObjetoSpline objetoSelecionado = null;
    private bool bBoxDesenhar = false;
    int mouseX, mouseY;
    private bool mouseMoverPto = false;

    private List<PrimitiveType> lista_primitivas = new List<PrimitiveType>()
    {
      PrimitiveType.Points,
      PrimitiveType.Lines,
      PrimitiveType.LineLoop,
      PrimitiveType.LineStrip,
      PrimitiveType.Triangles,
      PrimitiveType.TriangleStrip,
      PrimitiveType.TriangleFan,
      PrimitiveType.Quads,
      PrimitiveType.QuadStrip,
      PrimitiveType.Polygon
    };

    protected override void OnLoad(EventArgs e)
    {
      base.OnLoad(e);
      Console.WriteLine(" --- Ajuda / Teclas: ");
      Console.WriteLine(" [  H     ] mostra teclas usadas. ");

      GL.ClearColor(Color.Gray);
      
      camera.xmin = -300;
      camera.xmax = 300;
      camera.ymin = -300;
      camera.ymax = 300;
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

      if (bBoxDesenhar && (objetoSelecionado != null))
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
      else if (e.Key == Key.B)
      {
        if (objetoSelecionado != null)
        {
          objetoSelecionado.move(new Ponto4D(0, -10));
        }
      }
      else if (e.Key == Key.C)
      {
        if (objetoSelecionado != null)
        {
          objetoSelecionado.move(new Ponto4D(0, 10));
        }
      }
      else if (e.Key == Key.E)
      {
        if (objetoSelecionado != null)
        {
          objetoSelecionado.move(new Ponto4D(-10, 0));
        }
      }
      else if (e.Key == Key.D)
      {
        if (objetoSelecionado != null)
        {
          objetoSelecionado.move(new Ponto4D(10, 0));
        }
      }
      else if (e.Key == Key.Number0)
      {
        if (objetoSelecionado != null)
        {
          objetoSelecionado.pontoSel = -1;
        }
      }
      else if (e.Key == Key.Number1)
      {
        if (objetoSelecionado != null)
        {
          objetoSelecionado.pontoSel = 0;
        }
      }
      else if (e.Key == Key.Number2)
      {
        if (objetoSelecionado != null)
        {
          objetoSelecionado.pontoSel = 1;
        }
      }
      else if (e.Key == Key.Number3)
      {
        if (objetoSelecionado != null)
        {
          objetoSelecionado.pontoSel = 2;
        }
      }
      else if (e.Key == Key.Number4)
      {
        if (objetoSelecionado != null)
        {
          objetoSelecionado.pontoSel = 3;
        }
      }
      else if (e.Key == Key.Minus || e.Key == Key.KeypadMinus)
      {
        if (objetoSelecionado != null)
        {
          if (objetoSelecionado.qtLinhas > 0)
          {
            objetoSelecionado.qtLinhas -= 1;
            Console.WriteLine(objetoSelecionado.qtLinhas);
          }
        }
      }
      else if (e.Key == Key.Plus)
      {
        if (objetoSelecionado != null)
        {
          objetoSelecionado.qtLinhas += 1;
          Console.WriteLine(objetoSelecionado.qtLinhas);
        }
      }
      else
      {
        Console.WriteLine(" __ Tecla não implementada.");
      }
    }

    protected override void OnMouseMove(MouseMoveEventArgs e)
    {
      mouseX = e.Position.X;
      mouseY = 600 - e.Position.Y;
      if (mouseMoverPto && (objetoSelecionado != null))
      {
        objetoSelecionado.PontosUltimo().X = mouseX;
        objetoSelecionado.PontosUltimo().Y = mouseY;
      }
    }
  }

}
