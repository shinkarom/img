using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace img
{
    public partial class FormSettings : Form
    {

        SettingsParser sets;
        bool NonManualChecking = false;

        public FormSettings() => InitializeComponent();

        public FormSettings(SettingsParser sp)
        {
            InitializeComponent();
            sets = new SettingsParser();
            foreach (var item in sp.sets.Paths)
                sets.sets.Paths.Add(new Path(item.Name,item.IsActive));
        }

        private void Settings_Load(object sender, EventArgs e)
        {
            checkedListBox1.Items.Clear();
            NonManualChecking = true;
            foreach (var item in sets.sets.Paths)
            {
                checkedListBox1.Items.Add(item.Name, item.IsActive);
            }
            NonManualChecking = false;
        }

        private void buttonOK_Click(object sender, EventArgs e) => sets.Save();

        private void checkedListBox1_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            if (NonManualChecking) return;
            var p = sets.sets.Paths[e.Index];
            p.IsActive = (e.NewValue == CheckState.Checked);
            sets.sets.Paths[e.Index] = p;
        }

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            if (folderBrowserDialog1.ShowDialog() == DialogResult.OK)
            {
                Path p = new Path(folderBrowserDialog1.SelectedPath, true);
                sets.sets.Paths.Add(p);
                checkedListBox1.SelectedIndex = checkedListBox1.Items.Add(p.Name, true);
            }
        }

        private void checkedListBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            buttonRemove.Enabled = checkedListBox1.SelectedIndex != -1;
            buttonUp.Enabled = checkedListBox1.SelectedIndex > 0;
            buttonDown.Enabled = (checkedListBox1.SelectedIndex != -1) &&
                (checkedListBox1.SelectedIndex < checkedListBox1.Items.Count - 1);
        }

        private void buttonRemove_Click(object sender, EventArgs e)
        {
            sets.sets.Paths.RemoveAt(checkedListBox1.SelectedIndex);
            checkedListBox1.Items.RemoveAt(checkedListBox1.SelectedIndex);
        }

        private void buttonUp_Click(object sender, EventArgs e)
        {
            var i = checkedListBox1.SelectedIndex;
            var p = sets.sets.Paths[i];
            sets.sets.Paths.RemoveAt(i);
            sets.sets.Paths.Insert(i - 1, p);
            //
            var pl = checkedListBox1.Items[i];
            checkedListBox1.Items.RemoveAt(i);
            checkedListBox1.Items.Insert(i - 1, pl);
            checkedListBox1.SetItemChecked(i - 1, p.IsActive);
            checkedListBox1.SelectedIndex = i - 1;
        }

        private void buttonDown_Click(object sender, EventArgs e)
        {
            var i = checkedListBox1.SelectedIndex;
            var p = sets.sets.Paths[i+1];
            sets.sets.Paths.RemoveAt(i + 1);
            sets.sets.Paths.Insert(i, p);
            //
            var pl = checkedListBox1.Items[i + 1];
            checkedListBox1.Items.RemoveAt(i + 1);
            checkedListBox1.Items.Insert(i, pl);
            checkedListBox1.SetItemChecked(i, p.IsActive);
            checkedListBox1.SelectedIndex = i + 1;
        }
    }
}
