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

    public Objeto(string rotulo)
    {
      this.rotulo = rotulo;
      this.trasnformacao = new Transformacao4D();
    }

    protected string rotulo;

    // private PrimitiveType primitivaTipo = PrimitiveType.LineLoop;
    // public PrimitiveType PrimitivaTipo { get => primitivaTipo; set => primitivaTipo = value; }
    
    private bool selecionado;
    public bool Selecionado { get => selecionado; set => selecionado = value; }

    private Color cor = Color.Black;
    public Color Cor { get => cor; set => cor = value; }

    private Transformacao4D trasnformacao;
    public Transformacao4D Transformacao { get => trasnformacao; set => trasnformacao = value; }

    public abstract void Desenhar();
    public abstract BBox bbox();

  }
}
