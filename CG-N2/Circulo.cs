/**
  Autor: Gustavo Spiess
**/

using OpenTK.Graphics.OpenGL;
using CG_Biblioteca;

namespace gcgcg
{
  internal class Circulo : ObjetoGeometriaListPontos
  {
    public Circulo(string rotulo, Objeto paiRef, Ponto4D ptoOrig, double raio) : base(rotulo, paiRef)
    {
      for (int i = 0; i < 72; i++) 
      {
        base.PontosAdicionar(Matematica.GerarPtosCirculo(i*360/72, raio) + ptoOrig);
      }
    }
  }
}
