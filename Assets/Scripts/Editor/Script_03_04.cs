using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class Script_03_04 : UnityEditor.AssetModificationProcessor
{
    [InitializeOnLoadMethod]
    static void InitializeOnLoadMethod()
    {
        EditorApplication.projectChanged += delegate ()
        {
            Debug.Log("change");
        };
    }

    // 监听“双击鼠标左键，打开资源”事件
    public static bool IsOpenForEdit(string assetPath, out string message)
    {
        message = null;
        Debug.LogFormat("opening the asset: {0}", assetPath);
        return true;
    }

    // 监听“资源即将被删除”事件
    public static AssetDeleteResult OnWillDeleteAsset(string assetPath, RemoveAssetOptions option)
    {
        Debug.LogFormat("deleting the asset: {0}", assetPath);
        if (assetPath.Contains("NoDelete"))
        {
            Debug.Log("deleting... Not allowed!");
            return AssetDeleteResult.DidDelete; // 不允许删除
        }
        return AssetDeleteResult.DidNotDelete; // 允许删除
    }
}
