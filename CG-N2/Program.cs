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
      Mundo window = Mundo.GetInstance(600, 600);
      window.Title = "CG-N2";

      window.addObjeto(new Eixos("Eixos", null));

      Objeto circulo = new Circulo("C", null, new Ponto4D(0, 0), 100);
      circulo.primitivaTipo = PrimitiveType.Lines;
      window.addObjeto(circulo);

      // window.addObjeto(new SegReta("B", null, new Ponto4D(0, 0), new Ponto4D(0, 250)))
      // window.addObjeto(new SegReta("B", null, new Ponto4D(0, 0), new Ponto4D(250, 0)))
      //
      // obj_Retangulo = new Retangulo("A", null, new Ponto4D(50, 50, 0), new Ponto4D(150, 150, 0));
      // objetosLista.Add(obj_Retangulo);
      // objetoSelecionado = obj_Retangulo;
      //
      // obj_SegReta = ;
      // objetosLista.Add(obj_SegReta);
      // objetoSelecionado = obj_SegReta;
      //
      // obj_Circulo = new Circulo("C", null, new Ponto4D(100, 300), 50);
      // objetosLista.Add(obj_Circulo);
      // objetoSelecionado = obj_Circulo;


      window.Run(1.0 / 60.0);
    }
  }
}
