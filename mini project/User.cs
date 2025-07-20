using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mini_progect
{
    internal class User : IEnumerable
    {

        public User()
        {
            PhoneNumber = Rnd.Next(500000000, 599999999);
        }


        public void Sort(IComparer<Car> comparer)
        {
            BuyedCar.Sort(comparer);
        }

        private static Random Rnd = new Random();
        public string Name { get; set; }
        public string Mail { get; set; }
        public string Password { get; set; }
        public int PhoneNumber { get; set; }

        public IEnumerator GetEnumerator()
        {
            throw new NotImplementedException();
        }


        public List<Car> Favorites { get; set; } = new List<Car>();
        public List<Car> MyCars { get; set; } = new List<Car>();
        public List<Car> BuyedCar { get; set; } = new List<Car>();

        public void ShowFavoriteCar()
        {
            Console.WriteLine($"User Name : {Name}\n");
            foreach (var car in Favorites)
            {
                Console.WriteLine($"({Favorites.IndexOf(car)+1}) {car}  ");
            }
        }
        public void ShowAllBuyedCars()
        {
            foreach (var car in BuyedCar)
            {
                Console.WriteLine(car);
            }
        }
        public void ShowMyCar()
        {
            Console.WriteLine($"User Name : {Name}\n");
            foreach (var car in MyCars)
            {
                Console.WriteLine($"({MyCars.IndexOf(car) + 1}) {car}");
            }
        }

        public override string ToString()
        {
            return $"Name : {Name}, Mail : {Mail} , PhoneNumber : {PhoneNumber}  ";


        }


    }
}