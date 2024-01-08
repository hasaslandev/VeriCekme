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
        public void cekilenVeri()
        {
            HtmlWeb web = new HtmlWeb();
            int veriGH = 1;

            for (int i = 1; i < 50; i++)
            {
                HtmlDocument doc = web.Load($"https://aviation-safety.net/wikibase/dblist.php?Year=2022&sorteer=datekey&page={i}");
                var rows = doc.DocumentNode.SelectNodes("//*[@id=\"contentcolumnfull\"]/div");

                foreach (var row in rows)
                {
                    var cells = row.SelectNodes(".//td");
                    for (int k = 1; k < cells.Count; k+=10)
                    {
                        AirCrash airCrash = new AirCrash
                        {
                            Date = cells[0].InnerText.Trim(),
                            AircraftType = cells[1].InnerText.Trim(),
                            Operator = cells[3].InnerText.Trim(),
                            Fatalities = cells[4].InnerText.Trim(),
                            Location = cells[5].InnerText.Trim(),
                            Status = cells[7].InnerText.Trim()
                        };
                        repo.AddEntity(airCrash);
                    }



                }
                veriGH++;
            }
            for (int i = 0; i < airCrashes.Count; i++)
            {
                Console.WriteLine(airCrashes[i].Date);
            }
        }
        
        

    }

}
