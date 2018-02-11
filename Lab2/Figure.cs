using System;

namespace figure
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
    public void Print()
    {
        Console.WriteLine(this.ToString());
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
    interface VivodData
    {
        void Print();
    }
    public class Matrix<T>
    {
        Dictionary<string, T> _matrix = new Dictionary<string, T>();
        int maxX;
        int maxY;
        int maxZ;
        T nullElement;
        public Matrix(int px, int py, int pz, T nullElementParam)
        {
            this.maxX = px;
            this.maxY = py;
            this.maxZ = pz;
            this.nullElement = nullElementParam;
        }
        public T this[int x, int y, int z]
        {
            get
            {
                CheckBounds(x, y, z);
                string key = DictKey(x, y, z);
                if (this._matrix.ContainsKey(key))
                {
                    return this._matrix[key];
                }
                else
                {
                    return this.nullElement;
                }
            }
            set
            {
                CheckBounds(x, y, z);
                string key = DictKey(x, y, z);
                this._matrix.Add(key, value);
            }
        }
        void CheckBounds(int x, int y, int z)
        {
            if (x < 0 || x >= this.maxX) throw new Exception("x=" + x + " выходит за границы");
            if (y < 0 || y >= this.maxY) throw new Exception("y=" + y + " выходит за границы");
            if (z < 0 || z >= this.maxZ) throw new Exception("z=" + z + " выходит за границы");
        }
        string DictKey(int x, int y, int z)
        {
            return x.ToString() + "_" + y.ToString() + "_" + z.ToString();
        }
        public override string ToString()
        {
            ArrayList lis = new ArrayList();
            for (int k = 0; k < this.maxZ; k++)
            {
                for (int j = 0; j < this.maxY; j++)
                {

                    for (int i = 0; i < this.maxX; i++)
                    {
                        string i1 = Convert.ToString(i);
                        string j1 = Convert.ToString(j);
                        string k1 = Convert.ToString(k);
                        lis.Add("{" + i1 + j1 + k1 + "}");
                    }
                }
            }
            foreach (object o in lis) Console.WriteLine(o.ToString());
            return null;
        }

    }
    public class SimpleListItem<T>
    {
        public T data { get; set; }
        public SimpleListItem<T> next { get; set; }
        public SimpleListItem(T param)
        {
            this.data = param;
        }
    }
    public class SimpleList<T> : IEnumerable<T>
        where T : IComparable
    {
        protected SimpleListItem<T> first = null;
        protected SimpleListItem<T> last = null;
        public int Count
        {
            get { return _count; }
            protected set { _count = value; }
        }
        int _count;
        public void Add(T element)
        {
            SimpleListItem<T> newItem = new SimpleListItem<T>(element);
            this.Count++;
            if (last == null)
            {
                this.first = newItem;
                this.last = newItem;
            }
            else
            {
                this.last.next = newItem;
                this.last = newItem;
            }
        }
        public SimpleListItem<T> GetItem(int number)
        {
            if ((number < 0) || (number >= this.Count))
            {
                throw new Exception("Выход за границу индекса");
            }
            SimpleListItem<T> current = this.first;
            int i = 0;
            while (i < number)
            {
                current = current.next;
                i++;
            }
            return current;
        }
        public T Get(int number)
        {
            return GetItem(number).data;
        }
        public IEnumerator<T> GetEnumerator()
        {
            SimpleListItem<T> current = this.first;
            while (current != null)
            {
                yield return current.data; //возврат тек. знач.
                current = current.next;
            }
        }
        System.Collections.IEnumerator
        System.Collections.IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
        public void Sort()
        {
            Sort(0, this.Count - 1);
        }
        private void Sort(int low, int high)
        {
            int i = low;
            int j = high;
            T x = Get((low + high) / 2);
            do
            {
                while (Get(i).CompareTo(x) < 0) ++i;
                while (Get(j).CompareTo(x) > 0) --j;
                if (i <= j)
                {
                    Swap(i, j); i++; j--;
                }
            } while (i <= j);
            if (low < j) Sort(low, j);
            if (i < high) Sort(i, high);
        }
        private void Swap(int i, int j)
        {
            SimpleListItem<T> ci = GetItem(i);
            SimpleListItem<T> cj = GetItem(j);
            T temp = ci.data;
            ci.data = cj.data;
            cj.data = temp;
        }
    }
    public class SimpleStack<T> : SimpleList<T>
        where T : IComparable
    {
        public void Push(T element)
        {
            Add(element);

        }
        public T Pop()
        {
            T Result = default(T);
            if (this.Count == 0) return Result;
            if (this.Count == 1)
            {
                Result = this.first.data;
                this.first = null;
                this.last = null;
            }
            else
            {
                SimpleListItem<T> newLast = this.GetItem(this.Count - 2);
                Result = newLast.next.data;
                this.last = newLast;
                newLast.next = null;
            }
            this.Count--;
            return Result;
        }
    }
}
