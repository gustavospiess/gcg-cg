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
      mundo.addObjeto(eixo);

      Objeto circulo_superior = new Circulo("A", null, new Ponto4D(0, 100), 100);
      circulo_superior.PrimitivaTipo = PrimitiveType.Points;
      mundo.addObjeto(circulo_superior);

      Objeto circulo_direita = new Circulo("B", null, new Ponto4D(100, -100), 100);
      circulo_direita.PrimitivaTipo = PrimitiveType.Points;
      mundo.addObjeto(circulo_direita);

      Objeto circulo_esquerda = new Circulo("C", null, new Ponto4D(-100, -100), 100);
      circulo_esquerda.PrimitivaTipo = PrimitiveType.Points;
      mundo.addObjeto(circulo_esquerda);

      Objeto reta_direita = new SegReta("D", null, new Ponto4D(100, -100), new Ponto4D(0, 100));
      reta_direita.Cor = Color.LightBlue;
      mundo.addObjeto(reta_direita);

      Objeto reta_esquerda = new SegReta("D", null, new Ponto4D(-100, -100), new Ponto4D(0, 100));
      reta_esquerda.Cor = Color.LightBlue;
      mundo.addObjeto(reta_esquerda);

      Objeto reta_inferior = new SegReta("D", null, new Ponto4D(-100, -100), new Ponto4D(100, -100));
      reta_inferior.Cor = Color.LightBlue;
      mundo.addObjeto(reta_inferior);

      mundo.Run(1.0 / 60.0);
    }
  }
}
