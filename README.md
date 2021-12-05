# Input
Characters allowed: 
* Natural numbers.
* Mathematical operations: `+,-,*,/`.
* White spaces.

Input value should start with either integer, or white space.

# Output
Output value will be represented as real number.

# Test plan
* Write unit tests for main functionality. Tests should regularly run on CI pipeline (CI is not implemented at this stage).
* Quality of unit tests are being measured as follows:
    * Use code coverage metrics.
    * "Test the tests" by applying code mutations (either manual or automated).
* Exploratory testing: generate a solid pool of random valid inputs and calculate expected outputs using the reliable tool (e.g. DataTable.Compute() in C#, WolframAlpha, etc.). Compare the results. This testing should be done automatically but not necessarily run on CI pipeline.
* Manually test the usability:
    * check a couple of valid expressions,
    * check validation messages,
    * check incredibly large values.
