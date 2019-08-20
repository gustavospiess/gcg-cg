using OpenTK.Graphics.OpenGL;
using System.Collections.Generic;
using CG_Biblioteca;

namespace gcgcg
{
  internal abstract class Objeto
  {
    private string rotulo;
    private PrimitiveType primitivaTipo = PrimitiveType.LineLoop;
    private float primitivaTamanho = 2;
    private BBox bBox = new BBox();
    private Transformacao4D matriz = new Transformacao4D();
    private List<Objeto> objetosLista = new List<Objeto>();


    public Objeto(string rotulo)
    {
      this.rotulo = rotulo;
    }

    protected PrimitiveType PrimitivaTipo { get => primitivaTipo; set => primitivaTipo = value; }
    protected float PrimitivaTamanho { get => primitivaTamanho; set => primitivaTamanho = value; }

    public void Desenhar()
    {

      GL.PushMatrix();
      GL.MultMatrix(matriz.GetDate());
      DesenharAramado();
      for (var i = 0; i < objetosLista.Count; i++)
      {
        objetosLista[i].Desenhar();
      }
      GL.PopMatrix();
      //TODO: desenhar sua bBox
      // bBox.desenhaBBox();
    }
    protected abstract void DesenharAramado();
    public void FilhoAdicionar(Objeto filho)
    {
      this.objetosLista.Add(filho);
    }
    public void FilhoRemover(Objeto filho)
    {
      this.objetosLista.Remove(filho);
    }
    public void TransladarXY(double tx, double ty)
    {
      Transformacao4D matrizTranslate = new Transformacao4D();
      matrizTranslate.atribuirTranslacao(tx, ty, 0);
      matriz = matrizTranslate.transformMatrix(matriz);
    }

  }
}