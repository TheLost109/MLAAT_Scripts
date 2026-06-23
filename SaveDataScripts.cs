using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;

public class SaveDataScripts : MonoBehaviour
{
    public TSMainScript tsMainScript;

    private void Start()
    {

    }

    private void Update()
    {

    }

    [Serializable]
    public class SaveData
    {
        public DateTime dateTime;
        public int ChapterID;
        public int AreaID;
        public int EventID;
        public int Health;
        public List<Records> RecordsEvidence = new List<Records>();
        public List<Records> RecordsProfile = new List<Records>();
        public Queue<Backlog> backlogList = new Queue<Backlog>();
        public List<int> completedTalk = new List<int>();
        public List<int> completedInvest = new List<int>();
    }

    public SaveData CreateSaveData(int gameType)
    {
        SaveData saveData = new SaveData();
        saveData.dateTime = DateTime.Now;
        if (gameType == 0)
        {
            saveData.ChapterID = tsMainScript.ChapterID;
            saveData.AreaID = tsMainScript.AreaID;
            saveData.EventID = tsMainScript.EventID;
            saveData.Health = tsMainScript.Health;
            saveData.RecordsEvidence = tsMainScript.RecordsEvidence;
            saveData.RecordsProfile = tsMainScript.RecordsProfile;
            saveData.backlogList = tsMainScript.backlogList;
            saveData.completedTalk = tsMainScript.completedTalk;
            saveData.completedInvest = tsMainScript.completedInvest;
        }
        return saveData;
    }

    public void SaveBySerialization(int gameType, int slotId)
    {
        string savePath = Application.persistentDataPath + "/Save";
        // 根据slotId和gameType定义FileName
        string fileName = "unknowndata";
        if (gameType == 0)
        {
            fileName = "Save_TS_" + slotId;
        }
        else if (gameType == 1)
        {
            fileName = "Save_MLI_" + slotId;
        }
        else if (gameType == 2)
        {
            fileName = "Save_EoJ_" + slotId;
        }
        // 检查文件夹是否存在
        if (!Directory.Exists(savePath))
        {
            // 创建文件夹
            Directory.CreateDirectory(savePath);
            Debug.Log("新文件夹创建成功: " + savePath);
        }
        else
        {
            Debug.Log("文件夹已存在");
        }
        SaveData saveData = CreateSaveData(gameType);
        //获取当前的游戏数据存在Save对象里
        BinaryFormatter bf = new BinaryFormatter();
        //创建一个二进制形式
        FileStream fs = File.Create(savePath + "/" + fileName);
        //这里指使用持久路径创建一个文件流并将其保存在systemdata里（具体在哪就不打了，反正创建了）
        //由于持久路径在Windows系统是隐藏的，所以无法找到systemdata本身
        //如果想看到，可以改成dataPath(就像下文json的代码里一样)
        //文件后缀可以随便改，甚至是自定义的（比如我这里用了systemdata）
        //将Save对象转化为字节
        bf.Serialize(fs, saveData);
        //把文件流关了
        fs.Close();
    }
    public void LoadBySerialization(int gameType, int slotId)
    {
        string SavePath = Application.persistentDataPath + "/Save";
        // 根据slotId和gameType定义FileName
        string fileName = null;
        if (gameType == 0)
        {
            fileName = "Save_TS_" + slotId;
        }
        else if (gameType == 1)
        {
            fileName = "Save_MLI_" + slotId;
        }
        else if (gameType == 2)
        {
            fileName = "Save_EoJ_" + slotId;
        }
        if (File.Exists(SavePath + "/" + fileName))
        //判断文件是否创建
        {
            //反系列化的过程
            //创建一个二进制格式化程序
            BinaryFormatter bf = new BinaryFormatter();
            //打开一个文件流
            FileStream fs = File.Open(SavePath + "/" + fileName, FileMode.Open);
            //调用格式化程序的反序列化方法，将文件流转换为一个SystemData对象
            SaveData saveData = (SaveData)bf.Deserialize(fs);
            if (gameType == 0)
            {
                tsMainScript.ChapterID = saveData.ChapterID;
                tsMainScript.AreaID = saveData.AreaID;
                tsMainScript.EventID = saveData.EventID;
                tsMainScript.Health = saveData.Health;
                tsMainScript.RecordsEvidence = saveData.RecordsEvidence;
                tsMainScript.RecordsProfile = saveData.RecordsProfile;
                tsMainScript.backlogList = saveData.backlogList;
                tsMainScript.completedTalk = saveData.completedTalk;
                tsMainScript.completedInvest = saveData.completedInvest;
            }
            //关闭文件流
            fs.Close();
        }
        else
        {
            Debug.LogError("读档出现错误。");
        }
    }

    public void DeleteSaveData(string fileName)
    {
        string savePath = Application.persistentDataPath + "/Save";
        if (File.Exists(savePath + "/" + fileName))
        {
            File.Delete(savePath + "/" + fileName);
        }
        else
        {
            Debug.LogError("名为" + fileName + "的存档删除失败！");
        }
    }

}
