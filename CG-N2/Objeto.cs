/**
  Autor: Dalton Solano dos Reis
**/

using OpenTK;
using OpenTK.Graphics.OpenGL;
using System.Collections.Generic;
using CG_Biblioteca;

namespace gcgcg
{
  internal abstract class Objeto
  {
    protected string rotulo;

    protected double angulo = 0;
    public double Angulo { get => angulo; set => angulo = value; }

    protected Ponto4D posicao = new Ponto4D(0, 0);
    public Ponto4D Posicao { get => posicao; set => posicao = value; }

    private PrimitiveType primitivaTipo = PrimitiveType.LineLoop;
    public PrimitiveType PrimitivaTipo { get => primitivaTipo; set => primitivaTipo = value; }

    private float primitivaTamanho = 1;
    public float PrimitivaTamanho { get => primitivaTamanho; set => setTamanho(value); }
    private void setTamanho(float tamanho)
    {
      if ( tamanho > 0 )
      {
        primitivaTamanho = tamanho;
        for (var i = 0; i < objetosLista.Count; i++)
        {
          objetosLista[i].PrimitivaLargura = tamanho;
        }
      }
    }

    private float primitivaLargura = 4;
    public float PrimitivaLargura { get => primitivaLargura; set => this.setLargura(value); }
    private void setLargura(float largura)
    {
      if ( largura > 0 )
      {
        primitivaLargura = largura;
        for (var i = 0; i < objetosLista.Count; i++)
        {
          objetosLista[i].PrimitivaLargura = largura;
        }
      }
    }

    private Color cor = Color.Black;
    public Color Cor { get => cor; set => cor = value; }

    private BBox bBox = new BBox();
    public BBox BBox { get => bBox; set => bBox = value; }

    private List<Objeto> objetosLista = new List<Objeto>();

    public Objeto(string rotulo, Objeto paiRef)
    {
      this.rotulo = rotulo;
    }

    public void Desenhar()
    {
      DesenharGeometria();
      for (var i = 0; i < objetosLista.Count; i++)
      {
        objetosLista[i].Desenhar();
      }
    }

    protected abstract void DesenharGeometria();

    public void FilhoAdicionar(Objeto filho)
    {
      this.objetosLista.Add(filho);
    }

    public void FilhoRemover(Objeto filho)
    {
      this.objetosLista.Remove(filho);
    }

  }
}
