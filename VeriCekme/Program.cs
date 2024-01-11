using HtmlAgilityPack;
using Microsoft.EntityFrameworkCore.Migrations.Operations;
using Microsoft.Identity.Client;

namespace VeriCekme
{
    internal class Program
    {
        static void Main(string[] args)
        {
            HttpClientHandler clientHandler = new HttpClientHandler();
            clientHandler.ServerCertificateCustomValidationCallback = (sender, cert, chain, sslPolicyErrors) => { return true; };

            HttpClient client = new HttpClient(clientHandler);

            HtmlWeb web = new HtmlWeb();
            HtmlDocument document = web.Load("https://example.com/");
            var title = document.DocumentNode.SelectNodes("//div/h1").First().InnerText;
            var description = document.DocumentNode.SelectNodes("//div/p").First().InnerText;

            //Console.WriteLine(title);
            //Console.WriteLine();
            //Console.WriteLine(description);

            HtmlWeb web2 = new HtmlWeb();
            HtmlDocument document1 = web2.Load("https://tr.wikipedia.org/wiki/HTML");
            var title1 = document1.DocumentNode.SelectNodes("//*[@id=\"firstHeading\"]").First();
            var paragraphs = document1.DocumentNode.SelectNodes("//*[@id=\"mw-content-text\"]/div[1]/p");
            //Console.WriteLine(title1);
            //Console.WriteLine();
            //paragraphs.ToList().ForEach(i=> Console.WriteLine(i.InnerHtml));
            Site site = new Site();
            site.CekilenVeri();
            Repo repo = new Repo();
            var result = repo.GetAll(x => x.Location == "");
            foreach ( var op in result )
            {
                repo.Delete(op);
            }



        }

       public void veritabaniEkleme(AirCrash airCrash)
        {
            Repo repo = new Repo();

            repo.UpdateAsync(airCrash);
        }
    }
}