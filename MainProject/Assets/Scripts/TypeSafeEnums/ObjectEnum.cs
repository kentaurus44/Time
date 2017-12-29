public class ObjectEnum : TypeSafeEnum 
{
	public static readonly ObjectEnum EVENT1 = new ObjectEnum("EVENT1");
	public static readonly ObjectEnum EVENT2 = new ObjectEnum("EVENT2");
	public static readonly ObjectEnum EVENT3 = new ObjectEnum("EVENT3");
	public static readonly ObjectEnum EVENT4 = new ObjectEnum("EVENT4");
	public static readonly ObjectEnum EVENT5 = new ObjectEnum("EVENT5");
	public static readonly ObjectEnum EVENT6 = new ObjectEnum("EVENT6");


	protected ObjectEnum(string name) : base(name) { }
}