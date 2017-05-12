using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeanSummary
{
    class Program
    {
        static void Main(string[] args)
        {
            var web = new HtmlWeb();
            var doc = web.Load("http://dean.xjtu.edu.cn/jxxx/xwdt.htm");
            var y = doc.DocumentNode.SelectSingleNode("//div[@class='list_main_content']"); 
            // HtmlDocument.DocumentNode
            //              .GetElementById
            // HtmlNode.innerText .InnerHtml .SelectNodes .SelectSingleNode
            foreach (var i in y.SelectNodes("./div"))
            {
                string name = null, url = null, date = null;
                //var namenode = i.SelectSingleNode("./a");
                //name = namenode.GetAttributeValue("title", "");
                //Console.WriteLine(name);
                var urlnode = i.SelectSingleNode("./a");
                url = urlnode.GetAttributeValue("href", "");
                //Console.WriteLine(url);
                var datenode = i.SelectSingleNode("./span");
                date = datenode.GetAttributeValue("datenode", "");
                Console.WriteLine(i.InnerText  );
                //........
                //Console.WriteLine("({0}){1}", i.GetAttributeValue("href", ""), i.InnerText);
                Console.WriteLine("({0}){1} {2}", url, name, date);
            }
            Console.ReadLine();
            //Console.WriteLine(doc);
            //Console.ReadLine();
        }
    }
}
