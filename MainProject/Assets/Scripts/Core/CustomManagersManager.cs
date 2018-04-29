﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Core.Flow;

public class CustomManagersManager : ManagersManager
{
    public override IEnumerator Load()
    {
        yield return base.Load();

        GameManager.Instance.Load(
            DatabaseManager.Instance.JsonDatabase.Events.ToString(),
            DatabaseManager.Instance.JsonDatabase.Dialogs.ToString(),
            DatabaseManager.Instance.JsonDatabase.Chapters.ToString());
    }

	protected override void OnSingletonLoaded(string id)
	{
		base.OnSingletonLoaded(id);

		if (id == typeof(FlowManager).Name)
		{
			FlowManager.Instance.TriggerAction(FlowDatabase.kOpen, "MainPanel");
		}
	}
}
