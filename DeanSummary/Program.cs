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
            HtmlWeb web = new HtmlWeb();
            HtmlDocument doc1 = web.Load("http://dean.xjtu.edu.cn/jxxx/xwdt.htm");
            HtmlDocument doc2 = web.Load("http://dean.xjtu.edu.cn/jxxx/xytz.htm");
            HtmlDocument doc3 = web.Load("http://dean.xjtu.edu.cn/jxxx/zhtz.htm");
            //HtmlNode  x = doc1.DocumentNode.SelectSingleNode("//div[@class='list_main_content']");
            //HtmlNode  y = doc2.DocumentNode.SelectSingleNode("//div[@class='list_main_content']");
            //HtmlNode  z = doc3.DocumentNode.SelectSingleNode("//div[@class='list_main_content']");
            // HtmlDocument.DocumentNode
            //              .GetElementById
            // HtmlNode.innerText .InnerHtml .SelectNodes .SelectSingleNode
            var notes = new List<Notification> ();
            
            //    //........
            //    //Console.WriteLine("({0}){1}", i.GetAttributeValue("href", ""), i.InnerText);
            //   Notification note = new Notification(name, url, date);

            //    Console.WriteLine("({0}){1} {2}", url, name, date);
            //}
            Repetition img = new Repetition();
            img.FindAllNotifications(doc1);
            img.FindAllNotifications(doc2);
            img.FindAllNotifications(doc3);
            //notes.AddRange();
            //notes.Add(new Notification("电气223", "abc1", "223"));
            //notes.Add(new Notification("电气123", "abc", "123"));
            //notes.Add(new Notification("交大", "abc", "123"));
            //foreach (var item in notes.Where(n => n.Name.Contains("电气"))
            //    .OrderByDescending(n => n.Date))
            //{
            //    Console.WriteLine(item);
            //}
            Console.ReadLine();
            //Console.WriteLine(doc);
            //Console.ReadLine();
        }
    }
    class Notification
    {

        public string Name { get; set; }

        public string Url { get; set; }

        public string Date { get; set; }

        public Notification(string name, string url, string date)
        {
            Name = name;
            Url = url;
            Date = date;
        }
       
        public override string ToString()
        {
            //return $"[{Date}]{Name}";
            return string.Format("[{0}]{1}", Name, Date);
        }
    }
    class Repetition
    {

        private readonly HtmlWeb web = new HtmlWeb();

        public IEnumerable<Notification> DownloadAllNotifications(string url)
        {
            var doc = web.Load(url);
            return FindAllNotifications(doc);
        }

        public IEnumerable<Notification> FindAllNotifications(HtmlDocument document)
        {
            HtmlNode node = document.DocumentNode.SelectSingleNode("//div[@class='list_main_content']");
            foreach (var i in node.SelectNodes("./div"))
            {
                string name = null, url = null, date = null;
                var namenode = i.SelectSingleNode("./a");
                name = namenode.GetAttributeValue("title", "");
                var urlnode = i.SelectSingleNode("./a");
                url = urlnode.GetAttributeValue("href", "");
                var datenode = i.SelectSingleNode("./span");
                date = datenode.InnerText;
                yield return new Notification(name, url, date);
            }

        }
    }
}
