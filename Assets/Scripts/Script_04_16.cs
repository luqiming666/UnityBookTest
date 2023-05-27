using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Script_04_16 : MonoBehaviour
{
    // Start is called before the first frame update
    IEnumerator Start()
    {
        //10������
        yield return new CustomWait(10f, 1f, delegate ()
        {
            //string msg = System.String.Format("ÿ��һ��ص�һ��: {0}", Time.time);
            //Debug.Log(msg);
            Debug.LogFormat("ÿ��1��ص�1��: {0:F3}", Time.time);
        });
        Debug.Log("10�������");
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
            //��¼��ʼʱ��
            m_StartTime = Time.time;
            //��¼��һ�μ��ʱ��
            m_LastTime = m_StartTime;
            //��¼����ص���ʱ��
            m_Interval = interval;
            //��¼�ȴ���ʱ��
            m_Duration = duration;
            //��¼�ص�����
            m_IntervalCallback = callback;
        }
    }
}
