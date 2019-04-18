using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Text;
using System.Xml;
using HtmlAgilityPack;
using MsTestResultToHtml;
using Newtonsoft.Json;
using Formatting = Newtonsoft.Json.Formatting;

namespace NUnitReporter.ReportWriters
{
    public class HtmlReportWriter
    {
        private readonly String _outputFilePath;

        private readonly String _outputFolderPath;
        private const String TemplateResoucePath = "MsTestResultToHtml.templates.default";

        private const String TemplateIndexFileName = "index.html";

        public HtmlReportWriter(string outputFilePath,string outputFileName)
        {
            _outputFilePath = Path.Combine(outputFilePath, outputFileName);
            if (!Directory.Exists(outputFilePath))
                Directory.CreateDirectory(outputFilePath);
            _outputFolderPath = outputFilePath;
        }

        private static readonly IDictionary<string, string> TemplateResources = new Dictionary<string, string>
        {
            {
                "bootstrap.dist.css.bootstrap-theme.min.css",
                @"bootstrap\dist\css\bootstrap-theme.min.css"
            },
            {
                "bootstrap.dist.fonts.glyphicons-halflings-regular.eot",
                @"bootstrap\dist\fonts\glyphicons-halflings-regular.eot"
            },
            {
                "bootstrap.dist.fonts.glyphicons-halflings-regular.svg",
                @"bootstrap\dist\fonts\glyphicons-halflings-regular.svg"
            },
            {
                "bootstrap.dist.fonts.glyphicons-halflings-regular.ttf",
                @"bootstrap\dist\fonts\glyphicons-halflings-regular.ttf"
            },
            {
                "bootstrap.dist.fonts.glyphicons-halflings-regular.woff",
                @"bootstrap\dist\fonts\glyphicons-halflings-regular.woff"
            },
            {
                "bootstrap.dist.fonts.glyphicons-halflings-regular.woff2",
                @"bootstrap\dist\fonts\glyphicons-halflings-regular.woff2"
            },
            {
                "bootstrap.dist.css.bootstrap.min.css",
                @"bootstrap\dist\css\bootstrap.min.css"
            }
        };

        private static readonly Assembly Assembly = Assembly.GetExecutingAssembly();

        private static String GetTemplateResourceName(String relativePath)
        {
            return String.Format("{0}.{1}", TemplateResoucePath, relativePath);
        }

        public  void Write(TestLoadResult document)
        {
            var jsonStr = JsonConvert.SerializeObject(document, Formatting.Indented);
            CopyMainFileTo(_outputFilePath, jsonStr);

            foreach (var pair in TemplateResources)
            {
                CopyResourceTo(GetTemplateResourceName(pair.Key), Path.Combine(_outputFolderPath, pair.Value));
            }
        }

        private void CopyResourceTo(String resourceName, String filePath)
        {
            string targetFolderPath = Path.GetDirectoryName(filePath);

            if (String.IsNullOrEmpty(targetFolderPath))
            {
                throw new ArgumentException(String.Format("Wrong path: {0}", filePath));
            }

            Directory.CreateDirectory(targetFolderPath);

            using (Stream source = Assembly.GetManifestResourceStream(resourceName))
            {
                if (source == null)
                {
                    throw new ArgumentException(String.Format("Wrong resource name: {0}", resourceName));
                }

                using (var target = new FileStream(filePath, FileMode.Create, FileAccess.Write))
                {
                    source.CopyTo(target);
                }
            }
        }

        private static void CopyMainFileTo(String outputFilePath, String testResultJson)
        {
            using (Stream stream = Assembly.GetManifestResourceStream(GetTemplateResourceName(TemplateIndexFileName)))
            {
                if (stream == null)
                {
                    throw new InvalidOperationException("Failed to load report template");
                }

                var document = new HtmlDocument();
                document.OptionDefaultStreamEncoding = Encoding.UTF8;
                document.Load(stream);

                HtmlNode body = document.DocumentNode.SelectSingleNode("//body");

                if (body == null)
                {
                    throw new InvalidOperationException("Document did not contain body");
                }

                HtmlNode script = document.CreateElement("script");
                script.SetAttributeValue("type", "text/javascript");
                script.AppendChild(document.CreateTextNode(String.Format("var NUnitTestResult = {0};", testResultJson)));
                body.PrependChild(script);

                document.Save(outputFilePath);
            }
        }
    }
}