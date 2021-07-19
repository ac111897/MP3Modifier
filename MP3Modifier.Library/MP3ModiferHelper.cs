using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using TagLib;
using System.IO;
namespace MP3Modifier.Library
{
    /// <summary>
    /// Provides methods useful to the MP3 UI
    /// </summary>
    public static class MP3ModiferHelper
    {
        public static string RemoveFileFromPath(this string path) => Path.GetDirectoryName(path);
        
        /// <summary>
        /// Asyncronously gets an image from a <see cref="byte"/> array provided by using memory stream
        /// </summary>
        /// <param name="bin">A byte array of the image</param>
        /// <returns>A thumbnail of an <see cref="Image"/> enclosed in <see cref="Task{TResult}"/></returns>
        public static async Task<Image> GetImageAsync(byte[] bin)
        {
            Stopwatch timer = new();
            timer.Start();
            var img = await Task.Run(() => GetImage(bin));
            timer.Stop();
            Debug.WriteLine("Took " + timer.Elapsed.ToString("fff") + "ms to load img");
            return img;
        }
        /// <summary>
        /// Heloer method to get image for <see cref="GetImageAsync(byte[])"/>
        /// </summary>
        /// <param name="bin"></param>
        /// <returns>An <see cref="Image"/></returns>
        private static Image GetImage(byte[] bin)
        {
            return Image.FromStream(new MemoryStream(bin)).GetThumbnailImage(600, 600, null, IntPtr.Zero);
        }
    }
}
