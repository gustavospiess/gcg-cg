/*
  Autor: Dalton Solano dos Reis
 */

using CG_Biblioteca;

namespace gcgcg
{
  //TODO: melhorar o exemplo de uso de herança (ver exemplo em: https://docs.microsoft.com/pt-br/dotnet/csharp/programming-guide/classes-and-structs/inheritance)
  
  internal class Retangulo : Objeto
  {
        //TODO: inicailizar como atributo linestrip

    public Retangulo()
    {
    }
    public Retangulo(Ponto4D pto1, Ponto4D pto2) {
      AdicionaPto(pto1);
      AdicionaPto(pto2);
    }

  }
}