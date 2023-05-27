using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Script_04_05 : MonoBehaviour
{
    private Coroutine m_Coroutine = null;

    IEnumerator CreateCube()
    {
        for (int i = 0; i < 100; i++)
        {
            GameObject.CreatePrimitive(PrimitiveType.Cube).transform.position = Vector3.one * i;
            yield return new WaitForSeconds(1f); // 每秒创建一个Cube
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnGUI()
    {
        if (GUILayout.Button("Start Coroutine"))
        {
            stopCurrentCoroutine();
            m_Coroutine = StartCoroutine(CreateCube());
        }

        if (GUILayout.Button("Stop Coroutine"))
        {
            stopCurrentCoroutine();

            // 测试单例
            Global.instance.DoSomething();
            // 测试定时器
            WaitTimeMgr.WaitTime(2f, delegate {
                Debug.Log("2秒定时器已到~ 通过协程实现的哦~");
            });
        }
    }

    private void stopCurrentCoroutine()
    {
        if (m_Coroutine != null)
        {
            StopCoroutine(m_Coroutine);
            m_Coroutine = null;
        }
    }
}
