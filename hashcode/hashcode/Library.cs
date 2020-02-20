using System;
using System.Collections.Generic;
using System.Text;

namespace hashcode
{
    /// <summary>
    /// Storing the lib data
    /// </summary>
    class Library
    {
        public int bLib;
        public int proDays;
        public int bDay;
        public List<int> ids;
        public int libId;

        /// <summary>
        /// Create Library
        /// </summary>
        /// <param name="bLib"></param>
        /// <param name="proDays"></param>
        /// <param name="bDay"></param>
        /// <param name="id"></param>
        public Library(int libId, int bLib, int proDays, int bDay, List<int> ids)
        {
            this.libId = libId;
            this.bLib = bLib;
            this.proDays = proDays;
            this.bDay = bDay;
            this.ids = ids;
        }
    }
}
