using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TvpProj
{
    public class Data
    {
        const string dirClients = @"data\clients.json";
        const string dirCars = @"data\cars.json";
        const string dirReservations = @"data\reservations.json";
        const string dirOffers = @"data\offers.json";
        const string dirAdmin = @"data\admin.json";
        //Car marks
        const string dirMake = @"data\make.json";
        public static void Save<T>(T item)
        {
            if (item is Car)
            {
                Car newCar = item as Car;
                List<Car> cars = ReadAll<Car>();

                string newMake = newCar.Make;
                List<string> makeList = ReadAll<string>();
                //If there's makes in the file
                if (makeList != null)
                {
                    string stringFromFile = makeList.Where(x => x.ToLower().Equals(newMake.ToLower())).FirstOrDefault();
                    //Save make that doesn't exist in a file
                    if (stringFromFile == null)
                    {
                        newMake = CultureInfo.CurrentCulture.TextInfo.ToTitleCase(newCar.Make.ToLower());
                        makeList.Add(newMake);
                        makeList.Sort();
                        string json = JsonConvert.SerializeObject(makeList, Formatting.Indented);
                        File.WriteAllText(dirMake, json);
                    }
                    //If make exists in a file
                    else
                        newCar.Make = stringFromFile;
                }
                //If file is empty/doesn't exist
                else
                {
                    newMake = CultureInfo.CurrentCulture.TextInfo.ToTitleCase(newCar.Make.ToLower());
                    makeList = new List<string>();
                    makeList.Add(newMake);
                    string json = JsonConvert.SerializeObject(makeList, Formatting.Indented);
                    File.WriteAllText(dirMake, json);
                    newCar.Make = newMake;
                }
                if (cars != null)
                {
                    int newID = cars.Max(x => x.CarID) + 1;
                    newCar.CarID = newID;
                    cars.Add(newCar);
                    string json = JsonConvert.SerializeObject(cars, Formatting.Indented);
                    File.WriteAllText(dirCars, json);
                }
                else
                {
                    cars = new List<Car>();
                    newCar.CarID = 1;
                    cars.Add(newCar);
                    string json = JsonConvert.SerializeObject(cars, Formatting.Indented);
                    File.WriteAllText(dirCars, json);
                }
            }
            else if (item is Client)
            {
                Client newClient = item as Client;
                List<Client> clients = ReadAll<Client>();
                if (clients != null)
                {
                    int newID = clients.Max(x => x.ClientID) + 1;
                    newClient.ClientID = newID;
                    clients.Add(newClient);
                    string json = JsonConvert.SerializeObject(clients, Formatting.Indented);
                    File.WriteAllText(dirClients, json);
                }
                else
                {
                    clients = new List<Client>();
                    newClient.ClientID = 1;
                    clients.Add(newClient);
                    string json = JsonConvert.SerializeObject(clients, Formatting.Indented);
                    File.WriteAllText(dirClients, json);
                }

            }

            else if (item is Offer)
            {
                Offer newOffer = item as Offer;
                List<Offer> offers = ReadAll<Offer>();
                if (offers != null)
                {
                    int newID = offers.Max(x => x.OfferID) + 1;
                    newOffer.OfferID = newID;
                    offers.Add(newOffer);
                    string json = JsonConvert.SerializeObject(offers, Formatting.Indented);
                    File.WriteAllText(dirOffers, json);
                }
                else
                {
                    offers = new List<Offer>();
                    newOffer.OfferID = 1;
                    offers.Add(newOffer);
                    string json = JsonConvert.SerializeObject(offers, Formatting.Indented);
                    File.WriteAllText(dirOffers, json);
                }
            }

            else if (item is Reservation)
            {
                Reservation newReservation = item as Reservation;
                List<Reservation> reservations = ReadAll<Reservation>();
                if (reservations != null)
                {
                    int newID = reservations.Max(x => x.ReservationID) + 1;
                    newReservation.ReservationID = newID;
                    reservations.Add(newReservation);
                    string json = JsonConvert.SerializeObject(reservations, Formatting.Indented);
                    File.WriteAllText(dirReservations, json);
                }
                else
                {
                    reservations = new List<Reservation>();
                    newReservation.ReservationID = 1;
                    reservations.Add(newReservation);
                    string json = JsonConvert.SerializeObject(reservations, Formatting.Indented);
                    File.WriteAllText(dirReservations, json);
                }
            }
        }

        public static List<T> ReadAll<T>()
        {
            List<T> list = new List<T>();
            string json = "";
            if (typeof(T) == typeof(Car))
            {
                if (File.Exists(dirCars))
                {
                    json = File.ReadAllText(dirCars);
                    list = (List<T>)Convert.ChangeType(JsonConvert.DeserializeObject<List<Car>>(json), typeof(List<T>));
                }
            }
            else if (typeof(T) == typeof(Client))
            {
                if (File.Exists(dirClients))
                {
                    json = File.ReadAllText(dirClients);
                    list = (List<T>)Convert.ChangeType(JsonConvert.DeserializeObject<List<Client>>(json), typeof(List<T>));
                }
            }
            else if (typeof(T) == typeof(Reservation))
            {
                if (File.Exists(dirReservations))
                {
                    json = File.ReadAllText(dirReservations);
                    list = (List<T>)Convert.ChangeType(JsonConvert.DeserializeObject<List<Reservation>>(json), typeof(List<T>));
                }
            }
            else if (typeof(T) == typeof(Offer))
            {
                if (File.Exists(dirOffers))
                {
                    json = File.ReadAllText(dirOffers);
                    list = (List<T>)Convert.ChangeType(JsonConvert.DeserializeObject<List<Offer>>(json), typeof(List<T>));
                }
            }
            else if (typeof(T) == typeof(string))
            {
                if (File.Exists(dirMake))
                {
                    json = File.ReadAllText(dirMake);
                    list = (List<T>)Convert.ChangeType(JsonConvert.DeserializeObject<List<string>>(json), typeof(List<T>));
                }
            }
            if (list.Count != 0)
                return list;
            return null;
        }

        public static void Update<T>(List<T> list)
        {
            // In case of deletion, if  the last item in file is deleted, delete the file it self
            if (list is List<Car>)
            {
                if (list.Count == 0)
                {
                    File.Delete(dirCars);
                    return;
                }
                string json = JsonConvert.SerializeObject(list, Formatting.Indented);
                File.WriteAllText(dirCars, json);
            }
            if (list is List<Reservation>)
            {
                if (list.Count == 0)
                {
                    File.Delete(dirReservations);
                    return;
                }
                string json = JsonConvert.SerializeObject(list, Formatting.Indented);
                File.WriteAllText(dirReservations, json);
            }
            if (list is List<Client>)
            {
                if (list.Count == 0)
                {
                    File.Delete(dirClients);
                    return;
                }
                string json = JsonConvert.SerializeObject(list, Formatting.Indented);
                File.WriteAllText(dirClients, json);
            }
            if (list is List<Offer>)
            {
                if (list.Count == 0)
                {
                    File.Delete(dirOffers);
                    return;
                }
                string json = JsonConvert.SerializeObject(list, Formatting.Indented);
                File.WriteAllText(dirOffers, json);
            }
        }

        public static void SaveAdmin(Administrator admin)
        {
            string json = JsonConvert.SerializeObject(admin);
            File.WriteAllText(dirAdmin, json);
        }

        public static Administrator ReadAdmin()
        {
            if (File.Exists(dirAdmin))
            {
                String json = File.ReadAllText(dirAdmin);
                return JsonConvert.DeserializeObject<Administrator>(json);
            }
            return null;
        }

        private static void CreateDirectory()
        {
            if (!Directory.Exists(@"data\"))
                Directory.CreateDirectory(@"data\");
        }

        public static void Make1stUsers()
        {
            CreateDirectory();
            if (!File.Exists(dirAdmin))
            {
                Data.SaveAdmin(new Administrator("admin", "admin"));
                Data.Save<Client>(new Client("dimitrios", "12345", "Dimitrios", "Kozomara", "01021997625254", new DateTime(1997, 8, 14), "0611234567"));
                Data.Save<Client>(new Client("sara", "12345", "Sara", "Lazic", "11111998564278", new DateTime(1998, 1, 27), "0655555555"));
                Data.Save<Client>(new Client("laza123", "12345", "Lazar", "Lazarevic", "05061989343432", new DateTime(1989, 2, 13), "0613433234"));
            }
        }

        public static void Make1stCars()
        {
            CreateDirectory();
            if (!File.Exists(dirCars))
            {
                Save<Car>(new Car("Mercedes", "ML 320", 2007, 2938, "Four Wheel Drive", "Automatic", "SUV", "Diesel", 5));
                Save<Car>(new Car("Mercedes", "ML 320", 2009, 2987, "Four Wheel Drive", "Automatic", "SUV", "Diesel", 5));
                Save<Car>(new Car("Mercedes", "ML 320", 2009, 2990, "Four Wheel Drive", "Automatic", "SUV", "Diesel", 5));
                Save<Car>(new Car("Mercedes", "CLS 350", 2019, 2925, "Front Wheel Drive", "Automatic", "Coupe", "Diesel", 5));

                Save<Car>(new Car("Porsche", "Cayenne", 2012, 2995, "Four Wheel Drive", "Automatic", "SUV", "Diesel", 5));
                Save<Car>(new Car("Porsche", "Macan", 2018, 2984, "Four Wheel Drive", "Automatic", "SUV", "Diesel", 5));

                Save<Car>(new Car("Alfa Romeo", "159", 2007, 1910, "Front Wheel Drive", "Manual", "Sedan", "Diesel", 5));

                Save<Car>(new Car("Audi", "A8", 2018, 2967, "Four Wheel Drive", "Automatic", "Coupe", "Diesel", 5));
                Save<Car>(new Car("Audi", "Q7", 2015, 2967, "Four Wheel Drive", "Automatic", "SUV", "Diesel", 5));
            }
        }
    }
}
