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

        public Form1() => InitializeComponent();


        private void Form1_Load(object sender, EventArgs e) => Reload();

        private void Reload()
        {
            sets = new SettingsParser(AppDomain.CurrentDomain.BaseDirectory + "settings.xml");
            prog=new ImgController();
            sets.ProcessToController(prog);
            Next();
        }

        private void Next()
        {
            var n = prog.Next();
            if (pictureBox1.ImageLocation != n) pictureBox1.ImageLocation = n;
        }

        private void Prev()
        {
            var n = prog.Prev();
            if (pictureBox1.ImageLocation != n) pictureBox1.ImageLocation = n;
        }

        private void pictureBox1_Click(object sender, EventArgs e) => Next();

        private void contextMenuStrip1_Opening(object sender, CancelEventArgs e)
        {

        }

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
            FormSettings settings = new FormSettings(sets);
            var res=settings.ShowDialog();
            if(res==DialogResult.OK)
            {
                Reload();
            }
        }

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var res = MessageBox.Show($"Really delete the file\"{prog.Current}\"","img",MessageBoxButtons.YesNo);
            if (res == DialogResult.Yes)
            {
                prog.DeleteCurrent();
                Next();
            }
        }

        private void reloadToolStripMenuItem_Click(object sender, EventArgs e) => Reload();
    }
}
