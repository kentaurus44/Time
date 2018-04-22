using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Core.Pause;

public class GameplayManager : SingletonComponent<GameplayManager>
{
    [SerializeField]
    protected PlayerController _playerController;

    private string _chapter;

    private bool _inGame = false;

    public string Chapter
    {
        get { return _chapter; }
    }

    public override void Init()
    {
        base.Init();
    }

    public void Update()
    {
        if (_inGame && !PauseManager.Instance.IsPaused)
        {
            _playerController.OnUpdate();
        }
    }

    public void Load(string chapter)
    {
        _playerController.Init();
        _chapter = chapter;
    }

    private void ResetPlayer()
    {
        _playerController.gameObject.SetActive(true);
    }
}