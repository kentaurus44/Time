using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestManager : MonoBehaviour
{
	[SerializeField]
	protected CameraConfigs _cameraConfigs;


	protected void Start()
	{
		// CustomCamera.CameraManager.Instance.MainCameraController.Init(DatabaseManager.Instance.CameraConfigs);
	}
}
