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
            sets.FileName = sp.FileName;
            foreach (var item in sp.sets.Paths)
                sets.sets.Paths.Add(new Path(item.Name, item.IsEnabled));
            sets.sets.DisableBack = sp.sets.DisableBack;
            sets.sets.ShowToolTip = sp.sets.ShowToolTip;
        }

        private void Settings_Load(object sender, EventArgs e)
        {
            checkedListBoxPaths.Items.Clear();
            NonManualChecking = true;
            foreach (var item in sets.sets.Paths)
                checkedListBoxPaths.Items.Add(item.Name, item.IsEnabled);
            checkBoxDisableBack.Checked = sets.sets.DisableBack;
            checkBoxShowToolTip.Checked = sets.sets.ShowToolTip;
            NonManualChecking = false;
        }

        private void buttonOK_Click(object sender, EventArgs e) => sets.Save();

        private void checkedListBox1_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            if (NonManualChecking) return;
            var p = sets.sets.Paths[e.Index];
            p.IsEnabled = (e.NewValue == CheckState.Checked);
            sets.sets.Paths[e.Index] = p;
        }

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            if (folderBrowserDialog1.ShowDialog() == DialogResult.OK)
            {
                Path p = new Path(folderBrowserDialog1.SelectedPath, true);
                sets.sets.Paths.Add(p);
                checkedListBoxPaths.SelectedIndex = checkedListBoxPaths.Items.Add(p.Name, true);
            }
        }

        private void checkedListBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            buttonRemove.Enabled = checkedListBoxPaths.SelectedIndex != -1;
            buttonUp.Enabled = checkedListBoxPaths.SelectedIndex > 0;
            buttonDown.Enabled = (checkedListBoxPaths.SelectedIndex != -1) &&
                (checkedListBoxPaths.SelectedIndex < checkedListBoxPaths.Items.Count - 1);
        }

        private void buttonRemove_Click(object sender, EventArgs e)
        {
            sets.sets.Paths.RemoveAt(checkedListBoxPaths.SelectedIndex);
            checkedListBoxPaths.Items.RemoveAt(checkedListBoxPaths.SelectedIndex);
        }

        private void buttonUp_Click(object sender, EventArgs e)
        {
            var i = checkedListBoxPaths.SelectedIndex;
            var p = sets.sets.Paths[i];
            sets.sets.Paths.RemoveAt(i);
            sets.sets.Paths.Insert(i - 1, p);
            //
            var pl = checkedListBoxPaths.Items[i];
            checkedListBoxPaths.Items.RemoveAt(i);
            checkedListBoxPaths.Items.Insert(i - 1, pl);
            checkedListBoxPaths.SetItemChecked(i - 1, p.IsEnabled);
            checkedListBoxPaths.SelectedIndex = i - 1;
        }

        private void buttonDown_Click(object sender, EventArgs e)
        {
            var i = checkedListBoxPaths.SelectedIndex;
            var p = sets.sets.Paths[i + 1];
            sets.sets.Paths.RemoveAt(i + 1);
            sets.sets.Paths.Insert(i, p);
            //
            var pl = checkedListBoxPaths.Items[i + 1];
            checkedListBoxPaths.Items.RemoveAt(i + 1);
            checkedListBoxPaths.Items.Insert(i, pl);
            checkedListBoxPaths.SetItemChecked(i, p.IsEnabled);
            checkedListBoxPaths.SelectedIndex = i + 1;
        }

        private void checkBoxDisableBack_CheckedChanged(object sender, EventArgs e)
        {
            if (NonManualChecking) return;
            sets.sets.DisableBack = checkBoxDisableBack.Checked;
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (NonManualChecking) return;
            sets.sets.ShowToolTip = checkBoxShowToolTip.Checked;
        }
    }
}
