using UnityEngine;
using DG.Tweening;

public class TSScriptC0A1 : MonoBehaviour
{
    // 逆转风暴 - 基础脚本
    public TSMainScript tsMainScript;
    // 逆转风暴 - 贴图管理器
    public TSSpritesManager tsSpritesManager;
    // 对话文件
    public TextAsset DialogFile;
    // 主摄像机
    public GameObject MainCamera;

    private void Awake()
    {

    }

    private void Start()
    {

    }

    private void Update()
    {

    }

    public void ProceedGame(int EventID, bool IsContinue)
    {
        if (tsMainScript.CurrentScript != "TSScriptC0A1")
        {
            // 读取 TextAsset
            tsMainScript.CurrentScript = "TSScriptC0A1";
            tsMainScript.SendMessage("ReadText", DialogFile);
            Debug.Log("已读取对话文本TSScriptC0A1");
        }
        print(tsMainScript.EventID);
        if (EventID == 0)
        {
            Debug.Log("执行Event 0");
            tsMainScript.DialogIndex = 1;
            tsSpritesManager.NameTag.SetActive(false);
            tsSpritesManager.dialogBox.SetActive(true);
            tsSpritesManager.SpeechText.SetActive(false);
            tsSpritesManager.NewAreaText.SetActive(true);
            tsMainScript.Clickable = true;
            ProceedText(IsContinue, false);
        }
        // Area 1 成步堂来电
        else if (EventID == 1)
        {
            Debug.Log("执行Event 1");
            tsSpritesManager.OfficeBG.GetComponent<SpriteRenderer>().DOFade(0, 0);
            tsSpritesManager.BackgroundUpdate("WrightOffice");
            tsSpritesManager.OfficeBG.GetComponent<SpriteRenderer>().DOFade(1, 3f);
            tsMainScript.Clickable = false;
            tsSpritesManager.NewAreaText.SetActive(false);
            tsSpritesManager.dialogBox.SetActive(false);
            tsSpritesManager.SpeechText.SetActive(true);
            AudioManager.Instance.PlayBGM(BGMID.Ringtone_PW);
            Invoke("PickUp", 8f);
            Invoke("ItemPop", 9f);
            Invoke("WrightAnswer", 10f);
        }
        // Area 1 成步堂接电话
        else if (EventID == 2)
        {
            Debug.Log("执行Event 2");
            tsSpritesManager.BackgroundUpdate("WrightOffice");
            tsSpritesManager.ItemHolder.SetActive(true);
            tsSpritesManager.WrightPhoneSpr.SetActive(true);
            tsSpritesManager.dialogBox.SetActive(true);
            tsMainScript.DialogIndex = 2;
            ProceedText(IsContinue, false);
            tsMainScript.Clickable = true;
        }
        else if (EventID == 3)
        {
            Debug.Log("执行Event 3");
            tsSpritesManager.BackgroundUpdate("WrightOffice");
            tsSpritesManager.ItemHolder.SetActive(true);
            tsSpritesManager.WrightPhoneSpr.SetActive(true);
            tsSpritesManager.dialogBox.SetActive(true);
            tsMainScript.DialogIndex = 3;
            ProceedText(IsContinue, false);
            tsMainScript.Clickable = true;
        }
        else if (EventID == 4)
        {
            Debug.Log("执行Event 4");
            tsSpritesManager.BackgroundUpdate("WrightOffice");
            tsSpritesManager.ItemHolder.SetActive(true);
            tsSpritesManager.WrightPhoneSpr.SetActive(true);
            tsSpritesManager.dialogBox.SetActive(true);
            tsMainScript.DialogIndex = 4;
            ProceedText(IsContinue, false);
            tsMainScript.Clickable = true;
        }
        else if (EventID == 5)
        {
            Debug.Log("执行Event 5");
            tsSpritesManager.BackgroundUpdate("WrightOffice");
            tsSpritesManager.dialogBox.SetActive(true);
            tsMainScript.DialogIndex = 5;
            if (!IsContinue)
            {
                tsMainScript.Clickable = false;
                Invoke("Event5Delay", 1f);
                Invoke("Event5Delay2", 2f);
            }
            else if(IsContinue)
            {
                ProceedText(true, false);
                tsMainScript.Clickable = true;
            }
        }
        else if (EventID == 6)
        {
            Debug.Log("执行Event 6");
            tsSpritesManager.BackgroundUpdate("WrightOffice");
            tsSpritesManager.dialogBox.SetActive(true);
            tsMainScript.DialogIndex = 6;
            ProceedText(IsContinue, false);
            tsMainScript.Clickable = true;
        }
        else if (EventID == 7)
        {
            Debug.Log("执行Event 7");
            tsSpritesManager.BackgroundUpdate("WrightOffice");
            tsSpritesManager.dialogBox.SetActive(true);
            tsMainScript.DialogIndex = 7;
            ProceedText(IsContinue, false);
            tsMainScript.Clickable = true;
        }
        else if (EventID == 8)
        {
            Debug.Log("执行Event 8");
            tsSpritesManager.BackgroundUpdate("WrightOffice");
            tsSpritesManager.dialogBox.SetActive(true);
            tsMainScript.DialogIndex = 8;
            ProceedText(IsContinue, false);
            tsMainScript.Clickable = true;
        }
        else if (EventID == 9)
        {
            Debug.Log("执行Event 9");
            tsSpritesManager.BackgroundUpdate("WrightOffice");
            tsSpritesManager.dialogBox.SetActive(true);
            tsMainScript.DialogIndex = 9;
            ProceedText(IsContinue, false);
            tsMainScript.Clickable = true;
        }
        else if (EventID == 10)
        {
            Debug.Log("执行Event 10");
            tsSpritesManager.BackgroundUpdate("WrightOffice");
            tsSpritesManager.dialogBox.SetActive(true);
            tsMainScript.DialogIndex = 10;
            ProceedText(IsContinue, false);
            tsMainScript.Clickable = true;
        }
        else if (EventID == 11)
        {
            Debug.Log("执行Event 11");
            tsSpritesManager.dialogBox.SetActive(true);
            tsSpritesManager.BackgroundUpdate("WrightOffice");
            tsMainScript.DialogIndex = 11;
            if (IsContinue)
            {
                ProceedText(true, false);
                tsMainScript.Clickable = true;
                AudioManager.Instance.PlayBGM(BGMID.Suspense);
            }
            else if (!IsContinue)
            {
                tsMainScript.Clickable = false;
                ProceedText(false, false);
                Invoke("Event11Delay", 1f);
                Invoke("Event11Delay2", 2f);
            }
        }
        else if (EventID == 12)
        {
            Debug.Log("执行Event 12");
            tsSpritesManager.dialogBox.SetActive(true);
            tsSpritesManager.BackgroundUpdate("WrightOffice");
            tsMainScript.DialogIndex = 12;
            if (IsContinue)
            {
                ProceedText(true, false);
                tsMainScript.Clickable = true;
                AudioManager.Instance.PlayBGM(BGMID.Suspense);
            }
            else if (!IsContinue)
            {
                tsMainScript.Clickable = false;
                ProceedText(false, false);
                Invoke("Event12Delay", 1f);
                Invoke("Event12Delay2", 1.2f);
                Invoke("Event12Delay3", 2.2f);
            }
        }
        else if (EventID == 13)
        {
            Debug.Log("执行Event 13");
            tsSpritesManager.dialogBox.SetActive(true);
            tsSpritesManager.BackgroundUpdate("WrightOffice");
            tsMainScript.DialogIndex = 13;
            tsMainScript.Clickable = true;
            if (IsContinue)
            {
                ProceedText(true, false);
                AudioManager.Instance.PlayBGM(BGMID.Suspense);
            }
            else if (!IsContinue)
            {
                ProceedText(false, false);
            }
        }
        else if (EventID == 14)
        {
            Debug.Log("执行Event 14");
            tsSpritesManager.dialogBox.SetActive(true);
            tsSpritesManager.BackgroundUpdate("WrightOffice");
            tsMainScript.DialogIndex = 14;
            tsMainScript.Clickable = true;
            if (IsContinue)
            {
                ProceedText(true, false);
                AudioManager.Instance.PlayBGM(BGMID.Suspense);
            }
            else if (!IsContinue)
            {
                ProceedText(false, false);
            }
        }
        else if (EventID == 15)
        {
            Debug.Log("执行Event 15");
            tsSpritesManager.dialogBox.SetActive(true);
            tsSpritesManager.BackgroundUpdate("WrightOffice");
            tsMainScript.DialogIndex = 15;
            tsMainScript.Clickable = true;
            Invoke("Event15Delay", .1f);
            if (IsContinue)
            {
                ProceedText(true, false);
                AudioManager.Instance.PlayBGM(BGMID.Suspense);
            }
            else if (!IsContinue)
            {
                ProceedText(false, false);
            }
        }
        else if (EventID == 16)
        {
            Debug.Log("执行Event 16");
            tsSpritesManager.dialogBox.SetActive(false);
            tsSpritesManager.BackgroundUpdate("WrightOffice");
            tsMainScript.Clickable = false;
            Invoke("Event16Delay", 3f);
            Invoke("Event16Delay2", 8f);
        }
    }

