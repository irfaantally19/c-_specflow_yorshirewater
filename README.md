# Introduction 
This is an example implementation project of the YW Specflow automation framework.
This should be used as a base repository which can be imported into new repos.

# Getting Started
1.	Install dotnet 5.0
2.	Install Visual Studio and Specflow extensions
3.	Import this repo into a new repository
4.	If Visual Studio is unable to find the Core_Framework manually add the nuget url found in the nuget.config to Visual Studio Package Manager
5.  Example classes are included, once you are happy remove them to reduce clutter

# Build and Test
1.  Create or add feature files to the Features directory
2.  Execute the feature file to generate Step Definitions
3.  Create a Step Definition class and Extend the StepDefinition class which is found in the Core_Framework
4.  Create test scripts using the Page Object Model
5.  Implement Page Object Model into Step Definitions

# Living Doc
1.  Run the installLivingDoc.bat to install the dotnet tools required for Living Doc CLI
2.  Update the filepath in the refreshLivingDoc.bat (for some reason relative paths didnt work at time of creation)
3.  Run refreshLivingDoc.bat after test execution to have documentation of tests including results