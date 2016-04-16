using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LD35
{
    /// <summary>
    /// Controllable interface of MindlessLump_LD35
    /// </summary>
    public interface IView
    {
        // Events triggered by the GUI that must be handled by the Controller
        // View -> Controller
        event Action SaveEvent;
        event Action QuicksaveEvent;
        event Action LoadEvent;
        event Action ExitEvent;
        event Action HelpEvent;
        event Action ToggleAutosaveEvent;
        event Action Button1Event;
        event Action Button2Event;
        event Action Button3Event;
        event Action Button4Event;
        event Action Button5Event;
        event Action Button6Event;
        event Action Button7Event;
        event Action Button8Event;
        event Action Button9Event;
        event Action Button10Event;

        // Data implemented by the GUI that can be accessed by the Controller
        // Controller -> View
        string AutosaveButtonText { get; set; }
        string PlayerName { get; set; }
        string RichText { get; set; }
        int GameDate { get; set; }
        int GameTime { get; set; }

        // Methods implemented by the GUI that can be called by the Controller
        // Controller -> View
        void UpdateCoreStats(string[] newInfo);
        void UpdateCombatStats(string[] newInfo);
        void UpdateAdvancementStats(string[] newInfo);
        void UpdateButtonText(string[] newInfo);
    }
}
