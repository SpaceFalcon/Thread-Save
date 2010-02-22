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
using System.Text;
using System.IO;
using System.Net;

namespace ThreadSave
{
    class NetStream
    {
        private Stream m_stream;
        private WebClient m_client;

        private bool m_exists = true;
        private bool m_loading;

        private long m_position = 0;
        private long m_length;

        private string m_mimetype;
        private string m_lasterror;

        private Encoding m_encoding;
        private HttpStatusCode m_HTTPstatuscode;

        /// <summary>
        /// The remote resource exists and is ready to be read.
        /// </summary>
        public bool Exists
        {
            get
            {
                return m_exists;
            }
        }

        /// <summary>
        /// The client is in an initialization state.
        /// </summary>
        public bool Loading
        {
            get
            {
                return m_loading;
            }
        }

        /// <summary>
        /// Current read position from the stream.
        /// </summary>
        public long Position
        {
            get
            {
                return m_position;
            }
        }

        /// <summary>
        /// The length of the data in the stream.
        /// </summary>
        public long Length
        {
            get
            {
                return m_length;
            }
        }

        /// <summary>
        /// The MIME-Type of the data in the stream.
        /// </summary>
        public string MimeType
        {
            get
            {
                return m_mimetype;
            }
        }

        /// <summary>
        /// The character encoding of the data (should it be a string).
        /// </summary>
        public Encoding Encoding
        {
            get
            {
                return m_encoding;
            }
        }

        /// <summary>
        /// The remote resource has data to be read and the stream is not at the end of the data.
        /// </summary>
        public bool HasData
        {
            get
            {
                if (m_position < m_length)
                    return true;
                else
                    return false;
            }
        }

        /// <summary>
        /// The last error that occured.
        /// </summary>
        public string LastError
        {
            get
            {
                return m_lasterror;
            }
        }

        public HttpStatusCode HTTPStatusCode
        {
            get
            {
                return m_HTTPstatuscode;
            }
        }

        /// <summary>
        /// Returns a two digit precision float with the status of the NetStream in percent complete.
        /// </summary>
        public double PercentComplete
        {
            get
            {
                if (m_exists)
                {
                    return Math.Round((((float)m_position / (float)m_length) * 100), 2);
                }
                else
                    return 0f;
            }
        }

        /// <summary>
        /// Base stream to the web resource.
        /// </summary>
        public Stream BaseStream
        {
            get
            {
                if (m_stream != null)
                    return m_stream;
                else
                    throw new Exception("No stream available");
            }
        }

        /// <summary>
        /// Read a chunk of the NetStream data into a byte array buffer.
        /// </summary>
        /// <param name="buffer">Buffer to read data into</param>
        /// <param name="offset">Offset in the stream to begin reading</param>
        /// <param name="count">Number of bytes to read starting at offset</param>
        /// <returns>Number of bytes successfully read</returns>
        public int Read(byte[] buffer, int offset, int count)
        {
            try
            {
                if (count + offset > m_length) count = (int)m_length - offset;
                int bytesRead = m_stream.Read(buffer, offset, count);
                m_position += bytesRead;
                return bytesRead;
            }
            catch(Exception ex)
            {
                m_lasterror = "Error in method: " + ex.TargetSite + " [" + ex.Message + "]";
                return 0;
            }
        }

        /// <summary>
        /// Read a single byte from the stream.
        /// </summary>
        /// <returns>The byte that was read, or -1 if at the end of the stream</returns>
        public int ReadByte()
        {
            m_position += 1;
            return m_stream.ReadByte();
        }

        /// <summary>
        /// Closes the internal stream, do not use unless reading from the stream is complete.
        /// </summary>
        public void Close()
        {
            m_stream.Close();
        }

        public NetStream(string URL)
        {
            m_client = new WebClient();
            try
            {
                m_loading = true;
                m_stream = m_client.OpenRead(URL);
                m_encoding = m_client.Encoding;
                m_length = uint.Parse(m_client.ResponseHeaders.Get("Content-Length"));
                m_mimetype = m_client.ResponseHeaders.Get("Content-Type");
                m_loading = false;
            }
            catch (WebException ex)
            {
                m_exists = false;
                if (ex.Response is HttpWebResponse)
                {
                    m_HTTPstatuscode = ((HttpWebResponse)ex.Response).StatusCode;
                }
                m_lasterror = "WebException: Status Code in HTTPStatusCode property. [" + ex.Message + "]";
            }
            catch (Exception ex)
            {
                m_exists = false;
                m_lasterror = ex.Message;
            }
        }

        ~NetStream()
        {
            try
            {
                m_stream.Dispose();
                m_client.Dispose();
            }
            catch { } //Ignore potential disposal problems, since the object is being destroyed anyway.
        }

        /// <summary>
        /// Obtains all data from the stream.
        /// </summary>
        /// <returns>Byte array of all the data in the NetStream.</returns>
        public byte[] GetAllData()
        {
            byte[] data = new byte[m_length];
            Console.WriteLine("Length: " + data.Length);
            int offset = 0;
            int chunkSize = 2048;
            if (chunkSize > m_length) chunkSize = (int)m_length;
            while (offset < m_length)
            {
                offset += m_stream.Read(data, offset, chunkSize);
                if (chunkSize > m_length - offset && m_length > chunkSize) chunkSize = (int)(m_length - offset);
            }
            m_position = m_length;
            return data;
        }
    }
}
