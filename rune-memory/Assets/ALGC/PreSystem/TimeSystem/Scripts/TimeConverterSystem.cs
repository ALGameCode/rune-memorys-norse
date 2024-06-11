using System;
using UnityEngine;

namespace ALGC.timeSystem
{
    public static class TimeConverterSystem
    {
        /// <summary>
        /// Converts the total playtime from seconds to a formatted string in "HH:MM:SS" format.
        /// </summary>
        /// <param name="totalPlayTime">The total playtime in seconds.</param>
        /// <returns>The formatted playtime string.</returns>
        public static string ConvertTime(string totalPlayTime)
        {
            int timeInSeconds = int.Parse(totalPlayTime);

            // Convert to hours, minutes, and seconds
            int hours = timeInSeconds / 3600;
            int minutes = (timeInSeconds % 3600) / 60;
            int seconds = timeInSeconds % 60;

            // Create a TimeSpan with the converted time
            TimeSpan convertedTime = new TimeSpan(hours, minutes, seconds);

            // Format the time as a string in "HH:MM:SS" format
            string formattedTime = convertedTime.ToString(@"hh\:mm\:ss");

            return formattedTime;
        }

        /// <summary>
        /// Converts the total playtime from seconds to a formatted string in "HH:MM:SS" format.
        /// </summary>
        /// <param name="totalPlayTime">The total playtime in seconds as a float.</param>
        /// <returns>The formatted playtime string.</returns>
        public static string ConvertTime(float totalPlayTime)
        {
            int timeInSeconds = Mathf.RoundToInt(totalPlayTime);

            // Convert to hours, minutes, and seconds
            int hours = timeInSeconds / 3600;
            int minutes = (timeInSeconds % 3600) / 60;
            int seconds = timeInSeconds % 60;

            // Create a TimeSpan with the converted time
            TimeSpan convertedTime = new TimeSpan(hours, minutes, seconds);

            // Format the time as a string in "HH:MM:SS" format
            string formattedTime = convertedTime.ToString(@"hh\:mm\:ss");

            return formattedTime;
        }
    }
}