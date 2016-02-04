using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using System.IO;

using System.Diagnostics;

namespace Spirals
{
    public partial class Form1 : Form
    {
        enum State
        {
            stopped,
            paused,
            running
        }

        enum RunMode
        {
            drawStepByStep,
            drawAtEnd
        }

        const int MAXCOGSIZE = 240;
        const int MINCOGSIZE = 3;

        State state = State.stopped;

        RunMode runMode = RunMode.drawAtEnd;    //.drawStepByStep;

        Cog cog;

        List<PointF> pointList = new List<PointF>();

        int listBoxHighlightedIndex = 0;

        List<List<int>> cogSettings = new List<List<int>>();

        List<List<int>> library = new List<List<int>>();
        bool libraryChanged = false;


        int pictureBoxXIndent;
        int pictureBoxYIndent;

        Random random = new Random();

        public Form1()
        {
            InitializeComponent();

            library.Add(new List<int> { 7, 60, 60, 30 });
            library.Add(new List<int> { 50,50,25,23});


        }

        private void Form1_Load(object sender, EventArgs e)
        {
            pictureBoxXIndent = this.Width - pictureBoxDisplay.Width - pictureBoxDisplay.Left;
            pictureBoxYIndent = this.Height - pictureBoxDisplay.Height - pictureBoxDisplay.Top;

            bool b = runMode == RunMode.drawAtEnd;
            checkBoxDrawAtOnce.Checked = b; // why does this exit code>???

            comboBoxQuality.Items.Add("Low");
            comboBoxQuality.Items.Add("Low/Mid");
            comboBoxQuality.Items.Add("Mid");
            comboBoxQuality.Items.Add("Mid/High");
            comboBoxQuality.Items.Add("High");
            comboBoxQuality.Items.Add("Very High");

            comboBoxQuality.SelectedIndex = 1;


            //checkBoxDrawAtOnce.Checked = (runMode == RunMode.drawAtEnd);
            SetPictureBoxSizeFromForm();


            List<int> currentSettings = new List<int>();
            currentSettings.Add(50);
            currentSettings.Add(50);
            currentSettings.Add(25);
            currentSettings.Add(23);
            cogSettings.Add(currentSettings);

            CopyCogSettingsToListbox();
            CreateCogsFromCurrentSettings();
            pictureBoxDisplay.Invalidate();

            ValidateUI();

            timer1.Interval = 1000 / 100;
            timer1.Start();



            LoadLibrary();
            labelLibrarySize.Text = string.Format("Entries: {0}", library.Count);
        }

        private void buttonGo_Click(object sender, EventArgs e)
        {
            // Start --> Pause --> Unpause
            switch (state)
            {

                case State.stopped:

                    
                    // new run
                    CreateCogsFromCurrentSettings();
                    pointList.Clear();
                                     
                    if (runMode == RunMode.drawAtEnd)
                    {
                        DrawWholeShape();
                        state = State.stopped;
                    }
                    else
                    {
                        buttonGo.Text = "Pause"; // next click
                        state = State.running;
                    }
                    pictureBoxDisplay.Invalidate();
                    break;


                case State.running:

                    buttonGo.Text = "Unpause";
                    state = State.paused;
                    break;


                case State.paused:

                    buttonGo.Text = "Pause";
                    state = State.running;
                    break;
            }
            ValidateUI();
        }

        private void CreateCogsFromCurrentSettings()        
        {
            List<int> currentSettings = cogSettings[cogSettings.Count - 1];

            int cogSize;

            cog = null;

            if (currentSettings.Count > 1)
            {
                cogSize = currentSettings[0];

                cog = new Cog(cogSize, new PointF(pictureBoxDisplay.Width / 2, pictureBoxDisplay.Height / 2), pointList, null, textBoxOutput);


                for (int i = 1; i < currentSettings.Count; i++ )   // we add a sentinel
                {
                    cogSize = Convert.ToInt32(currentSettings[i]);

                    cog.AddChild(cogSize);
                }
            }

        }
        private double GetSpeed()
        {

            double speed = Math.PI / 512;


            // 128 256 512 1024 2048


            int i = comboBoxQuality.SelectedIndex;

            if (i < 0)
            {
                i = 0;
            }

            int divisor = 128 * (int)Math.Pow(2, i);
            speed = Math.PI / divisor;
            return speed;
        }


        private void timer1_Tick(object sender, EventArgs e)
        {
            if (runMode == RunMode.drawStepByStep)
            {
                if (state == State.running)
                {


                    double speed = GetSpeed();


                    textBoxOutput2.Text = ">>>" + Convert.ToString(cog.NumberOfLoops);

                    cog.Rotate(0 * (Math.PI / 4000), speed);
                    pictureBoxDisplay.Invalidate();

                    if (cog.CycleCompleted())
                    {
                        state = State.stopped;
                        buttonGo.Text = "Start";
                        ValidateUI();
                    }
                }
            }
        }

        private void DrawWholeShape()
        {

            Debug.Assert(runMode == RunMode.drawAtEnd);

            double speed = GetSpeed();

            while (!cog.CycleCompleted())
            {
                cog.Rotate(0, speed);
            }
        }

