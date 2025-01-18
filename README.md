## WORKING WITH LEGISTATIVE DATA
----

### Questions 

1. Discuss your solution’s time complexity. What tradeoffs did you make?<b> 
- I separated the searches into separate queries to keep them isolated simultaneous.
- I avoided using nested loops to prevent harming the time complexity.
- I could also perform the queries on demand, avoiding loading the information into memory, but given the amount of data, I didn't find it necessary.
</b>

2. How would you change your solution to account for future columns that might be requested, such as “Bill Voted On Date” or “Co-Sponsors”?<b>
- I would make the file construction dynamic, fetching the necessary tabs from the database.
This way, any other team could make changes and define an output file structure simply by setting the parameters.
</b>

3. How would you change your solution if instead of receiving CSVs of data, you were given a
list of legislators or bills that you should generate a CSV for?<b>
- I would standardize the process so that the same processing is performed regardless of the data source, ensuring that the source does not impact the core processing structure.
For instance, when dealing with a repository of legislators, I should always return a List, even if the source is a CSV, API, database, etc.
Of course, if specific scenarios exist, they should be adapted in the best possible way to preserve the domain layer.
</b>
4. How long did you spend working on the assignment?<b>
- 5 hours to develop and 2 hours to documentation and tests.
</b>


### Main technologies used 

- Frameworks
1. .NET (C#) Console Application
2. xUnit - Unit Test

- Concepts
1. I used DDD because the focus is business rules and it seemed appropriate. I didn't use these in deep form these concepts because I believed don't is the purpose of this test
