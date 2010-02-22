/* File Created: 10/4/2009
 * Last Modified: 10/6/2009
 * 
 * This file is part of ThreadSave.
 * 
 * ThreadSave is free software: you can redistribute it and/or modify
 * it under the terms of the GNU General Public License as published by
 * the Free Software Foundation, either version 3 of the License, or
 * (at your option) any later version.
 * 
 * ThreadSave is distributed in the hope that it will be useful,
 * but WITHOUT ANY WARRANTY; without even the implied warranty of
 * MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
 * GNU General Public License for more details.
 * 
 * You should have received a copy of the GNU General Public License
 * along with ThreadSave.  If not, see <http://www.gnu.org/licenses/>.
*/

using System;

namespace ThreadSave
{
    static class MimeType
    {
        public static string ToExtension(string mimeType)
        {
            switch (mimeType)
            {
                case "image/jpeg":
                    return ".jpg";
                case "image/gif":
                    return ".gif";
                case "image/png":
                    return ".png";
                case "image/tiff":
                    return ".tiff";
                case "image/x-tiff":
                    return ".tiff";
                case "image/bmp":
                    return ".bmp";
                case "image/x-windows-bmp":
                    return ".bmp";

            }
            return ".unknown";
        }

        public static System.Drawing.Imaging.ImageFormat ToImageFormat(string mimeType)
        {
            switch (mimeType)
            {
                case "image/jpeg":
                    return System.Drawing.Imaging.ImageFormat.Jpeg;
                case "image/gif":
                    return System.Drawing.Imaging.ImageFormat.Gif;
                case "image/png":
                    return System.Drawing.Imaging.ImageFormat.Png;
                case "image/tiff":
                    return System.Drawing.Imaging.ImageFormat.Tiff;
                case "image/bmp":
                    return System.Drawing.Imaging.ImageFormat.Bmp;
            }
            return null;
        }
    }
}
