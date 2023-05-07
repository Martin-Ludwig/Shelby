// See https://aka.ms/new-console-template for more information
using Shelby.Library.Model;
using Shelby.Library.System;

Console.WriteLine("Shelby by Ludwig");
Console.WriteLine("~");
Console.WriteLine();

List<Character> Players = new()
{
    new Character("Alice", 100, 10),
    new Character("Bob", 100, 7)
};

var c = new Combat(Players);

c.Battle();

Console.WriteLine("end");