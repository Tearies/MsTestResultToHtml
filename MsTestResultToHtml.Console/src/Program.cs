using System;
using CommandLine;
using NUnitReporter.ReportWriters;

namespace MsTestResultToHtml
{
    class Program
    {
        static void Main(string[] args)
        {
            var options = new CommandLineOptions();
            try
            {
                if (!Parser.Default.ParseArguments(args, options))
                {
                    return;
                }

                Console.WriteLine("Start");
                Validate.FileExist(options.TestResultXmlPath, "Test Result Xml Path");
                TestLoadResult testLoadResult = TestLoadResult.ConvertFrom(options.TestResultXmlPath);
                HtmlReportWriter writer = new HtmlReportWriter(options.OutputFolderPath, options.OutputName);
                writer.Write(testLoadResult);
            }
            catch (Exception ex)
            {
                Console.Error.WriteLine(ex.Message);
                Console.WriteLine(options.GetUsage());
            }
            Console.WriteLine("End");
        }
    }


}
