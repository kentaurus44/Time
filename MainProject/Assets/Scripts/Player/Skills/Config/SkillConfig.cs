using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "SkillConfig", menuName = "Configs/SkillConfig", order = 1)]
public class SkillConfig : ScriptableObject
{
    [SerializeField]
    private SkillSequenceConfig[] _skillSequenceConfigs = new SkillSequenceConfig[0];

    public SkillSequenceConfig[] SkillSequence { get { return _skillSequenceConfigs; } }
}
