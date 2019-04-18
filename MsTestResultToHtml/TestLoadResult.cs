using System.Collections.Generic;

namespace MsTestResultToHtml
{
    public class TestLoadResult
    {
        public IEnumerable<Test> tests { get; internal set; }
        public TotalTestsProperties totalTestsProp { get; internal set; }
        public List<string> AllTestedClasses { get; internal set; }

        public static TestLoadResult ConvertFrom(string optionsTestResultXmlPath)
        {
            var trxReader = new TrxReader(optionsTestResultXmlPath);
            return trxReader.CreateTestLoadResult();
        }
    }
}