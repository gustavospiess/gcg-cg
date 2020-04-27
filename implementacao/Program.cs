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

      Objeto circulo = new Circulo("A", null, new Ponto4D(0, 0), 100);
      circulo.PrimitivaTipo = PrimitiveType.Points;
      circulo.Cor = Color.Yellow;
      mundo.addObjeto(circulo);

      mundo.Run(1.0 / 60.0);
    }
  }
}
