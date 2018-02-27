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

namespace img
{
    public partial class Form1 : Form
    {
        ImgController prog;
        SettingsParser sets;
        string CurrentImage;
        ToolTip hint;
        int HintDelay = 2000;

        public Form1() => InitializeComponent();


        private void Form1_Load(object sender, EventArgs e)
        {
            MouseWheel += Form1_MouseWheel;
            Reload();
        }

        private void Form1_MouseWheel(object sender, MouseEventArgs e)
        {
            if (e.Delta < 0)
                Next();
            else if (e.Delta > 0)
                Prev();
        }

        private void Reload()
        {
            prog = new ImgController();
            sets = new SettingsParser(AppDomain.CurrentDomain.BaseDirectory + "settings.xml");
            sets.ProcessToController(prog);
            ToolStripMenuItemPrev.Visible = !sets.sets.DisableBack;
            hint = new ToolTip
            {
                InitialDelay = HintDelay,
                ReshowDelay = HintDelay,
                Active = sets.sets.ShowToolTip
            };
            Next();
        }

        private void LoadImage(string ImageName)
        {
            if (CurrentImage == ImageName) return;
            hint.Hide(pictureBox1);
            CurrentImage = ImageName;
            var pic = new Bitmap(ImageName);
            // SetClientSizeCore(pic.Width,pic.Height);
            pictureBox1.Width = pic.Width;
            pictureBox1.Height = pic.Height;
            /* if x or y > desktop
             *  get the proportion of sides
                get the larger side 
                scale the larger side to desktop
                scale the smaller side by proportion
             */
            pictureBox1.Image = pic;
            hint.SetToolTip(pictureBox1, ImageName);
        }

        private void Next() => LoadImage(prog.Next());

        private void Prev()
        {
            if (!sets.sets.DisableBack) LoadImage(prog.Prev());
        }

        private void pictureBox1_Click(object sender, EventArgs e) => Next();

        private void nextToolStripMenuItem_Click(object sender, EventArgs e) => Next();

        private void exitToolStripMenuItem_Click(object sender, EventArgs e) => Application.Exit();

        private void statsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show($"{prog.TotalCount} images total\n" +
                $"{prog.Position} current | {prog.QueueCount} shown\n" +
                $"{prog.Current}");
        }

        private void previousToolStripMenuItem_Click(object sender, EventArgs e) => Prev();

        private void settingsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (new FormSettings(sets).ShowDialog() == DialogResult.OK)
                Reload();
        }

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e) => Delete();

        private void Delete()
        {
            var res = MessageBox.Show($"Really delete the file\"{prog.Current}\"", "img", MessageBoxButtons.YesNo);
            if (res == DialogResult.Yes)
            {
                prog.DeleteCurrent();
                Next();
            }
        }

        private void reloadToolStripMenuItem_Click(object sender, EventArgs e) => Reload();

        private void Form1_KeyUp(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.PageDown:
                case Keys.Space:
                case Keys.Right:
                case Keys.Down:
                    Next();
                    break;
                case Keys.PageUp:
                case Keys.Back:
                case Keys.Left:
                case Keys.Up:
                    Prev();
                    break;
                case Keys.Delete:
                    Delete();
                    break;
            }
        }
    }
}
