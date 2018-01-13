using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestManager : MonoBehaviour
{
    [SerializeField]
    protected CharacterControl _character;
    [SerializeField]
    protected CameraConfigs _cameraConfigs;


    protected void Start()
    {
        CustomCamera.CameraManager.Instance.MainCameraController.Init(_cameraConfigs.X, _cameraConfigs.Y);
        _character.OnPlayerMoved += CustomCamera.CameraManager.Instance.MainCameraController.OnPlayerMoved;
    }
}
