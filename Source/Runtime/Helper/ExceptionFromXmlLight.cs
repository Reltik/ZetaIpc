﻿namespace ZetaIpc.Runtime.Helper
{
    using System.Xml;

    internal sealed class ExceptionFromXmlLight
    {
        public static bool IsSerializedException(string raw)
        {
            return !string.IsNullOrEmpty(raw) && raw.Contains(ExceptionToXmlLight.Magic);
        }

        public ExceptionFromXmlLight(string xml)
        {
            var doc = new XmlDocument();
            doc.LoadXml(xml);

            Message = doc.SelectSingleNode(@"/exception/message").InnerText;
            Type = doc.SelectSingleNode(@"/exception/type").InnerText;
            Source = doc.SelectSingleNode(@"/exception/source").InnerText;
            StackTrace = doc.SelectSingleNode(@"/exception/stackTrace").InnerText;
            Dump = doc.SelectSingleNode(@"/exception/dump").InnerText;
        }

        public string Message { get; private set; }
        public string Type { get; private set; }
        public string Source { get; private set; }
        public string StackTrace { get; private set; }
        public string Dump { get; private set; }
    }
}