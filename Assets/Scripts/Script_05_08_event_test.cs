using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

// 想让Event携带额外参数时，须自定义Event类
public class MyEvent : UnityEvent<int, string> { }

public class Script_05_08_event_test : MonoBehaviour
{
    public UnityAction<int, string> action1;  // Action实际为回调函数指针，可以不用定义成员变量
    public UnityAction<int, string> action2;
    public MyEvent myEvent = new MyEvent();

    public void MyEventHandler(int a, string b)
    {
        Debug.Log(string.Format("MyEvent received. Action1: Do something... {0}, {1}", a, b));
    }

    // 同一个Event可以挂多个action
    public void MyEventHandler2(int a, string b)
    {
        Debug.Log(string.Format("MyEvent received. Action2: Do something... {0}, {1}", a, b));
    }

    // Start is called before the first frame update
    void Start()
    {
        myEvent.AddListener(MyEventHandler);
        myEvent.AddListener(MyEventHandler2);
    }

    private void OnDestroy()
    {
        myEvent.RemoveAllListeners();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            Debug.Log("A键按下了！");
            myEvent.Invoke(1, "keyboard A");
        }
        if (Input.GetKeyUp(KeyCode.B))
        {
            Debug.Log("B键按下后松开了！");
            myEvent.Invoke(2, "keyboard B");
        }
    }
}
