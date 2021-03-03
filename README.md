# TextAnalyzer
## Instructions
To compile the program you should have Visual Studio and .NET Core 3.1 installed. If you open the TextAnalyzer.sln file in Visual Studio you can then click the green start button to compile and run the console app. In the output you will see the 20 most common words in each provided text file.
## Explanation
### Test Driven Development
Each method in the TextAnalyzer class was developed using Test Driven Development. You can check the commits to view the stages and progression of how I wrote this program using TDD. 
### Assumptions
- Each string is case insensitive. E.g., `the` was equal to `The`. 
- If two strings were identical in frequency, the tie breaker to consider which ranked first was it's alphabetical order.
### Logic Execution
#### 1. Read File
First I read the content of the text file into a string using the `TextAnalyzer.ReadFile` method. 
#### 2. Get Stop Words
Second I read the content of the stopwords.txt file into a list of strings using the `TextAnalyzer.GetStopWords` method.
#### 3. Get Words and their Frequency In String
##### 3.1 Split String
I then replace all non alphabetical and non space characters with String.empty to remove punctuation and any unneeded symbols. I then split the now space separated string (that contains only words) via the space characters. That results in an array of strings representing each word in the text file. Note that I call .toLower on this array and convert all the strings to lower case. 
##### 3.2 Create Frequency Dictionary
I then take the string array and convert it into a dictionary of <string, int> and sum up the amount of times that each string occurs into the int value of the dictionary.
#### 4. Remove Stop Words
Next I remove all of the words that are contained in the stopWords list from the initial frequency dictionary.
#### 5. Create Stem Frequency Dictionary
Now that there is a mapping of how often each string occurs, I can take and convert this dictionary<string, int> into another dictionary<string, int> of just the stem words. I iterate over the original dictionary and find the stem of the key word, I then insert this as a new record or update an existing record in the new stemmed dictionary to track the number of times this stem word occurs. This stemmed dictionary is the final data structure of the program that is easily iterated through and printed. This is all done within the `TextAnalyzer.StemWords` method.

## Output
### Declaration of Independence
    right 10
    govern 9
    law 9
    us 9
    state 8
    peopl 7
    power 6
    time 6
    among 5
    declar 5
    establish 5
    refus 5
    abolish 4
    assent 4
    form 4
    free 4
    independ 4
    larg 4
    new 4
    absolut 3
    
### Alice in Wonderland
    said 462
    alic 400
    littl 128
    look 104
    on 103
    like 97
    know 90
    went 83
    go 77
    thing 77
    queen 76
    thought 76
    time 74
    sai 70
    get 68
    see 68
    king 64
    think 64
    turtl 60
    well 60
