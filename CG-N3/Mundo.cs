/*
  Autor: Dalton Solano dos Reis
*/

using System;
using OpenTK.Graphics.OpenGL;
using System.Drawing;
using OpenTK.Input;
using CG_Biblioteca;

namespace gcgcg
{
  /// <summary>
  /// Classe que define o mundo virtual
  /// Padrão Singleton
  /// </summary>
  /// 
  
  class Mundo
  {
    public static Mundo instance = null;
    private Retangulo objeto_1 = new Retangulo();
    private Retangulo objeto_2 = new Retangulo(new Ponto4D(100,100), new Ponto4D(200,200));
    private Circulo objeto_3 = new Circulo(new Ponto4D(150,150),100);
    
    private Mundo()
    {
      // adicionar os ptos para objeto 1
      objeto_1.AdicionaPto(new Ponto4D(100,100));
      objeto_1.AdicionaPto(new Ponto4D(200,200));
      objeto_1.atualizarBBox();
      // adicionar os ptos para objeto 2 pelo seu constructor
      objeto_2.atualizarBBox();
      // adicionar centro e raio para objeto 3 pelo seu constructor
      objeto_3.atualizarBBox();
    }

//TODO: pesquisar outras formas de implementar padrão singleton
// Preferência site de documentação do CSharp
// http://www.linhadecodigo.com.br/artigo/3397/singleton-padrao-de-projeto-com-microsoft-net-c-sharp.aspx
// 
    public static Mundo getInstance() {
      if (instance == null)
        instance = new Mundo();
      return instance;
    }

    public void Desenha()
    {
      // Console.WriteLine("[6] .. Desenha");

      SRU3D();

      objeto_1.Desenha();
      objeto_2.Desenha();
      objeto_3.Desenha();
    }
    //FIXME: não está considerando o NDC
    public void MouseMove(int x, int y)
    {
      //* Invertendo a coordenada y do espaço de tela para o espaço do mundo */
      objeto_1.Move(x, 600 - y);
    }

    public void OnKeyDown(OpenTK.Input.KeyboardKeyEventArgs e)
    {
      if (e.Key == Key.M)
        objeto_2.exibeMatriz();
      else
        if (e.Key == Key.P)
        objeto_2.exibePontos();
      else
        if (e.Key == Key.R)
        objeto_2.atribuirIdentidade();
      else
        if (e.Key == Key.Left)
        objeto_2.translacaoXYZ(-10, 0, 0);
      else
        if (e.Key == Key.Right)
        objeto_2.translacaoXYZ(10, 0, 0);
      else
        if (e.Key == Key.Up)
        objeto_2.translacaoXYZ(0, 10, 0);
      else
        if (e.Key == Key.Down)
        objeto_2.translacaoXYZ(0, -10, 0);
        else
        if (e.Key == Key.PageUp)
        objeto_2.escalaXYZ(2,2);
        else
        if (e.Key == Key.PageDown)
        objeto_2.escalaXYZ(0.5,0.5);
        else
        if (e.Key == Key.Home)
        objeto_2.escalaXYZPtoFixo(0.5,new Ponto4D(-150,-150));
        else
        if (e.Key == Key.End)
        objeto_2.escalaXYZPtoFixo(2,new Ponto4D(-150,-150));
        else
        if (e.Key == Key.Number1)
        objeto_2.rotacaoZ(10);
        else
        if (e.Key == Key.Number2)
        objeto_2.rotacaoZ(-10);
        if (e.Key == Key.Number3)
        objeto_2.rotacaoZPtoFixo(10,new Ponto4D(-150,-150));
        else
        if (e.Key == Key.Number4)
        objeto_2.rotacaoZPtoFixo(-10,new Ponto4D(-150,-150));
    }

    private void SRU3D()
    {
      // Console.WriteLine("[5] .. SRU3D");

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

}