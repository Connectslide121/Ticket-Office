// See https://aka.ms/new-console-template for more information

using Ticket_Office;


string placeList = Methods.RandomListGenerator(8000);

Console.WriteLine("Welcome to The Ticket Office!");
Console.WriteLine();
Console.WriteLine("How old are you?");

int userAge = Methods.AskAge();

Console.WriteLine();
Console.WriteLine("What type of ticket would you like to purchase? Standing or seated?");

string userPlace = Methods.AskPlace();

Console.WriteLine();
Console.WriteLine("Thank you for your answers!");
Console.WriteLine("Searching for an available ticket number...");
await Task.Delay(1000);

int price = Methods.PriceSetter(userAge, userPlace);
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
        await Task.Delay(100);
    }

    else
    {
        Console.WriteLine($"Your ticker number is {placeNumber}");
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
Console.WriteLine($"List of unavailable places: {placeListWithoutLastComma.Remove(0, 1)}");
Console.ReadKey();


