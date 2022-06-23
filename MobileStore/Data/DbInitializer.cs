using MobileStore.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MobileStore.Data
{
    public static class DbInitializer
    {
        public static void Initialize(MobileStoreContext context)
        {
            // Look for any students.
            if (context.Phones.Any())
            {
                return;   // DB has been seeded
            }

            var phone = new Phone[]
            {
                new Phone{Firm="Apple",Model="Iphone 12",Price=1000},
                new Phone{Firm="Apple",Model="Iphone 13",Price=1300},
                new Phone{Firm="Apple",Model="Iphone 11",Price=900},
                new Phone{Firm="Apple",Model="Iphone 10",Price=800},
                new Phone{Firm="Samsung",Model="Galaxy A52",Price=500},
                new Phone{Firm="Samsung",Model="Galaxy S71",Price=700},
                new Phone{Firm="Samsung",Model="Galaxy S31",Price=2000},
                new Phone{Firm="Samsung",Model="Galaxy S22",Price=1500},
                new Phone{Firm="Xiaomi",Model="Mi A1",Price=300},
                new Phone{Firm="Xiaomi",Model="Z Flip",Price=3000},
                new Phone{Firm="Xiaomi",Model="Mi 11 Ultra",Price=1000}

            };

            context.Phones.AddRange(phone);
            context.SaveChanges();

            var client = new Client[]
            {
                new Client{Name="Vasya",PhoneNumber=12345,Address="Vitebsk"},
                new Client{Name="Petya",PhoneNumber=54321,Address="Minsk"},
                new Client{Name="Kolya",PhoneNumber=11111,Address="Brest"},
                new Client{Name="Dima",PhoneNumber=12442345,Address="Mogilev"},
                new Client{Name="Andrei",PhoneNumber=22212345,Address="Gomel"},
                new Client{Name="Fedya",PhoneNumber=33312345,Address="Grodno"},

            };

            context.Clients.AddRange(client);
            context.SaveChanges();

            var order = new Order[]
            {
                new Order{ClientID=1}
                

            };

            context.Orders.AddRange(order);
            context.SaveChanges();
            
            var aboutphone = new AboutPhone[]
            {
                new AboutPhone{PhoneID=1,Firm="Apple",Model="Iphone 12", CPU="Bionic A13", Camera= "12 MPx", Color="Black"},
                new AboutPhone{PhoneID=2,Firm="Apple",Model="Iphone 13", CPU="Bionic A14", Camera= "13 MPx", Color="Blue"},
                new AboutPhone{PhoneID=3,Firm="Apple",Model="Iphone 11", CPU="Bionic A12", Camera= "11 MPx", Color="White"},

            };

            context.AboutPhones.AddRange(aboutphone);
            context.SaveChanges();

            var aboutclient = new AboutClient[]
            {
                new AboutClient{ClientID=1,Name="Vasya",LastName="Petrov", PhoneNumber=12345, Address= "Vitebsk", RegistrationDate = DateTime.Parse("2022-08-01")},
                new AboutClient{ClientID=2,Name="Petya",LastName="Ivanov", PhoneNumber=54321, Address= "Minsk", RegistrationDate = DateTime.Parse("2021-07-01")},
                new AboutClient{ClientID=3,Name="Kolya",LastName="Sidorov", PhoneNumber=11111, Address= "Brest", RegistrationDate = DateTime.Parse("2020-06-01")},

            };

            context.AboutClient.AddRange(aboutclient);
            context.SaveChanges();


        }
    }
}