<Query Kind="Program" />

void Main()
{
	var p = new Person();
	p.Greetings += new Greet(SayHello);
	p.Greetings += new Greet(SayHola);
	p.Greetings += new Greet(SayNiHow);
	p.DeliverGreetings();
	
	var a = new ActionPerson();
	a.Greetings += new Action(SayHello);
	a.Greetings += new Action(SayHola);
	a.Greetings += new Action(SayNiHow);
	
	a.DeliverGreetings();
}

public delegate void Greet();

public void SayHello(){ Console.WriteLine("Hello"); }
public void SayHola() { Console.WriteLine("Hola"); }
public void SayNiHow() { Console.WriteLine("Ni How"); }

public class Person
{
	public Greet Greetings;
	public void DeliverGreetings()
	{
		Greetings.Invoke();
	}
}

public class ActionPerson
{
	public Action Greetings;
	public void DeliverGreetings()
	{
		Greetings();
	}
}