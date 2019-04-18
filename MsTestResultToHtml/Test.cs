﻿using System.IO;
using System.Linq;
using System.Text;

namespace MsTestResultToHtml
{
    public class Test
    {
        public string MethodName { get; set; }
        public string ClassName { get; set; }
        public string ID { get; set; }
        public string Result { get; set; }
        public string StartTime { get; set; }
        public string Duration { get; set; }
        public string Message { get; set; }
        public string Description { get; set; }

        public string TestName { get; set; }

        public string StackTrace { get; set; }

        public override string ToString()
        {
            return $"{MethodName} - {ClassName.Split('.').Last()} - Result: {Result}";
        }

        public override bool Equals(object obj)
        {
            if (!(obj is Test))
                return false;

            Test o = (Test)obj;

            return MethodName == o.MethodName && ClassName == o.ClassName && ID == o.ID && Result == o.Result;
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
    }
}