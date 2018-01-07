﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameplayManager : SingletonComponent<GameplayManager>
{
    [SerializeField]
    protected GameplayLoader _loader;

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
        _playerController.gameObject.SetActive(false);
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
        _chapter = chapter;
        StartCoroutine(LoadChapter());
    }

    protected IEnumerator LoadChapter()
    {
        LoadingPanel.Instance.Show();
        yield return _loader.LoadChapter(_chapter);
        ResetPlayer();
        LoadingPanel.Instance.Hide();
        _inGame = true;
    }

    private void ResetPlayer()
    {
        _playerController.transform.position = _loader.PlayerInitialLocation.position;
        _playerController.gameObject.SetActive(true);
    }
}