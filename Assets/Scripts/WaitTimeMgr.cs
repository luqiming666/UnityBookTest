using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class WaitTimeMgr
{
    private static TaskBehaviour m_Task;

    static WaitTimeMgr()
    {
        GameObject go = new GameObject("#WaitTimeMgr#");
        GameObject.DontDestroyOnLoad(go);
        m_Task = go.AddComponent<TaskBehaviour>();
    }

    static public Coroutine WaitTime(float time, UnityAction callback)
    {
        return m_Task.StartCoroutine(MyCoroutine(time, callback));
    }

    static public void CancelWait(ref Coroutine coroutine)
    {
        if (coroutine != null)
        {
            m_Task.StopCoroutine(coroutine);
            coroutine = null;
        }
    }

    static private IEnumerator MyCoroutine(float time, UnityAction callback)
    {
        yield return new WaitForSeconds(time);
        if (callback != null)
        {
            callback();
        }
    }

    //ÄÚ²¿Àà
    class TaskBehaviour : MonoBehaviour { }
}
