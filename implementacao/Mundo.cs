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

    CameraOrtho camera = new CameraOrtho();
    List<ObjetoGeometria> objetosLista = new List<ObjetoGeometria>();
    ObjetoGeometria objetoSelecionado = null;
    String estado = "add-pto";
    bool shwBB = true;

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

      if (this.objetoSelecionado != null && this.shwBB)
      {
        this.objetoSelecionado.bbox().Desenhar();
      }

      this.SwapBuffers();
    }

    protected override void OnKeyDown(OpenTK.Input.KeyboardKeyEventArgs e)
    {
      if (e.Key == Key.Escape || e.Key == Key.Q)
      {
        Exit();
      }
      else if (e.Key == Key.Left)
      {
        if (this.objetoSelecionado != null)
        {
          Transformacao4D tr = new Transformacao4D();
          tr.AtribuirTranslacao(-5, 0, 0);
          Transformacao4D trOriginal = this.objetoSelecionado.Transformacao;
          this.objetoSelecionado.Transformacao = trOriginal.MultiplicarMatriz(tr);
        }
      }
      else if (e.Key == Key.Right)
      {
        if (this.objetoSelecionado != null)
        {
          Transformacao4D tr = new Transformacao4D();
          tr.AtribuirTranslacao(5, 0, 0);
          Transformacao4D trOriginal = this.objetoSelecionado.Transformacao;
          this.objetoSelecionado.Transformacao = trOriginal.MultiplicarMatriz(tr);
        }
      }
      else if (e.Key == Key.Up)
      {
        if (this.objetoSelecionado != null)
        {
          Transformacao4D tr = new Transformacao4D();
          tr.AtribuirTranslacao(0, 5, 0);
          Transformacao4D trOriginal = this.objetoSelecionado.Transformacao;
          this.objetoSelecionado.Transformacao = trOriginal.MultiplicarMatriz(tr);
        }
      }
      else if (e.Key == Key.Down)
      {
        if (this.objetoSelecionado != null)
        {
          Transformacao4D tr = new Transformacao4D();
          tr.AtribuirTranslacao(0, -5, 0);
          Transformacao4D trOriginal = this.objetoSelecionado.Transformacao;
          this.objetoSelecionado.Transformacao = trOriginal.MultiplicarMatriz(tr);
        }
      }
      else if (e.Key == Key.I)
      {
        if (this.objetoSelecionado != null)
        {
          this.objetoSelecionado.Transformacao = new Transformacao4D();
        }
      }
      else if (e.Key == Key.O)
      {
        this.shwBB = !this.shwBB;
      }
      else if (e.Key == Key.A)
      {
        this.estado = "sel-pol";
      }
      else if (e.Key == Key.Enter)
      {
        if (this.objetoSelecionado != null)
        {
          this.objetoSelecionado.pontos.limpaPontoSel();
          this.objetoSelecionado = null;
          this.estado = "sel-pol";
        }
      }
      else if (e.Key == Key.Space)
      {
        if (this.objetoSelecionado != null)
        {
          this.objetoSelecionado = null;
          this.estado = "add-pto";
        }
      }
      else if (e.Key == Key.R)
      {
        if (this.objetoSelecionado != null)
        {
          this.objetoSelecionado.Cor = Color.Red;
        }
      }
      else if (e.Key == Key.G)
      {
        if (this.objetoSelecionado != null)
        {
          this.objetoSelecionado.Cor = Color.Green;
        }
      }
      else if (e.Key == Key.B)
      {
        if (this.objetoSelecionado != null)
        {
          this.objetoSelecionado.Cor = Color.Blue;
        }
      }
    }

    // protected override void OnMouseMove(MouseMoveEventArgs e)
    // {
    //     base.OnMouseMove(e);
    // }

    protected override void OnMouseDown(MouseButtonEventArgs e)
    {
      base.OnMouseDown(e);
      Ponto4D pto = new Ponto4D(e.Mouse.X, 600-e.Mouse.Y);
      
      if (this.estado == "add-pto")
      {
        if (this.objetoSelecionado == null)
        {
          this.objetoSelecionado = new ObjetoGeometria("Poligono " + this.objetosLista.Count);
          this.objetoSelecionado.Selecionado = true;
          this.objetosLista.Add(this.objetoSelecionado);
        }
        this.objetoSelecionado.pontos.addPonto(pto);
      }
      else if (this.estado == "mov-pto")
      {
        if (this.objetoSelecionado == null)
        {
          return;
        }
        this.objetoSelecionado.pontos.movePontoSel(pto);
      }
      else if (this.estado == "sel-pol")
      {
        this.objetoSelecionado = null;
        foreach (ObjetoGeometria objeto in this.objetosLista)
        {
          bool inBB = Utilitario.insideBBox(pto, objeto.bbox());
          if (!inBB)
          {
            continue;
          }
          if (Utilitario.insidePol(pto, objeto.pontos.pontos(objeto.Transformacao)))
          {
            this.objetoSelecionado = objeto;
            this.objetoSelecionado.Selecionado = true;
            this.estado = "add-pto";
            break;
          }
        } 
      }
      else if (this.estado == "sel-pto")
      {

        if (this.objetoSelecionado == null)
        {
          return;
        }
        this.objetoSelecionado.pontos.SelecionaProximo(pto, this.objetoSelecionado.Transformacao);
        this.estado = "mov-pto";
      }

      if (e.Button == MouseButton.Middle && this.objetoSelecionado != null)
      {
        this.objetosLista.Remove(this.objetoSelecionado);
        this.objetoSelecionado = null;
      }

    }

  }

}
