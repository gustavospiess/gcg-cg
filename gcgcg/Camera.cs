namespace gcgcg
{
  /// <summary>
  /// Classe para controlar a câmera sintética.
  /// </summary>
  internal class Camera
  {
    private double xMin, xMax, yMin, yMax;

    public Camera(double xMin = -300, double xMax = 300, double yMin = -300, double yMax = 300)
    {
      this.xMin = xMin;
      this.xMax = xMax;
      this.yMin = yMin;
      this.yMax = yMax;
    }
    public double xmin { get => xMin; set => xMin = value; }
    public double xmax { get => xMax; set => xMax = value; }
    public double ymin { get => yMin; set => yMin = value; }
    public double ymax { get => yMax; set => yMax = value; }

    public void panEsq() { xMin += 2; xMax += 2; }
    public void panDir() { xMin -= 2; xMax -= 2; }
    public void panCim() { yMin -= 2; yMax -= 2; }
    public void panBai() { yMin += 2; yMax += 2; }
//TODO: falta testa os limites de zoom    
    public void zoomIn() { 
      xMin += 2; xMax -= 2; yMin += 2; yMax -= 2; 
    }
//TODO: falta testa os limites de zoom    
    public void zoomOut() { 
      xMin -= 2; xMax += 2; yMin -= 2; yMax += 2; 
    }

  }
}