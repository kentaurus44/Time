using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public partial class PlayerControlManager
{
	partial void UpdateActions()
	{
		if (Input.GetKey(KeyCode.D))
		{
			CharacterMove(1f);
		}
		else if (Input.GetKey(KeyCode.A))
		{
			CharacterMove(-1f);
		}
		else
		{
			CharacterMove(0f);
		}

		if (Input.GetKeyDown(KeyCode.Space))
		{
			CharacterJump();
		}
	}
}