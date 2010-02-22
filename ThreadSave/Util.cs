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
    static class Util
    {
        /// <summary>
        /// Convert a long into a string representing a filesize in shorthand.
        /// </summary>
        /// <param name="size">Size to convert</param>
        /// <param name="precision">Decimal precision</param>
        /// <returns>String representing the size of bytes in shorthand.</returns>
        public static string FileSizeToString(long size, int precision)
        {
            long KB = 1 << 10;
            long MB = 1 << 20;
            long GB = 1 << 30;
            long TB = 1 << 40;
            long PB = 1 << 50;

            if (size > KB && size < MB)
                return Math.Round((float)size / (float)KB, precision) + " KB";
            else if (size > MB && size < GB)
                return Math.Round((float)size / (float)MB, precision) + " MB";
            else if (size > GB && size < TB)
                return Math.Round((float)size / (float)GB, precision) + " GB";
            else if (size > TB && size < PB)
                return Math.Round((float)size / (float)TB, precision) + " TB";
            else
                return (float)size + " B";
        }
    }
}
