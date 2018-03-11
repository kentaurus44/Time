using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : SingletonComponent<PlayerManager>
{
    [SerializeField]
    private PlayerController _playerController;

    private PlayerSkill _playerSkill1 = new PlayerSkill();

    private PlayerSkill _currentRunningSkill;

    public void Load()
    {
        _playerController.Init();
    }

#if UNITY_EDITOR
    protected void Update()
    {
        //OnUpdate();
    }
#endif

    public void OnUpdate()
    {
        if (_currentRunningSkill == null)
        {
            PerformBasicMovment();
            PerformSkill();
        }

        if (_currentRunningSkill != null)
        {
            _currentRunningSkill.OnUpdate();

            if (_currentRunningSkill.IsComplete)
            {
                _currentRunningSkill.ResetSkill();
                _currentRunningSkill = null;
            }
        }

    }

    public void ResetPlayer(Vector3 location)
    {
        _playerController.transform.position = location;

        if (!_playerController.gameObject.activeSelf)
        {
            _playerController.gameObject.SetActive(true);
        }
    }

    private void PerformSkill()
    {
        if (Input.GetKey(KeyCode.M))
        {
            _currentRunningSkill = _playerSkill1;
        }
    }

    private void PerformBasicMovment()
    {
        if (Input.GetKey(KeyCode.D))
        {
            _playerController.Vehicle.Move(1f);
        }
        else if (Input.GetKey(KeyCode.A))
        {
            _playerController.Vehicle.Move(-1f);
        }
        else
        {
            _playerController.Vehicle.Move(0f);
        }

        if (!_playerController.Vehicle.IsInAir && Input.GetKeyDown(KeyCode.Space))
        {
            _playerController.Vehicle.Jump();
        }

        _playerController.OnUpdate();
    }
}
