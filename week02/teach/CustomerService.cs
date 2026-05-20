using System.Diagnostics;

/// <summary>
/// Maintain a Customer Service Queue.  Allows new customers to be 
/// added and allows customers to be serviced.
/// </summary>
public class CustomerService {
    public static void Run() {
        // Example code to see what's in the customer service queue:
         var cs = new CustomerService(10);
         Console.WriteLine(cs);

        // Test Cases

        // Test 1
        Console.WriteLine("=================");
        Console.WriteLine("Test 1");
        // Scenario:
        // Is the max size value 10 by default when CustomService is created with an invalid parameter (a number smaller than or equal to zero)?
        cs = new CustomerService(0);

        // Expected Result: 10 -> no error
        Trace.Assert(cs._maxSize == 10, "The max size should be 10 for any value equal to 0");
        cs = new CustomerService(-1);
        Trace.Assert(cs._maxSize == 10, "The max size should be 10 for any value smaller than 0"); 
        // Defect(s) Found: 
        //None
        Console.WriteLine("Passed!");

        Console.WriteLine("=================");

        // Test 2
        Console.WriteLine("Test 2");
        // Scenario: Does the AddNewCustomer method enqueue a new customer correctly?
        cs = new CustomerService(2);
        cs.AddNewCustomer();
        // Expected Result:
        //Should return the customer that has been added 
        cs.ServeCustomer();

        // Defect(s) Found:
        //The ServeCustomer method deletes the customer and then tries to get it causing an argument out of range exception 
        Console.WriteLine("Passed!");
        Console.WriteLine("=================");

        //Test 3
        Console.WriteLine("Test 3");
        //Scenario:
        //Are the clients going to be enqueued and dequeued using FIFO?
        cs = new CustomerService(10);
        cs.AddNewCustomer();
        cs.AddNewCustomer();
        cs.AddNewCustomer();

        //Expected Result:
        //It shoud use FIFO and display each served customer
        cs.ServeCustomer();
        cs.ServeCustomer();
        cs.ServeCustomer();

        //Defect(s) found:
        //None
        Console.WriteLine("Passed!");
        Console.WriteLine("=================");

        //Test 4
        Console.WriteLine("Test 4");
        //Scenario:
        //If I try to add a new element to the queue when the queue is full, is it gonna add it?
        cs = new CustomerService(1);
        cs.AddNewCustomer();
        cs.AddNewCustomer();
        
        //Expected Result:
        //An error message.

        Trace.Assert(cs._queue.Count <= cs._maxSize, "The Queue should not add a new element when the queue when it's already full");

        //Defect(s) Found:
        //The validation in the Enqueue method had to be _queue.Count == _maxSize and not something different.
        Console.WriteLine("Passed!");

        Console.WriteLine("=================");
        //Test 5
        Console.WriteLine("Test 5");
        //Scenario:
        //If the queue is empty when trying to serve a customer, then is an error message going to be displayed?
        
        cs = new CustomerService(1);
        cs.ServeCustomer();
        
        //Expected Result:
        //An error message
        
        //Defect(s) Found:
        //There was not a validation like _queue.Count == 0 inside the ServeCustomer method causing an error;
        Console.WriteLine("Passed!");

    }

    private readonly List<Customer> _queue = new();
    private readonly int _maxSize;

    public CustomerService(int maxSize) {
        if (maxSize <= 0)
            _maxSize = 10;
        else
            _maxSize = maxSize;
    }

    /// <summary>
    /// Defines a Customer record for the service queue.
    /// This is an inner class.  Its real name is CustomerService.Customer
    /// </summary>
    private class Customer {
        public Customer(string name, string accountId, string problem) {
            Name = name;
            AccountId = accountId;
            Problem = problem;
        }

        private string Name { get; }
        private string AccountId { get; }
        private string Problem { get; }

        public override string ToString() {
            return $"{Name} ({AccountId})  : {Problem}";
        }
    }

    /// <summary>
    /// Prompt the user for the customer and problem information.  Put the 
    /// new record into the queue.
    /// </summary>
    private void AddNewCustomer() {
        // Verify there is room in the service queue
        if (_queue.Count == _maxSize) {;
            Console.WriteLine("Maximum Number of Customers in Queue.");
            return;
        }

        Console.Write("Customer Name: ");
        var name = Console.ReadLine()!.Trim();
        Console.Write("Account Id: ");
        var accountId = Console.ReadLine()!.Trim();
        Console.Write("Problem: ");
        var problem = Console.ReadLine()!.Trim();

        // Create the customer object and add it to the queue
        var customer = new Customer(name, accountId, problem);
        _queue.Add(customer);
    }

    /// <summary>
    /// Dequeue the next customer and display the information.
    /// </summary>
    private void ServeCustomer() {
        if(_queue.Count == 0)
        {
            Console.WriteLine("There are no customers to serve");
            return;
        }
        var customer = _queue[0];
        Console.WriteLine(customer);
        _queue.RemoveAt(0);
    }

    /// <summary>
    /// Support the WriteLine function to provide a string representation of the
    /// customer service queue object. This is useful for debugging. If you have a 
    /// CustomerService object called cs, then you run Console.WriteLine(cs) to
    /// see the contents.
    /// </summary>
    /// <returns>A string representation of the queue</returns>
    public override string ToString() {
        return $"[size={_queue.Count} max_size={_maxSize} => " + string.Join(", ", _queue) + "]";
    }
}