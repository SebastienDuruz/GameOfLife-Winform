/// Autor : Sébastien Duruz
/// Date : 22.06.2021
/// Description : Save the settings of the user to text file.

using System;
using System.Drawing;

namespace sebduruz_GameOfLife
{
    /// <summary>
    /// Class SettingsSaver
    /// </summary>
    public class SettingsSaver
    {
        /// <summary>
        /// Property : The file path of the config file
        /// </summary>
        private string FilePath { get; set; }

        /// <summary>
        /// Property : The number of cells for each axes
        /// </summary>
        public int CellNumber { get; set; }

        /// <summary>
        /// Property : The size of the cell
        /// </summary>
        public int CellSize { get; set; }

        /// <summary>
        /// Property : The color of the cell
        /// </summary>
        public Color CellColor { get; set; }

        /// <summary>
        /// Default Constructor
        /// </summary>
        public SettingsSaver()
        {
            this.FilePath = $"{Environment.CurrentDirectory}/settings.txt";
        }

        /// <summary>
        /// Get the settings
        /// </summary>
        /// <returns>A string with content of the last indexation path</returns>
        public bool GetSettings()
        {
            string content = AccessFile.ReadContent(this.FilePath);

            // Return content only if not empty
            if (content != null)
            {
                string[] splitedContent = content.Split(',');

                try
                {
                    this.CellNumber = Int32.Parse(splitedContent[0]);
                    this.CellSize = Int32.Parse(splitedContent[1]);
                    this.CellColor = Color.FromArgb(Int32.Parse(splitedContent[2]));

                    return true;
                }
                catch(Exception ex)
                {
                    Console.Error.WriteLine($"GetSettings throw at {DateTime.Now} Exception : {ex.Message}\n{ex.StackTrace}");
                    return false;
                }
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// Add the lastIndexed to file
        /// </summary>
        /// <param name="lastIndexed">The lastindexed folder source</param>
        public void SetSettings(int cellNumber, int cellSize, Color livingCellColor)
        {
            AccessFile.WriteContent(this.FilePath, $"{cellNumber},{cellSize},{livingCellColor.ToArgb()}");
        }
    }
}
