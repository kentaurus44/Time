using UnityEngine;
using UnityEngine.UI;

public partial class PlayerControlManager
{
	[SerializeField]
	private DirectionalInputController _dPad;

	[SerializeField]
	private Button _jump;

	private float _direction = 0f;
	private float _targetDirection = -1f;

	partial void InitMobile()
	{
		_dPad.Init();
		_jump.onClick.AddListener(CharacterJump);
	}

	partial void UpdateMobile()
	{
		if (_dPad.IsMoving && _dPad.IsFingerDown)
		{
			if (0 < _dPad.Angle && _dPad.Angle < 180)
			{
				_targetDirection = 1f;
			}
			else if (180 < _dPad.Angle && _dPad.Angle < 360)
			{
				_targetDirection = - 1f;
			}
		}
		else
		{
			_targetDirection = 0f;
		}

		if (_targetDirection != _direction)
		{
			CharacterMove(_targetDirection);
			_direction = _targetDirection;
		}
	}
}