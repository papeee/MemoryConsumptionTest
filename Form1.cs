using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MemoryConsumptionTest
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            
            InitializeComponent();
            TestStringConsumption();
            TestStringBuilderConsumption();
        }

        private static long currentMemoryUsage = 0;
        private static long AppMemoryUsage = 0;

        /// <summary>
        /// Memory consumption test of string manipulation
        /// </summary>
        private void TestStringConsumption()
        {
            Process currentProcess = Process.GetCurrentProcess();
            long usedMemory = currentProcess.PrivateMemorySize64;
            //currentMemoryUsage = usedMemory;
            AppMemoryUsage = usedMemory;
            //label2.Text = "Applicatiom: "+ usedMemory.ToString();

            string s = "a";
            for (int i = 0; i < 10000; i++)
            {
                if (i > 0)
                    s += i + "b"; // Creates a new string
            }
            currentProcess = Process.GetCurrentProcess();
            usedMemory = currentProcess.PrivateMemorySize64;
            //usedMemory = usedMemory;
            currentMemoryUsage = usedMemory - AppMemoryUsage;
            label3.Text = "String: " + currentMemoryUsage.ToString() + " bytes";
        }

        /// <summary>
        /// Memory consumption test of StringBuilder
        /// </summary>
        private void TestStringBuilderConsumption()
        {
            Process currentProcess = Process.GetCurrentProcess();
            //long usedMemory = currentProcess.PrivateMemorySize64;

            //label2.Text = usedMemory.ToString();

            StringBuilder sb = new StringBuilder();
            sb.Append("a");
            for (int i = 1; i < 10000; i++)
            {
                sb.Append(i).Append("b"); // Append to one string
            }
            currentProcess = Process.GetCurrentProcess();
            long usedMemory = currentProcess.PrivateMemorySize64  - currentMemoryUsage - AppMemoryUsage;
            label4.Text = "StringBuilder: " + usedMemory.ToString() + " bytes";
            
        }
    }
}
