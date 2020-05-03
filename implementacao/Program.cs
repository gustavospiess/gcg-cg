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

      ObjetoCor objeto_geometria = new ObjetoCor("A", null);
      objeto_geometria.PontosAdicionar(new Ponto4D(200, 200), Color.Purple);
      objeto_geometria.PontosAdicionar(new Ponto4D(-200, 200), Color.Aqua);
      objeto_geometria.PontosAdicionar(new Ponto4D(-200, -200), Color.Yellow);
      objeto_geometria.PontosAdicionar(new Ponto4D(200, -200), Color.Black);
      objeto_geometria.PrimitivaTipo = PrimitiveType.Points;
      mundo.addObjeto(objeto_geometria);
      mundo.objetoSelecionado = objeto_geometria;

      mundo.Run(1.0 / 60.0);
    }
  }
}
