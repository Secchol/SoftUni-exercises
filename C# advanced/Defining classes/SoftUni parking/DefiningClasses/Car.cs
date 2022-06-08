using System;
using System.Collections.Generic;
using System.Text;

namespace SoftUniParking
{
    public class Car
    {
        private string make;
        private string model;
        private int horsePower;
        private string registrationNumber;
        public string Make { get { return make; } set { make = value; } }
        public string Model { get { return model; } set { model = value; } }
        public int HorsePower { get { return horsePower; } set { horsePower = value; } }
        public string RegistrationNumber { get { return registrationNumber; } set { registrationNumber = value; } }
        public Car(string make, string model, int horsePower, string registrationNumber)
        {
            this.Make = make;
            this.Model = model;
            this.HorsePower = horsePower;
            this.RegistrationNumber = registrationNumber;



        }
        public override string ToString()
        {
            string make = this.Make;
            string model = this.Model;
            int horsePower = this.HorsePower;
            string registrationNumber = this.RegistrationNumber;
            StringBuilder carInfo = new StringBuilder();
            carInfo.Append($"Make: {make}").Append(Environment.NewLine);
            
            carInfo.Append($"Model: {model}").Append(Environment.NewLine);
            
            carInfo.Append($"HorsePower: {horsePower}").Append(Environment.NewLine);

            carInfo.Append($"RegistartionNumber: {registrationNumber}");
            return carInfo.ToString();







        }

    }
}
