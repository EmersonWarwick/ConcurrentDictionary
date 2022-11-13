using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoConcurrentDictionary
{
    internal class ConcurrentDictionaryTest
    {
        ConcurrentDictionary<int, DictionaryModel> CD = new ConcurrentDictionary<int, DictionaryModel>();

        const int kID = 1;

        internal ConcurrentDictionaryTest()
        {
            DictionaryModel basicModel = new DictionaryModel
            {
                ID = 1,
                Name = "Test",
                DatabaseID = 1,
            };

            CD.TryAdd(kID, basicModel);

            Task.Run(() => ModifyDataInDictionaryWithoutTryUpdate());
        }

        private void ModifyDataInDictionaryWithoutTryUpdate()
        {
            if (CD.TryGetValue(kID, out DictionaryModel complexObjectInside))
            {
                while (true)
                {
                    complexObjectInside.DatabaseID++;
                }
            }
        }

        private SummaryData GetClonedSummaryData()
        {
            if (CD.TryGetValue(kID, out DictionaryModel complexObjectInside))
            {
                return complexObjectInside.SummaryData();
            }
            return new SummaryData();
        }

        public int GetSummaryID
        {
            get => GetClonedSummaryData().SDatabaseID;
        }

        private int GetIDFromDictionary()
        {
            if (CD.TryGetValue(kID, out DictionaryModel complexObjectInside))
            {
                return complexObjectInside.DatabaseID;
            }
            return 0;
        }

        public int GetRootID
        {
            get => GetIDFromDictionary();
        }
    }
}
