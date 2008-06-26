﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using System.Reflection;
using System.Collections;
using System.Collections.Specialized;
using System.Configuration;
using System.IO;
using TibiaTekPlus.Plugins;

namespace TibiaTekPlus
{
    public partial class MainForm : Form
    {

        private Kernel Kernel
        {
            get
            {
                return global::TibiaTekPlus.Program.kernel;
            }
        }

        public MainForm()
        {
            InitializeComponent();
            
            
        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void plugInManagerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Kernel.pluginsForm.Show();
        }

    }
}