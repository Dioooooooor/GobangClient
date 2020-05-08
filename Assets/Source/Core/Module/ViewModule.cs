using LuaInterface;
using System;
using UnityEngine;

public class ViewModule : Module
{
    ResourcesModule resourcesModule;

    private Transform viewAboveAll = null;

    public override void RegisterOver()
    {
        viewAboveAll = Global.OneAboveAll.Find("ViewAboveAll");

        resourcesModule = ModuleManager.Instance().FindModule<ResourcesModule>();
    }

    void Start()
    {
    }

    public void ShowUpdate(Action<GameObject> unityFunc)
    {
        string viewName = "UpdateView";
        resourcesModule.AsyncLoadPrefab("Views", viewName, (objs) => {
            if (objs.Length <= 0) return;
            var obj = objs[0] as GameObject;
            if (obj == null) return;
            GameObject view = Instantiate(obj) as GameObject;
            view.name = viewName;
            view.transform.SetParent(viewAboveAll);
            view.transform.localPosition = Vector3.zero;
            view.transform.localScale = Vector3.one;

            unityFunc.Invoke(view);
        });
    }

    /// <summary>
    /// show user interface
    /// </summary>
    /// <param name="name">name</param>
    /// <param name="func">callback</param>
    public void Show(string name, Action<object[]> unityFunc, LuaFunction luaFunc)
    {
        resourcesModule.AsyncLoadPrefab("Views", name, (objs)=> {
            if (objs.Length <= 0) return;
            var obj = objs[0] as GameObject;
            if (obj == null) return;
            GameObject view = Instantiate(obj) as GameObject;
            view.name = name;
            //view.AddComponent<>();
        });
    }
}
