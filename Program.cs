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

