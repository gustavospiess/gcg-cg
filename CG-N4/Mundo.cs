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
    private Cubo objeto1 = new Cubo();
    private Cubo objeto2 = new Cubo();

    private Mundo()
    {
      objeto1.atualizarBBox();
      objeto2.atualizarBBox();
    }

    public static Mundo getInstance()
    {
      if (instance == null)
        instance = new Mundo();
      return instance;
    }

    public void Desenha()
    {
      SRU3D();
      objeto1.Desenha();
      // objeto2.Desenha();
    }
    public void MouseMove(int x, int y)
    {
    }

    public void OnKeyDown(OpenTK.Input.KeyboardKeyEventArgs e)
    {
      if (e.Key == Key.Number1)
        objeto1.exibeMatriz();
      else
        if (e.Key == Key.Number2)
        objeto1.exibePontos();
      else
        if (e.Key == Key.Number3)
        objeto1.atribuirIdentidade();
      else
        if (e.Key == Key.Left)
        objeto1.translacaoXYZ(-1, 0, 0);
      else
        if (e.Key == Key.Right)
        objeto1.translacaoXYZ(1, 0, 0);
      else
        if (e.Key == Key.Number9)
        objeto1.translacaoXYZ(0, 1, 0);
      else
        if (e.Key == Key.Number0)
        objeto1.translacaoXYZ(0, -1, 0);
      else
        if (e.Key == Key.Up)
        objeto1.translacaoXYZ(0, 0, 1);
      else
        if (e.Key == Key.Down)
        objeto1.translacaoXYZ(0, 0,-1);
      else
        if (e.Key == Key.PageUp)
        objeto1.escalaXYZ(2, 2, 2);
      else
        if (e.Key == Key.PageDown)
        objeto1.escalaXYZ(0.5, 0.5, 0.5);
      else
        if (e.Key == Key.Home)
        objeto1.escalaXYZPtoFixo(0.5, new Ponto4D(0, 0));
      else
        if (e.Key == Key.End)
        objeto1.escalaXYZPtoFixo(2, new Ponto4D(0, 0));
      else
        if (e.Key == Key.Number4)
        objeto1.rotacaoEixo(10);
      else
        if (e.Key == Key.Number5)
        objeto1.rotacaoEixo(-10);
//FIXME: rotação para pto fixo não funciona, acho que deve receber o valor do centro da BBox
// estranho é que na escala funciona com pto(0,0,0) como ptoFixo.        
      if (e.Key == Key.Number6)
        objeto1.rotacaoEixoPtoFixo(10, new Ponto4D(0, 0));
      else
//FIXME: rotação para pto fixo não funciona, acho que deve receber o valor do centro da BBox
// estranho é que na escala funciona com pto(0,0,0) como ptoFixo.        
      if (e.Key == Key.Number7)
        objeto1.rotacaoEixoPtoFixo(-10, new Ponto4D(0, 0));
      else
      if (e.Key == Key.X)
        objeto1.TrocaEixoRotacao('x');
      else
      if (e.Key == Key.Y)
        objeto1.TrocaEixoRotacao('y');
      else
      if (e.Key == Key.Z)
        objeto1.TrocaEixoRotacao('z');
      else
      if (e.Key == Key.O)
        objeto1.trocaExibeObjeto();
      else
      if (e.Key == Key.B)
        objeto1.trocaExibeBBox();
      else
      if (e.Key == Key.V)
        objeto1.trocaExibeVetorNormal();
    }

    private void SRU3D()
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

}