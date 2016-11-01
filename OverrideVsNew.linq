<Query Kind="Program" />

void Main()
{
	Base b = new Derived();
	b.Foo().Dump(); // > BASE
	b.Bar().Dump(); // > DERIVED
}

// Define other methods and classes here
class Base
{
	public string Foo() { return "BASE"; }
	public virtual string Bar() { return "BASE"; }
}

class Derived : Base
{
	public new string Foo() { return "DERIVED"; }
	public override string Bar() { return "DERIVED"; }
}