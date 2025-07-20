using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mini_progect
{
    internal class Car
    {
        public string Manufactorer { get; set; }
        public string Model { get; set; }
        public int Year { get; set; }
        public int Price { get; set; }
        public string Location { get; set; }
        public User Owener { get; set; }

        public IEnumerator GetEnumerator()
        {
            throw new NotImplementedException();
        }

        public override string ToString()
        {
            return $"Manufactorer : {Manufactorer} , Model : {Model} , Year : {Year} , Location : {Location} , Price : {Price}$\n" + Owener.ToString() + "\n";
        }




    }
}