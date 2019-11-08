#define CG_Gizmo
#define CG_Privado

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
    private ObjetoGeometria objetoSelecionado = null;
    private bool bBoxDesenhar = false;
    int mouseX, mouseY;   //FIXME: achar método MouseDown para não ter variável Global
    private Poligono objetoNovo = null;
    private String objetoId = "A";
    private Retangulo obj_Retangulo;
    private Privado_SegReta obj_SegReta;
    private Privado_Circulo obj_Circulo;
    private Cubo obj_Cubo;

    protected override void OnLoad(EventArgs e)
    {
      base.OnLoad(e);
      Console.WriteLine(" --- Ajuda / Teclas: ");
      Console.WriteLine(" [  H     ] mostra teclas usadas. ");
      obj_Retangulo = new Retangulo("A", null, new Ponto4D(50, 50, 0), new Ponto4D(150, 150, 0));
      objetosLista.Add(obj_Retangulo);
      obj_SegReta = new Privado_SegReta("B", null, new Ponto4D(50, 150), new Ponto4D(150, 250));
      objetosLista.Add(obj_SegReta);
      obj_Circulo = new Privado_Circulo("C", null, new Ponto4D(100,300), 50);
      objetosLista.Add(obj_Circulo);
      obj_Cubo = new Cubo("D",null);
      objetosLista.Add(obj_Cubo);
      objetoSelecionado = obj_Cubo;;
      
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
#if CG_Gizmo      
      Sru3D();
#endif
      for (var i = 0; i < objetosLista.Count; i++)
        objetosLista[i].Desenhar();
      if (bBoxDesenhar && (objetoSelecionado != null))
        objetoSelecionado.BBox.Desenhar();
      this.SwapBuffers();
    }

    protected override void OnKeyDown(OpenTK.Input.KeyboardKeyEventArgs e)
    {
      // N3-Exe2: usar o arquivo docs/umlClasses.wsd
      // N3-Exe3: usar o arquivo bin/documentação.XML -> ver exemplo CG_Biblioteca/bin/documentação.XML
      if (e.Key == Key.H)
        Utilitario.AjudaTeclado();
      else if (e.Key == Key.Escape)
        Exit();
      else if (e.Key == Key.E)    // N3-Exe4: ajuda a conferir se os poligonos e vértices estão certos
      {
        Console.WriteLine("--- Objetos / Pontos: ");
        for (var i = 0; i < objetosLista.Count; i++)
        {
          objetosLista[i].PontosExibirObjeto();
        }
      }
      else if (e.Key == Key.O)
        bBoxDesenhar = !bBoxDesenhar;   // N3-Exe9: exibe a BBox ... sempre desenha bBox se tiver objetoSelecionado
      else if (e.Key == Key.Enter)
      {
        if (objetoNovo != null)
        {
          objetoNovo.PontosRemoverUltimo();   // N3-Exe6: "truque" para deixar o rastro
          objetoSelecionado = objetoNovo;
          objetoNovo = null;
        }
      }
      else if (e.Key == Key.Space)
      {
        if (objetoNovo == null)
        {
          objetoNovo = new Poligono(objetoId + 1, null);
          objetosLista.Add(objetoNovo);
          objetoNovo.PontosAdicionar(new Ponto4D(mouseX, mouseY));
          objetoNovo.PontosAdicionar(new Ponto4D(mouseX, mouseY));  // N3-Exe6: "troque" para deixar o rastro
        }
        else
          objetoNovo.PontosAdicionar(new Ponto4D(mouseX, mouseY));
      } else if (objetoSelecionado != null)
      {
        if (e.Key == Key.M)
          objetoSelecionado.ExibeMatriz();
        else if (e.Key == Key.P)
          objetoSelecionado.PontosExibirObjeto();
        else if (e.Key == Key.I)
          objetoSelecionado.AtribuirIdentidade();
        //FIXME: não está atualizando a BBox com as transformações geométricas
        else if (e.Key == Key.Left)
          objetoSelecionado.TranslacaoXY(-10, 0);       // N3-Exe10: translação
        else if (e.Key == Key.Right)
          objetoSelecionado.TranslacaoXY(10, 0);        // N3-Exe10: translação
        else if (e.Key == Key.Up)
          objetoSelecionado.TranslacaoXY(0, 10);        // N3-Exe10: translação
        else if (e.Key == Key.Down)
          objetoSelecionado.TranslacaoXY(0, -10);       // N3-Exe10: translação
        else if (e.Key == Key.PageUp)
          objetoSelecionado.EscalaXY(2, 2);
        else if (e.Key == Key.PageDown)
          objetoSelecionado.EscalaXY(0.5, 0.5);
        else if (e.Key == Key.Home)
          objetoSelecionado.EscalaXYBBox(0.5);          // N3-Exe11: escala
        else if (e.Key == Key.End)
          objetoSelecionado.EscalaXYBBox(2);            // N3-Exe11: escala
        else if (e.Key == Key.Number1)
          objetoSelecionado.RotacaoZ(10);
        else if (e.Key == Key.Number2)
          objetoSelecionado.RotacaoZ(-10);
        else if (e.Key == Key.Number3)
          objetoSelecionado.RotacaoZBBox(10);           // N3-Exe12: rotação
        else if (e.Key == Key.Number4)
          objetoSelecionado.RotacaoZBBox(-10);          // N3-Exe12: rotação
        else if (e.Key == Key.Number9)
          objetoSelecionado = null;   //TODO: remover está tecla e atribuir o null qdo não tiver um poligono
        else
          Console.WriteLine(" __ Tecla não implementada.");
      } else
        Console.WriteLine(" __ Tecla não implementada.");
    }

    //FIXME: não está considerando o NDC
    protected override void OnMouseMove(MouseMoveEventArgs e)
    {
      mouseX = e.Position.X; mouseY = 600 - e.Position.Y; // Inverti eixo Y
      if (objetoNovo != null)
      {
        objetoNovo.PontosUltimo().X = mouseX;             // N3-Exe5: movendo um vértice de um poligono específico
        objetoNovo.PontosUltimo().Y = mouseY;
      }
    }

#if CG_Gizmo
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
