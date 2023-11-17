using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lastname_pad
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            undoToolStripMenuItem.ShortcutKeys = Keys.Control | Keys.Z;
            redoToolStripMenuItem.ShortcutKeys = Keys.Control | Keys.Y;
            copyToolStripMenuItem.ShortcutKeys = Keys.Control | Keys.C;
            pasteToolStripMenuItem.ShortcutKeys = Keys.Control | Keys.V;
            cutToolStripMenuItem.ShortcutKeys = Keys.Control | Keys.X;
            selectToolStripMenuItem.ShortcutKeys = Keys.Control | Keys.A;
            toolStripStatusLabel1.Text = "Ready";
        }
        private void UpdateStatusLabel(string status)
        {
            
            toolStripStatusLabel1.Text = status;
        }
        private void newToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
          
            OpenFileDialog op = new OpenFileDialog();
            op.Title = "open";
            op.Filter = "Text Document(*.txt)|*.txt| All Files(*.*)|*.*";
            if (op.ShowDialog() == DialogResult.OK)
                richTextBox1.LoadFile(op.FileName, RichTextBoxStreamType.PlainText);
            this.Text = op.FileName;
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
          
            SaveFileDialog sv = new SaveFileDialog();
            sv.Title = "Save";
            sv.Filter = "Text Document(*.txt)|*.txt| All Files(*.*)|*.*";
            if (sv.ShowDialog() == DialogResult.OK)
                richTextBox1.SaveFile(sv.FileName, RichTextBoxStreamType.PlainText);
            this.Text = sv.FileName;
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
          
            string message = "Do you want to close this window?";
            string title = "Close Window";
            MessageBoxButtons buttons = MessageBoxButtons.YesNo;
            DialogResult result = MessageBox.Show(message, title, buttons);
            if (result == DialogResult.Yes)
            {
                this.Close();
            }
            else
            {
               
                MessageBox.Show("Failed to exit","Warning", MessageBoxButtons.OK);
            }
        }

        private void undoToolStripMenuItem_Click(object sender, EventArgs e)
        {
           
            richTextBox1.Undo();
            UpdateStatusLabel("Undo");
        }

        private void redoToolStripMenuItem_Click(object sender, EventArgs e)
        {
          
            richTextBox1.Redo();
            UpdateStatusLabel("Redo");
        }

        private void copyToolStripMenuItem_Click(object sender, EventArgs e)
        {

           
            richTextBox1.Copy();
            UpdateStatusLabel("Copy");
        }

        private void pasteToolStripMenuItem_Click(object sender, EventArgs e)
        {
           
            richTextBox1.Paste();
            UpdateStatusLabel("Paste");
        }

        private void cutToolStripMenuItem_Click(object sender, EventArgs e)
        {
           
            richTextBox1.Cut();
            UpdateStatusLabel("Cut");
        }

        private void selectToolStripMenuItem_Click(object sender, EventArgs e)
        {

           
            richTextBox1.SelectAll();
            UpdateStatusLabel("Select All");
        }

        private void dateTimeToolStripMenuItem_Click(object sender, EventArgs e)
        {

           
            richTextBox1.Text = System.DateTime.Now.ToString();
            UpdateStatusLabel("Date");
        }

        private void fontToolStripMenuItem_Click(object sender, EventArgs e)
        {
           
            FontDialog fo = new FontDialog();
            if (fo.ShowDialog() == DialogResult.OK)
                richTextBox1.Font = fo.Font;
        }

        private void colotToolStripMenuItem_Click(object sender, EventArgs e)
        {
           
            ColorDialog op = new ColorDialog();
            if (op.ShowDialog() == DialogResult.OK)
                richTextBox1.ForeColor = op.Color;

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
        }
        private bool changesMade = false;

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (changesMade)
            {
                DialogResult result = MessageBox.Show("Do you want to save changes?", "Save Changes", MessageBoxButtons.YesNoCancel);

                if (result == DialogResult.Yes)
                {
                    SaveFileDialog sv = new SaveFileDialog();
                    sv.Title = "Save";
                    sv.Filter = "Text Document(*.txt)|*.txt| All Files(*.*)|*.*";
                    if (sv.ShowDialog() == DialogResult.OK)
                        richTextBox1.SaveFile(sv.FileName, RichTextBoxStreamType.PlainText);
                    this.Text = sv.FileName;
                }
                else if (result == DialogResult.Cancel)
                {
                    e.Cancel = true; 
                }
            }    
        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {
            changesMade = true;
        }
    }
}
