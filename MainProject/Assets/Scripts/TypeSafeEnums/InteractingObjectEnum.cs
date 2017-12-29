public class InteractingObjectEnum : TypeSafeEnum 
{
	public static readonly InteractingObjectEnum Object1 = new InteractingObjectEnum("Object1");
	public static readonly InteractingObjectEnum Object2 = new InteractingObjectEnum("Object2");
	public static readonly InteractingObjectEnum Object3 = new InteractingObjectEnum("Object3");


	protected InteractingObjectEnum(string name) : base(name) { }
}