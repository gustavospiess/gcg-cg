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

      ObjetoGeometria palito = new SegReta("D", null, new Ponto4D(0, 0), new Ponto4D(100, 0));
      palito.Angulo = 45;
      mundo.addObjeto(palito);
      mundo.objetoSelecionado = palito;

      mundo.Run(1.0 / 60.0);
    }
  }
}
