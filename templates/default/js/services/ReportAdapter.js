 

function ReportAdapter(report) {
    this.testCasereport=new TestCaseReportWrapper(report["tests"]);
    this.summaryreport=new TestSummaryWrapper(report["totalTestsProp"]);
}

ReportAdapter.prototype.summary = function() {
    return {
        'Total': this.summaryreport['Total'] || 0,
        'Executed': this.summaryreport['Executed'] || 0,
        'Passed': this.summaryreport['Passed'] || 0,
        'Failed': this.summaryreport['Failed'] || 0,
        'Error': this.summaryreport['Error'] || 0,
        'Timeout': this.summaryreport['Timeout'] || 0,
        'Aborted': this.summaryreport['Aborted'] || 0,
        'Inconclusive': this.summaryreport['Inconclusive'] || 0,
        'PassedButRunAborted': this.summaryreport['PassedButRunAborted'] || 0,
        'NotRunnable': this.summaryreport['NotRunnable'] || 0,
        'NotExecuted': this.summaryreport['NotExecuted'] || 0,
        'Disconnected': this.summaryreport['Disconnected'] || 0,
        'Warning': this.summaryreport['Warning'] || 0,
        'Completed': this.summaryreport['Completed'] || 0,
        'InProgress': this.summaryreport['InProgress'] || 0,
        'Pending': this.summaryreport['Pending'] || 0,
        'StartTime': this.summaryreport['StartTime'] || 0,
        'FinishTime': this.summaryreport['FinishTime'] || 0,
        'TestCategory': this.summaryreport['TestCategory'] || 0,
        'Duration': this.summaryreport['Duration'] || 0,
    };
};

ReportAdapter.prototype.testFixtures = function() {
    var testFixtures = [];

   
    return testFixtures;
};

ReportAdapter.prototype.testCases = function() {
    return this.testCasereport.getTestCases();
};

ReportAdapter.prototype.findTestCaseByName = function(testName) {
    
    var testCase;

    angular.forEach(this.testCases(), function(tc) {
        if (tc.TestName === testName) {
            testCase = tc;
            return;
        }
    });

    return testCase;
};

 
function TestSummaryWrapper(rawTestSuite) {
    var self = this;
    angular.forEach(rawTestSuite, function(value, key) {
    self[key]=value
    });
}
function TestCaseReportWrapper(rawTestSuite) {
    var self = this;
    self["TestCases"]=rawTestSuite
}


TestSummaryWrapper.prototype.isTestFixture = function() {
    return true;
};

 
TestCaseReportWrapper.prototype.getTestCases = function() {
    var testCases = [];
    angular.forEach(toArray(this["TestCases"]), function(testCase) {
        testCases.push(new TestCaseWrapper(testCase));
    });
    return testCases;
};
TestCaseWrapper.prototype.getMessage = function(){
    return this.Message;
};
TestCaseWrapper.prototype.getStackTrace = function(){
    return this.StackTrace;
};


function TestCaseWrapper(rawTestCase) {
    var self = this;
    this.name=rawTestCase.MethodName;
    this.Description=rawTestCase.Description;
    this.Message=rawTestCase.Message;
    this.Result=rawTestCase.Result;
    this.DisPlayName=this.name;
    this.ClassName=rawTestCase.ClassName;
    this.TestName=rawTestCase.TestName;
    this.Duration=rawTestCase.Duration;
    this.StackTrace=rawTestCase.StackTrace;
    if(this.Description!=null && this.Description!="null"){
        this.DisPlayName=this.name+"["+this.Description+"]";
    } 
 
}
function toArray(value) {
    return value ? angular.isArray(value) ? value : [value] : [];
}
module.exports = ['Report', ReportAdapter];