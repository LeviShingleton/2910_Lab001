using System.Globalization;

namespace _2910_Lab001
{
    internal class Program
    {
        const string filePath = @"..\..\..\videogames.csv";
        const string lineBreak = "\n-----------------------------------\n";
        // Used for Title Case string formatting; matches CSV data
        static TextInfo CultureText = new CultureInfo("en-us", false).TextInfo;

        static List<VideoGame> csvGames = new List<VideoGame>();
        // Collection of all distinct publisher names; used in PublisherData() method
        static List<string> publisherNames = new List<string>();
        // Collection of all distinct genre names; used in GenreData() method
        static List<string> genreNames = new List<string>();

        static void Main(string[] args)
        {
            try
            {
                string[] data = File.ReadAllLines(filePath);

                for (int i = 1; i < data.Length - 1; i++)
                {
                    string[] attributes = data[i].Split(",");
                    csvGames.Add(new VideoGame(attributes));
                }
            }
            catch (IOException e)
            {
                Console.WriteLine("The file could not be read:");
                Console.WriteLine(e.Message);
                return;
            }

            // Store distinct column values for publisher, 
            publisherNames = csvGames.Select(x => x.Publisher).Distinct().OrderBy(x => x).ToList();
            genreNames = csvGames.Select(x => x.Genre).Distinct().OrderBy(x => x).ToList();

            // Sort the list entries (rows) by title, ascending
            // VideoGame : IComparable | VideoGame.ToString() should return name
            csvGames.Sort();

            PublisherData();
            Console.Clear();
            GenreData();
            Console.Clear();
        }


        /// <summary>
        /// Looping prompt for user to input a publisher to filter search. Prints alphabetized list of games and proportion of games published by publisher.
        /// </summary>
        static void PublisherData()
        {
            // Prompt loop
            while (true)
            {
                Console.WriteLine("User Publisher Query : Please enter the name of a publisher to search for its games.");
                Console.WriteLine("Enter \'exit\' to leave search.");
                string input = CultureText.ToTitleCase(Console.ReadLine());
                Console.Clear();
                // Input validation loop; accept only entries found in csv data
                while (!publisherNames.Contains(input))
                {
                    if (input.ToLower().Equals("exit"))
                    {
                        Console.WriteLine(lineBreak);
                        return;
                    }
                    Console.WriteLine($"Publisher \'{input}\' could not be found. Please try again.");
                    input = CultureText.ToTitleCase(Console.ReadLine());
                }

                // Get list by publisher, ordered by publisher
                IEnumerable<VideoGame> queryList = csvGames.Where(game => game.Publisher.Equals(input));
                List<VideoGame> ByPublisherList = queryList.OrderBy(game => game.Name).ToList();

                PrintQueryList(ByPublisherList);

                // Proportion meeting criteria
                float proportion = ((float)ByPublisherList.Count / csvGames.Count) * 100;
                // Format calculated float to print with 2 decimal places
                string proportionString = proportion.ToString("F2");
                // Print results to screen
                Console.WriteLine(lineBreak);
                Console.WriteLine($"Out of the {csvGames.Count} games, {ByPublisherList.Count} of them were published by {input}.");
                Console.WriteLine($"Proportion of games developed by {input}: {proportionString}%");

                
                input = "";
                Console.WriteLine(lineBreak);
            }
        }

        /// <summary>
        /// Looping prompt for user to input a genre to filter search. Prints alphabetized list of games and proportion of games within input genre.
        /// </summary>
        static void GenreData()
        {
            string input = default;
            // Prompting loop
            while (true)
            {
                Console.WriteLine("User Genre Query : Please enter the a genre to search for its games.");
                Console.WriteLine("Enter \'exit\' to leave search.");
                input = CultureText.ToTitleCase(Console.ReadLine());
                Console.Clear();
                // Input validation; accept only entries found in csv data
                while (!genreNames.Contains(input))
                {
                    if (input.ToLower().Equals("exit"))
                    {
                        Console.WriteLine(lineBreak);
                        return;
                    }
                    Console.WriteLine($"Genre \'{input}\' could not be found. Please try again.");
                    input = Console.ReadLine();
                }
                
                // Get list of entries of genre, ordered alphabetically by name
                IEnumerable<VideoGame> queryList = csvGames.Where(game => game.Genre.Equals(input));
                List<VideoGame> ByGenreList = queryList.OrderBy(game => game.Name).ToList();

                PrintQueryList(ByGenreList);

                // Calculate proportion, format to 00.00%; print results
                float proportion = ((float)ByGenreList.Count / csvGames.Count) * 100;
                string proportionString = proportion.ToString("F2");
                Console.WriteLine(lineBreak);
                Console.WriteLine($"Out of the {csvGames.Count} games, {ByGenreList.Count} of them are in the \'{input}\' genre.");
                Console.WriteLine($"Proportion of games in the genre \'{input}\' : {proportionString}%");

                input = "";
                Console.WriteLine(lineBreak);
            }
        }

        /// <summary>
        /// Prints all entries of VideoGame list using VideoGame.ToString().
        /// TODO: Implement method using generic.
        /// </summary>
        /// <param name="queryList">The input list to print from.</param>
        static void PrintQueryList(List<VideoGame> queryList)
        {
            foreach (VideoGame game in queryList)
            {
                Console.WriteLine(game.ToString());
            }
        }
    }
}