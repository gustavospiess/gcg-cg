using System;
using CG_Biblioteca;

namespace gcgcg
{
  internal class SegReta : ObjetoAramado
  {
    private Ponto4D ptoIni, ptoFim;
    public SegReta(string rotulo, Ponto4D ptoIni, Ponto4D ptoFim) : base(rotulo)
    {
      this.ptoIni = ptoIni;
      this.ptoFim = ptoFim;
      GerarPtosRetangulo();
    }

    private void GerarPtosRetangulo()
    {
      base.PontosRemoverTodos();
      base.PontosAdicionar(ptoIni);
      base.PontosAdicionar(ptoFim);
    }

    public void MoverPtoSupDir(Ponto4D ptoMover)
    {
      ptoFim = ptoMover;
      GerarPtosRetangulo();
    }
  }
}