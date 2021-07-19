using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TagLib;
using System.Drawing;
using System.IO;
namespace MP3Modifier.Library
{
    /// <summary>
    /// Provides a simplified way of acccessing mp3 metadata and event handlers for metadata changing
    /// </summary>
    public sealed class Song
    {
        /// <summary>
        /// The shorthand file name of the song excluding the path
        /// </summary>
        public string FileName { get; set; }
        /// <summary>
        /// If set to true the app will autosave changes to properties
        /// If false it will not
        /// </summary>
        /// <remarks>
        /// Default value is false
        /// </remarks>
        public bool AutoSave { get; set; } = false;
        /// <summary>
        /// Initializes a new instance of the <see cref="Song"/> class
        /// </summary>
        /// <param name="file">The MP3 file</param>
        public Song(TagLib.File file)
        {
            _ = file ?? throw new ArgumentNullException(nameof(file));
            CurrentlyOpen = file;
        }
        /// <summary>
        /// Initializes a new instance of the <see cref="Song"/> class
        /// </summary>
        /// <param name="file">The MP3 file</param>
        /// <param name="autoSave">If true after every assignment the file will auto-save the changes</param>
        public Song(TagLib.File file, bool autoSave)
        {
            _ = file ?? throw new ArgumentNullException(nameof(file));
            CurrentlyOpen = file;
            AutoSave = autoSave;
        }
        #region Methods
        /// <summary>
        /// Tries to save a song if it fails passes up the exception to higher method
        /// </summary>
        public void Save()
        {
            try
            {
                CurrentlyOpen.Save();
            }
            catch (FileNotFoundException ex)
            {
                throw new FileNotFoundException(ex.Message);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        private bool TrySave()
        {
            try { Save(); }
            catch
            {
                return false;
            }
            return true;
        }
        #endregion
        #region Events
        /// <summary>
        /// Occurs when the title of the audio file is set a new value
        /// </summary>
        public event EventHandler<bool?> TitleChanged;
        /// <summary>
        /// Occurs when the artists of the audio file is set a new value
        /// </summary>
        public event EventHandler<bool?> SongArtistsChanged;
        /// <summary>
        /// Occurs when the song cover of the audio file is set a new value
        /// </summary>
        public event EventHandler<bool?> SongCoverChanged;
        /// <summary>
        /// Occurs when the album title of the audio file is set a new value
        /// </summary>
        public event EventHandler<bool?> AlbumTitleChanged;
        #endregion
        #region Properties
        /// <summary>
        /// Represents the currently open song
        /// </summary>
        private TagLib.File CurrentlyOpen { get; set; } = null;
        /// <summary>
        /// The title of the audio file
        /// </summary>
        public string Title
        {
            get => CurrentlyOpen.Tag.Title;
            set
            {
                CurrentlyOpen.Tag.Title = value.Trim();
                if (AutoSave)
                {
                    TitleChanged?.Invoke(this, TrySave());
                }
                else
                {
                    TitleChanged?.Invoke(this, null);
                }
            }
        }
        /// <summary>
        /// The artists of the audio file
        /// </summary>
        public string[] Artists
        {
            get => CurrentlyOpen.Tag.Performers;
            set
            {
                CurrentlyOpen.Tag.Performers = value;

                if (AutoSave)
                {
                    SongArtistsChanged?.Invoke(this, TrySave());
                }
                else
                {
                    SongArtistsChanged?.Invoke(this, null);
                }

            }
        }
        /// <summary>
        /// The pictures of the audio file
        /// </summary>
        public IPicture[] Covers
        {
            get
            {
                return CurrentlyOpen.Tag.Pictures;
            }
            set
            {
                CurrentlyOpen.Tag.Pictures = value;
                if (AutoSave)
                {
                    SongCoverChanged?.Invoke(this, TrySave());
                }
                else
                {
                    SongCoverChanged?.Invoke(this, null);
                }
            }
        }
        /// <summary>
        /// The title of the audio file
        /// </summary>
        public string AlbumTitle
        {
            get
            {
                return CurrentlyOpen.Tag.Album;
            }
            set
            {
                CurrentlyOpen.Tag.Album = value.Trim();
                if (AutoSave)
                {
                    AlbumTitleChanged?.Invoke(this, TrySave());
                }
                else
                {
                    AlbumTitleChanged?.Invoke(this, null);
                }
            }
        }
        /// <summary>
        /// Gets the duration of the file
        /// </summary>
        public TimeSpan Duration
        {
            get => CurrentlyOpen.Properties.Duration;
        }
        public string BitRate
        {
            get => CurrentlyOpen.Properties.AudioBitrate.ToString();
        }
        #endregion
    }
}