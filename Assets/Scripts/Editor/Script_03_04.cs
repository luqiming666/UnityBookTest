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

    // ������˫��������������Դ���¼�
    public static bool IsOpenForEdit(string assetPath, out string message)
    {
        message = null;
        Debug.LogFormat("opening the asset: {0}", assetPath);
        return true;
    }

    // ��������Դ������ɾ�����¼�
    public static AssetDeleteResult OnWillDeleteAsset(string assetPath, RemoveAssetOptions option)
    {
        Debug.LogFormat("deleting the asset: {0}", assetPath);
        if (assetPath.Contains("NoDelete"))
        {
            Debug.Log("deleting... Not allowed!");
            return AssetDeleteResult.DidDelete; // ������ɾ��
        }
        return AssetDeleteResult.DidNotDelete; // ����ɾ��
    }
}
