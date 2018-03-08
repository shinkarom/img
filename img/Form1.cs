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
            if (ImageName == CurrentImage) return;
            hint.Hide(pictureBox1);
            CurrentImage = ImageName;
            var pic = new Bitmap(ImageName);
            // if x or y > desktop
            int wid = Screen.PrimaryScreen.WorkingArea.Width;
            int hei = Screen.PrimaryScreen.WorkingArea.Height;
            int w, h;
            if (pic.Width > wid || pic.Height > hei)
            {
                if (wid > hei)
                {
                    float ratio = (float)pic.Height / pic.Width;
                    h = hei;
                    w = (int)(h / ratio);
                }
                else
                {
                    float ratio = (float)pic.Height / pic.Width;
                    w = wid;
                    h = (int)(w * ratio);
                }
            }
            else
            {
                w = pic.Width;
                h = pic.Height;
            }
            SetBounds(Bounds.X,Bounds.Y,w,h);
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
                $"{prog.Current}\n");
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
                var c = prog.Current;
                Next();
                prog.DeleteItem(c);
                MessageBox.Show($"File \"{c}\" was deleted");
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
