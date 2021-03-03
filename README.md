# TextAnalyzer
## Instructions
To compile the program you should have Visual Studio and .NET Core 3.1 installed. If you open the TextAnalyzer.sln file in Visual Studio you can then click the green start button to compile and run the console app. In the output you will see the 20 most common words in each provided text file.
## Explanation
### Test Driven Development
Each method in the TextAnalyzer class was developed using Test Driven Development. You can check the commits to view the stages and progression of how I wrote this program using TDD. 
### Assumptions
Two important assumptions I made were that each string was to be treated as case insensitive. E.g., `the` was equal to `The`. The second assumption I had to make was the ordering for the final most common output. I implemented a tie breaker in case there were two strings that had the same frequency: alphabetical order. Thus, if two strings were identical in frequency, the tie breaker to consider which ranked first was it's alphabetical order.
### Logic Execution
First I read in the text file using the TextAnalyzer.ReadFile method. With that string I replace all non alphabetical (or space) characters with String.empty. I then split the string using the space characters.
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
