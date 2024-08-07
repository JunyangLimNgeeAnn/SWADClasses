// See https://aka.ms/new-console-template for more information


using SWADCode;
using System.Text.RegularExpressions;








bool carCreated = false;

while (!carCreated)
{
    car vehicle = new car();
    Console.WriteLine("Please key in details for the car:");
    Console.WriteLine("Please key in your license plate:");
    string carPlate = Console.ReadLine();

    Console.WriteLine("Please key in your car mileage(km):");
    int mileage;
    while (!int.TryParse(Console.ReadLine(), out mileage) || mileage < 0)
    {
        Console.WriteLine("Invalid mileage. Please enter a valid positive number:");
    }

    Console.WriteLine("Please key in your car model:");
    string carModel = Console.ReadLine();

    // Call AddDetails to check validity
    bool result = vehicle.validateDetails(carPlate, mileage, carModel);

    if (result)
    {
        if (vehicle.LicensePlateExists( carPlate))
        {
            Console.WriteLine("Error: License plate already exists in the system.");
            Console.WriteLine("Car details are invalid. Try again.");
            
        }
        else
        {
            vehicle.LicensePlate = carPlate;
            vehicle.CarMileage = mileage;
            vehicle.CarModel = carModel;
            vehicle.AddCarToCSV(vehicle);
            Console.WriteLine("Car Details:");
            Console.WriteLine($"License Plate: {vehicle.LicensePlate}");
            Console.WriteLine($"Mileage: {vehicle.CarMileage}");
            Console.WriteLine($"Model: {vehicle.CarModel}");
            carCreated = true; // Exit loop on successful creation
        }
        


        
    }
    
}
    


