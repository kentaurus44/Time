using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class PlayerSkill
{
    private PlayerSkillSequence[] _skillSequence = null;
    private bool _overrideControls = false;
    private int _currentIndexSequence = 0;
    private bool _isComplete = false;

    public bool IsComplete { get { return _isComplete; } }
    public bool OverrideControls { get { return _overrideControls; } }

    public void LoadSequence(PlayerSkillSequence[] skillSequence)
    {
        _skillSequence = skillSequence;
    }

    public void OnUpdate()
    {
    }

    public void ResetSkill()
    {
        _currentIndexSequence = 0;
    }
}