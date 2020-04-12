/**
  Autor: Gustavo Spiess
**/

using OpenTK.Graphics.OpenGL;
using CG_Biblioteca;

namespace gcgcg
{
  internal class SegReta : ObjetoGeometriaListPontos
  {
    public SegReta(string rotulo, Objeto paiRef, Ponto4D ptoOrig, Ponto4D ptoDest) : base(rotulo, paiRef)
    {
      base.PontosAdicionar(ptoOrig);
      base.PontosAdicionar(ptoDest);
    }

  }
}
