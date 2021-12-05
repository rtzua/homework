The code is written under an assumption that algorithm should be implemented from scratch without using external "ready to use" solutions (e.g. DataTable.Compute(), make API calls to WolframAlpha, etc.) In different circumstances it would probably be better to use other approaches.


# Input
Characters allowed: 
* Natural numbers.
* Mathematical operations: `+,-,*,/`.
* White spaces.

Input value should start with either integer, or white space.

# Output
Output value is represented as a real number.

# Test plan
* Write unit tests for main functionality. Tests should regularly run on CI pipeline (CI is not implemented at this stage).
* Quality of unit tests are being measured as follows:
    * Use code coverage metrics.
    * "Test the tests" by applying code mutations (either manual or automated).
* Exploratory testing: generate a solid pool of random valid inputs and calculate expected outputs using the reliable tool (e.g. DataTable.Compute() in C#, WolframAlpha, etc.). Compare the results. This testing should be done automatically but not necessarily run on CI pipeline.
* Manually test the usability:
    * check a couple of valid expressions,
    * check validation messages (is software handling them in a proper way?),
    * check incredibly large values.
    
# Limitations of current implementation
The implementation could be improved by handling large output numbers more gracefully. Currently, it handles large values with some approximation. Needs to decide, what is expected behavior and make according adjustments (either improve the implementation or document current behavior precisely).
