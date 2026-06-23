using DG.Tweening;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class TSScriptC0A6 : MonoBehaviour
{
    // 主摄像机
    public Camera mainCamera;
    // 逆转风暴基础脚本
    public TSMainScript tsMainScript;
    // 逆转风暴 - 贴图管理器
    public TSSpritesManager tsSpritesManager;
    // 对话文件
    public TextAsset DialogFile;
    // 法庭记录系统
    public CourtRecordsSystem courtRecordsSystem;
    // 调查系统
    public DetectiveSystem detectiveSystem;
    //
    [HideInInspector]
    public SpriteRenderer currentCharaSpr;
    //
    public GameObject investSpots;
    //
    public Image DemoEndScreen;
    public CanvasGroup DemoEndPanel;

    void Start()
    {
        detectiveSystem.currentBackgroundPos = 1;
    }

    void Update()
    {

    }

    public void ProceedText(bool isContinue, bool SpriteTalk)
    {
        if (!isContinue)
        {
            tsMainScript.ShowDialogRow();
            if (SpriteTalk) tsMainScript.IsCharacterTalking = true;
        }
        else
        {
            tsMainScript.UpdateText();
        }
    }

    public void ProceedGame(int eventID, bool isContinue)
    {
        if (tsMainScript.CurrentScript != "TSScriptC0A6")
        {
            // 读取 TextAsset
            tsMainScript.CurrentScript = "TSScriptC0A6";
            tsMainScript.ReadText(DialogFile);
            Debug.Log("已读取对话文本TSScriptC0A6");
        }
        print(tsMainScript.EventID);
        // Area 6 案发现场
        if (eventID == 0)
        {
            tsMainScript.Clickable = true;
            tsMainScript.DialogIndex = 1;
            tsSpritesManager.NameTag.SetActive(false);
            tsSpritesManager.dialogBox.SetActive(true);
            tsSpritesManager.SpeechText.SetActive(false);
            tsSpritesManager.NewAreaText.SetActive(true);
            if (!isContinue)
            {
                tsSpritesManager.blackScreen.gameObject.SetActive(false);
            }
            ProceedText(isContinue, false);
        }
        else if (eventID == 1)
        {
            tsMainScript.DialogIndex = 2;
            if (!isContinue)
            {
                tsMainScript.Clickable = false;
                tsSpritesManager.dialogBox.SetActive(false);
                tsSpritesManager.NameTag.SetActive(true);
                tsSpritesManager.SpeechText.SetActive(true);
                tsSpritesManager.NewAreaText.SetActive(false);
                Invoke("Event1Delay", 1f);
            }
            else
            {
                tsMainScript.Clickable = true;
                tsSpritesManager.dialogBox.SetActive(true);
                ProceedText(true, false);
            }
        }
        else if (eventID == 2)
        {
            tsMainScript.DialogIndex = 3;
            tsMainScript.Clickable = true;
            tsSpritesManager.dialogBox.SetActive(true);
            ProceedText(isContinue, false);
        }
        else if (eventID == 3)
        {
            tsMainScript.DialogIndex = 4;
            tsMainScript.Clickable = true;
            tsSpritesManager.dialogBox.SetActive(true);
            ProceedText(isContinue, false);
        }
        else if (eventID == 4)
        {
            tsMainScript.DialogIndex = 5;
            tsMainScript.Clickable = true;
            tsSpritesManager.dialogBox.SetActive(true);
            ProceedText(isContinue, false);
        }
        else if (eventID == 5)
        {
            tsMainScript.DialogIndex = 6;
            tsMainScript.Clickable = true;
            tsSpritesManager.dialogBox.SetActive(true);
            ProceedText(isContinue, false);
        }
        else if (eventID == 6)
        {
            tsMainScript.DialogIndex = 7;
            tsMainScript.Clickable = true;
            tsSpritesManager.dialogBox.SetActive(true);
            if (!isContinue)
            {
                AudioManager.Instance.PlaySE(SEID.explode);
                mainCamera.DOShakePosition(.3f, new Vector3(2, 2, 0)).SetLoops(1, LoopType.Yoyo);
            }
            ProceedText(isContinue, false);
        }
        else if (eventID == 7)
        {
            tsMainScript.DialogIndex = 8;
            tsMainScript.Clickable = true;
            tsSpritesManager.dialogBox.SetActive(true);
            ProceedText(isContinue, false);
        }
        else if (eventID == 8)
        {
            tsMainScript.DialogIndex = 9;
            tsMainScript.Clickable = true;
            tsSpritesManager.dialogBox.SetActive(true);
            ProceedText(isContinue, false);
        }
        else if (eventID == 9)
        {
            tsMainScript.DialogIndex = 10;
            tsMainScript.Clickable = true;
            tsSpritesManager.dialogBox.SetActive(true);
            ProceedText(isContinue, false);
        }
        else if (eventID == 10)
        {
            tsMainScript.DialogIndex = 11;
            if (!isContinue)
            {
                tsMainScript.Clickable = false;
                tsSpritesManager.dialogBox.SetActive(false);
                Invoke("Event10Delay", 2f);
            }
            else
            {
                tsMainScript.Clickable = true;
                tsSpritesManager.dialogBox.SetActive(true);
                ProceedText(true, false);
            }
        }
        else if (eventID == 11)
        {
            tsMainScript.DialogIndex = 12;
            tsMainScript.Clickable = true;
            tsSpritesManager.dialogBox.SetActive(true);
            ProceedText(isContinue, false);
        }
        else if (eventID == 12)
        {
            tsMainScript.DialogIndex = 13;
            tsMainScript.Clickable = true;
            tsSpritesManager.dialogBox.SetActive(true);
            ProceedText(isContinue, false);
        }
        else if (eventID == 13)
        {
            tsMainScript.DialogIndex = 14;
            tsMainScript.Clickable = true;
            tsSpritesManager.dialogBox.SetActive(true);
            ProceedText(isContinue, false);
        }
        else if (eventID == 14)
        {
            tsMainScript.DialogIndex = 15;
            tsMainScript.Clickable = true;
            tsSpritesManager.dialogBox.SetActive(true);
            ProceedText(isContinue, false);
        }
        else if (eventID == 15)
        {
            tsMainScript.DialogIndex = 16;
            tsMainScript.Clickable = true;
            tsSpritesManager.dialogBox.SetActive(true);
            ProceedText(isContinue, false);
        }
        else if (eventID == 16)
        {
            tsMainScript.DialogIndex = 17;
            if (!isContinue)
            {
                tsMainScript.Clickable = false;
                tsSpritesManager.dialogBox.SetActive(false);
                AudioManager.Instance.PlaySE(SEID.se_script_011);
                Invoke("Event16Delay", 1f);
            }
            else
            {
                tsMainScript.Clickable = true;
                tsSpritesManager.dialogBox.SetActive(true);
                ProceedText(true, false);
            }
        }
        else if (eventID == 17)
        {
            tsMainScript.DialogIndex = 18;
            tsMainScript.Clickable = true;
            tsSpritesManager.dialogBox.SetActive(true);
            ProceedText(isContinue, false);
        }
        else if (eventID == 18)
        {
            tsMainScript.DialogIndex = 19;
            tsMainScript.Clickable = true;
            tsSpritesManager.dialogBox.SetActive(true);
            ProceedText(isContinue, false);
            tsSpritesManager.twilightMagicAura.DOFade(0, 0);
        }
        else if (eventID == 19)
        {
            tsMainScript.DialogIndex = 20;
            if (!isContinue)
            {
                tsMainScript.Clickable = false;
                tsSpritesManager.dialogBox.SetActive(false);
                tsSpritesManager.blackScreen.gameObject.SetActive(true);
                tsSpritesManager.BackgroundUpdate("EverfreeCrimeScene");
                tsSpritesManager.TwilightStandNormal.SetActive(true);
                tsSpritesManager.twilightMagicAura.gameObject.SetActive(true);
                tsSpritesManager.twilightMagicAura.DOFade(1, 1f);
                Invoke("Event19Delay", 2f);
                Invoke("Event19Delay2", 5.5f);
            }
            else
            {
                tsSpritesManager.BackgroundUpdate("EverfreeCrimeScene");
                tsSpritesManager.TwilightStandNormal.SetActive(true);
                tsMainScript.Clickable = true;
                tsSpritesManager.dialogBox.SetActive(true);
                ProceedText(true, false);
            }
        }
        else if (eventID == 20)
        {
            tsMainScript.DialogIndex = 21;
            tsMainScript.Clickable = true;
            tsSpritesManager.dialogBox.SetActive(true);
            tsSpritesManager.BackgroundUpdate("EverfreeCrimeScene");
            tsSpritesManager.TwilightStandNormal.SetActive(true);
            ProceedText(isContinue, false);
        }
        else if (eventID == 20)
        {
            tsMainScript.DialogIndex = 21;
            tsMainScript.Clickable = true;
            tsSpritesManager.dialogBox.SetActive(true);
            tsSpritesManager.BackgroundUpdate("EverfreeCrimeScene");
            tsSpritesManager.TwilightStandNormal.SetActive(true);
            ProceedText(isContinue, false);
        }
        else if (eventID == 21)
        {
            tsMainScript.DialogIndex = 22;
            tsMainScript.Clickable = true;
            tsSpritesManager.dialogBox.SetActive(true);
            tsSpritesManager.BackgroundUpdate("EverfreeCrimeScene");
            if (!isContinue)
            {
                tsSpritesManager.TwilightStandNormal.SetActive(false);
                Invoke("Event21Delay", 0.3f);
            }
            else
            {
                AudioManager.Instance.PlayBGM(BGMID.Further_Investigation_2009);
            }
            tsSpritesManager.TwilightStandHappy.SetActive(true);
            ProceedText(isContinue, false);
        }
        else if (eventID == 22)
        {
            AudioManager.Instance.PlayBGM(BGMID.Further_Investigation_2009);
            tsMainScript.DialogIndex = 23;
            tsMainScript.Clickable = true;
            tsSpritesManager.dialogBox.SetActive(true);
            tsSpritesManager.BackgroundUpdate("EverfreeCrimeScene");
            tsSpritesManager.TwilightStandHappy.SetActive(true);
            ProceedText(isContinue, false);
            tsMainScript.EventID = 90220;
        }
        else if (eventID == 90220)
        {
            tsMainScript.EventID = 22;
            tsMainScript.ProceedGame(tsMainScript.ChapterID, tsMainScript.AreaID, true);
        }
        else if (eventID == 90221)
        {
            tsMainScript.EventID = 99990;
            tsMainScript.ProceedGame(tsMainScript.ChapterID, tsMainScript.AreaID, false);
            currentCharaSpr = tsSpritesManager.TwilightStandHappy.GetComponent<SpriteRenderer>();
        }
        else if (eventID == 99990)
        {
            AudioManager.Instance.PlayBGM(BGMID.Further_Investigation_2009);
            tsMainScript.Clickable = true;
            tsMainScript.ClickOverlay.SetActive(false);
            tsSpritesManager.dialogBox.SetActive(false);
            tsSpritesManager.BackgroundUpdate("EverfreeCrimeScene");
            if (isContinue)
            {
                tsSpritesManager.TwilightStandNormal.SetActive(true);
                currentCharaSpr = tsSpritesManager.TwilightStandNormal.GetComponent<SpriteRenderer>();
            }
            tsMainScript.investEnabled = true;
            tsMainScript.moveEnabled = false;
            tsMainScript.talkEnabled = false;
            tsMainScript.presentEnabled = false;
            detectiveSystem.actionInvest.GetComponent<Button>().onClick.RemoveAllListeners();
            detectiveSystem.actionInvest.GetComponent<Button>().onClick.AddListener(OpenDetectiveInvest);
            tsMainScript.ShowActions();
            if (tsMainScript.completedInvest.Contains(0) && tsMainScript.completedInvest.Contains(1))
            {
                detectiveSystem.backgroundSlideBtnLeftActivated = true;
                detectiveSystem.backgroundSlideBtnRightActivated = true;
                detectiveSystem.currentBackground = tsSpritesManager.everfreecrimeScene.GetComponent<Transform>();
                detectiveSystem.currentBackgroundSpots = investSpots.GetComponent<RectTransform>();
                var temp = new List<int>();
                temp.Add(1288);
                temp.Add(0);
                var tempSpr = new List<float>();
                tempSpr.Add(12.06f);
                tempSpr.Add(0f);
                if (tsMainScript.completedInvest.Contains(2))
                {
                    temp.Add(-1288);
                    tempSpr.Add(-12.06f);
                }
                detectiveSystem.allBackgroundPos = temp;
                detectiveSystem.allBackgroundPosSpr = tempSpr;
            }
        }
        else if (eventID == 23)
        {
            AudioManager.Instance.PlayBGM(BGMID.Further_Investigation_2009);
            tsMainScript.DialogIndex = 24;
            tsSpritesManager.BackgroundUpdate("EverfreeCrimeScene");
            if (!isContinue)
            {
                tsMainScript.Clickable = false;
                Invoke("Event23Delay", .26f);
                Invoke("Event23Delay2", .27f);
                Invoke("Event23Delay3", .53f);
            }
            else
            {
                tsMainScript.Clickable = true;
                tsSpritesManager.dialogBox.SetActive(true);
                tsSpritesManager.TwilightStandHappy.SetActive(true);
                ProceedText(true, false);
            }
        }
        else if (eventID == 24)
        {
            AudioManager.Instance.PlayBGM(BGMID.Further_Investigation_2009);
            tsMainScript.DialogIndex = 25;
            tsMainScript.Clickable = true;
            tsSpritesManager.dialogBox.SetActive(true);
            tsSpritesManager.BackgroundUpdate("EverfreeCrimeScene");
            if (!isContinue)
            {
                tsSpritesManager.TwilightStandHappy.SetActive(false);
            }
            tsSpritesManager.TwilightStandNormal.SetActive(true);
            ProceedText(isContinue, false);
        }
        else if (eventID == 25)
        {
            AudioManager.Instance.PlayBGM(BGMID.Further_Investigation_2009);
            tsMainScript.DialogIndex = 26;
            tsMainScript.Clickable = true;
            tsSpritesManager.dialogBox.SetActive(true);
            tsSpritesManager.BackgroundUpdate("EverfreeCrimeScene");
            tsSpritesManager.TwilightStandNormal.SetActive(true);
            ProceedText(isContinue, false);
        }
        else if (eventID == 26)
        {
            AudioManager.Instance.PlayBGM(BGMID.Further_Investigation_2009);
            tsMainScript.DialogIndex = 27;
            tsMainScript.Clickable = true;
            tsSpritesManager.dialogBox.SetActive(true);
            tsSpritesManager.BackgroundUpdate("EverfreeCrimeScene");
            if (!isContinue)
            {
                tsSpritesManager.TwilightStandNormal.SetActive(false);
            }
            tsSpritesManager.twilightStandHey.gameObject.SetActive(true);
            ProceedText(isContinue, false);
        }
        else if (eventID == 27)
        {
            AudioManager.Instance.PlayBGM(BGMID.Further_Investigation_2009);
            tsMainScript.DialogIndex = 28;
            tsMainScript.Clickable = true;
            tsSpritesManager.dialogBox.SetActive(true);
            tsSpritesManager.BackgroundUpdate("EverfreeCrimeScene");
            tsSpritesManager.twilightStandHey.gameObject.SetActive(true);
            ProceedText(isContinue, false);
        }
        else if (eventID == 28)
        {
            AudioManager.Instance.PlayBGM(BGMID.Further_Investigation_2009);
            tsMainScript.DialogIndex = 29;
            tsMainScript.Clickable = true;
            tsSpritesManager.dialogBox.SetActive(true);
            tsSpritesManager.BackgroundUpdate("EverfreeCrimeScene");
            if (!isContinue)
            {
                tsSpritesManager.twilightStandHey.gameObject.SetActive(false);
            }
            tsSpritesManager.TwilightStandNormal.SetActive(true);
            ProceedText(isContinue, false);
        }
        else if (eventID == 29)
        {
            AudioManager.Instance.PlayBGM(BGMID.Further_Investigation_2009);
            tsMainScript.DialogIndex = 30;
            tsMainScript.Clickable = true;
            tsSpritesManager.dialogBox.SetActive(true);
            tsSpritesManager.BackgroundUpdate("EverfreeCrimeScene");
            tsSpritesManager.TwilightStandNormal.SetActive(true);
            ProceedText(isContinue, false);
        }
        else if (eventID == 30)
        {
            AudioManager.Instance.PlayBGM(BGMID.Further_Investigation_2009);
            tsMainScript.DialogIndex = 31;
            tsMainScript.Clickable = true;
            tsSpritesManager.dialogBox.SetActive(true);
            tsSpritesManager.BackgroundUpdate("EverfreeCrimeScene");
            if (!isContinue)
            {
                tsSpritesManager.TwilightStandNormal.SetActive(false);
            }
            tsSpritesManager.TwilightStandConfused.SetActive(true);
            ProceedText(isContinue, false);
        }
        else if (eventID == 31)
        {
            AudioManager.Instance.PlayBGM(BGMID.Further_Investigation_2009);
            tsMainScript.DialogIndex = 32;
            tsMainScript.Clickable = true;
            tsSpritesManager.dialogBox.SetActive(true);
            tsSpritesManager.BackgroundUpdate("EverfreeCrimeScene");
            if (!isContinue)
            {
                tsSpritesManager.TwilightStandConfused.SetActive(false);
            }
            tsSpritesManager.TwilightStandNormal.SetActive(true);
            ProceedText(isContinue, false);
        }
        else if (eventID == 32)
        {
            AudioManager.Instance.PlayBGM(BGMID.Further_Investigation_2009);
            tsMainScript.DialogIndex = 33;
            tsMainScript.Clickable = true;
            tsSpritesManager.dialogBox.SetActive(true);
            tsSpritesManager.BackgroundUpdate("EverfreeCrimeScene");
            tsSpritesManager.TwilightStandNormal.SetActive(true);
            ProceedText(isContinue, false);
        }
        else if (eventID == 33)
        {
            AudioManager.Instance.PlayBGM(BGMID.Further_Investigation_2009);
            tsMainScript.DialogIndex = 34;
            tsMainScript.Clickable = true;
            tsSpritesManager.dialogBox.SetActive(true);
            tsSpritesManager.BackgroundUpdate("EverfreeCrimeScene");
            tsSpritesManager.TwilightStandNormal.SetActive(true);
            ProceedText(isContinue, false);
        }
        else if (eventID == 34)
        {
            AudioManager.Instance.PlayBGM(BGMID.Further_Investigation_2009);
            tsMainScript.DialogIndex = 35;
            tsMainScript.Clickable = true;
            tsSpritesManager.dialogBox.SetActive(true);
            tsSpritesManager.BackgroundUpdate("EverfreeCrimeScene");
            if (!isContinue)
            {
                tsSpritesManager.TwilightStandNormal.SetActive(false);
            }
            tsSpritesManager.TwilightStandConfused.SetActive(true);
            ProceedText(isContinue, false);
        }
        else if (eventID == 35)
        {
            AudioManager.Instance.PlayBGM(BGMID.Further_Investigation_2009);
            tsMainScript.DialogIndex = 36;
            tsMainScript.Clickable = true;
            tsSpritesManager.dialogBox.SetActive(true);
            tsSpritesManager.BackgroundUpdate("EverfreeCrimeScene");
            if (!isContinue)
            {
                tsSpritesManager.TwilightStandConfused.SetActive(false);
            }
            tsSpritesManager.TwilightStandNormal.SetActive(true);
            ProceedText(isContinue, false);
        }
        else if (eventID == 36)
        {
            AudioManager.Instance.PlayBGM(BGMID.Further_Investigation_2009);
            tsMainScript.DialogIndex = 37;
            tsSpritesManager.dialogBox.SetActive(true);
            tsSpritesManager.BackgroundUpdate("EverfreeCrimeScene");
            if (!isContinue)
            {
                tsMainScript.Clickable = false;
                Invoke("Event36Delay", 1.8f);
            }
            else
            {
                tsMainScript.Clickable = true;
                tsSpritesManager.TwilightStandConfused.SetActive(true);
            }
            ProceedText(isContinue, false);
        }
        else if (eventID == 37)
        {
            AudioManager.Instance.PlayBGM(BGMID.Further_Investigation_2009);
            tsMainScript.DialogIndex = 38;
            tsMainScript.Clickable = true;
            tsSpritesManager.dialogBox.SetActive(true);
            tsSpritesManager.BackgroundUpdate("EverfreeCrimeScene");
            tsSpritesManager.TwilightStandConfused.SetActive(true);
            ProceedText(isContinue, false);
        }
        else if (eventID == 38)
        {
            if (!isContinue)
            {
                if (courtRecordsSystem.DoIHaveThisEvidence(4))
                {
                    tsMainScript.EventID = 39;
                    tsMainScript.Proceed = true;
                }
                else
                {
                    AudioManager.Instance.PlaySE(SEID.se_com_017);
                    tsSpritesManager.NameTag.SetActive(false);
                    tsMainScript.DialogIndex = 39;
                    courtRecordsSystem.GetNewEvidence(4);
                    courtRecordsSystem.NewEvidenceShow();
                    tsMainScript.CourtRecordsHideOverlay.SetActive(true);
                    ProceedText(false, false);
                }
            }
            else
            {
                AudioManager.Instance.PlayBGM(BGMID.Further_Investigation_2009);
                tsMainScript.DialogIndex = 39;
                tsMainScript.Clickable = true;
                tsSpritesManager.NameTag.SetActive(false);
                tsSpritesManager.dialogBox.SetActive(true);
                tsSpritesManager.BackgroundUpdate("EverfreeCrimeScene");
                tsSpritesManager.TwilightStandConfused.SetActive(true);
                ProceedText(true, false);
            }
        }
        else if (eventID == 39)
        {
            AudioManager.Instance.PlayBGM(BGMID.Further_Investigation_2009);
            tsMainScript.DialogIndex = 40;
            tsSpritesManager.BackgroundUpdate("EverfreeCrimeScene");
            if (!isContinue)
            {
                tsMainScript.Clickable = false;
                tsSpritesManager.dialogBox.SetActive(false);
                tsSpritesManager.NameTag.SetActive(true);
                tsSpritesManager.TwilightStandConfused.GetComponent<SpriteRenderer>().DOFade(0, .25f);
                Invoke("Event39Delay", .5f);
                Invoke("Event39Delay2", 1.5f);
                Invoke("Event39Delay3", 1.75f);
                Invoke("Event39Delay4", 3.95f);
            }
            else
            {
                tsMainScript.Clickable = true;
                tsSpritesManager.dialogBox.SetActive(true);
                tsSpritesManager.TwilightStandHappy.SetActive(true);
                ProceedText(true, false);
            }
        }
        else if (eventID == 40)
        {
            AudioManager.Instance.PlayBGM(BGMID.Further_Investigation_2009);
            tsMainScript.DialogIndex = 41;
            tsMainScript.Clickable = true;
            tsSpritesManager.dialogBox.SetActive(true);
            tsSpritesManager.BackgroundUpdate("EverfreeCrimeScene");
            tsSpritesManager.TwilightStandHappy.SetActive(true);
            ProceedText(isContinue, false);
        }
        else if (eventID == 41)
        {
            AudioManager.Instance.PlayBGM(BGMID.Further_Investigation_2009);
            tsMainScript.DialogIndex = 42;
            tsMainScript.Clickable = true;
            tsSpritesManager.dialogBox.SetActive(true);
            tsSpritesManager.BackgroundUpdate("EverfreeCrimeScene");
            tsSpritesManager.TwilightStandHappy.SetActive(true);
            ProceedText(isContinue, false);
            tsMainScript.EventID = 90410;
        }
        else if (eventID == 90410)
        {
            tsMainScript.EventID = 41;
            tsMainScript.ProceedGame(tsMainScript.ChapterID, tsMainScript.AreaID, true);
        }
        else if (eventID == 90411)
        {
            if (!tsMainScript.completedInvest.Contains(0) && tsMainScript.completedInvest.Contains(1))
            {
                tsMainScript.completedInvest.Add(0);
                tsMainScript.EventID = 49;
                tsMainScript.ProceedGame(tsMainScript.ChapterID, tsMainScript.AreaID, false);
            }
            else
            {
                if (!tsMainScript.completedInvest.Contains(0))
                {
                    tsMainScript.completedInvest.Add(0);
                }
                tsMainScript.EventID = 99990;
                currentCharaSpr = tsSpritesManager.TwilightStandHappy.GetComponent<SpriteRenderer>();
                tsMainScript.ProceedGame(tsMainScript.ChapterID, tsMainScript.AreaID, false);
            }
        }
        else if (eventID == 42)
        {
            AudioManager.Instance.PlayBGM(BGMID.Further_Investigation_2009);
            tsMainScript.DialogIndex = 43;
            tsSpritesManager.BackgroundUpdate("EverfreeCrimeScene");
            if (!isContinue)
            {
                tsMainScript.Clickable = false;
                Invoke("Event42Delay", .26f);
                Invoke("Event42Delay2", .27f);
                Invoke("Event42Delay3", .52f);
            }
            else
            {
                tsMainScript.Clickable = true;
                tsSpritesManager.dialogBox.SetActive(true);
                tsSpritesManager.TwilightStandNormal.SetActive(true);
                ProceedText(true, false);
            }
        }
        else if (eventID == 43)
        {
            AudioManager.Instance.PlayBGM(BGMID.Further_Investigation_2009);
            tsMainScript.DialogIndex = 44;
            tsSpritesManager.dialogBox.SetActive(true);
            tsSpritesManager.BackgroundUpdate("EverfreeCrimeScene");
            tsSpritesManager.burntObject.SetActive(true);
            tsSpritesManager.ItemHolder.SetActive(true);
            tsSpritesManager.TwilightStandNormal.SetActive(true);
            if (!isContinue)
            {
                tsMainScript.Clickable = false;
                AudioManager.Instance.PlaySE(SEID.item_pop);
                Invoke("Event43Delay", 1f);
            }
            else
            {
                tsMainScript.Clickable = true;
                ProceedText(true, false);
            }
        }
        else if (eventID == 44)
        {
            AudioManager.Instance.PlayBGM(BGMID.Further_Investigation_2009);
            tsMainScript.DialogIndex = 45;
            tsMainScript.Clickable = true;
            tsSpritesManager.dialogBox.SetActive(true);
            tsSpritesManager.BackgroundUpdate("EverfreeCrimeScene");
            tsSpritesManager.burntObject.SetActive(true);
            tsSpritesManager.ItemHolder.SetActive(true);
            if (!isContinue)
            {
                tsSpritesManager.TwilightStandNormal.SetActive(false);
            }
            tsSpritesManager.TwilightStandConfused.SetActive(true);
            ProceedText(isContinue, false);
        }
        else if (eventID == 45)
        {
            AudioManager.Instance.PlayBGM(BGMID.Further_Investigation_2009);
            tsMainScript.DialogIndex = 46;
            tsMainScript.Clickable = true;
            tsSpritesManager.dialogBox.SetActive(true);
            tsSpritesManager.BackgroundUpdate("EverfreeCrimeScene");
            tsSpritesManager.burntObject.SetActive(true);
            tsSpritesManager.ItemHolder.SetActive(true);
            tsSpritesManager.TwilightStandConfused.SetActive(true);
            ProceedText(isContinue, false);
        }
        else if (eventID == 46)
        {
            AudioManager.Instance.PlayBGM(BGMID.Further_Investigation_2009);
            tsMainScript.DialogIndex = 47;
            tsMainScript.Clickable = true;
            tsSpritesManager.dialogBox.SetActive(true);
            tsSpritesManager.BackgroundUpdate("EverfreeCrimeScene");
            tsSpritesManager.burntObject.SetActive(true);
            tsSpritesManager.ItemHolder.SetActive(true);
            if (!isContinue)
            {
                tsSpritesManager.TwilightStandConfused.SetActive(false);
            }
            tsSpritesManager.TwilightStandNormal.SetActive(true);
            ProceedText(isContinue, false);
        }
        else if (eventID == 47)
        {
            AudioManager.Instance.PlayBGM(BGMID.Further_Investigation_2009);
            tsMainScript.DialogIndex = 48;
            tsMainScript.Clickable = true;
            tsSpritesManager.dialogBox.SetActive(true);
            tsSpritesManager.BackgroundUpdate("EverfreeCrimeScene");
            tsSpritesManager.burntObject.SetActive(true);
            tsSpritesManager.ItemHolder.SetActive(true);
            tsSpritesManager.TwilightStandNormal.SetActive(true);
            ProceedText(isContinue, false);
        }
        else if (eventID == 48)
        {
            if (!isContinue)
            {
                tsSpritesManager.burntObject.SetActive(false);
                tsSpritesManager.ItemHolder.SetActive(false);
                if (courtRecordsSystem.DoIHaveThisEvidence(5))
                {
                    tsMainScript.EventID = 90481;
                    tsMainScript.Proceed = true;
                }
                else
                {
                    tsMainScript.EventID = 90480;
                    AudioManager.Instance.PlaySE(SEID.se_com_017);
                    tsSpritesManager.NameTag.SetActive(false);
                    tsMainScript.DialogIndex = 49;
                    courtRecordsSystem.GetNewEvidence(5);
                    courtRecordsSystem.NewEvidenceShow();
                    tsMainScript.CourtRecordsHideOverlay.SetActive(true);
                    ProceedText(false, false);
                }
            }
            else
            {
                tsMainScript.EventID = 90480;
                AudioManager.Instance.PlayBGM(BGMID.Further_Investigation_2009);
                tsMainScript.DialogIndex = 49;
                tsMainScript.Clickable = true;
                tsSpritesManager.NameTag.SetActive(false);
                tsSpritesManager.dialogBox.SetActive(true);
                tsSpritesManager.BackgroundUpdate("EverfreeCrimeScene");
                tsSpritesManager.TwilightStandNormal.SetActive(true);
                ProceedText(true, false);
            }
        }
        else if (eventID == 90480)
        {
            tsMainScript.EventID = 48;
            tsMainScript.ProceedGame(tsMainScript.ChapterID, tsMainScript.AreaID, true);
        }
        else if (eventID == 90481)
        {
            tsSpritesManager.NameTag.SetActive(true);
            if (!tsMainScript.completedInvest.Contains(1) && tsMainScript.completedInvest.Contains(0))
            {
                tsMainScript.completedInvest.Add(1);
                tsMainScript.EventID = 49;
                tsMainScript.ProceedGame(tsMainScript.ChapterID, tsMainScript.AreaID, false);
            }
            else
            {
                if (!tsMainScript.completedInvest.Contains(1))
                {
                    tsMainScript.completedInvest.Add(1);
                }
                tsMainScript.EventID = 99990;
                currentCharaSpr = tsSpritesManager.TwilightStandNormal.GetComponent<SpriteRenderer>();
                tsMainScript.ProceedGame(tsMainScript.ChapterID, tsMainScript.AreaID, false);
            }
        }
        else if (eventID == 49)
        {
            AudioManager.Instance.PlayBGM(BGMID.Further_Investigation_2009);
            tsMainScript.DialogIndex = 50;
            tsMainScript.Clickable = true;
            tsSpritesManager.dialogBox.SetActive(true);
            tsSpritesManager.BackgroundUpdate("EverfreeCrimeScene");
            tsSpritesManager.ClrAllCharaSpr("Twilight");
            tsSpritesManager.TwilightStandNormal.SetActive(true);
            ProceedText(isContinue, false);
        }
        else if (eventID == 50)
        {
            AudioManager.Instance.PlayBGM(BGMID.Further_Investigation_2009);
            tsMainScript.DialogIndex = 51;
            tsMainScript.Clickable = true;
            tsSpritesManager.dialogBox.SetActive(true);
            tsSpritesManager.BackgroundUpdate("EverfreeCrimeScene");
            if (!isContinue)
            {
                tsSpritesManager.TwilightStandNormal.SetActive(false);
            }
            tsSpritesManager.TwilightStandHappy.SetActive(true);
            ProceedText(isContinue, false);
            tsMainScript.EventID = 90500;
        }
        else if (eventID == 90500)
        {
            tsMainScript.EventID = 50;
            tsMainScript.ProceedGame(tsMainScript.ChapterID, tsMainScript.AreaID, true);
        }
        else if (eventID == 90501)
        {
            tsMainScript.EventID = 99990;
            tsMainScript.ProceedGame(tsMainScript.ChapterID, tsMainScript.AreaID, false);
            currentCharaSpr = tsSpritesManager.TwilightStandHappy.GetComponent<SpriteRenderer>();
        }
        else if (eventID == 51)
        {
            tsMainScript.DialogIndex = 52;
            tsMainScript.Clickable = true;
            tsSpritesManager.dialogBox.SetActive(true);
            if (!isContinue)
            {
                tsMainScript.btnOpenCourtRecords.gameObject.SetActive(true);
                tsMainScript.btnShowBacklog.gameObject.SetActive(true);
                tsMainScript.btnOptions.gameObject.SetActive(true);
                tsMainScript.ClickOverlay.SetActive(true);
            }
            else
            {
                AudioManager.Instance.PlayBGM(BGMID.Further_Investigation_2009);
                tsSpritesManager.BackgroundUpdate("EverfreeCrimeScene");
                detectiveSystem.currentBackgroundPos = 0;
                tsSpritesManager.everfreecrimeScene.GetComponent<Transform>().DOMoveX(12.06f, 0);
                investSpots.GetComponent<RectTransform>().DOLocalMoveX(1288, 0);
                detectiveSystem.currentBackgroundPos = 0;
            }
            tsSpritesManager.TwilightStandConfused.GetComponent<SpriteRenderer>().DOFade(0, 0);
            ProceedText(isContinue, false);
        }
        else if (eventID == 52)
        {
            tsMainScript.DialogIndex = 53;
            if (!isContinue)
            {
                tsMainScript.Clickable = false;
                tsSpritesManager.dialogBox.SetActive(false);
                tsSpritesManager.TwilightStandConfused.SetActive(true);
                tsSpritesManager.TwilightStandConfused.GetComponent<SpriteRenderer>().DOFade(1, .25f);
                Invoke("Event52Delay", .26f);
            }
            else
            {
                AudioManager.Instance.PlayBGM(BGMID.Further_Investigation_2009);
                tsMainScript.Clickable = true;
                tsSpritesManager.dialogBox.SetActive(true);
                tsSpritesManager.BackgroundUpdate("EverfreeCrimeScene");
                tsSpritesManager.TwilightStandConfused.SetActive(true);
                ProceedText(true, false);
                tsSpritesManager.everfreecrimeScene.GetComponent<Transform>().DOMoveX(12.06f, 0);
                investSpots.GetComponent<RectTransform>().DOLocalMoveX(1288, 0);
                detectiveSystem.currentBackgroundPos = 0;
            }
        }
        else if (eventID == 53)
        {
            tsMainScript.DialogIndex = 54;
            if (isContinue)
            {
                AudioManager.Instance.PlayBGM(BGMID.Further_Investigation_2009);
                tsMainScript.Clickable = true;
                tsSpritesManager.dialogBox.SetActive(true);
                tsSpritesManager.BackgroundUpdate("EverfreeCrimeScene");
                tsSpritesManager.TwilightStandConfused.SetActive(true);
                tsSpritesManager.everfreecrimeScene.GetComponent<Transform>().DOMoveX(12.06f, 0);
                investSpots.GetComponent<RectTransform>().DOLocalMoveX(1288, 0);
                detectiveSystem.currentBackgroundPos = 0;
            }
            ProceedText(isContinue, false);
        }
        else if (eventID == 54)
        {
            tsMainScript.DialogIndex = 55;
            if (!isContinue)
            {
                tsSpritesManager.TwilightStandConfused.SetActive(false);
            }
            else
            {
                AudioManager.Instance.PlayBGM(BGMID.Further_Investigation_2009);
                tsMainScript.Clickable = true;
                tsSpritesManager.dialogBox.SetActive(true);
                tsSpritesManager.BackgroundUpdate("EverfreeCrimeScene");
                tsSpritesManager.everfreecrimeScene.GetComponent<Transform>().DOMoveX(12.06f, 0);
                investSpots.GetComponent<RectTransform>().DOLocalMoveX(1288, 0);
                detectiveSystem.currentBackgroundPos = 0;
            }
            tsSpritesManager.TwilightStandNormal.SetActive(true);
            ProceedText(isContinue, false);
        }
        else if (eventID == 55)
        {
            tsMainScript.DialogIndex = 56;
            if (isContinue)
            {
                AudioManager.Instance.PlayBGM(BGMID.Further_Investigation_2009);
                tsMainScript.Clickable = true;
                tsSpritesManager.dialogBox.SetActive(true);
                tsSpritesManager.BackgroundUpdate("EverfreeCrimeScene");
                tsSpritesManager.TwilightStandNormal.SetActive(true);
                tsSpritesManager.everfreecrimeScene.GetComponent<Transform>().DOMoveX(12.06f, 0);
                investSpots.GetComponent<RectTransform>().DOLocalMoveX(1288, 0);
                detectiveSystem.currentBackgroundPos = 0;
            }
            ProceedText(isContinue, false);
        }
        else if (eventID == 56)
        {
            tsMainScript.DialogIndex = 57;
            if (!isContinue)
            {
                tsSpritesManager.TwilightStandNormal.SetActive(false);
            }
            else
            {
                AudioManager.Instance.PlayBGM(BGMID.Further_Investigation_2009);
                tsMainScript.Clickable = true;
                tsSpritesManager.dialogBox.SetActive(true);
                tsSpritesManager.BackgroundUpdate("EverfreeCrimeScene");
                tsSpritesManager.everfreecrimeScene.GetComponent<Transform>().DOMoveX(12.06f, 0);
                investSpots.GetComponent<RectTransform>().DOLocalMoveX(1288, 0);
                detectiveSystem.currentBackgroundPos = 0;
            }
            tsSpritesManager.TwilightStandConfused.SetActive(true);
            ProceedText(isContinue, false);
        }
        else if (eventID == 57)
        {
            if (!isContinue)
            {
                if (courtRecordsSystem.DoIHaveThisEvidence(6))
                {
                    tsMainScript.EventID = 58;
                    tsMainScript.Proceed = true;
                }
                else
                {
                    AudioManager.Instance.PlaySE(SEID.se_com_017);
                    tsSpritesManager.NameTag.SetActive(false);
                    tsMainScript.DialogIndex = 58;
                    courtRecordsSystem.GetNewEvidence(6);
                    courtRecordsSystem.NewEvidenceShow();
                    tsMainScript.CourtRecordsHideOverlay.SetActive(true);
                    ProceedText(false, false);
                }
            }
            else
            {
                AudioManager.Instance.PlayBGM(BGMID.Further_Investigation_2009);
                tsMainScript.DialogIndex = 58;
                tsMainScript.Clickable = true;
                tsSpritesManager.NameTag.SetActive(false);
                tsSpritesManager.dialogBox.SetActive(true);
                tsSpritesManager.BackgroundUpdate("EverfreeCrimeScene");
                tsSpritesManager.TwilightStandConfused.SetActive(true);
                ProceedText(true, false);
                tsSpritesManager.everfreecrimeScene.GetComponent<Transform>().DOMoveX(12.06f, 0);
                investSpots.GetComponent<RectTransform>().DOLocalMoveX(1288, 0);
                detectiveSystem.currentBackgroundPos = 0;
            }
        }
        else if (eventID == 58)
        {
            tsMainScript.DialogIndex = 59;
            if (!isContinue)
            {
                tsSpritesManager.NameTag.SetActive(true);
                tsSpritesManager.TwilightStandConfused.SetActive(false);
            }
            else
            {
                AudioManager.Instance.PlayBGM(BGMID.Further_Investigation_2009);
                tsMainScript.Clickable = true;
                tsSpritesManager.dialogBox.SetActive(true);
                tsSpritesManager.BackgroundUpdate("EverfreeCrimeScene");
                tsSpritesManager.everfreecrimeScene.GetComponent<Transform>().DOMoveX(12.06f, 0);
                investSpots.GetComponent<RectTransform>().DOLocalMoveX(1288, 0);
                detectiveSystem.currentBackgroundPos = 0;
            }
            tsSpritesManager.TwilightStandNormal.SetActive(true);
            ProceedText(isContinue, false);
        }
        else if (eventID == 59)
        {
            tsMainScript.DialogIndex = 60;
            if (isContinue)
            {
                AudioManager.Instance.PlayBGM(BGMID.Further_Investigation_2009);
                tsMainScript.Clickable = true;
                tsSpritesManager.dialogBox.SetActive(true);
                tsSpritesManager.BackgroundUpdate("EverfreeCrimeScene");
                tsSpritesManager.TwilightStandNormal.SetActive(true);
                tsSpritesManager.everfreecrimeScene.GetComponent<Transform>().DOMoveX(12.06f, 0);
                investSpots.GetComponent<RectTransform>().DOLocalMoveX(1288, 0);
                detectiveSystem.currentBackgroundPos = 0;
            }
            ProceedText(isContinue, false);
            tsMainScript.EventID = 90590;
        }
        else if (eventID == 90590)
        {
            tsMainScript.EventID = 59;
            tsMainScript.ProceedGame(tsMainScript.ChapterID, tsMainScript.AreaID, true);
        }
        else if (eventID == 90591)
        {
            if (!tsMainScript.completedInvest.Contains(2))
            {
                tsMainScript.completedInvest.Add(2);
            }
            tsMainScript.EventID = 99990;
            currentCharaSpr = tsSpritesManager.TwilightStandNormal.GetComponent<SpriteRenderer>();
            tsMainScript.ProceedGame(tsMainScript.ChapterID, tsMainScript.AreaID, false);
        }
        else if (eventID == 60)
        {
            tsMainScript.DialogIndex = 61;
            if (!isContinue)
            {
                tsMainScript.Clickable = false;
                tsSpritesManager.WhiteScreen.GetComponent<Image>().DOFade(0, 0);
                Invoke("Event60Delay", .26f);
                Invoke("Event60Delay2", .51f);
                Invoke("Event60Delay3", 1.01f);
            }
            else
            {
                AudioManager.Instance.PlayBGM(BGMID.Further_Investigation_2009);
                tsMainScript.Clickable = true;
                tsSpritesManager.dialogBox.SetActive(true);
                tsSpritesManager.BackgroundUpdate("EverfreeCrimeScene");
                ProceedText(true, false);
                tsSpritesManager.everfreecrimeScene.GetComponent<Transform>().DOMoveX(-12.06f, 0);
                investSpots.GetComponent<RectTransform>().DOLocalMoveX(-1288, 0);
                detectiveSystem.currentBackgroundPos = 2;
            }
        }
        else if (eventID == 61)
        {
            tsMainScript.DialogIndex = 62;
            tsSpritesManager.TwilightStandNormal.SetActive(true);
            if (!isContinue)
            {
                tsMainScript.Clickable = false;
                tsSpritesManager.TwilightStandNormal.GetComponent<SpriteRenderer>().DOFade(1, .25f);
                Invoke("Event61Delay", .26f);
            }
            else
            {
                AudioManager.Instance.PlayBGM(BGMID.Further_Investigation_2009);
                tsMainScript.Clickable = true;
                tsSpritesManager.dialogBox.SetActive(true);
                tsSpritesManager.BackgroundUpdate("EverfreeCrimeScene");
                ProceedText(true, false);
                tsSpritesManager.everfreecrimeScene.GetComponent<Transform>().DOMoveX(-12.06f, 0);
                investSpots.GetComponent<RectTransform>().DOLocalMoveX(-1288, 0);
                detectiveSystem.currentBackgroundPos = 2;
            }
        }
        else if (eventID == 62)
        {
            tsMainScript.DialogIndex = 63;
            if (isContinue)
            {
                AudioManager.Instance.PlayBGM(BGMID.Further_Investigation_2009);
                tsMainScript.Clickable = true;
                tsSpritesManager.dialogBox.SetActive(true);
                tsSpritesManager.BackgroundUpdate("EverfreeCrimeScene");
                tsSpritesManager.TwilightStandNormal.SetActive(true);
                tsSpritesManager.everfreecrimeScene.GetComponent<Transform>().DOMoveX(-12.06f, 0);
                investSpots.GetComponent<RectTransform>().DOLocalMoveX(-1288, 0);
                detectiveSystem.currentBackgroundPos = 2;
            }
            ProceedText(isContinue, false);
        }
        else if (eventID == 63)
        {
            tsMainScript.DialogIndex = 64;
            if (!isContinue)
            {
                tsSpritesManager.TwilightStandNormal.SetActive(false);
            }
            else
            {
                AudioManager.Instance.PlayBGM(BGMID.Further_Investigation_2009);
                tsMainScript.Clickable = true;
                tsSpritesManager.dialogBox.SetActive(true);
                tsSpritesManager.BackgroundUpdate("EverfreeCrimeScene");
                tsSpritesManager.everfreecrimeScene.GetComponent<Transform>().DOMoveX(-12.06f, 0);
                investSpots.GetComponent<RectTransform>().DOLocalMoveX(-1288, 0);
                detectiveSystem.currentBackgroundPos = 2;
            }
            tsSpritesManager.TwilightStandConfused.SetActive(true);
            ProceedText(isContinue, false);
        }
        else if (eventID == 64)
        {
            tsMainScript.DialogIndex = 65;
            if (!isContinue)
            {
                tsSpritesManager.TwilightStandConfused.SetActive(false);
            }
            else
            {
                AudioManager.Instance.PlayBGM(BGMID.Further_Investigation_2009);
                tsMainScript.Clickable = true;
                tsSpritesManager.dialogBox.SetActive(true);
                tsSpritesManager.BackgroundUpdate("EverfreeCrimeScene");
                tsSpritesManager.everfreecrimeScene.GetComponent<Transform>().DOMoveX(-12.06f, 0);
                investSpots.GetComponent<RectTransform>().DOLocalMoveX(-1288, 0);
                detectiveSystem.currentBackgroundPos = 2;
            }
            tsSpritesManager.TwilightStandNormal.SetActive(true);
            ProceedText(isContinue, false);
        }
        else if (eventID == 65)
        {
            tsMainScript.DialogIndex = 66;
            if (!isContinue)
            {
                tsSpritesManager.TwilightStandNormal.SetActive(false);
            }
            else
            {
                AudioManager.Instance.PlayBGM(BGMID.Further_Investigation_2009);
                tsMainScript.Clickable = true;
                tsSpritesManager.dialogBox.SetActive(true);
                tsSpritesManager.BackgroundUpdate("EverfreeCrimeScene");
                tsSpritesManager.everfreecrimeScene.GetComponent<Transform>().DOMoveX(-12.06f, 0);
                investSpots.GetComponent<RectTransform>().DOLocalMoveX(-1288, 0);
                detectiveSystem.currentBackgroundPos = 2;
            }
            tsSpritesManager.TwilightStandConfused.SetActive(true);
            ProceedText(isContinue, false);
        }
        else if (eventID == 66)
        {
            tsMainScript.DialogIndex = 67;
            if (!isContinue)
            {
                tsSpritesManager.TwilightStandConfused.SetActive(false);
            }
            else
            {
                AudioManager.Instance.PlayBGM(BGMID.Further_Investigation_2009);
                tsMainScript.Clickable = true;
                tsSpritesManager.dialogBox.SetActive(true);
                tsSpritesManager.BackgroundUpdate("EverfreeCrimeScene");
                tsSpritesManager.everfreecrimeScene.GetComponent<Transform>().DOMoveX(-12.06f, 0);
                investSpots.GetComponent<RectTransform>().DOLocalMoveX(-1288, 0);
                detectiveSystem.currentBackgroundPos = 2;
            }
            tsSpritesManager.TwilightStandNormal.SetActive(true);
            ProceedText(isContinue, false);
        }
        else if (eventID == 67)
        {
            tsMainScript.DialogIndex = 68;
            if (isContinue)
            {
                AudioManager.Instance.PlayBGM(BGMID.Further_Investigation_2009);
                tsMainScript.Clickable = true;
                tsSpritesManager.dialogBox.SetActive(true);
                tsSpritesManager.BackgroundUpdate("EverfreeCrimeScene");
                tsSpritesManager.TwilightStandNormal.SetActive(true);
                tsSpritesManager.everfreecrimeScene.GetComponent<Transform>().DOMoveX(-12.06f, 0);
                investSpots.GetComponent<RectTransform>().DOLocalMoveX(-1288, 0);
                detectiveSystem.currentBackgroundPos = 2;
            }
            ProceedText(isContinue, false);
        }
        else if (eventID == 68)
        {
            tsMainScript.DialogIndex = 69;
            if (isContinue)
            {
                AudioManager.Instance.PlayBGM(BGMID.Further_Investigation_2009);
                tsMainScript.Clickable = true;
                tsSpritesManager.dialogBox.SetActive(true);
                tsSpritesManager.BackgroundUpdate("EverfreeCrimeScene");
                tsSpritesManager.TwilightStandNormal.SetActive(true);
                tsSpritesManager.everfreecrimeScene.GetComponent<Transform>().DOMoveX(-12.06f, 0);
                investSpots.GetComponent<RectTransform>().DOLocalMoveX(-1288, 0);
                detectiveSystem.currentBackgroundPos = 2;
            }
            ProceedText(isContinue, false);
        }
        else if (eventID == 69)
        {
            tsMainScript.DialogIndex = 70;
            if (!isContinue)
            {
                tsSpritesManager.TwilightStandNormal.SetActive(false);
            }
            else
            {
                AudioManager.Instance.PlayBGM(BGMID.Further_Investigation_2009);
                tsMainScript.Clickable = true;
                tsSpritesManager.dialogBox.SetActive(true);
                tsSpritesManager.BackgroundUpdate("EverfreeCrimeScene");
                tsSpritesManager.everfreecrimeScene.GetComponent<Transform>().DOMoveX(-12.06f, 0);
                investSpots.GetComponent<RectTransform>().DOLocalMoveX(-1288, 0);
                detectiveSystem.currentBackgroundPos = 2;
            }
            tsSpritesManager.TwilightStandConfused.SetActive(true);
            ProceedText(isContinue, false);
        }
        else if (eventID == 70)
        {
            tsMainScript.DialogIndex = 71;
            if (!isContinue)
            {
                tsSpritesManager.TwilightStandConfused.SetActive(false);
            }
            else
            {
                AudioManager.Instance.PlayBGM(BGMID.Further_Investigation_2009);
                tsMainScript.Clickable = true;
                tsSpritesManager.dialogBox.SetActive(true);
                tsSpritesManager.BackgroundUpdate("EverfreeCrimeScene");
                tsSpritesManager.everfreecrimeScene.GetComponent<Transform>().DOMoveX(-12.06f, 0);
                investSpots.GetComponent<RectTransform>().DOLocalMoveX(-1288, 0);
                detectiveSystem.currentBackgroundPos = 2;
            }
            tsSpritesManager.TwilightStandNormal.SetActive(true);
            ProceedText(isContinue, false);
        }
        else if (eventID == 71)
        {
            tsMainScript.DialogIndex = 72;
            if (isContinue)
            {
                AudioManager.Instance.PlayBGM(BGMID.Further_Investigation_2009);
                tsMainScript.Clickable = true;
                tsSpritesManager.dialogBox.SetActive(true);
                tsSpritesManager.BackgroundUpdate("EverfreeCrimeScene");
                tsSpritesManager.TwilightStandNormal.SetActive(true);
                tsSpritesManager.everfreecrimeScene.GetComponent<Transform>().DOMoveX(-12.06f, 0);
                investSpots.GetComponent<RectTransform>().DOLocalMoveX(-1288, 0);
                detectiveSystem.currentBackgroundPos = 2;
            }
            ProceedText(isContinue, false);
        }
        else if (eventID == 72)
        {
            tsMainScript.DialogIndex = 73;
            if (!isContinue)
            {
                tsSpritesManager.TwilightStandNormal.SetActive(false);
            }
            else
            {
                AudioManager.Instance.PlayBGM(BGMID.Further_Investigation_2009);
                tsMainScript.Clickable = true;
                tsSpritesManager.dialogBox.SetActive(true);
                tsSpritesManager.BackgroundUpdate("EverfreeCrimeScene");
                tsSpritesManager.everfreecrimeScene.GetComponent<Transform>().DOMoveX(-12.06f, 0);
                investSpots.GetComponent<RectTransform>().DOLocalMoveX(-1288, 0);
                detectiveSystem.currentBackgroundPos = 2;
            }
            tsSpritesManager.TwilightStandHappy.SetActive(true);
            ProceedText(isContinue, false);
        }
        else if (eventID == 73)
        {
            tsMainScript.DialogIndex = 74;
            if (isContinue)
            {
                AudioManager.Instance.PlayBGM(BGMID.Further_Investigation_2009);
                tsMainScript.Clickable = true;
                tsSpritesManager.dialogBox.SetActive(true);
                tsSpritesManager.BackgroundUpdate("EverfreeCrimeScene");
                tsSpritesManager.TwilightStandHappy.SetActive(true);
                tsSpritesManager.everfreecrimeScene.GetComponent<Transform>().DOMoveX(-12.06f, 0);
                investSpots.GetComponent<RectTransform>().DOLocalMoveX(-1288, 0);
                detectiveSystem.currentBackgroundPos = 2;
            }
            ProceedText(isContinue, false);
        }
        else if (eventID == 74)
        {
            tsMainScript.DialogIndex = 75;
            if (isContinue)
            {
                AudioManager.Instance.PlayBGM(BGMID.Further_Investigation_2009);
                tsMainScript.Clickable = true;
                tsSpritesManager.dialogBox.SetActive(true);
                tsSpritesManager.BackgroundUpdate("EverfreeCrimeScene");
                tsSpritesManager.TwilightStandHappy.SetActive(true);
                tsSpritesManager.everfreecrimeScene.GetComponent<Transform>().DOMoveX(-12.06f, 0);
                investSpots.GetComponent<RectTransform>().DOLocalMoveX(-1288, 0);
                detectiveSystem.currentBackgroundPos = 2;
            }
            ProceedText(isContinue, false);
            tsMainScript.EventID = 90740;
        }
        else if (eventID == 90740)
        {
            tsMainScript.EventID = 74;
            tsMainScript.ProceedGame(tsMainScript.ChapterID, tsMainScript.AreaID, true);
        }
        else if (eventID == 90741)
        {
            if (!tsMainScript.completedInvest.Contains(3) && tsMainScript.completedInvest.Contains(4))
            {
                tsMainScript.completedInvest.Add(3);
                tsMainScript.EventID = 105;
                tsMainScript.ProceedGame(tsMainScript.ChapterID, tsMainScript.AreaID, false);
            }
            else
            {
                if (!tsMainScript.completedInvest.Contains(3))
                {
                    tsMainScript.completedInvest.Add(3);
                }
                tsMainScript.EventID = 99990;
                currentCharaSpr = tsSpritesManager.TwilightStandHappy.GetComponent<SpriteRenderer>();
                tsMainScript.ProceedGame(tsMainScript.ChapterID, tsMainScript.AreaID, false);
            }
        }
        else if (eventID == 75)
        {
            tsMainScript.DialogIndex = 76;
            if (!isContinue)
            {
                tsMainScript.Clickable = false;
                tsSpritesManager.TwilightStandExplain.GetComponent<SpriteRenderer>().DOFade(0, 0);
                Invoke("Event75Delay", .26f);
                Invoke("Event75Delay2", .51f);
            }
            else
            {
                AudioManager.Instance.PlayBGM(BGMID.Further_Investigation_2009);
                tsMainScript.Clickable = true;
                tsSpritesManager.dialogBox.SetActive(true);
                tsSpritesManager.BackgroundUpdate("EverfreeCrimeScene");
                tsSpritesManager.TwilightStandExplain.SetActive(true);
                ProceedText(true, false);
                tsSpritesManager.everfreecrimeScene.GetComponent<Transform>().DOMoveX(-12.06f, 0);
                investSpots.GetComponent<RectTransform>().DOLocalMoveX(-1288, 0);
                detectiveSystem.currentBackgroundPos = 2;
            }
        }
        else if (eventID == 76)
        {
            tsMainScript.DialogIndex = 77;
            if (isContinue)
            {
                AudioManager.Instance.PlayBGM(BGMID.Further_Investigation_2009);
                tsMainScript.Clickable = true;
                tsSpritesManager.dialogBox.SetActive(true);
                tsSpritesManager.BackgroundUpdate("EverfreeCrimeScene");
                tsSpritesManager.everfreecrimeScene.GetComponent<Transform>().DOMoveX(-12.06f, 0);
                investSpots.GetComponent<RectTransform>().DOLocalMoveX(-1288, 0);
                detectiveSystem.currentBackgroundPos = 2;
            }
            tsSpritesManager.TwilightStandExplain.SetActive(true);
            ProceedText(isContinue, false);
        }
        else if (eventID == 77)
        {
            tsMainScript.DialogIndex = 78;
            if (!isContinue)
            {
                tsSpritesManager.TwilightStandExplain.SetActive(false);
            }
            else
            {
                AudioManager.Instance.PlayBGM(BGMID.Further_Investigation_2009);
                tsMainScript.Clickable = true;
                tsSpritesManager.dialogBox.SetActive(true);
                tsSpritesManager.BackgroundUpdate("EverfreeCrimeScene");
                tsSpritesManager.everfreecrimeScene.GetComponent<Transform>().DOMoveX(-12.06f, 0);
                investSpots.GetComponent<RectTransform>().DOLocalMoveX(-1288, 0);
                detectiveSystem.currentBackgroundPos = 2;
            }
            tsSpritesManager.TwilightStandHappy.SetActive(true);
            ProceedText(isContinue, false);
        }
        else if (eventID == 78)
        {
            tsMainScript.DialogIndex = 79;
            if (!isContinue)
            {
                tsMainScript.Clickable = false;
                tsSpritesManager.dialogBox.SetActive(false);
                tsSpritesManager.TwilightStandHappy.GetComponent<SpriteRenderer>().DOFade(0, .25f);
                Invoke("Event78Delay", .26f);
                Invoke("Event78Delay2", 2.08f);
            }
            else
            {
                AudioManager.Instance.PlayBGM(BGMID.Further_Investigation_2009);
                tsMainScript.Clickable = true;
                tsSpritesManager.dialogBox.SetActive(true);
                tsSpritesManager.BackgroundUpdate("EverfreeCrimeScene");
                ProceedText(true, false);
                tsSpritesManager.everfreecrimeScene.GetComponent<Transform>().DOMoveX(-12.06f, 0);
                investSpots.GetComponent<RectTransform>().DOLocalMoveX(-1288, 0);
                detectiveSystem.currentBackgroundPos = 2;
            }
        }
        else if (eventID == 79)
        {
            tsMainScript.DialogIndex = 80;
            tsSpritesManager.brownFeather.SetActive(true);
            tsSpritesManager.ItemHolder.SetActive(true);
            if (!isContinue)
            {
                AudioManager.Instance.PlaySE(SEID.item_pop);
                tsMainScript.Clickable = false;
                Invoke("Event79Delay", .83f);
            }
            else
            {
                AudioManager.Instance.PlayBGM(BGMID.Further_Investigation_2009);
                tsMainScript.Clickable = true;
                tsSpritesManager.dialogBox.SetActive(true);
                tsSpritesManager.BackgroundUpdate("EverfreeCrimeScene");
                ProceedText(true, false);
                tsSpritesManager.everfreecrimeScene.GetComponent<Transform>().DOMoveX(-12.06f, 0);
                investSpots.GetComponent<RectTransform>().DOLocalMoveX(-1288, 0);
                detectiveSystem.currentBackgroundPos = 2;
            }
        }
        else if (eventID == 80)
        {
            tsMainScript.DialogIndex = 81;
            tsSpritesManager.TwilightStandNormal.GetComponent<SpriteRenderer>().DOFade(0, 0);
            if (isContinue)
            {
                AudioManager.Instance.PlayBGM(BGMID.Further_Investigation_2009);
                tsMainScript.Clickable = true;
                tsSpritesManager.dialogBox.SetActive(true);
                tsSpritesManager.BackgroundUpdate("EverfreeCrimeScene");
                tsSpritesManager.brownFeather.SetActive(true);
                tsSpritesManager.ItemHolder.SetActive(true);
                tsSpritesManager.everfreecrimeScene.GetComponent<Transform>().DOMoveX(-12.06f, 0);
                investSpots.GetComponent<RectTransform>().DOLocalMoveX(-1288, 0);
                detectiveSystem.currentBackgroundPos = 2;
            }
            ProceedText(isContinue, false);
        }
        else if (eventID == 81)
        {
            tsMainScript.DialogIndex = 82;
            tsSpritesManager.TwilightStandNormal.SetActive(true);
            if (!isContinue)
            {
                tsMainScript.Clickable = false;
                tsSpritesManager.TwilightStandNormal.GetComponent<SpriteRenderer>().DOFade(1, .25f);
                Invoke("Event81Delay", .5f);
            }
            else
            {
                AudioManager.Instance.PlayBGM(BGMID.Further_Investigation_2009);
                tsMainScript.Clickable = true;
                tsSpritesManager.dialogBox.SetActive(true);
                tsSpritesManager.BackgroundUpdate("EverfreeCrimeScene");
                tsSpritesManager.brownFeather.SetActive(true);
                tsSpritesManager.ItemHolder.SetActive(true);
                ProceedText(true, false);
                tsSpritesManager.everfreecrimeScene.GetComponent<Transform>().DOMoveX(-12.06f, 0);
                investSpots.GetComponent<RectTransform>().DOLocalMoveX(-1288, 0);
                detectiveSystem.currentBackgroundPos = 2;
            }
        }
        else if (eventID == 82)
        {
            tsMainScript.DialogIndex = 83;
            if (isContinue)
            {
                AudioManager.Instance.PlayBGM(BGMID.Further_Investigation_2009);
                tsMainScript.Clickable = true;
                tsSpritesManager.dialogBox.SetActive(true);
                tsSpritesManager.BackgroundUpdate("EverfreeCrimeScene");
                tsSpritesManager.TwilightStandNormal.SetActive(true);
                tsSpritesManager.brownFeather.SetActive(true);
                tsSpritesManager.ItemHolder.SetActive(true);
                tsSpritesManager.everfreecrimeScene.GetComponent<Transform>().DOMoveX(-12.06f, 0);
                investSpots.GetComponent<RectTransform>().DOLocalMoveX(-1288, 0);
                detectiveSystem.currentBackgroundPos = 2;
            }
            ProceedText(isContinue, false);
        }
        else if (eventID == 83)
        {
            tsMainScript.DialogIndex = 84;
            if (isContinue)
            {
                AudioManager.Instance.PlayBGM(BGMID.Further_Investigation_2009);
                tsMainScript.Clickable = true;
                tsSpritesManager.dialogBox.SetActive(true);
                tsSpritesManager.BackgroundUpdate("EverfreeCrimeScene");
                tsSpritesManager.TwilightStandNormal.SetActive(true);
                tsSpritesManager.brownFeather.SetActive(true);
                tsSpritesManager.ItemHolder.SetActive(true);
                tsSpritesManager.everfreecrimeScene.GetComponent<Transform>().DOMoveX(-12.06f, 0);
                investSpots.GetComponent<RectTransform>().DOLocalMoveX(-1288, 0);
                detectiveSystem.currentBackgroundPos = 2;
            }
            ProceedText(isContinue, false);
        }
        else if (eventID == 84)
        {
            tsMainScript.DialogIndex = 85;
            if (isContinue)
            {
                AudioManager.Instance.PlayBGM(BGMID.Further_Investigation_2009);
                tsMainScript.Clickable = true;
                tsSpritesManager.dialogBox.SetActive(true);
                tsSpritesManager.BackgroundUpdate("EverfreeCrimeScene");
                tsSpritesManager.TwilightStandNormal.SetActive(true);
                tsSpritesManager.brownFeather.SetActive(true);
                tsSpritesManager.ItemHolder.SetActive(true);
                tsSpritesManager.everfreecrimeScene.GetComponent<Transform>().DOMoveX(-12.06f, 0);
                investSpots.GetComponent<RectTransform>().DOLocalMoveX(-1288, 0);
                detectiveSystem.currentBackgroundPos = 2;
            }
            ProceedText(isContinue, false);
        }
        else if (eventID == 85)
        {
            if (!isContinue)
            {
                tsSpritesManager.ItemHolder.SetActive(false);
                tsSpritesManager.brownFeather.SetActive(false);
                if (courtRecordsSystem.DoIHaveThisEvidence(7))
                {
                    tsMainScript.EventID = 86;
                    tsMainScript.Proceed = true;
                }
                else
                {
                    AudioManager.Instance.PlaySE(SEID.se_com_017);
                    tsSpritesManager.NameTag.SetActive(false);
                    tsMainScript.DialogIndex = 86;
                    courtRecordsSystem.GetNewEvidence(7);
                    courtRecordsSystem.NewEvidenceShow();
                    tsMainScript.CourtRecordsHideOverlay.SetActive(true);
                    ProceedText(false, false);
                }
            }
            else
            {
                AudioManager.Instance.PlayBGM(BGMID.Further_Investigation_2009);
                tsMainScript.DialogIndex = 86;
                tsMainScript.Clickable = true;
                tsSpritesManager.NameTag.SetActive(false);
                tsSpritesManager.dialogBox.SetActive(true);
                tsSpritesManager.BackgroundUpdate("EverfreeCrimeScene");
                tsSpritesManager.TwilightStandNormal.SetActive(true);
                ProceedText(true, false);
            }
        }
        else if (eventID == 86)
        {
            tsMainScript.DialogIndex = 87;
            if (!isContinue)
            {
                tsSpritesManager.NameTag.SetActive(true);
            }
            else
            {
                AudioManager.Instance.PlayBGM(BGMID.Further_Investigation_2009);
                tsMainScript.Clickable = true;
                tsSpritesManager.dialogBox.SetActive(true);
                tsSpritesManager.BackgroundUpdate("EverfreeCrimeScene");
                tsSpritesManager.TwilightStandNormal.SetActive(true);
                tsSpritesManager.everfreecrimeScene.GetComponent<Transform>().DOMoveX(-12.06f, 0);
                investSpots.GetComponent<RectTransform>().DOLocalMoveX(-1288, 0);
                detectiveSystem.currentBackgroundPos = 2;
            }
            ProceedText(isContinue, false);
        }
        else if (eventID == 87)
        {
            tsMainScript.DialogIndex = 88;
            tsSpritesManager.TwilightStandConfused.SetActive(true);
            if (!isContinue)
            {
                tsSpritesManager.TwilightStandNormal.SetActive(false);
            }
            else
            {
                AudioManager.Instance.PlayBGM(BGMID.Further_Investigation_2009);
                tsMainScript.Clickable = true;
                tsSpritesManager.dialogBox.SetActive(true);
                tsSpritesManager.BackgroundUpdate("EverfreeCrimeScene");
                tsSpritesManager.everfreecrimeScene.GetComponent<Transform>().DOMoveX(-12.06f, 0);
                investSpots.GetComponent<RectTransform>().DOLocalMoveX(-1288, 0);
                detectiveSystem.currentBackgroundPos = 2;
            }
            ProceedText(isContinue, false);
        }
        else if (eventID == 88)
        {
            tsMainScript.DialogIndex = 89;
            if (isContinue)
            {
                AudioManager.Instance.PlayBGM(BGMID.Further_Investigation_2009);
                tsMainScript.Clickable = true;
                tsSpritesManager.dialogBox.SetActive(true);
                tsSpritesManager.BackgroundUpdate("EverfreeCrimeScene");
                tsSpritesManager.TwilightStandConfused.SetActive(true);
                tsSpritesManager.everfreecrimeScene.GetComponent<Transform>().DOMoveX(-12.06f, 0);
                investSpots.GetComponent<RectTransform>().DOLocalMoveX(-1288, 0);
                detectiveSystem.currentBackgroundPos = 2;
            }
            ProceedText(isContinue, false);
        }
        else if (eventID == 89)
        {
            tsMainScript.DialogIndex = 90;
            if (isContinue)
            {
                AudioManager.Instance.PlayBGM(BGMID.Further_Investigation_2009);
                tsMainScript.Clickable = true;
                tsSpritesManager.dialogBox.SetActive(true);
                tsSpritesManager.BackgroundUpdate("EverfreeCrimeScene");
                tsSpritesManager.TwilightStandConfused.SetActive(true);
                tsSpritesManager.everfreecrimeScene.GetComponent<Transform>().DOMoveX(-12.06f, 0);
                investSpots.GetComponent<RectTransform>().DOLocalMoveX(-1288, 0);
                detectiveSystem.currentBackgroundPos = 2;
            }
            ProceedText(isContinue, false);
        }
        else if (eventID == 90)
        {
            tsMainScript.DialogIndex = 91;
            tsSpritesManager.TwilightStandExplain.SetActive(true);
            if (!isContinue)
            {
                tsSpritesManager.TwilightStandConfused.SetActive(false);
            }
            else
            {
                AudioManager.Instance.PlayBGM(BGMID.Further_Investigation_2009);
                tsMainScript.Clickable = true;
                tsSpritesManager.dialogBox.SetActive(true);
                tsSpritesManager.BackgroundUpdate("EverfreeCrimeScene");
                tsSpritesManager.everfreecrimeScene.GetComponent<Transform>().DOMoveX(-12.06f, 0);
                investSpots.GetComponent<RectTransform>().DOLocalMoveX(-1288, 0);
                detectiveSystem.currentBackgroundPos = 2;
            }
            ProceedText(isContinue, false);
        }
        else if (eventID == 91)
        {
            tsMainScript.DialogIndex = 92;
            tsSpritesManager.TwilightStandNormal.SetActive(true);
            if (!isContinue)
            {
                tsSpritesManager.TwilightStandExplain.SetActive(false);
            }
            else
            {
                AudioManager.Instance.PlayBGM(BGMID.Further_Investigation_2009);
                tsMainScript.Clickable = true;
                tsSpritesManager.dialogBox.SetActive(true);
                tsSpritesManager.BackgroundUpdate("EverfreeCrimeScene");
                tsSpritesManager.everfreecrimeScene.GetComponent<Transform>().DOMoveX(-12.06f, 0);
                investSpots.GetComponent<RectTransform>().DOLocalMoveX(-1288, 0);
                detectiveSystem.currentBackgroundPos = 2;
            }
            ProceedText(isContinue, false);
        }
        else if (eventID == 92)
        {
            tsMainScript.DialogIndex = 93;
            if (isContinue)
            {
                AudioManager.Instance.PlayBGM(BGMID.Further_Investigation_2009);
                tsMainScript.Clickable = true;
                tsSpritesManager.dialogBox.SetActive(true);
                tsSpritesManager.BackgroundUpdate("EverfreeCrimeScene");
                tsSpritesManager.TwilightStandNormal.SetActive(true);
                tsSpritesManager.everfreecrimeScene.GetComponent<Transform>().DOMoveX(-12.06f, 0);
                investSpots.GetComponent<RectTransform>().DOLocalMoveX(-1288, 0);
                detectiveSystem.currentBackgroundPos = 2;
            }
            ProceedText(isContinue, false);
        }
        else if (eventID == 93)
        {
            tsMainScript.DialogIndex = 94;
            if (isContinue)
            {
                AudioManager.Instance.PlayBGM(BGMID.Further_Investigation_2009);
                tsMainScript.Clickable = true;
                tsSpritesManager.dialogBox.SetActive(true);
                tsSpritesManager.BackgroundUpdate("EverfreeCrimeScene");
                tsSpritesManager.TwilightStandNormal.SetActive(true);
                tsSpritesManager.everfreecrimeScene.GetComponent<Transform>().DOMoveX(-12.06f, 0);
                investSpots.GetComponent<RectTransform>().DOLocalMoveX(-1288, 0);
                detectiveSystem.currentBackgroundPos = 2;
            }
            ProceedText(isContinue, false);
        }
        else if (eventID == 94)
        {
            tsMainScript.DialogIndex = 95;
            tsSpritesManager.TwilightStandHappy.SetActive(true);
            if (!isContinue)
            {
                tsSpritesManager.TwilightStandNormal.SetActive(false);
            }
            else
            {
                AudioManager.Instance.PlayBGM(BGMID.Further_Investigation_2009);
                tsMainScript.Clickable = true;
                tsSpritesManager.dialogBox.SetActive(true);
                tsSpritesManager.BackgroundUpdate("EverfreeCrimeScene");
                tsSpritesManager.everfreecrimeScene.GetComponent<Transform>().DOMoveX(-12.06f, 0);
                investSpots.GetComponent<RectTransform>().DOLocalMoveX(-1288, 0);
                detectiveSystem.currentBackgroundPos = 2;
            }
            ProceedText(isContinue, false);
        }
        else if (eventID == 95)
        {
            tsMainScript.DialogIndex = 96;
            if (isContinue)
            {
                AudioManager.Instance.PlayBGM(BGMID.Further_Investigation_2009);
                tsMainScript.Clickable = true;
                tsSpritesManager.dialogBox.SetActive(true);
                tsSpritesManager.BackgroundUpdate("EverfreeCrimeScene");
                tsSpritesManager.TwilightStandHappy.SetActive(true);
                tsSpritesManager.everfreecrimeScene.GetComponent<Transform>().DOMoveX(-12.06f, 0);
                investSpots.GetComponent<RectTransform>().DOLocalMoveX(-1288, 0);
                detectiveSystem.currentBackgroundPos = 2;
            }
            ProceedText(isContinue, false);
        }
        else if (eventID == 96)
        {
            tsMainScript.DialogIndex = 97;
            tsSpritesManager.TwilightStandNormal.SetActive(true);
            if (!isContinue)
            {
                tsSpritesManager.TwilightStandHappy.SetActive(false);
            }
            else
            {
                AudioManager.Instance.PlayBGM(BGMID.Further_Investigation_2009);
                tsMainScript.Clickable = true;
                tsSpritesManager.dialogBox.SetActive(true);
                tsSpritesManager.BackgroundUpdate("EverfreeCrimeScene");
                tsSpritesManager.everfreecrimeScene.GetComponent<Transform>().DOMoveX(-12.06f, 0);
                investSpots.GetComponent<RectTransform>().DOLocalMoveX(-1288, 0);
                detectiveSystem.currentBackgroundPos = 2;
            }
            ProceedText(isContinue, false);
        }
        else if (eventID == 97)
        {
            tsMainScript.DialogIndex = 98;
            if (isContinue)
            {
                AudioManager.Instance.PlayBGM(BGMID.Further_Investigation_2009);
                tsMainScript.Clickable = true;
                tsSpritesManager.dialogBox.SetActive(true);
                tsSpritesManager.BackgroundUpdate("EverfreeCrimeScene");
                tsSpritesManager.TwilightStandNormal.SetActive(true);
                tsSpritesManager.everfreecrimeScene.GetComponent<Transform>().DOMoveX(-12.06f, 0);
                investSpots.GetComponent<RectTransform>().DOLocalMoveX(-1288, 0);
                detectiveSystem.currentBackgroundPos = 2;
            }
            ProceedText(isContinue, false);
        }
        else if (eventID == 98)
        {
            tsMainScript.DialogIndex = 99;
            if (isContinue)
            {
                AudioManager.Instance.PlayBGM(BGMID.Further_Investigation_2009);
                tsMainScript.Clickable = true;
                tsSpritesManager.dialogBox.SetActive(true);
                tsSpritesManager.BackgroundUpdate("EverfreeCrimeScene");
                tsSpritesManager.TwilightStandNormal.SetActive(true);
                tsSpritesManager.everfreecrimeScene.GetComponent<Transform>().DOMoveX(-12.06f, 0);
                investSpots.GetComponent<RectTransform>().DOLocalMoveX(-1288, 0);
                detectiveSystem.currentBackgroundPos = 2;
            }
            ProceedText(isContinue, false);
        }
        else if (eventID == 99)
        {
            tsMainScript.DialogIndex = 100;
            tsSpritesManager.TwilightStandConfused.SetActive(true);
            if (!isContinue)
            {
                tsSpritesManager.TwilightStandNormal.SetActive(false);
            }
            else
            {
                AudioManager.Instance.PlayBGM(BGMID.Further_Investigation_2009);
                tsMainScript.Clickable = true;
                tsSpritesManager.dialogBox.SetActive(true);
                tsSpritesManager.BackgroundUpdate("EverfreeCrimeScene");
                tsSpritesManager.everfreecrimeScene.GetComponent<Transform>().DOMoveX(-12.06f, 0);
                investSpots.GetComponent<RectTransform>().DOLocalMoveX(-1288, 0);
                detectiveSystem.currentBackgroundPos = 2;
            }
            ProceedText(isContinue, false);
        }
        else if (eventID == 100)
        {
            tsMainScript.DialogIndex = 101;
            tsSpritesManager.TwilightStandHappy.SetActive(true);
            if (!isContinue)
            {
                AudioManager.Instance.PlaySE(SEID.se_script_007);
                tsSpritesManager.TwilightStandConfused.SetActive(false);
            }
            else
            {
                AudioManager.Instance.PlayBGM(BGMID.Further_Investigation_2009);
                tsMainScript.Clickable = true;
                tsSpritesManager.dialogBox.SetActive(true);
                tsSpritesManager.BackgroundUpdate("EverfreeCrimeScene");
                tsSpritesManager.everfreecrimeScene.GetComponent<Transform>().DOMoveX(-12.06f, 0);
                investSpots.GetComponent<RectTransform>().DOLocalMoveX(-1288, 0);
                detectiveSystem.currentBackgroundPos = 2;
            }
            ProceedText(isContinue, false);
        }
        else if (eventID == 101)
        {
            tsMainScript.DialogIndex = 102;
            if (!isContinue)
            {
                tsMainScript.Clickable = false;
                Invoke("Event101Delay", 1.1f);
            }
            else
            {
                AudioManager.Instance.PlayBGM(BGMID.Further_Investigation_2009);
                tsMainScript.Clickable = true;
                tsSpritesManager.dialogBox.SetActive(true);
                tsSpritesManager.BackgroundUpdate("EverfreeCrimeScene");
                tsSpritesManager.TwilightStandNormal.SetActive(true);
                tsSpritesManager.everfreecrimeScene.GetComponent<Transform>().DOMoveX(-12.06f, 0);
                investSpots.GetComponent<RectTransform>().DOLocalMoveX(-1288, 0);
                detectiveSystem.currentBackgroundPos = 2;
            }
            ProceedText(isContinue, false);
        }
        else if (eventID == 102)
        {
            tsMainScript.DialogIndex = 103;
            if (isContinue)
            {
                AudioManager.Instance.PlayBGM(BGMID.Further_Investigation_2009);
                tsMainScript.Clickable = true;
                tsSpritesManager.dialogBox.SetActive(true);
                tsSpritesManager.BackgroundUpdate("EverfreeCrimeScene");
                tsSpritesManager.TwilightStandNormal.SetActive(true);
                tsSpritesManager.everfreecrimeScene.GetComponent<Transform>().DOMoveX(-12.06f, 0);
                investSpots.GetComponent<RectTransform>().DOLocalMoveX(-1288, 0);
                detectiveSystem.currentBackgroundPos = 2;
            }
            ProceedText(isContinue, false);
        }
        else if (eventID == 103)
        {
            tsMainScript.DialogIndex = 104;
            tsSpritesManager.TwilightStandConfused.SetActive(true);
            if (!isContinue)
            {
                tsSpritesManager.TwilightStandNormal.SetActive(false);
            }
            else
            {
                AudioManager.Instance.PlayBGM(BGMID.Further_Investigation_2009);
                tsMainScript.Clickable = true;
                tsSpritesManager.dialogBox.SetActive(true);
                tsSpritesManager.BackgroundUpdate("EverfreeCrimeScene");
                tsSpritesManager.everfreecrimeScene.GetComponent<Transform>().DOMoveX(-12.06f, 0);
                investSpots.GetComponent<RectTransform>().DOLocalMoveX(-1288, 0);
                detectiveSystem.currentBackgroundPos = 2;
            }
            ProceedText(isContinue, false);
        }
        else if (eventID == 104)
        {
            tsMainScript.DialogIndex = 105;
            tsSpritesManager.TwilightStandHappy.SetActive(true);
            if (!isContinue)
            {
                tsSpritesManager.TwilightStandConfused.SetActive(false);
            }
            else
            {
                AudioManager.Instance.PlayBGM(BGMID.Further_Investigation_2009);
                tsMainScript.Clickable = true;
                tsSpritesManager.dialogBox.SetActive(true);
                tsSpritesManager.BackgroundUpdate("EverfreeCrimeScene");
                tsSpritesManager.everfreecrimeScene.GetComponent<Transform>().DOMoveX(-12.06f, 0);
                investSpots.GetComponent<RectTransform>().DOLocalMoveX(-1288, 0);
                detectiveSystem.currentBackgroundPos = 2;
            }
            ProceedText(isContinue, false);
            tsMainScript.EventID = 91040;
        }
        else if (eventID == 91040)
        {
            tsMainScript.EventID = 104;
            tsMainScript.ProceedGame(tsMainScript.ChapterID, tsMainScript.AreaID, true);
        }
        else if (eventID == 91041)
        {
            if (!tsMainScript.completedInvest.Contains(4) && tsMainScript.completedInvest.Contains(3))
            {
                tsMainScript.completedInvest.Add(4);
                tsMainScript.EventID = 105;
                tsMainScript.ProceedGame(tsMainScript.ChapterID, tsMainScript.AreaID, false);
            }
            else
            {
                if (!tsMainScript.completedInvest.Contains(4))
                {
                    tsMainScript.completedInvest.Add(4);
                }
                tsMainScript.EventID = 99990;
                currentCharaSpr = tsSpritesManager.TwilightStandHappy.GetComponent<SpriteRenderer>();
                tsMainScript.ProceedGame(tsMainScript.ChapterID, tsMainScript.AreaID, false);
            }
        }
        else if (eventID == 105)
        {
            tsMainScript.DialogIndex = 106;
            if (!isContinue)
            {
                tsSpritesManager.ClrAllCharaSpr("Twilight");
            }
            else
            {
                AudioManager.Instance.PlayBGM(BGMID.Further_Investigation_2009);
                tsMainScript.Clickable = true;
                tsSpritesManager.dialogBox.SetActive(true);
                tsSpritesManager.BackgroundUpdate("EverfreeCrimeScene");
                tsSpritesManager.everfreecrimeScene.GetComponent<Transform>().DOMoveX(-12.06f, 0);
                investSpots.GetComponent<RectTransform>().DOLocalMoveX(-1288, 0);
                detectiveSystem.currentBackgroundPos = 2;
            }
            tsSpritesManager.TwilightStandNormal.SetActive(true);
            ProceedText(isContinue, false);
        }
        else if (eventID == 106)
        {
            tsMainScript.DialogIndex = 107;
            if (isContinue)
            {
                AudioManager.Instance.PlayBGM(BGMID.Further_Investigation_2009);
                tsMainScript.Clickable = true;
                tsSpritesManager.dialogBox.SetActive(true);
                tsSpritesManager.BackgroundUpdate("EverfreeCrimeScene");
                tsSpritesManager.TwilightStandNormal.SetActive(true);
                tsSpritesManager.everfreecrimeScene.GetComponent<Transform>().DOMoveX(-12.06f, 0);
                investSpots.GetComponent<RectTransform>().DOLocalMoveX(-1288, 0);
                detectiveSystem.currentBackgroundPos = 2;
            }
            ProceedText(isContinue, false);
        }
        else if (eventID == 107)
        {
            tsMainScript.DialogIndex = 108;
            if (isContinue)
            {
                AudioManager.Instance.PlayBGM(BGMID.Further_Investigation_2009);
                tsMainScript.Clickable = true;
                tsSpritesManager.dialogBox.SetActive(true);
                tsSpritesManager.BackgroundUpdate("EverfreeCrimeScene");
                tsSpritesManager.TwilightStandNormal.SetActive(true);
                tsSpritesManager.everfreecrimeScene.GetComponent<Transform>().DOMoveX(-12.06f, 0);
                investSpots.GetComponent<RectTransform>().DOLocalMoveX(-1288, 0);
                detectiveSystem.currentBackgroundPos = 2;
            }
            ProceedText(isContinue, false);
        }
        else if (eventID == 108)
        {
            tsMainScript.DialogIndex = 109;
            if (isContinue)
            {
                AudioManager.Instance.PlayBGM(BGMID.Further_Investigation_2009);
                tsMainScript.Clickable = true;
                tsSpritesManager.dialogBox.SetActive(true);
                tsSpritesManager.BackgroundUpdate("EverfreeCrimeScene");
                tsSpritesManager.TwilightStandNormal.SetActive(true);
                tsSpritesManager.everfreecrimeScene.GetComponent<Transform>().DOMoveX(-12.06f, 0);
                investSpots.GetComponent<RectTransform>().DOLocalMoveX(-1288, 0);
                detectiveSystem.currentBackgroundPos = 2;
            }
            ProceedText(isContinue, false);
        }
        else if (eventID == 109)
        {
            tsMainScript.DialogIndex = 110;
            if (isContinue)
            {
                AudioManager.Instance.PlayBGM(BGMID.Further_Investigation_2009);
                tsMainScript.Clickable = true;
                tsSpritesManager.dialogBox.SetActive(true);
                tsSpritesManager.BackgroundUpdate("EverfreeCrimeScene");
                tsSpritesManager.TwilightStandNormal.SetActive(true);
                tsSpritesManager.everfreecrimeScene.GetComponent<Transform>().DOMoveX(-12.06f, 0);
                investSpots.GetComponent<RectTransform>().DOLocalMoveX(-1288, 0);
                detectiveSystem.currentBackgroundPos = 2;
            }
            ProceedText(isContinue, false);
        }
        else if (eventID == 110)
        {
            tsMainScript.DialogIndex = 111;
            if (isContinue)
            {
                AudioManager.Instance.PlayBGM(BGMID.Further_Investigation_2009);
                tsMainScript.Clickable = true;
                tsSpritesManager.dialogBox.SetActive(true);
                tsSpritesManager.BackgroundUpdate("EverfreeCrimeScene");
                tsSpritesManager.TwilightStandNormal.SetActive(true);
                tsSpritesManager.everfreecrimeScene.GetComponent<Transform>().DOMoveX(-12.06f, 0);
                investSpots.GetComponent<RectTransform>().DOLocalMoveX(-1288, 0);
                detectiveSystem.currentBackgroundPos = 2;
            }
            ProceedText(isContinue, false);
        }
        else if (eventID == 111)
        {
            tsMainScript.DialogIndex = 112;
            if (isContinue)
            {
                AudioManager.Instance.PlayBGM(BGMID.Further_Investigation_2009);
                tsMainScript.Clickable = true;
                tsSpritesManager.dialogBox.SetActive(true);
                tsSpritesManager.BackgroundUpdate("EverfreeCrimeScene");
                tsSpritesManager.TwilightStandNormal.SetActive(true);
                tsSpritesManager.everfreecrimeScene.GetComponent<Transform>().DOMoveX(-12.06f, 0);
                investSpots.GetComponent<RectTransform>().DOLocalMoveX(-1288, 0);
                detectiveSystem.currentBackgroundPos = 2;
            }
            ProceedText(isContinue, false);
        }
        else if (eventID == 112)
        {
            tsMainScript.DialogIndex = 113;
            if (isContinue)
            {
                AudioManager.Instance.PlayBGM(BGMID.Further_Investigation_2009);
                tsMainScript.Clickable = true;
                tsSpritesManager.dialogBox.SetActive(true);
                tsSpritesManager.BackgroundUpdate("EverfreeCrimeScene");
                tsSpritesManager.TwilightStandNormal.SetActive(true);
                tsSpritesManager.everfreecrimeScene.GetComponent<Transform>().DOMoveX(-12.06f, 0);
                investSpots.GetComponent<RectTransform>().DOLocalMoveX(-1288, 0);
                detectiveSystem.currentBackgroundPos = 2;
            }
            ProceedText(isContinue, false);
        }
        else if (eventID == 113)
        {
            tsMainScript.DialogIndex = 114;
            if (isContinue)
            {
                AudioManager.Instance.PlayBGM(BGMID.Further_Investigation_2009);
                tsMainScript.Clickable = true;
                tsSpritesManager.dialogBox.SetActive(true);
                tsSpritesManager.BackgroundUpdate("EverfreeCrimeScene");
                tsSpritesManager.TwilightStandNormal.SetActive(true);
                tsSpritesManager.everfreecrimeScene.GetComponent<Transform>().DOMoveX(-12.06f, 0);
                investSpots.GetComponent<RectTransform>().DOLocalMoveX(-1288, 0);
                detectiveSystem.currentBackgroundPos = 2;
            }
            ProceedText(isContinue, false);
        }
        else if (eventID == 114)
        {
            tsMainScript.DialogIndex = 115;
            if (!isContinue)
            {
                tsMainScript.Clickable = false;
                Invoke("Event114Delay", .2f);
            }
            else
            {
                AudioManager.Instance.PlayBGM(BGMID.Further_Investigation_2009);
                tsMainScript.Clickable = true;
                tsSpritesManager.dialogBox.SetActive(true);
                tsSpritesManager.BackgroundUpdate("EverfreeCrimeScene");
                tsSpritesManager.TwilightStandWhat.SetActive(true);
                tsSpritesManager.everfreecrimeScene.GetComponent<Transform>().DOMoveX(-12.06f, 0);
                investSpots.GetComponent<RectTransform>().DOLocalMoveX(-1288, 0);
                detectiveSystem.currentBackgroundPos = 2;
            }
            ProceedText(isContinue, false);
        }
        else if (eventID == 115)
        {
            tsMainScript.DialogIndex = 116;
            tsSpritesManager.TwilightStandNormal.SetActive(true);
            if (!isContinue)
            {
                tsSpritesManager.TwilightStandWhat.SetActive(false);
            }
            else
            {
                AudioManager.Instance.PlayBGM(BGMID.Further_Investigation_2009);
                tsMainScript.Clickable = true;
                tsSpritesManager.dialogBox.SetActive(true);
                tsSpritesManager.BackgroundUpdate("EverfreeCrimeScene");
                tsSpritesManager.everfreecrimeScene.GetComponent<Transform>().DOMoveX(-12.06f, 0);
                investSpots.GetComponent<RectTransform>().DOLocalMoveX(-1288, 0);
                detectiveSystem.currentBackgroundPos = 2;
            }
            ProceedText(isContinue, false);
        }
        else if (eventID == 116)
        {
            tsMainScript.DialogIndex = 117;
            if (!isContinue)
            {
                AudioManager.Instance.StopBGM(false);
            }
            else
            {
                tsMainScript.Clickable = true;
                tsSpritesManager.dialogBox.SetActive(true);
                tsSpritesManager.BackgroundUpdate("EverfreeCrimeScene");
                tsSpritesManager.TwilightStandNormal.SetActive(true);
                tsSpritesManager.everfreecrimeScene.GetComponent<Transform>().DOMoveX(-12.06f, 0);
                investSpots.GetComponent<RectTransform>().DOLocalMoveX(-1288, 0);
                detectiveSystem.currentBackgroundPos = 2;
            }
            ProceedText(isContinue, false);
        }
        else if (eventID == 117)
        {
            tsMainScript.DialogIndex = 118;
            if (isContinue)
            {
                tsMainScript.Clickable = true;
                tsSpritesManager.dialogBox.SetActive(true);
                tsSpritesManager.BackgroundUpdate("EverfreeCrimeScene");
                tsSpritesManager.TwilightStandNormal.SetActive(true);
                tsSpritesManager.everfreecrimeScene.GetComponent<Transform>().DOMoveX(-12.06f, 0);
                investSpots.GetComponent<RectTransform>().DOLocalMoveX(-1288, 0);
                detectiveSystem.currentBackgroundPos = 2;
            }
            ProceedText(isContinue, false);
        }
        else if (eventID == 118)
        {
            tsMainScript.DialogIndex = 119;
            if (isContinue)
            {
                tsMainScript.Clickable = true;
                tsSpritesManager.dialogBox.SetActive(true);
                tsSpritesManager.BackgroundUpdate("EverfreeCrimeScene");
                tsSpritesManager.TwilightStandNormal.SetActive(true);
                tsSpritesManager.everfreecrimeScene.GetComponent<Transform>().DOMoveX(-12.06f, 0);
                investSpots.GetComponent<RectTransform>().DOLocalMoveX(-1288, 0);
                detectiveSystem.currentBackgroundPos = 2;
            }
            ProceedText(isContinue, false);
        }
        else if (eventID == 119)
        {
            tsMainScript.DialogIndex = 120;
            tsSpritesManager.TwilightStandExplain.SetActive(true);
            if (!isContinue)
            {
                tsSpritesManager.TwilightStandNormal.SetActive(false);
            }
            else
            {
                tsMainScript.Clickable = true;
                tsSpritesManager.dialogBox.SetActive(true);
                tsSpritesManager.BackgroundUpdate("EverfreeCrimeScene");
                tsSpritesManager.everfreecrimeScene.GetComponent<Transform>().DOMoveX(-12.06f, 0);
                investSpots.GetComponent<RectTransform>().DOLocalMoveX(-1288, 0);
                detectiveSystem.currentBackgroundPos = 2;
            }
            ProceedText(isContinue, false);
        }
        else if (eventID == 120)
        {
            tsMainScript.DialogIndex = 121;
            tsSpritesManager.TwilightStandNormal.SetActive(true);
            if (!isContinue)
            {
                tsSpritesManager.TwilightStandExplain.SetActive(false);
            }
            else
            {
                tsMainScript.Clickable = true;
                tsSpritesManager.dialogBox.SetActive(true);
                tsSpritesManager.BackgroundUpdate("EverfreeCrimeScene");
                tsSpritesManager.everfreecrimeScene.GetComponent<Transform>().DOMoveX(-12.06f, 0);
                investSpots.GetComponent<RectTransform>().DOLocalMoveX(-1288, 0);
                detectiveSystem.currentBackgroundPos = 2;
            }
            ProceedText(isContinue, false);
        }
        else if (eventID == 121)
        {
            tsMainScript.DialogIndex = 122;
            tsSpritesManager.TwilightStandImpatient.SetActive(true);
            AudioManager.Instance.PlayBGM(BGMID.Heart_of_the_Investigation_2001);
            if (!isContinue)
            {
                tsSpritesManager.TwilightStandNormal.SetActive(false);
            }
            else
            {
                tsMainScript.Clickable = true;
                tsSpritesManager.dialogBox.SetActive(true);
                tsSpritesManager.BackgroundUpdate("EverfreeCrimeScene");
                tsSpritesManager.everfreecrimeScene.GetComponent<Transform>().DOMoveX(-12.06f, 0);
                investSpots.GetComponent<RectTransform>().DOLocalMoveX(-1288, 0);
                detectiveSystem.currentBackgroundPos = 2;
            }
            ProceedText(isContinue, false);
        }
        else if (eventID == 122)
        {
            tsMainScript.DialogIndex = 123;
            if (isContinue)
            {
                AudioManager.Instance.PlayBGM(BGMID.Heart_of_the_Investigation_2001);
                tsMainScript.Clickable = true;
                tsSpritesManager.dialogBox.SetActive(true);
                tsSpritesManager.BackgroundUpdate("EverfreeCrimeScene");
                tsSpritesManager.everfreecrimeScene.GetComponent<Transform>().DOMoveX(-12.06f, 0);
                tsSpritesManager.TwilightStandImpatient.SetActive(true);
                investSpots.GetComponent<RectTransform>().DOLocalMoveX(-1288, 0);
                detectiveSystem.currentBackgroundPos = 2;
            }
            ProceedText(isContinue, false);
        }
        else if (eventID == 123)
        {
            tsMainScript.DialogIndex = 124;
            if (!isContinue)
            {
                tsSpritesManager.TwilightStandImpatient.SetActive(false);
            }
            else
            {
                AudioManager.Instance.PlayBGM(BGMID.Heart_of_the_Investigation_2001);
                tsMainScript.Clickable = true;
                tsSpritesManager.dialogBox.SetActive(true);
                tsSpritesManager.BackgroundUpdate("EverfreeCrimeScene");
                tsSpritesManager.everfreecrimeScene.GetComponent<Transform>().DOMoveX(-12.06f, 0);
                investSpots.GetComponent<RectTransform>().DOLocalMoveX(-1288, 0);
                detectiveSystem.currentBackgroundPos = 2;
            }
            tsSpritesManager.TwilightSitSad.SetActive(true);
            ProceedText(isContinue, false);
        }
        else if (eventID == 124)
        {
            tsMainScript.DialogIndex = 125;
            if (isContinue)
            {
                AudioManager.Instance.PlayBGM(BGMID.Heart_of_the_Investigation_2001);
                tsMainScript.Clickable = true;
                tsSpritesManager.dialogBox.SetActive(true);
                tsSpritesManager.BackgroundUpdate("EverfreeCrimeScene");
                tsSpritesManager.TwilightSitSad.SetActive(true);
                tsSpritesManager.everfreecrimeScene.GetComponent<Transform>().DOMoveX(-12.06f, 0);
                investSpots.GetComponent<RectTransform>().DOLocalMoveX(-1288, 0);
                detectiveSystem.currentBackgroundPos = 2;
            }
            ProceedText(isContinue, false);
        }
        else if (eventID == 125)
        {
            tsMainScript.DialogIndex = 126;
            if (!isContinue)
            {
                tsSpritesManager.TwilightSitSad.SetActive(false);
            }
            else
            {
                AudioManager.Instance.PlayBGM(BGMID.Heart_of_the_Investigation_2001);
                tsMainScript.Clickable = true;
                tsSpritesManager.dialogBox.SetActive(true);
                tsSpritesManager.BackgroundUpdate("EverfreeCrimeScene");
                tsSpritesManager.everfreecrimeScene.GetComponent<Transform>().DOMoveX(-12.06f, 0);
                investSpots.GetComponent<RectTransform>().DOLocalMoveX(-1288, 0);
                detectiveSystem.currentBackgroundPos = 2;
            }
            tsSpritesManager.TwilightStandNormal.SetActive(true);
            ProceedText(isContinue, false);
        }
        else if (eventID == 126)
        {
            tsMainScript.DialogIndex = 127;
            if (isContinue)
            {
                AudioManager.Instance.PlayBGM(BGMID.Heart_of_the_Investigation_2001);
                tsMainScript.Clickable = true;
                tsSpritesManager.dialogBox.SetActive(true);
                tsSpritesManager.BackgroundUpdate("EverfreeCrimeScene");
                tsSpritesManager.everfreecrimeScene.GetComponent<Transform>().DOMoveX(-12.06f, 0);
                tsSpritesManager.TwilightStandNormal.SetActive(true);
                investSpots.GetComponent<RectTransform>().DOLocalMoveX(-1288, 0);
                detectiveSystem.currentBackgroundPos = 2;
            }
            ProceedText(isContinue, false);
        }
        else if (eventID == 127)
        {
            tsMainScript.DialogIndex = 128;
            if (!isContinue)
            {
                tsSpritesManager.TwilightStandNormal.SetActive(false);
            }
            else
            {
                AudioManager.Instance.PlayBGM(BGMID.Heart_of_the_Investigation_2001);
                tsMainScript.Clickable = true;
                tsSpritesManager.dialogBox.SetActive(true);
                tsSpritesManager.BackgroundUpdate("EverfreeCrimeScene");
                tsSpritesManager.everfreecrimeScene.GetComponent<Transform>().DOMoveX(-12.06f, 0);
                investSpots.GetComponent<RectTransform>().DOLocalMoveX(-1288, 0);
                detectiveSystem.currentBackgroundPos = 2;
            }
            tsSpritesManager.twilightStandOMG.gameObject.SetActive(true);
            ProceedText(isContinue, false);
        }
        else if (eventID == 128)
        {
            tsMainScript.DialogIndex = 129;
            if (!isContinue)
            {
                tsSpritesManager.twilightStandOMG.gameObject.SetActive(false);
            }
            else
            {
                AudioManager.Instance.PlayBGM(BGMID.Heart_of_the_Investigation_2001);
                tsMainScript.Clickable = true;
                tsSpritesManager.dialogBox.SetActive(true);
                tsSpritesManager.BackgroundUpdate("EverfreeCrimeScene");
                tsSpritesManager.everfreecrimeScene.GetComponent<Transform>().DOMoveX(-12.06f, 0);
                investSpots.GetComponent<RectTransform>().DOLocalMoveX(-1288, 0);
                detectiveSystem.currentBackgroundPos = 2;
            }
            tsSpritesManager.TwilightStandNormal.SetActive(true);
            ProceedText(isContinue, false);
        }
        else if (eventID == 129)
        {
            tsMainScript.DialogIndex = 130;
            if (!isContinue)
            {
                tsSpritesManager.TwilightStandNormal.SetActive(false);
            }
            else
            {
                AudioManager.Instance.PlayBGM(BGMID.Heart_of_the_Investigation_2001);
                tsMainScript.Clickable = true;
                tsSpritesManager.dialogBox.SetActive(true);
                tsSpritesManager.BackgroundUpdate("EverfreeCrimeScene");
                tsSpritesManager.everfreecrimeScene.GetComponent<Transform>().DOMoveX(-12.06f, 0);
                investSpots.GetComponent<RectTransform>().DOLocalMoveX(-1288, 0);
                detectiveSystem.currentBackgroundPos = 2;
            }
            tsSpritesManager.TwilightSitSad.SetActive(true);
            ProceedText(isContinue, false);
        }
        else if (eventID == 130)
        {
            tsMainScript.DialogIndex = 131;
            if (isContinue)
            {
                AudioManager.Instance.PlayBGM(BGMID.Heart_of_the_Investigation_2001);
                tsMainScript.Clickable = true;
                tsSpritesManager.dialogBox.SetActive(true);
                tsSpritesManager.BackgroundUpdate("EverfreeCrimeScene");
                tsSpritesManager.TwilightSitSad.SetActive(true);
                tsSpritesManager.everfreecrimeScene.GetComponent<Transform>().DOMoveX(-12.06f, 0);
                investSpots.GetComponent<RectTransform>().DOLocalMoveX(-1288, 0);
                detectiveSystem.currentBackgroundPos = 2;
            }
            ProceedText(isContinue, false);
        }
        else if (eventID == 131)
        {
            tsMainScript.DialogIndex = 132;
            if (!isContinue)
            {
                tsSpritesManager.TwilightSitSad.SetActive(false);
            }
            else
            {
                AudioManager.Instance.PlayBGM(BGMID.Heart_of_the_Investigation_2001);
                tsMainScript.Clickable = true;
                tsSpritesManager.dialogBox.SetActive(true);
                tsSpritesManager.BackgroundUpdate("EverfreeCrimeScene");
                tsSpritesManager.everfreecrimeScene.GetComponent<Transform>().DOMoveX(-12.06f, 0);
                investSpots.GetComponent<RectTransform>().DOLocalMoveX(-1288, 0);
                detectiveSystem.currentBackgroundPos = 2;
            }
            tsSpritesManager.TwilightStandExplain.SetActive(true);
            ProceedText(isContinue, false);
        }
        else if (eventID == 132)
        {
            tsMainScript.DialogIndex = 133;
            if (isContinue)
            {
                AudioManager.Instance.PlayBGM(BGMID.Heart_of_the_Investigation_2001);
                tsMainScript.Clickable = true;
                tsSpritesManager.dialogBox.SetActive(true);
                tsSpritesManager.BackgroundUpdate("EverfreeCrimeScene");
                tsSpritesManager.TwilightStandExplain.SetActive(true);
                tsSpritesManager.everfreecrimeScene.GetComponent<Transform>().DOMoveX(-12.06f, 0);
                investSpots.GetComponent<RectTransform>().DOLocalMoveX(-1288, 0);
                detectiveSystem.currentBackgroundPos = 2;
            }
            ProceedText(isContinue, false);
        }
        else if (eventID == 133)
        {
            tsMainScript.DialogIndex = 134;
            if (isContinue)
            {
                AudioManager.Instance.PlayBGM(BGMID.Heart_of_the_Investigation_2001);
                tsMainScript.Clickable = true;
                tsSpritesManager.dialogBox.SetActive(true);
                tsSpritesManager.BackgroundUpdate("EverfreeCrimeScene");
                tsSpritesManager.TwilightStandExplain.SetActive(true);
                tsSpritesManager.everfreecrimeScene.GetComponent<Transform>().DOMoveX(-12.06f, 0);
                investSpots.GetComponent<RectTransform>().DOLocalMoveX(-1288, 0);
                detectiveSystem.currentBackgroundPos = 2;
            }
            ProceedText(isContinue, false);
        }
        else if (eventID == 134)
        {
            tsMainScript.DialogIndex = 135;
            if (isContinue)
            {
                AudioManager.Instance.PlayBGM(BGMID.Heart_of_the_Investigation_2001);
                tsMainScript.Clickable = true;
                tsSpritesManager.dialogBox.SetActive(true);
                tsSpritesManager.BackgroundUpdate("EverfreeCrimeScene");
                tsSpritesManager.TwilightStandExplain.SetActive(true);
                tsSpritesManager.everfreecrimeScene.GetComponent<Transform>().DOMoveX(-12.06f, 0);
                investSpots.GetComponent<RectTransform>().DOLocalMoveX(-1288, 0);
                detectiveSystem.currentBackgroundPos = 2;
            }
            ProceedText(isContinue, false);
        }
        else if (eventID == 135)
        {
            tsMainScript.DialogIndex = 136;
            if (isContinue)
            {
                AudioManager.Instance.PlayBGM(BGMID.Heart_of_the_Investigation_2001);
                tsMainScript.Clickable = true;
                tsSpritesManager.dialogBox.SetActive(true);
                tsSpritesManager.BackgroundUpdate("EverfreeCrimeScene");
                tsSpritesManager.TwilightStandExplain.SetActive(true);
                tsSpritesManager.everfreecrimeScene.GetComponent<Transform>().DOMoveX(-12.06f, 0);
                investSpots.GetComponent<RectTransform>().DOLocalMoveX(-1288, 0);
                detectiveSystem.currentBackgroundPos = 2;
            }
            ProceedText(isContinue, false);
            tsSpritesManager.blackScreen.DOFade(0, 0);
        }
        else if (eventID == 136)
        {
            tsMainScript.Clickable = false;
            tsSpritesManager.dialogBox.SetActive(false);
            tsSpritesManager.blackScreen.gameObject.SetActive(true);
            tsSpritesManager.blackScreen.DOFade(1, 5f);
            DemoEndScreen.DOFade(0, 0);
            Invoke("Event136Delay", 1f);
            Invoke("Event136Delay2", 6f);
            Invoke("Event136Delay3", 6.5f);
            tsMainScript.EventID = 135;
        }
        else if (eventID == 137)
        {
            tsMainScript.DialogIndex = 138;
            if (!isContinue)
            {
                Invoke("Event137Delay", .26f);
            }
            else
            {
                tsMainScript.Clickable = true;
                tsSpritesManager.dialogBox.SetActive(true);
                AudioManager.Instance.PlayBGM(BGMID.Heart_of_the_Investigation_2001);
                tsSpritesManager.BackgroundUpdate("EverfreeCrimeScene");
                ProceedText(true, false);
            }
            tsMainScript.EventID = 91370;
        }
        else if (eventID == 91370)
        {
            tsMainScript.EventID = 137;
            tsMainScript.ProceedGame(tsMainScript.ChapterID, tsMainScript.AreaID, true);
        }
        else if (eventID == 91371)
        {
            tsMainScript.EventID = 99990;
            tsMainScript.ProceedGame(tsMainScript.ChapterID, tsMainScript.AreaID, false);
        }
        else
        {
            tsMainScript.EventID -= 1;
            Debug.Log("Event " + eventID + "无对应事件。");
            tsMainScript.Proceed = false;
            tsMainScript.DialogProcessing = false;
        }
    }

    public void OpenDetectiveInvest()
    {
        detectiveSystem.flag = true;
        AudioManager.Instance.PlaySE(SEID.se_com_001);
        detectiveSystem.CloseActions();
        tsMainScript.btnOpenCourtRecords.gameObject.SetActive(false);
        tsMainScript.btnShowBacklog.gameObject.SetActive(false);
        tsMainScript.btnOptions.gameObject.SetActive(false);
        Invoke("ShowInvest", .26f);
    }
    public void ShowInvest()
    {
        tsMainScript.btnCloseDetectiveInvest.gameObject.SetActive(true);
        detectiveSystem.OpenInvest(currentCharaSpr, investSpots);
    }

    public void DemoEndSave()
    {
        AudioManager.Instance.PlaySE(SEID.kettei);
    }

    public void DemoEndQuit()
    {
        AudioManager.Instance.PlaySE(SEID.cancel);
        DemoEndScreen.DOFade(0, 2.5f);
        DemoEndPanel.DOFade(0, 2.5f);
        DemoEndPanel.blocksRaycasts = false;
        Invoke("BacktoMenu", 3f);
    }

    public void BacktoMenu()
    {
        SceneManager.LoadScene("ChapSelect");
    }

    public void Event1Delay()
    {
        tsMainScript.Clickable = true;
        tsSpritesManager.dialogBox.SetActive(true);
        ProceedText(false, false);
    }
    public void Event10Delay()
    {
        tsMainScript.Clickable = true;
        tsSpritesManager.dialogBox.SetActive(true);
        ProceedText(false, false);
    }
    public void Event16Delay()
    {
        tsMainScript.Clickable = true;
        tsSpritesManager.dialogBox.SetActive(true);
        ProceedText(false, false);
    }
    public void Event19Delay()
    {
        AudioManager.Instance.PlaySE(SEID.se_com_023);
        tsSpritesManager.twilightMagicAura.DOFade(0, 3f);
        tsSpritesManager.blackScreen.DOFade(0, 3f);
    }
    public void Event19Delay2()
    {
        tsSpritesManager.twilightMagicAura.gameObject.SetActive(false);
        tsSpritesManager.twilightMagicAura.DOFade(1, 0);
        tsSpritesManager.blackScreen.gameObject.SetActive(false);
        tsSpritesManager.blackScreen.DOFade(1, 0);
        tsMainScript.Clickable = true;
        tsSpritesManager.dialogBox.SetActive(true);
        ProceedText(false, false);
    }
    public void Event21Delay()
    {
        AudioManager.Instance.PlayBGM(BGMID.Further_Investigation_2009);
    }
    public void Event23Delay()
    {
        tsSpritesManager.TwilightStandHappy.GetComponent<SpriteRenderer>().DOFade(0, 0);
    }
    public void Event23Delay2()
    {
        tsSpritesManager.TwilightStandHappy.SetActive(true);
        tsSpritesManager.TwilightStandHappy.GetComponent<SpriteRenderer>().DOFade(1, .25f);
    }
    public void Event23Delay3()
    {
        tsMainScript.btnOpenCourtRecords.gameObject.SetActive(true);
        tsMainScript.btnShowBacklog.gameObject.SetActive(true);
        tsMainScript.btnOptions.gameObject.SetActive(true);
        tsMainScript.ClickOverlay.SetActive(true);
        tsMainScript.Clickable = true;
        tsSpritesManager.dialogBox.SetActive(true);
        ProceedText(false, false);
    }
    public void Event36Delay()
    {
        tsMainScript.Clickable = true;
        tsSpritesManager.TwilightStandNormal.SetActive(false);
        tsSpritesManager.TwilightStandConfused.SetActive(true);
    }
    public void Event39Delay()
    {
        AudioManager.Instance.PlaySE(SEID.se_script_013);
    }
    public void Event39Delay2()
    {
        tsSpritesManager.TwilightStandConfused.GetComponent<SpriteRenderer>().DOFade(1, .25f);
    }
    public void Event39Delay3()
    {
        tsSpritesManager.dialogBox.SetActive(true);
        ProceedText(false, false);
    }
    public void Event39Delay4()
    {
        tsMainScript.Clickable = true;
        tsSpritesManager.TwilightStandConfused.SetActive(false);
        tsSpritesManager.TwilightStandHappy.SetActive(true);
    }
    public void Event42Delay()
    {
        tsSpritesManager.TwilightStandNormal.GetComponent<SpriteRenderer>().DOFade(0, 0);
    }
    public void Event42Delay2()
    {
        tsSpritesManager.TwilightStandNormal.SetActive(true);
        tsSpritesManager.TwilightStandNormal.GetComponent<SpriteRenderer>().DOFade(1, .25f);
    }
    public void Event42Delay3()
    {
        tsMainScript.btnOpenCourtRecords.gameObject.SetActive(true);
        tsMainScript.btnShowBacklog.gameObject.SetActive(true);
        tsMainScript.btnOptions.gameObject.SetActive(true);
        tsMainScript.ClickOverlay.SetActive(true);
        tsMainScript.Clickable = true;
        tsSpritesManager.dialogBox.SetActive(true);
        ProceedText(false, false);
    }
    public void Event43Delay()
    {
        tsMainScript.Clickable = true;
        ProceedText(false, false);
    }
    public void Event52Delay()
    {
        tsMainScript.Clickable = true;
        tsSpritesManager.dialogBox.SetActive(true);
        ProceedText(false, false);
    }
    public void Event60Delay()
    {
        tsSpritesManager.TwilightStandNormal.GetComponent<SpriteRenderer>().DOFade(0, 0);
        tsSpritesManager.WhiteScreen.SetActive(true);
        tsSpritesManager.WhiteScreen.GetComponent<Image>().DOFade(1, .25f);
    }
    public void Event60Delay2()
    {
        AudioManager.Instance.PlaySE(SEID.se_script_011);
        tsSpritesManager.WhiteScreen.GetComponent<Image>().DOFade(0, .25f);
    }
    public void Event60Delay3()
    {
        tsSpritesManager.WhiteScreen.SetActive(false);
        tsSpritesManager.WhiteScreen.GetComponent<Image>().DOFade(1, 0);
        tsMainScript.btnOpenCourtRecords.gameObject.SetActive(true);
        tsMainScript.btnShowBacklog.gameObject.SetActive(true);
        tsMainScript.btnOptions.gameObject.SetActive(true);
        tsMainScript.ClickOverlay.SetActive(true);
        tsMainScript.Clickable = true;
        tsSpritesManager.dialogBox.SetActive(true);
        ProceedText(false, false);
    }
    public void Event61Delay()
    {
        tsMainScript.Clickable = true;
        ProceedText(false, false);
    }
    public void Event75Delay()
    {
        tsSpritesManager.TwilightStandExplain.SetActive(true);
        tsSpritesManager.TwilightStandExplain.GetComponent<SpriteRenderer>().DOFade(1, .25f);
    }
    public void Event75Delay2()
    {
        tsMainScript.btnOpenCourtRecords.gameObject.SetActive(true);
        tsMainScript.btnShowBacklog.gameObject.SetActive(true);
        tsMainScript.btnOptions.gameObject.SetActive(true);
        tsMainScript.ClickOverlay.SetActive(true);
        tsMainScript.Clickable = true;
        tsSpritesManager.dialogBox.SetActive(true);
        ProceedText(false, false);
    }
    public void Event78Delay()
    {
        AudioManager.Instance.PlaySE(SEID.se_com_023);
        tsSpritesManager.TwilightStandHappy.SetActive(false);
        tsSpritesManager.TwilightStandHappy.GetComponent<SpriteRenderer>().DOFade(1, 0);
    }
    public void Event78Delay2()
    {
        tsMainScript.Clickable = true;
        tsSpritesManager.dialogBox.SetActive(true);
        ProceedText(false, false);
    }
    public void Event79Delay()
    {
        tsMainScript.Clickable = true;
        ProceedText(false, false);
    }
    public void Event81Delay()
    {
        tsMainScript.Clickable = true;
        ProceedText(false, false);
    }
    public void Event101Delay()
    {
        tsMainScript.Clickable = true;
        tsSpritesManager.TwilightStandHappy.SetActive(false);
        tsSpritesManager.TwilightStandNormal.SetActive(true);
    }
    public void Event114Delay()
    {
        tsMainScript.Clickable = true;
        tsSpritesManager.TwilightStandNormal.SetActive(false);
        tsSpritesManager.TwilightStandWhat.SetActive(true);
    }
    public void Event136Delay()
    {
        AudioManager.Instance.StopBGM(true);
    }
    public void Event136Delay2()
    {
        AudioManager.Instance.PlayBGM(BGMID.Jingle_2001);
        DemoEndScreen.gameObject.SetActive(true);
        DemoEndScreen.DOFade(1, .5f);
    }
    public void Event136Delay3()
    {
        DemoEndPanel.gameObject.SetActive(true);
        DemoEndPanel.alpha = 1;
        DemoEndPanel.blocksRaycasts = true;
    }
    public void Event137Delay()
    {
        tsMainScript.btnOpenCourtRecords.gameObject.SetActive(true);
        tsMainScript.btnShowBacklog.gameObject.SetActive(true);
        tsMainScript.btnOptions.gameObject.SetActive(true);
        tsMainScript.ClickOverlay.SetActive(true);
        tsSpritesManager.dialogBox.SetActive(true);
        ProceedText(false, false);
    }
}
