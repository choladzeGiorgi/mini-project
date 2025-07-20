using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mini_progect
{
    internal class SortByYear : IComparer<Car>
    {
        public int Compare(Car x, Car y)
        {
            return x.Year.CompareTo(y.Year);
        }
    }
    internal class SortByManufactorer : IComparer<Car>
    {
        public int Compare(Car x, Car y)
        {
            return x.Manufactorer.CompareTo(y.Manufactorer);
        }
    }
}