﻿using System;
using System.Diagnostics;
using System.IO;
using System.Windows.Forms;
using GitCommands;

namespace GitUI
{
    public partial class FormMailMap : GitExtensionsForm
    {
        public string MailMapFile;

        public FormMailMap()
        {
            InitializeComponent();
            Translate();
            MailMapFile = "";

            try
            {
                var mailMap = Settings.WorkingDir + ".mailmap";
                if (File.Exists(mailMap))
                    using (var re = new StreamReader(mailMap, Settings.Encoding))
                        MailMapFile = re.ReadToEnd();

                _NO_TRANSLATE_MailMapText.Text = MailMapFile;
            }
            catch (Exception ex)
            {
                Trace.WriteLine(ex.Message);
            }
        }

        private void SaveClick(object sender, EventArgs e)
        {
            FileInfoExtensions
                .MakeFileTemporaryWriteable(
                    Settings.WorkingDir + ".mailmap",
                    x =>
                        {
                            // Enter a newline to work around a wierd bug 
                            // that causes the first line to include 3 extra bytes. (encoding marker??)
                            MailMapFile = Environment.NewLine + _NO_TRANSLATE_MailMapText.Text.Trim();
                            using (TextWriter tw = new StreamWriter(x, false, Settings.Encoding))
                                tw.Write(MailMapFile);
                            Close();
                        });
        }

        private void FormMailMapFormClosing(object sender, FormClosingEventArgs e)
        {
            SavePosition("edit-mail-map");
        }

        private void FormMailMapLoad(object sender, EventArgs e)
        {
            RestorePosition("edit-mail-map");
            if (!Settings.IsBareRepository()) return;
            MessageBox.Show(".mailmap is only supported when there is a working dir.");
            Close();
        }
    }
}