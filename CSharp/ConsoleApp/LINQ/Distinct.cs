using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp.LINQ
{
    internal class Distinct
    {
        internal void TestDinstinctByOneField()
        {
            List<TestData> _TestDataSet = new()
            {
                new TestData { Description = "A", ModelCode = "1"},
                new TestData { Description = "A", ModelCode = "2"},
                new TestData { Description = "B", ModelCode = "1"},
                new TestData { Description = "C", ModelCode = "2"},
            };

            var _DistinctList = _TestDataSet.GroupBy(x => x.Description)
                .Select(x => x.FirstOrDefault()).ToList();
        }
    }

    internal class TestData
    {
        public string Description { get; set; }
        public string ModelCode { get; set; }
    }
}
