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
    }
  }
}
