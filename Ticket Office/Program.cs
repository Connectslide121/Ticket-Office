// See https://aka.ms/new-console-template for more information

using Ticket_Office;


string placeList = Methods.RandomListGenerator(7500);

Console.WriteLine("Welcome to The Ticket Office!");
Console.WriteLine();
Console.WriteLine("How old are you?");

int userAge = Methods.GetCustomerAge();

Console.WriteLine();
Console.WriteLine("What's your place preference? Standing or seated?");

PlaceOptions.CustomerPlacePreference customerPlacePreference;
customerPlacePreference = Methods.GetCustomerPlacePreference();

Console.WriteLine();
Console.WriteLine($"Your place of choice is: {customerPlacePreference}");
await Task.Delay(1000);

Console.WriteLine();
Console.WriteLine("Searching for an available ticket number...");
await Task.Delay(1000);

int price = Methods.PriceSetter(userAge, customerPlacePreference);
decimal tax = Methods.TaxCalculator(price);
int placeNumber;
bool checkAvailability;

do
{
    placeNumber = Methods.TicketNumberGenerator();
    checkAvailability = Methods.CheckPlaceAvailability(placeList, placeNumber);

    if (checkAvailability == false)
    {
        Console.WriteLine($"Sorry, the selected ticket number ({placeNumber}) is not available");
        await Task.Delay(20);
    }

    else
    {
        Console.WriteLine($"Your ticker number is {placeNumber}!");
    }

}while (checkAvailability == false);

Console.WriteLine();
Console.WriteLine("Here are the details of your ticket:");
Console.WriteLine();
Console.WriteLine($"Price: \t\t{price} SEK");
Console.WriteLine($"Taxes: \t\t{tax} SEK");
Console.WriteLine($"Ticket Number: \t{placeNumber}");
Console.WriteLine();
await Task.Delay(1000);

Console.WriteLine("Press any key if you want to see the list of places that are already taken");
Console.ReadKey();
placeList = Methods.AddPlace(placeList, placeNumber);
string placeListWithoutLastComma = placeList.Substring(0, placeList.Length -1);
string placeListWithoutLastFirstComma = placeListWithoutLastComma.Remove(0, 1);
Console.WriteLine();
Console.WriteLine($"List of unavailable places: {placeListWithoutLastFirstComma}");
Console.ReadKey();


