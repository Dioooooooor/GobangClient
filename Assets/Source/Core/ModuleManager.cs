using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class ModuleManager
{
    private static ModuleManager instance;
    public static ModuleManager Instance()
    {
        if(instance == null)
        {
            instance = new ModuleManager();
        }
        return instance;
    }

    public ModuleManager()
    {
        instance = this;
    }

    public Dictionary<string, IModule> modules = new Dictionary<string, IModule>();

    /// <summary>
    /// 添加模块
    /// </summary>
    /// <param name="ModuleName">模块名</param>
    /// <param name="module">模块</param>
    public void RegisterModule<T>(IModule module)
    {
        string moduleName = typeof(T).ToString();//module.ModuleName();
        if (modules.ContainsKey(moduleName))
        {
            modules[moduleName] = module;
        }
        else
        {
            modules.Add(moduleName, module);
        }
    }

    /// <summary>
    /// 获取模块
    /// </summary>
    /// <param name="moduleName">模块名</param>
    /// <returns>模块</returns>
    public T FindModule<T>() where T : IModule
    {
        String moduleName = typeof(T).ToString();
        IModule module;
        if(modules.TryGetValue(moduleName, out module))
        {
            return (T)module;
        }
        return default(T);
    }

    public void RegisterOver()
    {
        foreach (var module in modules.Values)
        {
            module.RegisterOver();
        }
    }
}

