# Csharp1_Events

In C#, events are a way to implement the publisher-subscriber pattern. They allow objects to communicate with each other by notifying subscribers when a particular action or state change occurs.

Here's a simple example that demonstrates the concept of events in C#:

```csharp
using System;

public class EventPublisher
{
    // Define an event delegate
    public event EventHandler SomethingHappened;

    public void DoSomething()
    {
        Console.WriteLine("Doing something...");
        OnSomethingHappened(EventArgs.Empty);
    }

    protected virtual void OnSomethingHappened(EventArgs e)
    {
        SomethingHappened?.Invoke(this, e);
    }
}

public class EventSubscriber
{
    public void Subscribe(EventPublisher publisher)
    {
        publisher.SomethingHappened += Publisher_SomethingHappened;
    }

    public void Unsubscribe(EventPublisher publisher)
    {
        publisher.SomethingHappened -= Publisher_SomethingHappened;
    }

    private void Publisher_SomethingHappened(object sender, EventArgs e)
    {
        Console.WriteLine("Something happened in the publisher!");
    }
}

public class Program
{
    public static void Main()
    {
        EventPublisher publisher = new EventPublisher();
        EventSubscriber subscriber = new EventSubscriber();
        
        // Subscribe to the event
        subscriber.Subscribe(publisher);

        // Trigger the event
        publisher.DoSomething();

        // Unsubscribe from the event
        subscriber.Unsubscribe(publisher);

        // Trigger the event again (no subscriber will be notified)
        publisher.DoSomething();
    }
}
```

In this example, we have two classes: EventPublisher and EventSubscriber. The EventPublisher class defines an event called SomethingHappened, which is of type EventHandler. The DoSomething method triggers the event by invoking the OnSomethingHappened method.

The EventSubscriber class has Subscribe and Unsubscribe methods, which allow subscribing to and unsubscribing from the event. The Publisher_SomethingHappened method is the event handler that will be executed when the event is triggered.

In the Main method of the Program class, an instance of EventPublisher and EventSubscriber is created. The subscriber subscribes to the publisher's event using the Subscribe method. Then, the DoSomething method is called on the publisher, which triggers the event. The event handler in the subscriber is executed and displays the message. Finally, the subscriber unsubscribes from the event, and triggering the event again does not notify the subscriber.

This is a basic example of how events work in C#. You can extend this concept to implement more complex scenarios and pass additional data through event arguments.
