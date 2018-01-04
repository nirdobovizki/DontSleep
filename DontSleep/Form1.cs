using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DontSleep
{
    public partial class Form1 : Form
    {

        private class Native
        {
            [DllImport("kernel32.dll", CharSet = CharSet.Auto, SetLastError = true)]
            public static extern EXECUTION_STATE SetThreadExecutionState(EXECUTION_STATE esFlags);

            [FlagsAttribute]
            public enum EXECUTION_STATE : uint
            {
                ES_AWAYMODE_REQUIRED = 0x00000040,
                ES_CONTINUOUS = 0x80000000,
                ES_DISPLAY_REQUIRED = 0x00000002,
                ES_SYSTEM_REQUIRED = 0x00000001
                // Legacy flag, should not be used.
                // ES_USER_PRESENT = 0x00000004
            }
        }

        public void DisableSleep()
        {
            Native.SetThreadExecutionState(Native.EXECUTION_STATE.ES_CONTINUOUS | Native.EXECUTION_STATE.ES_SYSTEM_REQUIRED| Native.EXECUTION_STATE.ES_DISPLAY_REQUIRED);
        }

        public void ReeanbleSleep()
        {
            Native.SetThreadExecutionState(Native.EXECUTION_STATE.ES_CONTINUOUS);
        }


        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            DisableSleep();
        }
    }
}
