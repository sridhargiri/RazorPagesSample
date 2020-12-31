/*
Add one to last element. If sum exceeds nine carry over 1 to previous element. asked in agilysys
1,2,3=1,2,4
1,2,9=1,3,0
9,9,9=1,0,0,0
*/
// C# Program to add 1 to an array 
// representing a number 
using System; 

public class AddOne { 
	
	// function to add one and print the array 
	void sum(int []arr, int n){ 
		
	int i = n; 

	// if array element is less than 9, then 
	// simply add 1 to this. 
	if(arr[i] < 9) 
	{ 
	arr[i] = arr[i] + 1; 
	return; 
	} 

	// if array element is greater than 9, 
	// replace it with 0 and decrement i 
	arr[i] = 0; 
	i--; 

	// recursive function 
	sum(arr, i); 
} 

	// driver code 
	static public void Main () 
	{ 
	AddOne obj =new AddOne(); 
		
	// number of elements in array 
	int n = 4; 

	// array elements, index of array 
	// should be 1 based, hence, 0 is 
	// added here at arr[0] 
	int []arr = {0, 1, 9, 3, 9}; 

	// function calling 
	obj.sum(arr, n); 
	
	// If 1 was appended at head 
	// of array then, print it 
	if(arr[0] > 0) 
		Console.Write(arr[0] + ", "); 
	int i; 
	// print the array elements 
	// after adding one 
	for( i = 1; i <= n; i++) 
	{ 
		Console.Write(arr[i]); 
			
		if(i < n) 
			Console.Write(", "); 
	} 

	} 
} 
