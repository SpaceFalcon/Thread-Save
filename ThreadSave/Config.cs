/* File Created: 3/23/2010
 * Last Modified: 3/23/2010
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
using System.IO;

namespace ThreadSave
{
    static class Config
    {
        private static List<string> lines = new List<string>();
        public static List<Board> boards = new List<Board>();
        public static string APP_VER = "0.2.0";
        public static void LoadFile(string path)
        {
            StreamReader reader = new StreamReader(path);
            while (!reader.EndOfStream) lines.Add(reader.ReadLine());
            foreach (string line in lines)
            {
                int i = 0;
                while (line[i] == ' ' || line[i] == '\t') i++; //Skip whitespace
                if (line[i] != '#') boards.Add(ParseChandef(line));
            }
        }

        public static Board ParseChandef(string line)
        {
            Board board = new Board();
            string[] args = GetArgs(line);
            board.Host = args[0];
            board.BoardName = args[1];
            board.ImageRegex = args[2];
            board.StorageDir = args[3];
            return board;
        }

        private static string[] GetArgs(string chandef)
        {
            int curIndex = 0;
            int startIndex, endIndex;
            int numargs = 4;
            string[] args = new string[numargs];
            for (int i = 0; i < numargs; i++)
            {
                startIndex = chandef.IndexOf('"', curIndex) + 1;
                endIndex = chandef.IndexOf('"', startIndex + 1); 
                args[i] = chandef.Substring(startIndex, (endIndex - startIndex));
                curIndex = endIndex + 1;
            }
            return args;
        }

        public static void Save(string path)
        {
            StreamWriter writer = new StreamWriter("ThreadSave.cfg");
            writer.WriteLine("#ThreadSave Configuration File");
            writer.WriteLine("#ThreadSave Version" + APP_VER);
            writer.WriteLine("#chandef(host, board, storagedir)");
            foreach (Board board in boards)
            {
                writer.WriteLine(String.Format("chandef(\"%s\", \"%s\", \"%s\")", board.Host, board.BoardName, board.StorageDir));
            }
        }

        public static string GetBoardName(string URL)
        {
            Uri test = new Uri(URL);
            String threadURL = test.GetComponents(UriComponents.HttpRequestUrl, UriFormat.SafeUnescaped);
            int startindex = threadURL.IndexOf("boards.4chan.org") + 16;
            int endindex = threadURL.IndexOf('/', startindex + 1);
            return threadURL.Substring(startindex, (endindex - startindex) + 1);
        }
    }
}
