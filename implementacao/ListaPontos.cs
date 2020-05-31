
using CG_Biblioteca;
using System.Collections.Generic;
using System;

namespace gcgcg
{
  internal class ListaPontos
  {

    private List<Ponto4D> pontosInterno;
    private Ponto4D ptoSel;

    private List<Ponto4D> cachePontos;
    private Transformacao4D cacheTransformacao;

    public ListaPontos(): base()
    {
      this.pontosInterno = new List<Ponto4D>();
      this.ptoSel = null;
      this.cachePontos = null;
      this.cacheTransformacao = null;
    }

    public List<Ponto4D> pontos(Transformacao4D trs)
    {

      if (this.cachePontos != null && this.cacheTransformacao == trs)
      {
        return this.cachePontos;
      }

      List<Ponto4D> ptos = new List<Ponto4D>();
      
      foreach (Ponto4D pt in this.pontosInterno)
      {
        ptos.Add(trs.MultiplicarPonto(pt));
      }

      this.cachePontos = ptos;
      this.cacheTransformacao = trs;

      return ptos;
    }

    public double maxX(Transformacao4D trs)
    {
      double ret = 0d;
      bool isFist = true;
      foreach (Ponto4D pt in this.pontos(trs))
      {
        if (isFist || pt.X > ret)
        {
          isFist = false;
          ret = pt.X;
        }
      }
      return ret;
    }

    public double minX(Transformacao4D trs)
    {
      double ret = 0d;
      bool isFist = true;
      foreach (Ponto4D pt in this.pontos(trs))
      {
        if (isFist || pt.X < ret)
        {
          isFist = false;
          ret = pt.X;
        }
      }
      return ret;
    }

    public double maxY(Transformacao4D trs)
    {
      double ret = 0d;
      bool isFist = true;
      foreach (Ponto4D pt in this.pontos(trs))
      {
        if (isFist || pt.Y > ret)
        {
          isFist = false;
          ret = pt.Y;
        }
      }
      return ret;
    }

    public double minY(Transformacao4D trs)
    {
      double ret = 0d;
      bool isFist = true;
      foreach (Ponto4D pt in this.pontos(trs))
      {
        if (isFist || pt.Y < ret)
        {
          isFist = false;
          ret = pt.Y;
        }
      }
      return ret;
    }
  
    public Ponto4D pontoSel(Transformacao4D trs)
    {
      if (this.ptoSel == null)
      {
        return null;
      }
      return trs.MultiplicarPonto(this.ptoSel);
    }

    public void SelecionaProximo(Ponto4D pto, Transformacao4D trs)
    {
      double d = 0;
      this.ptoSel = null;
      foreach (Ponto4D pt in this.pontos(trs))
      {
        double dPt = Utilitario.distancia(pt, pto);
        if (dPt < d || this.ptoSel == null)
        {
          this.ptoSel = pt;
          d = dPt;
        }
      }
    }

    public void movePontoSel(Ponto4D pto)
    {
      for (int idx = 0; idx < this.pontosInterno.Count; idx++)
      {
        Ponto4D temp = this.pontosInterno[idx];
        if (temp.X == this.ptoSel.X && temp.Y == this.ptoSel.Y)
        {
          this.pontosInterno[idx] = pto;
          this.ptoSel = pto;
          this.cachePontos = null;
          return;
        }
      }
    }

    public void removePontoSel()
    {
      this.pontosInterno.Remove(this.ptoSel);
      this.cachePontos = null;
    }

    public void limpaPontoSel()
    {
      this.ptoSel = null;
    }

    public void addPonto(Ponto4D pto)
    {
      this.pontosInterno.Add(pto);
      this.cachePontos = null;
    }

  }
}
