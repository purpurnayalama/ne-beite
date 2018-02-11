using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication2
{
    abstract class GeoFig : IComparable
    {
        public string Tip
        {
            get
            {
                return this._Tip;
            }
            set
            {
                this._Tip = value;
            }
        }
        string _Tip;
        public abstract double Ploshad();

        public override string ToString()
        {
            return this.Tip + " площадью " + this.Ploshad().ToString();
        }
        public int CompareTo(object obj)
        {
            GeoFig g = (GeoFig)obj;
            if (this.Ploshad() < g.Ploshad()) return -1;
            else if (this.Ploshad() == g.Ploshad()) return 0;
            else return 1;
        }

    }
    class Pryamougolnik : GeoFig, VivodData
    {
        double visota;
        double shirina;

        public Pryamougolnik(double vi, double sh)
        {
            this.visota = vi;
            this.shirina = sh;
            this.Tip = "Прямоугольник";
        }
        public override double Ploshad()
        {
            double Otvet = this.visota * this.shirina;
            return Otvet;
        }

        public void Print()
        {
            Console.WriteLine(this.ToString());
        }

    }
    class Kvadrat : Pryamougolnik
    {
        public Kvadrat(double dlina) : base(dlina, dlina)
        {
            this.Tip = "Квадрат";
        }
    }
    class krug : GeoFig, VivodData
    {
        public double Radius;
        public krug(double Ra)
        {
            this.Radius = Ra;
            this.Tip = "Круг";
        }
        public override double Ploshad()
        {
            double Otvet = Math.PI * (Math.Pow(this.Radius, 2));
            return Otvet;
        }
        public void Print()
        {
            Console.WriteLine(this.ToString());
        }
    }
}
