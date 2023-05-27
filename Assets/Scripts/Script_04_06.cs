using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Script_04_06 : MonoBehaviour
{
    public float updateInterval = 1.0F;
    private float accum = 0;
    private int frames = 0;
    private float timeLeft;
    private string stringFps;

    // Start is called before the first frame update
    void Start()
    {
        Application.targetFrameRate = 60;
        timeLeft = updateInterval;
    }

    // Update is called once per frame
    void Update()
    {
        timeLeft -= Time.deltaTime;
        accum += Time.timeScale / Time.deltaTime;
        ++frames;
        if (timeLeft <= 0.0)
        {
            float fps = accum / frames;
            stringFps = System.String.Format("{0:F2} FPS", fps);
            timeLeft = updateInterval;
            accum = 0.0F;
            frames = 0;
        }
    }

    private void OnGUI()
    {
        GUIStyle guiStyle = GUIStyle.none;
        guiStyle.fontSize = 30;
        guiStyle.normal.textColor = Color.green;
        guiStyle.alignment = TextAnchor.UpperLeft;
        Rect rt = new Rect(200, 0, 100, 100);
        GUI.Label(rt, stringFps, guiStyle);
    }
}
