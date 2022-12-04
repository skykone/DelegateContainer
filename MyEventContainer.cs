
using System;

public class MyEventArgs : EventArgs
{
    public int MyIntArgTypeA { get; set; }
    public string MyStringArgTypeB { get; set; }
}

public class MyEventContainer
{

    public static EventHandler<MyEventArgs>[] MyEventArray = new EventHandler<MyEventArgs>[30];

    public static void TriggerMyEvent(int index, MyEventArgs myEventArgs, object sender = null)
    {
        EventHandler<MyEventArgs> handler = MyEventArray[index];
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
            throw new Exception("the provided argument must be greater than 0 and less than " + max);
        }     
    }
    
    public static void SubscribeMyEvent(int index, EventHandler<MyEventArgs> myEventHandler)
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