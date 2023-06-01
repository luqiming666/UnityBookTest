using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using TMPro;
using System.IO;
using System.Threading;

// 本脚本挂在Canvas上，统一处理Canvas上的各UI事件！
public class Script_05_07_UIHandler : MonoBehaviour
{
    public Button button1;
    public Button btnPlay;
    public TMP_Text text;
    public Image image;
    public TMP_InputField myInput;

    public TMP_Dropdown myOptions;
    //private List<string> _options;

    private void Awake()
    {
        button1.onClick.AddListener(delegate () {
            OnClick(button1.gameObject);
        });
        btnPlay.onClick.AddListener(delegate () {
            OnClick(btnPlay.gameObject);
        });

        UGUIEventListener.Get(text.gameObject).onClick = OnClick;
        UGUIEventListener.Get(image.gameObject).onClick = OnClick;

        // 监听用户输入的字符，如果是a则进行替换
        myInput.onValidateInput += delegate (string input, int charIndex, char addedChar)
        {
            if (addedChar == 'a')
            {
                addedChar = '*';
            }
            return addedChar;
        };
        myInput.onValueChanged.AddListener((string content) => {
            Debug.LogFormat("已经输入{0}个字符", content.Length);
        });

        /*_options = new List<string>();
        _options.Add("Option 1");
        _options.Add("Option 2");
        _options.Add("Option 3");
        myOptions.AddOptions(_options); */
    }

    // Start is called before the first frame update
    void Start()
    {
        myOptions.onValueChanged.AddListener((int index) => DropdownItemChanged(index));
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void DropdownItemChanged(int index)
    {
        // 下拉框项目索引值和内容
        var text = myOptions.options[index].text;
        Debug.LogFormat("下拉框 {0} 选中了，内容为 {1}", index, text);

        // 获取下拉框项目索引值
        Debug.LogFormat("下拉框的当前选中项索引：{0}", myOptions.value);
    }

    void OnClick(GameObject go)
    {
        if (go == button1.gameObject) {
            Debug.Log("按钮--点击事件-已处理！");
            ClickButton1();
        } else if (go == text.gameObject) {
            Debug.Log("文本框--点击事件-已处理！");
        } else if (go == image.gameObject) {
            Debug.Log("邮件图片--点击事件-已处理！");
        } else if (go == btnPlay.gameObject) {
            PlayHEAsset();
        }
    }

    private void PlayHEAsset()
    {
        string filepath = "Assets/Haptics/" + myOptions.options[myOptions.value].text;
        Debug.LogFormat("Playing the asset: {0}", filepath);

        string heContent = File.ReadAllText(filepath);
        Debug.LogFormat("Loading HE asset：{0}", heContent);
    }

    private void ClickButton1()
    {
        // 测试协程，发现：主线程与协程是同一个线程？！
        Debug.LogFormat("进程ID: {0}; 主线程 名字: {1}, ID: {2}", Thread.GetCurrentProcessorId(), Thread.CurrentThread.Name, Thread.CurrentThread.ManagedThreadId);
        StartCoroutine(MyCoroutineJob(2));
    }

    private IEnumerator MyCoroutineJob(float waittime)
    {
        Debug.LogFormat("协程内 >>> 线程名字: {0}, ID: {1}", Thread.CurrentThread.Name, Thread.CurrentThread.ManagedThreadId);
        yield return new WaitForSeconds(waittime);
        Debug.Log("协程执行完毕");
    }
}
