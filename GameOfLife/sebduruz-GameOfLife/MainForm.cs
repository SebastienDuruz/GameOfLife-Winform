/// Autor : Sébastien Duruz
/// Date : 16.06.2021
/// Description : An implementation of the Conway's Game of life as describe here https://en.wikipedia.org/wiki/Conway%27s_Game_of_Life

using sebduruz_GameOfLife.Resources;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Windows.Forms;

namespace sebduruz_GameOfLife
{
    /// <summary>
    /// Class MainForm
    /// </summary>
    public partial class MainForm : Form
    {
        /// <summary>
        /// Const : The tag representing dead cells
        /// </summary>
        private const string DEAD_CELL_TAG = "DEAD";

        /// <summary>
        /// Const : The tag representing living cells
        /// </summary>
        private const string LIVING_CELL_TAG = "LIVING";

        /// <summary>
        /// Const : The tag representing changing cells (need to update after calculations)
        /// </summary>
        private const string UPDATE_CELL_TAG = "UPDATE";

        /// <summary>
        /// Const : The X_Position of a Coords
        /// </summary>
        private const byte X_POSITION = 0;

        /// <summary>
        /// Const : The Y_Position of a Coords
        /// </summary>
        private const byte Y_POSITION = 1;

        /// <summary>
        /// Const : The interval of speed to consider beetween each value of speed bar
        /// </summary>
        private const byte SPEED_INTERVAL = 10;

        /// <summary>
        /// Const : The size of the stack containing the last cycles of the generation
        /// </summary>
        private const byte STACK_SIZE = 100;

        /// <summary>
        /// Const : The string representing French language
        /// </summary>
        private const string LANG_FR = "FR";

        /// <summary>
        /// Const : The string representing English language
        /// </summary>
        private const string LANG_EN = "EN";

        /// <summary>
        /// Const : The default color for dead cells
        /// </summary>
        private Color DEAD_CELL_COLOR = Color.White;

        /// <summary>
        /// Const : The default color for living cells
        /// </summary>
        private Color LIVING_CELL_COLOR = Color.Black;

        /// <summary>
        /// Const : The default color of the borders;
        /// </summary>
        private Color BORDERS_CELL_COLOR = Color.Black;

        /// <summary>
        /// Atribut : The number of cells that gameArea contains (axes X and Y)
        /// </summary>
        private int _cellsNumber;

        /// <summary>
        /// Atribut : The speed of the cycle (ms)
        /// </summary>
        private int _cycleSpeed = 50;

        /// <summary>
        /// atribut : The size of each cells
        /// </summary>
        private int _cellSize = 14;

        /// <summary>
        /// Atribut : The cells represented by an array of labels
        /// </summary>
        private Button[,] _buttons;

        /// <summary>
        /// Atribut : The informations about the imported cells
        /// </summary>
        private List<string> _importedCells = new List<string>();

        /// <summary>
        /// Atribut : Check if the generation is running or not
        /// </summary>
        private bool _running = false;

        /// <summary>
        /// Atribut : The current number of cycle executed
        /// </summary>
        private int _currentCycle = 0;

        /// <summary>
        /// Atribut : The current number of living cells
        /// </summary>
        private int _currentLivingCells = 0;

        /// <summary>
        /// Atribut : The minimum number of living cells 
        /// </summary>
        private int _currentMaxLivingCells = 0;

        /// <summary>
        /// Atribut : The maximum number of living cells
        /// </summary>
        private int _currentMinLivingCells = 0;

        /// <summary>
        /// Atribut : The object that will get / set settings to / from text file
        /// </summary>
        private SettingsSaver _settings = new SettingsSaver();

        /// <summary>
        /// Atribut : The Stack that contains the differents points to build the last cycles of the generation
        /// </summary>
        private Stack<List<string>> _lastCycles = new Stack<List<string>>(STACK_SIZE);

        /// <summary>
        /// Atribut : The current language used by the PC
        /// </summary>
        private string _currentLanguage;

        /// <summary>
        /// Default Constructor
        /// </summary>
        public MainForm()
        {
            // Initialise the form componants
            InitializeComponent();

            // Get the current language of the pc
            this._currentLanguage = GetCurrentLanguage();

            // Set the language string to file
            this.SetLanguage();

            // Modify initial settings
            this._cellsNumber = this.CalculateCellsNumber();

            // Update the settings if they exists
            this.SetSettings();

            // Set the default backColor for cell color label (show the current color to player)
            this.colorLabel.BackColor = LIVING_CELL_COLOR;
            this.cellSizeNumericValue.Value = this._cellSize;

            // Initialise a empty GameArea
            this.InitialiseGameArea();
        }

       

        /// <summary>
        /// Calculate the cell number that can be displayed foreach axe
        /// </summary>
        /// <returns>The number of cells calculated</returns>
        private int CalculateCellsNumber()
        {
            return this.gameAreaPanel.Width / this._cellSize;
        }

