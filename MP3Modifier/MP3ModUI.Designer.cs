
namespace MP3Modifier
{
    /// <summary>
    /// The user interface of the application
    /// </summary>
    partial class MP3ModUI
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.FileStrip = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.SaveThumbnailtoolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ExitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.editToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.SongName = new System.Windows.Forms.Label();
            this.SongNameTitle = new System.Windows.Forms.Label();
            this.ArtistNameTitle = new System.Windows.Forms.Label();
            this.ArtistNames = new System.Windows.Forms.Label();
            this.ChangeSongNameBox = new System.Windows.Forms.RichTextBox();
            this.SongCover = new System.Windows.Forms.PictureBox();
            this.ChangeArtistsBox = new System.Windows.Forms.RichTextBox();
            this.AlbumTitle = new System.Windows.Forms.Label();
            this.Album = new System.Windows.Forms.Label();
            this.ChangeAlbumBox = new System.Windows.Forms.RichTextBox();
            this.FileNameTitle = new System.Windows.Forms.Label();
            this.Filename = new System.Windows.Forms.Label();
            this.DurationTitle = new System.Windows.Forms.Label();
            this.Duration = new System.Windows.Forms.Label();
            this.FileModifierCheckTimer = new System.Windows.Forms.Timer(this.components);
            this.BitRateTitle = new System.Windows.Forms.Label();
            this.BitRate = new System.Windows.Forms.Label();
            this.ReadOnlyLabel = new System.Windows.Forms.Label();
            this.CyclerIfModified = new System.Windows.Forms.Timer(this.components);
            this.WarningLabel = new System.Windows.Forms.Label();
            this.FileStrip.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.SongCover)).BeginInit();
            this.SuspendLayout();
            // 
            // FileStrip
            // 
            this.FileStrip.BackColor = System.Drawing.Color.Gainsboro;
            this.FileStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.editToolStripMenuItem,
            this.helpToolStripMenuItem});
            this.FileStrip.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.HorizontalStackWithOverflow;
            this.FileStrip.Location = new System.Drawing.Point(0, 0);
            this.FileStrip.Name = "FileStrip";
            this.FileStrip.Padding = new System.Windows.Forms.Padding(0);
            this.FileStrip.Size = new System.Drawing.Size(784, 24);
            this.FileStrip.TabIndex = 0;
            this.FileStrip.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.BackColor = System.Drawing.SystemColors.Control;
            this.fileToolStripMenuItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openToolStripMenuItem,
            this.SaveThumbnailtoolStripMenuItem,
            this.ExitToolStripMenuItem});
            this.fileToolStripMenuItem.ForeColor = System.Drawing.SystemColors.InfoText;
            this.fileToolStripMenuItem.Margin = new System.Windows.Forms.Padding(0, 0, 1, 0);
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 24);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // openToolStripMenuItem
            // 
            this.openToolStripMenuItem.Name = "openToolStripMenuItem";
            this.openToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.openToolStripMenuItem.Text = "Open";
            this.openToolStripMenuItem.Click += new System.EventHandler(this.OpenToolStripMenuItem_Click);
            // 
            // SaveThumbnailtoolStripMenuItem
            // 
            this.SaveThumbnailtoolStripMenuItem.Name = "SaveThumbnailtoolStripMenuItem";
            this.SaveThumbnailtoolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.SaveThumbnailtoolStripMenuItem.Text = "Save Thumbnail..";
            this.SaveThumbnailtoolStripMenuItem.Click += new System.EventHandler(this.SaveThumbnailtoolStripMenuItem_Click);
            // 
            // ExitToolStripMenuItem
            // 
            this.ExitToolStripMenuItem.Name = "ExitToolStripMenuItem";
            this.ExitToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.F4)));
            this.ExitToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.ExitToolStripMenuItem.Text = "Exit";
            this.ExitToolStripMenuItem.Click += new System.EventHandler(this.ExitToolStripMenuItem_Click);
            // 
            // editToolStripMenuItem
            // 
            this.editToolStripMenuItem.BackColor = System.Drawing.SystemColors.Control;
            this.editToolStripMenuItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.editToolStripMenuItem.Margin = new System.Windows.Forms.Padding(1, 0, 1, 0);
            this.editToolStripMenuItem.Name = "editToolStripMenuItem";
            this.editToolStripMenuItem.Size = new System.Drawing.Size(39, 24);
            this.editToolStripMenuItem.Text = "Edit";
            // 
            // helpToolStripMenuItem
            // 
            this.helpToolStripMenuItem.BackColor = System.Drawing.SystemColors.Control;
            this.helpToolStripMenuItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.helpToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.aboutToolStripMenuItem});
            this.helpToolStripMenuItem.Margin = new System.Windows.Forms.Padding(1, 0, 1, 0);
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            this.helpToolStripMenuItem.Size = new System.Drawing.Size(44, 24);
            this.helpToolStripMenuItem.Text = "Help";
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.aboutToolStripMenuItem.Text = "About";
            this.aboutToolStripMenuItem.Click += new System.EventHandler(this.AboutToolStripMenuItem_Click);
            // 
            // SongName
            // 
            this.SongName.AutoSize = true;
            this.SongName.Font = new System.Drawing.Font("Cambria", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.SongName.Location = new System.Drawing.Point(92, 30);
            this.SongName.Name = "SongName";
            this.SongName.Size = new System.Drawing.Size(31, 37);
            this.SongName.TabIndex = 1;
            this.SongName.Text = "..";
            this.SongName.Click += new System.EventHandler(this.SongName_Click);
            // 
            // SongNameTitle
            // 
            this.SongNameTitle.AutoSize = true;
            this.SongNameTitle.Font = new System.Drawing.Font("Cambria", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.SongNameTitle.Location = new System.Drawing.Point(9, 30);
            this.SongNameTitle.Name = "SongNameTitle";
            this.SongNameTitle.Size = new System.Drawing.Size(95, 37);
            this.SongNameTitle.TabIndex = 2;
            this.SongNameTitle.Text = "Title:";
            // 
            // ArtistNameTitle
            // 
            this.ArtistNameTitle.AutoSize = true;
            this.ArtistNameTitle.Font = new System.Drawing.Font("Cambria", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.ArtistNameTitle.Location = new System.Drawing.Point(9, 70);
            this.ArtistNameTitle.Name = "ArtistNameTitle";
            this.ArtistNameTitle.Size = new System.Drawing.Size(152, 37);
            this.ArtistNameTitle.TabIndex = 3;
            this.ArtistNameTitle.Text = "Artist(s):";
            // 
            // ArtistNames
            // 
            this.ArtistNames.AutoSize = true;
            this.ArtistNames.Font = new System.Drawing.Font("Cambria", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.ArtistNames.Location = new System.Drawing.Point(150, 70);
            this.ArtistNames.Name = "ArtistNames";
            this.ArtistNames.Size = new System.Drawing.Size(31, 37);
            this.ArtistNames.TabIndex = 4;
            this.ArtistNames.Text = "..";
            this.ArtistNames.Click += new System.EventHandler(this.ArtistNames_Click);
            // 
            // ChangeSongNameBox
            // 
            this.ChangeSongNameBox.Enabled = false;
            this.ChangeSongNameBox.Font = new System.Drawing.Font("Cambria", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.ChangeSongNameBox.Location = new System.Drawing.Point(98, 34);
            this.ChangeSongNameBox.Margin = new System.Windows.Forms.Padding(3, 0, 3, 0);
            this.ChangeSongNameBox.Multiline = false;
            this.ChangeSongNameBox.Name = "ChangeSongNameBox";
            this.ChangeSongNameBox.Size = new System.Drawing.Size(410, 31);
            this.ChangeSongNameBox.TabIndex = 5;
            this.ChangeSongNameBox.Text = "";
            this.ChangeSongNameBox.Visible = false;
            this.ChangeSongNameBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.ChangeSongNameBox_KeyDown);
            // 
            // SongCover
            // 
            this.SongCover.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.SongCover.BackgroundImage = global::MP3Modifier.Images.no_image_found;
            this.SongCover.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.SongCover.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.SongCover.ErrorImage = global::MP3Modifier.Images.no_image_found;
            this.SongCover.Location = new System.Drawing.Point(600, 27);
            this.SongCover.Name = "SongCover";
            this.SongCover.Size = new System.Drawing.Size(180, 180);
            this.SongCover.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.SongCover.TabIndex = 6;
            this.SongCover.TabStop = false;
            this.SongCover.Click += new System.EventHandler(this.SongCover_Click);
            // 
            // ChangeArtistsBox
            // 
            this.ChangeArtistsBox.Enabled = false;
            this.ChangeArtistsBox.Font = new System.Drawing.Font("Cambria", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.ChangeArtistsBox.Location = new System.Drawing.Point(153, 75);
            this.ChangeArtistsBox.Margin = new System.Windows.Forms.Padding(3, 0, 3, 0);
            this.ChangeArtistsBox.Multiline = false;
            this.ChangeArtistsBox.Name = "ChangeArtistsBox";
            this.ChangeArtistsBox.Size = new System.Drawing.Size(355, 31);
            this.ChangeArtistsBox.TabIndex = 7;
            this.ChangeArtistsBox.Text = "";
            this.ChangeArtistsBox.Visible = false;
            this.ChangeArtistsBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.ChangeArtistsBox_KeyDown);
            // 
            // AlbumTitle
            // 
            this.AlbumTitle.AutoSize = true;
            this.AlbumTitle.Font = new System.Drawing.Font("Cambria", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.AlbumTitle.Location = new System.Drawing.Point(9, 116);
            this.AlbumTitle.Name = "AlbumTitle";
            this.AlbumTitle.Size = new System.Drawing.Size(123, 37);
            this.AlbumTitle.TabIndex = 8;
            this.AlbumTitle.Text = "Album:";
            // 
            // Album
            // 
            this.Album.AutoSize = true;
            this.Album.Font = new System.Drawing.Font("Cambria", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.Album.Location = new System.Drawing.Point(121, 116);
            this.Album.Name = "Album";
            this.Album.Size = new System.Drawing.Size(31, 37);
            this.Album.TabIndex = 9;
            this.Album.Text = "..";
            this.Album.Click += new System.EventHandler(this.Album_Click);
            // 
            // ChangeAlbumBox
            // 
            this.ChangeAlbumBox.Enabled = false;
            this.ChangeAlbumBox.Font = new System.Drawing.Font("Cambria", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.ChangeAlbumBox.Location = new System.Drawing.Point(124, 119);
            this.ChangeAlbumBox.Margin = new System.Windows.Forms.Padding(3, 0, 3, 0);
            this.ChangeAlbumBox.Multiline = false;
            this.ChangeAlbumBox.Name = "ChangeAlbumBox";
            this.ChangeAlbumBox.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.None;
            this.ChangeAlbumBox.Size = new System.Drawing.Size(384, 31);
            this.ChangeAlbumBox.TabIndex = 10;
            this.ChangeAlbumBox.Text = "";
            this.ChangeAlbumBox.Visible = false;
            this.ChangeAlbumBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.ChangeAlbumBox_KeyDown);
            // 
            // FileNameTitle
            // 
            this.FileNameTitle.AutoSize = true;
            this.FileNameTitle.Font = new System.Drawing.Font("Cambria", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.FileNameTitle.Location = new System.Drawing.Point(12, 161);
            this.FileNameTitle.Name = "FileNameTitle";
            this.FileNameTitle.Size = new System.Drawing.Size(81, 37);
            this.FileNameTitle.TabIndex = 11;
            this.FileNameTitle.Text = "File:";
            // 
            // Filename
            // 
            this.Filename.AutoSize = true;
            this.Filename.Font = new System.Drawing.Font("Cambria", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.Filename.Location = new System.Drawing.Point(83, 161);
            this.Filename.Name = "Filename";
            this.Filename.Size = new System.Drawing.Size(31, 37);
            this.Filename.TabIndex = 12;
            this.Filename.Text = "..";
            // 
            // DurationTitle
            // 
            this.DurationTitle.AutoSize = true;
            this.DurationTitle.Font = new System.Drawing.Font("Cambria", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.DurationTitle.Location = new System.Drawing.Point(12, 199);
            this.DurationTitle.Name = "DurationTitle";
            this.DurationTitle.Size = new System.Drawing.Size(158, 37);
            this.DurationTitle.TabIndex = 14;
            this.DurationTitle.Text = "Duration:";
            // 
            // Duration
            // 
            this.Duration.AutoSize = true;
            this.Duration.Font = new System.Drawing.Font("Cambria", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.Duration.Location = new System.Drawing.Point(159, 199);
            this.Duration.Name = "Duration";
            this.Duration.Size = new System.Drawing.Size(31, 37);
            this.Duration.TabIndex = 15;
            this.Duration.Text = "..";
            // 
            // FileModifierCheckTimer
            // 
            this.FileModifierCheckTimer.Enabled = true;
            this.FileModifierCheckTimer.Interval = 1000;
            this.FileModifierCheckTimer.Tick += new System.EventHandler(this.FileModifierCheckTimer_Tick);
            // 
            // BitRateTitle
            // 
            this.BitRateTitle.AutoSize = true;
            this.BitRateTitle.Font = new System.Drawing.Font("Cambria", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.BitRateTitle.Location = new System.Drawing.Point(12, 236);
            this.BitRateTitle.Name = "BitRateTitle";
            this.BitRateTitle.Size = new System.Drawing.Size(143, 37);
            this.BitRateTitle.TabIndex = 16;
            this.BitRateTitle.Text = "Bit Rate:";
            // 
            // BitRate
            // 
            this.BitRate.AutoSize = true;
            this.BitRate.Font = new System.Drawing.Font("Cambria", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.BitRate.Location = new System.Drawing.Point(150, 236);
            this.BitRate.Name = "BitRate";
            this.BitRate.Size = new System.Drawing.Size(31, 37);
            this.BitRate.TabIndex = 17;
            this.BitRate.Text = "..";
            // 
            // ReadOnlyLabel
            // 
            this.ReadOnlyLabel.AutoSize = true;
            this.ReadOnlyLabel.Font = new System.Drawing.Font("Cambria", 36F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.ReadOnlyLabel.Location = new System.Drawing.Point(494, 305);
            this.ReadOnlyLabel.Name = "ReadOnlyLabel";
            this.ReadOnlyLabel.Size = new System.Drawing.Size(273, 57);
            this.ReadOnlyLabel.TabIndex = 18;
            this.ReadOnlyLabel.Text = "READ-ONLY";
            this.ReadOnlyLabel.Visible = false;
            // 
            // CyclerIfModified
            // 
            this.CyclerIfModified.Interval = 10000;
            this.CyclerIfModified.Tick += new System.EventHandler(this.CyclerIfModified_Tick);
            // 
            // WarningLabel
            // 
            this.WarningLabel.AutoSize = true;
            this.WarningLabel.Font = new System.Drawing.Font("Cambria", 36F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.WarningLabel.Location = new System.Drawing.Point(12, 305);
            this.WarningLabel.Name = "WarningLabel";
            this.WarningLabel.Size = new System.Drawing.Size(751, 57);
            this.WarningLabel.TabIndex = 19;
            this.WarningLabel.Text = "YOU CANNOT EDIT UNTIL RELOAD";
            this.WarningLabel.Visible = false;
            // 
            // MP3ModUI
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 361);
            this.Controls.Add(this.WarningLabel);
            this.Controls.Add(this.ReadOnlyLabel);
            this.Controls.Add(this.BitRate);
            this.Controls.Add(this.BitRateTitle);
            this.Controls.Add(this.Duration);
            this.Controls.Add(this.DurationTitle);
            this.Controls.Add(this.Filename);
            this.Controls.Add(this.FileNameTitle);
            this.Controls.Add(this.ChangeAlbumBox);
            this.Controls.Add(this.SongCover);
            this.Controls.Add(this.ChangeSongNameBox);
            this.Controls.Add(this.SongName);
            this.Controls.Add(this.FileStrip);
            this.Controls.Add(this.Album);
            this.Controls.Add(this.AlbumTitle);
            this.Controls.Add(this.ChangeArtistsBox);
            this.Controls.Add(this.ArtistNames);
            this.Controls.Add(this.ArtistNameTitle);
            this.Controls.Add(this.SongNameTitle);
            this.MainMenuStrip = this.FileStrip;
            this.MaximizeBox = false;
            this.MinimumSize = new System.Drawing.Size(800, 400);
            this.Name = "MP3ModUI";
            this.Text = "MP3 Modifier";
            this.FileStrip.ResumeLayout(false);
            this.FileStrip.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.SongCover)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip FileStrip;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openToolStripMenuItem;
        private System.Windows.Forms.Label SongName;
        private System.Windows.Forms.Label SongNameTitle;
        private System.Windows.Forms.Label ArtistNameTitle;
        private System.Windows.Forms.Label ArtistNames;
        private System.Windows.Forms.RichTextBox ChangeSongNameBox;
        private System.Windows.Forms.PictureBox SongCover;
        private System.Windows.Forms.RichTextBox ChangeArtistsBox;
        private System.Windows.Forms.ToolStripMenuItem ExitToolStripMenuItem;
        private System.Windows.Forms.Label AlbumTitle;
        private System.Windows.Forms.Label Album;
        private System.Windows.Forms.RichTextBox ChangeAlbumBox;
        private System.Windows.Forms.Label FileNameTitle;
        private System.Windows.Forms.Label Filename;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem editToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem SaveThumbnailtoolStripMenuItem;
        private System.Windows.Forms.Label DurationTitle;
        private System.Windows.Forms.Label Duration;
        private System.Windows.Forms.Timer FileModifierCheckTimer;
        private System.Windows.Forms.Label BitRateTitle;
        private System.Windows.Forms.Label BitRate;
        private System.Windows.Forms.Label ReadOnlyLabel;
        private System.Windows.Forms.Timer CyclerIfModified;
        private System.Windows.Forms.Label WarningLabel;
    }
}

