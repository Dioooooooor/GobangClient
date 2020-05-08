using LuaInterface;
using System;

interface ILoader
{
    void Init();

    /// <summary>
    /// load prefab sync
    /// </summary>
    void Load<T>(string bundleName, string[] names,Action<object[]> unityFunc = null, LuaFunction luaFunc = null) where T : UnityEngine.Object;

    /// <summary>
    /// load prefab async
    /// </summary>
    void AsyncLoad<T>(string bundleName, string[] names, Action<object[]> unityFunc = null, LuaFunction luaFunc = null) where T : UnityEngine.Object;

}

public class LoaderInfo
{
    public string assetNames;
    public Action<object[]> unityFunc;
    public LuaFunction luaFunc;
    public LoaderInfo(string assetNames, Action<object[]> unityFunc, LuaFunction luaFunc)
    {
        this.assetNames = assetNames;
        this.unityFunc = unityFunc;
        this.luaFunc = luaFunc;
    }
}
