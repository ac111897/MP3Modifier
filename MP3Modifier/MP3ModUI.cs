using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TagLib;
using System.Collections.Specialized;
using System.Configuration;
using System.IO;
using MP3Modifier.Library;
using System.Drawing.Imaging;
using System.Diagnostics;
using System.Runtime.InteropServices;
namespace MP3Modifier
{
    public partial class MP3ModUI : Form
    {
        public MP3ModUI()
        {
            InitializeComponent();
            ChangeSongNameBox.Hide();
            OnNewSong += MP3ModUI_OnNewSong;
        }
        #region Fields&Props
        private bool FileHasBeenModified { get; set; }
        private string FilePath { get; set; }
        /// <summary>
        /// The event handler for when a new song is selected;
        /// </summary>
        private event EventHandler OnNewSong;
        /// <summary>
        /// The file name of the song
        /// </summary>
        private string FileName { get; set; } // TODO: Set up file renaming
        /// <summary>
        /// Do not refer to this anywhere other than the current song property
        /// </summary>
        private Song BackingProp { get; set; }
        /// <summary>
        /// The current songs metadata provided access to Changed event handlers for the properties
        /// </summary>
        private Song CurrentSong
        {
            get
            {
                return BackingProp;
            }
            set
            {
                BackingProp = value;
                OnNewSong?.Invoke(this, EventArgs.Empty);
            }
        }
        #endregion
        #region Methods
        /// <summary>
        /// Brings up the hidden text box to change the name of the song
        /// </summary>
        private void ChangeSongName() => ChangeField(ref SongName, ref ChangeSongNameBox);
        /// <summary>
        /// Brings up the hidden text box to change the artist names
        /// </summary>
        private void ChangeArtistNames() => ChangeField(ref ArtistNames, ref ChangeArtistsBox);
        /// <summary>
        /// Brings up the hidden text box to change the album title name
        /// </summary>
        private void ChangeAlbumName() => ChangeField(ref Album, ref ChangeAlbumBox);
        /// <summary>
        /// Closes the hidden text box when the user presses escape or opens another file
        /// </summary>
        private void CloseSongDialog() => CloseDialog(ref SongName, ref ChangeSongNameBox);
        /// <summary>
        /// Closes the hidden text box when the user presses escape or opens another file
        /// </summary>
        private void CloseArtistDialog() => CloseDialog(ref ArtistNames, ref ChangeArtistsBox);
        /// <summary>
        /// Closes the hidden text box when the user presses escape or opens another file
        /// </summary>
        private void CloseAlbumDialog() => CloseDialog(ref Album, ref ChangeAlbumBox);
        private void CloseAllDialogs()
        {
            CloseSongDialog();
            CloseArtistDialog();
            CloseAlbumDialog();
        }
        /// <summary>
        /// Brings up the hidden field to change the labels text property
        /// </summary>
        /// <param name="field">The field to modify</param>
        /// <param name="box">The hidden text box to modify the label</param>
        private void ChangeField(ref Label field, ref RichTextBox box)
        {
            if (CurrentSong is null) return;
            else if (FileHasBeenModified) return;
            field.Hide();
            box.Text = field.Text;
            box.Show();
            box.Visible = true;
            box.Enabled = true;
        }
        /// <summary>
        /// Closes the hidden field after the user presses escape or a new file opens
        /// </summary>
        /// <param name="field">The field to reshow</param>
        /// <param name="box">The hidden text box to rehide</param>
        private static void CloseDialog(ref Label field, ref RichTextBox box)
        {
            box.Text = string.Empty;
            box.Hide();
            box.Visible = false;
            box.Enabled = false;
            field.Show();
        }
        /// <summary>
        /// Sets up all the handlers for the <see cref="CurrentSong"/> property
        /// </summary>
        private void SetHandlers()
        {
            CurrentSong.TitleChanged += CurrentSong_OnTitleChange;
            CurrentSong.SongArtistsChanged += CurrentSong_OnSongArtistChange;
            CurrentSong.SongCoverChanged += CurrentSong_OnSongCoverChange;
            CurrentSong.AlbumTitleChanged += CurrentSong_AlbumTitleChanged;
        }
        /// <summary>
        /// Attempts to save the changes to the songs metadata
        /// </summary>
        /// <remarks>
        /// Displays a message box with the error
        /// </remarks>
        /// <returns>A <see cref="bool"/> true if it saved, false if it did not</returns>
        private bool TrySave()
        {
            try { CurrentSong.Save(); }
            catch (FileNotFoundException ex)
            {
                MessageBox.Show(ex.Message + "\nThe file may have been renamed or deleted, find and open to change metadata", "Unable To Find File");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "AN ERROR HAS OCCURED");
                return false;
            }
            return true;
        }
        #endregion
        #region Event Consumers
        #region WinForm Events
        /// <summary>
        /// When the user presses File->Open and select a file, they provide an mp3 and the application shows the metadata
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OpenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var dialog = new OpenFileDialog
            {
                Filter = "MP3 Files | *.mp3;",
                Title = "Select an MP3 File",
                Multiselect = false
            };
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                FilePath = dialog.FileName;
                FileHasBeenModified = false;
                CurrentSong = new Song(TagLib.File.Create(dialog.FileName), true)
                {
                    FileName = dialog.SafeFileName
                };
                BitRate.Text = $"{CurrentSong.BitRate}kbps";
            }
        }
        /// <summary>
        /// Shows the hidden text box to edit the name of the song
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SongName_Click(object sender, EventArgs e) => ChangeSongName();
        /// <summary>
        /// Changes the album title if the key is Enter, if escape it cancels the operation
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ChangeAlbumBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (ChangeAlbumBox.Text == string.Empty) return;
                e.SuppressKeyPress = true;
                CurrentSong.AlbumTitle = ChangeAlbumBox.Text;
                TrySave();
                ChangeAlbumBox.Hide();
                ChangeAlbumBox.Visible = false;
                ChangeAlbumBox.Enabled = false;
                Album.Show();
            }
            else if (e.KeyCode == Keys.Escape)
            {
                CloseAlbumDialog();
            }
        }
        /// <summary>
        /// Changes the song title if the key is Enter, if escape it cancels the operation
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ChangeSongNameBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;
                if (CurrentSong.Title != ChangeSongNameBox.Text)
                {
                    CurrentSong.Title = ChangeSongNameBox.Text;
                    TrySave();
                }
                ChangeSongNameBox.Hide();
                ChangeSongNameBox.Visible = false;
                ChangeSongNameBox.Enabled = false;
                SongName.Show();
            }
            else if (e.KeyCode == Keys.Escape)
            {
                CloseSongDialog();
            }
        }
        /// <summary>
        /// When the user clicks on the song cover they can select a new song cover from their file system and update the metadata
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SongCover_Click(object sender, EventArgs e)
        {
            if (CurrentSong is null) return;
            var dialog = new OpenFileDialog()
            {
                Filter = "Image Files (*.jpg, *.jpeg, *.jpe, *.png) | *.jpg; *.jpeg; *.jpe; *.png",
                Title = "Select an album cover",
                Multiselect = false
            };
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                var picture = new Picture(dialog.FileName);
                var pictures = new IPicture[] { picture };
                CurrentSong.Covers = pictures;
                TrySave();
            }
        }
        /// <summary>
        /// Brings up the hidden text box to edit the artist names
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ArtistNames_Click(object sender, EventArgs e) => ChangeArtistNames();
        /// <summary>
        /// Changes the artists if the key is Enter, if escape it cancels the operation
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ChangeArtistsBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (ChangeArtistsBox.Text == string.Empty) return;
                e.SuppressKeyPress = true;
                CurrentSong.Artists = ChangeArtistsBox.Text.Split(",");
                TrySave();
                ChangeArtistsBox.Hide();
                ChangeArtistsBox.Visible = false;
                ChangeArtistsBox.Enabled = false;
                ArtistNames.Show();
            }
            else if (e.KeyCode == Keys.Escape)
            {
                CloseArtistDialog();
            }
        }
        /// <summary>
        /// Closes the application from File->Exit
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ExitToolStripMenuItem_Click(object sender, EventArgs e) => Close();
        /// <summary>
        /// Brings up the text box to modify the album title
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Album_Click(object sender, EventArgs e) => ChangeField(ref Album, ref ChangeAlbumBox);
        #endregion
        #region Custom Events
        /// <summary>
        /// Handles when the user selects a new song from their file system
        /// </summary>
        /// <param name="sender">The sender of the event</param>
        /// <param name="e">Event arguments</param>
        private async void MP3ModUI_OnNewSong(object sender, EventArgs e)
        {
            // TODO: Split code into more functions for readability
            SongName.Text = CurrentSong.Title;
            ArtistNames.Text = string.Join(", ", CurrentSong.Artists);
            Album.Text = CurrentSong.AlbumTitle;
            Duration.Text = CurrentSong.Duration.ToString("hh\\:mm\\:ss");
            Filename.Text = CurrentSong.FileName;
            SongCover.Image = CurrentSong.Covers.Length >= 1 ?
                await MP3ModiferHelper.GetImageAsync(CurrentSong.Covers[0].Data.Data)
                : Images.no_image_found;
            SetHandlers();
            CloseAllDialogs();
            Text = $"MP3 Modifier -> {string.Join(",", CurrentSong.Artists) ?? "unknown_artist"} " +
                $"- {CurrentSong.Title ?? "unknown_title"}";
            DoFuncIfEmpty(SongName.Text, ChangeSongName);
            DoFuncIfEmpty(ArtistNames.Text, ChangeArtistNames);
            DoFuncIfEmpty(Album.Text, ChangeAlbumName);
            FileHasBeenModified = false;
            ReadOnlyLabel.Visible = false;
        }
        /// <summary>
        /// If the <see cref="string"/> param 'field' is empty call the <see cref="Action"/> 'action' function
        /// </summary>
        /// <param name="field">Check to see if this field is <see cref="string.Empty"/></param>
        /// <param name="action">The function call if 'field' is empty"/></param>
        private static void DoFuncIfEmpty(string field, Action action)
        {
            if (field == string.Empty)
            {
                action();
            }
        }
        /// <summary>
        /// Updates the album text on the screen when the album title is changed
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"><see cref="Nullable{T}"/> T is <see cref="bool"/>
        /// If null it means that autosave is not on,
        /// If true it means that it saved properly,
        /// If false it failed to saved
        /// </param>
        private void CurrentSong_AlbumTitleChanged(object sender, bool? e)
        {
            if (!e.HasValue) return;
            else if (!e.Value) return;
            Album.Text = CurrentSong.AlbumTitle;
        }
        /// <summary>
        /// Updates the thumbnail on the screen when the album cover is changed
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void CurrentSong_OnSongCoverChange(object sender, bool? e)
        {
            SongCover.Image = await MP3ModiferHelper.GetImageAsync(CurrentSong.Covers[0].Data.Data);
        }
        /// <summary>
        /// Updates the song artist label and the text of the top bar of the form when the song artist is changed
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CurrentSong_OnSongArtistChange(object sender, bool? e)
        {
            if (!e.HasValue) return;
            else if (!e.Value) return;
            ArtistNames.Text = string.Join(",", CurrentSong.Artists);
            Text = $"MP3 Modifier -> {(string.IsNullOrWhiteSpace(ArtistNames.Text) ? "unknown" : ArtistNames.Text)} - " +
                $"{(string.IsNullOrWhiteSpace(SongName.Text) ? "unknown" : SongName.Text)}";
        }
        /// <summary>
        /// Updates the title label and the text of the top of the bar when the song title is changed
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CurrentSong_OnTitleChange(object sender, bool? e)
        {
            if (!e.HasValue) return;
            else if (!e.Value) return;
            SongName.Text = CurrentSong.Title;
            Text = $"MP3 Modifier -> {(string.IsNullOrWhiteSpace(ArtistNames.Text) ? "unknown" : ArtistNames.Text)} - " +
                $"{(string.IsNullOrWhiteSpace(SongName.Text) ? "unknown" : SongName.Text)}";
        }
        #endregion
        #endregion
        /// <summary>
        /// Gets data about the current version of the app and displays it to the user using <see cref="MessageBox.Show(string, string)"/>
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void AboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string version = ConfigurationManager.AppSettings.Get("version");
            string message = $"MP3 Modifier v{version}\n" +
                $"Developer: paradox#4005" +
                $"\nCLR: {RuntimeEnvironment.GetSystemVersion()}" +
                $"\n{RuntimeInformation.OSDescription}";
            MessageBox.Show(message, "About MP3 Modifier");
        }
        /// <summary>
        /// Saves the current song's artwork to the user selected location
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void SaveThumbnailtoolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (CurrentSong is null) { return; }
            else if (!(CurrentSong.Covers.Length >= 1)) { return; }
            var saveDialog = new SaveFileDialog()
            {
                Filter = "JPEG File | *.jpg;",
                Title = "Save Image Thumbnail",
                FileName = $"{(CurrentSong.Artists[0] ?? "unknown_artist").ToLower().Replace(" ", "_")}" +
                $"-{(CurrentSong.Title ?? "unknown_song").ToLower().Replace(" ", "_")}-artwork.jpg"
            };
            var result = saveDialog.ShowDialog();
            if (result == DialogResult.OK)
            {
                var fs = (FileStream)saveDialog.OpenFile();
                var pic = await MP3ModiferHelper.GetImageAsync(CurrentSong.Covers[0].Data.Data);
                pic.Save(fs, ImageFormat.Jpeg);
            }
            // TODO: Code unselected logic here later
        }

        private async void FileModifierCheckTimer_Tick(object sender, EventArgs e)
        {
            if (!FileHasBeenModified)
            {
                ReadOnlyLabel.Visible = await Task.Run(() => HasFileBeenModified());
            }
        }
        /// <summary>
        /// Checks to see if the file has been modified so that we can no longer retrieve it
        /// </summary>
        /// <returns></returns>
        private bool HasFileBeenModified()
        {
            if (FilePath is null) return false;
            else if (FileHasBeenModified) return false;
            if (!System.IO.File.Exists(FilePath))
            {
                FileHasBeenModified = true;
                MessageBox.Show("We have detected a change in file location or name" +
                    "\nYou will have to reload the audio file to modify it",
                    "File Moved/Renamed/Deleted");
                CyclerIfModified.Enabled = true;
                CyclerIfModified.Start();
                return true;
            }
            else return false;
        }
        /// <summary>
        /// Toggle between warning and full message boolean
        /// </summary>
        private bool OnMessage = false;
        private void CyclerIfModified_Tick(object sender, EventArgs e)
        {
            if (OnMessage)
            {
                OnMessage = false;
                WarningLabel.Visible = false;
                ReadOnlyLabel.Visible = true;
            }
            else
            {
                OnMessage = true;
                WarningLabel.Visible = true;
                ReadOnlyLabel.Visible = false;
            }
        }
    }
}
