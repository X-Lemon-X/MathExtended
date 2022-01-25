using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MathExtended.Statistics
{
    public class StatisticsData
    {
        private DataForStatistics dfs;
        private DataForStatistics sortedDFS;
        private double avarage;
        private double standardDiviation;
        private double mediana;


        private bool sortedDFSCalcualted = false;
        private bool medianaCalcualted = false;
        private bool avarageCalcualted = false;
        private bool sdiviationCalcualted = false;

        public StatisticsData(DataForStatistics dataForStatistics)
        {
            if (dataForStatistics == null)
            {
                throw new ArgumentNullException("dataForStatistics");
            }
            else
            {
                dfs = dataForStatistics;
            }
        }

        private double CalculateAvarage()
        {
            double[] dataA = dfs.GetData().ToArray();

            double dataAvarage = 0;
            foreach (double item in dataA)
            {
                dataAvarage += item;
            }

            avarage = dataAvarage / (double)dataA.Length;
            avarageCalcualted = true;
            GC.Collect();
            return avarage;
        }
        private double CalculateStandardDiviation()
        {
            if (!avarageCalcualted) CalculateAvarage();

            double sd = 0;
            foreach (double item in dfs.GetData())
            {
                sd += item * item;
            }

            sd /= (double)dfs.GetData().Count();

            sd -= avarage * avarage;

            sd = Math.Sqrt(Math.Abs(sd));
            standardDiviation = sd;
            sdiviationCalcualted = true;
            GC.Collect();
            return sd;
        }
        private double CalculateMediana()
        {
            if (!sortedDFSCalcualted) SortDataBubble();

            int size = sortedDFS.GetData().Count;
            if (size % 2 == 0)
            {
                double val = sortedDFS.GetData()[size / 2];
                val += sortedDFS.GetData()[size / 2 + 1];
                mediana = val / 2;
                medianaCalcualted = true;
                return mediana;
            }
            else
            {
                mediana = sortedDFS.GetData()[size / 2 + 1];
                medianaCalcualted = true;
                return mediana;
            }
        }

        public double GetAvarage()
        {
            if (avarageCalcualted)
                return avarage;  
            else  
                return CalculateAvarage();  
        }
        public double GetStandardDiviation()
        {
            if (sdiviationCalcualted)
                return standardDiviation;
            else
                return CalculateStandardDiviation();
        }
        public double GetMediana()
        {
            if (medianaCalcualted)
                return standardDiviation;
            else
                return CalculateMediana();
        }

        public DataForStatistics SortDataBubble()
        {
            double[] data = dfs.GetData().ToArray();

            long j = 0, changes = 1;
            while (changes != 0)
            {
                changes = 0;
                for (int i = 0; i < dfs.GetData().Count - j - 1; i++)
                {
                    if (data[i] > data[i + 1])
                    {
                        double d = data[i];
                        data[i] = data[i + 1];
                        data[i + 1] = d;
                        changes++;
                    }
                }
                j++;
            }
            GC.Collect();
            sortedDFS = new DataForStatistics(data);
            sortedDFSCalcualted = true;
            return sortedDFS;
        }

    }
}
