/*
  Autor: Dalton Solano dos Reis
 */

using CG_Biblioteca;

namespace gcgcg
{
  //TODO: melhorar o exemplo de uso de herança (ver exemplo em: https://docs.microsoft.com/pt-br/dotnet/csharp/programming-guide/classes-and-structs/inheritance)
  //FIXME: não está desenahando certo o círculo
  internal class Circulo : Objeto
  {
    private double raio;
    private Ponto4D ptoCentro = new Ponto4D();
    //TODO: inicailizar como atributo linestrip

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
  }
}