        private void pictureBoxDisplay_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;

            if ((checkBoxCogs.Checked) && (cog != null))
            {
                cog.Draw(g);
            }
            Pen pen2;

            if (state == State.running)
            {
                pen2 = new Pen(Color.Red);
            }
            else
            {
                pen2 = new Pen(Color.Green);
            }

            if (checkBoxLines.Checked)
            {

                for (int i = 0; i < pointList.Count - 1; i++)
                {
                    g.DrawLine(pen2, pointList[i], pointList[i + 1]);
                }
            }
        }

        private void checkBoxCogs_CheckedChanged(object sender, EventArgs e)
        {
            pictureBoxDisplay.Invalidate();

            ValidateUI();
        }

        private void checkBoxLines_CheckedChanged(object sender, EventArgs e)
        {
            pictureBoxDisplay.Invalidate();

            ValidateUI();
        }

        private void listBoxCogSizes_SelectedIndexChanged(object sender, EventArgs e)
        {
            listBoxHighlightedIndex = listBoxCogSizes.SelectedIndex;

            ValidateUI();
        }

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            int size;

            try
            {
                size = Convert.ToInt32(textBoxCogSize.Text);

                listBoxCogSizes.Items.Insert(listBoxHighlightedIndex, size);
                listBoxHighlightedIndex++;
                listBoxCogSizes.SelectedIndex = listBoxHighlightedIndex;
                AddListboxSettingsToCurrentSettings();
                CreateCogsFromCurrentSettings();
                pictureBoxDisplay.Invalidate();

                textBoxCogSize.Focus();
            }
            catch (Exception ex)
            {
            }



