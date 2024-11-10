//Arrays
//Insert element at the end of array - O(1)
 
int[] intArray = new int[8];
//make a varriable to keep the lenght because .Lenght is based off capacity and does track the actual index
int lenght = 0;  

//This adds data for us 
for (int i = 0; i < 4; i++)
{
    intArray[lenght] = i;
    Console.WriteLine(intArray[lenght]);
    lenght++;
    
}


//Insert at the start of array 
int insertValue = 5;

for(int i = lenght + 1; i >= 1; i--)
{
    intArray[i] = intArray[i-1];
    if (i == 1)
    {
        intArray[0] = insertValue;
        lenght++;
    }
}


//insert in the middle od array 
//find value 3 in the array and insert into newValue 

int newValue = 8;
int foundValue = 3;

for(int i = 0; i < lenght; i++)
{
    if (intArray[i] == foundValue)
    {
        for(int j = lenght; j > i; j--)
        {
            intArray[j] = intArray[j - 1];
        }
        intArray[i] = newValue;
        lenght++;
        break;
    }
}


//delete element from start of array 
for(int i = 0;  i < lenght - 1; i++)
{
    intArray[i] = intArray[i + 1];
}
intArray[lenght] = 0;
lenght--;

//deleteing anywhere from array 
//find number 8 and deleted

int removeElement = 8;

for(int i = 0; i < lenght; i++)
{
    if (intArray[i] == removeElement)
    {
        for(int j = i; j < lenght - 1; j++)
        {
            intArray[j] = intArray[j + 1];
        }
        lenght--;
        break;
    }
}

//linear search --> look for evry element and if case

//result
Console.WriteLine("------------------------------");

for(int i = 0; i < lenght; i++)
{
    Console.WriteLine(intArray[i]);
}

