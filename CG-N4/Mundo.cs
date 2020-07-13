/**
  Autor: Dalton Solano dos Reis
**/

#define CG_Gizmo

using System;
using OpenTK;
using OpenTK.Graphics.OpenGL;
using System.Collections.Generic;
using OpenTK.Input;
using CG_Biblioteca;


//TODO: arrumar o id dos objetos usando char letra = 'A'; letra++;
//TODO: ter mais objetos geométricos: esfera
//TODO: arrumar objeto cone
//TODO: ter iluminação
//TODO: ter textura
//TODO: ter texto 2D
//TODO: ter um mapa em 2D
//TODO: ler arquivo OBJ/MTL
//TODO: ter audio
//TODO: usar DisplayList
//TODO: Seleciona Alpha
//TODO: Unproject
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

    protected List<Transformacao4D> movimentos = new List<Transformacao4D>();
    protected List<Int32> qtMovimentos = new List<Int32>();
    protected int i;
    protected int j;
    private CameraPerspective camera = new CameraPerspective();
    protected List<Objeto> objetosLista = new List<Objeto>();
    private ObjetoGeometria objetoSelecionado = null;
    private bool bBoxDesenhar = false;
    int mouseX, mouseY;   //TODO: achar método MouseDown para não ter variável Global
    private String objetoId = "A";
    private Cubo obj_Cubo;
    private Cilindro obj_Cilindro;
    private Esfera obj_Esfera;
    private Cone obj_Cone;

    protected override void OnLoad(EventArgs e)
    {

      curva(0.1, 'V');
      reta(5);
      curva(-0.1, 'V');
      curva(0.5, 'H');
      curva(-0.1, 'V');
      reta(1);
      curva(0.25, 'H');
      curva(-0.25, 'T');
      curva(0.25, 'H');
      curva(0.25, 'H');
      curva(-0.25, 'T');
      curva(0.25, 'H');
      curva(0.1, 'V');
      reta(1);
      curva(1/3.0, 'V');
      curva(1/3.0, 'V');
      curva(1/3.0, 'V');
      reta(1);
      for (var i = 0; i < 5; i++)
        curva(0.2, 'V');
      reta(1);
      curva(-0.05, 'T');
      curva(0.5, 'H');
      curva(-0.05, 'T');

      base.OnLoad(e);
      Console.WriteLine(" --- Ajuda / Teclas: ");
      Console.WriteLine(" [  H     ] mostra teclas usadas. ");

      obj_Cubo = new Cubo("G", null);
      objetosLista.Add(obj_Cubo);
      obj_Cubo.EscalaXYZ(50, 50, 50);

      objetoSelecionado = obj_Cubo;

      camera.At = new Vector3(0, 0, 0);
      camera.Eye = new Vector3(2000, 2000, 2000);
      // camera.Eye = new Vector3(0, 0, 1000);
      camera.Near = 100.0f;
      camera.Far = 8000.0f;

      GL.ClearColor(127,127,127,255);
      GL.Enable(EnableCap.DepthTest);
      // GL.Enable(EnableCap.CullFace);
      GL.Disable(EnableCap.CullFace);
    }
    protected override void OnResize(EventArgs e)
    {
      base.OnResize(e);

      GL.Viewport(ClientRectangle.X, ClientRectangle.Y, ClientRectangle.Width, ClientRectangle.Height);

      Matrix4 projection = Matrix4.CreatePerspectiveFieldOfView(camera.Fovy, Width / (float)Height, camera.Near, camera.Far);
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
      GL.Clear(ClearBufferMask.ColorBufferBit | ClearBufferMask.DepthBufferBit);
      Matrix4 modelview = Matrix4.LookAt(camera.Eye, camera.At, camera.Up);
      GL.MatrixMode(MatrixMode.Modelview);
      GL.LoadMatrix(ref modelview);
#if CG_Gizmo      
      Sru3D();
#endif
      for (var i = 0; i < objetosLista.Count; i++)
        objetosLista[i].Desenhar();
      if (bBoxDesenhar && (objetoSelecionado != null))
        objetoSelecionado.BBox.Desenhar();

      Transformacao4D tr = new Transformacao4D();
      tr.AtribuirEscala(50, 50, 50);
      Ponto4D pt = new Ponto4D(0, 0, 0);

      GL.LineWidth(5);
      GL.Color3(0, 0, 0);
      GL.Begin(PrimitiveType.LineLoop);
      for (var i = 0; i < movimentos.Count; i++)
      {
        for (var j = 0; j < qtMovimentos[i]; j++)
        {
          Ponto4D pt2 = tr.MultiplicarPonto(pt);
          GL.Vertex3(pt2.X, pt2.Y, pt2.Z);
          tr = tr.MultiplicarMatriz(movimentos[i]);
        }
      }
      GL.End();

      objetoSelecionado.Matriz = objetoSelecionado.Matriz.MultiplicarMatriz(this.movimentos[i]);
      j++;
      if (j >= this.qtMovimentos[i])
      {
        i++;
        j = 0;
        if (i >= this.movimentos.Count)
        {
          i = 0;
          objetoSelecionado.Matriz.AtribuirIdentidade();
          objetoSelecionado.Matriz.AtribuirEscala(50, 50, 50);
        }
      }

      this.SwapBuffers();
    }

    protected override void OnKeyDown(OpenTK.Input.KeyboardKeyEventArgs e)
    {
      if (e.Key == Key.Escape)
        Exit();
      else if (e.Key == Key.E)
      {
        Console.WriteLine("--- Objetos / Pontos: ");
        for (var i = 0; i < objetosLista.Count; i++)
        {
          Console.WriteLine(objetosLista[i]);
        }
      }
      else if (e.Key == Key.O)
        bBoxDesenhar = !bBoxDesenhar;
      else if (e.Key == Key.Left)
      {
        this.AtRotateX(-1/2);
        this.AtRotateY(1);
      }
      else if (e.Key == Key.Right)
      {
        this.AtRotateX(1/2);
        this.AtRotateY(-1);
      }
      else if (e.Key == Key.Up)
        this.EyeRotate(1);
      else if (e.Key == Key.Down)
        this.EyeRotate(-1);
      else if (objetoSelecionado != null)
      {
        if (e.Key == Key.M)
          Console.WriteLine(objetoSelecionado.Matriz);
        else if (e.Key == Key.P)
          Console.WriteLine(objetoSelecionado);
        else if (e.Key == Key.I)
        {
          objetoSelecionado.AtribuirIdentidade();
          this.i = 0;
          this.j = 0;
        }
       else if (e.Key == Key.Number8)
          objetoSelecionado.TranslacaoXYZ(0, 0, 10);
        else if (e.Key == Key.Number9)
          objetoSelecionado.TranslacaoXYZ(0, 0, -10);
        else if (e.Key == Key.PageUp)
          objetoSelecionado.EscalaXYZ(2, 2, 2);
        else if (e.Key == Key.PageDown)
          objetoSelecionado.EscalaXYZ(0.5, 0.5, 0.5);
        else if (e.Key == Key.Home)
          objetoSelecionado.EscalaXYZBBox(0.5, 0.5, 0.5);
        else if (e.Key == Key.End)
          objetoSelecionado.EscalaXYZBBox(2, 2, 2);
        else if (e.Key == Key.Number1)
          objetoSelecionado.Rotacao(10);
        else if (e.Key == Key.Number2)
          objetoSelecionado.Rotacao(-10);
        else if (e.Key == Key.Number3)
          objetoSelecionado.RotacaoZBBox(10);
        else if (e.Key == Key.Number4)
          objetoSelecionado.RotacaoZBBox(-10);
        else if (e.Key == Key.Number0)
          objetoSelecionado = null;
        else if (e.Key == Key.X)
          objetoSelecionado.TrocaEixoRotacao('x');
        else if (e.Key == Key.Y)
          objetoSelecionado.TrocaEixoRotacao('y');
        else if (e.Key == Key.Z)
          objetoSelecionado.TrocaEixoRotacao('z');
        else
          Console.WriteLine(" __ Tecla não implementada.");
      }
      else
        Console.WriteLine(" __ Tecla não implementada.");
    }

    //TODO: não está considerando o NDC
    protected override void OnMouseMove(MouseMoveEventArgs e)
    {
      mouseX = e.Position.X; mouseY = 600 - e.Position.Y; // Inverti eixo Y
    }

    private Vector3 PontoToVector(Ponto4D p)
    {
      return new Vector3(Convert.ToSingle(p.X), Convert.ToSingle(p.Y), Convert.ToSingle(p.Z));
    }

    private Ponto4D VectorToPonto(Vector3 v)
    {
      return new Ponto4D(v.X, v.Y, v.Z);
    }

    private void AtRotateY(float n)
    {
      Transformacao4D matA = new Transformacao4D();
      matA.AtribuirTranslacao(camera.Eye.X, camera.Eye.Y, camera.Eye.Z);
      Transformacao4D matB = new Transformacao4D();
      matB.AtribuirRotacaoY(n * Math.PI/120);
      matA = matA.MultiplicarMatriz(matB);
      matB.AtribuirTranslacao(-1*camera.Eye.X, -1*camera.Eye.Y, -1*camera.Eye.Z);
      matA = matA.MultiplicarMatriz(matB);
      this.camera.At = PontoToVector(matA.MultiplicarPonto(VectorToPonto(this.camera.At)));
    }

    private void AtRotateX(float n)
    {
      Transformacao4D matA = new Transformacao4D();
      matA.AtribuirTranslacao(camera.Eye.X, camera.Eye.Y, camera.Eye.Z);
      Transformacao4D matB = new Transformacao4D();
      matB.AtribuirRotacaoX(n * Math.PI/120);
      matA = matA.MultiplicarMatriz(matB);
      matB.AtribuirTranslacao(-1*camera.Eye.X, -1*camera.Eye.Y, -1*camera.Eye.Z);
      matA = matA.MultiplicarMatriz(matB);
      this.camera.At = PontoToVector(matA.MultiplicarPonto(VectorToPonto(this.camera.At)));
    }

    private void EyeRotate(float n)
    {
      Transformacao4D matA = new Transformacao4D();
      matA.AtribuirTranslacao(camera.At.X, camera.At.Y, camera.At.Z);
      Transformacao4D matB = new Transformacao4D();
      matB.AtribuirRotacaoY(n * Math.PI/120);
      matA = matA.MultiplicarMatriz(matB);
      matB.AtribuirTranslacao(-1*camera.At.X, -1*camera.At.Y, -1*camera.At.Z);
      matA = matA.MultiplicarMatriz(matB);
      this.camera.Eye = PontoToVector(matA.MultiplicarPonto(VectorToPonto(this.camera.Eye)));
    }

    private void reta(int qt)
    {
      Transformacao4D tr = new Transformacao4D();
      tr.AtribuirTranslacao(1, 0, 0);
      this.movimentos.Add(tr);
      this.qtMovimentos.Add(qt*5);
    }

    private void curva(double i, char d)
    {
      Transformacao4D tr = new Transformacao4D();
      Transformacao4D trAux = new Transformacao4D();
      if (d == 'H')
      {
        trAux.AtribuirTranslacao(0.3, 0, 0);
        tr.AtribuirRotacaoY(Math.PI*i/(10));
      }
      else if (d == 'V')
      {
        trAux.AtribuirTranslacao(0.3, 0, 0);
        tr.AtribuirRotacaoZ(Math.PI*i/(10));
      }
      else
      {
        trAux.AtribuirTranslacao(0.3, 0, 0);
        tr.AtribuirRotacaoX(Math.PI*i/(10));
      }
      this.movimentos.Add(trAux.MultiplicarMatriz(tr));
      this.qtMovimentos.Add(20);
    }

#if CG_Gizmo
    private void Sru3D()
    {
      GL.LineWidth(1);
      GL.Begin(PrimitiveType.Lines);
      GL.Color3(255,0,0);
      GL.Vertex3(0, 0, 0); GL.Vertex3(20000, 0, 0);
      GL.Color3(0,255,0);
      GL.Vertex3(0, 0, 0); GL.Vertex3(0, 20000, 0);
      GL.Color3(0,0,255);
      GL.Vertex3(0, 0, 0); GL.Vertex3(0, 0, 20000);
      GL.End();
    }
#endif    
  }
  class Program
  {
    static void Main(string[] args)
    {
      Mundo window = Mundo.GetInstance(600, 600);
      window.Title = "CG-N4";
      window.Run(1.0 / 60.0);
    }
  }
}
