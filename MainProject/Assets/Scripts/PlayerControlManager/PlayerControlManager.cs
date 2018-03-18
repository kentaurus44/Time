using System;

public partial class PlayerControlManager : SingletonComponent<PlayerControlManager>
{
	public delegate void Jump();
	public static event Jump OnJump;

	public delegate void Move(float direction);
	public static event Move OnMove;

	partial void UpdateActions();

#if UNITY_ANDROID || UNITY_EDITOR
	partial void InitMobile();
#endif

	protected void Start()
	{
#if UNITY_ANDROID || UNITY_EDITOR
		InitMobile();
#endif
	}

	private void Update()
	{
		UpdateActions();
	}

	private void CharacterMove(float direction)
	{
		if (OnMove != null)
		{
			OnMove(direction);
		}
	}

	private void CharacterJump()
	{
		if (OnJump != null)
		{
			OnJump();
		}
	}
}