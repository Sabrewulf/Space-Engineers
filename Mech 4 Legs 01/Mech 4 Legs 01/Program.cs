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
using VRage.Game.GUI.TextPanel;

namespace IngameScript
{
    partial class Program : MyGridProgram
    {

        IMyTextPanel screenOne; //trying to put lcd variable here
        List<IMyTerminalBlock> blockList = new List<IMyTerminalBlock>();
        int ticks = 0;
        
        public Program()
        {
            Runtime.UpdateFrequency = UpdateFrequency.Update10;
            
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
            HardwareCheck();

        }

        public void HardwareCheck()
        {
            if (++ticks < 18) return; // for delay

            screenOne = GridTerminalSystem.GetBlockWithName("LCD Debug") as IMyTextPanel;
            screenOne.ContentType = ContentType.TEXT_AND_IMAGE;
            screenOne.WriteText("Hardware Check Timer " +ticks+ "\n", false);

            string ERR_TXT = "";
            string[] rightParts = new string[4];
            string[] leftParts = new string[4];
            rightParts[0] = "Hip FR"; rightParts[1] = "Hip BR"; rightParts[2] = "Knee FR"; rightParts[3] = "Knee BR";
            leftParts[0] = "Hip FL"; leftParts[1] = "Hip BL"; leftParts[2] = "Knee FL"; leftParts[3] = "Knee BL";

            GridTerminalSystem.GetBlocksOfType<IMyFunctionalBlock>(blockList);

            if (blockList.Count == 0)
            {
                ERR_TXT += "no Rotor blocks found\n";
            }
            else
            {
                for (int i = 0; i < blockList.Count; i++)
                {
                    for (int j = 0; j < rightParts.Length; j++)
                    {
                        if (blockList[i].CustomName == rightParts[j])
                        {
                            ERR_TXT += rightParts[j] + " OK\n";
                        }

                    }

                }
            }

            if (ERR_TXT != "")
            {
                Echo("Hardware:\n" + ERR_TXT);
                screenOne.WriteText("Hardware:\n"+ERR_TXT, true);
            }
            else
            {
                Echo("");
                screenOne.WriteText(ERR_TXT, true);
            }
        }
    }
}