/*
  Autor: Dalton Solano dos Reis
 */
using OpenTK.Graphics.OpenGL;
using CG_Biblioteca;

namespace gcgcg
{
  internal class Cubo : Objeto
  {
    private bool exibeVetorNormal = false;
    public Cubo()
    {
      listaPto.Add(new Ponto4D(-1, -1, 1)); // PtoA listaPto[0]
      listaPto.Add(new Ponto4D(1, -1, 1)); // PtoB listaPto[1]
      listaPto.Add(new Ponto4D(1, 1, 1)); // PtoC listaPto[2]
      listaPto.Add(new Ponto4D(-1, 1, 1)); // PtoD listaPto[3]
      listaPto.Add(new Ponto4D(-1, -1, -1)); // PtoE listaPto[4]
      listaPto.Add(new Ponto4D(1, -1, -1)); // PtoF listaPto[5]
      listaPto.Add(new Ponto4D(1, 1, -1)); // PtoG listaPto[6]
      listaPto.Add(new Ponto4D(-1, 1, -1)); // PtoH listaPto[7]
      atualizarBBox();
    }

    public new void Desenha()
    {
      base.Desenha();

      if (base.pegaExibeObjeto)
      {
        GL.PushMatrix();
        GL.MultMatrix(matriz.GetDate());

        GL.Begin(PrimitiveType.Quads);
        // // Face da frente
        GL.Color3(1.0, 0.0, 0.0);
        GL.Normal3(0, 0, 1);
        GL.Vertex3(listaPto[0].X, listaPto[0].Y, listaPto[0].Z);    // PtoA
        GL.Vertex3(listaPto[1].X, listaPto[1].Y, listaPto[1].Z);    // PtoB
        GL.Vertex3(listaPto[2].X, listaPto[2].Y, listaPto[2].Z);    // PtoC
        GL.Vertex3(listaPto[3].X, listaPto[3].Y, listaPto[3].Z);    // PtoD
        // Face do fundo
        GL.Color3(0.0, 1.0, 0.0);
        // GL.Normal3(0, 0, -1);
        GL.Vertex3(listaPto[4].X, listaPto[4].Y, listaPto[4].Z);    // PtoE
        GL.Vertex3(listaPto[7].X, listaPto[7].Y, listaPto[7].Z);    // PtoH
        GL.Vertex3(listaPto[6].X, listaPto[6].Y, listaPto[6].Z);    // PtoG
        GL.Vertex3(listaPto[5].X, listaPto[5].Y, listaPto[5].Z);    // PtoF
        // Face de cima
        GL.Color3(0.0, 0.0, 1.0);
        GL.Normal3(0, 1, 0);
        GL.Vertex3(listaPto[3].X, listaPto[3].Y, listaPto[3].Z);    // PtoD
        GL.Vertex3(listaPto[2].X, listaPto[2].Y, listaPto[2].Z);    // PtoC
        GL.Vertex3(listaPto[6].X, listaPto[6].Y, listaPto[6].Z);    // PtoG
        GL.Vertex3(listaPto[7].X, listaPto[7].Y, listaPto[7].Z);    // PtoH
        // Face de baixo
        GL.Color3(1.0, 1.0, 0.0);
        GL.Normal3(0, -1, 0);
        GL.Vertex3(listaPto[0].X, listaPto[0].Y, listaPto[0].Z);    // PtoA
        GL.Vertex3(listaPto[4].X, listaPto[4].Y, listaPto[4].Z);    // PtoE
        GL.Vertex3(listaPto[5].X, listaPto[5].Y, listaPto[5].Z);    // PtoF
        GL.Vertex3(listaPto[1].X, listaPto[1].Y, listaPto[1].Z);    // PtoB
        // Face da direita
        GL.Color3(0.0, 1.0, 1.0);
        GL.Normal3(1, 0, 0);
        GL.Vertex3(listaPto[1].X, listaPto[1].Y, listaPto[1].Z);    // PtoB
        GL.Vertex3(listaPto[5].X, listaPto[5].Y, listaPto[5].Z);    // PtoF
        GL.Vertex3(listaPto[6].X, listaPto[6].Y, listaPto[6].Z);    // PtoG
        GL.Vertex3(listaPto[2].X, listaPto[2].Y, listaPto[2].Z);    // PtoC
        // Face da esquerda
        GL.Color3(1.0, 0.0, 1.0);
        GL.Normal3(-1, 0, 0);
        GL.Vertex3(listaPto[0].X, listaPto[0].Y, listaPto[0].Z);    // PtoA
        GL.Vertex3(listaPto[3].X, listaPto[3].Y, listaPto[3].Z);    // PtoD
        GL.Vertex3(listaPto[7].X, listaPto[7].Y, listaPto[7].Z);    // PtoH
        GL.Vertex3(listaPto[4].X, listaPto[4].Y, listaPto[4].Z);    // PtoE
        GL.End();
      }

      if (exibeVetorNormal)
        ajudaExibirVetorNormal();

      GL.PopMatrix();
    }
    public void ajudaExibirVetorNormal()
    {
      GL.LineWidth(3);
      GL.Color3(1.0, 1.0, 1.0);
      GL.Begin(PrimitiveType.Lines);
      // Face da frente
      GL.Vertex3(0, 0, 0); GL.Vertex3(0, 0, 5);
      // Face do fundo
      GL.Vertex3(0, 0, 0); GL.Vertex3(0, 0, -5);
      // Face de cima
      GL.Vertex3(0, 0, 0); GL.Vertex3(0, 5, 0);
      // Face de baixo
      GL.Vertex3(0, 0, 0); GL.Vertex3(0, -5, 0);
      // Face da direita
      GL.Vertex3(0, 0, 0); GL.Vertex3(5, 0, 0);
      // Face da esquerda
      GL.Vertex3(0, 0, 0); GL.Vertex3(-5, 0, 0);
      GL.End();
    }

    public void trocaExibeVetorNormal() => exibeVetorNormal = !exibeVetorNormal;

  }
}