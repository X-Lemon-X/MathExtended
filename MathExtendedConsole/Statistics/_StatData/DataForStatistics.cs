using System.Collections.Generic;

namespace MathExtended.Statistics
{
    public class DataForStatistics
    {
        private List<double> list;

        public DataForStatistics(double[] data)
        {
            this.list = new List<double>(data);
        }

        public DataForStatistics(List<double> list)
        {
            this.list = list;
        }

        public List<double> GetData()
        {
            return this.list;
        }
    }
}
