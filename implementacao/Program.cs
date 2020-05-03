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

      double bb_len = 141.421356;
      Ponto4D origin = new Ponto4D(250, 250);

      Circulo area = new Circulo("area", null, origin, 200);
      area.BBox = new BBox(origin.X - bb_len, origin.Y - bb_len, 0, origin.X + bb_len, origin.Y + bb_len);
      area.BBox.ProcessarCentro();
      mundo.addObjeto(area);
      mundo.objetoSelecionado = area;
      Circulo botao = new Circulo("botao", null, new Ponto4D(0, 0), 50);
      botao.Posicao = origin;
      mundo.addObjeto(botao);

      mundo.Run(1.0 / 60.0);
    }
  }
}
