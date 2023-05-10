// See https://aka.ms/new-console-template for more information
using OpenAI_API.Chat;

Console.ForegroundColor = ConsoleColor.DarkGray;
Console.WriteLine("Shelby by Ludwig");
Console.WriteLine("~");
Console.WriteLine();

Console.ForegroundColor = ConsoleColor.Yellow;
Console.Write("Your Open AI Key = ");
Console.ForegroundColor = ConsoleColor.Gray;
string? openaiApiKey = Console.ReadLine();

var api = new OpenAI_API.OpenAIAPI(openaiApiKey);

Conversation? chat = default;

if (await api.Auth.ValidateAPIKey())
{
    Console.ForegroundColor = ConsoleColor.Yellow;
    Console.WriteLine("~ OK\n");
    chat = api.Chat.CreateConversation();
} else
{
    Console.ForegroundColor = ConsoleColor.Yellow;
    Console.WriteLine("~ Api Key is not valid.\n");

    Console.ForegroundColor = ConsoleColor.Gray;
    Console.WriteLine("To get an OpenAI API key, you will need to create an account on the OpenAI website https://openai.com/.");
    Console.WriteLine("1. Log in to your OpenAI account on their website.");
    Console.WriteLine("2. Navigate to the \"API\" section.");
    Console.WriteLine("3. Click on the \"Create API key\" button.");
    Console.WriteLine("4. Give your API key a name and select the permissions you want to grant to it.");
    Console.WriteLine("5. Click on the \"Create API key\" button again to generate your new API key.");
    Console.WriteLine("6. Copy your API key and store it in a safe place.");
    Console.WriteLine("7. Use your API key to authenticate your API requests to OpenAI.");

    Console.ForegroundColor = ConsoleColor.DarkGray;
    Console.WriteLine("\n~ end");
    Console.ReadLine();
    Environment.Exit(1);
}

while (true)
{
    // Read user input
    if (chat.Messages.Count < 3)
    {
        Console.ForegroundColor = ConsoleColor.Gray;
        Console.WriteLine("You > ");
    }

    Console.ForegroundColor = ConsoleColor.White;
    string? userInput = Console.ReadLine();
    Console.WriteLine("");

    if (userInput == "exit")
    {
        break;
    }

    chat.AppendUserInput(userInput);

    // Write response
    await GptSaysAsync();
}

Console.ForegroundColor = ConsoleColor.DarkGray;
Console.WriteLine("\n~ end");
Console.ReadLine();

async Task GptSaysAsync()
{
    if (chat.Messages.Count < 2)
    {
        Console.ForegroundColor = ConsoleColor.DarkCyan;
        Console.WriteLine($"GPT > ");
    }

    Console.ForegroundColor = ConsoleColor.Cyan;
    await foreach (var res in chat.StreamResponseEnumerableFromChatbotAsync())
    {
        Console.Write(res);
    }
    Console.WriteLine("\n");
}