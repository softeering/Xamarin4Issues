# Xamarin4Issues
##Xaml Compilation
- Open the solution and set the "XamlCompileIssue.iOS" project as startup
- The ContentPage named "CustomControl.xaml" explains the issue we're having when pre-compiling the xaml

##ADAL library
- Open the solution and set the "ADALIssue.iOS" project as startup
- Issue with the latest ADAL pre-release version after the migration to Xamarin 4
    - https://github.com/AzureAD/azure-activedirectory-library-for-dotnet/releases
- You can have a look at the code but won't be able to reproduce the error without us logging in against our Azure Active Directory instance
    - We can set up a sharing session once an engineer from Xamarin takes a look at the issue
    - You can create an Azure AD instance on your side and change the constant values to use your own configuration
- The app works on the simulator (iPhone 5s iOS 8 / 9) but doesn't work while debugging on a device (iPhone 5S iOS 9.1)
    - The exact same code was working before the migration to Xamarin 4
- The error message we are getting while running on the device is the following:
```
System.ExecutionEngineException: Attempting to JIT compile method '(wrapper runtime-invoke) <Module>:runtime_invoke_bool_Nullable`1<DateTimeOffset> (object,intptr,intptr,intptr)' while running with --aot-only. 
See http://docs.xamarin.com/ios/about/limitations for more information.
-> System.Reflection.TargetInvocationException: Exception has been thrown by the target of an invocation.
```

##Version info
###Visual Studio
```
Microsoft Visual Studio Enterprise 2015
Version 14.0.24720.00 Update 1
Microsoft .NET Framework
Version 4.6.01038

Installed Version: Enterprise

Architecture and Modeling Tools   00322-90000-00365-AA634
Microsoft Architecture and Modeling Tools
    
UML® and Unified Modeling Language™ are trademarks or registered trademarks of the Object Management Group, Inc. in the United States and other countries.

Visual Basic 2015   00322-90000-00365-AA634
Microsoft Visual Basic 2015

Visual C# 2015   00322-90000-00365-AA634
Microsoft Visual C# 2015

Visual C++ 2015   00322-90000-00365-AA634
Microsoft Visual C++ 2015

Visual F# 2015   00322-90000-00365-AA634
Microsoft Visual F# 2015

Windows Phone SDK 8.0 - ENU   00322-90000-00365-AA634
Windows Phone SDK 8.0 - ENU

Application Insights Tools for Visual Studio Package   1.0
Application Insights Tools for Visual Studio

ASP.NET and Web Tools 2015 (RC1 Update 1)   14.1.11120.0
ASP.NET and Web Tools 2015 (RC1 Update 1)

ASP.NET Web Frameworks and Tools 2012.2   4.1.41102.0
For additional information, visit http://go.microsoft.com/fwlink/?LinkID=309563

ASP.NET Web Frameworks and Tools 2013   5.2.30624.0
For additional information, visit http://www.asp.net/

Azure App Service Tools v2.8.1   14.0.11123.0
Azure App Service Tools v2.8.1

Common Azure Tools   1.7
Provides common services for use by Azure Mobile Services and Microsoft Azure Tools.

DataFactoryProject   1.0
Microsoft Data Factory Package

GitHub.VisualStudio   1.0
A Visual Studio Extension that brings the GitHub Flow into Visual Studio.

Microsoft Azure Data Factory Node Node   1.0
Azure Data Factory extension for Visual Studio Server Explorer.

Microsoft Azure HDInsight HQL Service   2.0.2900.0
Language service for Hive query

Microsoft Azure HDInsight Tools for Visual Studio   2.0.2900.0
An integrated development environment for HDInsight application development.

Microsoft Azure Mobile Services Tools   1.4
Microsoft Azure Mobile Services Tools

Microsoft Azure Tools   2.7
Microsoft Azure Tools for Microsoft Visual Studio 2015 - v2.7.30818.1601

Microsoft Azure Tools   2.8
Microsoft Azure Tools for Microsoft Visual Studio 2015 - v2.8.31121.1

Microsoft Team Foundation Server 2015 Power Tools   14.0
Power Tools that extend the Team Foundation Server integration with Visual Studio.

Microsoft Visual Studio Process Editor   1.0
Process Editor for Microsoft Visual Studio Team Foundation Server

NuGet Package Manager   3.3.0
NuGet Package Manager in Visual Studio. For more information about NuGet, visit http://docs.nuget.org/.

Office Developer Tools for Visual Studio 2015 ENU   14.0.23025
Microsoft Office Developer Tools for Visual Studio 2015 ENU

PreEmptive Analytics Visualizer   1.2
Microsoft Visual Studio extension to visualize aggregated summaries from the PreEmptive Analytics product.

SQL Server Data Tools   14.0.50730.0
Microsoft SQL Server Data Tools

tangible T4 Editor   2.3.0
tangible engineering GmbH

TypeScript   1.7.4.0
TypeScript for Microsoft Visual Studio

Web Essentials 2015   0.5.197
Adds many useful features to Visual Studio for web developers.

Workflow Manager Tools 1.0   1.0
This package contains the necessary Visual Studio integration components for Workflow Manager.

Xamarin   4.0.0.1697 (deffc90)
Visual Studio extension to enable development for Xamarin.iOS and Xamarin.Android.

Xamarin.Android   6.0.0.34 (3efa14c)
Visual Studio plugin to enable development for Xamarin.Android.

Xamarin.iOS   9.2.1.51 (3c0ec35)
Visual Studio extension to enable development for Xamarin.iOS.
```
