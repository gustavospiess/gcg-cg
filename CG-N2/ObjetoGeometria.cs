/**
  Autor: Dalton Solano dos Reis
**/

using System;
using CG_Biblioteca;
using OpenTK.Graphics.OpenGL;

namespace gcgcg
{
  internal abstract class ObjetoGeometria : Objeto
  {

    public ObjetoGeometria(string rotulo, Objeto paiRef) : base(rotulo, paiRef) { }

    protected override void DesenharGeometria()
    {
      DesenharObjeto();
    }

    protected abstract void DesenharObjeto();
    
    public abstract Ponto4D PontosUltimo();

  }
}
