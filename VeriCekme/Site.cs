using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace VeriCekme
{
    public class Site
    {
        Repo repo = new Repo();
        List<AirCrash> airCrashes = new List<AirCrash>();
        public void CekilenVeri()
        {

            HtmlWeb web = new HtmlWeb();
            int toplamSayfa = 50;

            for (int sayfaNo = 1; sayfaNo <= toplamSayfa; sayfaNo++)
            {
                HtmlDocument doc = web.Load($"https://aviation-safety.net/wikibase/dblist.php?Year=2022&sorteer=datekey&page={sayfaNo}");
                var rows = doc.DocumentNode.SelectNodes("//*[@id=\"contentcolumnfull\"]/div");

                if (rows != null)
                {
                    foreach (var row in rows)
                    {
                        var cells = row.SelectNodes(".//td");

                        if (cells != null && cells.Count >= 10)
                        {
                            for (int k = 10; k < cells.Count; k++)
                            {
                                if (k % 10 == 0)
                                {

                                    var imgElement = cells[k - 4].SelectSingleNode(".//img");
                                    if(imgElement != null)
                                    {
                                        string imgSrc = imgElement.GetAttributeValue("src", "");
                                        int lastIndexOfSlash = imgSrc.LastIndexOf('/');
                                        string fileName = imgSrc.Substring(lastIndexOfSlash + 1);

                                        Console.WriteLine("Dosya Adı: " + fileName);
                                        string fileNameWithoutExtension = fileName.Replace(".gif", "");
                                        var result2 = repo.GetAll(x => x.Country == null).First();
                                        result2.Country = fileNameWithoutExtension;
                                        AirCrash airCrash = new AirCrash()
                                        {
                                            AirCrashId = result2.AirCrashId,
                                            AircraftType = result2.AircraftType,
                                            Country = result2.Country,
                                            Date = result2.Date,
                                            Fatalities = result2.Fatalities,
                                            Location = result2.Location,
                                            Operator = result2.Operator,
                                            Status = result2.Status
                                        };
                                        Program program = new Program();
                                        program.veritabaniEkleme(airCrash);
                                    }


                                   
                                    //repo.AddEntity(airCrash);
                                }
                                string cellContent = cells[k].InnerText.Trim();
                                Console.WriteLine($"Row {sayfaNo}, Cell {k + 1}: {cellContent}");

                            }
                        }
                    }
                }
            }
        }



    }

}
