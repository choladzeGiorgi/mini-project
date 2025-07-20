using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mini_progect
{
    internal class Myauto
    {
        private bool Logined = false;
        private User LoginedUser = null;
        public Myauto()
        {
            Sort(new SortByYear());
            GetUsers();
        }
        public void ShowMostPopularCar()
        {
           
            int count = 0;
            int max = 0;
            string MaxCars = LoginedUser.BuyedCar[0].Manufactorer;
            string car = "";

            for (int i = 0; i < LoginedUser.BuyedCar.Count; i++)
            {
               
                if(LoginedUser.BuyedCar[i].Manufactorer.ToLower() == MaxCars.ToLower() )
                {
                    count++;
                    if (count > max)
                    {
                        max = count;
                        car = MaxCars;
                    }
                }
                else
                {
                    count = 1;
                    MaxCars = LoginedUser.BuyedCar[i].Manufactorer;
                };
                
                
            }

            Console.WriteLine(car+ " " + max);
          

        }
        public void GetUsers()
        {
             foreach (var cars in autos)
            {
                cars.Owener.MyCars.Add(cars);
                users.Add(cars.Owener);
            }

            User user = null;

            for (int i = 0; i < users.Count; i++)
            {

                for (int j = i+1; j < users.Count; j++)
                {

                    if (users[i].Name == users[j].Name)
                    {
                        Car car = new Car();
                        car = users[j].MyCars[0];
                        users[i].MyCars.Add(car);
                        user = users[j];
                    }
                    users.Remove(user);
                }
            }
            

        }
        List<Car> autos = new carsClass().myauto;
        List<User> users = new List<User>();
        public void Menu()
        {
            Console.WriteLine("Input Operations");
            Console.WriteLine("(1) Show All Cars");
            Console.WriteLine("(2) Search Cars");
            Console.WriteLine("(3) User");
            string op = Console.ReadLine();

            if (op.Trim() == "1")
            {
                ShowALL();
                Menu();
            }
            else if (op.Trim() == "2")
            {
                Search();
                Menu();
            }
            else if(op.Trim() == "3")
            {
                UserSettings();
                Menu();
            }

        }
        List<Car> filter = new List<Car>();
        public void FilterByManufactorer()
        {
            Console.WriteLine("Enter Manufactorer");
            string manufactorer = Console.ReadLine();
            foreach (var car in autos)
            {
                if (car.Manufactorer.ToLower().Trim() == manufactorer.ToLower().Trim())
                {
                    filter.Add(car);
                }

            }
        }
        public void FilterByModel()
        {
            if (filter.Count == 0)
            {
                Console.WriteLine("Sorry try again");
            }
            else
            {
                Console.WriteLine("Enter Model");
                string model = Console.ReadLine();
                List<Car> modelFilter = new List<Car>();
                foreach (var car in filter)
                {
                    if (car.Model.ToLower().Trim() == model.ToLower().Trim())
                    {
                        modelFilter.Add(car);
                    }
                    
                }
                if (modelFilter.Count == 0) { }
                else
                {
                    filter = modelFilter;
                }
                 

            }
        }
        public void Search()
            {

            FilterByManufactorer();
            FilterByModel();

            foreach (var cars in filter)
            {
                Console.WriteLine(cars);
            }
            filter = new List<Car>();
        }
        public void ShowALL()
        {

            foreach (var car in autos)
            {
                Console.WriteLine($"({autos.IndexOf(car)+1}){car}");

            }
        }
        public void ShowAllUsers()
        {
            foreach(var u in users)
                Console.WriteLine(u);
        }
        public void UserLogIn()
        {
            Console.WriteLine("Input Mail");
            string mail = Console.ReadLine();
            Console.WriteLine("Input Password");
            string password = Console.ReadLine();
            foreach(var user in users)
            {
                if(user.Mail ==  mail && user.Password == password)
                {
                    Logined = true;
                    LoginedUser = user;
                }
            }
            if(Logined == false)
            {
                Console.WriteLine("Login Failed");
                Console.WriteLine("Do you Want to Login Again");
                string op = Console.ReadLine();
                if(op.ToLower().Trim() == "yes" )
                    UserLogIn();
            }
            else if (Logined == true)
            {
                Console.WriteLine("Login Successfuly");
            }
        }
        public void UserSettings()
        {
            if(Logined == true)
            {
                Console.WriteLine("(1)Favorites Cars");
                Console.WriteLine("(2)Log Out");
                Console.WriteLine("(3)Add Favorite Car");
                Console.WriteLine("(4)MyCars");
                Console.WriteLine("(5)Add Car");
                Console.WriteLine("(6)Buy Car");
                Console.WriteLine("(7)Buying car");

                string op = Console.ReadLine();
                if (op.ToLower().Trim() == "1")
                {
                    LoginedUser.ShowFavoriteCar();
                    Console.WriteLine("Do you Want to Remove Some Cars");
                    string removeOp = Console.ReadLine();
                    if (removeOp.ToLower() == "yes")
                        RemoveFromFavorites();

                }
                else if (op.ToLower().Trim() == "2")
                {
                    LoginedUser = null;
                    Logined = false;
                }
                else if (op.ToLower().Trim() == "3")
                {
                    Console.WriteLine($"Input Car index");
                    ShowALL();
                    bool addFavorite = true;
                    int index = int.Parse(Console.ReadLine());
                    foreach (var i in LoginedUser.Favorites)
                    {
                        if (i.Owener.Name == autos[index - 1].Owener.Name && i.Manufactorer == autos[index - 1].Manufactorer && i.Model == autos[index - 1].Model)
                        {
                            addFavorite = false;
                        }
                    }
                    if (addFavorite == true)
                    {
                        AddFavoriteCar(autos[index - 1]);
                    }
                    else if (addFavorite == false)
                    {
                        Console.WriteLine("You Allready Have this car in favorites");
                    }
                }
                else if (op.ToLower().Trim() == "4")
                {
                    LoginedUser.ShowMyCar();
                    Console.WriteLine("Do you Want to Remove Some Cars");
                    string removeOp = Console.ReadLine();
                    if (removeOp.ToLower() == "yes")
                        RemoveFromMyCars();
                }
                else if(op.ToLower().Trim() == "5")
                    AddNewCar();
                else if(op.ToLower() == "6")
                {
                    Console.WriteLine($"Input Car index");
                    ShowALL();
                    int index = int.Parse(Console.ReadLine());
                    LoginedUser.BuyedCar.Add(autos[index - 1]);
                    RemoveCar(autos[index - 1]);
                }
                else if (op.ToLower() == "7")
                {
                    LoginedUser.Sort(new SortByManufactorer());
                    LoginedUser.ShowAllBuyedCars();
                    Console.WriteLine("Do you want to remove some cars");
                    string _msg = Console.ReadLine();

                    try
                    {
                        ShowMostPopularCar();
                    }
                    catch (ArgumentOutOfRangeException ex)
                    {

                        Console.WriteLine(ex.Message);
                    }
                    if (_msg.ToLower() == "yes")
                    {

                        Console.WriteLine("Input index");
                        int ind = int.Parse(Console.ReadLine());
                        try
                        {
                            LoginedUser.BuyedCar.RemoveAt(ind - 1);
                        }
                        catch (ArgumentOutOfRangeException ex)
                        {

                            Console.WriteLine(ex.Message);
                        }
                    }

                }
            }
            else if(Logined == false)
            {
                Console.WriteLine("(1)LogIn");
                Console.WriteLine("(2)Register");
                string op = Console.ReadLine();
                if (op.ToLower().Trim() == "1")
                     UserLogIn();
                else if (op.ToLower().Trim() == "2")
                 Register();
            }

        }
        private void RemoveFromMyCars()
        {
            Console.WriteLine("Which One Do You Whant To Remove");
            int index = int.Parse(Console.ReadLine());
            Car car = LoginedUser.MyCars[index - 1];
            LoginedUser.MyCars.Remove(car);
            autos.Remove(car);
        }
        private void RemoveCar(Car car)
        {
            foreach(var user in users)
            {
              for(int i = 0 ; i < user.MyCars.Count; i++)
                {
                    if(user.MyCars[i] == car)
                        user.MyCars.Remove(car);
                }
            }

            autos.Remove(car);
        }
        public void AddNewCar()
        {
            Console.WriteLine("Input Manufactorer");
            string manufactorer = Console.ReadLine();
            Console.WriteLine("Input Model");
            string model = Console.ReadLine();
            Console.WriteLine("Input Year");
            int year = int.Parse(Console.ReadLine());
            Console.WriteLine("Input Price");
            int price = int.Parse(Console.ReadLine());
            Console.WriteLine("Input Location");
            string Location = Console.ReadLine();
            Car car = new Car() { Owener = LoginedUser, Location = Location, Manufactorer = manufactorer, Model = model, Price = price, Year = year };

            LoginedUser.MyCars.Add(car);
            autos.Add(car);

        }
        private void RemoveFromFavorites()
        {
            Console.WriteLine("Which One Do You Whant To Remove");
            int index = int.Parse(Console.ReadLine());
            LoginedUser.Favorites.Remove(LoginedUser.Favorites[index-1]);
        }
        private void AddFavoriteCar(Car car)
        {
            LoginedUser.Favorites.Add(car);
        }
        private void Register()
        {
            User user1 = null;
            bool register = false;
            Console.WriteLine("Input Name");
            string name = Console.ReadLine();
            Console.WriteLine("Input Mail");
            string mail = Console.ReadLine();


            foreach (var user in users)
            {
                if(user.Name == name && user.Mail == mail) 
                    register = true;
            }
             if (register == true)
            {
                Console.WriteLine("This User is All ready Register");
            }
            else if (register == false)
            {
                user1 = new User { Name = name, Mail = mail, PhoneNumber = GetPhoneNumber(), Password = GetPassword() };
                LoginedUser = user1;
                users.Add(user1);
                Logined = true;
            }
            

        }

        public string GetPassword()
        {
            string password = "";
            try
            {
                Console.WriteLine("Input Password");
                password = Console.ReadLine();
                if (password.Length < 8)
                {
                   throw new PasswordExeption();
                }
            }
            catch (PasswordExeption ex)
            {
                Console.WriteLine(ex.Message);
                GetPassword();
            }
            return password;
        }

        public int GetPhoneNumber()
        {
            int phoneNumber = 0;
            try
            {
                Console.WriteLine("Input PhoneNumber");
                phoneNumber = int.Parse(Console.ReadLine());
            }
            catch (FormatException ex)
            {
                Console.WriteLine(ex.Message);
                GetPhoneNumber();
            }
            return phoneNumber;
        }
        public void Sort(IComparer<Car> comparer)
        {
            autos.Sort(comparer);
        }



    }

    class carsClass
    {

     


       

        public List<Car> myauto = new List<Car>()
        {
            new Car()
            {
                Owener = new User(){
                Name = "Gela",
                Mail = "Gela@gmail.com",
                Password = "GelaaGoca12" },
                Manufactorer = "Mercedes",
                Model = "W140",
                Location = "Tbilisi",
                Price = 5000,
                Year = 1998

            },
            new Car()
            {
                Owener = new User(){
                Name = "Gela",
                Mail = "Gela@gmail.com",
                Password = "GelaaGoca12" },
                Manufactorer = "Mercedes",
                Model = "W210",
                Location = "Tbilisi",
                Price = 3000,
                Year = 2000

            },
            new Car()
            {
                Owener = new User(){
                Name = "Gela",
                Mail = "Gela@gmail.com",
                Password = "GelaaGoca12" },
                Manufactorer = "Mercedes",
                Model = "W211",
                Location = "Tbilisi",
                Price = 6000,
                Year = 2003

            },
            new Car()
            {
                Owener = new User(){
                Name = "Giusha",
                Mail = "GiushaGoco@gmail.com",
                Password = "Giushagio12" },
                Manufactorer = "Bmw",
                Model = "F90",
                Location = "Tbilisi",
                Price = 95000,
                Year = 2023
            },
             new Car()
            {
                Owener = new User(){
                Name = "Giusha",
                Mail = "GiushaGoco@gmail.com",
                Password = "Giushagio12" },
                Manufactorer = "Bmw",
                Model = "F30",
                Location = "Tbilisi",
                Price = 20000,
                Year = 2016
            },
              new Car()
            {
                Owener = new User(){
                Name = "Giusha",
                Mail = "GiushaGoco@gmail.com",
                Password = "Giushagio12" },
                Manufactorer = "Bmw",
                Model = "E60",
                Location = "Tbilisi",
                Price = 25000,
                Year = 2020
            },
             new Car()
            {
                Owener = new User()
                {
                Name = "coTne",
                Mail = "coTnevano@gmail.com",
                Password = "cotneji12",
                },
                Manufactorer = "Porsche",
                Model = "Panamera",
                Location = "qutaisi",
                Price = 75000,
                Year = 2020
             },
             new Car()
            {
                Owener = new User()
                {
                Name = "coTne",
                Mail = "coTnevano@gmail.com",
                Password = "cotneji12",
                },
                Manufactorer = "Audi",
                Model = "RS7",
                Location = "qutaisi",
                Price = 38000,
                Year = 2017
             },
              new Car()
            {
                Owener = new User()
                {
                Name = "nika",
                Mail = "nika@gmail.com",
                Password = "nika12",
                },
                Manufactorer = "Lexus",
                Model = "GX550",
                Location = "qutaisi",
                Price = 38000,
                Year = 2017
             },

        };

    }

} 



