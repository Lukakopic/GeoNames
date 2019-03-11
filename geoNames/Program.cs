using OfficeOpenXml;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace geoNames
{
    class Program
    {
        static void Main(string[] args)
        {
            // var fileName = @"D:\adreses.txt";
            //GenerateFromTXT(fileName);
            var fileName = @"D:\GitProjekti\GeoNames\ADDRESSES_COPY – kopija.xlsx";
            printToFile(LoadOneSheet.GenerateFromXLS(fileName));
            //printToFile(LoadAllSheets.GenerateFromXLS(fileName));
        }

        private static void printToFile(List<Adresa> inputData)
        {
            DateTime dt = DateTime.Now;
            var formatedDate = dt.ToString("yyyy-MM-dd");
            var outFilename = @"D:\GitProjekti\GeoNames\adresesCopy.txt";

            if (File.Exists(outFilename))
            {
                File.Delete(outFilename);
            }

            foreach (var adresa in inputData)
            {
                adresa.country_code = "HR";
                adresa.cc2 = "HR";
                adresa.feature_class = "P";
                adresa.feature_code = "PPL";

                adresa.admin1_code = GetZupanijaCode(adresa.name);
               
                string strline = $"{adresa.geonameid}\t{adresa.name}\t{adresa.asciiname}\t{adresa.alternatenames}\t{adresa.longitude}\t{adresa.latitude}\t{adresa.feature_class}\t{adresa.feature_code}\t{adresa.country_code}\t{adresa.cc2}\t{adresa.admin1_code}\t{adresa.admin2_code}\t{adresa.admin3_code}\t{adresa.admin4_code}\t{adresa.population}\t{adresa.elevation}\t{adresa.dem}\tEurope/Zagreb\t{formatedDate}";
                File.AppendAllText(outFilename, strline + Environment.NewLine, Encoding.UTF8);
            }
            Console.WriteLine("done");
            Console.ReadLine();
        }

        private static string GetZupanijaCode(string postCode)
        {
            if (postCode.StartsWith("31"))
            {
                return "10";
            }

            if (postCode.StartsWith("10"))
            {
                return "20";
            }

            if (postCode.StartsWith("52"))
            {
                return "04";
            }

            if (postCode.StartsWith("32"))
            {
                return "18";
            }

            if (postCode.StartsWith("48"))
            {
                return "06";
            }

            if (postCode.StartsWith("51"))
            {
                return "12";
            }

            if (postCode.StartsWith("21"))
            {
                return "15";
            }

            if (postCode.StartsWith("44"))
            {
                return "14";
            }

            if (postCode.StartsWith("23"))
            {
                return "19";
            }

            if (postCode.StartsWith("49"))
            {
                return "07";
            }

            if (postCode.StartsWith("47"))
            {
                return "05";
            }

            if (postCode.StartsWith("34"))
            {
                return "11";
            }

            if (postCode.StartsWith("22"))
            {
                return "13";
            }

            if (postCode.StartsWith("35"))
            {
                return "02";
            }

            if (postCode.StartsWith("43"))
            {
                return "01";
            }

            if (postCode.StartsWith("20"))
            {
                return "03";
            }

            if (postCode.StartsWith("33"))
            {
                return "17";
            }

            if (postCode.StartsWith("40"))
            {
                return "09";
            }

            if (postCode.StartsWith("53"))
            {
                return "08";
            }

            if (postCode.StartsWith("42"))
            {
                return "16";
            }

            return string.Empty;
        }

        private static void GenerateFromTXT(string fileName)
        {
            var mylist = new List<Adresa>();

            if (!File.Exists(fileName))
            {
                return;
            }

            var lines = File.ReadLines(fileName);
            foreach (var line in lines)
            {
                if (line.StartsWith("ADDRESS_ID"))
                {
                    continue;
                }

                var data = line.Split('\t');
                var adresa1 = new Adresa();

                if (data.Length >= 0)
                {
                    adresa1.geonameid = data[0];
                }

                if (data.Length > 1)
                {
                    adresa1.name = data[1];
                    adresa1.asciiname = data[1];
                    adresa1.alternatenames = data[1];

                }
                                
                if (data.Length > 2)
                {
                    adresa1.longitude = data[2];
                }

                if (data.Length > 3)
                {
                    adresa1.latitude = data[3];
                }


                mylist.Add(adresa1);
            }
            printToFile(mylist);
        }
       
    }

}
