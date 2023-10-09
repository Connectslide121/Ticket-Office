// See https://aka.ms/new-console-template for more information

using System;
using System.Text.Json;
using Ticket_Office;

string concertData = File.ReadAllText("C:\\Users\\Jon\\Desktop\\Lexicon .NET\\Assignments\\Week 3 - Ticket Office\\Ticket Office\\Ticket Office\\concert_data.json");

List<Concert> concerts = JsonSerializer.Deserialize<List<Concert>>(concertData);

//*****************************************************************************//

DateTime currentDate = DateTime.Now;

List<Concert> dateSorted = concerts
    .Where(item => item.Date >= currentDate)
    .OrderBy(item => item.Date)
    .ToList();

string listDateSorted = "Future concerts sorted by date:\n";
foreach (Concert concert in dateSorted)
{
    listDateSorted += $"{concert.Date} @{concert.BeginsAt}:00 - ID:{concert.Id}\t- Reduced venue {concert.ReducedVenue}\t- {concert.Performer}\t- {concert.FullCapacitySales}SEK\n";
}
Console.WriteLine(listDateSorted);

//*****************************************************************************//

List<Concert> reducedVenue = concerts
    .Where(item => item.ReducedVenue == true)
    .ToList();

string listReducedVenue = "Concerts with reduced venue:\n";
foreach (Concert concert in reducedVenue)
{
    listReducedVenue += $"{concert.Date} @{concert.BeginsAt}:00 - ID:{concert.Id}\t- {concert.Performer}\t- {concert.FullCapacitySales}SEK\n";
}
Console.WriteLine(listReducedVenue);

//*****************************************************************************//

List<Concert> concerts2024 = concerts
    .Where (item => item.Date.Year == 2024)
    .ToList ();

string listConcerts2024 = "Concerts in 2024:\n";
foreach (Concert concert in concerts2024)
{
    listConcerts2024 += $"{concert.Date} @{concert.BeginsAt}:00 - ID:{concert.Id}\t- Reduced venue {concert.ReducedVenue}\t- {concert.Performer}\t- {concert.FullCapacitySales}SEK\n";
}
Console.WriteLine (listConcerts2024);

//*****************************************************************************//

List<Concert> topRevenue = concerts
    .OrderByDescending(item => item.FullCapacitySales)
    .Take(5)
    .ToList();

string listTopRevenue = "Top 5 full capacity revenue concerts:\n";
foreach (Concert concert in topRevenue)
{
    listTopRevenue += $"{concert.Date} @{concert.BeginsAt}:00 - ID:{concert.Id}\t- Reduced venue {concert.ReducedVenue}\t- {concert.Performer}\t- {concert.FullCapacitySales}SEK\n";
}
Console.WriteLine(listTopRevenue);

//*****************************************************************************//

List<Concert> onFriday = concerts
    .Where((concert) => concert.Date.DayOfWeek == DayOfWeek.Friday)
    .ToList();

string listOnFriday = "Concerts taking place on Fridays:\n";
foreach (Concert concert in onFriday)
{
    listOnFriday += $"{concert.Date} @{concert.BeginsAt}:00 - ID:{concert.Id}\t- Reduced venue {concert.ReducedVenue}\t- {concert.Performer}\t- {concert.FullCapacitySales}SEK\n";
}
Console.WriteLine(listOnFriday);

//*****************************************************************************//

Console.ReadKey();

TicketSalesManager.RandomListGenerator(7500);

Console.WriteLine("Welcome to The Ticket Office!");
Console.WriteLine();
Console.WriteLine("How old are you?");

int customerAge = Methods.GetCustomerAge();


Console.WriteLine();
Console.WriteLine("What's your place preference? Standing or seated?");

PlaceOptions.CustomerPlacePreference customerPlacePreference = Methods.GetCustomerPlacePreference();

Console.WriteLine();
Console.WriteLine("Generating ticket...");
await Task.Delay(1000);

Ticket ticket = new Ticket(customerAge, customerPlacePreference);
TicketSalesManager.ticketSalesManager.AddTicket(ticket);

Console.WriteLine();
Console.WriteLine("Here are the details of your ticket:");
Console.WriteLine();
Console.WriteLine($"Ticket Number: \t{ticket.Number}");
Console.WriteLine($"Age: \t\t{ticket.Age}");
Console.WriteLine($"Place: \t\t{ticket.Place}");
Console.WriteLine($"Price: \t\t{Convert.ToString(ticket.Price())} SEK");
Console.WriteLine($"Taxes: \t\t{Convert.ToString(ticket.Tax())} SEK");
Console.WriteLine();
await Task.Delay(1000);

Console.WriteLine("Press any key to access the Sales Manager information");
Console.ReadKey();

Console.WriteLine();
Console.WriteLine($"Total amount of tickets sold: {Convert.ToString(TicketSalesManager.ticketSalesManager.AmountOfTickets())}");
Console.WriteLine($"Seated: {Convert.ToString(TicketSalesManager.ticketSalesManager.AmountOfTicketsSeated())}");
Console.WriteLine($"Standing: {Convert.ToString(TicketSalesManager.ticketSalesManager.AmountOfTicketsStanding())}");
Console.WriteLine();
Console.WriteLine($"Total revenue: {Convert.ToString(TicketSalesManager.ticketSalesManager.SalesTotal())} SEK");
Console.WriteLine($"Total taxes to pay: {Convert.ToString(TicketSalesManager.ticketSalesManager.TaxTotal(TicketSalesManager.ticketSalesManager.SalesTotal()))} SEK");

Console.ReadKey();









