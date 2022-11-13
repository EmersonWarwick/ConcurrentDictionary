using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoConcurrentDictionary
{
    internal class DictionaryModel
    {
        internal int ID { get; set; }
        internal string? Name { get; set; }
        public int DatabaseID { get; set; }

        internal SummaryData SummaryData()
        {
            return new SummaryData
            {
                SName = Name,
                SDatabaseID = DatabaseID
            };
        }
    }
}
