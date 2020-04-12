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

    private PrimitiveType primitivaTipo = PrimitiveType.LineLoop;
    public PrimitiveType PrimitivaTipo { get => primitivaTipo; set => primitivaTipo = value; }

    private float primitivaTamanho = 2;
    public float PrimitivaTamanho { get => primitivaTamanho; set => this.setTamanho(value); }
    private void setTamanho(float tamanho)
    {
      primitivaTamanho = tamanho;
      for (var i = 0; i < objetosLista.Count; i++)
      {
        objetosLista[i].PrimitivaTamanho = tamanho;
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
