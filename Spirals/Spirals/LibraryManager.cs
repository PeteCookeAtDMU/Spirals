using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Spirals
{
    public partial class LibraryManager : Form
    {

        List<List<int>> library;

        Selection selection;


        public LibraryManager(List<List<int>> library, Selection selection)
        {
            InitializeComponent();


            this.library = library;
            this.selection = selection;
        }

        private void LibraryManager_Load(object sender, EventArgs e)
        {
            DisplayLibraryInListBox();

            buttonUse.Enabled = (listBoxLibrary.SelectedIndex != -1);
        }

        private void DisplayLibraryInListBox()
        {
            listBoxLibrary.Items.Clear();
            foreach (List<int> list in library)
            {
                listBoxLibrary.Items.Add(GetTextRepresentation(list));
            }
        }

        private string GetTextRepresentation(List<int> list)
        {
            StringBuilder sb = new StringBuilder();

            for (int i = 0; i < list.Count; i++)
            {
                sb.Append(Convert.ToString(list[i]));
                if (i < list.Count - 1)
                {
                    sb.Append(" ");
                }

            }
            return sb.ToString();
        }

        private void listBoxLibrary_SelectedIndexChanged(object sender, EventArgs e)
        {
            selection.Choice = listBoxLibrary.SelectedIndex;
            buttonUse.Enabled = true;
        }

        private void buttonDelete_Click(object sender, EventArgs e)
        {
            int index = listBoxLibrary.SelectedIndex;
            if (index != -1)
            {
                library.RemoveAt(index);
                DisplayLibraryInListBox();
                buttonUse.Enabled = (listBoxLibrary.SelectedIndex != -1);
            }
        }
    }
}
