using System;

class Program
{
    static void Main(string[] args)
    {
        string _scripture = "She is more precious than rubies: and all the things thou canst desire are not to be compared unto her. Length of days is in her right hand; and in her left hand ariches and honour. Her ways are ways of pleasantness, and all her paths are peace.";

        string _trimmedScripture = _scripture.Trim();
        string[] _splitScripture = _trimmedScripture.Split();
        Console.WriteLine(_splitScripture[47]);
        Console.WriteLine(_splitScripture.Length);
    }
}