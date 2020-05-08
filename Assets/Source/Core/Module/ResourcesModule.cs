using LuaInterface;
using System;
using UnityEngine;
/// <summary>
/// resources load class
/// </summary>
class ResourcesModule : Module
{
    ILoader loader;

    // Load AssetBundleManifest.

    public override void RegisterOver()
    {
        Initialize();
    }

    public void Initialize()
    {
        if (Define.UseAssetBundle == false && Application.platform == RuntimePlatform.WindowsEditor)
        {
            loader = new EditorLoader();
        }
    }

    /// <summary>
    /// load asset
    /// </summary>
    /// <param name="name">asset name</param>
    public void Load<T>(string path, string name, Action<object[]> loadCallback) where T : UnityEngine.Object
    {

    }

    public void AsyncLoadPrefab(string path, string name, Action<object[]> loadCallback)
    {
        AsyncLoad<GameObject>(path, new string[] { name }, loadCallback);
    }

    public void AsyncLoadPrefab(string path, string[] names, Action<object[]> loadCallback)
    {
        AsyncLoad<GameObject>(path, names, loadCallback);
    }

    public void AsyncLoadPrefab(string path, string[] names, LuaFunction loadCallback)
    {
        AsyncLoad<GameObject>(path, names, loadCallback);
    }

    /// <summary>
    /// load asset async
    /// </summary>
    /// <param name="name">asset name</param>
    public void AsyncLoad<T>(string path, string name, Action<object[]> loadCallback) where T : UnityEngine.Object
    {
        AsyncLoad<T>(path, new string[] { name }, loadCallback);
    }

    public void AsyncLoad<T>(string path, string name, LuaFunction loadCallback = null) where T : UnityEngine.Object
    {
        AsyncLoad<T>(path, new string[] { name }, null, loadCallback);
    }

    /// <summary>
    /// load asset async
    /// </summary>
    public void AsyncLoad<T>(string path, string[] names, Action<object[]> loadCallback = null) where T : UnityEngine.Object
    {
        AsyncLoad<T>(path, names, loadCallback, null);
    }

    public void AsyncLoad<T>(string path, string[] names, LuaFunction loadCallback = null) where T : UnityEngine.Object
    {
        AsyncLoad<T>(path, names, null, loadCallback);
    }

    public void AsyncLoad<T>(string path, string[] names, Action<object[]> unityfunc = null, LuaFunction luafunc = null) where T : UnityEngine.Object
    {
        loader.AsyncLoad<T>(path, names, unityfunc, luafunc);
    }
}

