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

      ObjetoSpline sp = new ObjetoSpline("Spline", null);
      sp.PontosAdicionar(new Ponto4D(-100, -100));
      sp.PontosAdicionar(new Ponto4D(-100, 100));
      sp.PontosAdicionar(new Ponto4D(100, 100));
      sp.PontosAdicionar(new Ponto4D(100, -100));

      mundo.addObjeto(sp);
      mundo.objetoSelecionado = sp;

      mundo.Run(1.0 / 60.0);
    }
  }
}
