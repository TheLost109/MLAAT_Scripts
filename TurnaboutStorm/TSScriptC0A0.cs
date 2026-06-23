using UnityEngine;
using UnityEngine.Video;

public class TSScriptC0A0 : MonoBehaviour
{
    // 逆转风暴基础脚本
    public TSMainScript tsMainScript;
    // 法庭记录脚本
    public CourtRecordsSystem courtRecordsSystem;
    // 对话文件
    public TextAsset DialogFile;
    // 对话框
    public GameObject dialogBox;
    // 对话框上名称标签
    public GameObject NameTag;
    // 对话文本
    public GameObject SpeechText;
    // Area 0 开幕
    public GameObject IntroVideo;
    // RenderTexture
    public RenderTexture ts_prologue;

    private void Awake()
    {

    }

    private void Start()
    {

    }

    private void Update()
    {

    }

    public void ProceedGame()
    {
        if(tsMainScript.CurrentScript != "TSScriptC0A0")
        {
            // 读取 TextAsset
            tsMainScript.CurrentScript = "TSScriptC0A0";
            tsMainScript.SendMessage("ReadText", DialogFile);
            Debug.Log("已读取对话文本TSScriptC0A0");
        }
        print(tsMainScript.EventID);
        // 开场
        Begin0();
    }

    private void Begin0()
    {
        courtRecordsSystem.GetNewEvidence(0);
        courtRecordsSystem.GetNewEvidence(1);
        courtRecordsSystem.GetNewProfile(0);
        NameTag.SetActive(false);
        tsMainScript.Clickable = false;
        PlayPrologue();
        Invoke("showBox", 7f);
        Invoke("dialog", 7f);
        Invoke("dialog", 12f);
        Invoke("dialog", 17f);
        Invoke("dialog", 22f);
        Invoke("dialog", 27f);
        Invoke("dialog", 31f);
        Invoke("dialog", 34f);
        Invoke("hideBox", 37f);
        Invoke("End0", 45f);
    }

    private void PlayPrologue()
    {
        Invoke("PlayPrologueMusic", 1f);
        ts_prologue.Release();
        IntroVideo.SetActive(true);
        IntroVideo.GetComponent<VideoPlayer>().Play();
    }

    private void PlayPrologueMusic()
    {
        AudioManager.Instance.PlayBGM(BGMID.TS_Prologue);
    }

    private void dialog()
    {
        tsMainScript.DialogIndex = tsMainScript.DialogIndex + 1;
        tsMainScript.ShowDialogRow();
    }

    private void showBox()
    {
        dialogBox.SetActive(true);
    }
    private void hideBox()
    {
        dialogBox.SetActive(false);
    }
    private void End0()
    {
        IntroVideo.SetActive(false);
        tsMainScript.DialogProcessing = false;
        tsMainScript.AreaID = 1;
        tsMainScript.EventID = 0;
        tsMainScript.ProceedGame(tsMainScript.ChapterID, tsMainScript.AreaID, false);
    }

}
