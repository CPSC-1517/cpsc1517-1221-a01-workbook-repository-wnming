using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NhlSystemClassLibrary
{
    public class CanadianIncomeTaxManager
    {
        public List<CanadianIncomeTaxData> ConvertToCanadianIncomeTax(List<string> lines)
        {
            List<CanadianIncomeTaxData> dataList = new List<CanadianIncomeTaxData>();
            //iterate through each element in the list
            foreach (string line in lines)
            {
                string[] dataFromFile = line.Split(',');
                CanadianIncomeTaxData data = new CanadianIncomeTaxData();
                data.RegionAbbreviation = dataFromFile[0];
                data.RegionName = dataFromFile[1];
                data.TaxYear = int.Parse(dataFromFile[2]);
                data.StartingIncome = decimal.Parse(dataFromFile[4]);
                data.EndingIncome = decimal.Parse(dataFromFile[5]);
                data.TaxRate = double.Parse(dataFromFile[6]);
                data.BaseTaxAmount = decimal.Parse(dataFromFile[7]);
            }
            return dataList;
        }
        public List<string> LoadFromCsvFile(string csvFilePath)
        {
            List<string> allLines = new List<string>();

            //use the StreamReader or File class to read data from file
            //using (StreamReader reader = new StreamReader(csvFilePath))
            //{
            //    string line;
            //    bool firstLine = true;
            //    while ((line = reader.ReadLine()) != null)
            //    {
            //        if (firstLine)
            //        {
            //            firstLine = false;
            //        }
            //        else
            //        {
            //            allLines.Add(line);
            //        }
            //    }
            //}
            //another way
            string[] lineArray = File.ReadAllLines(csvFilePath);
            allLines = lineArray.ToList().Skip(1).ToList();

            return allLines;
        }
    }
}
