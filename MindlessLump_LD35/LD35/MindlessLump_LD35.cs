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
        public event Action SaveEvent;
        public event Action QuicksaveEvent;
        public event Action LoadEvent;
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

        public string RichText
        {
            get { return richTextBox.Text; }
            set { richTextBox.Text = value; }
        }

        public int GameDate
        {
            get { return int.Parse(dateLabel.Text.Substring(8)); }
            set { dateLabel.Text = "Date #: " + value; }
        }

        public int GameTime
        {
            get { return int.Parse(timeLabel.Text.Split(':')[1].Substring(1)); }
            set { timeLabel.Text = "Time: " + value + ":00"; }
        }

        public void UpdateCoreStats(string[] newInfo)
        {
            // TODO
        }

        public void UpdateCombatStats(string[] newInfo)
        {
            // TODO
        }

        public void UpdateAdvancementStats(string[] newInfo)
        {
            // TODO
        }

        public void UpdateButtonText(string[] newInfo)
        {
            // TODO
        }
    }
}
