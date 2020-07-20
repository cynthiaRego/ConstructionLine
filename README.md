## ConstructionLine
I have attempted to solve the code challenge to the best of my understanding of the problem statement.

I have however found an issue with the validity of the tests, in that how they check the filtered results.

I can confirm my understanding below using the test data from SearchEngineTests.cs

### Case 1:
Filter: Size=Small, Color=Red
Expected Result: 
Shirt:Red-Small
ColorCount: Red(1),Black(0),Blue(0)	, Yellow(0), White(0)			 
SizeCount: Small(1), Medium(0), Large(0)
Actual Result:
Matches Expected (All Good!)


### Case 2:
Filter: Size=[Small,Medium] Color=Red
Expected Result: 
Shirt:Red-Small
ColorCount: Red(1), Black(1), Blue(0), Yellow(0), White(0)			 
SizeCount: Small(1), Medium(0), Large(0)
Actual Result:
All match except : ColorCount: Red(1), Black(0), Blue(0), Yellow(0), White(0)
(Don't see why Black should be 1 but Medium 0, when the filter is for Red only)


### Case 3:
Filter: Size=[Small] Color=[Red,Blue]
Expected Result: 
Shirt:Red-Small
ColorCount: Red(1), Black(0), Blue(0), Yellow(0), White(0)			 
SizeCount: Small(1), Medium(0), Large(1)
Actual Result:
All match except : SizeCount: Small(1), Medium(0), Large(0)
(Don't see why Large should be 1 but Blue 0, when the filter is for Small only)


I have taken the liberty to ammend the test case logic slightly (took in the filtered shirt list rather that All shirts)
The results seem to align (as per my understanding), and the performance stats are around ~70ms on an average.

Hope this helps understand my approach.
