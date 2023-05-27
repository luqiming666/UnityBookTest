using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Script_04_16 : MonoBehaviour
{
    // Start is called before the first frame update
    IEnumerator Start()
    {
        //10秒后结束
        yield return new CustomWait(10f, 1f, delegate ()
        {
            //string msg = System.String.Format("每过一秒回调一次: {0}", Time.time);
            //Debug.Log(msg);
            Debug.LogFormat("每过1秒回调1次: {0:F3}", Time.time);
        });
        Debug.Log("10秒结束！");
    }

    public class CustomWait : CustomYieldInstruction
    {
        private UnityAction m_IntervalCallback;
        private float m_StartTime;
        private float m_LastTime;
        private float m_Interval;
        private float m_Duration;

        public override bool keepWaiting
        {
            get
            {
                float currentTime = Time.time;
                if (currentTime - m_StartTime >= m_Duration)
                {
                    return false;
                }
                else if (currentTime - m_LastTime >= m_Interval)
                {
                    m_LastTime = currentTime;
                    m_IntervalCallback();
                }
                return true;
            }
        }

        public CustomWait(float duration, float interval, UnityAction callback)
        {
            //记录开始时间
            m_StartTime = Time.time;
            //记录上一次间隔时间
            m_LastTime = m_StartTime;
            //记录间隔回调的时间
            m_Interval = interval;
            //记录等待总时长
            m_Duration = duration;
            //记录回调函数
            m_IntervalCallback = callback;
        }
    }
}
