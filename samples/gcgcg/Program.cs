using System;

namespace gcgcg
{
    class Program
    {

        public void areaCirculo() {
            double areaCirculo = 0, RaioDoCirculo = 0;
            Console.WriteLine(" Informe o raio do Círculo : ");
            RaioDoCirculo = Convert.ToDouble(Console.ReadLine());
            areaCirculo = Math.PI * Math.Pow(RaioDoCirculo, 2);
            Console.WriteLine(" A área do círculo de raio " +  RaioDoCirculo.ToString() + " é : " + areaCirculo.ToString());
            Console.ReadKey();
        }


        static void Main(string[] args)
        {
            Console.WriteLine("___ TESTES ____");
            Matematica mat = new Matematica();
            Ponto4D pto = new Ponto4D();
            pto = mat.ptoCirculo(90,15);
            Console.WriteLine("x: "+pto.X+" - y: "+pto.Y+" - z: "+pto.Z);
            
        }

    }
}
