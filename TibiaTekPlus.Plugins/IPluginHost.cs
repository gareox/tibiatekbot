﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TibiaTekPlus.Plugins
{
    public interface IPluginHost
    {

        /// <summary>
        /// Starts the kernel, enables the use of plug-ins. This function is called when the main form is ready.
        /// </summary>
        void Enable();

        /// <summary>
        /// Stops the kernel, stops all plug-ins currently running. This function is called when disconnected or exiting.
        /// </summary>
        void Disable();

        /// <summary>
        /// Pauses the kernel, all plug-ins running are paused
        /// </summary>
        void Pause();

        /// <summary>
        /// Resumes the kernel, all paused plug-ins are resumed
        /// </summary>
        void Resume();

        string Get(string pluginName, string key);
        void Set(string pluginName, string key, string value);

        /// <summary>
        /// Gets/sets a reference to the client object.
        /// </summary>
        Tibia.Objects.Client Client{get;set;}

        /// <summary>
        /// Gets or sets the current Tibia version
        /// </summary>
        string TibiaVersion { get; set; }

        PluginCollection Plugins { get; }
    }
}
