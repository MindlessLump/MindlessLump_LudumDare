using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LD35
{
    public partial class MindlessLump_LD35 : Form, IView
    {
        public event Action<string> SaveEvent;
        public event Action QuicksaveEvent;
        public event Action<string> LoadEvent;
        public event Action ExitEvent;
        public event Action HelpEvent;
        public event Action ToggleAutosaveEvent;
        public event Action Button1Event;
        public event Action Button2Event;
        public event Action Button3Event;
        public event Action Button4Event;
        public event Action Button5Event;
        public event Action Button6Event;
        public event Action Button7Event;
        public event Action Button8Event;
        public event Action Button9Event;
        public event Action Button10Event;

        public MindlessLump_LD35()
        {
            InitializeComponent();
            new Controller(this);
        }

        public string AutosaveButtonText
        {
            get { return autosaveToggle.Text; }
            set { autosaveToggle.Text = value; }
        }

        public string PlayerName
        {
            get { return statBlock_nameLabel.Text; }
            set { statBlock_nameLabel.Text = value; }
        }

        public string MainText
        {
            get { return mainPage.DocumentText; }
            set { mainPage.DocumentText = value; }
        }

        public string Message
        {
            set
            {
                MessageBox.Show(value, "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        public DialogResult Warning(string message)
        {
            return MessageBox.Show(message, "Warning", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
        }

        public void DoClose()
        {
            Close();
        }

        public void UpdateCoreStats(string[] newInfo)
        {
            if (newInfo == null)
            {
                throw new ArgumentNullException();
            }
            if (newInfo.Length != 10)
            {
                throw new ArgumentException("String array wrong size.");
            }
            coreStats_strengthValue.Text = newInfo[0];
            if (newInfo[1] != "")
            {
                coreStats_strengthImage.Image = Image.FromFile(newInfo[1]);
            }
            coreStats_toughnessValue.Text = newInfo[2];
            if (newInfo[3] != "")
            {
                coreStats_toughnessImage.Image = Image.FromFile(newInfo[3]);
            }
            coreStats_speedValue.Text = newInfo[4];
            if (newInfo[5] != "")
            {
                coreStats_speedImage.Image = Image.FromFile(newInfo[5]);
            }
            coreStats_accuracyValue.Text = newInfo[6];
            if (newInfo[7] != "")
            {
                coreStats_accuracyImage.Image = Image.FromFile(newInfo[7]);
            }
            coreStats_corruptionValue.Text = newInfo[8];
            if (newInfo[9] != "")
            {
                coreStats_corruptionImage.Image = Image.FromFile(newInfo[9]);
            }
        }

        public void UpdateCombatStats(string[] newInfo)
        {
            if (newInfo == null)
            {
                throw new ArgumentNullException();
            }
            if (newInfo.Length != 4)
            {
                throw new ArgumentException("String array wrong size.");
            }
            combatStats_hpValue.Text = newInfo[0];
            if (newInfo[1] != "")
            {
                combatStats_hpImage.Image = Image.FromFile(newInfo[1]);
            }
            combatStats_fatigueValue.Text = newInfo[2];
            if (newInfo[3] != "")
            {
                combatStats_fatigueImage.Image = Image.FromFile(newInfo[3]);
            }
        }

        public void UpdateAdvancementStats(string[] newInfo)
        {
            if (newInfo == null)
            {
                throw new ArgumentNullException();
            }
            if (newInfo.Length != 6)
            {
                throw new ArgumentException("String array wrong size.");
            }
            advancementStats_levelValue.Text = newInfo[0];
            if (newInfo[1] != "")
            {
                advancementStats_levelImage.Image = Image.FromFile(newInfo[1]);
            }
            advancementStats_xpValue.Text = newInfo[2];
            if (newInfo[3] != "")
            {
                advancementStats_xpImage.Image = Image.FromFile(newInfo[3]);
            }
            advancementStats_goldValue.Text = newInfo[4];
            if (newInfo[5] != "")
            {
                advancementStats_goldImage.Image = Image.FromFile(newInfo[5]);
            }
        }

        public void UpdateButtonText(string[] newInfo)
        {
            if (newInfo == null)
            {
                throw new ArgumentNullException();
            }
            if (newInfo.Length != 10)
            {
                throw new ArgumentException("String array wrong size.");
            }
            button1.Text = newInfo[0];
            button2.Text = newInfo[1];
            button3.Text = newInfo[2];
            button4.Text = newInfo[3];
            button5.Text = newInfo[4];
            button6.Text = newInfo[5];
            button7.Text = newInfo[6];
            button8.Text = newInfo[7];
            button9.Text = newInfo[8];
            button10.Text = newInfo[9];
        }

        public void UpdateGameDateTime(string[] newInfo)
        {
            if (newInfo == null)
            {
                throw new ArgumentNullException();
            }
            if (newInfo.Length != 2)
            {
                throw new ArgumentException("String array wrong size.");
            }
            dateLabel.Text = newInfo[0];
            timeLabel.Text = newInfo[1];
        }

        public string GetSaveFile()
        {
            SaveFileDialog dialog = new SaveFileDialog();
            dialog.Filter = "Text File (.txt)|*.txt|All Files (*.*)|*.*";
            dialog.FilterIndex = 1;

            DialogResult result = dialog.ShowDialog();
            if (result == DialogResult.Yes || result == DialogResult.OK)
            {
                return dialog.FileName;
            }
            else
            {
                return null;
            }
        }

        private void file_saveGame_Click(object sender, EventArgs e)
        {
            SaveFileDialog dialog = new SaveFileDialog();
            dialog.Filter = "Text File (.txt)|*.txt|All Files (*.*)|*.*";
            dialog.FilterIndex = 1;

            DialogResult result = dialog.ShowDialog();
            if (result == DialogResult.Yes || result == DialogResult.OK)
            {
                SaveEvent?.Invoke(dialog.FileName);
            }
        }

        private void file_quicksave_Click(object sender, EventArgs e)
        {
            QuicksaveEvent?.Invoke();
        }

        private void file_loadGame_Click(object sender, EventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Filter = "Text File (.txt)|*.txt|All Files (*.*)|*.*";
            dialog.FilterIndex = 1;
            dialog.Multiselect = false;

            DialogResult result = dialog.ShowDialog();
            if (result == DialogResult.Yes || result == DialogResult.OK)
            {
                LoadEvent?.Invoke(dialog.FileName);
            }
        }

        private void file_exit_Click(object sender, EventArgs e)
        {
            ExitEvent?.Invoke();
        }

        private void helpMenu_Click(object sender, EventArgs e)
        {
            HelpEvent?.Invoke();
        }

        private void autosaveToggle_Click(object sender, EventArgs e)
        {
            ToggleAutosaveEvent?.Invoke();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Button1Event?.Invoke();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Button2Event?.Invoke();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Button3Event?.Invoke();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Button4Event?.Invoke();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Button5Event?.Invoke();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            Button6Event?.Invoke();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            Button7Event?.Invoke();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            Button8Event?.Invoke();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            Button9Event?.Invoke();
        }

        private void button10_Click(object sender, EventArgs e)
        {
            Button10Event?.Invoke();
        }

        private void MindlessLump_LD35_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Q || e.KeyCode == Keys.D1)
            {
                Button1Event?.Invoke();
            }
            else if (e.KeyCode == Keys.W || e.KeyCode == Keys.D2)
            {
                Button2Event?.Invoke();
            }
            else if (e.KeyCode == Keys.E || e.KeyCode == Keys.D3)
            {
                Button3Event?.Invoke();
            }
            else if (e.KeyCode == Keys.R || e.KeyCode == Keys.D4)
            {
                Button4Event?.Invoke();
            }
            else if (e.KeyCode == Keys.T || e.KeyCode == Keys.D5)
            {
                Button5Event?.Invoke();
            }
            else if (e.KeyCode == Keys.A || e.KeyCode == Keys.D6)
            {
                Button6Event?.Invoke();
            }
            else if (e.KeyCode == Keys.S || e.KeyCode == Keys.D7)
            {
                Button7Event?.Invoke();
            }
            else if (e.KeyCode == Keys.D || e.KeyCode == Keys.D8)
            {
                Button8Event?.Invoke();
            }
            else if (e.KeyCode == Keys.F || e.KeyCode == Keys.D9)
            {
                Button9Event?.Invoke();
            }
            else if (e.KeyCode == Keys.G || e.KeyCode == Keys.D0)
            {
                Button10Event?.Invoke();
            }
        }
    }
}
