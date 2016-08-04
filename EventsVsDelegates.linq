<Query Kind="Program">
  <Reference>&lt;RuntimeDirectory&gt;\mscorlib.dll</Reference>
  <Reference>&lt;RuntimeDirectory&gt;\System.dll</Reference>
</Query>

void Main()
{
	var ActionAlarm = new DelegateAlarmSignalBase();
	
	new Clock("one", ActionAlarm);
	new Clock("two", ActionAlarm);
	ActionAlarm.SoundAlarm();
	ActionAlarm.Alarm = null;
	ActionAlarm.SoundAlarm();
	
	var EventAlarm = new EventAlarmSignal();
	new Clock("three", EventAlarm);
	new Clock("four", EventAlarm);
	EventAlarm.SoundAlarm();
	
	//EventAlarm.Alarm(); // won't compile with Events
	//EventAlarm.Alarm = null;  // won't compile with Events
	
	EventAlarm.SoundAlarm();
	
}

public class DelegateAlarmSignalBase
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

public class EventAlarmSignal : DelegateAlarmSignalBase
{
	public new event Action Alarm;
}

public class Clock
{
	public string _Name;
	public Clock(string name, DelegateAlarmSignalBase a)
	{
		_Name = name;
		a.Alarm += AlarmMessage;
	}
	
	public void AlarmMessage()
	{
		Console.WriteLine("Alarm from: " + _Name);
	}
}

// Define other methods and classes here
