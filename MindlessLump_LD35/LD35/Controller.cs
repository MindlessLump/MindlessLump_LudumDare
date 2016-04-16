using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LD35
{
    class Controller
    {
        private static IView window;
        private static string[] coreStatInfo = { "", "", "", "", "", "", "", "", "", "" };
        private static string[] combatStatInfo = { "", "", "", "" };
        private static string[] advancementStatInfo = { "", "", "", "", "", "" };
        private static string[] dateTimeInfo = { "", "" };
        private static string[] buttonInfo = { "", "", "", "", "", "", "", "", "", "" };
        private static bool autosaveOn = false;
        private static string previousFile = "";

        public Controller (IView w)
        {
            // Connect controller to GUI through interface
            window = w;

            // Setup menu page
            window.MainText = GetStringFromFile("main.html");
            window.UpdateCoreStats(coreStatInfo);
            window.AutosaveButtonText = "Turn Autosave ON";

            // Setup Controller to hook the GUI's events
            window.SaveEvent += SaveEventHandler;
            window.QuicksaveEvent += QuicksaveEventHandler;
            window.LoadEvent += LoadEventHandler;
            window.ExitEvent += ExitEventHandler;
            window.HelpEvent += HelpEventHandler;
            window.ToggleAutosaveEvent += ToggleAutosaveEventHandler;
            window.Button1Event += Button1EventHandler;
            window.Button2Event += Button2EventHandler;
            window.Button3Event += Button3EventHandler;
            window.Button4Event += Button4EventHandler;
            window.Button5Event += Button5EventHandler;
            window.Button6Event += Button6EventHandler;
            window.Button7Event += Button7EventHandler;
            window.Button8Event += Button8EventHandler;
            window.Button9Event += Button9EventHandler;
            window.Button10Event += Button10EventHandler;
        }

        private void SaveEventHandler(string file)
        {
            SaveToFile(file);
            previousFile = file;
        }

        private void QuicksaveEventHandler()
        {
            if (previousFile != null && previousFile.Length > 0)
            {
                SaveToFile(previousFile);
            }
            else
            {
                string file = window.GetSaveFile();
                if (file != null)
                {
                    SaveToFile(file);
                    previousFile = file;
                }
            }
        }

        private void LoadEventHandler(string file)
        {
            LoadFromFile(file);
            previousFile = file;
        }

        private void ExitEventHandler()
        {
            DialogResult result = window.Warning("Are you sure you want to quit the game?");
            if (result == DialogResult.OK)
            {
                window.DoClose();
            }
        }

        private void HelpEventHandler()
        {
            // TOOD
        }

        private void ToggleAutosaveEventHandler()
        {
            // TODO
        }

        private void Button1EventHandler()
        {
            // TODO
        }

        private void Button2EventHandler()
        {
            // TODO
        }

        private void Button3EventHandler()
        {
            // TODO
        }

        private void Button4EventHandler()
        {
            // TODO
        }

        private void Button5EventHandler()
        {
            // TODO
        }

        private void Button6EventHandler()
        {
            // TODO
        }

        private void Button7EventHandler()
        {
            // TODO
        }

        private void Button8EventHandler()
        {
            // TODO
        }

        private void Button9EventHandler()
        {
            // TODO
        }

        private void Button10EventHandler()
        {
            // TODO
        }

        public string GetStringFromFile(string file)
        {
            StringBuilder build = new StringBuilder();
            foreach (string s in File.ReadLines("../../Files/" + file))
            {
                build.Append(s);
            }
            return build.ToString();
        }

        public void SaveToFile(string file)
        {
            // TODO
        }

        public void LoadFromFile(string file)
        {
            // TODO
        }
    }
}
