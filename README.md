# Explanation

I have created a dotnet core console application which acts as an entry point.

I have hard coded the file 'data-clean' as the file to read from but this can be changed to 'data-dirty'. 

The main method of the console instantiates `CsvAngloDataReader` and `RuleEngine`, ideally these should be injected as dependancies as I have interfaces for them. 

## `IAngloDataReader` && `CsvAngloDataReader`

IAngloDataReader is an interface I created just incase we want to change the way files are being read in the future from a CSV format to something else, we can just create another class that implements the interface and we won't have to make changes to the CsvAngloDataReader.

## `AngloTest.RulesEngine`

This is project that has the rules engine implementation. I used a Rules Design Pattern to achieve this. The reason I went that route is to allow rules to be added in future. This way I don't end up writing a long if/else statement in the code or having to amend the if else conditions by adding more when they're. Instead I can just add a new concrete class that implements the `IValidationRule` interface. And because I am using reflection and projection, the new class will automatically be used to validate the file. 

## Test

I have added an `nunit` test, since this test was initially to validate the excel sheet, this test is only testing against the `RulesEngine`. 