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
            var forward = inputs.ContainsKey("w");
            var attention = inputs.ContainsKey("e");

            // LCD declarations
            var statusLegsLCD = GridTerminalSystem.GetBlockWithName("LCD Legs Status") as IMyTextPanel;

            // display
            if (statusLegsLCD != null) {
                statusLegsLCD.ContentType = ContentType.TEXT_AND_IMAGE;
                statusLegsLCD.WriteText("", false);
                if (HipHFR == null) { statusLegsLCD.WriteText("HipHFR not found \n", true); }
                if (HipHBR == null) { statusLegsLCD.WriteText("HipHBR not found \n", true); }
                if (HipVFR == null) { statusLegsLCD.WriteText("HipVFR not found \n", true); }
                if (HipVBR == null) { statusLegsLCD.WriteText("HipVBR not found \n", true); }
                if (KneeFR == null) { statusLegsLCD.WriteText("KneeFR not found \n", true); }
                if (KneeBR == null) { statusLegsLCD.WriteText("KneeBR not found \n", true); }
                if (HipHFL == null) { statusLegsLCD.WriteText("HipHFL not found \n", true); }
                if (HipHBL == null) { statusLegsLCD.WriteText("HipHBL not found \n", true); }
                if (HipVFL == null) { statusLegsLCD.WriteText("HipVFL not found \n", true); }
                if (HipVBL == null) { statusLegsLCD.WriteText("HipVBL not found \n", true); }
                if (KneeFL == null) { statusLegsLCD.WriteText("KneeFL not found \n", true); }
                if (KneeBL == null) { statusLegsLCD.WriteText("KneeBL not found \n", true); }
                statusLegsLCD.WriteText("\n", true);
            }
            else { Echo("Status LCD missing"); }
            // logic
            var positiveSpeed = 20;
            var negativeSpeed = -20;
            HipHFR.LowerLimitDeg = -45;
            HipHFR.UpperLimitDeg = 90;
            HipHBR.LowerLimitDeg = -90;
            HipHBR.UpperLimitDeg = 45;
            var test = true;
            // attention position
            if (test == true)
            {
                if (HipHFR.Angle > 47 * (Math.PI / 180)) { HipHFR.TargetVelocityRPM = -positiveSpeed * (-47 + Math.Abs(HipHFR.Angle)); } else if (HipHFR.Angle < 43 * (Math.PI / 180)) { HipHFR.TargetVelocityRPM = positiveSpeed * (+43 - Math.Abs(HipHFR.Angle)); } else { HipHFR.TargetVelocityRPM = 0; }

                if (HipHBR.Angle > 47 * (Math.PI / 180)) { HipHBR.TargetVelocityRPM = -positiveSpeed * HipHBR.Angle; } else if (HipHBR.Angle < 43 * (Math.PI / 180)) { HipHBR.TargetVelocityRPM = positiveSpeed * -HipHBR.Angle; } else { HipHBR.TargetVelocityRPM = 0; }
            }
        }

    }
}