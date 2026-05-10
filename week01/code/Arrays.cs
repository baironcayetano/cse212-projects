public static class Arrays
{
    /// <summary>
    /// This function will produce an array of size 'length' starting with 'number' followed by multiples of 'number'.  For 
    /// example, MultiplesOf(7, 5) will result in: {7, 14, 21, 28, 35}.  Assume that length is a positive
    /// integer greater than 0.
    /// </summary>
    /// <returns>array of doubles that are the multiples of the supplied number</returns>
    public static double[] MultiplesOf(double number, int length)
    {

        /**
        PLAN - SOLUTION
        1- I will define a new Array of type double and of n size because that is what we will get
        2- Then, I will write a for loop to iterate n times
        3- To get each multiple of the number, I will run the next operation in each iteration:
            double multiple = number * i;
           Where i is the index of the iteration.
        4- In each iteration the multiple will be added to the list of multiples 
        **/

        double[] multiples = new double[length];
        for(int i=1; i<=length; i++)
        {
            double multiple = number * i;
            multiples[i-1] = multiple;
        }

        return multiples;
    }

    /// <summary>
    /// Rotate the 'data' to the right by the 'amount'.  For example, if the data is 
    /// List<int>{1, 2, 3, 4, 5, 6, 7, 8, 9} and an amount is 3 then the list after the function runs should be 
    /// List<int>{7, 8, 9, 1, 2, 3, 4, 5, 6}.  The value of amount will be in the range of 1 to data.Count, inclusive.
    ///
    /// Because a list is dynamic, this function will modify the existing data list rather than returning a new list.
    /// </summary>
    public static void RotateListRight(List<int> data, int amount)
    {
        /**
        PLAN - SOLUTION
        For this problem I will implement the next algorithm:
        1 - Validate that the size of the list is > 1;
        2 - I will define a new variable called divisionPoint to calculate the index of the cut point.
            The cut index will be calculated like this: data.Count - amount;
        3 - I will create a new list using the new variable and the data.GetRange method to get the right part of list.
            The code would look something like this:
            List<int> rightPart = data.GetRange(divisionPoint, amount);
        4 - Then, use the data.RemoveRange and the data.InsertRange methods to remove the right part of the list
            and insert the rightPart at the beginning of the List.
            The code would look something like this:
            data.RemoveRange(divisionPoint, amount);
            data.InsertRange(0, rightPart);   
        **/
        if(data.Count <= 1) return;
        int divisionPoint = data.Count - amount;
        List<int> rightPart = data.GetRange(divisionPoint, amount);
        data.RemoveRange(divisionPoint, amount);
        data.InsertRange(0,rightPart);

    }
}
