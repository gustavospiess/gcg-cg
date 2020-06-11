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
    Transformacao4D ultima = new Transformacao4D();
    bool shwBB = true;

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
        BBox bb = objetoSelecionado.bbox();
        bb.ProcessarCentro();
        bb.Desenhar();
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
          if (e.Control)
          {
            tr.AtribuirRotacaoZ(0.05);
          }
          else
          {
            tr.AtribuirTranslacao(-5, 0, 0);
          }
          Transformacao4D trOriginal = this.objetoSelecionado.Transformacao;
          this.objetoSelecionado.Transformacao = tr.MultiplicarMatriz(trOriginal);
        }
      }
      else if (e.Key == Key.Right)
      {
        if (this.objetoSelecionado != null)
        {
          Transformacao4D tr = new Transformacao4D();
          if (e.Control)
          {
            tr.AtribuirRotacaoZ(-0.05);
          }
          else
          {
            tr.AtribuirTranslacao(5, 0, 0);
          }
          Transformacao4D trOriginal = this.objetoSelecionado.Transformacao;
          this.objetoSelecionado.Transformacao = tr.MultiplicarMatriz(trOriginal);
        }
      }
      else if (e.Key == Key.Up)
      {
        if (this.objetoSelecionado != null)
        {
          Transformacao4D tr = new Transformacao4D();
          if (e.Control)
          {
            BBox bb = objetoSelecionado.bbox();
            bb.ProcessarCentro();
            Transformacao4D tr2 = new Transformacao4D();
            tr2.AtribuirTranslacao(-1 * bb.obterCentro.X, -1 * bb.obterCentro.Y, -1 * bb.obterCentro.Z);
            tr.AtribuirRotacaoZ(-0.05);
            tr = tr2.MultiplicarMatriz(tr);
            tr2.AtribuirTranslacao(bb.obterCentro.X, bb.obterCentro.Y, bb.obterCentro.Z);
            tr2 = tr.MultiplicarMatriz(tr2);
            tr = tr2;
          }
          else if (e.Shift)
          {
            tr.AtribuirEscala(1.01, 1.01, 1.01);
          }
          else
          {
            tr.AtribuirTranslacao(0, 5, 0);
          }
          Transformacao4D trOriginal = this.objetoSelecionado.Transformacao;
          this.objetoSelecionado.Transformacao = tr.MultiplicarMatriz(trOriginal);
        }
      }
      else if (e.Key == Key.Down)
      {
        if (this.objetoSelecionado != null)
        {
          Transformacao4D tr = new Transformacao4D();
          if (e.Control)
          {
            BBox bb = objetoSelecionado.bbox();
            bb.ProcessarCentro();
            Transformacao4D tr2 = new Transformacao4D();
            tr2.AtribuirTranslacao(-1 * bb.obterCentro.X, -1 * bb.obterCentro.Y, -1 * bb.obterCentro.Z);
            tr.AtribuirRotacaoZ(0.05);
            tr = tr2.MultiplicarMatriz(tr);
            tr2.AtribuirTranslacao(bb.obterCentro.X, bb.obterCentro.Y, bb.obterCentro.Z);
            tr2 = tr.MultiplicarMatriz(tr2);
            tr = tr2;
          }
          else if (e.Shift)
          {
            tr.AtribuirEscala(0.99, 0.99, 0.99);
          }
          else
          {
            tr.AtribuirTranslacao(0, -5, 0);
          }
          Transformacao4D trOriginal = this.objetoSelecionado.Transformacao;
          this.objetoSelecionado.Transformacao = tr.MultiplicarMatriz(trOriginal);
        }
      }
      else if (e.Key == Key.U)
      {
        if (this.objetoSelecionado != null)
        {
          this.objetoSelecionado.Transformacao = this.ultima;
        }
      }
      else if (e.Key == Key.I)
      {
        if (this.objetoSelecionado != null)
        {
          this.ultima = this.objetoSelecionado.Transformacao;
          this.objetoSelecionado.Transformacao = new Transformacao4D();
        }
      }
      else if (e.Key == Key.O)
      {
        this.shwBB = !this.shwBB;
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

    protected override void OnMouseDown(MouseButtonEventArgs e)
    {
      base.OnMouseDown(e);
      Ponto4D pto = new Ponto4D(e.Mouse.X-300, 300-e.Mouse.Y);
      Ponto4D ptoTr;
      if (this.objetoSelecionado != null)
      {
        ptoTr = this.objetoSelecionado.Transformacao.MultiplicarPonto(pto);
      }
      else
      {
        ptoTr = pto;
      }

      KeyboardState st = Keyboard.GetState();

      if (st[Key.ShiftLeft])
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
            break;
          }
        } 
      }

      if (st[Key.ControlLeft] && st[Key.ShiftLeft])
      {
        if (this.objetoSelecionado == null)
        {
          return;
        }
        if (ptoTr.X != pto.X || ptoTr.Y != pto.Y)
        {
          this.ultima = this.objetoSelecionado.Transformacao;
          this.objetoSelecionado.Transformacao = new Transformacao4D();
        }
        else
        {
            this.objetoSelecionado.pontos.SelecionaProximo(pto, this.objetoSelecionado.Transformacao);
        }
        return;
      }
      
      if (st[Key.ControlLeft])
      {
        if (this.objetoSelecionado == null)
        {
          this.objetoSelecionado = new ObjetoGeometria("Poligono " + this.objetosLista.Count);
          this.objetoSelecionado.Selecionado = true;
          this.objetosLista.Add(this.objetoSelecionado);
        }
        else
        {
          if (ptoTr.X != pto.X || ptoTr.Y != pto.Y)
          {
            this.ultima = this.objetoSelecionado.Transformacao;
            this.objetoSelecionado.Transformacao = new Transformacao4D();
          }
          else
          {
            this.objetoSelecionado.pontos.addPonto(pto);
          }
        }
        return;
      }

      if (this.objetoSelecionado == null || this.objetoSelecionado.pontos.pontoSel(new Transformacao4D()) == null)
      {
        return;
      }

      if (ptoTr.X != pto.X || ptoTr.Y != pto.Y)
      {
        this.ultima = this.objetoSelecionado.Transformacao;
        this.objetoSelecionado.Transformacao = new Transformacao4D();
      }
      else
      {
        this.objetoSelecionado.pontos.movePontoSel(pto);
        this.objetoSelecionado.pontos.limpaPontoSel();
      }
    }

  }

}
