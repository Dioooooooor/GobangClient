using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExtractModule : Module {
    private UpdateModule updateModule;

    public override void RegisterOver()
    {
        updateModule = ModuleManager.Instance().FindModule<UpdateModule>();
    }


    public void Extract()
    {
        
    }

    /// <summary>
    /// 1. get local package version
    /// 2. get prefs package version
    /// 3. not equal for extract resource
    /// </summary>
    public bool ExtractCheck()
    {
        bool needExtract = true;

        var codeAsset = Resources.Load<TextAsset>("vCode");
        string vCode = codeAsset.text;

        string tmpver = PlayerPrefs.GetString("UpadeVerCode", "0");

        if (vCode.Equals(tmpver))
        {
            // UpdateResource
            //updateModule.CheckUpdate();
        }
        else
        {
            // ExtractResoucre
        }
        return needExtract;

    }

}
