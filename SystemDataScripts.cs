using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;

public class SystemDataScripts : MonoBehaviour
{
    private string savePath;
    // 单例模式
    public static SystemDataScripts Instance;
    private void Awake()
    {
        savePath = Application.persistentDataPath + "/Save";
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
        }
        else
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }

    private void Start()
    {
        LoadBySerialization();
    }

    [Serializable]
    public class SystemData
    {
        public string dataVersion;
        public bool FirstRun;
        public float BGMVol;
        public float SEVol;
        public string Language;
        public string VoiceLang;
        public int MSAA;
        public bool VSyncEnabled;
        public int MaxFPS;
        //public int loadSlotId;
    }

    public SystemData CreateSysData()
    {
        SystemData systemData = new SystemData();
        systemData.dataVersion = SettingsScript.Instance.dataVersion;
        systemData.FirstRun = SettingsScript.Instance.FirstRun;
        systemData.BGMVol = SettingsScript.Instance.BGMVol;
        systemData.SEVol = SettingsScript.Instance.SEVol;
        systemData.Language = SettingsScript.Instance.Language;
        systemData.VoiceLang = SettingsScript.Instance.VoiceLang;
        systemData.MSAA = SettingsScript.Instance.MSAA;
        systemData.VSyncEnabled = SettingsScript.Instance.VSyncEnabled;
        systemData.MaxFPS = SettingsScript.Instance.MaxFPS;
        //systemData.loadSlotId = SettingsScript.Instance.loadSlotId;
        return systemData;
    }

    public void SaveBySerialization()
    {
        // 检查文件夹是否存在
        if (!Directory.Exists(savePath))
        {
            // 创建文件夹
            Directory.CreateDirectory(savePath);
            Debug.Log("新文件夹创建成功: " + savePath);
        }
        else
        {
            Debug.Log("Save文件夹已存在");
        }
        SystemData systemData = CreateSysData();
        //获取当前的游戏数据存在Save对象里
        BinaryFormatter bf = new BinaryFormatter();
        //创建一个二进制形式
        FileStream fs = File.Create(savePath + "/systemdata");
        //这里指使用持久路径创建一个文件流并将其保存在systemdata里（具体在哪就不打了，反正创建了）
        //由于持久路径在Windows系统是隐藏的，所以无法找到systemdata本身
        //如果想看到，可以改成dataPath(就像下文json的代码里一样)
        //文件后缀可以随便改，甚至是自定义的（比如我这里用了systemdata）
        bf.Serialize(fs, systemData);
        //将Save对象转化为字节
        fs.Close();
        //把文件流关了
    }
    public void LoadBySerialization()
    {
        if (File.Exists(savePath + "/systemdata"))
        //判断文件是否创建
        {
            //反系列化的过程
            //创建一个二进制格式化程序
            BinaryFormatter bf = new BinaryFormatter();
            //打开一个文件流
            FileStream fs = File.Open(savePath + "/systemdata", FileMode.Open);
            //调用格式化程序的反序列化方法，将文件流转换为一个SystemData对象
            SystemData systemData = (SystemData)bf.Deserialize(fs);
            try
            {

                if (systemData.dataVersion == SettingsScript.Instance.dataVersion)
                {
                    SettingsScript.Instance.FirstRun = systemData.FirstRun;
                    SettingsScript.Instance.BGMVol = systemData.BGMVol;
                    SettingsScript.Instance.SEVol = systemData.SEVol;
                    SettingsScript.Instance.Language = systemData.Language;
                    SettingsScript.Instance.VoiceLang = systemData.VoiceLang;
                    SettingsScript.Instance.MSAA = systemData.MSAA;
                    SettingsScript.Instance.VSyncEnabled = systemData.VSyncEnabled;
                    SettingsScript.Instance.MaxFPS = systemData.MaxFPS;
                    //SettingsScript.Instance.loadSlotId = systemData.loadSlotId;
                    //关闭文件流
                    fs.Close();
                }
                else
                {
                    //关闭文件流
                    fs.Close();
                    Debug.LogError("systemdata版本与当前游戏版本不匹配！正在删除所有存档并创建新systemdata。");
                    Directory.Delete(savePath, true);
                    Directory.CreateDirectory(savePath);
                    SaveBySerialization();
                }
            }
            catch (Exception ex)
            {
                //关闭文件流
                fs.Close();
                Debug.LogError("错误："+ ex );
                Debug.LogError("systemdata版本过老！正在创建新systemdata。");
                SaveBySerialization();
            }
        }
        else
        {
            Debug.LogError("未检测到systemdata，正在创建。");
            SaveBySerialization();
        }
    }

}
