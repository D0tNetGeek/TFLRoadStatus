# TFLRoadStatus
<p>Create a C# client to find out the status of major roads using TFL API.</p>

<h2>Tools and Technologies used</h2>

<ul>
	<li>Visual Studio 2019</li>
	<li>ASP.NET Framework 4.7.2</li>
	<li>Visual Studio IDE</li>
	<li>TDD (xUnit)</li>
	<li>BDD (Specflow)</li>
</ul>

<h3>Prerequisites</h3>

<ul>
	<li>Extract the contents of zip file into a directory</li>
	<li>Go to the directory and open the "TFLRoadStatus.sln" file</li>
	<li>Build solution - since all the packages are deleted, you are advised to build the solution to restore missing package and build the solution again.</li>
</ul>

<h3>Setup</h3>

<p>You need to update the "App.Config" files for "AppId" and "AppKey" into following projects</p>

<ul>
	<li>TFLRoadStatus.Specs</li>
	<li>TFLRoadStatus.Integration.Tests</li>
	<li>TFLRoadStatus.Console</li>
</ul>

<h3>Steps to run</h3>

<ul>
	<li>Go to command line->Go to Debug folder (TFLRoadStatus.Console project)</li>
	<li>Enter "TFLRoadStatus A2" to see result of valid road status request or "TFLRoadStatus A223" to see the result of invalid road status request</li>
</ul>

<h3>Running the tests</h3>

<ul>
	<li>Load the solution into Visual Studio IDE and open the test explorer.</li>
	<li>Click on "Run all Tests" button/context menu or select individual test project to run the tests<li>
</ul>

<h2>Solution</h2>

The solution consists of following projects

<ul>
<li><strong>TFLRoadStatus.API</strong></li>
contains implementaion of creating a web client for sending request to TFL API to find status of road status and parsing the results to print the response.</br></br>

<li><strong>TFLRoadStatus.Console</strong></li>
contains implementation of console application to accept arguments from command line and to get the road status using TFLRoadStatus.API</br></br>

<li><strong>TFLRoadStatus.Integration.Tests</strong></li>
contains integration tests with TFL API and app.config file</br></br>

<li><strong>TFLRoadStatus.Specs</strong></li>
contains BDD spec tests using SpecFlow</br></br>

<li><strong>TFLRoadStatus.Stubs</strong></li>
contains implementation of handler function to create stub</br></br>

<li><strong>TFLRoadStatus.Tests</strong></li>
contains unit tests using xUnit</br></br>
</ul>

<h2>Assumptimons</h2>

<ul>
	<li>TFLRoadStatus.Specs are written to mock the TFL API URL and configuration</li>
	<li>Used Aufo DI container to decouple and to remove dependencies between projects<li>
</ul>