/*
  Autor: Dalton Solano dos Reis
 */

using OpenTK.Graphics.OpenGL;
using CG_Biblioteca;

namespace gcgcg
{
  //TODO: melhorar o exemplo de uso de herança (ver exemplo em: https://docs.microsoft.com/pt-br/dotnet/csharp/programming-guide/classes-and-structs/inheritance)
  internal class Circulo : Objeto
  {
    private double raio;
    private Ponto4D ptoCentro = new Ponto4D();

//TODO: usar atributo primitiva no método Desenha()
    private PrimitiveType primitiva = PrimitiveType.LineLoop;

    public Circulo(Ponto4D ptoCentro, double raio) {
      this.ptoCentro = ptoCentro;
      this.raio = raio;
      geraPtosCirculo();
    }
    private void geraPtosCirculo() {

      Matematica mat = new Matematica();
      Ponto4D pto = new Ponto4D();
      for (int angulo = 0; angulo < 360; angulo+=10) {
        pto = mat.ptoCirculo(angulo,raio);
        pto += ptoCentro;
        listaPto.Add(pto);
      }

    }
    public PrimitiveType Primitiva { get => primitiva; set => primitiva = value; }
  }
}