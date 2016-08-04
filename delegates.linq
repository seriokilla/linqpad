<Query Kind="Program" />

void Main()
{
	var p = new Person();
	p.Greetings += new Greet(SayHello);
	p.Greetings += new Greet(SayHola);
	p.Greetings += new Greet(SayNiHow);
	p.DeliverGreeting();
}

public delegate void Greet();
public void SayHello(){ Console.WriteLine("Hello"); }
public void SayHola() { Console.WriteLine("Hola"); }
public void SayNiHow() { Console.WriteLine("Ni How"); }

public class Person
{
	public Greet Greetings;
	public void DeliverGreeting()
	{
		Greetings();
	}
}