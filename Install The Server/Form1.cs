using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Server_Installer_Forms
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void ButtonAccept_Click(object sender, EventArgs e)
        {
            if (Amx182Box.CheckState == CheckState.Unchecked &&
                Amx182DevBox.CheckState == CheckState.Unchecked &&
                Amx183DevBox.CheckState == CheckState.Unchecked
                ) AmxBox.Version = 0;

            Server_Installer_Forms.WorkFunc.MainFunction();
        }

        private void Amx182Box_CheckedChanged(object sender, EventArgs e)
        {
            if (Amx182Box.CheckState == CheckState.Checked)
            {
                AmxBox.LastStatus = true;
                AmxBox.DevStatus = false;
                AmxBox.Version = 1;

                Amx182DevBox.CheckState = CheckState.Unchecked;
                Amx183DevBox.CheckState = CheckState.Unchecked;
            }
        }

        private void Amx182DevBox_CheckedChanged(object sender, EventArgs e)
        {
            if(Amx182DevBox.CheckState == CheckState.Checked)
            {
                AmxBox.DevStatus = false;
                AmxBox.LastStatus = false;
                AmxBox.Version = 2;

                Amx182Box.CheckState = CheckState.Unchecked;
                Amx183DevBox.CheckState = CheckState.Unchecked;
            }
        }

        private void Amx183DevBox_CheckedChanged(object sender, EventArgs e)
        {
            if (Amx183DevBox.CheckState == CheckState.Checked)
            {
                AmxBox.DevStatus = true;
                AmxBox.LastStatus = false;
                AmxBox.Version = 3;

                Amx182Box.CheckState = CheckState.Unchecked;
                Amx182DevBox.CheckState = CheckState.Unchecked;
            }
        }

        private void MetamodBox_CheckedChanged(object sender, EventArgs e)
        {
            if (metamodBox.CheckState == CheckState.Checked)
                MetamodBox.MetamodStatus = true;
            else
                MetamodBox.MetamodStatus = false;
        }
    }

    public class AmxBox
    {
        public static int Version;
        public static bool DevStatus { get; internal set; }
        public static bool LastStatus { get; internal set; }
    }

    public class MetamodBox
    {
        public static bool MetamodStatus { get; internal set; }
    }
}
