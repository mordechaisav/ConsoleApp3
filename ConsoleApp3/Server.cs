using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace ConsoleApp3
{
    internal class Server
    {
        List<string> questions = new List<string>();
        List<string> answers = new List<string>();
        string xmlFilePath;
        public Server(string path) {
            xmlFilePath = path;


        }
        public void CreateQuestion()



        {
            Console.WriteLine("Enter the question:");
            string? question = Console.ReadLine();
            Console.WriteLine("Enter the answer:");
            string? answer = Console.ReadLine();

            XElement xml1 =(File.Exists(xmlFilePath))?XElement.Load(xmlFilePath): new XElement("data");
            xml1.Add(ToXml(question, answer));
            xml1.Save(xmlFilePath);
        }

        public XElement ToXml(string question, string answer)
        {
            XElement element = new XElement("Item",
                new XElement("Question", question),
                new XElement("Answer", answer));

            return element;
        }

        public void read()
        {
            if (!File.Exists(xmlFilePath))
            {
                Console.WriteLine("no qwetions");
                return;
            }
            XElement xml = XElement.Load(xmlFilePath);
            foreach (var item in xml.Elements("Item"))
            {

                var Question = item.Element("Question")?.Value;
                var answer = item.Element("answer")?.Value;
                questions.Add(Question);
                answers.Add(answer);
            }

            foreach (var item in questions)
            {
                Console.WriteLine(item);
            }
            int choice = Console.Read();
            Console.WriteLine(questions[choice-1]);
            string ans = Console.ReadLine();
            string result = ans == answers[choice - 1] ? "correct" : "incorrect"; 
            Console.WriteLine(result);
        }
    }
}
