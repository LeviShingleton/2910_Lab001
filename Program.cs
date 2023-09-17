namespace _2910_Lab001
{
    internal class Program
    {
        const string filePath = @"..\..\..\videogames.csv";

        static List<VideoGame> csvGames = new List<VideoGame>();

        static int topQueryDepth = 5;

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

            // Sort the list entries (rows) by title, ascending
            csvGames.Sort();

            // Empty dictionary to hold platform-keyed lists of videogames
            Dictionary<string, List<VideoGame>> byPlatformDict = new();
            
            // Populate dictionary using platforms as keys
            foreach (var group in csvGames.GroupBy(x => x.Platform).OrderBy(x => x.Key))
            {
                byPlatformDict.Add(group.Key, group.ToList());
            }

            // Fetch topQueryDepth number of entries from byPlatformDict keys (platforms); prints out result to console
            foreach (var platform in byPlatformDict.Keys)
            {
                var platformTop = GetTopXInGroup(byPlatformDict, platform, topQueryDepth);
                Console.WriteLine($"-----The top {platformTop.Count} global best-selling games for {platform}-----");
                PrintQueryList(platformTop);
                Console.WriteLine();
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

        /// <summary>
        /// Returns the top takeCount entries in key category of input dictionary<string, List<VideoGame>>.
        /// </summary>
        /// <param name="inDict">Reference to dictionary to query</param>
        /// <param name="key">The column/category to query</param>
        /// <param name="takeCount">The number of entries to take from the top of the sorted column</param>
        /// <returns></returns>
        static List<VideoGame> GetTopXInGroup(Dictionary<string, List<VideoGame>> inDict, string key, int takeCount)
        {
            return inDict[key].OrderBy(list => list.Global_Sales).Reverse().Take(takeCount).ToList();
        }
    }
}