using LuaInterface;
using System;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

class EditorLoader : MonoBehaviour, ILoader
{
    string prefabPath = "";
    public void Init()
    {
        //resPath = 
    }

    public void Load<T>(string bundleName, string[] names, Action<object[]> unityFunc = null, LuaFunction luaFunc = null) where T : UnityEngine.Object
    {
        List<object> datas = new List<object>();
        //AssetDatabase.LoadAssetAtPath()
        foreach (var name in names)
        {
            string assetPath = "Prefabs/" + bundleName + "/" + name + "/" + name;
            //assetPath = "Prefabs/Views/UpdateView";
            var data = Resources.Load<T>(assetPath);
            datas.Add(data);

        }
        if (unityFunc != null)
        {
            unityFunc(datas.ToArray());
        }
        if (luaFunc != null)
        {
            luaFunc.Call(datas.ToArray());
            luaFunc.Dispose();
        }
    }

    public void AsyncLoad<T>(string bundleName, string[] names, Action<object[]> unityFunc = null, LuaFunction luaFunc = null) where T : UnityEngine.Object
    {
        Load<T>(bundleName, names, unityFunc, luaFunc);
    }
}
