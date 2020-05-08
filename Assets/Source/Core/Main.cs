using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Main : MonoBehaviour
{

    private ModuleManager moduleManager;
    private UpdateModule updateModule;
    private ExtractModule extractModule;
    private ViewModule viewModule;

    void Awake()
    {
        Global.OneAboveAll = this.transform;

        DontDestroyOnLoad(gameObject);  //avoid to be destroy

        moduleManager = new ModuleManager();
        moduleManager.RegisterModule<NetModule>(gameObject.AddComponent<NetModule>());
        moduleManager.RegisterModule<ViewModule>(gameObject.AddComponent<ViewModule>());
        moduleManager.RegisterModule<SceneModule>(gameObject.AddComponent<SceneModule>());
        moduleManager.RegisterModule<LoginModule>(gameObject.AddComponent<LoginModule>());
        moduleManager.RegisterModule<LuaModule>(gameObject.AddComponent<LuaModule>());
        moduleManager.RegisterModule<SceneModule>(gameObject.AddComponent<SceneModule>());
        moduleManager.RegisterModule<UpdateModule>(gameObject.AddComponent<UpdateModule>());
        moduleManager.RegisterModule<ExtractModule>(gameObject.AddComponent<ExtractModule>());
        moduleManager.RegisterModule<ResourcesModule>(gameObject.AddComponent<ResourcesModule>());

        moduleManager.RegisterOver();
    }
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
    }

    void OnDestroy()
    {
        //Debug.LogError("OnDestroy");
    }
}
