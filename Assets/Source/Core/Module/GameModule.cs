using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameModule : Module {
	ViewModule viewModule = null;

	public override void RegisterOver()
	{
		viewModule = ModuleManager.Instance().FindModule<ViewModule>();
	}

	public void UpdateGame()
	{
		viewModule.ShowUpdate((view) =>
		{
			
		});
	}
}
