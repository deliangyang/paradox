// Copyright (c) 2014 Silicon Studio Corp. (http://siliconstudio.co.jp)
// This file is distributed under GPL v3. See LICENSE.md for details.
using System.Windows;
using System.Windows.Threading;
using Microsoft.WindowsAPICodePack.Dialogs;
using SiliconStudio.Presentation.Services;

namespace SiliconStudio.Presentation.Dialogs
{
    public class FolderOpenModalDialog : ModalDialogBase, IFolderOpenModalDialog
    {
        internal FolderOpenModalDialog(Dispatcher dispatcher, Window parentWindow)
            : base(dispatcher, parentWindow)
        {
            Dialog = new CommonOpenFileDialog { EnsurePathExists = true };
            OpenDlg.IsFolderPicker = true;
        }

        /// <inheritdoc/>
        public string Directory { get; private set; }

        /// <inheritdoc/>
        public string InitialDirectory { get { return OpenDlg.InitialDirectory; } set { OpenDlg.InitialDirectory = value.Replace('/', '\\'); } }

        private CommonOpenFileDialog OpenDlg { get { return (CommonOpenFileDialog)Dialog; } }

        public override DialogResult Show()
        {
            var result = InvokeDialog();
            Directory = result != DialogResult.Cancel ? OpenDlg.FileName : null;
            return result;
        }
    }
}