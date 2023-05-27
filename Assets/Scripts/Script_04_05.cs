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
            yield return new WaitForSeconds(1f); // ÿ�봴��һ��Cube
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

            // ���Ե���
            Global.instance.DoSomething();
            // ���Զ�ʱ��
            WaitTimeMgr.WaitTime(2f, delegate {
                Debug.Log("2�붨ʱ���ѵ�~ ͨ��Э��ʵ�ֵ�Ŷ~");
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