        /// <summary>
        /// Initialise the gameArea
        /// </summary>
        private void InitialiseGameArea()
        {
            // Desactivate the functions that can make the process throw errors
            this.importToolStripMenuItem.Enabled = false;
            this.exportToolStripMenuItem.Enabled = false;

            // Show the loading elements
            this.loadingProgressBar.Visible = true;
            this.infoLabel.Visible = true;
            this.loadingPanel.Visible = true;

            // Create the new grid
            this.createGridBackgroundWorker.RunWorkerAsync();
        }

        /// <summary>
        /// Reset the game area with empty cells
        /// </summary>
        private void ResetGameArea()
        {
            // Modify each cell to correspond with empty area
            for (int i = 0; i < this._cellsNumber; ++i)
            {
                for (int j = 0; j < this._cellsNumber; ++j)
                {
                    // Reset the necessary data of the cell
                    this._buttons[j, i].BackColor = DEAD_CELL_COLOR;
                    this._buttons[j, i].FlatAppearance.MouseOverBackColor = LIVING_CELL_COLOR;
                    this._buttons[j, i].Tag = DEAD_CELL_TAG;
                }
            }
        }

        /// <summary>
        /// Reset the game area after having calculate the cell size
        /// </summary>
        private void ResetGameAreaWithNewSize()
        {
            this._cellsNumber = this.CalculateCellsNumber();

            this.InitialiseGameArea();
        }

        /// <summary>
        /// Occured when user click Button
        /// </summary>
        /// <param name="sender">The object that trigger the event</param>
        /// <param name="e">Datas used by the event</param>
        private void LabelClicked(object sender, EventArgs e)
        {
            if (!this._running)
            {
                // If the cell is dead
                if (((Button)sender).Tag.ToString() == DEAD_CELL_TAG)
                {
                    ((Button)sender).BackColor = LIVING_CELL_COLOR;
                    ((Button)sender).Tag = LIVING_CELL_TAG;

                    // Add 1 to the cells living
                    ++this._currentLivingCells;
                    ++this._currentMaxLivingCells;
                    ++this._currentMinLivingCells;
                }
                // If the cell is living
                else
                {
                    ((Button)sender).BackColor = DEAD_CELL_COLOR;
                    ((Button)sender).Tag = DEAD_CELL_TAG;

                    // Remove 1 from the cells living
                    --this._currentLivingCells;
                    --this._currentMaxLivingCells;
                    --this._currentMinLivingCells;
                }

                this.PrintLabelsInfos();
            }
        }

        /// <summary>
        /// Occured when user press reset button
        /// </summary>
        /// <param name="sender">The object that trigger the event</param>
        /// <param name="e">Datas used by the event</param>
        private void ResetButtonClicked(object sender, EventArgs e)
        {
            if (this.ShowConfirmationBox())
            {
                // Set the state to not running
                this._running = false;

                // Reset the game informations
                this.ResetGameInformations();

                // Stop the timer
                this.refreshTimer.Stop();
                this.refreshTimer.Tick -= new System.EventHandler(ExecuteOneCycle);

                // Reset the game area
                this.ResetGameArea();

                // Enable the buttons in case of the loop was running
                this.nextCycleButton.Enabled = true;
                this.lastCycleButton.Enabled = true;
            }
        }

        /// <summary>
        /// Reset the game informations with default values
        /// </summary>
        private void ResetGameInformations()
        {
            // Reset the current cycle counter
            this._currentCycle = 0;
            this._currentLivingCells = 0;
            this._currentMaxLivingCells = 0;
            this._currentMinLivingCells = 0;

            // Print the updated values
            this.PrintLabelsInfos();
        }

        /// <summary>
        /// Occured when user press start button
        /// </summary>
        /// <param name="sender">The object that trigger the event</param>
        /// <param name="e">Datas used by the event</param>
        private void StartButtonClicked(object sender, EventArgs e)
        {
            // Set the mode to the inverse
            this._running = !this._running;

            this.refreshTimer.Interval = this._cycleSpeed;

            // Start or stop the timer in relation with the game status
            if (this._running)
            {
                this.refreshTimer.Start();
                this.refreshTimer.Tick += new System.EventHandler(ExecuteOneCycle);
                this.nextCycleButton.Enabled = false;
                this.lastCycleButton.Enabled = false;
            }
            else
            {
                this.refreshTimer.Stop();
                this.refreshTimer.Tick -= new System.EventHandler(ExecuteOneCycle);
                this.nextCycleButton.Enabled = true;
                this.lastCycleButton.Enabled = true;
            }
        }

