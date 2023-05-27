using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
//using UnityEngine.UI;

public class Script_05_06_image_click : MonoBehaviour, IPointerClickHandler, IPointerEnterHandler
{
    // Start is called before the first frame update
    void Start()
    {
        //RawImage ri = gameObject as RawImage;
    }

    // Update is called once per frame
    void Update()
    {        
    }

    // 监听图片点击事件
    public void OnPointerClick(PointerEventData eventData)
    {
        // gameObject是当前脚本绑定的宿主Game Object
        Debug.LogFormat("{0} is clicked.", gameObject.name);
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        Debug.LogFormat("Entering {0}'s region.", gameObject.name);
    }
}
