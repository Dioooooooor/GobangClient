using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Module : MonoBehaviour, IModule
{
	//protected ModuleManager moduleManager;
	//public Module(ModuleManager moduleManager)
	//{
	//	this.moduleManager = moduleManager;
	//}

	//public Module Register(ModuleManager moduleManager)
	//{
	//	this.moduleManager = moduleManager;
	//	return this;
	//}
	public virtual void RegisterOver()
	{
	}

	public string ModuleName()
	{
		return this.GetType().ToString();
	}
}
