using System;
using UnityEngine;
#if UNITY_EDITOR
using UnityEditor;
#endif

public partial class PlayerControlManager : SingletonComponent<PlayerControlManager>
{
	public delegate void Jump();
	public static event Jump OnJump;

	public delegate void Move(float direction);
	public static event Move OnMove;

	partial void UpdatePC();

	partial void InitMobile();
	partial void UpdateMobile();

	private enum Controls
	{
		Mobile,
		PC
	}

	private static Controls _controls = Controls.Mobile;

	protected void Start()
	{
		InitMobile();
	}

	private void Update()
	{
#if UNITY_EDITOR
		switch (_controls)
		{
			case Controls.Mobile:
				UpdateMobile();
				break;
			case Controls.PC:
				UpdatePC();
				break;
			default:
				break;
		}
#elif UNITY_ANDROID || UNITY_IOS
		UpdateMobile();
#endif
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

	[MenuItem("Time/Controls/Enable Mobile")]
	private static void SetControlsMobile()
	{
		DisableAll();
		_controls = Controls.Mobile;
		Menu.SetChecked("Time/Controls/Enable Mobile", true);
	}

	[MenuItem("Time/Controls/Enable PC")]
	private static void SetControlsPC()
	{
		DisableAll();
		_controls = Controls.PC;
		Menu.SetChecked("Time/Controls/Enable PC", true);
	}

	private static void DisableAll()
	{
		Menu.SetChecked("Time/Controls/Enable Mobile", false);
		Menu.SetChecked("Time/Controls/Enable PC", false);
	}
}