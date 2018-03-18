using UnityEngine;
using UnityEngine.UI;

#if UNITY_ANDROID || UNITY_EDITOR
public partial class PlayerControlManager
{
	[SerializeField]
	private DirectionalInputController _dPad;

	[SerializeField]
	private Button _jump;

	partial void InitMobile()
	{
		_dPad.Init();
		_jump.onClick.AddListener(CharacterJump);
		_dPad.OnAngleSet = OnAngleSet;
	}

	private void OnAngleSet(float angle)
	{
		if (0 < angle && angle < 180)
		{
			CharacterMove(1f);
		}
		else if (180 < angle && angle < 360)
		{
			CharacterMove(-1f);
		}
		else
		{
			CharacterMove(0f);
		}
	}

}
#endif