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
    }

    //TODO: entender o uso da keyword new ... e replicar para os outros projetos
    new public void Desenha()
    {
      GL.Begin(PrimitiveType.Quads);
      // Face da frente
      GL.Color3(1.0, 0.0, 0.0);
      GL.Normal3(0, 0, 1);
      GL.Vertex3(-1.0f, -1.0f, 1.0f);
      GL.Vertex3(1.0f, -1.0f, 1.0f);
      GL.Vertex3(1.0f, 1.0f, 1.0f);
      GL.Vertex3(-1.0f, 1.0f, 1.0f);
      // Face do fundo
      GL.Color3(0.0, 1.0, 0.0);
      GL.Normal3(0, 0, -1);
      GL.Vertex3(-1.0f, -1.0f, -1.0f);
      GL.Vertex3(-1.0f, 1.0f, -1.0f);
      GL.Vertex3(1.0f, 1.0f, -1.0f);
      GL.Vertex3(1.0f, -1.0f, -1.0f);
      // Face de cima
      GL.Color3(0.0, 0.0, 1.0);
      GL.Normal3(0, 1, 0);
      GL.Vertex3(-1.0f, 1.0f, -1.0f);
      GL.Vertex3(-1.0f, 1.0f, 1.0f);
      GL.Vertex3(1.0f, 1.0f, 1.0f);
      GL.Vertex3(1.0f, 1.0f, -1.0f);
      // Face de baixo
      GL.Color3(1.0, 1.0, 0.0);
      GL.Normal3(0, -1, 0);
      GL.Vertex3(-1.0f, -1.0f, -1.0f);
      GL.Vertex3(1.0f, -1.0f, -1.0f);
      GL.Vertex3(1.0f, -1.0f, 1.0f);
      GL.Vertex3(-1.0f, -1.0f, 1.0f);
      // Face da direita
      GL.Color3(0.0, 1.0, 1.0);
      GL.Normal3(1, 0, 0);
      GL.Vertex3(1.0f, -1.0f, -1.0f);
      GL.Vertex3(1.0f, 1.0f, -1.0f);
      GL.Vertex3(1.0f, 1.0f, 1.0f);
      GL.Vertex3(1.0f, -1.0f, 1.0f);
      // Face da esquerda
      GL.Color3(1.0, 0.0, 1.0);
      GL.Normal3(-1, 0, 0);
      GL.Vertex3(-1.0f, -1.0f, -1.0f);
      GL.Vertex3(-1.0f, -1.0f, 1.0f);
      GL.Vertex3(-1.0f, 1.0f, 1.0f);
      GL.Vertex3(-1.0f, 1.0f, -1.0f);
      GL.End();

      if (exibeVetorNormal)
        ajudaExibirVetorNormal();
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