using UnityEngine;

enum UpdateType
{
    APP_FULL_UPDATE,
    RESOURCE_UPDATE
}

class UpdateModule : Module
{
    private ViewModule viewModule;
    private SceneModule sceneModule;
    private ExtractModule extractModule;

    private UpdateType updateType = 0;
    private string updateInfo = "";
    private float updatePorgress = 0;

    public override void RegisterOver()
    {
        viewModule = ModuleManager.Instance().FindModule<ViewModule>();
        extractModule = ModuleManager.Instance().FindModule<ExtractModule>();
    }

    /// <summary>
    /// check if need update
    /// 1. get current version
    /// 2. get server version
    /// 3. compare
    /// </summary>
    /// <returns></returns>
    public bool UpdateCheckFull()
    {
        bool needUpdate = false;

        // http for update


        return needUpdate;
    }

    public bool UpdateCheckPartical()
    {
        bool needUpdate = false;

        // http for update


        return needUpdate;
    }

    //public bool UpdateFull()
    //{
        
    //}


    //public bool UpdatePartical()
    //{

    //}

    /// <summary>
    /// Check Resource To Update
    /// 1. load updateview
    /// 2. check extract
    /// 3. check update
    /// </summary>
    //public void Update()
    //{
    //    viewModule.ShowUpdate((updateView) =>
    //    {
    //        if (needUpdate())
    //        {
    //            if (updateType == UpdateType.APP_FULL_UPDATE)
    //            {
    //                UpdateFull();
    //            }
    //            else
    //            {
    //                if (extractModule.CheckExtract())
    //                {

    //                }
    //                else
    //                {

    //                }
    //            }
    //        }
    //        else
    //        {
    //            UpdateOver();
    //        }
    //    });
    //}

    public void UpdateOver()
    {

    }
}
