/**
  Autor: Gustavo Spiess
**/

using OpenTK;
using OpenTK.Graphics.OpenGL;
using CG_Biblioteca;

namespace gcgcg
{
  internal class Eixos : Objeto
  {
    public Eixos(string rotulo, Objeto paiRef) : base(rotulo, paiRef)
    {
      Ponto4D origin = new Ponto4D(0, 0);

      Objeto eixoX = new SegReta(rotulo + "(X)", this, origin, new Ponto4D(0, 200));
      eixoX.Cor = Color.Green;
      this.FilhoAdicionar(eixoX);
      Objeto eixoY = new SegReta(rotulo + "(X)", this, origin, new Ponto4D(200, 0));
      eixoY.Cor = Color.Red;
      this.FilhoAdicionar(eixoY);
    }

    protected override void DesenharGeometria()
    {
      //TODO remover a necessidade desse método vazio
    }

  }
}
