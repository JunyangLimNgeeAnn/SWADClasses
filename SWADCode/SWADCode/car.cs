using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace SWADCode
{
    internal class car
    {
        public string LicensePlate { get; set; }
        public int CarMileage { get; set; }
        public string CarModel { get; set; }

        public int carrentalfee { get; set; }

        public string description { get; set; }
        public car()
        {

        }

        
        public car(string lp, int m, string cm , string d)
        {
            LicensePlate = lp; 
            CarMileage = m;   
            CarModel = cm;   
            
        }

        public bool validateDetails(string licensePlate, int carMileage, string carModel)
        {
            
            licensePlate = NormalizeLicensePlate(licensePlate);


            if (!ValidateLicensePlate(licensePlate))
            {
                Console.WriteLine("Invalid License Plate. It should be alphanumeric and 1-7 characters long.");
                return false;
            }

            if (carMileage < 0)
            {
                Console.WriteLine("Invalid Car Mileage. It should be a positive number.");
                return false;
            }

            if (string.IsNullOrWhiteSpace(carModel))
            {
                Console.WriteLine("Car Model Invalid");
                return false;

            }

            Console.WriteLine("Car Details Are Valid");
            return true;
        }


        public bool ValidateLicensePlate(string licensePlate)
        {
            // Regex for the format Sxx #### y
            Regex regex = new Regex(@"^S[A-HJ-NP-Z]{2} \d{4} [A-Z]$");
            return regex.IsMatch(licensePlate);
        }

        static string NormalizeLicensePlate(string licensePlate)
        {
            // Add space between alphanumeric and digits for normalization
            // Adjust as needed to match your specific format requirements
            if (Regex.IsMatch(licensePlate, @"^S[A-HJ-NP-Z]{2}\d{4}[A-Z]$"))
            {
                return $"{licensePlate.Substring(0, 3)} {licensePlate.Substring(3, 4)} {licensePlate.Substring(7, 1)}";
            }
            return licensePlate;
        }


        public void AddCarToCSV(car car)
        {
            string filePath = "carexcel.csv";
            // Prepare the car details as a CSV line
            string csvLine = $"{car.LicensePlate},{car.CarMileage},{car.CarModel}";

            // Append the car details to the CSV file
            try
            {
                using (StreamWriter writer = new StreamWriter(filePath, append: true))
                {
                    writer.WriteLine(csvLine);
                }
                Console.WriteLine("Car sent to system , awaiting approval.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error writing to CSV file: {ex.Message}");
            }
        }


        public bool LicensePlateExists(string licensePlate)
        {
            string filePath = "carexcel.csv";
            // Read all lines from the CSV file
            string[] lines = File.ReadAllLines(filePath);

            // Skip the header line and check if any subsequent line contains the license plate
            return lines.Skip(1).Any(line => line.Split(',')[0].Equals(licensePlate, StringComparison.OrdinalIgnoreCase));
        }






    }
}
