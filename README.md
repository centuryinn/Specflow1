
# SpecFlow-SeleniumWebdriver-RestSharp Test Automation Framework

This repository contains Web and API automation framework. 
Framework is developed using Behaviour driven development (BDD).

Tools and services used:
1. Microsoft Visual Studio 2022
2. Specflow: BDD Framework (C# alternate for cucumber) 
3. Selenium Webdriver: Framework to automate Web Applications
4. Restsharp: Framework to automate APIs
5. Nunit: for unit testing
6. ExtentReports: for reporting test results
7. LivingDoc: for reporting test results
7. Git: to make application versions, push and pull
8. Github: to store local git repo (application code)
9. TargetFramework: net6.0

## What Is This Project

SpecFlow1 is a project to build test automation project for both web and rest api's, include
to run as part of CI/CD pipeline, from scratch. This is built with .NET 6.0 specflow selenium c# nunit with reports both extent reports and specflow livingdoc.

## The Application Under Test

Demo web page https://www.demo_tbd.com/

## CI/CD

[Pipeline](https://github.com/demo_tbd/SpecFlow1/-/pipelines) is configuration
in yml with 3 stages

- build
- test
- report

Pipeline is triggered automatically once source code gets pushed to remote repository.

## Repository

https://github.com/demo_tbd/SpecFlow1/

## Project Packages

    <PackageReference Include="ExtentReports" Version="5.0.1" />
    <PackageReference Include="log4net" Version="2.0.15" />
    <PackageReference Include="Microsoft.Extensions.Configuration" Version="7.0.0" />
    <PackageReference Include="Microsoft.Extensions.Configuration.Binder" Version="7.0.4" />
    <PackageReference Include="Microsoft.Extensions.Configuration.Json" Version="7.0.0" />
    <PackageReference Include="Microsoft.NET.Test.Sdk" Version="17.0.0" />
    <PackageReference Include="Newtonsoft.Json" Version="13.0.3" />
    <PackageReference Include="NUnit.Console" Version="3.16.3" />
    <PackageReference Include="NUnit.ConsoleRunner" Version="3.16.3" />
    <PackageReference Include="RestSharp" Version="110.2.0" />
    <PackageReference Include="RestSharp.Serializers.NewtonsoftJson" Version="110.2.0" />
    <PackageReference Include="Selenium.Support" Version="4.14.1" />
    <PackageReference Include="Selenium.WebDriver" Version="4.14.1" />
    <PackageReference Include="SpecFlow" Version="3.9.74" />
    <PackageReference Include="SpecFlow.Assist.Dynamic" Version="1.4.2" />
    <PackageReference Include="SpecFlow.ExternalData" Version="3.9.74" />
    <PackageReference Include="SpecFlow.NUnit.Runners" Version="3.9.74" />
    <PackageReference Include="SpecFlow.Plus.LivingDocPlugin" Version="3.9.57" />
    <PackageReference Include="SpecFlow.NUnit" Version="3.9.74" />
    <PackageReference Include="nunit" Version="3.13.2" />
    <PackageReference Include="NUnit3TestAdapter" Version="4.1.0" />
    <PackageReference Include="FluentAssertions" Version="6.2.0" />
    <PackageReference Include="SpecFlow.Tools.MsBuild.Generation" Version="3.9.74" />
    <PackageReference Include="WebDriverManager" Version="2.17.1" />

## How To Run Test On GitHub CI/CD

- Pipeline is triggered automatically on target branch once source code is pushed to remote repository

### How To Access Test Report

Report artifacts are generated at report Test Results folder. 

## How To Run Test On Local

### This is assumed that you have these tools installed on your local machine.

- Visual Studio 2022
- SpecFlow Plugin

### Run Test

- Clone the [Remote Repository](https://github.com/demo_tbd/SpecFlow1.git)
- Change directory to root of the project
- Run command line
    - To run whole project: dotnet test
    - To run specific scenario's tag(s): 

### How To Access Test Report After Running Locally

## Extent Reports

- View report: AutomationTestReport.html report generated in TestResults->ExtentReports folder

## SpecFlow LivingDoc
Run command:

- To generate the report: livingdoc test-assembly .\<bin dir>\Project.Automation.Specs.dll -t .\<bin dir>\TestExecution.json
- View report: view .html file
