using System;

public class DynamicArrayExample
{
    // establishing array variables
    private int[] array;
    private int count;
    private int size;

    // creating array
    public DynamicArrayExample()
    {
        array = new int[1];
        count = 0;
        size = 1;
    }

    // function for adding an element to the end of an array
    public void add(int data)
    {
        if (count == size)
        {
            doubleSize();
        }

        array[count] = data;
        count++;
    }

    // creating method previously mentioned in the add function
    public void doubleSize()
    {
        /* creating a varaible array to use for the bigger
         array as arrays are not edited and instead a new
         array has to be created with the new properties
         and elements */
        int[] temp = null;

        // if the array is maxed out with all elements filled
        if (count == size)
        {

            /* doubling size of array with a for loop
             estalishing how big the size of the new
             array will be exactly.*/
            temp = new int[size * 2];
            {
                for (int i = 0; i < size; i++)
                {
                    // adding array items to the temp array
                    temp[i] = array[i];
                }
            }
        }
        // now we update the array to the new perameters we set with temp
        array = temp;
        
        // keeping the size updated along with the array for the future
        size = size * 2;
    }
    // function to decrease size and save memory
    public void decreaseSize()
    {
        // again starting a temporary array because we cannot modify original
        int[]temp = null;
        if (count > 0)
        {
            /* count differes from size where size
            is the entire size of the array where
            as count is the elements inside */
            temp = new int[count];
            for (int i = 0; i < count; i++)
            {
                /* copying value right off the bat as we
                already have the size we desire located in
                how big the count is */
                temp[i] = array[i];
            }

            // keeping size consistent with the method
            size = count;
            // and we have the new array
            array = temp;
        }
    }
    // add a element at specific index
    public void addAt(int index, int date)
    {
        // cant add it if there ain't room
        if (count == size)
        {
            doubleSize();
        }

        /* because we want it at a specific index and not
        just the end we have to move the other elements in
        the array and ideally don't mess with the structure. 
        So we start at the end and work our way down to the
        choosen index. Along the way any elements in the array
        are moved one to the right. And there is enough space
        because if it was full than the double size method
        would initialize in the if statement. */
        for (int i = count - 1; i >= index; i--)
        {
            array[i + 1] = array[i];
        }

        // inserting data
        array[index] = data;
        // keeping count consistent
        count++;
    }

    // remove last element
    public void remove()
    {
        if (count > 0)
        {
            array[count - 1] = 0;
            count--;
        }
    }

    // similar to addAt but we are removing
    public void removeAt(int index)
    {
        if (count > 0)
        {
            for (int i = index; i < count - 1; i++)
            {
                array[i] = array[i + 1];
            }
            array[count - 1] = 0;
            count--;
        }
    }

}