        /// <summary>
        /// Execute one cycle of population
        /// </summary>
        /// <param name="sender">The object that trigger the event</param>
        /// <param name="e">Datas used by the event</param>
        private void ExecuteOneCycle(object sender, EventArgs e)
        {
            // Reset the living cells counter
            this._currentLivingCells = 0;

            // Store the living cells for this generation
            List<string> livingCells = new List<string>();

            // Goes threw every cells of the gameArea
            for (int i = 0; i < this._cellsNumber; ++i)
            {
                for (int j = 0; j < this._cellsNumber; ++j)
                {
                    // Get the number of neighbor the cell have
                    byte neighborCounter = this.GetNbOfNeighbor(j, i);

                    // Check neighbors of the cell if the cell is living
                    if (this._buttons[j, i].BackColor == LIVING_CELL_COLOR)
                    {
                        // if neighbor nb are lower or higher than min max, kill the cell
                        if (neighborCounter < 2 || neighborCounter > 3)
                        {
                            this._buttons[j, i].Tag = UPDATE_CELL_TAG;
                        }
                        else
                        {
                            // Add 1 to currentLivingCells counter
                            ++this._currentLivingCells;
                        }

                        // The cell is living, add it to list of livings for this turn
                        livingCells.Add($"{j},{i}");
                    }
                    // If the cell is dead and exactly 3 neighbor
                    else if (this._buttons[j, i].BackColor == DEAD_CELL_COLOR && neighborCounter == 3)
                    {
                        this._buttons[j, i].Tag = UPDATE_CELL_TAG;

                        // Add 1 to currentLivingCells counter
                        ++this._currentLivingCells;
                    }
                }
            }
            // Update the cells only after all calculations as been made
            this.UpdateCells();

            // Update the cells counter
            this.UpdateMinMaxCells();

            // Print the new datas to labels
            this.PrintLabelsInfos();

            ++this._currentCycle;

            // Add the current living cells coords to the Stack
            this._lastCycles.Push(new List<string>(livingCells));
        }

        /// <summary>
        /// Update all the cells that need to be changed (at the end of the calculations)
        /// </summary>
        private void UpdateCells()
        {
            // Goes threw every cells of the gameArea
            for (int i = 0; i < this._cellsNumber; ++i)
            {
                for (int j = 0; j < this._cellsNumber; ++j)
                {
                    // Only if the label as been set to UPDATE
                    if (this._buttons[j, i].Tag.ToString() == UPDATE_CELL_TAG)
                    {
                        // Switch the state of the cell (DEAD goes LIVING, LIVING goes DEAD)
                        if (this._buttons[j, i].BackColor == LIVING_CELL_COLOR)
                        {
                            this._buttons[j, i].BackColor = DEAD_CELL_COLOR;
                            this._buttons[j, i].Tag = DEAD_CELL_TAG;
                        }
                        else
                        {
                            this._buttons[j, i].BackColor = LIVING_CELL_COLOR;
                            this._buttons[j, i].Tag = LIVING_CELL_COLOR;
                        }
                    }
                }
            }
        }

        /// <summary>
        /// Find the number of neighbor a specific cell have
        /// </summary>
        /// <param name="posX">The posX (in the array) of the cell to check</param>
        /// <param name="posY">The posY (in the array) of the cell to check</param>
        /// <returns>The number of neighbor</returns>
        private byte GetNbOfNeighbor(int posX, int posY)
        {
            // The "possible" neighbor coords to check
            int[,] possibleCoords = new int[,] { { -1, -1 }, { 0, -1 }, { 1, -1 }, { -1, 0 }, { 1, 0 }, { -1, 1 }, { 0, 1 }, { 1, 1 } };

            // the number of neighbor cells found
            byte neighborCounter = 0;

            // Check every coords possibles
            for (int i = 0; i < possibleCoords.GetLength(0); ++i)
            {
                //Check if the coords is inside the game area limits
                if (posX + possibleCoords[i, X_POSITION] >= 0 && posX + possibleCoords[i, X_POSITION] < this._cellsNumber && posY + possibleCoords[i, Y_POSITION] >= 0 && posY + possibleCoords[i, Y_POSITION] < this._cellsNumber)
                {
                    // if the cell tested is living
                    if (this._buttons[posX + possibleCoords[i, X_POSITION], posY + possibleCoords[i, Y_POSITION]].BackColor == LIVING_CELL_COLOR)
                    {
                        ++neighborCounter;
                    }
                }
            }

            // Return the result
            return neighborCounter;
        }

