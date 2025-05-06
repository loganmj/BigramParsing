while (true)
{
    // Print title
    PrintTitleAndDescription();

    // Prompt user for command input
    var command = GetCommandFromUser();

    // TEST: Show the command.
    Console.WriteLine($"User entered command: {command}");
    Console.WriteLine("");
}

// Prints the title and app description.
void PrintTitleAndDescription()
{
    Console.WriteLine("--------------------------------------------------");
    Console.WriteLine("Bigram Parser");
    Console.WriteLine("--------------------------------------------------");
    Console.WriteLine("Parses text from a string or file and creates a histogram of occurances of pairs of words.");
    Console.WriteLine("--------------------------------------------------");
}

// Prints the command menu.
void PrintCommandMenu()
{
    Console.WriteLine("Commands: ");
    Console.WriteLine("String | Allows the user to enter a string value.");
    Console.WriteLine("File | Allows the user to enter a file path.");
    Console.WriteLine("Exit | Exits the program.");
    Console.WriteLine();
}

// Prints the menu and gets the command input from the user.
string GetCommandFromUser()
{
    // Print menu
    PrintCommandMenu();

    // Get selection from user
    Console.Write("Enter a command: ");
    var commandInput = Console.ReadLine();

    return commandInput;
}