// See https://aka.ms/new-console-template for more information

using System;
using Ticket_Office;

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