    public void ProceedText(bool IsContinue, bool SpriteTalk)
    {
        if (!IsContinue)
        {
            tsMainScript.ShowDialogRow();
            if (SpriteTalk) tsMainScript.IsCharacterTalking = true;
        }
        else
        {
            tsMainScript.UpdateText();
        }
    }
    private void PickUp()
    {
        AudioManager.Instance.StopBGM(false);
        AudioManager.Instance.PlaySE(SEID.pick_up_phone);
    }

    private void ItemPop()
    {
        tsSpritesManager.ItemHolder.SetActive(true);
        tsSpritesManager.WrightPhoneSpr.SetActive(true);
        AudioManager.Instance.PlaySE(SEID.item_pop);
    }
    private void WrightAnswer()
    {
        tsSpritesManager.NameTag.SetActive(true);
        tsSpritesManager.dialogBox.SetActive(true);
        tsMainScript.EventID = 2;
        ProceedGame(tsMainScript.EventID, false);
    }

    public void Event5Delay()
    {
        tsSpritesManager.ItemHolder.GetComponent<RectTransform>().DOScale(new Vector3(0, 0, 0), .5f);
        AudioManager.Instance.PlaySE(SEID.se_com_008);
    }
    public void Event5Delay2()
    {
        tsSpritesManager.ItemHolder.SetActive(false);
        tsSpritesManager.WrightPhoneSpr.SetActive(false);
        ProceedText(false, false);
        tsMainScript.Clickable = true;
    }
    public void Event11Delay()
    {
        MainCamera.GetComponent<Camera>().DOShakePosition(.3f, new Vector3(2, 2, 0)).SetLoops(1, LoopType.Yoyo);
        AudioManager.Instance.PlaySE(SEID.explode);
        AudioManager.Instance.PlayBGM(BGMID.Suspense);
    }
    public void Event11Delay2()
    {
        tsMainScript.Clickable = true;
    }
    public void Event12Delay()
    {
        tsSpritesManager.WhiteScreen.SetActive(true);
        Invoke("FlashbangOut", .2f);
        AudioManager.Instance.PlaySE(SEID.explode);
    }
    public void Event12Delay2()
    {
        MainCamera.GetComponent<Camera>().DOShakePosition(.3f, new Vector3(2, 2, 0)).SetLoops(1, LoopType.Yoyo);
        tsMainScript.Clickable = true;
    }
    public void Event12Delay3()
    {
        tsMainScript.Clickable = true;
    }
    public void FlashbangOut()
    {
        tsSpritesManager.WhiteScreen.SetActive(false);
    }
    public void Event15Delay()
    {
        tsSpritesManager.OfficeBG.GetComponent<SpriteRenderer>().DOFade(0, 1f).SetLoops(-1, LoopType.Yoyo);
    }
    public void Event16Delay()
    {
        tsSpritesManager.ClearAllBG();
        AudioManager.Instance.PlaySE(SEID.se_script_082);
        AudioManager.Instance.StopBGM(true);
    }
    public void Event16Delay2()
    {
        tsMainScript.AreaID = 2;
        tsMainScript.EventID = 0;
        tsMainScript.ProceedGame(tsMainScript.ChapterID, tsMainScript.AreaID, false);
    }
}
