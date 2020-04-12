using System;
using OpenTK;
using OpenTK.Graphics.OpenGL;
using System.Collections.Generic;
using OpenTK.Input;
using CG_Biblioteca;

namespace gcgcg
{
  class Program
  {

    static void Main(string[] args)
    {
      Mundo mundo = Mundo.GetInstance(600, 600);
      mundo.Title = "CG-N2";

      Objeto eixo = new Eixos("Eixos", null);
      eixo.PrimitivaTamanho = 4;
      mundo.addObjeto(eixo);

      Enunciado4(mundo);

      mundo.Run(1.0 / 60.0);
    }

    static void Enunciado1(Mundo mundo) {
      Objeto circulo = new Circulo("A", null, new Ponto4D(0, 0), 100);
      circulo.PrimitivaTipo = PrimitiveType.Points;
      circulo.Cor = Color.Yellow;
      circulo.PrimitivaTamanho = 4;
      mundo.addObjeto(circulo);
    }

    static void Enunciado3(Mundo mundo) {
      Objeto circulo_superior = new Circulo("A", null, new Ponto4D(0, 100), 100);
      circulo_superior.PrimitivaTipo = PrimitiveType.Points;
      circulo_superior.Cor = Color.Black;
      circulo_superior.PrimitivaTamanho = 4;
      mundo.addObjeto(circulo_superior);

      Objeto circulo_direita = new Circulo("B", null, new Ponto4D(100, -100), 100);
      circulo_direita.PrimitivaTipo = PrimitiveType.Points;
      circulo_direita.Cor = Color.Black;
      circulo_direita.PrimitivaTamanho = 4;
      mundo.addObjeto(circulo_direita);

      Objeto circulo_esquerda = new Circulo("C", null, new Ponto4D(-100, -100), 100);
      circulo_esquerda.PrimitivaTipo = PrimitiveType.Points;
      circulo_esquerda.Cor = Color.Black;
      circulo_esquerda.PrimitivaTamanho = 4;
      mundo.addObjeto(circulo_esquerda);

      Objeto reta_direita = new SegReta("D", null, new Ponto4D(100, -100), new Ponto4D(0, 100));
      reta_direita.Cor = Color.LightBlue;
      reta_direita.PrimitivaTamanho = 4;
      mundo.addObjeto(reta_direita);

      Objeto reta_esquerda = new SegReta("D", null, new Ponto4D(-100, -100), new Ponto4D(0, 100));
      reta_esquerda.Cor = Color.LightBlue;
      reta_esquerda.PrimitivaTamanho = 4;
      mundo.addObjeto(reta_esquerda);

      Objeto reta_inferior = new SegReta("D", null, new Ponto4D(-100, -100), new Ponto4D(100, -100));
      reta_inferior.Cor = Color.LightBlue;
      reta_inferior.PrimitivaTamanho = 4;
      mundo.addObjeto(reta_inferior);
    }

    static void Enunciado4(Mundo mundo) {
      ObjetoGeometriaListPontos objeto_geometria = new ObjetoGeometriaListPontos("A", null);
      objeto_geometria.PontosAdicionar(new Ponto4D(200, 200));
      objeto_geometria.PontosAdicionar(new Ponto4D(-200, 200));
      objeto_geometria.PontosAdicionar(new Ponto4D(-200, -200));
      objeto_geometria.PontosAdicionar(new Ponto4D(200, -200));
      objeto_geometria.PrimitivaTipo = PrimitiveType.Points;
      objeto_geometria.Cor = Color.Black;
      objeto_geometria.PrimitivaTamanho = 4;
      mundo.addObjeto(objeto_geometria);
    }

  }
}
