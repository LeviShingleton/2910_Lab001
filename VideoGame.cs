using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2910_Lab001
{
    internal class VideoGame : IComparable<VideoGame>
    {
        string name;
        public string Name { get => name; }

        string platform;
        public string Platform { get => platform; }

        string year;
        public string Year { get => year; }

        string genre;
        public string Genre { get => genre; }

        string publisher;
        public string Publisher { get => publisher; }

        float na_sales;
        public float NA_Sales { get => na_sales; }

        float eu_sales;
        public float EU_Sales { get => eu_sales; }

        float jp_sales;
        public float JP_Sales { get => jp_sales; }

        float other_sales;
        public float Other_Sales { get => other_sales; }

        float global_sales;
        public float Global_Sales { get => global_sales; }

        /// <summary>
        /// Constructor using manual input
        /// </summary>
        /// <param name="Name">Game name</param>
        /// <param name="Platform">Gaming platform(s) that game is supported on</param>
        /// <param name="Year">Year that game was published</param>
        /// <param name="Genre">Category of game</param>
        /// <param name="Publisher">Name of publisher</param>
        /// <param name="NA_Sales">Proportion of sales in North America</param>
        /// <param name="EU_Sales">Proportion of sales in European Union</param>
        /// <param name="JP_Sales">Proportion of sales in Japan</param>
        /// <param name="Other_Sales">Proportion of sales in other countries</param>
        /// <param name="Global_Sales"></param>
        public VideoGame(string Name, string Platform, string Year, string Genre, string Publisher, float NA_Sales, float EU_Sales, float JP_Sales, float Other_Sales, float Global_Sales)
        {
            name = Name;
            platform = Platform;
            year = Year;
            genre = Genre;
            publisher = Publisher;
            na_sales = NA_Sales;
            eu_sales = EU_Sales;
            jp_sales = JP_Sales;
            other_sales = Other_Sales;
            global_sales = Global_Sales;
        }

        /// <summary>
        /// Constructor using CSV row as input
        /// </summary>
        /// <param name="dataArray">Input string array of separated attribute values</param>
        public VideoGame(string[] dataArray)
        {
            name = dataArray[0];
            platform = dataArray[1];
            year = dataArray[2];
            genre = dataArray[3];
            publisher = dataArray[4];
            na_sales = Convert.ToSingle(dataArray[5]);
            eu_sales = Convert.ToSingle(dataArray[6]);
            jp_sales = Convert.ToSingle(dataArray[7]);
            other_sales = Convert.ToSingle(dataArray[8]);
            global_sales = Convert.ToSingle(dataArray[9]);
        }

        /// <summary>
        /// Compares a VideoGame object to another VideoGame "other"
        /// </summary>
        /// <param name="other"></param>
        /// <returns>-1, if </returns>
        /// <exception cref="NotImplementedException"></exception>
        public int CompareTo(VideoGame? other)
        {
            return Name.CompareTo(other.Name);
        }

        public override string ToString()
        {
            return $"{Name}, {Platform}, {Year}, {Genre}, {Publisher}, {NA_Sales}, {EU_Sales}, {JP_Sales}, {Other_Sales}, {Global_Sales}"; 
        }
    }
}
