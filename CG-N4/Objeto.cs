/*
  Autor: Dalton Solano dos Reis
*/

using OpenTK.Graphics.OpenGL;
using System.Drawing;
using CG_Biblioteca;
using System;
using System.Collections.Generic;

namespace gcgcg
{
  internal class Objeto
  {
    protected List<Ponto4D> listaPto = new List<Ponto4D>();
    private bool exibeObjeto = true;
    private BBox bBox = new BBox();
    private bool exibeBBox = false;
    protected Transformacao4D matriz = new Transformacao4D();
    //TODO: por default ter o atributo do tipo point

    /// Matrizes temporarias que sempre sao inicializadas com matriz Identidade entao podem ser "static".
    private static Transformacao4D matrizTmpTranslacao = new Transformacao4D();
    private static Transformacao4D matrizTmpTranslacaoInversa = new Transformacao4D();
    private static Transformacao4D matrizTmpEscala = new Transformacao4D();
    private static Transformacao4D matrizTmpRotacao = new Transformacao4D();
    private static Transformacao4D matrizGlobal = new Transformacao4D();
    private char eixoRotacao = 'x';

    public void TrocaEixoRotacao(char eixo) => eixoRotacao = eixo;

    public Objeto()
    {
    }

    public virtual void Desenha()
    {
      //FIXME: ////// ATENCAO: chamar desenho dos filhos... 

      //FIXME: a BBox deve ser atualizada com as transformações do objeto.
      if (exibeBBox)
        bBox.desenhaBBox();
    }
    protected bool pegaExibeObjeto { get => exibeObjeto; }
    public void trocaExibeObjeto() => exibeObjeto = !exibeObjeto;
    public void trocaExibeBBox() => exibeBBox = !exibeBBox;

    public void atualizarBBox()
    {
      if (listaPto.Count > 0)
      {
        bBox.atribuirBBox(listaPto[0]);             // inicializa BBox
        for (int i = 1; i < listaPto.Count; i++)
        {
          bBox.atualizarBBox(listaPto[i]);
        }
        bBox.processarCentroBBox();
      }
    }
    public void exibeMatriz()
    {
      matriz.exibeMatriz();
    }
    public void exibePontos() => listaPto.ForEach(delegate (Ponto4D pto)
    {
      Console.WriteLine("P[" + pto.X + "," + pto.Y + "," + pto.Z + "," + pto.W + "]");
    });
    public void atribuirIdentidade()
    {
      matriz.atribuirIdentidade();
    }
    public void translacaoXYZ(double tx, double ty, double tz)
    {
      Transformacao4D matrizTranslate = new Transformacao4D();
      matrizTranslate.atribuirTranslacao(tx, ty, tz);
      matriz = matrizTranslate.transformMatrix(matriz);
    }
    public void escalaXYZ(double Sx, double Sy, double Sz)
    {
      Transformacao4D matrizScale = new Transformacao4D();
      matrizScale.atribuirEscala(Sx, Sy, Sz);
      matriz = matrizScale.transformMatrix(matriz);
    }

    public void escalaXYZPtoFixo(double escala, Ponto4D ptoFixo)
    {
      matrizGlobal.atribuirIdentidade();

      matrizTmpTranslacao.atribuirTranslacao(ptoFixo.X, ptoFixo.Y, ptoFixo.Z);
      matrizGlobal = matrizTmpTranslacao.transformMatrix(matrizGlobal);

      matrizTmpEscala.atribuirEscala(escala, escala, escala);
      matrizGlobal = matrizTmpEscala.transformMatrix(matrizGlobal);

      ptoFixo.inverterSinal();
      matrizTmpTranslacaoInversa.atribuirTranslacao(ptoFixo.X, ptoFixo.Y, ptoFixo.Z);
      matrizGlobal = matrizTmpTranslacaoInversa.transformMatrix(matrizGlobal);

      matriz = matriz.transformMatrix(matrizGlobal);
    }
    public void rotacaoEixo(double angulo)
    {
      switch (eixoRotacao)
      {
        case 'x':
          matrizTmpRotacao.atribuirRotacaoX(Transformacao4D.DEG_TO_RAD * angulo);
          break;
        case 'y':
          matrizTmpRotacao.atribuirRotacaoY(Transformacao4D.DEG_TO_RAD * angulo);
          break;
        case 'z':
          matrizTmpRotacao.atribuirRotacaoZ(Transformacao4D.DEG_TO_RAD * angulo);
          break;
        default:
          Console.WriteLine("ERRO: eixo de rotação não definido.");
          break;
      }
      matriz = matrizTmpRotacao.transformMatrix(matriz);
    }
    public void rotacaoEixoPtoFixo(double angulo, Ponto4D ptoFixo)
    {
      matrizGlobal.atribuirIdentidade();

      matrizTmpTranslacao.atribuirTranslacao(ptoFixo.X, ptoFixo.Y, ptoFixo.Z);
      matrizGlobal = matrizTmpTranslacao.transformMatrix(matrizGlobal);

      rotacaoEixo(angulo);
      matrizGlobal = matrizTmpRotacao.transformMatrix(matrizGlobal);

      ptoFixo.inverterSinal();
      matrizTmpTranslacaoInversa.atribuirTranslacao(ptoFixo.X, ptoFixo.Y, ptoFixo.Z);
      matrizGlobal = matrizTmpTranslacaoInversa.transformMatrix(matrizGlobal);

      matriz = matriz.transformMatrix(matrizGlobal);
    }
  }
}