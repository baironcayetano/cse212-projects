using Microsoft.VisualStudio.TestTools.UnitTesting;

// TODO Problem 2 - Write and run test cases and fix the code to match requirements.

[TestClass]
public class PriorityQueueTests
{
    
    [TestMethod]
    // Scenario: Will the enqueue method add a new element containing both data and priority to the back of the queue? 
    // We are going to add this item ["Sleep at 8pm",5] to test this function
    // Expected Result: 
    // A string with "Sleep at 8pm"
    // Defect(s) Found: 
    //None
    public void TestPriorityQueue_1()
    {
        var priorityQueue = new PriorityQueue();
        string text = "Sleep at 8pm";
        priorityQueue.Enqueue(text,5);
        Assert.AreEqual(text,priorityQueue.Dequeue());
    }

    [TestMethod]
    // Scenario: If we use the Dequeue method will this function remove the items by their priority?
    // There are going to be 3 items with different priority values to test this function.
    // The items are going to be: ["Sleep at 8pm",3],["Wake up at 5am",5],["Play videogames",1].
    // These items are going to be enqueued in that same order. 
    // Expected Result: 
    // We expect to dequeue this queue by their priority. Being the result: 
    // 1) "Wake up at 5am" 2) "Sleep at 8pm" 3)"Play videogames"
    // Defect(s) Found: 
    // The dequeue method was returning the element with the highest priority but not deleting it from the queue.
    // I fixed it using _queue.RemoveAt method.
    public void TestPriorityQueue_2()
    {
        var priorityQueue = new PriorityQueue();
        string[] items = {"Sleep at 8pm","Wake up at 5am","Play videogames"};
        priorityQueue.Enqueue(items[0],3);
        priorityQueue.Enqueue(items[1],5);
        priorityQueue.Enqueue(items[2],1);

        //items in the expected order
        string[] expectedItems = {"Wake up at 5am","Sleep at 8pm","Play videogames"};
        for(int i = 0; i < 2; i++)
        {
            string item = priorityQueue.Dequeue();
            Console.WriteLine($"Got: {item}, expected: {expectedItems[i]}");
            Assert.AreEqual(expectedItems[i],item);
        }

    }
    
    [TestMethod]
    // Scenario: If there are more than 1 item with the highest priority, will the item be removed using FIFO? 
    // We are going to use queues with the same priority to check this
    // the queues are going to be these ones next: ["Sleep at 8pm",5],["Wake up at 5am", 5].
    // Expected Result: They should be dequeued in this order: ["Wake up at 5am", 5], ["Sleep at 8pm",5]
    // Defect(s) Found: 
    //None
    public void TestPriorityQueue_3()
    {
        var priorityQueue = new PriorityQueue();
        string[] items = {"Sleep at 8pm", "Wake up at 5am"};
        priorityQueue.Enqueue(items[0],5);
        priorityQueue.Enqueue(items[1], 5);

        for(int i = 0; i > 1; i++)
        {
            Assert.AreEqual(items[i],priorityQueue.Dequeue());
        }
    }

        [TestMethod]
    // Scenario: If the queue is empty, shall be thrown an error exception?
    // We are going to call the Dequeue function with an empty priorityQueue to test it.
    // We are also going to use a try catch statement to prevent this program to end if the error exception is thrown.
    // Expected Result: An InvalidOperationException with a message of "The queue is empty."
    // Defect(s) Found: 
    //None
    public void TestPriorityQueue_4()
    {
        var priorityQueue = new PriorityQueue();
        try
        {
            priorityQueue.Dequeue();   
            Assert.Fail("Exception should have been thrown");
        }
        catch (InvalidOperationException e)
        {
            Assert.AreEqual("The queue is empty.", e.Message);  
        }
        catch (Exception e)
        {
            Assert.Fail(
                 string.Format("Unexpected exception of type {0} caught: {1}",
                                e.GetType(), e.Message)
            );
        }
    }

}