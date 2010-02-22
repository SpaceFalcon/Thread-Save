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
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ThreadSave
{
    class Image
    {
        string RemoteURL;
        string LocalPath;
        string FileName;
        bool isDownloaded = false;
        long Size;

        public Image(string ImageURL)
        {
            RemoteURL = ImageURL;
            FileName = System.IO.Path.GetFileName(ImageURL);
        }

        public NetStream GetStream()
        {
            return null;
        }
    }
}
