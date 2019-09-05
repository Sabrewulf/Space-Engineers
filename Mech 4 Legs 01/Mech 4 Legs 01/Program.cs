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

        void Main(string argument)
        {
            /*string ERR_TXT = ""*/
            ;
            // right joints declarations
            string Hip_HFR = "Hip HFR"; string Hip_HBR = "Hip HBR";
            string Hip_VFR = "Hip VFR"; string Hip_VBR = "Hip VBR";
            string Knee_FR = "Knee FR"; string Knee_BR = "Knee BR";
            var HipHFR = GridTerminalSystem.GetBlockWithName(Hip_HFR) as IMyMotorStator;
            var HipHBR = GridTerminalSystem.GetBlockWithName(Hip_HBR) as IMyMotorStator;
            var HipVFR = GridTerminalSystem.GetBlockWithName(Hip_VFR) as IMyMotorStator;
            var HipVBR = GridTerminalSystem.GetBlockWithName(Hip_VBR) as IMyMotorStator;
            var KneeFR = GridTerminalSystem.GetBlockWithName(Knee_FR) as IMyMotorStator;
            var KneeBR = GridTerminalSystem.GetBlockWithName(Knee_BR) as IMyMotorStator;
            // left joints declarations
            string Hip_HFL = "Hip HFL"; string Hip_HBL = "Hip HBL";
            string Hip_VFL = "Hip VFL"; string Hip_VBL = "Hip VBL";
            string Knee_FL = "Knee FL"; string Knee_BL = "Knee BL";
            var HipHFL = GridTerminalSystem.GetBlockWithName(Hip_HFL) as IMyMotorStator;
            var HipHBL = GridTerminalSystem.GetBlockWithName(Hip_HBL) as IMyMotorStator;
            var HipVFL = GridTerminalSystem.GetBlockWithName(Hip_VFL) as IMyMotorStator;
            var HipVBL = GridTerminalSystem.GetBlockWithName(Hip_VBL) as IMyMotorStator;
            var KneeFL = GridTerminalSystem.GetBlockWithName(Knee_FL) as IMyMotorStator;
            var KneeBL = GridTerminalSystem.GetBlockWithName(Knee_BL) as IMyMotorStator;
            // mod control module declarations
            var inputs = Me.GetValue<Dictionary<string, object>>("ControlModule.Inputs");

            // LCD declarations
            var statusLegsLCD = GridTerminalSystem.GetBlockWithName("LCD Legs Status") as IMyTextPanel;

            // display errors
            if (statusLegsLCD != null) {
                statusLegsLCD.ContentType = ContentType.TEXT_AND_IMAGE;
                if (HipHFR == null) { statusLegsLCD.WriteText("HipHFR not found", true); }
                if (HipHFR == null) { statusLegsLCD.WriteText("HipHFR not found", true); }
                if (HipHFR == null) { statusLegsLCD.WriteText("HipHFR not found", true); }
                if (HipHFR == null) { statusLegsLCD.WriteText("HipHFR not found", true); }
                if (HipHFR == null) { statusLegsLCD.WriteText("HipHFR not found", true); }
                if (HipHFR == null) { statusLegsLCD.WriteText("HipHFR not found", true); }
                if (HipHFR == null) { statusLegsLCD.WriteText("HipHFR not found", true); }
                if (HipHFR == null) { statusLegsLCD.WriteText("HipHFR not found", true); }
                if (HipHFR == null) { statusLegsLCD.WriteText("HipHFR not found", true); }
                if (HipHFR == null) { statusLegsLCD.WriteText("HipHFR not found", true); }
                if (HipHFR == null) { statusLegsLCD.WriteText("HipHFR not found", true); }
                if (HipHFR == null) { statusLegsLCD.WriteText("HipHFR not found", true); }
            }
            else { Echo("Status LCD missing", true); }
            // logic

        }

    }
}