using DG.Tweening;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TSScriptC0A4 : MonoBehaviour
{
    // 主摄像机
    public Camera MainCamera;
    // 逆转风暴基础脚本
    public TSMainScript tsMainScript;
    // 逆转风暴 - 贴图管理器
    public TSSpritesManager tsSpritesManager;
    // 对话文件
    public TextAsset DialogFile;
    public CourtRecordsSystem courtRecordsSystem;
    public DetectiveSystem detectiveSystem;
    // 移动Thumbnails
    public Sprite moveThumb0;

    void Start()
    {

    }

    void Update()
    {

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

    #region 事件
    public void ProceedGame(int EventID, bool IsContinue)
    {
        if (tsMainScript.CurrentScript != "TSScriptC0A4")
        {
            // 读取 TextAsset
            tsMainScript.CurrentScript = "TSScriptC0A4";
            tsMainScript.ReadText(DialogFile);
            Debug.Log("已读取对话文本TSScriptC0A4");
        }
        print(tsMainScript.EventID);
        // Area 4 看守所
        if (EventID == 0)
        {
            tsMainScript.DialogIndex = 1;
            tsSpritesManager.NameTag.SetActive(false);
            tsSpritesManager.dialogBox.SetActive(true);
            tsSpritesManager.SpeechText.SetActive(false);
            tsSpritesManager.NewAreaText.SetActive(true);
            if (!IsContinue)
            {
                tsMainScript.Clickable = false;
                tsSpritesManager.detentionCenter.GetComponent<SpriteRenderer>().DOFade(0, 0f);
                Invoke("Event0Delay", .1f);
                Invoke("Event0Delay2", 1f);
            }
            else
            {
                tsMainScript.Clickable = true;
                tsSpritesManager.BackgroundUpdate("DetentionCenter");
                ProceedText(true, false);
            }
        }
        else if (EventID == 1)
        {
            tsMainScript.DialogIndex = 2;
            tsSpritesManager.BackgroundUpdate("DetentionCenter");
            if (!IsContinue)
            {
                tsMainScript.Clickable = false;
                tsSpritesManager.dialogBox.SetActive(false);
                tsSpritesManager.NameTag.SetActive(true);
                tsSpritesManager.SpeechText.SetActive(true);
                tsSpritesManager.NewAreaText.SetActive(false);
                Invoke("Event1Delay", 2f);
            }
            else
            {
                tsMainScript.Clickable = true;
                tsSpritesManager.dialogBox.SetActive(true);
                ProceedText(true, false);
            }
        }
        else if (EventID == 2)
        {
            tsMainScript.DialogIndex = 3;
            tsSpritesManager.BackgroundUpdate("DetentionCenter");
            if (!IsContinue)
            {
                tsMainScript.Clickable = false;
                tsSpritesManager.dialogBox.SetActive(false);
                tsSpritesManager.rainbowStandAngry.DOFade(0, 0);
                Invoke("Event2Delay", 1.5f);
                Invoke("Event2Delay2", 4f);
                Invoke("Event2Delay3", 5f);
            }
            else
            {
                tsMainScript.Clickable = true;
                tsSpritesManager.dialogBox.SetActive(true);
                tsSpritesManager.rainbowStandAngry.gameObject.SetActive(true);
                ProceedText(true, false);
            }
        }
        else if (EventID == 3)
        {
            tsMainScript.Clickable = true;
            tsMainScript.DialogIndex = 4;
            tsSpritesManager.dialogBox.SetActive(true);
            tsSpritesManager.BackgroundUpdate("DetentionCenter");
            tsSpritesManager.rainbowStandAngry.gameObject.SetActive(true);
            ProceedText(IsContinue, false);
        }
        else if (EventID == 4)
        {
            tsMainScript.Clickable = true;
            tsMainScript.DialogIndex = 5;
            tsSpritesManager.dialogBox.SetActive(true);
            tsSpritesManager.BackgroundUpdate("DetentionCenter");
            tsSpritesManager.rainbowStandNormal.gameObject.SetActive(true);
            if (!IsContinue) tsSpritesManager.rainbowStandAngry.gameObject.SetActive(false);
            ProceedText(IsContinue, false);
        }
        else if (EventID == 5)
        {
            tsMainScript.Clickable = true;
            tsMainScript.DialogIndex = 6;
            tsSpritesManager.dialogBox.SetActive(true);
            tsSpritesManager.BackgroundUpdate("DetentionCenter");
            tsSpritesManager.rainbowStandNormal.gameObject.SetActive(true);
            ProceedText(IsContinue, false);
        }
        else if (EventID == 6)
        {
            tsMainScript.Clickable = true;
            tsMainScript.DialogIndex = 7;
            tsSpritesManager.dialogBox.SetActive(true);
            tsSpritesManager.BackgroundUpdate("DetentionCenter");
            if (!IsContinue) tsSpritesManager.rainbowStandNormal.gameObject.SetActive(false);
            tsSpritesManager.rainbowStandSmile.gameObject.SetActive(true);
            ProceedText(IsContinue, false);
        }
        else if (EventID == 7)
        {
            tsMainScript.DialogIndex = 8;
            tsSpritesManager.BackgroundUpdate("DetentionCenter");
            if (!IsContinue)
            {
                tsMainScript.Clickable = false;
                AudioManager.Instance.PlaySE(SEID.se_script_012);
                Invoke("Event7Delay", 1.6f);
            }
            else
            {
                tsMainScript.Clickable = true;
                tsSpritesManager.dialogBox.SetActive(true);
                tsSpritesManager.rainbowStandNormal.gameObject.SetActive(true);
                ProceedText(true, false);
            }
        }
        else if (EventID == 8)
        {
            tsMainScript.Clickable = true;
            tsMainScript.DialogIndex = 9;
            tsSpritesManager.dialogBox.SetActive(true);
            tsSpritesManager.BackgroundUpdate("DetentionCenter");
            tsSpritesManager.rainbowStandSmile.gameObject.SetActive(true);
            if (!IsContinue)
            {
                tsSpritesManager.rainbowStandNormal.gameObject.SetActive(false);
                Invoke("Event8Delay", .5f);
            }
            else
            {
                AudioManager.Instance.PlayBGM(BGMID.LOVELOVEGUILTY);
            }
            ProceedText(IsContinue, false);
        }
        else if (EventID == 9)
        {
            tsMainScript.Clickable = true;
            tsMainScript.DialogIndex = 10;
            tsSpritesManager.dialogBox.SetActive(true);
            tsSpritesManager.BackgroundUpdate("DetentionCenter");
            tsSpritesManager.rainbowStandSmile.gameObject.SetActive(true);
            AudioManager.Instance.PlayBGM(BGMID.LOVELOVEGUILTY);
            ProceedText(IsContinue, false);
        }
        else if (EventID == 10)
        {
            tsMainScript.DialogIndex = 11;
            tsSpritesManager.BackgroundUpdate("DetentionCenter");
            AudioManager.Instance.PlayBGM(BGMID.LOVELOVEGUILTY);
            if (!IsContinue)
            {
                tsMainScript.Clickable = false;
                tsSpritesManager.dialogBox.SetActive(false);
                AudioManager.Instance.PlaySE(SEID.se_script_007);
                tsSpritesManager.WhiteScreen.GetComponent<Image>().DOFade(0, 0f);
                tsSpritesManager.WhiteScreen.SetActive(true);
                tsSpritesManager.WhiteScreen.GetComponent<Image>().DOFade(1, .25f);
                Invoke("Event10Delay", .25f);
                Invoke("Event10Delay2", 1.5f);
                Invoke("Event10Delay3", 1.9f);
            }
            else
            {
                tsMainScript.Clickable = true;
                tsSpritesManager.dialogBox.SetActive(true);
                tsSpritesManager.rainbowStandNormal.gameObject.SetActive(true);
                ProceedText(true, false);
            }
        }
        else if (EventID == 11)
        {
            tsMainScript.Clickable = true;
            tsMainScript.DialogIndex = 12;
            tsSpritesManager.dialogBox.SetActive(true);
            tsSpritesManager.BackgroundUpdate("DetentionCenter");
            if (!IsContinue) tsSpritesManager.rainbowStandNormal.gameObject.SetActive(false);
            tsSpritesManager.rainbowStandImpatient.gameObject.SetActive(true);
            AudioManager.Instance.PlayBGM(BGMID.LOVELOVEGUILTY);
            ProceedText(IsContinue, false);
        }
        else if (EventID == 12)
        {
            tsMainScript.Clickable = true;
            tsMainScript.DialogIndex = 13;
            tsSpritesManager.dialogBox.SetActive(true);
            tsSpritesManager.BackgroundUpdate("DetentionCenter");
            if (!IsContinue) tsSpritesManager.rainbowStandImpatient.gameObject.SetActive(false);
            tsSpritesManager.rainbowStandNormal.gameObject.SetActive(true);
            AudioManager.Instance.PlayBGM(BGMID.LOVELOVEGUILTY);
            ProceedText(IsContinue, false);
        }
        else if (EventID == 13)
        {
            tsMainScript.Clickable = true;
            tsMainScript.DialogIndex = 14;
            tsSpritesManager.dialogBox.SetActive(true);
            tsSpritesManager.BackgroundUpdate("DetentionCenter");
            tsSpritesManager.rainbowStandNormal.gameObject.SetActive(true);
            AudioManager.Instance.PlayBGM(BGMID.LOVELOVEGUILTY);
            ProceedText(IsContinue, false);
            tsMainScript.EventID = 9130;
        }
        else if (EventID == 9130)
        {
            tsMainScript.EventID = 13;
            tsMainScript.ProceedGame(tsMainScript.ChapterID, tsMainScript.AreaID, true);
        }
        else if (EventID == 9131)
        {
            tsMainScript.EventID = 99990;
            tsMainScript.ProceedGame(tsMainScript.ChapterID, tsMainScript.AreaID, false);
        }
        else if (EventID == 99990)
        {
            tsMainScript.Clickable = true;
            tsMainScript.ClickOverlay.SetActive(false);
            tsSpritesManager.dialogBox.SetActive(false);
            tsSpritesManager.BackgroundUpdate("DetentionCenter");
            if (!tsMainScript.completedTalk.Contains(5) && IsContinue)
            {
                tsSpritesManager.rainbowStandNormal.gameObject.SetActive(true);
            }
            if (tsMainScript.completedTalk.Contains(5))
            {
                AudioManager.Instance.StopBGM(true);
            }
            else if (tsMainScript.completedTalk.Contains(3) && !tsMainScript.completedTalk.Contains(4))
            {
                AudioManager.Instance.PlayBGM(BGMID.DetentionCenter_2001);
            }
            else
            {
                AudioManager.Instance.PlayBGM(BGMID.LOVELOVEGUILTY);
            }
            // Detective System
            tsMainScript.investEnabled = false;
            tsMainScript.moveEnabled = false;
            tsMainScript.talkEnabled = false;
            tsMainScript.presentEnabled = false;
            if (tsMainScript.completedTalk.Contains(5))
            {
                tsMainScript.moveEnabled = true;
                detectiveSystem.moveList = InitializeMoves();
                detectiveSystem.actionMove.GetComponent<Button>().onClick.RemoveAllListeners();
                detectiveSystem.actionMove.GetComponent<Button>().onClick.AddListener(OpenDetectiveMove);
            }
            else
            {
                tsMainScript.talkEnabled = true;
                detectiveSystem.talkList = InitializeTalks();
                detectiveSystem.actionTalk.GetComponent<Button>().onClick.RemoveAllListeners();
                detectiveSystem.actionTalk.GetComponent<Button>().onClick.AddListener(OpenDetectiveTalk);
                if (tsMainScript.completedTalk.Contains(3))
                {
                    tsMainScript.presentEnabled = true;
                    detectiveSystem.presentList = InitializePresents();
                    detectiveSystem.actionPresent.GetComponent<Button>().onClick.RemoveAllListeners();
                    detectiveSystem.actionPresent.GetComponent<Button>().onClick.AddListener(OpenDetectivePresent);
                }
            }
            tsMainScript.ShowActions();
        }
        else if (EventID == 14)
        {
            tsMainScript.Clickable = true;
            tsMainScript.DialogIndex = 15;
            tsSpritesManager.dialogBox.SetActive(true);
            tsSpritesManager.BackgroundUpdate("DetentionCenter");
            AudioManager.Instance.PlayBGM(BGMID.LOVELOVEGUILTY);
            if (!IsContinue)
            {
                tsSpritesManager.ClrAllCharaSpr("Rainbow");
                tsMainScript.btnOpenCourtRecords.gameObject.SetActive(true);
                tsMainScript.btnShowBacklog.gameObject.SetActive(true);
                tsMainScript.btnOptions.gameObject.SetActive(true);
                tsMainScript.ClickOverlay.SetActive(true);
            }
            tsSpritesManager.rainbowStandNormal.gameObject.SetActive(true);
            ProceedText(IsContinue, false);
        }
        else if (EventID == 15)
        {
            tsMainScript.Clickable = true;
            tsMainScript.DialogIndex = 16;
            tsSpritesManager.dialogBox.SetActive(true);
            tsSpritesManager.BackgroundUpdate("DetentionCenter");
            if (!IsContinue) tsSpritesManager.rainbowStandNormal.gameObject.SetActive(false);
            tsSpritesManager.rainbowStandProud.gameObject.SetActive(true);
            AudioManager.Instance.PlayBGM(BGMID.LOVELOVEGUILTY);
            ProceedText(IsContinue, false);
        }
        else if (EventID == 16)
        {
            tsMainScript.Clickable = true;
            tsMainScript.DialogIndex = 17;
            tsSpritesManager.dialogBox.SetActive(true);
            tsSpritesManager.BackgroundUpdate("DetentionCenter");
            tsSpritesManager.rainbowStandProud.gameObject.SetActive(true);
            AudioManager.Instance.PlayBGM(BGMID.LOVELOVEGUILTY);
            ProceedText(IsContinue, false);
        }
        else if (EventID == 17)
        {
            tsMainScript.Clickable = true;
            tsMainScript.DialogIndex = 18;
            tsSpritesManager.dialogBox.SetActive(true);
            tsSpritesManager.BackgroundUpdate("DetentionCenter");
            if (!IsContinue) tsSpritesManager.rainbowStandProud.gameObject.SetActive(false);
            tsSpritesManager.rainbowStandSmile.gameObject.SetActive(true);
            AudioManager.Instance.PlayBGM(BGMID.LOVELOVEGUILTY);
            ProceedText(IsContinue, false);
        }
        else if (EventID == 18)
        {
            tsMainScript.Clickable = true;
            tsMainScript.DialogIndex = 19;
            tsSpritesManager.dialogBox.SetActive(true);
            tsSpritesManager.BackgroundUpdate("DetentionCenter");
            tsSpritesManager.rainbowStandSmile.gameObject.SetActive(true);
            AudioManager.Instance.PlayBGM(BGMID.LOVELOVEGUILTY);
            ProceedText(IsContinue, false);
        }
        else if (EventID == 19)
        {
            tsMainScript.Clickable = true;
            tsMainScript.DialogIndex = 20;
            tsSpritesManager.dialogBox.SetActive(true);
            tsSpritesManager.BackgroundUpdate("DetentionCenter");
            if (!IsContinue) tsSpritesManager.rainbowStandSmile.gameObject.SetActive(false);
            tsSpritesManager.rainbowStandNormal.gameObject.SetActive(true);
            AudioManager.Instance.PlayBGM(BGMID.LOVELOVEGUILTY);
            ProceedText(IsContinue, false);
        }
        else if (EventID == 20)
        {
            tsMainScript.Clickable = true;
            tsMainScript.DialogIndex = 21;
            tsSpritesManager.dialogBox.SetActive(true);
            tsSpritesManager.BackgroundUpdate("DetentionCenter");
            if (!IsContinue) tsSpritesManager.rainbowStandNormal.gameObject.SetActive(false);
            tsSpritesManager.rainbowStretchThinking.gameObject.SetActive(true);
            AudioManager.Instance.PlayBGM(BGMID.LOVELOVEGUILTY);
            ProceedText(IsContinue, false);
        }
        else if (EventID == 21)
        {
            tsMainScript.DialogIndex = 22;
            tsSpritesManager.dialogBox.SetActive(true);
            tsSpritesManager.BackgroundUpdate("DetentionCenter");
            ProceedText(IsContinue, false);
            if (!IsContinue)
            {
                tsMainScript.Clickable = false;
                Invoke("Event21Delay", 1.5f);
            }
            else
            {
                tsMainScript.Clickable = true;
                tsSpritesManager.rainbowStandProud.gameObject.SetActive(true);
            }
            AudioManager.Instance.PlayBGM(BGMID.LOVELOVEGUILTY);
        }
        else if (EventID == 22)
        {
            tsMainScript.DialogIndex = 23;
            tsSpritesManager.BackgroundUpdate("DetentionCenter");
            if (!IsContinue)
            {
                tsMainScript.Clickable = false;
                tsSpritesManager.dialogBox.SetActive(false);
                tsSpritesManager.WhiteScreen.GetComponent<Image>().DOFade(0, 0);
                tsSpritesManager.WhiteScreen.SetActive(true);
                tsSpritesManager.WhiteScreen.GetComponent<Image>().DOFade(1, .25f);
                Invoke("Event22Delay", .25f);
                Invoke("Event22Delay2", .5f);
            }
            else
            {
                tsMainScript.Clickable = true;
                tsSpritesManager.dialogBox.SetActive(true);
                tsSpritesManager.rainbowStandProud.gameObject.SetActive(true);
                ProceedText(true, false);
            }
            AudioManager.Instance.PlayBGM(BGMID.LOVELOVEGUILTY);
        }
        else if (EventID == 23)
        {
            tsMainScript.DialogIndex = 24;
            tsSpritesManager.dialogBox.SetActive(true);
            tsSpritesManager.BackgroundUpdate("DetentionCenter");
            ProceedText(IsContinue, false);
            if (!IsContinue)
            {
                tsMainScript.Clickable = false;
                tsSpritesManager.rainbowStandProud.gameObject.SetActive(false);
                tsSpritesManager.rainbowStandSmile.gameObject.SetActive(true);
                Invoke("Event23Delay", 2.3f);
            }
            else
            {
                tsMainScript.Clickable = true;
                tsSpritesManager.rainbowStandProud.gameObject.SetActive(true);
            }
            AudioManager.Instance.PlayBGM(BGMID.LOVELOVEGUILTY);
        }
        else if (EventID == 24)
        {
            tsMainScript.Clickable = true;
            tsMainScript.DialogIndex = 25;
            tsSpritesManager.dialogBox.SetActive(true);
            tsSpritesManager.BackgroundUpdate("DetentionCenter");
            ProceedText(IsContinue, false);
            if (!IsContinue) tsSpritesManager.rainbowStandProud.gameObject.SetActive(false);
            tsSpritesManager.rainbowStandNormal.gameObject.SetActive(true);
            AudioManager.Instance.PlayBGM(BGMID.LOVELOVEGUILTY);
        }
        else if (EventID == 25)
        {
            tsMainScript.Clickable = true;
            tsMainScript.DialogIndex = 26;
            tsSpritesManager.dialogBox.SetActive(true);
            tsSpritesManager.BackgroundUpdate("DetentionCenter");
            ProceedText(IsContinue, false);
            tsSpritesManager.rainbowStandNormal.gameObject.SetActive(true);
            AudioManager.Instance.PlayBGM(BGMID.LOVELOVEGUILTY);
        }
        else if (EventID == 26)
        {
            tsMainScript.Clickable = true;
            tsMainScript.DialogIndex = 27;
            tsSpritesManager.dialogBox.SetActive(true);
            tsSpritesManager.BackgroundUpdate("DetentionCenter");
            if (!IsContinue) tsSpritesManager.rainbowStandNormal.gameObject.SetActive(false);
            tsSpritesManager.rainbowStandAnnoyed.gameObject.SetActive(true);
            ProceedText(IsContinue, false);
            AudioManager.Instance.PlayBGM(BGMID.LOVELOVEGUILTY);
        }
        else if (EventID == 27)
        {
            tsMainScript.Clickable = true;
            tsMainScript.DialogIndex = 28;
            tsSpritesManager.dialogBox.SetActive(true);
            tsSpritesManager.BackgroundUpdate("DetentionCenter");
            tsSpritesManager.rainbowStandAnnoyed.gameObject.SetActive(true);
            ProceedText(IsContinue, false);
            AudioManager.Instance.PlayBGM(BGMID.LOVELOVEGUILTY);
        }
        else if (EventID == 28)
        {
            tsMainScript.DialogIndex = 29;
            tsSpritesManager.BackgroundUpdate("DetentionCenter");
            tsSpritesManager.rainbowStandAnnoyed.gameObject.SetActive(true);
            if (!IsContinue)
            {
                tsMainScript.Clickable = false;
                tsSpritesManager.dialogBox.SetActive(false);
                AudioManager.Instance.PlaySE(SEID.se_script_012);
                Invoke("Event28Delay", 1.07f);
            }
            else
            {
                tsMainScript.Clickable = true;
                tsSpritesManager.dialogBox.SetActive(true);
                ProceedText(true, false);
            }
            AudioManager.Instance.PlayBGM(BGMID.LOVELOVEGUILTY);
        }
        else if (EventID == 29)
        {
            tsMainScript.DialogIndex = 30;
            tsSpritesManager.BackgroundUpdate("DetentionCenter");
            if (!IsContinue)
            {
                tsMainScript.Clickable = false;
                tsSpritesManager.dialogBox.SetActive(false);
                Invoke("Event29Delay", 2f);
            }
            else
            {
                tsMainScript.Clickable = true;
                tsSpritesManager.dialogBox.SetActive(true);
                tsSpritesManager.rainbowStretchThinking.gameObject.SetActive(true);
                ProceedText(true, false);
            }
            AudioManager.Instance.PlayBGM(BGMID.LOVELOVEGUILTY);
            tsMainScript.EventID = 9290;
        }
        else if (EventID == 9290)
        {
            tsMainScript.EventID = 29;
            tsMainScript.ProceedGame(tsMainScript.ChapterID, tsMainScript.AreaID, true);
        }
        else if (EventID == 9291)
        {
            if (!tsMainScript.completedTalk.Contains(0)) tsMainScript.completedTalk.Add(0);
            tsMainScript.EventID = 99990;
            tsMainScript.ProceedGame(tsMainScript.ChapterID, tsMainScript.AreaID, false);
        }
        else if (EventID == 30)
        {
            tsMainScript.Clickable = true;
            tsMainScript.DialogIndex = 31;
            tsSpritesManager.dialogBox.SetActive(true);
            tsSpritesManager.BackgroundUpdate("DetentionCenter");
            AudioManager.Instance.PlayBGM(BGMID.LOVELOVEGUILTY);
            if (!IsContinue)
            {
                tsSpritesManager.ClrAllCharaSpr("Rainbow");
                tsMainScript.btnOpenCourtRecords.gameObject.SetActive(true);
                tsMainScript.btnShowBacklog.gameObject.SetActive(true);
                tsMainScript.btnOptions.gameObject.SetActive(true);
                tsMainScript.ClickOverlay.SetActive(true);
            }
            tsSpritesManager.rainbowStandNormal.gameObject.SetActive(true);
            ProceedText(IsContinue, false);
        }
        else if (EventID == 31)
        {
            tsMainScript.Clickable = true;
            tsMainScript.DialogIndex = 32;
            tsSpritesManager.dialogBox.SetActive(true);
            tsSpritesManager.BackgroundUpdate("DetentionCenter");
            AudioManager.Instance.PlayBGM(BGMID.LOVELOVEGUILTY);
            tsSpritesManager.rainbowStandNormal.gameObject.SetActive(true);
            ProceedText(IsContinue, false);
        }
        else if (EventID == 32)
        {
            tsMainScript.Clickable = true;
            tsMainScript.DialogIndex = 33;
            tsSpritesManager.dialogBox.SetActive(true);
            tsSpritesManager.BackgroundUpdate("DetentionCenter");
            AudioManager.Instance.PlayBGM(BGMID.LOVELOVEGUILTY);
            if (!IsContinue) tsSpritesManager.rainbowStandNormal.gameObject.SetActive(false);
            tsSpritesManager.rainbowStandSmile.gameObject.SetActive(true);
            ProceedText(IsContinue, false);
        }
        else if (EventID == 33)
        {
            tsMainScript.Clickable = true;
            tsMainScript.DialogIndex = 34;
            tsSpritesManager.dialogBox.SetActive(true);
            tsSpritesManager.BackgroundUpdate("DetentionCenter");
            AudioManager.Instance.PlayBGM(BGMID.LOVELOVEGUILTY);
            tsSpritesManager.rainbowStandSmile.gameObject.SetActive(true);
            ProceedText(IsContinue, false);
        }
        else if (EventID == 34)
        {
            tsMainScript.Clickable = true;
            tsMainScript.DialogIndex = 35;
            tsSpritesManager.dialogBox.SetActive(true);
            tsSpritesManager.BackgroundUpdate("DetentionCenter");
            AudioManager.Instance.PlayBGM(BGMID.LOVELOVEGUILTY);
            tsSpritesManager.rainbowStandSmile.gameObject.SetActive(true);
            ProceedText(IsContinue, false);
        }
        else if (EventID == 35)
        {
            tsMainScript.Clickable = true;
            tsMainScript.DialogIndex = 36;
            tsSpritesManager.dialogBox.SetActive(true);
            tsSpritesManager.BackgroundUpdate("DetentionCenter");
            AudioManager.Instance.PlayBGM(BGMID.LOVELOVEGUILTY);
            tsSpritesManager.rainbowStandSmile.gameObject.SetActive(true);
            ProceedText(IsContinue, false);
        }
        else if (EventID == 36)
        {
            tsMainScript.Clickable = true;
            tsMainScript.DialogIndex = 37;
            tsSpritesManager.dialogBox.SetActive(true);
            tsSpritesManager.BackgroundUpdate("DetentionCenter");
            AudioManager.Instance.PlayBGM(BGMID.LOVELOVEGUILTY);
            if (!IsContinue) tsSpritesManager.rainbowStandSmile.gameObject.SetActive(false);
            tsSpritesManager.rainbowStandProud.gameObject.SetActive(true);
            ProceedText(IsContinue, false);
        }
        else if (EventID == 37)
        {
            tsMainScript.DialogIndex = 38;
            tsSpritesManager.dialogBox.SetActive(true);
            tsSpritesManager.BackgroundUpdate("DetentionCenter");
            tsSpritesManager.rainbowStandProud.gameObject.SetActive(true);
            AudioManager.Instance.PlayBGM(BGMID.LOVELOVEGUILTY);
            ProceedText(IsContinue, false);
            if (!IsContinue)
            {
                tsMainScript.Clickable = false;
                tsSpritesManager.WhiteScreen.GetComponent<Image>().DOFade(0, 0);
                Invoke("Event37Delay", 1.2f);
                Invoke("Event37Delay2", 1.45f);
                Invoke("Event37Delay3", 1.7f);
            }
            else
            {
                tsMainScript.Clickable = true;
            }
        }
        else if (EventID == 38)
        {
            tsMainScript.Clickable = true;
            tsMainScript.DialogIndex = 39;
            tsSpritesManager.dialogBox.SetActive(true);
            tsSpritesManager.BackgroundUpdate("DetentionCenter");
            AudioManager.Instance.PlayBGM(BGMID.LOVELOVEGUILTY);
            if (!IsContinue) tsSpritesManager.rainbowStandProud.gameObject.SetActive(false);
            tsSpritesManager.rainbowStandSmile.gameObject.SetActive(true);
            ProceedText(IsContinue, false);
        }
        else if (EventID == 39)
        {
            tsMainScript.Clickable = true;
            tsMainScript.DialogIndex = 40;
            tsSpritesManager.dialogBox.SetActive(true);
            tsSpritesManager.BackgroundUpdate("DetentionCenter");
            AudioManager.Instance.PlayBGM(BGMID.LOVELOVEGUILTY);
            tsSpritesManager.rainbowStandSmile.gameObject.SetActive(true);
            ProceedText(IsContinue, false);
        }
        else if (EventID == 40)
        {
            tsMainScript.DialogIndex = 41;
            tsSpritesManager.dialogBox.SetActive(true);
            tsSpritesManager.BackgroundUpdate("DetentionCenter");
            AudioManager.Instance.PlayBGM(BGMID.LOVELOVEGUILTY);
            tsMainScript.EventID = 9400;
            if (!IsContinue)
            {
                tsMainScript.Clickable = false;
                tsSpritesManager.rainbowStandSmile.gameObject.SetActive(false);
                tsSpritesManager.rainbowStandProud.gameObject.SetActive(true);
                ProceedText(false, false);
                Invoke("Event40Delay", 1.4f);
            }
            else
            {
                tsMainScript.Clickable = true;
                tsSpritesManager.rainbowSitDashface.gameObject.SetActive(true);
                ProceedText(true, false);
            }
        }
        else if (EventID == 9400)
        {
            tsMainScript.EventID = 40;
            tsMainScript.ProceedGame(tsMainScript.ChapterID, tsMainScript.AreaID, true);
        }
        else if (EventID == 9401)
        {
            if (!tsMainScript.completedTalk.Contains(1)) tsMainScript.completedTalk.Add(1);
            tsMainScript.EventID = 99990;
            tsMainScript.ProceedGame(tsMainScript.ChapterID, tsMainScript.AreaID, false);
        }
        else if (EventID == 41)
        {
            tsMainScript.Clickable = true;
            tsMainScript.DialogIndex = 42;
            tsSpritesManager.dialogBox.SetActive(true);
            tsSpritesManager.BackgroundUpdate("DetentionCenter");
            AudioManager.Instance.PlayBGM(BGMID.LOVELOVEGUILTY);
            if (!IsContinue)
            {
                tsMainScript.btnOpenCourtRecords.gameObject.SetActive(true);
                tsMainScript.btnShowBacklog.gameObject.SetActive(true);
                tsMainScript.btnOptions.gameObject.SetActive(true);
                tsMainScript.ClickOverlay.SetActive(true);
            }
            else
            {
                tsSpritesManager.rainbowStandNormal.gameObject.SetActive(true);
            }
            ProceedText(IsContinue, false);
        }
        else if (EventID == 42)
        {
            tsMainScript.Clickable = true;
            tsMainScript.DialogIndex = 43;
            tsSpritesManager.dialogBox.SetActive(true);
            tsSpritesManager.BackgroundUpdate("DetentionCenter");
            AudioManager.Instance.PlayBGM(BGMID.LOVELOVEGUILTY);
            if (!IsContinue) tsSpritesManager.ClrAllCharaSpr("Rainbow");
            tsSpritesManager.rainbowStandNormal.gameObject.SetActive(true);
            ProceedText(IsContinue, false);
        }
        else if (EventID == 43)
        {
            tsMainScript.Clickable = true;
            tsMainScript.DialogIndex = 44;
            tsSpritesManager.dialogBox.SetActive(true);
            tsSpritesManager.BackgroundUpdate("DetentionCenter");
            AudioManager.Instance.PlayBGM(BGMID.LOVELOVEGUILTY);
            if (!IsContinue)
            {
                MainCamera.DOShakePosition(.3f, new Vector3(2, 0, 0)).SetLoops(1, LoopType.Yoyo);
                AudioManager.Instance.PlaySE(SEID.se_script_001);
                tsSpritesManager.rainbowStandNormal.gameObject.SetActive(false);
            }
            tsSpritesManager.rainbowStandAngry.gameObject.SetActive(true);
            ProceedText(IsContinue, false);
        }
        else if (EventID == 44)
        {
            tsMainScript.Clickable = true;
            tsMainScript.DialogIndex = 45;
            tsSpritesManager.dialogBox.SetActive(true);
            tsSpritesManager.BackgroundUpdate("DetentionCenter");
            AudioManager.Instance.PlayBGM(BGMID.LOVELOVEGUILTY);
            tsSpritesManager.rainbowStandAngry.gameObject.SetActive(true);
            ProceedText(IsContinue, false);
        }
        else if (EventID == 45)
        {
            tsMainScript.Clickable = true;
            tsMainScript.DialogIndex = 46;
            tsSpritesManager.dialogBox.SetActive(true);
            tsSpritesManager.BackgroundUpdate("DetentionCenter");
            AudioManager.Instance.PlayBGM(BGMID.LOVELOVEGUILTY);
            if (!IsContinue) tsSpritesManager.rainbowStandAngry.gameObject.SetActive(false);
            tsSpritesManager.rainbowStandFacehoof.gameObject.SetActive(true);
            ProceedText(IsContinue, false);
        }
        else if (EventID == 46)
        {
            tsMainScript.Clickable = true;
            tsMainScript.DialogIndex = 47;
            tsSpritesManager.dialogBox.SetActive(true);
            tsSpritesManager.BackgroundUpdate("DetentionCenter");
            AudioManager.Instance.PlayBGM(BGMID.LOVELOVEGUILTY);
            if (!IsContinue) tsSpritesManager.rainbowStandFacehoof.gameObject.SetActive(false);
            tsSpritesManager.rainbowStandAnnoyed.gameObject.SetActive(true);
            ProceedText(IsContinue, false);
        }
        else if (EventID == 47)
        {
            tsMainScript.DialogIndex = 48;
            tsSpritesManager.dialogBox.SetActive(true);
            tsSpritesManager.BackgroundUpdate("DetentionCenter");
            AudioManager.Instance.PlayBGM(BGMID.LOVELOVEGUILTY);
            ProceedText(IsContinue, false);
            if (!IsContinue)
            {
                tsMainScript.Clickable = false;
                Invoke("Event47Delay", 2.6f);
            }
            else
            {
                tsMainScript.Clickable = true;
                tsSpritesManager.rainbowSitDashface.gameObject.SetActive(true);
            }
        }
        else if (EventID == 48)
        {
            tsMainScript.Clickable = true;
            tsMainScript.DialogIndex = 49;
            tsSpritesManager.dialogBox.SetActive(true);
            tsSpritesManager.BackgroundUpdate("DetentionCenter");
            AudioManager.Instance.PlayBGM(BGMID.LOVELOVEGUILTY);
            ProceedText(IsContinue, false);
            if (!IsContinue)
            {
                tsMainScript.Clickable = false;
                tsSpritesManager.rainbowSitDashface.gameObject.SetActive(false);
                tsSpritesManager.rainbowStandNormal.gameObject.SetActive(true);
                Invoke("Event48Delay", 2.8f);
            }
            else
            {
                tsMainScript.Clickable = true;
                tsSpritesManager.rainbowStandSmile.gameObject.SetActive(true);
            }
        }
        else if (EventID == 49)
        {
            tsMainScript.Clickable = true;
            tsMainScript.DialogIndex = 50;
            tsSpritesManager.dialogBox.SetActive(true);
            tsSpritesManager.BackgroundUpdate("DetentionCenter");
            AudioManager.Instance.PlayBGM(BGMID.LOVELOVEGUILTY);
            tsSpritesManager.rainbowStandSmile.gameObject.SetActive(true);
            ProceedText(IsContinue, false);
        }
        else if (EventID == 50)
        {
            tsMainScript.Clickable = true;
            tsMainScript.DialogIndex = 51;
            tsSpritesManager.dialogBox.SetActive(true);
            tsSpritesManager.BackgroundUpdate("DetentionCenter");
            AudioManager.Instance.PlayBGM(BGMID.LOVELOVEGUILTY);
            tsSpritesManager.rainbowStandSmile.gameObject.SetActive(true);
            ProceedText(IsContinue, false);
            tsMainScript.EventID = 9500;
        }
        else if (EventID == 9500)
        {
            tsMainScript.EventID = 50;
            tsMainScript.ProceedGame(tsMainScript.ChapterID, tsMainScript.AreaID, true);
        }
        else if (EventID == 9501)
        {
            if (!tsMainScript.completedTalk.Contains(2)) tsMainScript.completedTalk.Add(2);
            tsMainScript.EventID = 99990;
            tsMainScript.ProceedGame(tsMainScript.ChapterID, tsMainScript.AreaID, false);
        }
        else if (EventID == 51)
        {
            tsMainScript.Clickable = true;
            tsMainScript.DialogIndex = 52;
            tsSpritesManager.dialogBox.SetActive(true);
            tsSpritesManager.BackgroundUpdate("DetentionCenter");
            AudioManager.Instance.PlayBGM(BGMID.LOVELOVEGUILTY);
            if (!IsContinue)
            {
                tsMainScript.btnOpenCourtRecords.gameObject.SetActive(true);
                tsMainScript.btnShowBacklog.gameObject.SetActive(true);
                tsMainScript.btnOptions.gameObject.SetActive(true);
                tsMainScript.ClickOverlay.SetActive(true);
            }
            else
            {
                tsSpritesManager.rainbowStandNormal.gameObject.SetActive(true);
            }
            ProceedText(IsContinue, false);
        }
        else if (EventID == 52)
        {
            tsMainScript.Clickable = true;
            tsMainScript.DialogIndex = 53;
            tsSpritesManager.dialogBox.SetActive(true);
            tsSpritesManager.BackgroundUpdate("DetentionCenter");
            AudioManager.Instance.PlayBGM(BGMID.LOVELOVEGUILTY);
            if (!IsContinue) tsSpritesManager.ClrAllCharaSpr("Rainbow");
            tsSpritesManager.rainbowStandNormal.gameObject.SetActive(true);
            ProceedText(IsContinue, false);
        }
        else if (EventID == 53)
        {
            tsMainScript.Clickable = true;
            tsMainScript.DialogIndex = 54;
            tsSpritesManager.dialogBox.SetActive(true);
            tsSpritesManager.BackgroundUpdate("DetentionCenter");
            AudioManager.Instance.PlayBGM(BGMID.LOVELOVEGUILTY);
            tsSpritesManager.rainbowStandNormal.gameObject.SetActive(true);
            ProceedText(IsContinue, false);
        }
        else if (EventID == 54)
        {
            tsMainScript.Clickable = true;
            tsMainScript.DialogIndex = 55;
            tsSpritesManager.dialogBox.SetActive(true);
            tsSpritesManager.BackgroundUpdate("DetentionCenter");
            AudioManager.Instance.PlayBGM(BGMID.LOVELOVEGUILTY);
            tsSpritesManager.rainbowStandNormal.gameObject.SetActive(true);
            ProceedText(IsContinue, false);
        }
        else if (EventID == 55)
        {
            tsMainScript.Clickable = true;
            tsMainScript.DialogIndex = 56;
            tsSpritesManager.dialogBox.SetActive(true);
            tsSpritesManager.BackgroundUpdate("DetentionCenter");
            AudioManager.Instance.PlayBGM(BGMID.LOVELOVEGUILTY);
            tsSpritesManager.rainbowStandNormal.gameObject.SetActive(true);
            ProceedText(IsContinue, false);
        }
        else if (EventID == 56)
        {
            tsMainScript.Clickable = true;
            tsMainScript.DialogIndex = 57;
            tsSpritesManager.dialogBox.SetActive(true);
            tsSpritesManager.BackgroundUpdate("DetentionCenter");
            AudioManager.Instance.PlayBGM(BGMID.LOVELOVEGUILTY);
            tsSpritesManager.rainbowStandNormal.gameObject.SetActive(true);
            ProceedText(IsContinue, false);
        }
        else if (EventID == 57)
        {
            tsMainScript.Clickable = true;
            tsMainScript.DialogIndex = 58;
            tsSpritesManager.dialogBox.SetActive(true);
            tsSpritesManager.BackgroundUpdate("DetentionCenter");
            AudioManager.Instance.PlayBGM(BGMID.LOVELOVEGUILTY);
            if (!IsContinue) tsSpritesManager.rainbowStandNormal.gameObject.SetActive(false);
            tsSpritesManager.rainbowStretchThinking.gameObject.SetActive(true);
            ProceedText(IsContinue, false);
        }
        else if (EventID == 58)
        {
            tsMainScript.Clickable = true;
            tsMainScript.DialogIndex = 59;
            tsSpritesManager.dialogBox.SetActive(true);
            tsSpritesManager.BackgroundUpdate("DetentionCenter");
            AudioManager.Instance.PlayBGM(BGMID.LOVELOVEGUILTY);
            tsSpritesManager.rainbowStretchThinking.gameObject.SetActive(true);
            ProceedText(IsContinue, false);
        }
        else if (EventID == 59)
        {
            tsMainScript.Clickable = true;
            tsMainScript.DialogIndex = 60;
            tsSpritesManager.dialogBox.SetActive(true);
            tsSpritesManager.BackgroundUpdate("DetentionCenter");
            AudioManager.Instance.PlayBGM(BGMID.LOVELOVEGUILTY);
            if (!IsContinue) tsSpritesManager.rainbowStretchThinking.gameObject.SetActive(false);
            tsSpritesManager.rainbowStandNormal.gameObject.SetActive(true);
            ProceedText(IsContinue, false);
        }
        else if (EventID == 60)
        {
            tsMainScript.Clickable = true;
            tsMainScript.DialogIndex = 61;
            tsSpritesManager.dialogBox.SetActive(true);
            tsSpritesManager.BackgroundUpdate("DetentionCenter");
            AudioManager.Instance.PlayBGM(BGMID.LOVELOVEGUILTY);
            if (!IsContinue) tsSpritesManager.rainbowStandNormal.gameObject.SetActive(false);
            tsSpritesManager.rainbowStandAngry.gameObject.SetActive(true);
            ProceedText(IsContinue, false);
        }
        else if (EventID == 61)
        {
            tsMainScript.Clickable = true;
            tsMainScript.DialogIndex = 62;
            tsSpritesManager.dialogBox.SetActive(true);
            tsSpritesManager.BackgroundUpdate("DetentionCenter");
            AudioManager.Instance.PlayBGM(BGMID.LOVELOVEGUILTY);
            if (!IsContinue) tsSpritesManager.rainbowStandAngry.gameObject.SetActive(false);
            tsSpritesManager.rainbowStandNormal.gameObject.SetActive(true);
            ProceedText(IsContinue, false);
        }
        else if (EventID == 62)
        {
            tsMainScript.Clickable = true;
            tsMainScript.DialogIndex = 63;
            tsSpritesManager.dialogBox.SetActive(true);
            tsSpritesManager.BackgroundUpdate("DetentionCenter");
            AudioManager.Instance.PlayBGM(BGMID.LOVELOVEGUILTY);
            tsSpritesManager.rainbowStandNormal.gameObject.SetActive(true);
            ProceedText(IsContinue, false);
        }
        else if (EventID == 63)
        {
            tsMainScript.DialogIndex = 64;
            tsSpritesManager.dialogBox.SetActive(true);
            tsSpritesManager.BackgroundUpdate("DetentionCenter");
            if (!IsContinue)
            {
                AudioManager.Instance.StopBGM(false);
                tsMainScript.Clickable = false;
                tsSpritesManager.WhiteScreen.GetComponent<Image>().DOFade(0, 0);
                tsSpritesManager.WhiteScreen.SetActive(true);
                tsSpritesManager.WhiteScreen.GetComponent<Image>().DOFade(1, .25f);
                Invoke("Event63Delay", .25f);
                Invoke("Event63Delay2", .5f);
            }
            else
            {
                tsMainScript.Clickable = true;
                tsSpritesManager.rainbowStandDisturbed.gameObject.SetActive(true);
                ProceedText(true, false);
            }
        }
        else if (EventID == 64)
        {
            tsMainScript.Clickable = true;
            tsMainScript.DialogIndex = 65;
            tsSpritesManager.dialogBox.SetActive(true);
            tsSpritesManager.BackgroundUpdate("DetentionCenter");
            tsSpritesManager.rainbowStandDisturbed.gameObject.SetActive(true);
            ProceedText(IsContinue, false);
        }
        else if (EventID == 65)
        {
            tsMainScript.Clickable = true;
            tsMainScript.DialogIndex = 66;
            tsSpritesManager.dialogBox.SetActive(true);
            tsSpritesManager.BackgroundUpdate("DetentionCenter");
            if (!IsContinue)
            {
                Invoke("Event65Delay", .5f);
            }
            else
            {
                AudioManager.Instance.PlayBGM(BGMID.DetentionCenter_2001);
            }
            tsSpritesManager.rainbowStandDisturbed.gameObject.SetActive(true);
            ProceedText(IsContinue, false);
        }
        else if (EventID == 66)
        {
            tsMainScript.Clickable = true;
            tsMainScript.DialogIndex = 67;
            tsSpritesManager.dialogBox.SetActive(true);
            tsSpritesManager.BackgroundUpdate("DetentionCenter");
            AudioManager.Instance.PlayBGM(BGMID.DetentionCenter_2001);
            tsSpritesManager.rainbowStandDisturbed.gameObject.SetActive(true);
            ProceedText(IsContinue, false);
        }
        else if (EventID == 67)
        {
            tsMainScript.Clickable = true;
            tsMainScript.DialogIndex = 68;
            tsSpritesManager.dialogBox.SetActive(true);
            tsSpritesManager.BackgroundUpdate("DetentionCenter");
            AudioManager.Instance.PlayBGM(BGMID.DetentionCenter_2001);
            if (!IsContinue) tsSpritesManager.rainbowStandDisturbed.gameObject.SetActive(false);
            tsSpritesManager.rainbowStandNormal.gameObject.SetActive(true);
            ProceedText(IsContinue, false);
        }
        else if (EventID == 68)
        {
            tsMainScript.Clickable = true;
            tsMainScript.DialogIndex = 69;
            tsSpritesManager.dialogBox.SetActive(true);
            tsSpritesManager.BackgroundUpdate("DetentionCenter");
            AudioManager.Instance.PlayBGM(BGMID.DetentionCenter_2001);
            tsSpritesManager.rainbowStandNormal.gameObject.SetActive(true);
            ProceedText(IsContinue, false);
        }
        else if (EventID == 69)
        {
            tsMainScript.DialogIndex = 70;
            tsSpritesManager.dialogBox.SetActive(true);
            tsSpritesManager.BackgroundUpdate("DetentionCenter");
            AudioManager.Instance.PlayBGM(BGMID.DetentionCenter_2001);
            if (!IsContinue)
            {
                tsMainScript.Clickable = false;
                tsSpritesManager.WhiteScreen.GetComponent<Image>().DOFade(0, 0);
                tsSpritesManager.WhiteScreen.SetActive(true);
                tsSpritesManager.WhiteScreen.GetComponent<Image>().DOFade(1, .25f);
                Invoke("Event69Delay", .25f);
                Invoke("Event69Delay2", .5f);
            }
            else
            {
                tsMainScript.Clickable = true;
                tsSpritesManager.rainbowStretchThinking.gameObject.SetActive(true);
                ProceedText(true, false);
            }
        }
        else if (EventID == 70)
        {
            tsMainScript.Clickable = true;
            tsMainScript.DialogIndex = 71;
            tsSpritesManager.dialogBox.SetActive(true);
            tsSpritesManager.BackgroundUpdate("DetentionCenter");
            AudioManager.Instance.PlayBGM(BGMID.DetentionCenter_2001);
            tsSpritesManager.rainbowStretchThinking.gameObject.SetActive(true);
            ProceedText(IsContinue, false);
        }
        else if (EventID == 71)
        {
            tsMainScript.DialogIndex = 72;
            tsSpritesManager.dialogBox.SetActive(true);
            tsSpritesManager.BackgroundUpdate("DetentionCenter");
            AudioManager.Instance.PlayBGM(BGMID.DetentionCenter_2001);
            if (!IsContinue)
            {
                tsMainScript.Clickable = false;
                ProceedText(false, false);
                Invoke("Event71Delay", 1.2f);
                Invoke("Event71Delay2", 2.9f);
            }
            else
            {
                tsMainScript.Clickable = true;
                tsSpritesManager.rainbowStandSorry.gameObject.SetActive(true);
                ProceedText(true, false);
            }
        }
        else if (EventID == 72)
        {
            tsMainScript.Clickable = true;
            tsMainScript.DialogIndex = 73;
            tsSpritesManager.dialogBox.SetActive(true);
            tsSpritesManager.BackgroundUpdate("DetentionCenter");
            AudioManager.Instance.PlayBGM(BGMID.DetentionCenter_2001);
            if (!IsContinue)  tsSpritesManager.rainbowStandSorry.gameObject.SetActive(false);
            tsSpritesManager.rainbowStandNormal.gameObject.SetActive(true);
            ProceedText(IsContinue, false);
        }
        else if (EventID == 73)
        {
            tsMainScript.Clickable = true;
            tsMainScript.DialogIndex = 74;
            tsSpritesManager.dialogBox.SetActive(true);
            tsSpritesManager.BackgroundUpdate("DetentionCenter");
            AudioManager.Instance.PlayBGM(BGMID.DetentionCenter_2001);
            tsSpritesManager.rainbowStandNormal.gameObject.SetActive(true);
            ProceedText(IsContinue, false);
        }
        else if (EventID == 74)
        {
            tsMainScript.Clickable = true;
            tsMainScript.DialogIndex = 75;
            tsSpritesManager.dialogBox.SetActive(true);
            tsSpritesManager.BackgroundUpdate("DetentionCenter");
            AudioManager.Instance.PlayBGM(BGMID.DetentionCenter_2001);
            tsSpritesManager.rainbowStandNormal.gameObject.SetActive(true);
            ProceedText(IsContinue, false);
        }
        else if (EventID == 75)
        {
            tsMainScript.Clickable = true;
            tsMainScript.DialogIndex = 76;
            tsSpritesManager.dialogBox.SetActive(true);
            tsSpritesManager.BackgroundUpdate("DetentionCenter");
            AudioManager.Instance.PlayBGM(BGMID.DetentionCenter_2001);
            if (!IsContinue) tsSpritesManager.rainbowStandNormal.gameObject.SetActive(false);
            tsSpritesManager.rainbowStandProud.gameObject.SetActive(true);
            ProceedText(IsContinue, false);
        }
        else if (EventID == 76)
        {
            tsMainScript.Clickable = true;
            tsMainScript.DialogIndex = 77;
            tsSpritesManager.dialogBox.SetActive(true);
            tsSpritesManager.BackgroundUpdate("DetentionCenter");
            AudioManager.Instance.PlayBGM(BGMID.DetentionCenter_2001);
            tsSpritesManager.rainbowStandProud.gameObject.SetActive(true);
            ProceedText(IsContinue, false);
        }
        else if (EventID == 77)
        {
            tsMainScript.Clickable = true;
            tsMainScript.DialogIndex = 78;
            tsSpritesManager.dialogBox.SetActive(true);
            tsSpritesManager.BackgroundUpdate("DetentionCenter");
            AudioManager.Instance.PlayBGM(BGMID.DetentionCenter_2001);
            tsSpritesManager.rainbowStandProud.gameObject.SetActive(true);
            ProceedText(IsContinue, false);
        }
        else if (EventID == 78)
        {
            tsMainScript.Clickable = true;
            tsMainScript.DialogIndex = 79;
            tsSpritesManager.dialogBox.SetActive(true);
            tsSpritesManager.BackgroundUpdate("DetentionCenter");
            AudioManager.Instance.PlayBGM(BGMID.DetentionCenter_2001);
            if (!IsContinue) tsSpritesManager.rainbowStandProud.gameObject.SetActive(false);
            tsSpritesManager.rainbowStandNormal.gameObject.SetActive(true);
            ProceedText(IsContinue, false);
        }
        else if (EventID == 79)
        {
            tsMainScript.Clickable = true;
            tsMainScript.DialogIndex = 80;
            tsSpritesManager.dialogBox.SetActive(true);
            tsSpritesManager.BackgroundUpdate("DetentionCenter");
            AudioManager.Instance.PlayBGM(BGMID.DetentionCenter_2001);
            if (!IsContinue) tsSpritesManager.rainbowStandNormal.gameObject.SetActive(false);
            tsSpritesManager.rainbowStandSorry.gameObject.SetActive(true);
            ProceedText(IsContinue, false);
        }
        else if (EventID == 80)
        {
            tsMainScript.Clickable = true;
            tsMainScript.DialogIndex = 81;
            tsSpritesManager.dialogBox.SetActive(true);
            tsSpritesManager.BackgroundUpdate("DetentionCenter");
            AudioManager.Instance.PlayBGM(BGMID.DetentionCenter_2001);
            tsSpritesManager.rainbowStandSorry.gameObject.SetActive(true);
            ProceedText(IsContinue, false);
        }
        else if (EventID == 81)
        {
            tsMainScript.DialogIndex = 82;
            tsSpritesManager.dialogBox.SetActive(true);
            tsSpritesManager.BackgroundUpdate("DetentionCenter");
            AudioManager.Instance.PlayBGM(BGMID.DetentionCenter_2001);
            tsMainScript.EventID = 9810;
            if (!IsContinue)
            {
                tsMainScript.Clickable = false;
                ProceedText(false, false);
                Invoke("Event81Delay", 1.6f);
            }
            else
            {
                tsMainScript.Clickable = true;
                tsSpritesManager.rainbowStandNormal.gameObject.SetActive(true);
                ProceedText(true, false);
            }
        }
        else if (EventID == 9810)
        {
            tsMainScript.EventID = 81;
            tsMainScript.ProceedGame(tsMainScript.ChapterID, tsMainScript.AreaID, true);
        }
        else if (EventID == 9811)
        {
            if (!tsMainScript.completedTalk.Contains(3)) tsMainScript.completedTalk.Add(3);
            tsMainScript.EventID = 99990;
            tsMainScript.ProceedGame(tsMainScript.ChapterID, tsMainScript.AreaID, false);
        }
        else if (EventID == 120)
        {
            tsMainScript.Clickable = true;
            tsMainScript.DialogIndex = 121;
            tsSpritesManager.dialogBox.SetActive(true);
            tsSpritesManager.BackgroundUpdate("DetentionCenter");
            if (!IsContinue)
            {
                tsSpritesManager.ClrAllCharaSpr("Rainbow");
                tsMainScript.btnOpenCourtRecords.gameObject.SetActive(true);
                tsMainScript.btnShowBacklog.gameObject.SetActive(true);
                tsMainScript.btnOptions.gameObject.SetActive(true);
                tsMainScript.ClickOverlay.SetActive(true);
            }
            tsSpritesManager.rainbowStandNormal.gameObject.SetActive(true);
            ProceedText(IsContinue, false);
            tsMainScript.EventID = 91200;
        }
        else if (EventID == 91200)
        {
            tsMainScript.EventID = 120;
            tsMainScript.ProceedGame(tsMainScript.ChapterID, tsMainScript.AreaID, true);
        }
        else if (EventID == 91201)
        {
            tsMainScript.EventID = 99990;
            tsMainScript.ProceedGame(tsMainScript.ChapterID, tsMainScript.AreaID, false);
        }
        else if (EventID == 82)
        {
            tsMainScript.Clickable = true;
            tsMainScript.DialogIndex = 83;
            tsSpritesManager.dialogBox.SetActive(true);
            tsSpritesManager.BackgroundUpdate("DetentionCenter");
            AudioManager.Instance.PlayBGM(BGMID.DetentionCenter_2001);
            tsSpritesManager.Magatama.SetActive(true);
            tsSpritesManager.ItemHolder.SetActive(true);
            if (!IsContinue)
            {
                AudioManager.Instance.PlaySE(SEID.item_pop);
                tsSpritesManager.ClrAllCharaSpr("Rainbow");
                tsMainScript.btnOpenCourtRecords.gameObject.SetActive(true);
                tsMainScript.btnShowBacklog.gameObject.SetActive(true);
                tsMainScript.btnOptions.gameObject.SetActive(true);
                tsMainScript.ClickOverlay.SetActive(true);
            }
            tsSpritesManager.rainbowStandNormal.gameObject.SetActive(true);
            ProceedText(IsContinue, false);
        }
        else if (EventID == 83)
        {
            tsMainScript.Clickable = true;
            tsMainScript.DialogIndex = 84;
            tsSpritesManager.dialogBox.SetActive(true);
            tsSpritesManager.BackgroundUpdate("DetentionCenter");
            AudioManager.Instance.PlayBGM(BGMID.DetentionCenter_2001);
            tsSpritesManager.Magatama.SetActive(true);
            tsSpritesManager.ItemHolder.SetActive(true);
            if (!IsContinue) tsSpritesManager.rainbowStandNormal.gameObject.SetActive(false);
            tsSpritesManager.rainbowStandSmile.gameObject.SetActive(true);
            ProceedText(IsContinue, false);
        }
        else if (EventID == 84)
        {
            tsMainScript.Clickable = true;
            tsMainScript.DialogIndex = 85;
            tsSpritesManager.dialogBox.SetActive(true);
            tsSpritesManager.BackgroundUpdate("DetentionCenter");
            tsSpritesManager.Magatama.SetActive(true);
            tsSpritesManager.ItemHolder.SetActive(true);
            tsSpritesManager.rainbowStandNormal.gameObject.SetActive(true);
            ProceedText(IsContinue, false);
            if (!IsContinue)
            {
                tsSpritesManager.rainbowStandSmile.gameObject.SetActive(false);
                Invoke("Event84Delay", .8f);
            }
        }
        else if (EventID == 85)
        {
            tsMainScript.Clickable = true;
            tsMainScript.DialogIndex = 86;
            tsSpritesManager.dialogBox.SetActive(true);
            tsSpritesManager.BackgroundUpdate("DetentionCenter");
            tsSpritesManager.Magatama.SetActive(true);
            tsSpritesManager.ItemHolder.SetActive(true);
            tsSpritesManager.rainbowStandNormal.gameObject.SetActive(true);
            ProceedText(IsContinue, false);
        }
        else if (EventID == 86)
        {
            tsMainScript.DialogIndex = 87;
            tsSpritesManager.dialogBox.SetActive(true);
            tsSpritesManager.BackgroundUpdate("DetentionCenter");
            tsSpritesManager.Magatama.SetActive(true);
            tsSpritesManager.ItemHolder.SetActive(true);
            ProceedText(IsContinue, false);
            if (!IsContinue)
            {
                tsMainScript.Clickable = false;
                tsSpritesManager.rainbowStandNormal.gameObject.SetActive(false);
                tsSpritesManager.rainbowStandDisturbed.gameObject.SetActive(true);
                Invoke("Event86Delay", 1.6f);
                Invoke("Event86Delay2", 2.8f);
            }
            else
            {
                tsMainScript.Clickable = true;
                tsSpritesManager.rainbowStandAngry.gameObject.SetActive(true);
            }
        }
        else if (EventID == 87)
        {
            tsMainScript.Clickable = true;
            tsMainScript.DialogIndex = 88;
            tsSpritesManager.dialogBox.SetActive(true);
            tsSpritesManager.BackgroundUpdate("DetentionCenter");
            tsSpritesManager.Magatama.SetActive(true);
            tsSpritesManager.ItemHolder.SetActive(true);
            tsSpritesManager.rainbowStandAngry.gameObject.SetActive(true);
            ProceedText(IsContinue, false);
        }
        else if (EventID == 88)
        {
            tsMainScript.Clickable = true;
            tsMainScript.DialogIndex = 89;
            tsSpritesManager.dialogBox.SetActive(true);
            tsSpritesManager.BackgroundUpdate("DetentionCenter");
            tsSpritesManager.Magatama.SetActive(true);
            tsSpritesManager.ItemHolder.SetActive(true);
            if (!IsContinue) tsSpritesManager.rainbowStandAngry.gameObject.SetActive(false);
            tsSpritesManager.rainbowStandNormal.gameObject.SetActive(true);
            ProceedText(IsContinue, false);
        }
        else if (EventID == 89)
        {
            tsMainScript.Clickable = true;
            tsMainScript.DialogIndex = 90;
            tsSpritesManager.dialogBox.SetActive(true);
            tsSpritesManager.BackgroundUpdate("DetentionCenter");
            tsSpritesManager.Magatama.SetActive(true);
            tsSpritesManager.ItemHolder.SetActive(true);
            if (!IsContinue) tsSpritesManager.rainbowStandAngry.gameObject.SetActive(false);
            tsSpritesManager.rainbowStandNormal.gameObject.SetActive(true);
            ProceedText(IsContinue, false);
        }
        else if (EventID == 90)
        {
            tsMainScript.Clickable = true;
            tsMainScript.DialogIndex = 91;
            tsSpritesManager.dialogBox.SetActive(true);
            tsSpritesManager.BackgroundUpdate("DetentionCenter");
            tsSpritesManager.rainbowStandNormal.gameObject.SetActive(true);
            ProceedText(IsContinue, false);
            if (!IsContinue)
            {
                AudioManager.Instance.PlaySE(SEID.se_com_008);
                tsSpritesManager.ItemHolder.GetComponent<RectTransform>().DOScale(new Vector3(0, 0, 0), .25f);
                Invoke("Event90Delay", .5f);
            }
        }
        else if (EventID == 91)
        {
            tsMainScript.Clickable = true;
            tsMainScript.DialogIndex = 92;
            tsSpritesManager.dialogBox.SetActive(true);
            tsSpritesManager.BackgroundUpdate("DetentionCenter");
            tsSpritesManager.rainbowStandNormal.gameObject.SetActive(true);
            ProceedText(IsContinue, false);
        }
        else if (EventID == 92)
        {
            tsMainScript.Clickable = true;
            tsMainScript.DialogIndex = 93;
            tsSpritesManager.dialogBox.SetActive(true);
            tsSpritesManager.BackgroundUpdate("DetentionCenter");
            tsSpritesManager.rainbowStandNormal.gameObject.SetActive(true);
            ProceedText(IsContinue, false);
        }
        else if (EventID == 93)
        {
            tsMainScript.Clickable = true;
            tsMainScript.DialogIndex = 94;
            tsSpritesManager.dialogBox.SetActive(true);
            tsSpritesManager.BackgroundUpdate("DetentionCenter");
            tsSpritesManager.rainbowStandProud.gameObject.SetActive(true);
            ProceedText(IsContinue, false);
            tsMainScript.EventID = 9930;
            if (!IsContinue)
            {
                tsSpritesManager.rainbowStandNormal.gameObject.SetActive(false);
                Invoke("Event93Delay", .5f);
            }
            else
            {
                AudioManager.Instance.PlayBGM(BGMID.LOVELOVEGUILTY);
            }
        }
        else if (EventID == 9930)
        {
            tsMainScript.EventID = 93;
            tsMainScript.ProceedGame(tsMainScript.ChapterID, tsMainScript.AreaID, true);
        }
        else if (EventID == 9931)
        {
            if (!tsMainScript.completedTalk.Contains(4)) tsMainScript.completedTalk.Add(4);
            tsMainScript.EventID = 99990;
            tsMainScript.ProceedGame(tsMainScript.ChapterID, tsMainScript.AreaID, false);
        }
        else if (EventID == 94)
        {
            tsMainScript.Clickable = true;
            tsMainScript.DialogIndex = 95;
            tsSpritesManager.dialogBox.SetActive(true);
            tsSpritesManager.BackgroundUpdate("DetentionCenter");
            AudioManager.Instance.PlayBGM(BGMID.LOVELOVEGUILTY);
            if (!IsContinue)
            {
                tsMainScript.btnOpenCourtRecords.gameObject.SetActive(true);
                tsMainScript.btnShowBacklog.gameObject.SetActive(true);
                tsMainScript.btnOptions.gameObject.SetActive(true);
                tsMainScript.ClickOverlay.SetActive(true);
            }
            else
            {
                tsSpritesManager.rainbowStandNormal.gameObject.SetActive(true);
            }
            ProceedText(IsContinue, false);
        }
        else if (EventID == 95)
        {
            tsMainScript.Clickable = true;
            tsMainScript.DialogIndex = 96;
            tsSpritesManager.dialogBox.SetActive(true);
            tsSpritesManager.BackgroundUpdate("DetentionCenter");
            AudioManager.Instance.PlayBGM(BGMID.LOVELOVEGUILTY);
            if (!IsContinue)
            {
                tsSpritesManager.rainbowStandNormal.gameObject.SetActive(false);
                tsSpritesManager.rainbowStandProud.gameObject.SetActive(false);
            }
            tsSpritesManager.rainbowStandSmile.gameObject.SetActive(true);
            ProceedText(IsContinue, false);
        }
        else if (EventID == 96)
        {
            tsMainScript.Clickable = true;
            tsMainScript.DialogIndex = 97;
            tsSpritesManager.dialogBox.SetActive(true);
            tsSpritesManager.BackgroundUpdate("DetentionCenter");
            AudioManager.Instance.PlayBGM(BGMID.LOVELOVEGUILTY);
            tsSpritesManager.rainbowStandSmile.gameObject.SetActive(true);
            ProceedText(IsContinue, false);
        }
        else if (EventID == 97)
        {
            tsMainScript.Clickable = true;
            tsMainScript.DialogIndex = 98;
            tsSpritesManager.dialogBox.SetActive(true);
            tsSpritesManager.BackgroundUpdate("DetentionCenter");
            AudioManager.Instance.PlayBGM(BGMID.LOVELOVEGUILTY);
            if (!IsContinue) tsSpritesManager.rainbowStandSmile.gameObject.SetActive(false);
            tsSpritesManager.rainbowStandNormal.gameObject.SetActive(true);
            ProceedText(IsContinue, false);
        }
        else if (EventID == 98)
        {
            tsMainScript.Clickable = true;
            tsMainScript.DialogIndex = 99;
            tsSpritesManager.dialogBox.SetActive(true);
            tsSpritesManager.BackgroundUpdate("DetentionCenter");
            AudioManager.Instance.PlayBGM(BGMID.LOVELOVEGUILTY);
            tsSpritesManager.rainbowStandNormal.gameObject.SetActive(true);
            ProceedText(IsContinue, false);
        }
        else if (EventID == 99)
        {
            tsMainScript.Clickable = true;
            tsMainScript.DialogIndex = 100;
            tsSpritesManager.dialogBox.SetActive(true);
            tsSpritesManager.BackgroundUpdate("DetentionCenter");
            AudioManager.Instance.PlayBGM(BGMID.LOVELOVEGUILTY);
            tsSpritesManager.rainbowStandNormal.gameObject.SetActive(true);
            ProceedText(IsContinue, false);
        }
        else if (EventID == 100)
        {
            tsMainScript.Clickable = true;
            tsMainScript.DialogIndex = 101;
            tsSpritesManager.dialogBox.SetActive(true);
            tsSpritesManager.BackgroundUpdate("DetentionCenter");
            AudioManager.Instance.PlayBGM(BGMID.LOVELOVEGUILTY);
            if (!IsContinue) tsSpritesManager.rainbowStandNormal.gameObject.SetActive(false);
            tsSpritesManager.rainbowStandSmile.gameObject.SetActive(true);
            ProceedText(IsContinue, false);
        }
        else if (EventID == 101)
        {
            tsMainScript.Clickable = true;
            tsMainScript.DialogIndex = 102;
            tsSpritesManager.dialogBox.SetActive(true);
            tsSpritesManager.BackgroundUpdate("DetentionCenter");
            AudioManager.Instance.PlayBGM(BGMID.LOVELOVEGUILTY);
            tsSpritesManager.rainbowStandSmile.gameObject.SetActive(true);
            ProceedText(IsContinue, false);
        }
        else if (EventID == 102)
        {
            tsMainScript.DialogIndex = 103;
            tsSpritesManager.dialogBox.SetActive(true);
            tsSpritesManager.BackgroundUpdate("DetentionCenter");
            AudioManager.Instance.PlayBGM(BGMID.LOVELOVEGUILTY);
            ProceedText(IsContinue, false);
            if (!IsContinue)
            {
                tsMainScript.Clickable = false;
                Invoke("Event102Delay", .7f);
            }
            else
            {
                tsMainScript.Clickable = true;
                tsSpritesManager.rainbowStandNormal.gameObject.SetActive(true);
            }
        }
        else if (EventID == 103)
        {
            tsMainScript.Clickable = true;
            tsMainScript.DialogIndex = 104;
            tsSpritesManager.dialogBox.SetActive(true);
            tsSpritesManager.BackgroundUpdate("DetentionCenter");
            AudioManager.Instance.PlayBGM(BGMID.LOVELOVEGUILTY);
            if (!IsContinue) tsSpritesManager.rainbowStandNormal.gameObject.SetActive(false);
            tsSpritesManager.rainbowStretchThinking.gameObject.SetActive(true);
            ProceedText(IsContinue, false);
        }
        else if (EventID == 104)
        {
            tsMainScript.Clickable = true;
            tsMainScript.DialogIndex = 105;
            tsSpritesManager.dialogBox.SetActive(true);
            tsSpritesManager.BackgroundUpdate("DetentionCenter");
            AudioManager.Instance.PlayBGM(BGMID.LOVELOVEGUILTY);
            tsSpritesManager.rainbowStretchThinking.gameObject.SetActive(true);
            ProceedText(IsContinue, false);
        }
        else if (EventID == 105)
        {
            tsMainScript.DialogIndex = 106;
            tsSpritesManager.BackgroundUpdate("DetentionCenter");
            if (!IsContinue)
            {
                tsMainScript.Clickable = false;
                tsSpritesManager.dialogBox.SetActive(false);
                tsSpritesManager.WhiteScreen.GetComponent<Image>().DOFade(0, 0);
                tsSpritesManager.WhiteScreen.SetActive(true);
                tsSpritesManager.WhiteScreen.GetComponent<Image>().DOFade(1, .25f);
                Invoke("Event105Delay", .25f);
                Invoke("Event105Delay2", .5f);
            }
            else
            {
                tsMainScript.Clickable = true;
                tsSpritesManager.dialogBox.SetActive(true);
                tsSpritesManager.rainbowStandDisturbed.gameObject.SetActive(true);
                ProceedText(true, false);
            }
        }
        else if (EventID == 106)
        {
            tsMainScript.Clickable = true;
            tsSpritesManager.dialogBox.SetActive(true);
            tsMainScript.DialogIndex = 107;
            tsSpritesManager.BackgroundUpdate("DetentionCenter");
            tsSpritesManager.rainbowStandDisturbed.gameObject.SetActive(true);
            ProceedText(IsContinue, false);
        }
        else if (EventID == 107)
        {
            tsMainScript.Clickable = false;
            tsMainScript.DialogIndex = 108;
            ProceedText(false, false);
            Invoke("Event107Delay", 1.6f);
            Invoke("Event107Delay2", 4.1f);
            Invoke("Event107Delay3", 4.2f);
            Invoke("Event107Delay4", 5.2f);
            Invoke("Event107Delay5", 6.2f);
            // 0.5
            Invoke("Event107Delay6", 6.7f);
            // 1
            Invoke("Event107Delay7", 7.2f);
            // 1.5
            Invoke("Event107Delay8", 7.7f);
            // 2
            Invoke("Event107Delay9", 8.7f);
            Invoke("Event107Delay10", 9.2f);
            Invoke("Event107Delay11", 9.35f);
            Invoke("Event107Delay12", 9.5f);
            Invoke("Event107Delay13", 9.65f);
            Invoke("Event107Delay14", 9.8f);
            Invoke("Event107Delay15", 10.3f);
            Invoke("Event107Delay16", 10.8f);
        }
        else if (EventID == 108)
        {
            tsMainScript.Clickable = true;
            tsSpritesManager.dialogBox.SetActive(true);
            tsMainScript.DialogIndex = 109;
            ProceedText(IsContinue, false);
            if (!IsContinue)
            {
                tsSpritesManager.rainbowStandNormal.gameObject.SetActive(false);
            }
            else
            {
                tsSpritesManager.PsyLockChainB1.GetComponent<Animation>().playAutomatically = false;
                tsSpritesManager.PsyLockChainB2.GetComponent<Animation>().playAutomatically = false;
                tsSpritesManager.PsyLockChainB5.GetComponent<Animation>().playAutomatically = false;
                tsSpritesManager.PsyLockChainB6.GetComponent<Animation>().playAutomatically = false;
                tsSpritesManager.PsyLockChainF2.GetComponent<Animation>().playAutomatically = false;
                tsSpritesManager.PsyLockChainF3.GetComponent<Animation>().playAutomatically = false;
                tsSpritesManager.PsyLockChainF4.GetComponent<Animation>().playAutomatically = false;
                tsSpritesManager.PsyLockChainF6.GetComponent<Animation>().playAutomatically = false;
                tsSpritesManager.PsyLockChainB1.SetActive(true);
                tsSpritesManager.PsyLockChainB2.SetActive(true);
                tsSpritesManager.PsyLockChainB5.SetActive(true);
                tsSpritesManager.PsyLockChainB6.SetActive(true);
                tsSpritesManager.PsyLockChainF2.SetActive(true);
                tsSpritesManager.PsyLockChainF3.SetActive(true);
                tsSpritesManager.PsyLockChainF4.SetActive(true);
                tsSpritesManager.PsyLockChainF6.SetActive(true);
                tsSpritesManager.PsyLock1.GetComponent<Animation>().playAutomatically = false;
                tsSpritesManager.PsyLock2.GetComponent<Animation>().playAutomatically = false;
                tsSpritesManager.PsyLock3.GetComponent<Animation>().playAutomatically = false;
                tsSpritesManager.PsyLock1.gameObject.SetActive(true);
                tsSpritesManager.PsyLock2.gameObject.SetActive(true);
                tsSpritesManager.PsyLock3.gameObject.SetActive(true);
            }
            tsSpritesManager.rainbowStandSmile.gameObject.SetActive(true);
        }
        else if (EventID == 109)
        {
            tsMainScript.Clickable = true;
            tsSpritesManager.dialogBox.SetActive(true);
            tsMainScript.DialogIndex = 110;
            ProceedText(IsContinue, false);
            if (!IsContinue)
            {
                tsSpritesManager.rainbowStandSmile.gameObject.SetActive(false);
            }
            else
            {
                tsSpritesManager.PsyLockChainB1.GetComponent<Animation>().playAutomatically = false;
                tsSpritesManager.PsyLockChainB2.GetComponent<Animation>().playAutomatically = false;
                tsSpritesManager.PsyLockChainB5.GetComponent<Animation>().playAutomatically = false;
                tsSpritesManager.PsyLockChainB6.GetComponent<Animation>().playAutomatically = false;
                tsSpritesManager.PsyLockChainF2.GetComponent<Animation>().playAutomatically = false;
                tsSpritesManager.PsyLockChainF3.GetComponent<Animation>().playAutomatically = false;
                tsSpritesManager.PsyLockChainF4.GetComponent<Animation>().playAutomatically = false;
                tsSpritesManager.PsyLockChainF6.GetComponent<Animation>().playAutomatically = false;
                tsSpritesManager.PsyLockChainB1.SetActive(true);
                tsSpritesManager.PsyLockChainB2.SetActive(true);
                tsSpritesManager.PsyLockChainB5.SetActive(true);
                tsSpritesManager.PsyLockChainB6.SetActive(true);
                tsSpritesManager.PsyLockChainF2.SetActive(true);
                tsSpritesManager.PsyLockChainF3.SetActive(true);
                tsSpritesManager.PsyLockChainF4.SetActive(true);
                tsSpritesManager.PsyLockChainF6.SetActive(true);
                tsSpritesManager.PsyLock1.GetComponent<Animation>().playAutomatically = false;
                tsSpritesManager.PsyLock2.GetComponent<Animation>().playAutomatically = false;
                tsSpritesManager.PsyLock3.GetComponent<Animation>().playAutomatically = false;
                tsSpritesManager.PsyLock1.gameObject.SetActive(true);
                tsSpritesManager.PsyLock2.gameObject.SetActive(true);
                tsSpritesManager.PsyLock3.gameObject.SetActive(true);
            }
            tsSpritesManager.rainbowStandSorry.gameObject.SetActive(true);
        }
        else if (EventID == 110)
        {
            tsMainScript.DialogIndex = 111;
            if (!IsContinue)
            {
                tsMainScript.Clickable = false;
                tsSpritesManager.dialogBox.SetActive(false);
                tsSpritesManager.blackScreen.DOFade(0, 0);
                tsSpritesManager.blackScreen.gameObject.SetActive(true);
                tsSpritesManager.blackScreen.DOFade(1, .5f);
                Invoke("Event110Delay", .5f);
                Invoke("Event110Delay2", 1f);
            }
            else
            {
                tsMainScript.Clickable = true;
                tsSpritesManager.dialogBox.SetActive(true);
                tsSpritesManager.BackgroundUpdate("DetentionCenter");
                tsSpritesManager.rainbowStandNormal.gameObject.SetActive(true);
                ProceedText(true, false);
            }
        }
        else if (EventID == 111)
        {
            tsMainScript.DialogIndex = 112;
            tsSpritesManager.dialogBox.SetActive(true);
            tsSpritesManager.BackgroundUpdate("DetentionCenter");
            ProceedText(IsContinue, false);
            if (!IsContinue)
            {
                tsMainScript.Clickable = false;
                tsSpritesManager.rainbowStandNormal.gameObject.SetActive(false);
                tsSpritesManager.rainbowStandDisturbed.gameObject.SetActive(true);
                Invoke("Event111Delay", 2.4f);
            }
            else
            {
                tsMainScript.Clickable = true;
                tsSpritesManager.rainbowStandAngry.gameObject.SetActive(true);
            }
        }
        else if (EventID == 112)
        {
            tsMainScript.Clickable = true;
            tsMainScript.DialogIndex = 113;
            tsSpritesManager.dialogBox.SetActive(true);
            tsSpritesManager.BackgroundUpdate("DetentionCenter");
            tsSpritesManager.rainbowStandAngry.gameObject.SetActive(true);
            ProceedText(IsContinue, false);
        }
        else if (EventID == 113)
        {
            tsMainScript.Clickable = true;
            tsMainScript.DialogIndex = 114;
            tsSpritesManager.dialogBox.SetActive(true);
            tsSpritesManager.BackgroundUpdate("DetentionCenter");
            if (!IsContinue) tsSpritesManager.rainbowStandAngry.gameObject.SetActive(false);
            tsSpritesManager.rainbowStandDisturbed.gameObject.SetActive(true);
            ProceedText(IsContinue, false);
        }
        else if (EventID == 114)
        {
            tsMainScript.Clickable = true;
            tsMainScript.DialogIndex = 115;
            tsSpritesManager.dialogBox.SetActive(true);
            tsSpritesManager.BackgroundUpdate("DetentionCenter");
            if (!IsContinue) tsSpritesManager.rainbowStandDisturbed.gameObject.SetActive(false);
            tsSpritesManager.rainbowStandSmile.gameObject.SetActive(true);
            ProceedText(IsContinue, false);
        }
        else if (EventID == 115)
        {
            tsMainScript.Clickable = true;
            tsMainScript.DialogIndex = 116;
            tsSpritesManager.dialogBox.SetActive(true);
            tsSpritesManager.BackgroundUpdate("DetentionCenter");
            if (!IsContinue) tsSpritesManager.rainbowStandSmile.gameObject.SetActive(false);
            tsSpritesManager.rainbowStandProud.gameObject.SetActive(true);
            ProceedText(IsContinue, false);
        }
        else if (EventID == 116)
        {
            tsMainScript.DialogIndex = 117;
            tsSpritesManager.dialogBox.SetActive(true);
            tsSpritesManager.BackgroundUpdate("DetentionCenter");
            if (!IsContinue)
            {
                tsMainScript.Clickable = false;
                tsSpritesManager.rainbowStandProud.DOFade(0, .25f);
                Invoke("Event116Delay", .75f);
                Invoke("Event116Delay2", 2.05f);
            }
            else
            {
                tsMainScript.Clickable = true;
                ProceedText(true, false);
            }
        }
        else if (EventID == 117)
        {
            tsMainScript.Clickable = true;
            tsMainScript.DialogIndex = 118;
            tsSpritesManager.dialogBox.SetActive(true);
            tsSpritesManager.BackgroundUpdate("DetentionCenter");
            ProceedText(IsContinue, false);
        }
        else if (EventID == 118)
        {
            tsMainScript.Clickable = true;
            tsMainScript.DialogIndex = 119;
            tsSpritesManager.dialogBox.SetActive(true);
            tsSpritesManager.BackgroundUpdate("DetentionCenter");
            ProceedText(IsContinue, false);
        }
        else if (EventID == 119)
        {
            tsMainScript.Clickable = true;
            tsMainScript.DialogIndex = 120;
            tsSpritesManager.dialogBox.SetActive(true);
            tsSpritesManager.BackgroundUpdate("DetentionCenter");
            ProceedText(IsContinue, false);
            tsMainScript.EventID = 91190;
        }
        else if (EventID == 91190)
        {
            tsMainScript.EventID = 119;
            tsMainScript.ProceedGame(tsMainScript.ChapterID, tsMainScript.AreaID, true);
        }
        else if (EventID == 91191)
        {
            if (!tsMainScript.completedTalk.Contains(5)) tsMainScript.completedTalk.Add(5);
            if (!courtRecordsSystem.DoIHaveThisProfile(2)) courtRecordsSystem.GetNewProfile(2);
            if (!courtRecordsSystem.DoIHaveThisProfile(3)) courtRecordsSystem.GetNewProfile(3);
            tsMainScript.EventID = 99990;
            tsMainScript.ProceedGame(tsMainScript.ChapterID, tsMainScript.AreaID, false);
        }
        else
        {
            tsMainScript.EventID -= 1;
            Debug.Log("EventID " + EventID + "无对应事件。");
        }
    }
    #endregion
    public List<Selection> InitializeTalks()
    {
        List<Selection> tmp = new List<Selection>();
        Selection selection0 = new Selection();
        selection0.id = 0;
        selection0.description = "自我介绍";
        selection0.eventId = 14;
        selection0.isPsyLock = false;
        selection0.prevSelection = -1;
        Selection selection1 = new Selection();
        selection1.id = 1;
        selection1.description = "知道的事情";
        selection1.eventId = 30;
        selection1.isPsyLock = false;
        selection1.prevSelection = 0;
        Selection selection2 = new Selection();
        selection2.id = 2;
        selection2.description = "闪电天马队";
        selection2.eventId = 41;
        selection2.isPsyLock = false;
        selection2.prevSelection = 1;
        Selection selection3 = new Selection();
        selection3.id = 3;
        selection3.description = "被害马死因";
        selection3.eventId = 51;
        selection3.isPsyLock = false;
        selection3.prevSelection = 2;
        Selection selection4 = new Selection();
        selection4.id = 5;
        selection4.description = "案发地点";
        selection4.eventId = 94;
        selection4.isPsyLock = true;
        selection4.prevSelection = 4;
        tmp.Add(selection0);
        tmp.Add(selection1);
        tmp.Add(selection2);
        tmp.Add(selection3);
        tmp.Add(selection4);
        return tmp;
    }
    public void OpenDetectiveTalk()
    {
        AudioManager.Instance.PlaySE(SEID.se_com_001);
        detectiveSystem.CloseActions();
        tsMainScript.btnCloseDetectiveTalk.gameObject.SetActive(true);
        Invoke("ShowTalks", .26f);
    }
    public void ShowTalks()
    {
        detectiveSystem.OpenTalk();
    }
    public List<Selection> InitializePresents()
    {
        List<Selection> tmp = new List<Selection>();
        Selection present0 = new Selection();
        present0.id = 0;
        present0.description = "";
        present0.eventId = 120;
        present0.isPsyLock = false;
        present0.prevSelection = -1;
        Selection present1 = new Selection();
        present1.id = 1;
        present1.description = "";
        present1.eventId = 82;
        present1.isPsyLock = false;
        present1.prevSelection = 1;
        tmp.Add(present0);
        tmp.Add(present1);
        return tmp;
    }
    public void OpenDetectivePresent()
    {
        AudioManager.Instance.PlaySE(SEID.se_com_001);
        detectiveSystem.CloseActions();
        Invoke("ShowPresent", .25f);
    }
    public void ShowPresent()
    {
        tsMainScript.ShowCourtRecordsPresent();
    }
    public List<SelectionMove> InitializeMoves()
    {
        List<SelectionMove> tmp = new List<SelectionMove>();
        SelectionMove area0 = new SelectionMove();
        area0.areaId = 3;
        area0.areaName = "小马镇";
        area0.areaThumb = moveThumb0;
        area0.newEventId = 63;
        tmp.Add(area0);
        return tmp;
    }

    public void OpenDetectiveMove()
    {
        AudioManager.Instance.PlaySE(SEID.se_com_001);
        detectiveSystem.CloseActions();
        tsMainScript.actionMovePanel.gameObject.SetActive(true);
        tsMainScript.btnCloseDetectiveMove.gameObject.SetActive(true);
        Invoke("ShowMoves", .26f);
    }
    public void ShowMoves()
    {
        tsMainScript.actionMovePanel.DOFade(1, .25f);
        tsMainScript.actionMovePanel.blocksRaycasts = true;
        detectiveSystem.OpenMove();
    }
    #region 延迟事件
    public void Event0Delay()
    {
        tsSpritesManager.BackgroundUpdate("DetentionCenter");
        tsSpritesManager.detentionCenter.GetComponent<SpriteRenderer>().DOFade(1, .5f);
    }
    public void Event0Delay2()
    {
        ProceedText(false, false);
        tsMainScript.Clickable = true;
    }
    public void Event1Delay()
    {
        tsMainScript.Clickable = true;
        tsMainScript.dialogBox.SetActive(true);
        ProceedText(false, false);
    }
    public void Event2Delay()
    {
        tsSpritesManager.rainbowStandAngry.gameObject.SetActive(true);
        tsSpritesManager.rainbowStandAngry.DOFade(1, 2f);
    }
    public void Event2Delay2()
    {
        AudioManager.Instance.PlaySE(SEID.se_script_011);
    }
    public void Event2Delay3()
    {
        tsSpritesManager.dialogBox.SetActive(true);
        ProceedText(false, false);
        tsMainScript.Clickable = true;
    }
    public void Event7Delay()
    {
        tsSpritesManager.rainbowStandSmile.gameObject.SetActive(false);
        tsSpritesManager.rainbowStandNormal.gameObject.SetActive(true);
        tsMainScript.Clickable = true;
        ProceedText(false, false);
    }
    public void Event8Delay()
    {
        AudioManager.Instance.PlayBGM(BGMID.LOVELOVEGUILTY);
    }
    public void Event10Delay()
    {
        tsSpritesManager.WhiteScreen.GetComponent<Image>().DOFade(0, .25f);
    }
    public void Event10Delay2()
    {
        tsSpritesManager.WhiteScreen.SetActive(false);
        tsSpritesManager.WhiteScreen.GetComponent<Image>().DOFade(1, 0);
        AudioManager.Instance.PlaySE(SEID.se_script_001);
        MainCamera.DOShakePosition(.3f, new Vector3(2, 0, 0)).SetLoops(1, LoopType.Yoyo);
        tsSpritesManager.dialogBox.SetActive(true);
        ProceedText(false, false);
    }
    public void Event10Delay3()
    {
        tsMainScript.Clickable = true;
        tsSpritesManager.rainbowStandSmile.gameObject.SetActive(false);
        tsSpritesManager.rainbowStandNormal.gameObject.SetActive(true);
    }
    public void Event21Delay()
    {
        tsMainScript.Clickable = true;
        tsSpritesManager.rainbowStretchThinking.gameObject.SetActive(false);
        tsSpritesManager.rainbowStandProud.gameObject.SetActive(true);
    }
    public void Event22Delay()
    {
        AudioManager.Instance.PlaySE(SEID.se_script_007);
        tsSpritesManager.WhiteScreen.GetComponent<Image>().DOFade(0, .25f);
    }
    public void Event22Delay2()
    {
        tsSpritesManager.WhiteScreen.SetActive(false);
        tsSpritesManager.WhiteScreen.GetComponent<Image>().DOFade(1, 0);
        tsMainScript.Clickable = true;
        tsSpritesManager.dialogBox.SetActive(true);
        ProceedText(false, false);
    }
    public void Event23Delay()
    {
        tsMainScript.Clickable = true;
        tsSpritesManager.rainbowStandSmile.gameObject.SetActive(false);
        tsSpritesManager.rainbowStandProud.gameObject.SetActive(true);
    }
    public void Event28Delay()
    {
        tsMainScript.Clickable = true;
        tsMainScript.dialogBox.SetActive(true);
        ProceedText(false, false);
    }
    public void Event29Delay()
    {
        tsMainScript.Clickable = true;
        tsMainScript.dialogBox.SetActive(true);
        tsSpritesManager.rainbowStandAnnoyed.gameObject.SetActive(false);
        tsSpritesManager.rainbowStretchThinking.gameObject.SetActive(true);
        ProceedText(false, false);
    }
    public void Event37Delay()
    {
        tsSpritesManager.WhiteScreen.SetActive(true);
        tsSpritesManager.WhiteScreen.GetComponent<Image>().DOFade(1, .25f);
    }
    public void Event37Delay2()
    {
        AudioManager.Instance.PlaySE(SEID.se_script_011);
        tsSpritesManager.WhiteScreen.GetComponent<Image>().DOFade(0, .25f);
    }
    public void Event37Delay3()
    {
        tsMainScript.Clickable = true;
        tsSpritesManager.WhiteScreen.SetActive(false);
        tsSpritesManager.WhiteScreen.GetComponent<Image>().DOFade(1, 0);
    }
    public void Event40Delay()
    {
        tsMainScript.Clickable = true;
        tsSpritesManager.rainbowStandProud.gameObject.SetActive(false);
        tsSpritesManager.rainbowSitDashface.gameObject.SetActive(true);
    }
    public void Event47Delay()
    {
        tsMainScript.Clickable = true;
        tsSpritesManager.rainbowStandAnnoyed.gameObject.SetActive(false);
        tsSpritesManager.rainbowSitDashface.gameObject.SetActive(true);
    }
    public void Event48Delay()
    {
        tsMainScript.Clickable = true;
        tsSpritesManager.rainbowStandNormal.gameObject.SetActive(false);
        tsSpritesManager.rainbowStandSmile.gameObject.SetActive(true);
    }
    public void Event63Delay()
    {
        AudioManager.Instance.PlaySE(SEID.se_script_011);
        tsMainScript.Clickable = true;
        tsSpritesManager.WhiteScreen.GetComponent<Image>().DOFade(0, .25f);
        tsSpritesManager.rainbowStandNormal.gameObject.SetActive(false);
        tsSpritesManager.rainbowStandDisturbed.gameObject.SetActive(true);
        ProceedText(false, false);
    }
    public void Event63Delay2()
    {
        tsSpritesManager.WhiteScreen.SetActive(false);
        tsSpritesManager.WhiteScreen.GetComponent<Image>().DOFade(1, 0);
    }
    public void Event65Delay()
    {
        AudioManager.Instance.PlayBGM(BGMID.DetentionCenter_2001);
    }
    public void Event69Delay()
    {
        AudioManager.Instance.PlaySE(SEID.se_script_011);
        tsMainScript.Clickable = true;
        tsSpritesManager.WhiteScreen.GetComponent<Image>().DOFade(0, .25f);
        tsSpritesManager.rainbowStandNormal.gameObject.SetActive(false);
        tsSpritesManager.rainbowStretchThinking.gameObject.SetActive(true);
        ProceedText(false, false);
    }
    public void Event69Delay2()
    {
        tsSpritesManager.WhiteScreen.SetActive(false);
        tsSpritesManager.WhiteScreen.GetComponent<Image>().DOFade(1, 0);
    }
    public void Event71Delay()
    {
        tsSpritesManager.rainbowStretchThinking.gameObject.SetActive(false);
        tsSpritesManager.rainbowStandNormal.gameObject.SetActive(true);
    }
    public void Event71Delay2()
    {
        tsMainScript.Clickable = true;
        tsSpritesManager.rainbowStandNormal.gameObject.SetActive(false);
        tsSpritesManager.rainbowStandSorry.gameObject.SetActive(true);
    }
    public void Event81Delay()
    {
        tsMainScript.Clickable = true;
        tsSpritesManager.rainbowStandSorry.gameObject.SetActive(false);
        tsSpritesManager.rainbowStandNormal.gameObject.SetActive(true);
    }
    public void Event84Delay()
    {
        AudioManager.Instance.StopBGM(true);
    }
    public void Event86Delay()
    {
        tsSpritesManager.rainbowStandDisturbed.gameObject.SetActive(false);
        tsSpritesManager.rainbowStandAngry.gameObject.SetActive(true);
    }
    public void Event86Delay2()
    {
        tsMainScript.Clickable = true;
        AudioManager.Instance.PlaySE(SEID.explode);
        MainCamera.DOShakePosition(.3f, new Vector3(2, 0, 0)).SetLoops(1, LoopType.Yoyo);
    }
    public void Event90Delay()
    {
        tsSpritesManager.ItemHolder.SetActive(false);
        tsSpritesManager.Magatama.SetActive(false);
    }
    public void Event93Delay()
    {
        AudioManager.Instance.PlayBGM(BGMID.LOVELOVEGUILTY);
    }
    public void Event102Delay()
    {
        tsMainScript.Clickable = true;
        tsSpritesManager.rainbowStandSmile.gameObject.SetActive(false);
        tsSpritesManager.rainbowStandNormal.gameObject.SetActive(true);
    }
    public void Event105Delay()
    {
        tsSpritesManager.rainbowStretchThinking.gameObject.SetActive(false);
        tsSpritesManager.rainbowStandDisturbed.gameObject.SetActive(true);
        tsSpritesManager.WhiteScreen.GetComponent<Image>().DOFade(0, .25f);
        AudioManager.Instance.StopBGM(false);
        AudioManager.Instance.PlaySE(SEID.se_script_007);
    }
    public void Event105Delay2()
    {
        tsSpritesManager.WhiteScreen.GetComponent<Image>().DOFade(1, 0);
        tsSpritesManager.WhiteScreen.SetActive(false);
        ProceedText(false, false);
        tsMainScript.Clickable = true;
        tsMainScript.dialogBox.SetActive(true);
    }
    public void Event107Delay()
    {
        tsSpritesManager.rainbowStandDisturbed.gameObject.SetActive(false);
        tsSpritesManager.rainbowStandNormal.gameObject.SetActive(true);
    }
    public void Event107Delay2()
    {
        tsSpritesManager.WhiteScreen.SetActive(true);
        tsSpritesManager.ClearAllBG();
        tsSpritesManager.dialogBox.SetActive(false);
    }
    public void Event107Delay3()
    {
        AudioManager.Instance.PlaySE(SEID.se_script_006);
        tsSpritesManager.WhiteScreen.SetActive(false);
        tsSpritesManager.detentionCenterInverted.gameObject.SetActive(true);
        tsSpritesManager.detentionCenterOverlayInverted.gameObject.SetActive(true);
    }
    public void Event107Delay4()
    {
        tsSpritesManager.detentionCenterInverted.DOFade(0, 1f);
        tsSpritesManager.detentionCenterOverlayInverted.DOFade(0, 1f);
    }
    public void Event107Delay5()
    {
        MainCamera.DOShakePosition(2f, new Vector3(.1f, .01f, 0), 20, 90, false, ShakeRandomnessMode.Harmonic);
        AudioManager.Instance.PlayBGM(BGMID.Locks_3_SE);
        tsSpritesManager.PsyLockChainB1.SetActive(true);
        tsSpritesManager.PsyLockChainB5.SetActive(true);
    }
    public void Event107Delay6()
    {
        tsSpritesManager.PsyLockChainB2.SetActive(true);
        tsSpritesManager.PsyLockChainB6.SetActive(true);
    }
    public void Event107Delay7()
    {
        tsSpritesManager.PsyLockChainF2.SetActive(true);
        tsSpritesManager.PsyLockChainF4.SetActive(true);
    }
    public void Event107Delay8()
    {
        tsSpritesManager.PsyLockChainF3.SetActive(true);
        tsSpritesManager.PsyLockChainF6.SetActive(true);
    }
    public void Event107Delay9()
    {
        AudioManager.Instance.StopBGM(true);
    }
    public void Event107Delay10()
    {
        tsSpritesManager.PsyLock1.gameObject.SetActive(true);
        AudioManager.Instance.PlaySE(SEID.LocksAppear_3);
    }
    public void Event107Delay11()
    {
        tsSpritesManager.PsyLock2.gameObject.SetActive(true);
    }
    public void Event107Delay12()
    {
        tsSpritesManager.PsyLock3.gameObject.SetActive(true);
    }
    public void Event107Delay13()
    {
        tsSpritesManager.WhiteScreen.SetActive(true);
    }
    public void Event107Delay14()
    {
        tsSpritesManager.WhiteScreen.SetActive(false);
    }
    public void Event107Delay15()
    {
        AudioManager.Instance.PlaySE(SEID.se_script_011);
    }
    public void Event107Delay16()
    {
        tsMainScript.EventID = 108;
        tsMainScript.Proceed = true;
    }
    public void Event110Delay()
    {
        tsSpritesManager.blackScreen.DOFade(0, .5f);
        tsSpritesManager.PsyLockChainB1.SetActive(false);
        tsSpritesManager.PsyLockChainB2.SetActive(false);
        tsSpritesManager.PsyLockChainB5.SetActive(false);
        tsSpritesManager.PsyLockChainB6.SetActive(false);
        tsSpritesManager.PsyLockChainF2.SetActive(false);
        tsSpritesManager.PsyLockChainF3.SetActive(false);
        tsSpritesManager.PsyLockChainF4.SetActive(false);
        tsSpritesManager.PsyLockChainF6.SetActive(false);
        tsSpritesManager.PsyLock1.gameObject.SetActive(false);
        tsSpritesManager.PsyLock2.gameObject.SetActive(false);
        tsSpritesManager.PsyLock3.gameObject.SetActive(false);
        tsSpritesManager.BackgroundUpdate("DetentionCenter");
        tsSpritesManager.rainbowStandSorry.gameObject.SetActive(false);
        tsSpritesManager.rainbowStandNormal.gameObject.SetActive(true);
    }
    public void Event110Delay2()
    {
        tsSpritesManager.blackScreen.gameObject.SetActive(false);
        tsSpritesManager.blackScreen.DOFade(1, 0);
        tsMainScript.Clickable = true;
        tsSpritesManager.dialogBox.SetActive(true);
        ProceedText(false, false);
    }
    public void Event111Delay()
    {
        tsMainScript.Clickable = true;
        tsSpritesManager.dialogBox.SetActive(true);
        tsSpritesManager.rainbowStandDisturbed.gameObject.SetActive(false);
        tsSpritesManager.rainbowStandAngry.gameObject.SetActive(true);
    }
    public void Event116Delay()
    {
        ProceedText(false, false);
        tsSpritesManager.rainbowStandProud.gameObject.SetActive(false);
        tsSpritesManager.rainbowStandProud.DOFade(1, 0);
    }
    public void Event116Delay2()
    {
        tsMainScript.Clickable = true;
        AudioManager.Instance.PlaySE(SEID.explode);
        MainCamera.DOShakePosition(.3f, new Vector3(2, 0, 0)).SetLoops(1, LoopType.Yoyo);
    }
    #endregion
}