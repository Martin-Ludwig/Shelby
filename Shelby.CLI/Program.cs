// See https://aka.ms/new-console-template for more information
using OpenAI_API.Chat;

Console.WriteLine("Shelby by Ludwig");
Console.WriteLine("~");
Console.WriteLine();
Console.Write("Your Open AI Key = ");
string? openaiApiKey = Console.ReadLine();


//List<Character> Players = new()
//{
//    new Character("Alice", 100, 10),
//    new Character("Bob", 100, 7)
//};

//var c = new Combat(Players);

//c.Battle();

var api = new OpenAI_API.OpenAIAPI(openaiApiKey);

Conversation? chat = default;

if (await api.Auth.ValidateAPIKey())
{
    Console.WriteLine("~ OK\n");
    chat = api.Chat.CreateConversation();
} else
{
    Console.WriteLine("~ Api Key is not valid.\n");
    Console.WriteLine("To get an OpenAI API key, you will need to create an account on the OpenAI website https://openai.com/.");
    Console.WriteLine("1. Log in to your OpenAI account on their website.");
    Console.WriteLine("2. Navigate to the \"API\" section.");
    Console.WriteLine("3. Click on the \"Create API key\" button.");
    Console.WriteLine("4. Give your API key a name and select the permissions you want to grant to it.");
    Console.WriteLine("5. Click on the \"Create API key\" button again to generate your new API key.");
    Console.WriteLine("6. Copy your API key and store it in a safe place.");
    Console.WriteLine("7. Use your API key to authenticate your API requests to OpenAI.");

    Console.WriteLine("\n~end");
    Console.ReadLine();
    Environment.Exit(1);
}

Console.WriteLine("You > ");
string userInput = Console.ReadLine();
Console.WriteLine("");

chat.AppendUserInput(userInput);

string response = await chat.GetResponseFromChatbotAsync();
Console.WriteLine($"GPT > ");
Console.WriteLine($"{response}");

Console.WriteLine("\n~end");
Console.ReadLine();