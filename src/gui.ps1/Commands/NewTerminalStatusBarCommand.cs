﻿using System.Collections.Generic;
using System.Management.Automation;
using Terminal.Gui;

namespace GuiPs1.Commands
{
    [Cmdlet(VerbsCommon.New, "TerminalStatusBar")]
    [OutputType(typeof(StatusBar))]
    public sealed class NewTerminalStatusBarCommand : NewTerminalCommandBase
    {
        private readonly List<StatusItem> statusItems = new List<StatusItem>();

        [Parameter(Mandatory = true, ValueFromPipeline = true)]
        public StatusItem? StatusItem { get; set; }

        protected override void BeginProcessing() => base.BeginProcessing();

        protected override void ProcessRecord()
        {
            if (this.StatusItem is null)
                return;

            this.statusItems.Add(this.StatusItem);
        }

        protected override void EndProcessing() => this.WriteObject(new StatusBar(this.statusItems.ToArray()));
    }
}