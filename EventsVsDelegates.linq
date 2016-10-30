<Query Kind="Program">
  <Reference>&lt;RuntimeDirectory&gt;\mscorlib.dll</Reference>
  <Reference>&lt;RuntimeDirectory&gt;\System.dll</Reference>
  <Reference>&lt;RuntimeDirectory&gt;\System.Activities.dll</Reference>
  <Reference>&lt;RuntimeDirectory&gt;\System.Xaml.dll</Reference>
  <Reference>&lt;RuntimeDirectory&gt;\System.Runtime.Serialization.dll</Reference>
  <Reference>&lt;RuntimeDirectory&gt;\System.ServiceModel.Internals.dll</Reference>
  <Reference>&lt;RuntimeDirectory&gt;\System.Runtime.DurableInstancing.dll</Reference>
  <Reference>&lt;RuntimeDirectory&gt;\Microsoft.VisualBasic.Activities.Compiler.dll</Reference>
  <Reference>&lt;RuntimeDirectory&gt;\Microsoft.VisualBasic.dll</Reference>
  <Namespace>System.Activities.Expressions</Namespace>
</Query>

/*
Delegates - function pointer that holds a reference to a method. 
An Event declaration adds a layer of abstraction and protection on the delegate instance. 
This protection prevents clients of the delegate from resetting the delegate and its 
invocation list and only allows adding or removing targets from the invocation list.
*/

void Main()
{
	var DelegateAlarm = new DelegateAlarmSignal();
	
	new Clock("DelegateAlarm one", DelegateAlarm);
	new Clock("DelegateAlarm two", DelegateAlarm);
	DelegateAlarm.SoundAlarm();
	DelegateAlarm.Alarm = null;
	DelegateAlarm.SoundAlarm();  // nothing happens because we nulled out the Alarm
	//DelegateAlarm.Alarm(); // Object Ref Error
	
	var EventAlarm = new EventAlarmSignal();
	new Clock("EventAlarm three", EventAlarm);
	new Clock("EventAlarm four", EventAlarm);
	EventAlarm.SoundAlarm();
	// The event can only appear on the left hand side of += or -=
	//EventAlarm.Alarm = null;  // won't compile with Events
	//EventAlarm.Alarm(); 
}

public class DelegateAlarmSignal
{
	public Action Alarm;
	public void SoundAlarm()
	{
		if (Alarm == null)
			Console.WriteLine("Cant Sound Alarm.  Alarm is null.");
		else
			Alarm();
	}
}

public class EventAlarmSignal : DelegateAlarmSignal
{
	public new event Action Alarm; // override the base class Action into an Event
}

public class Clock
{
	public string _Name;
	public Clock(string name, DelegateAlarmSignal a)
	{
		_Name = name;
		a.Alarm += AlarmMessage;
	}
	
	public void AlarmMessage()
	{
		Console.WriteLine("Alarm from: " + _Name);
	}
}