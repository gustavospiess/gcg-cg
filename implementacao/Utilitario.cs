/**
  Autor: Dalton Solano dos Reis
**/

using System;
using CG_Biblioteca;
using System.Collections.Generic;
using System.Collections.Generic;

namespace gcgcg
{
  public abstract class Utilitario
  {
    public static void AjudaTeclado()
    {
      // N3-Exe2: usar o arquivo docs/umlClasses.wsd
      // N3-Exe3: usar o arquivo bin/documentação.XML -> ver exemplo CG_Biblioteca/bin/documentação.XML

      Console.WriteLine(" --- Ajuda / Teclas: ");
      Console.WriteLine(" [  H     ] mostra está ajuda. ");
      Console.WriteLine(" [Escape  ] sair. ");
      Console.WriteLine(" [  E     ] N3-Exe04: listas polígonos e vértices. ");
      Console.WriteLine(" [  O     ] N3-Exe09: exibe bBox do polígono selecionado. ");
      Console.WriteLine(" [Enter   ] N3-Exe09: termina adição e mover de pontos, desseleciona polígono. ");
      Console.WriteLine(" [Espaço  ] N3-Exe06: adiciona vértice ao polígono. ");
      Console.WriteLine(" [  A     ] N3-Exe09: seleção do Polígono. ");
      Console.WriteLine(" [  M     ]         : exibe matriz de transformação do polígono selecionado. ");
      Console.WriteLine(" [  P     ]         : exibe os vértices do polígono selecionado. ");
      Console.WriteLine(" [  I     ]         : aplica a matriz Identidade no polígono selecionado. ");
      Console.WriteLine(" [Left    ] N3-Exe10: move o polígono selecionado para eixo X positivo. ");
      Console.WriteLine(" [Right   ] N3-Exe10: move o polígono selecionado para eixo X negativo. ");
      Console.WriteLine(" [Up      ] N3-Exe10: move o polígono selecionado para eixo Y positivo. ");
      Console.WriteLine(" [Down    ] N3-Exe10: move o polígono selecionado para eixo Y negativo. ");
      Console.WriteLine(" [Up      ]         : move o polígono selecionado para eixo Z positivo. ");
      Console.WriteLine(" [Down    ]         : move o polígono selecionado para eixo Z negativo. ");
      Console.WriteLine(" [PageUp  ]         : reduz o polígono selecionado em relação a origem. ");
      Console.WriteLine(" [PageDown]         : amplia o polígono selecionado em relação a origem. ");
      Console.WriteLine(" [Home    ] N3-Exe11: reduz o polígono selecionado em relação ao centro da bBox. ");
      Console.WriteLine(" [End     ] N3-Exe11: amplia o polígono selecionado em relação ao centro da bBox. ");
      Console.WriteLine(" [  1     ]         : rotação anti-horária do polígono selecionado em relação a origem. ");
      Console.WriteLine(" [  2     ]         : rotação horária do polígono selecionado em relação a origem. ");
      Console.WriteLine(" [  3     ] N3-Exe12: rotação anti-horária do polígono selecionado em relação ao centro da bBox. ");
      Console.WriteLine(" [  4     ] N3-Exe12: rotação horária do polígono selecionado em relação ao centro da bBox. ");
      Console.WriteLine(" [  R     ] N3-Exe08: atribui a cor vermelha ao polígono selecionado. ");
      Console.WriteLine(" [  G     ] N3-Exe08: atribui a cor verde ao polígono selecionado. ");
      Console.WriteLine(" [  B     ] N3-Exe08: atribui a cor azul ao polígono selecionado. ");
      Console.WriteLine(" [  S     ] N3-Exe07: alterna entre aberto e fechado o polígono selecionado. ");
      Console.WriteLine(" [  D     ] N3-Exe05: remove o vértice do polígono selecionado que estiver mais perto do mouse. ");
      Console.WriteLine(" [  V     ] N3-Exe05: move o vértice do polígono selecionado que estiver mais perto do mouse. ");
      Console.WriteLine(" [  C     ] N3-Exe04: remove o polígono selecionado. ");
      Console.WriteLine(" [  X     ]         : rotação entorno do eixo X. ");
      Console.WriteLine(" [  Y     ]         : rotação entorno do eixo Y. ");
      Console.WriteLine(" [  Z     ]         : rotação entorno do eixo Z. ");
      Console.WriteLine("  --- ");
      Console.WriteLine(" Se tiver objeto selecionado adiciona novo objeto como filho dele. ");
      Console.WriteLine(" Senão tiver objeto selecionado adiciona novo objeto no mundo. ");
    }

    public static bool insideBBox(Ponto4D pto, BBox bb)
    {
      if (pto.X > bb.obterMaiorX)
      {
        return false; // Fora da BBox para a direita
      }
      else if (pto.Y > bb.obterMaiorY)
      {
        return false; // Fora da BBox para cima
      }
      else if (pto.X < bb.obterMenorX)
      {
        return false; // Fora da BBox para a esquerda
      }
      else if (pto.Y < bb.obterMenorY)
      {
        return false; // Fora da BBox para baixo
      }
      return true;
    }

    public static bool insidePol(Ponto4D pto, List<Ponto4D> polig)
    {
      return insidePol(pto, polig, true);
    }

    public static bool insidePol(Ponto4D pto, List<Ponto4D> polig, bool def)
    {
      int parity = 0;
      for (int i = 0; i < polig.Count; i++)
      {
        Ponto4D pto1 = polig[i];
        Ponto4D pto2 = polig[(i+1)%polig.Count];

        if (pto == pto1 || pto == pto2)
        {
          //Ponto sobre ponto 1 ou 2
          return def;
        }

        if (pto1.Y == pto2.Y)
        {
          if (pto.Y == pto1.Y && pto.X > Math.Min(pto1.X, pto2.X) && pto.X < Math.Max(pto1.X, pto2.X))
          {
            //Ponto sobre a linha entre pto 1 e pto 2
            return def;
          }
          continue;
        }

        //porcentagem do caminho entre pto1 e pto2 que a linha orizontal de pto cruza
        double t = (pto.Y - pto1.Y)/(pto2.Y - pto1.Y);
        //Se porcentagem menor que zero, passa por baixo
        //Se porcentagem igual a zero, passa por pto1
        //Se porcentagem maior que um, passa por cima
        //Se porcentagem igual a um, passa por pto2
        bool isIntersec = t >= 0 && t <= 1;
        if (isIntersec)
        {
          Ponto4D interPto = new Ponto4D(pto1.X+t*(pto2.X-pto1.X), pto.Y);
          if (interPto.X == pto.X)
          {
            //Ponto sobre a linha entre pto 1 e pto 2
            return def;
          }
          if (interPto.X > pto.X && interPto.Y > Math.Min(pto1.Y, pto2.Y) && interPto.Y < Math.Max(pto1.Y, pto2.Y))
          {
            parity++;
          }
        }
      }
      return parity%2==1;
    }

  }
}
