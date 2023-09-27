// See https://aka.ms/new-console-template for more information

using Ticket_Office;

Console.WriteLine("Welcome to The Ticket Office!");
Console.WriteLine();
Console.WriteLine("How old are you?");

int userAge = Methods.AskAge();

Console.WriteLine();
Console.WriteLine("What type of ticket would you like to purchase? Standing or seated?");

string userPlace = Methods.AskPlace();

Console.WriteLine();
Console.WriteLine("Thank you for your answers!");
Console.WriteLine();

int price = Methods.PriceSetter(userAge, userPlace);
decimal tax = Methods.TaxCalculator(price);
int rng = Methods.TicketNumberGenerator();

Console.WriteLine("Here are the details of your ticket:");
Console.WriteLine();
Console.WriteLine($"Price: \t\t{price} SEK");
Console.WriteLine($"Taxes: \t\t{tax} SEK");
Console.WriteLine($"Ticket Number: \t{rng}");
Console.ReadKey();