        /// <summary>
        /// Print the label infos onto interface
        /// </summary>
        private void PrintLabelsInfos()
        {
            if(this._currentLanguage == LANG_FR)
            {
                // Update the labels with new values
                this.cycleGenLabel.Text = $"{LangFR.executedCyclesLabel}{this._currentCycle}";
                this.livingCellsLabel.Text = $"{LangFR.livingCellsLabel}{this._currentLivingCells}";
                this.livingCellMinLabel.Text = $"{LangFR.minLivingCellsLabel}{this._currentMinLivingCells}";
                this.livingCellMaxLabel.Text = $"{LangFR.maxLivingCellsLabel}{this._currentMaxLivingCells}";
            }
            else
            {
                this.cycleGenLabel.Text = $"{LangEN.executedCyclesLabel}{this._currentCycle}";
                this.livingCellsLabel.Text = $"{LangEN.livingCellsLabel}{this._currentLivingCells}";
                this.livingCellMinLabel.Text = $"{LangEN.minLivingCellsLabel}{this._currentMinLivingCells}";
                this.livingCellMaxLabel.Text = $"{LangEN.maxLivingCellsLabel}{this._currentMaxLivingCells}";
            }

            
        }

        /// <summary>
        /// Occured when the user change the speed of the application
        /// </summary>
        /// <param name="sender">The object that trigger the event</param>
        /// <param name="e">Datas used by the event</param>
        private void SpeedTrackBarValueChanded(object sender, EventArgs e)
        {
            // Calculate the new speed value
            this._cycleSpeed = this.speedTrackBar.Value * SPEED_INTERVAL / 2;
            this.refreshTimer.Interval = this._cycleSpeed;

            if(this._currentLanguage == LANG_FR)
            {
                this.speedLabel.Text = $"{LangFR.speedLabel}{this._cycleSpeed} ms";
            }
            else
            {
                this.speedLabel.Text = $"{LangEN.speedLabel}{this._cycleSpeed} ms";
            }
        }

        /// <summary>
        /// Occured when the user press the Next cycle button, execute only one generation
        /// </summary>
        /// <param name="sender">The object that trigger the event</param>
        /// <param name="e">Datas used by the event</param>
        private void NextCycleClicked(object sender, EventArgs e)
        {
            // Only if the geneation is not running
            if (!this._running)
            {
                // Execute manually one cycle
                this.ExecuteOneCycle(null, null);
            }
        }

        /// <summary>
        /// Update the cells counter if needed
        /// </summary>
        private void UpdateMinMaxCells()
        {
            // The current is highter then max, update max
            if (this._currentLivingCells > this._currentMaxLivingCells)
            {
                this._currentMaxLivingCells = this._currentLivingCells;
            }

            // The current is lower then min, update min
            if (this._currentLivingCells < this._currentMinLivingCells)
            {
                this._currentMinLivingCells = this._currentLivingCells;
            }
        }

        /// <summary>
        /// Occured if the player press WikiEN button
        /// </summary>
        /// <param name="sender">The object that trigger the event</param>
        /// <param name="e">Datas used by the event</param>
        private void WikiENLabelClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Process.Start("https://en.wikipedia.org/wiki/Conway%27s_Game_of_Life");
        }

