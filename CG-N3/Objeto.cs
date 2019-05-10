/*
  Autor: Dalton Solano dos Reis
*/

using OpenTK.Graphics.OpenGL;
using System.Drawing;
using CG_Biblioteca;
using System;

namespace gcgcg
{
  internal class Objeto
  {
    private Ponto4D[] listaPto = {
      new Ponto4D(100, 100),new Ponto4D(200, 200) };
    private BBox bBox = new BBox();
    private Transformacao4D matriz = new Transformacao4D();

    /// Matrizes temporarias que sempre sao inicializadas com matriz Identidade entao podem ser "static".
    private static Transformacao4D matrizTmpTranslacao = new Transformacao4D();
    private static Transformacao4D matrizTmpTranslacaoInversa = new Transformacao4D();
    private static Transformacao4D matrizTmpEscala = new Transformacao4D();
    private static Transformacao4D matrizGlobal = new Transformacao4D();

    public Objeto()
    {
      atualizarBBox();
    }
    public void Desenha()
    {
      GL.LineWidth(2);
      GL.Color3(Color.Cyan);

      GL.PushMatrix();
      GL.MultMatrix(matriz.GetDate());

      GL.Begin(PrimitiveType.Lines);
      GL.Vertex2(listaPto[0].X, listaPto[0].Y);
      GL.Vertex2(listaPto[1].X, listaPto[1].Y);
      GL.End();

      //////////// ATENCAO: chamar desenho dos filhos... 

      GL.PopMatrix();

      bBox.desenhaBBox();
    }
    private void atualizarBBox()
    {
      bBox.atribuirBBox(listaPto[0]);
      bBox.atualizarBBox(listaPto[1]);
      bBox.processarCentroBBox();
    }
    public void Move(int x, int y)
    {
      listaPto[1].X = x;
      listaPto[1].Y = y;
      atualizarBBox();
      // Console.WriteLine(" ..x: " + x);
      // Console.WriteLine(" ..y: " + y);
    }
    public void exibeMatriz()
    {
      matriz.exibeMatriz();
    }
    public void exibePontos()
    {
      Console.WriteLine("P0[" + listaPto[0].X + "," + listaPto[0].Y + "," + listaPto[0].Z + "," + listaPto[0].W + "]");
      Console.WriteLine("P1[" + listaPto[1].X + "," + listaPto[1].Y + "," + listaPto[1].Z + "," + listaPto[1].W + "]");
    }
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
    public void escalaXYZ(double Sx, double Sy)
    {
      Transformacao4D matrizScale = new Transformacao4D();
      matrizScale.atribuirEscala(Sx, Sy, 1.0);
      matriz = matrizScale.transformMatrix(matriz);
    }

    public void escalaXYZPtoFixo(double escala, Ponto4D ptoFixo)
    {
      matrizGlobal.atribuirIdentidade();

      matrizTmpTranslacao.atribuirTranslacao(ptoFixo.X, ptoFixo.Y, ptoFixo.Z);
      matrizGlobal = matrizTmpTranslacao.transformMatrix(matrizGlobal);

      matrizTmpEscala.atribuirEscala(escala, escala, 1.0);
      matrizGlobal = matrizTmpEscala.transformMatrix(matrizGlobal);

      ptoFixo.inverterSinal();
      matrizTmpTranslacaoInversa.atribuirTranslacao(ptoFixo.X, ptoFixo.Y, ptoFixo.Z);
      matrizGlobal = matrizTmpTranslacaoInversa.transformMatrix(matrizGlobal);

      matriz = matriz.transformMatrix(matrizGlobal);
    }
    public void rotacaoZPtoFixo(double angulo, Ponto4D ptoFixo)
    {
      matrizGlobal.atribuirIdentidade();

      matrizTmpTranslacao.atribuirTranslacao(ptoFixo.X, ptoFixo.Y, ptoFixo.Z);
      matrizGlobal = matrizTmpTranslacao.transformMatrix(matrizGlobal);

      matrizTmpEscala.atribuirRotacaoZ(Transformacao4D.DEG_TO_RAD * angulo);
      matrizGlobal = matrizTmpEscala.transformMatrix(matrizGlobal);

      ptoFixo.inverterSinal();
      matrizTmpTranslacaoInversa.atribuirTranslacao(ptoFixo.X, ptoFixo.Y, ptoFixo.Z);
      matrizGlobal = matrizTmpTranslacaoInversa.transformMatrix(matrizGlobal);

      matriz = matriz.transformMatrix(matrizGlobal);
    }


  }
}