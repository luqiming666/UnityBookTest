using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Global : MonoBehaviour
{
    public static Global instance;

    static Global()
    {
        GameObject go = new GameObject("#Global#");
        DontDestroyOnLoad(go);
        instance = go.AddComponent<Global>();
    }

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("Start");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void DoSomething()
    {
        Debug.Log("DoSomething");
    }
}
