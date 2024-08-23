using Microsoft.Data.Sqlite;

string connectionString = @"Data Source=habit-Tracker.db";

using (var connection = new SqliteConnection(connectionString))
{
    connection.Open();
    var tableCmd = connection.CreateCommand();

    tableCmd.CommandText =
        @"CREATE TABLE IF NOT EXISTS drinking_water (
            Id INTEGER PRIMARY KEY AUTOINCREMENT,
            Date TEXT,
            Quantity INTEGER
            )";

    tableCmd.ExecuteNonQuery();

    connection.Close();
}

GetUserInput();

static void GetUserInput()
{
    Console.Clear();
    bool closeApp = false;
    while (closeApp == false)
    {
        Console.WriteLine("\n\nMAIN MENU");
        Console.WriteLine("\nWhat would you like to do?");
        Console.WriteLine("\nType 0 to Close Application.");
        Console.WriteLine("Type 1 to View All Records.");
        Console.WriteLine("Type 2 to Insert Record.");
        Console.WriteLine("Type 3 to Delete Record.");
        Console.WriteLine("Type 4 to Update Record.");
        Console.WriteLine("--------------------------------------\n");

        string input = Console.ReadLine();

        switch (input)
        {
            case "0":
                Console.WriteLine("\nGoodbye!\n");
                closeApp = true;
                break;
            //case 1:
            //    GetAllRecords();
            //    break;
            case "2":
                Insert();
                break;
            //case 3:
            //    Delete();
            //    break;
            //case 4:
            //    Update();
            //    break;
            default:
                Console.WriteLine("\nInvalid Command. PLease type a number from 0 to 4.\n");
                break;
        }
    }
}

static void Insert()
{
    string connectionString = @"Data Source=habit-Tracker.db";

    string date = GetDateInput();

    int quantity = GetNumberInput("\n\nPlease insert a number of glasses or other measure fo your choise (no decimals allowed)\n\n");

    using (var connection = new SqliteConnection(connectionString))
    {
        connection.Open();
        var tableCmd = connection.CreateCommand();

        tableCmd.CommandText =
           $"INSERT INTO drinking_water(date, quantity) VALUES ('{date}',{quantity})";

        tableCmd.ExecuteNonQuery();

        connection.Close();
    }
}

static int GetNumberInput(string str)
{
    Console.WriteLine(str);

    string numInput = Console.ReadLine();

    if (numInput == "0") GetUserInput();

    int finalInput = Convert.ToInt32(numInput);

    return finalInput;

}

static string GetDateInput()
{
    Console.WriteLine("\n\nPlease insert the date: (Format: dd-mm-yy). Type 0 to return to main menu.");

    string dateInput = Console.ReadLine();

    if (dateInput == "0") GetUserInput();

    return dateInput;
}