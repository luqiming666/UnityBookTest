using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Script_05_09_raycast : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

#if UNITY_EDITOR
    static Vector3[] fourCorners = new Vector3[4];
    private void OnDrawGizmos()
    {
        //需要相应的UI控件都勾上RaycastTarget，【Scene视图】边框上画上蓝色以警示
        foreach (MaskableGraphic g in GameObject.FindObjectsOfType<MaskableGraphic>())
        {
            if (g.raycastTarget)
            {
                RectTransform rect = g.transform as RectTransform;
                rect.GetWorldCorners(fourCorners);
                Gizmos.color = Color.blue;
                for (int i = 0; i < 4; i++)
                {
                    Gizmos.DrawLine(fourCorners[i], fourCorners[(i + 1) % 4]);
                }
            }
        }
    }
#endif
}
