//v0.2

using System;

public class MyOtherEventArgs : EventArgs
{
    public float MyOtherFloatArgTypeA { get; set; }
    public int MyOtherIntArgTypeB { get; set; }
}

public class MyEventArgs : EventArgs
{
    public int MyIntArgTypeA { get; set; }
    public string MyStringArgTypeB { get; set; }
}

public class MyEventContainer
{

    public static EventHandler<EventArgs>[] MyEventArray = new EventHandler<EventArgs>[30];

    public static void TriggerMyEvent(int index, EventArgs myEventArgs, object sender = null)
    {
        EventHandler<EventArgs> handler = MyEventArray[index];
        if (handler != null)
        {
            handler(sender, myEventArgs);
        }
        else
        {
            throw new Exception("No subscription at index " + index);
        }
    }

    private static void _CheckMyIndex(int index)
    {
        int max = (MyEventArray.Length - 1);
        if (index < 0 || index > max )
        {
            throw new Exception("the provided argument must be 0 or greater, and less than " + max);
        }     
    }
    
    public static void SubscribeMyEvent(int index, EventHandler<EventArgs> myEventHandler)
    {
        _CheckMyIndex(index);
        MyEventArray[index] = myEventHandler;
    }

    public static void UnSubscribeMyEvent(int index)
    {
        _CheckMyIndex(index);
        MyEventArray[index] = null;
    }
    
 
    
}
