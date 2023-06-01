using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using TMPro;
using System.IO;
using System.Threading;

// ���ű�����Canvas�ϣ�ͳһ����Canvas�ϵĸ�UI�¼���
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

        // �����û�������ַ��������a������滻
        myInput.onValidateInput += delegate (string input, int charIndex, char addedChar)
        {
            if (addedChar == 'a')
            {
                addedChar = '*';
            }
            return addedChar;
        };
        myInput.onValueChanged.AddListener((string content) => {
            Debug.LogFormat("�Ѿ�����{0}���ַ�", content.Length);
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
        // ��������Ŀ����ֵ������
        var text = myOptions.options[index].text;
        Debug.LogFormat("������ {0} ѡ���ˣ�����Ϊ {1}", index, text);

        // ��ȡ��������Ŀ����ֵ
        Debug.LogFormat("������ĵ�ǰѡ����������{0}", myOptions.value);
    }

    void OnClick(GameObject go)
    {
        if (go == button1.gameObject) {
            Debug.Log("��ť--����¼�-�Ѵ���");
            ClickButton1();
        } else if (go == text.gameObject) {
            Debug.Log("�ı���--����¼�-�Ѵ���");
        } else if (go == image.gameObject) {
            Debug.Log("�ʼ�ͼƬ--����¼�-�Ѵ���");
        } else if (go == btnPlay.gameObject) {
            PlayHEAsset();
        }
    }

    private void PlayHEAsset()
    {
        string filepath = "Assets/Haptics/" + myOptions.options[myOptions.value].text;
        Debug.LogFormat("Playing the asset: {0}", filepath);

        string heContent = File.ReadAllText(filepath);
        Debug.LogFormat("Loading HE asset��{0}", heContent);
    }

    private void ClickButton1()
    {
        // ����Э�̣����֣����߳���Э����ͬһ���̣߳���
        Debug.LogFormat("����ID: {0}; ���߳� ����: {1}, ID: {2}", Thread.GetCurrentProcessorId(), Thread.CurrentThread.Name, Thread.CurrentThread.ManagedThreadId);
        StartCoroutine(MyCoroutineJob(2));
    }

    private IEnumerator MyCoroutineJob(float waittime)
    {
        Debug.LogFormat("Э���� >>> �߳�����: {0}, ID: {1}", Thread.CurrentThread.Name, Thread.CurrentThread.ManagedThreadId);
        yield return new WaitForSeconds(waittime);
        Debug.Log("Э��ִ�����");
    }
}
