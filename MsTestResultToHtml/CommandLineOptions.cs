using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommandLine;
using CommandLine.Text;

namespace MsTestResultToHtml
{
    public class CommandLineOptions
    {

        [ValueOption(0)]
        public String TestResultXmlPath { get; set; }

        [Option('a', "attachments", HelpText = "Path to attachments folder")]
        public String AttachmentFolderPath { get; set; }

        [Option('o', "output", DefaultValue = "./", HelpText = "Path to output folder")]
        public String OutputFolderPath { get; set; }
        [Option('f', "outputname", DefaultValue = "MSTestResult.html", HelpText = "Path to output folder")]
        public string OutputName { get; set; }

        [HelpOption]
        public String GetUsage()
        {
            return HelpText.AutoBuild(this);
        }

    }
}
