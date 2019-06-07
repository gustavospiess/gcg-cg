/*
  Autor: Dalton Solano dos Reis
 */
using OpenTK.Graphics.OpenGL;
using CG_Biblioteca;

namespace gcgcg
{
  internal class Cubo : Objeto
  {
    public Cubo()
    {
    }

//TODO: entender o uso da keyword new ... e replicar para os outros projetos
    new public void Desenha()
    {
      GL.Begin(PrimitiveType.Quads);
      // Front Face
      GL.Color3(1.0f, 0.0f, 0.0f);
      GL.Normal3(0, 0, 1);
      //glColor3f(1,0,0);
      GL.Vertex3(-1.0f, -1.0f, 1.0f);
      GL.Vertex3(1.0f, -1.0f, 1.0f);
      GL.Vertex3(1.0f, 1.0f, 1.0f);
      GL.Vertex3(-1.0f, 1.0f, 1.0f);
      // Back Face
      GL.Color3(0.0f, 1.0f, 0.0f);
      GL.Normal3(0, 0, -1);
      //glColor3f(0,1,0);
      GL.Vertex3(-1.0f, -1.0f, -1.0f);
      GL.Vertex3(-1.0f, 1.0f, -1.0f);
      GL.Vertex3(1.0f, 1.0f, -1.0f);
      GL.Vertex3(1.0f, -1.0f, -1.0f);
      // Top Face
      GL.Color3(0.0f, 0.0f, 1.0f);
      GL.Normal3(0, 1, 0);
      GL.Vertex3(-1.0f, 1.0f, -1.0f);
      GL.Vertex3(-1.0f, 1.0f, 1.0f);
      GL.Vertex3(1.0f, 1.0f, 1.0f);
      GL.Vertex3(1.0f, 1.0f, -1.0f);
      // Bottom Face
      GL.Color3(1.0f, 1.0f, 0.0f);
      GL.Normal3(0, -1, 0);
      GL.Vertex3(-1.0f, -1.0f, -1.0f);
      GL.Vertex3(1.0f, -1.0f, -1.0f);
      GL.Vertex3(1.0f, -1.0f, 1.0f);
      GL.Vertex3(-1.0f, -1.0f, 1.0f);
      // Right face
      GL.Color3(0.0f, 1.0f, 1.0f);
      GL.Normal3(1, 0, 0);
      GL.Vertex3(1.0f, -1.0f, -1.0f);
      GL.Vertex3(1.0f, 1.0f, -1.0f);
      GL.Vertex3(1.0f, 1.0f, 1.0f);
      GL.Vertex3(1.0f, -1.0f, 1.0f);
      // Left Face
      GL.Color3(1.0f, 0.0f, 1.0f);
      GL.Normal3(-1, 0, 0);
      GL.Vertex3(-1.0f, -1.0f, -1.0f);
      GL.Vertex3(-1.0f, -1.0f, 1.0f);
      GL.Vertex3(-1.0f, 1.0f, 1.0f);
      GL.Vertex3(-1.0f, 1.0f, -1.0f);
      GL.End();
    }
  }
}