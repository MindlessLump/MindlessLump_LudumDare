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
        private static string[] buttonDest = { "", "", "", "", "", "", "", "", "", "" };
        private static bool autosaveOn = false;
        private static string previousFile = "";
        private static string currLoc = "";
        private static Dictionary<string, string> descriptors = new Dictionary<string, string>();

        public Controller (IView w)
        {
            // Connect controller to GUI through interface
            window = w;

            // Setup menu page
            descriptors.Add("@Theme", "<b>Shapeshift</b>");
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
            string prevLoc = currLoc;
            window.MainText = GetStringFromFile("main.html");
            buttonInfo[0] = "Next";
            buttonDest[0] = prevLoc;
        }

        private void ToggleAutosaveEventHandler()
        {
            autosaveOn = !autosaveOn;
            if (autosaveOn)
            {
                window.AutosaveButtonText = "Turn Autosave OFF";
            }
            else
            {
                window.AutosaveButtonText = "Turn Autosave ON";
            }
        }

        private void Button1EventHandler()
        {
            if (buttonDest[0] != "")
            {
                window.MainText = GetStringFromFile(buttonDest[0]);
            }
        }

        private void Button2EventHandler()
        {
            if (buttonDest[1] != "")
            {
                window.MainText = GetStringFromFile(buttonDest[1]);
            }
        }

        private void Button3EventHandler()
        {
            if (buttonDest[2] != "")
            {
                window.MainText = GetStringFromFile(buttonDest[2]);
            }
        }

        private void Button4EventHandler()
        {
            if (buttonDest[3] != "")
            {
                window.MainText = GetStringFromFile(buttonDest[3]);
            }
        }

        private void Button5EventHandler()
        {
            if (buttonDest[4] != "")
            {
                window.MainText = GetStringFromFile(buttonDest[4]);
            }
        }

        private void Button6EventHandler()
        {
            if (buttonDest[5] != "")
            {
                window.MainText = GetStringFromFile(buttonDest[5]);
            }
        }

        private void Button7EventHandler()
        {
            if (buttonDest[6] != "")
            {
                window.MainText = GetStringFromFile(buttonDest[6]);
            }
        }

        private void Button8EventHandler()
        {
            if (buttonDest[7] != "")
            {
                window.MainText = GetStringFromFile(buttonDest[7]);
            }
        }

        private void Button9EventHandler()
        {
            if (buttonDest[8] != "")
            {
                window.MainText = GetStringFromFile(buttonDest[8]);
            }
        }

        private void Button10EventHandler()
        {
            if (buttonDest[9] != "")
            {
                window.MainText = GetStringFromFile(buttonDest[9]);
            }
        }

        public string GetStringFromFile(string file)
        {
            StringBuilder builder = new StringBuilder();
            currLoc = file;
            int fileSection = 0;
            int buttonNum = -1;
            int parseLine = -1;
            foreach (string s in File.ReadLines("../../Files/" + file))
            {
                // HTML section (the part that displays)
                if (fileSection == 0)
                {
                    if (s.Contains("<button"))
                    {
                        fileSection = 1;
                        buttonNum = int.Parse(s.Split('>')[0].Substring(7)) - 1;
                        parseLine = 0;
                    }
                    else
                    {
                        // Replace parts of the string (identified by an '@') with descriptors
                        if (s.Contains("@"))
                        {
                            string[] parts1 = s.Split('@');
                            for (int j = 1; j < parts1.Length; j++)
                            {
                                string[] parts2 = parts1[j].Split(' ', ',', '.', ';', ':', '?', '!', '/', '\\', '<', '\n', '\t', '\r');
                                if (parts2[0] != null && parts2[0] != "")
                                {
                                    string wordToBeReplaced = parts2[0];
                                    string replacement = "";
                                    if (descriptors.TryGetValue("@" + wordToBeReplaced, out replacement))
                                    {
                                        builder.Append(s);
                                        builder.Replace("@" + wordToBeReplaced, replacement);
                                    }
                                    else
                                    {
                                        builder.Append(s);
                                    }
                                }
                                else
                                {
                                    builder.Append(s);
                                }
                            }
                        }
                        else
                        {
                            builder.Append(s);
                        }
                    }
                }
                // Button section (text and destination)
                else if (fileSection == 1)
                {
                    if (s.Contains("<button"))
                    {
                        buttonNum = int.Parse(s.Split('>')[0].Substring(7)) - 1;
                        parseLine = 0;
                    }
                    else if (s.Contains("</button"))
                    {
                        parseLine = -1;
                    }
                    else if (s.Contains("<stats>"))
                    {
                        fileSection = 2;
                    }
                    else
                    {
                        if (parseLine == 0)
                        {
                            buttonInfo[buttonNum] = s.Trim();
                            parseLine = 1;
                        }
                        else if (parseLine == 1)
                        {
                            buttonDest[buttonNum] = s.Trim();
                        }
                        else
                        {
                            throw new IOException("File not parsing correctly.");
                        }
                    }
                }
                // Stat section (changes)
                else if (fileSection == 2)
                {
                    // TODO parse stat changes
                }
            }
            return builder.ToString();
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
