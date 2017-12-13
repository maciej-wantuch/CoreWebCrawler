using System;
using System.Xml;

namespace CoreWebCrawler
{
    public class MailerConfigurator
    {
        private static XmlDocument xDoc = new XmlDocument();

        public static string GetSenderAddress()
        {
            xDoc.Load("MailerConfig.xml");
            return xDoc.DocumentElement.SelectSingleNode("senderAddress").InnerText;
        }

        public static string GetSenderName()
        {
            xDoc.Load("MailerConfig.xml");
            return xDoc.DocumentElement.SelectSingleNode("senderName").InnerText;
        }

        public static string GetSenderPassword()
        {
            xDoc.Load("MailerConfig.xml");
            return xDoc.DocumentElement.SelectSingleNode("senderPassword").InnerText;
        }
        public static string GetSenderServer()
        {
            xDoc.Load("MailerConfig.xml");
            return xDoc.DocumentElement.SelectSingleNode("senderServer").InnerText;
        }
        public static string GetRecipientAddress()
        {
            xDoc.Load("MailerConfig.xml");
            return xDoc.DocumentElement.SelectSingleNode("recipientAddress").InnerText;
        }
        public static string GetRecipientName()
        {
            xDoc.Load("MailerConfig.xml");
            return xDoc.DocumentElement.SelectSingleNode("recipientName").InnerText;
        }
    }
}
