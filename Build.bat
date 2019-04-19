@echo off
cd F:\MsTestResultToHtml
rem gulp --cwd F:\MsTestResultToHtml\templates\default
msbuild MsTestResultToHtml.sln /p:Configuration=Release /p:DefineConstants="MASTER" 
cd publish
MsTestResultToHtml.Console.exe F:\MsTestResultToHtml\UI.Vbi5Client-Release.trx -o F:\MsTestResultToHtml\TestResult\
cd F:\MsTestResultToHtml
start %~dp0%TestResult\MSTestResult.html