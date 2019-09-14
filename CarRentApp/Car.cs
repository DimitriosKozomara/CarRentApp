using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TvpProj
{
    public class Car
    {
        //static int id = 0;
        int carID;
        string make;
        string model;
        int year;
        int cubage;
        string drivetrain;
        string transmission;
        string body;
        string fuel;
        int doors;

        public Car(string make, string model, int year, int cubage, string drivetrain,
            string transmission, string body, string fuel, int doors)
        {
            //his.carID = id++;
            this.make = make;
            this.model = model;
            this.year = year;
            this.cubage = cubage;
            this.drivetrain = drivetrain;
            this.transmission = transmission;
            this.body = body;
            this.fuel = fuel;
            this.doors = doors;
        }

        public override bool Equals(object obj)
        {
            var car = obj as Car;
            if (car == null)
                return false;
            return (this.carID == car.carID);
        }

        public override int GetHashCode()
        {
            return this.carID.GetHashCode();
        }

        public int CarID { get => carID; set => carID = value; }
        public string Make { get => make; set => make = value; }
        public string Model { get => model; set => model = value; }
        public int Year { get => year; set => year = value; }
        public int Cubage { get => cubage; set => cubage = value; }
        public string Drivetrain { get => drivetrain; set => drivetrain = value; }
        public string Transmission { get => transmission; set => transmission = value; }
        public string Body { get => body; set => body = value; }
        public string Fuel { get => fuel; set => fuel = value; }
        public int Doors { get => doors; set => doors = value; }
        
        public string GetCarInfo()
        {
            return this.make + " " + this.model + " " + this.year;
        }
        public override string ToString()
        {
            return this.make + " " + this.model + " " + this.year + " ID: " + this.carID;
        }
    }
}
