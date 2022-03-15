/*
 * This program is like typical keynote, but.... With some more technical details.
 */
string path = "D:/TEXT.txt";

Dictionary<string, string> keyNotes = new Dictionary<string, string>()
{
    { "Monday","Today i`m developing a site on ASP." },
    { "Tuesday","Today i`m fixing some bags." },
    { "Wednesday","Today i`m prepare pre-realese version." },
};

string yourNote;

string userName = null; int applicationUsing = 0; string userChoose = null;

App:
if(userName == null)
    Console.Write("Hello! How can i call you? \n>"); userName = Console.ReadLine();
if (userName != null)
    Console.WriteLine("Hello, {0}! Nice to meet you again!", userName);

if(applicationUsing == 0)
    Console.WriteLine("Oh... It`s your first time here! You open this application {0} times", applicationUsing);

FileWrt:
Console.Write("Do you want to read your notes or continue? \n>"); userChoose = Console.ReadLine();
if (userChoose == "No" || userChoose == "no" || userChoose == "NO")
{

    string noteName = null; string noteValue = null;

    Console.Write("Enter Note name: \n>"); noteName = Console.ReadLine();
    Console.Write("Enter Note: \n>"); noteValue = Console.ReadLine();

    keyNotes.Add(noteName, noteValue);
}
else if (userChoose == "yes" || userChoose == "YES" || userChoose == "Yes")
{
    foreach (var notes in keyNotes)
    {
        Console.WriteLine($"{notes.Key}: {notes.Value}");
    }
    goto FileWrt;
}
else 
{
    goto EndApp;
}

Console.Write("Do you finish? \n>"); userChoose= Console.ReadLine();

EndApp:
if (userChoose == "No" || userChoose == "no" || userChoose == "NO")
    goto App;
else if (userChoose == "yes" || userChoose == "YES" || userChoose == "Yes")
{
    Console.Write("Do you want to rewrite your file? \n>"); userChoose = Console.ReadLine();
    if (userChoose == "yes" || userChoose == "YES" || userChoose == "Yes")
    {
        using (StreamWriter writer = new StreamWriter(path, false))
        {
            foreach (var notes in keyNotes)
            {
                await writer.WriteLineAsync($"{notes.Key}: {notes.Value}");
            }
        }
    }
    else if (userChoose == "No" || userChoose == "no" || userChoose == "NO")
    {
        using (StreamWriter writer = new StreamWriter(path, true))
        {
            foreach (var notes in keyNotes)
            {
                await writer.WriteAsync($"{notes.Key}: {notes.Value}");
            }
        }
    }
    applicationUsing++;
    goto App;
}