            ValidateUI();
        }

        private void buttonDelete_Click(object sender, EventArgs e)
        {
            if (listBoxCogSizes.Items.Count > 1)
            {
                int itemToDelete = listBoxHighlightedIndex - 1;
                if (itemToDelete < 0)
                {
                    itemToDelete = 0;
                }

                int value = Convert.ToInt32(listBoxCogSizes.Items[itemToDelete]);
                listBoxCogSizes.Items.RemoveAt(itemToDelete);
                textBoxCogSize.Text = Convert.ToString(value);
                listBoxHighlightedIndex--;
                if (listBoxHighlightedIndex < 0)
                {
                    listBoxHighlightedIndex = 0;
                    
                }
                listBoxCogSizes.SelectedIndex = listBoxHighlightedIndex;


                AddListboxSettingsToCurrentSettings(); // create undo copy...
                CreateCogsFromCurrentSettings();
                pictureBoxDisplay.Invalidate();

                textBoxCogSize.Focus();

            }
            ValidateUI();
        }

        private void AddListboxSettingsToCurrentSettings()
        {

            List<int> currentSettings = new List<int>();

            for (int i = 0; i < listBoxCogSizes.Items.Count - 1; i++)
            {
                int cogSize = Convert.ToInt32(listBoxCogSizes.Items[i]);
                currentSettings.Add(cogSize);
            }

            cogSettings.Add(currentSettings);

            ValidateUI();

        }

        private void buttonStop_Click(object sender, EventArgs e)
        {
            if (state == State.running || state == State.paused)
            {
                state = State.stopped;
                buttonGo.Text = "Start";
            }
            ValidateUI();
        }

        private void checkBoxDrawAtOnce_CheckedChanged(object sender, EventArgs e)
        {

            if (checkBoxDrawAtOnce.Checked)
            {
                runMode = RunMode.drawAtEnd;
            }
            else
            {
                runMode = RunMode.drawStepByStep;
            }

            ValidateUI();
        }

        private void textBoxCogSize_TextChanged(object sender, EventArgs e)
        {

            bool valid = TextBoxCogSizeIsValid();

            textBoxCogSize.ForeColor = valid ? Color.Black : Color.Red;

            ValidateUI();
        }

        private bool TextBoxCogSizeIsValid()
        {



            bool valid = false;
            try
            {
                int value = Convert.ToInt32(textBoxCogSize.Text);
                valid = (value >= MINCOGSIZE && value <= MAXCOGSIZE);
            }
            catch (Exception ex)
            {
            }
            return valid;
        }



        private void ValidateUI()
        {
            // we need to legalise the UI
            // can only undo if more than 1 set of settings
            buttonUndo.Enabled = (cogSettings.Count > 1) && (state != State.running);

            // only add/ delete if not running...
            buttonAdd.Enabled = TextBoxCogSizeIsValid() && (state != State.running);
            buttonDelete.Enabled = (cogSettings[cogSettings.Count - 1].Count > 0) && (state != State.running);

            // need at least 2 cogs
            buttonGo.Enabled = (cogSettings[cogSettings.Count - 1].Count > 1);
            buttonStop.Enabled = (state != State.stopped);

            checkBoxDrawAtOnce.Enabled = (state == State.stopped);
            comboBoxQuality.Enabled = (state == State.stopped);


        }


        private void CopyCogSettingsToListbox()
        {
            List<int> currentSettings = cogSettings[cogSettings.Count - 1];
            listBoxCogSizes.Items.Clear();

            for (int i = 0; i < currentSettings.Count; i++)
            {
                int cogSize = currentSettings[i];
                listBoxCogSizes.Items.Add(cogSize);                
            }
            listBoxCogSizes.Items.Add(">"); // cursor
            listBoxHighlightedIndex = currentSettings.Count;
            listBoxCogSizes.SelectedIndex = listBoxHighlightedIndex;
        }


        private void buttonUndo_Click(object sender, EventArgs e)
        {
            if (cogSettings.Count > 1)
            {
                cogSettings.RemoveAt(cogSettings.Count - 1);
                CopyCogSettingsToListbox();
                CreateCogsFromCurrentSettings();
            }
        }

        private void Form1_ResizeEnd(object sender, EventArgs e)
        {
            // could flag size needs fixing....
            if (state == State.stopped)
            {
                SetPictureBoxSizeFromForm();
                CreateCogsFromCurrentSettings();
                pictureBoxDisplay.Invalidate();
            }
        }

        private void SetPictureBoxSizeFromForm()
        {
            pictureBoxDisplay.Width = this.Width - pictureBoxDisplay.Left - pictureBoxXIndent;
            pictureBoxDisplay.Height = this.Height - pictureBoxDisplay.Top - pictureBoxYIndent;
        }

        private void buttonAddToLibrary_Click(object sender, EventArgs e)
        {
            List<int> newLibraryEntry = new List<int>(cogSettings[cogSettings.Count - 1]);

            bool alreadyPresentInLibrary = false;

            int i = 0;
            while ((i < library.Count) & (!alreadyPresentInLibrary))
            {
                if (library[i].Count == newLibraryEntry.Count)
                {
                    bool thisEntryIsAMatch = true;
                    int j = 0;

                    while (thisEntryIsAMatch && j < newLibraryEntry.Count)
                    {
                        thisEntryIsAMatch &= (library[i][j] == newLibraryEntry[j]);
                        j++;
                    }
                    alreadyPresentInLibrary |= thisEntryIsAMatch;

                }
                i++;
            }
            if (!alreadyPresentInLibrary)
            {
                library.Add(newLibraryEntry);
                libraryChanged = true;
            }


            labelLibrarySize.Text = string.Format("Entries: {0}", library.Count);
        }

        private void buttonLibrary_Click(object sender, EventArgs e)
        {
            int librarySize = library.Count;

            Selection selection = new Selection();

            LibraryManager lm = new LibraryManager(library, selection);

            DialogResult dialogResult = lm.ShowDialog();

            // if the size is different then you deleted at least one entry
            // so will need saving at end as is changed
            if (librarySize != library.Count)
            {
                libraryChanged = true;
            }


            if (dialogResult == DialogResult.OK)
            {
                // do something

                int chosenIndex = selection.Choice;

                // copy this up

                if (chosenIndex != -1)  // safety
                {
                    List<int> newCogSettings = new List<int>(library[chosenIndex]);

                    cogSettings.Add(newCogSettings);
                    CopyCogSettingsToListbox();
                    CreateCogsFromCurrentSettings();
                    pictureBoxDisplay.Invalidate();
                }
            }
        }

        private void LoadLibrary()
        {
            //return;

            try
            {
                using (StreamReader sr = new StreamReader("Library.txt"))
                {
                    library = new List<List<int>>();

                    while (!sr.EndOfStream)
                    {

                        String line = sr.ReadLine();

                        List<int> libraryLine = new List<int>();

                        string[] values = line.Split(' ');

                        foreach (string s in values)
                        {
                            int value = int.Parse(s);
                            libraryLine.Add(value);
                        }

                        library.Add(libraryLine);
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("The file could not be read:");
                Console.WriteLine(e.Message);
            }
        }

        private void SaveLibrary()
        {

            //return;


            // Compose a string that consists of three lines.
            string text = "";   // = "First line.\r\nSecond line.\r\nThird line.";



            foreach (List<int> line in library)
            {
                for (int i = 0; i < line.Count; i++)
                {
                    text = text + Convert.ToString(line[i]) + ((i < (line.Count - 1)) ? " " : "");
                }
                text = text + "\r\n";
            }

            // Write the string to a file.
            System.IO.StreamWriter file = new System.IO.StreamWriter("Library.txt");
            file.WriteLine(text);

            file.Close();
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (libraryChanged)
            {
                SaveLibrary();
            }
        }

        private void buttonRandomise_Click(object sender, EventArgs e)
        {
            List<int> newCogSettings = new List<int>();


            int number = random.Next(2,4);

            for (int i = 0; i < number; i++)
            {
                newCogSettings.Add(random.Next(MINCOGSIZE, MAXCOGSIZE + 1));
            }
            cogSettings.Add(newCogSettings);
            CopyCogSettingsToListbox();
            CreateCogsFromCurrentSettings();
            pictureBoxDisplay.Invalidate();            

        }
    }
}
