using Sandbox.Game.EntityComponents;
using Sandbox.ModAPI.Ingame;
using Sandbox.ModAPI.Interfaces;
using SpaceEngineers.Game.ModAPI.Ingame;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text;
using System;
using VRage;
using VRage.Collections;
using VRage.Game.Components;
using VRage.Game.ModAPI.Ingame;
using VRage.Game.ModAPI.Ingame.Utilities;
using VRage.Game.ObjectBuilders.Definitions;
using VRage.Game;
using VRageMath;

namespace IngameScript
{
    partial class Program : MyGridProgram
    {


        List<IMyTerminalBlock> rotorList = new List<IMyTerminalBlock>();

        public Program()
        {
            Runtime.UpdateFrequency = UpdateFrequency.Update10;
            HardwareCheck();
        }

        public void Save()
        {
            // Called when the program needs to save its state. Use
            // this method to save your state to the Storage field
            // or some other means. 
            // 
            // This method is optional and can be removed if not
            // needed.
        }

        public void Main(string argument, UpdateType updateSource)
        {

        }

        public void HardwareCheck()
        {
            // block declarations
            string ERR_TXT = "";
            string[] rightParts = new string[4];
            string[] leftParts = new string[4];
            rightParts[0] = "Hip FR"; rightParts[1] = "Hip BR"; rightParts[2] = "Knee FR"; rightParts[3] = "Knee BR";
            leftParts[0] = "Hip FL"; leftParts[1] = "Hip BL"; leftParts[2] = "Knee FL"; leftParts[3] = "Knee BL";

            var debugLCD = GridTerminalSystem.GetBlockWithName("LCD Debug") as IMyTextPanel;
            debugLCD.ContentType = VRage.Game.GUI.TextPanel.ContentType.TEXT_AND_IMAGE;


            GridTerminalSystem.GetBlocksOfType<IMyMotorStator>(rotorList);

            if (rotorList.Count == 0)
            {
                ERR_TXT += "no Rotor blocks found\n";
            }
            else
            {
                for (int i = 0; i < rotorList.Count; i++)
                {
                    for (int j = 0; j < rightParts.Length; j++)
                    {
                        bool test = false;
                        if (rotorList[i].CustomName == rightParts[j])
                        {
                            test = true;
                        }
                        if (test == false)
                        {
                            ERR_TXT += rightParts[j] + " not found\n";
                        }
                    }

                }
            }
            // display errors
            if (ERR_TXT != "")
            {
                Echo("Hardware Errors:\n" + ERR_TXT);
                debugLCD.WriteText(ERR_TXT, true);
            }
            else
            {
                Echo("");
                debugLCD.WriteText(ERR_TXT, true);
            }

            // logic
            return;
        }
    }
}