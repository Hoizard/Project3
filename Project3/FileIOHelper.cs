using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;

namespace Project3
{
    public class FileIOHelper : IIOHelper
    {
        public void AddMortgages(string formattedTempString)
        {
            try
            {
                string fileLocation = HttpContext.Current.Server.MapPath("~/app_data/log.txt");
                using (var fileStream = File.AppendText(fileLocation))
                {
                    fileStream.WriteLine(formattedTempString);
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        public void ClearAllMortgages()
        {
            try
            {
                string fileLocation = HttpContext.Current.Server.MapPath("~/app_data/log.txt");
                File.Delete(fileLocation);
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        public List<string> ListAllMortgages()
        {
            string fileLocation = HttpContext.Current.Server.MapPath("~/app_data/log.txt");

            string[] allTempStringArray = File.ReadAllLines(fileLocation);

            List<string> allTemps = new List<string>(allTempStringArray);

            return allTemps;
        }
    }
}