        /// <summary>
        /// Occured if the player press WikiEN button
        /// </summary>
        /// <param name="sender">The object that trigger the event</param>
        /// <param name="e">Datas used by the event</param>
        private void WikiFRLabelClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Process.Start("https://fr.wikipedia.org/wiki/Jeu_de_la_vie");
        }

        /// <summary>
        /// Occured when the player change the size of the cells
        /// </summary>
        /// <param name="sender">The object that trigger the event</param>
        /// <param name="e">Datas used by the event</param>
        private void ConfirmCellSizeChangeButtonClick(object sender, EventArgs e)
        {
            // User need to validate the confirmation
            if (this.ShowConfirmationBox())
            {
                // Set the state to not running
                this._running = false;

                // Reset the current cycle counter and print the new values
                this.ResetGameInformations();

                // Stop the timer
                this.refreshTimer.Stop();
                this.refreshTimer.Tick -= new System.EventHandler(ExecuteOneCycle);
                this.nextCycleButton.Enabled = true;
                this.lastCycleButton.Enabled = true;

                // Change the cell size
                this._cellSize = Convert.ToInt32(this.cellSizeNumericValue.Value);

                // Reset the game with new size of buttons
                this.ResetGameAreaWithNewSize();
                this.confirmCellSizeChangeButton.Visible = false;
            }
        }

        /// <summary>
        /// Occured when the value of the cell size is changed
        /// </summary>
        /// <param name="sender">The object that trigger the event</param>
        /// <param name="e">Datas used by the event</param>
        private void CellSizeNumericValueValueChanged(object sender, EventArgs e)
        {
            // Activate or desactivate the validation button to not permits the player to resize with same cell size
            if (this._cellSize != this.cellSizeNumericValue.Value)
            {
                this.confirmCellSizeChangeButton.Visible = true;
            }
            else
            {
                this.confirmCellSizeChangeButton.Visible = false;
            }

        }

        /// <summary>
        /// Does some work in background, reset the game area with new labels
        /// </summary>
        /// <param name="sender">The object that trigger the event</param>
        /// <param name="e">Datas used by the event</param>
        private void BackgroundWorkerDoWork(object sender, System.ComponentModel.DoWorkEventArgs e)
        {
            // Reset the array before doing anything
            Invoke(new Action(() => { this._buttons = new Button[this._cellsNumber, this._cellsNumber]; this.gameAreaPanel.Controls.Clear(); this.loadingProgressBar.Step = (100 / this._cellsNumber) + 1; }));

            // Create each label of the array and set them default settings
            for (int i = 0; i < this._cellsNumber; ++i)
            {
                for (int j = 0; j < this._cellsNumber; ++j)
                {
                    // Create and set default settings to label
                    this._buttons[j, i] = new Button();
                    this._buttons[j, i].Location = new Point(j * this._cellSize, i * this._cellSize);
                    this._buttons[j, i].BackColor = DEAD_CELL_COLOR;
                    this._buttons[j, i].Size = new Size(this._cellSize, this._cellSize);
                    this._buttons[j, i].FlatStyle = FlatStyle.Flat;
                    if(this.borderCheckBox.Checked)
                    {
                        this._buttons[j, i].FlatAppearance.BorderSize = 1;
                    }
                    else
                    {
                        this._buttons[j, i].FlatAppearance.BorderSize = 0;
                    }
                    this._buttons[j, i].FlatAppearance.MouseOverBackColor = LIVING_CELL_COLOR;
                    this._buttons[j, i].FlatAppearance.BorderColor = BORDERS_CELL_COLOR;
                    this._buttons[j, i].Tag = DEAD_CELL_TAG;

                    // Add click event to label
                    this._buttons[j, i].Click += new EventHandler(LabelClicked);

                    Invoke(new Action(() => { this.gameAreaPanel.Controls.Add(this._buttons[j, i]); }));
                }
                
                // Update the progress bar
                Invoke(new Action(() => { this.loadingProgressBar.PerformStep(); }));
            }

            // Reset the cells statistics
            this._currentMinLivingCells = 0;
            this._currentMaxLivingCells = 0;
            this._currentLivingCells = 0;

            // Foreach cell that need to be imported, change the necessary values
            foreach (string cell in this._importedCells)
            {
                // Split each information of the cell (X Y and COLOR)
                string[] splitedCell = cell.Split(',');

                // Update the cell with living informations
                this._buttons[Int32.Parse(splitedCell[X_POSITION]), Int32.Parse(splitedCell[Y_POSITION])].BackColor = LIVING_CELL_COLOR;
                this._buttons[Int32.Parse(splitedCell[X_POSITION]), Int32.Parse(splitedCell[Y_POSITION])].FlatAppearance.MouseOverBackColor = LIVING_CELL_COLOR;
                this._buttons[Int32.Parse(splitedCell[X_POSITION]), Int32.Parse(splitedCell[Y_POSITION])].Tag = LIVING_CELL_COLOR;

                // Bump the cell statistics
                ++this._currentMinLivingCells;
                ++this._currentMaxLivingCells;
                ++this._currentLivingCells;

                // Enable the import and export button
                this.importToolStripMenuItem.Enabled = true;
                this.exportToolStripMenuItem.Enabled = true;
            }
        }

        /// <summary>
        /// Occured when the work initiated by backgroud worker is terminated
        /// </summary>
        /// <param name="sender">The object that trigger the event</param>
        /// <param name="e">Datas used by the event</param>
        private void BackgroundWorkerRunWorkerCompleted(object sender, System.ComponentModel.RunWorkerCompletedEventArgs e)
        {
            //Clear the list after importation
            this._importedCells.Clear();

            // hide the loading panel and reset his value of the progress bar for next time
            this.loadingProgressBar.Visible = false;
            this.infoLabel.Visible = false;
            this.loadingPanel.Visible = false;
            this.loadingProgressBar.Value = 0;

            this.importToolStripMenuItem.Enabled = true;
            this.exportToolStripMenuItem.Enabled = true;

            // Clear the stack
            this._lastCycles.Clear();

            // Print the statistics to the interface
            this.PrintLabelsInfos();
        }

        /// <summary>
        /// Export the data to text file
        /// </summary>
        /// <param name="sender">The object that trigger the event</param>
        /// <param name="e">Datas used by the event</param>
        private void ExportClick(object sender, EventArgs e)
        {
            // open file dialog   
            SaveFileDialog saveDialog = new SaveFileDialog();

            // Apply text file filter
            saveDialog.Filter = "GameOfLife Files(*.gol)|*.gol;";

            // If user validate with OK button
            if (saveDialog.ShowDialog() == DialogResult.OK)
            {
                // If the file does not exists, create the file for later
                if (!File.Exists(saveDialog.FileName))
                {
                    File.Create(saveDialog.FileName).Close();
                }

                // Save the content of the panel to txt file
                this.SaveToFile(saveDialog.FileName);
            }
        }

        /// <summary>
        /// Save the content of the panel to txt file
        /// </summary>
        /// <param name="path">The path to write into</param>
        private void SaveToFile(string path)
        {
            // The string that will store the content of the labels, add cells number and cellsize to the start of the file
            string contentToWrite = $"{this._cellsNumber},{this._cellSize}\n";

            for(int i = 0; i < this._cellsNumber; ++i)
            {
                for(int j = 0; j < this._cellsNumber; ++j)
                {
                    // Only if the cell is living
                    if (this._buttons[j, i].BackColor == LIVING_CELL_COLOR)
                    {
                        // Add the cell to the content to write (X pos Y pos)
                        contentToWrite += $"{this._buttons[j, i].Location.X / this._cellSize},{this._buttons[j, i].Location.Y / this._cellSize};";
                    }
                }
            }

            // Write the content string to file, if WriteContent return false, show error to user
            if(!AccessFile.WriteContent(path, contentToWrite))
            {
                if(this._currentLanguage == LANG_FR)
                {
                    MessageBox.Show(LangFR.errorExportation);
                }
                else
                {
                    MessageBox.Show(LangEN.errorExportation);
                }
            }
        }

        /// <summary>
        /// Import the data from a file
        /// </summary>
        /// <param name="sender">The object that trigger the event</param>
        /// <param name="e">Datas used by the event</param>
        private void ImportClick(object sender, EventArgs e)
        {
            // Open the file dialog
            OpenFileDialog openDialog = new OpenFileDialog();

            // Apply text file filter
            openDialog.Filter = "GameOfLife Files(*.gol)|*.gol;";

            // If user validate with OK button
            if (openDialog.ShowDialog() == DialogResult.OK)
            {
                // Load the content of the file given by user
                this.LoadFromFile(openDialog.FileName);
            }
        }

        /// <summary>
        /// Load the content of text file to panel
        /// </summary>
        /// <param name="path">The path to load content from</param>
        private void LoadFromFile(string path)
        {
            // Show the loading elements
            this.loadingProgressBar.Visible = true;
            this.infoLabel.Visible = true;
            this.loadingPanel.Visible = true;

            // Read the content of the file and split each line
            string fileContent = AccessFile.ReadContent(path);

            //Only if the file as been readed
            if(fileContent != null)
            {
                string[] lines = fileContent.Split('\n');

                // Update the import list with content of the file
                this.UpdateImportedCellsList(lines);

                // Initialise a new game area and set the necessary values to living cells (background work)
                this.createGridBackgroundWorker.RunWorkerAsync();
            }
            else
            {
                if(_currentLanguage == LANG_FR)
                {
                    MessageBox.Show(LangFR.errorFileCannotBeRead);
                }
                else
                {
                    MessageBox.Show(LangEN.errorFileCannotBeRead);
                }
            }
        }

        /// <summary>
        /// Update the list of imported cells. This will read all cells and put them into list for further calculations
        /// </summary>
        /// <param name="lines">The content of the file split by line</param>
        private void UpdateImportedCellsList(string[] lines)
        {
            // Clear the importedCells list to assure some don't exists from precedent importation
            this._importedCells.Clear();

            for (int i = 0; i < lines.Length; ++i)
            {
                // the first line of the file contains cellsNumber and cellSize informations
                if (i == 0)
                {
                    this._cellsNumber = Int32.Parse(lines[i].Split(',')[0]);
                    this._cellSize = Int32.Parse(lines[i].Split(',')[1]);
                }
                // Only if the line is not empty (the last line will always be empty)
                else if (lines[i] != "")
                {
                    // Split each label info
                    string[] splitedLabels = lines[i].Split(';');

                    // Add each labels to the list if they are not empty
                    foreach (string label in splitedLabels)
                    {
                        if (label != "")
                        {
                            this._importedCells.Add(label);
                        }
                    }
                }
            }

            // Print the new size calculated
            this.cellSizeNumericValue.Value = this._cellSize;
        }

        /// <summary>
        /// Change the color with the color choosen by the user
        /// </summary>
        /// <param name="sender">The object that trigger the event</param>
        /// <param name="e">Datas used by the event</param>
        private void ColorLabelClick(object sender, EventArgs e)
        {
            if (this.cellColorChooserDialog.ShowDialog() == DialogResult.OK)
            {
                // Change the color for living cell and color label
                this.colorLabel.BackColor = cellColorChooserDialog.Color;
            }
        }

        /// <summary>
        /// Change the color of the living cells
        /// </summary>
        /// <param name="sender">The object that trigger the event</param>
        /// <param name="e">Datas used by the event</param>
        private void ColorLabelBackColorChanged(object sender, EventArgs e)
        {
            if(LIVING_CELL_COLOR != this.colorLabel.BackColor)
            {
                // change the size of the border foreach buttons
                for (int i = 0; i < this._cellsNumber; ++i)
                {
                    for (int j = 0; j < this._cellsNumber; ++j)
                    {
                        // Change settings for living cells only
                        if(this._buttons[j, i].BackColor == LIVING_CELL_COLOR)
                        {
                            this._buttons[j, i].BackColor = this.colorLabel.BackColor;
                            this._buttons[j, i].FlatAppearance.MouseOverBackColor = this.colorLabel.BackColor;
                        }

                        this._buttons[j, i].FlatAppearance.MouseOverBackColor = this.colorLabel.BackColor;
                    }
                }

                LIVING_CELL_COLOR = this.colorLabel.BackColor;
            }
        }

        /// <summary>
        /// Set the settings store by user to the application
        /// </summary>
        private void SetSettings()
        {
            // If the settings were able to be obtains
            if(this._settings.GetSettings())
            {
                // Update the settings
                this._cellsNumber = this._settings.CellNumber;
                this._cellSize = this._settings.CellSize;
                LIVING_CELL_COLOR = this._settings.CellColor;
            }
        }

        /// <summary>
        /// Occured when the user close the application
        /// </summary>
        /// <param name="sender">The object that trigger the event</param>
        /// <param name="e">Datas used by the event</param>
        private void MainFormFormClosing(object sender, FormClosingEventArgs e)
        {
            this._settings.SetSettings(this._cellsNumber, this._cellSize, LIVING_CELL_COLOR);
        }

        /// <summary>
        /// Occured when the user press Last Cycle button, load the last generation of the game
        /// </summary>
        /// <param name="sender">The object that trigger the event</param>
        /// <param name="e">Datas used by the event</param>
        private void LastCycleButtonClick(object sender, EventArgs e)
        {
            // The stack is not empty and the timer is not running
            if (this._lastCycles.Count > 0 && !this._running && this._currentCycle > 0)
            {
                // Reset the living cells counter
                this._currentLivingCells = 0;
                --this._currentCycle;

                // Get the last cycle living cells
                List<string> livingCells = new List<string>(this._lastCycles.Pop());

                for (int i = 0; i < this._cellsNumber; ++i)
                {
                    for (int j = 0; j < this._cellsNumber; ++j)
                    {
                        if(this._buttons[j, i].BackColor == LIVING_CELL_COLOR)
                        {
                            this._buttons[j, i].Tag = DEAD_CELL_TAG;
                            this._buttons[j, i].BackColor = DEAD_CELL_COLOR;
                        }
                    }
                }

                foreach(string cell in livingCells)
                {
                    this._buttons[Int32.Parse(cell.Split(',')[X_POSITION]), Int32.Parse(cell.Split(',')[Y_POSITION])].BackColor = LIVING_CELL_COLOR;
                    this._buttons[Int32.Parse(cell.Split(',')[X_POSITION]), Int32.Parse(cell.Split(',')[Y_POSITION])].Tag = LIVING_CELL_COLOR;
                    this._buttons[Int32.Parse(cell.Split(',')[X_POSITION]), Int32.Parse(cell.Split(',')[Y_POSITION])].FlatAppearance.MouseOverBackColor = LIVING_CELL_COLOR;

                    ++this._currentLivingCells;
                }

                // Update the cells counter
                this.UpdateMinMaxCells();

                // Print the new datas to labels
                this.PrintLabelsInfos();
            }
        }

        /// <summary>
        /// Change the size of the borders if player change the state of the borders check box
        /// </summary>
        /// <param name="sender">The object that trigger the event</param>
        /// <param name="e">Datas used by the event</param>
        private void BordersCheckedChanged(object sender, EventArgs e)
        {
            // Set the default value to 0
            byte borderSize = 0;

            // Change the value if checked (activate the borders
            if(this.borderCheckBox.Checked)
            {
                borderSize = 1;
            }

            // change the size of the border foreach buttons
            for (int i = 0; i < this._cellsNumber; ++i)
            {
                for (int j = 0; j < this._cellsNumber; ++j)
                {
                    this._buttons[j, i].FlatAppearance.BorderSize = borderSize;
                }
            }
        }

        #region Language Culture
        /// <summary>
        /// Get the current culture of the PC and return the appropriate language
        /// </summary>
        /// <returns>The current language</returns>
        private string GetCurrentLanguage()
        {
            if (CultureInfo.CurrentCulture.Name.Contains(LANG_FR.ToLower()))
            {
                return LANG_FR;
            }
            else
            {
                return LANG_EN;
            }
        }

        /// <summary>
        /// Set the text values to the correct language (FR or EN)
        /// </summary>
        private void SetLanguage()
        {
            if(this._currentLanguage == LANG_FR)
            {
                this.menuStrip.Text = LangFR.fileMenuStrip;
                this.importToolStripMenuItem.Text = LangFR.fileMenuStripImport;
                this.exportToolStripMenuItem.Text = LangFR.fileMenuStripExport;
                this.actionsGroupBox.Text = LangFR.actionsGroupBox;
                this.settingsGroupBox.Text = LangFR.settingsGroupBox;
                this.infoGroupBox.Text = LangFR.informationsGroupBox;
                this.statsGroupBox.Text = LangFR.statisticsGroupBox;
                this.rulesGroupBox.Text = LangFR.rulesGroupBox;
                this.startBreakButton.Text = LangFR.startBreakButton;
                this.nextCycleButton.Text = LangFR.nextCycleButton;
                this.lastCycleButton.Text = LangFR.lastCycleButton;
                this.resetButton.Text = LangFR.resetButton;
                this.buttonSizeLabel.Text = LangFR.cellSizeLabel;
                this.confirmCellSizeChangeButton.Text = LangFR.cellSizeValidationButton;
                this.cellColorTextLabel.Text = LangFR.cellColorLabel;
                this.borderCheckBox.Text = LangFR.activeBordersCheckBox;
                this.speedLabel.Text = $"{LangFR.speedLabel}{this._cycleSpeed} ms";
                this.infoLabel.Text = LangFR.loadingLabel;
                this.cycleGenLabel.Text = $"{LangFR.executedCyclesLabel}{this._currentCycle}";
                this.livingCellsLabel.Text = $"{LangFR.livingCellsLabel}{this._currentLivingCells}";
                this.livingCellMinLabel.Text = $"{LangFR.minLivingCellsLabel}{this._currentMinLivingCells}";
                this.livingCellMaxLabel.Text = $"{LangFR.maxLivingCellsLabel}{this._currentMaxLivingCells}";
            }
            else
            {
                this.menuStrip.Text = LangEN.fileMenuStrip;
                this.importToolStripMenuItem.Text = LangEN.fileMenuStripImport;
                this.exportToolStripMenuItem.Text = LangEN.fileMenuStripExport;
                this.actionsGroupBox.Text = LangEN.actionsGroupBox;
                this.settingsGroupBox.Text = LangEN.settingsGroupBox;
                this.infoGroupBox.Text = LangEN.informationsGroupBox;
                this.statsGroupBox.Text = LangEN.statisticsGroupBox;
                this.rulesGroupBox.Text = LangEN.rulesGroupBox;
                this.startBreakButton.Text = LangEN.startBreakButton;
                this.nextCycleButton.Text = LangEN.nextCycleButton;
                this.lastCycleButton.Text = LangEN.lastCycleButton;
                this.resetButton.Text = LangEN.resetButton;
                this.buttonSizeLabel.Text = LangEN.cellSizeLabel;
                this.confirmCellSizeChangeButton.Text = LangEN.cellSizeValidationButton;
                this.cellColorTextLabel.Text = LangEN.cellColorLabel;
                this.borderCheckBox.Text = LangEN.activeBordersCheckBox;
                this.speedLabel.Text = $"{LangEN.speedLabel}{this._cycleSpeed} ms";
                this.infoLabel.Text = LangEN.loadingLabel;
                this.cycleGenLabel.Text = $"{LangEN.executedCyclesLabel}{this._currentCycle}";
                this.livingCellsLabel.Text = $"{LangEN.livingCellsLabel}{this._currentLivingCells}";
                this.livingCellMinLabel.Text = $"{LangEN.minLivingCellsLabel}{this._currentMinLivingCells}";
                this.livingCellMaxLabel.Text = $"{LangEN.maxLivingCellsLabel}{this._currentMaxLivingCells}";
            }
        }

        /// <summary>
        /// Show confirmationbox to player
        /// </summary>
        /// <returns>True if user validate by pressing OK</returns>
        private bool ShowConfirmationBox()
        {
            string message;

            // Get the correct language string from resource file
            if (this._currentLanguage == LANG_FR)
            {
                message = LangFR.confirmationBoxLabel;
            }
            else
            {
                message = LangEN.confirmationBoxLabel;
            }

            // Print the message box and wait for validation
            DialogResult result = MessageBox.Show(message, "Message", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
            if (result.Equals(DialogResult.OK))
            {
                return true;
            }
            return false;
        }

        /// <summary>
        /// Switch the language to FR
        /// </summary>
        /// <param name="sender">The object that trigger the event</param>
        /// <param name="e">Datas used by the event</param>
        private void FRToolStripMenuClick(object sender, EventArgs e)
        {
            this._currentLanguage = LANG_FR;

            this.SetLanguage();
        }

        /// <summary>
        /// Switch the language to EN
        /// </summary>
        /// <param name="sender">The object that trigger the event</param>
        /// <param name="e">Datas used by the event</param>
        private void ENToolStripMenuClick(object sender, EventArgs e)
        {
            this._currentLanguage = LANG_EN;

            this.SetLanguage();
        }
        #endregion Language Culture
    }
}
