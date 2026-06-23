using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

public class TSScriptC0A5 : MonoBehaviour
{
    // 主摄像机
    public Camera MainCamera;
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

    void Start()
    {

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
        if (tsMainScript.CurrentScript != "TSScriptC0A5")
        {
            // 读取 TextAsset
            tsMainScript.CurrentScript = "TSScriptC0A5";
            tsMainScript.ReadText(DialogFile);
            Debug.Log("已读取对话文本TSScriptC0A5");
        }
        print(tsMainScript.EventID);
        // Area 5 小蝶家
        if (eventID == 0)
        {
            tsMainScript.DialogIndex = 1;
            tsSpritesManager.NameTag.SetActive(false);
            tsSpritesManager.dialogBox.SetActive(true);
            tsSpritesManager.SpeechText.SetActive(false);
            tsSpritesManager.NewAreaText.SetActive(true);
            tsSpritesManager.BackgroundUpdate("FluttershysCottage");
            if (!isContinue)
            {
                tsMainScript.Clickable = false;
                tsSpritesManager.blackScreen.DOFade(0, .5f);
                Invoke("Event0Delay", .5f);
            }
            else
            {
                tsMainScript.Clickable = true;
                ProceedText(true, false);
            }
        }
        else if (eventID == 1)
        {
            tsMainScript.DialogIndex = 2;
            tsSpritesManager.BackgroundUpdate("FluttershysCottage");
            if (!isContinue)
            {
                tsSpritesManager.dialogBox.SetActive(false);
                tsSpritesManager.NameTag.SetActive(true);
                tsSpritesManager.SpeechText.SetActive(true);
                tsSpritesManager.NewAreaText.SetActive(false);
                tsMainScript.Clickable = false;
                tsSpritesManager.TwilightStandNormal.GetComponent<SpriteRenderer>().DOFade(0, 0f);
                Invoke("Event1Delay", .5f);
                Invoke("Event1Delay2", 1f);
            }
            else
            {
                tsSpritesManager.dialogBox.SetActive(true);
                tsMainScript.Clickable = true;
                ProceedText(true, false);
            }
        }
        else if (eventID == 2)
        {
            tsMainScript.Clickable = true;
            tsMainScript.DialogIndex = 3;
            tsSpritesManager.dialogBox.SetActive(true);
            tsSpritesManager.BackgroundUpdate("FluttershysCottage");
            tsSpritesManager.TwilightStandNormal.SetActive(true);
            ProceedText(isContinue, false);
        }
        else if (eventID == 3)
        {
            tsMainScript.Clickable = true;
            tsMainScript.DialogIndex = 4;
            tsSpritesManager.dialogBox.SetActive(true);
            tsSpritesManager.BackgroundUpdate("FluttershysCottage");
            tsSpritesManager.TwilightStandNormal.SetActive(true);
            ProceedText(isContinue, false);
        }
        else if (eventID == 4)
        {
            tsMainScript.Clickable = true;
            tsMainScript.DialogIndex = 5;
            tsSpritesManager.dialogBox.SetActive(true);
            tsSpritesManager.BackgroundUpdate("FluttershysCottage");
            if (!isContinue)
            {
                tsSpritesManager.TwilightStandNormal.SetActive(false);
            }
            tsSpritesManager.TwilightStandConfused.SetActive(true);
            ProceedText(isContinue, false);
        }
        else if (eventID == 5)
        {
            tsMainScript.Clickable = true;
            tsMainScript.DialogIndex = 6;
            tsSpritesManager.dialogBox.SetActive(true);
            tsSpritesManager.BackgroundUpdate("FluttershysCottage");
            if (!isContinue)
            {
                tsSpritesManager.TwilightStandConfused.SetActive(false);
            }
            tsSpritesManager.TwilightStandNormal.SetActive(true);
            ProceedText(isContinue, false);
        }
        else if (eventID == 6)
        {
            tsMainScript.DialogIndex = 7;
            tsSpritesManager.BackgroundUpdate("FluttershysCottage");
            if (!isContinue)
            {
                tsMainScript.Clickable = false;
                tsSpritesManager.dialogBox.SetActive(false);
                tsSpritesManager.TwilightStandNormal.GetComponent<SpriteRenderer>().DOFade(0, .5f);
                tsSpritesManager.WhiteScreen.GetComponent<Image>().DOFade(0, 0f);
                Invoke("Event6Delay", 1f);
                Invoke("Event6Delay2", 1.25f);
                Invoke("Event6Delay3", 2.25f);
            }
            else
            {
                tsMainScript.Clickable = true;
                tsSpritesManager.dialogBox.SetActive(true);
                tsSpritesManager.fluttershyStandShocked.gameObject.SetActive(true);
                ProceedText(true, false);
            }
        }
        else if (eventID == 7)
        {
            tsMainScript.Clickable = true;
            tsSpritesManager.dialogBox.SetActive(true);
            tsMainScript.DialogIndex = 8;
            tsSpritesManager.BackgroundUpdate("FluttershysCottage");
            if (!isContinue)
            {
                tsSpritesManager.fluttershyStandShocked.gameObject.SetActive(false);
            }
            tsSpritesManager.TwilightStandHappy.SetActive(true);
            ProceedText(isContinue, false);
        }
        else if (eventID == 8)
        {
            tsMainScript.DialogIndex = 9;
            tsSpritesManager.BackgroundUpdate("FluttershysCottage");
            if (!isContinue)
            {
                tsMainScript.Clickable = false;
                tsSpritesManager.dialogBox.SetActive(false);
                tsSpritesManager.TwilightStandHappy.SetActive(false);
                Invoke("Event8Delay", 1f);
            }
            else
            {

                tsMainScript.Clickable = true;
                tsSpritesManager.dialogBox.SetActive(true);
                ProceedText(true, false);
            }
            tsSpritesManager.fluttershyStandWorried.gameObject.SetActive(true);
        }
        else if (eventID == 9)
        {
            tsMainScript.Clickable = true;
            tsSpritesManager.dialogBox.SetActive(true);
            tsMainScript.DialogIndex = 10;
            tsSpritesManager.BackgroundUpdate("FluttershysCottage");
            if (!isContinue)
            {
                tsSpritesManager.fluttershyStandWorried.gameObject.SetActive(false);
            }
            tsSpritesManager.fluttershySitScared.gameObject.SetActive(true);
            ProceedText(isContinue, false);
        }
        else if (eventID == 10)
        {
            tsMainScript.Clickable = true;
            tsSpritesManager.dialogBox.SetActive(true);
            tsMainScript.DialogIndex = 11;
            tsSpritesManager.BackgroundUpdate("FluttershysCottage");
            tsSpritesManager.fluttershySitScared.gameObject.SetActive(true);
            ProceedText(isContinue, false);
        }
        else if (eventID == 11)
        {
            tsMainScript.Clickable = true;
            tsSpritesManager.dialogBox.SetActive(true);
            tsMainScript.DialogIndex = 12;
            tsSpritesManager.BackgroundUpdate("FluttershysCottage");
            tsSpritesManager.fluttershySitScared.gameObject.SetActive(true);
            ProceedText(isContinue, false);
        }
        else if (eventID == 12)
        {
            tsMainScript.DialogIndex = 13;
            tsSpritesManager.BackgroundUpdate("FluttershysCottage");
            if (!isContinue)
            {
                tsMainScript.Clickable = false;
                tsSpritesManager.dialogBox.SetActive(false);
                Invoke("Event12Delay", 2.4f);
                Invoke("Event12Delay2", 2.5f);
                Invoke("Event12Delay3", 2.75f);
            }
            else
            {
                tsMainScript.Clickable = true;
                tsSpritesManager.dialogBox.SetActive(true);
                tsSpritesManager.fluttershyStandUmm.gameObject.SetActive(true);
                ProceedText(true, false);
            }
        }
        else if (eventID == 13)
        {
            tsMainScript.Clickable = true;
            tsSpritesManager.dialogBox.SetActive(true);
            tsMainScript.DialogIndex = 14;
            tsSpritesManager.BackgroundUpdate("FluttershysCottage");
            if (!isContinue)
            {
                tsSpritesManager.fluttershyStandUmm.gameObject.SetActive(false);
            }
            tsSpritesManager.TwilightStandConfused.SetActive(true);
            ProceedText(isContinue, false);
        }
        else if (eventID == 14)
        {
            tsMainScript.Clickable = true;
            tsSpritesManager.dialogBox.SetActive(true);
            tsMainScript.DialogIndex = 15;
            tsSpritesManager.BackgroundUpdate("FluttershysCottage");
            tsSpritesManager.TwilightStandConfused.SetActive(true);
            ProceedText(isContinue, false);
        }
        else if (eventID == 15)
        {
            tsMainScript.Clickable = true;
            tsSpritesManager.dialogBox.SetActive(true);
            tsMainScript.DialogIndex = 16;
            tsSpritesManager.BackgroundUpdate("FluttershysCottage");
            if (!isContinue)
            {
                tsSpritesManager.TwilightStandConfused.SetActive(false);
            }
            tsSpritesManager.TwilightStandNormal.SetActive(true);
            ProceedText(isContinue, false);
        }
        else if (eventID == 16)
        {
            tsMainScript.Clickable = true;
            tsSpritesManager.dialogBox.SetActive(true);
            tsMainScript.DialogIndex = 17;
            tsSpritesManager.BackgroundUpdate("FluttershysCottage");
            if (!isContinue)
            {
                tsSpritesManager.TwilightStandNormal.SetActive(false);
            }
            tsSpritesManager.fluttershySitScared.gameObject.SetActive(true);
            ProceedText(isContinue, false);
        }
        else if (eventID == 17)
        {
            tsMainScript.Clickable = true;
            tsSpritesManager.dialogBox.SetActive(true);
            tsMainScript.DialogIndex = 18;
            tsSpritesManager.BackgroundUpdate("FluttershysCottage");
            if (!isContinue)
            {
                tsSpritesManager.fluttershySitScared.gameObject.SetActive(false);
            }
            tsSpritesManager.TwilightStandNormal.SetActive(true);
            ProceedText(isContinue, false);
        }
        else if (eventID == 18)
        {
            tsMainScript.Clickable = true;
            tsSpritesManager.dialogBox.SetActive(true);
            tsMainScript.DialogIndex = 19;
            tsSpritesManager.BackgroundUpdate("FluttershysCottage");
            if (!isContinue)
            {
                tsSpritesManager.TwilightStandNormal.SetActive(false);
            }
            tsSpritesManager.TwilightStandConfused.SetActive(true);
            ProceedText(isContinue, false);
        }
        else if (eventID == 19)
        {
            tsMainScript.Clickable = true;
            tsSpritesManager.dialogBox.SetActive(true);
            tsMainScript.DialogIndex = 20;
            tsSpritesManager.BackgroundUpdate("FluttershysCottage");
            if (!isContinue)
            {
                tsSpritesManager.TwilightStandConfused.SetActive(false);
            }
            tsSpritesManager.TwilightStandNormal.SetActive(true);
            ProceedText(isContinue, false);
        }
        else if (eventID == 20)
        {
            tsMainScript.Clickable = true;
            tsSpritesManager.dialogBox.SetActive(true);
            tsMainScript.DialogIndex = 21;
            tsSpritesManager.BackgroundUpdate("FluttershysCottage");
            tsSpritesManager.TwilightStandNormal.SetActive(true);
            ProceedText(isContinue, false);
        }
        else if (eventID == 21)
        {
            tsMainScript.Clickable = true;
            tsSpritesManager.dialogBox.SetActive(true);
            tsMainScript.DialogIndex = 22;
            tsSpritesManager.BackgroundUpdate("FluttershysCottage");
            if (!isContinue)
            {
                tsSpritesManager.TwilightStandNormal.SetActive(false);
            }
            tsSpritesManager.TwilightSitOops.SetActive(true);
            ProceedText(isContinue, false);
        }
        else if (eventID == 22)
        {
            tsSpritesManager.dialogBox.SetActive(true);
            tsMainScript.DialogIndex = 23;
            tsSpritesManager.BackgroundUpdate("FluttershysCottage");
            tsSpritesManager.TwilightSitOops.SetActive(true);
            if (!isContinue)
            {
                tsMainScript.Clickable = false;
                AudioManager.Instance.PlaySE(SEID.se_script_012);
                Invoke("Event22Delay", 1.32f);
            }
            else
            {
                tsMainScript.Clickable = true;
                ProceedText(true, false);
            }
        }
        else if (eventID == 23)
        {
            tsMainScript.Clickable = true;
            tsSpritesManager.dialogBox.SetActive(true);
            tsMainScript.DialogIndex = 24;
            tsSpritesManager.BackgroundUpdate("FluttershysCottage");
            if (!isContinue)
            {
                tsSpritesManager.TwilightSitOops.SetActive(false);
            }
            tsSpritesManager.TwilightStandNormal.SetActive(true);
            ProceedText(isContinue, false);
        }
        else if (eventID == 24)
        {
            tsSpritesManager.dialogBox.SetActive(true);
            tsMainScript.DialogIndex = 25;
            tsSpritesManager.BackgroundUpdate("FluttershysCottage");
            if (!isContinue)
            {
                tsMainScript.Clickable = false;
                Invoke("Event24Delay", 1.3f);
            }
            else
            {
                tsMainScript.Clickable = true;
                tsSpritesManager.TwilightStandConfused.SetActive(true);
            }
            ProceedText(isContinue, false);
        }
        else if (eventID == 25)
        {
            tsMainScript.Clickable = true;
            tsSpritesManager.dialogBox.SetActive(true);
            tsMainScript.DialogIndex = 26;
            tsSpritesManager.BackgroundUpdate("FluttershysCottage");
            if (!isContinue)
            {
                tsSpritesManager.TwilightStandConfused.SetActive(false);
            }
            tsSpritesManager.fluttershySitScared.gameObject.SetActive(true);
            ProceedText(isContinue, false);
        }
        else if (eventID == 26)
        {
            tsMainScript.Clickable = true;
            tsSpritesManager.dialogBox.SetActive(true);
            tsMainScript.DialogIndex = 27;
            tsSpritesManager.BackgroundUpdate("FluttershysCottage");
            if (!isContinue)
            {
                tsSpritesManager.fluttershySitScared.gameObject.SetActive(false);
            }
            tsSpritesManager.TwilightStandNormal.SetActive(true);
            ProceedText(isContinue, false);
        }
        else if (eventID == 27)
        {
            tsMainScript.Clickable = true;
            tsSpritesManager.dialogBox.SetActive(true);
            tsMainScript.DialogIndex = 28;
            tsSpritesManager.BackgroundUpdate("FluttershysCottage");
            if (!isContinue)
            {
                tsSpritesManager.TwilightStandNormal.SetActive(false);
            }
            tsSpritesManager.TwilightStandExplain.SetActive(true);
            ProceedText(isContinue, false);
        }
        else if (eventID == 28)
        {
            tsMainScript.Clickable = true;
            tsSpritesManager.dialogBox.SetActive(true);
            tsMainScript.DialogIndex = 29;
            tsSpritesManager.BackgroundUpdate("FluttershysCottage");
            tsSpritesManager.TwilightStandExplain.SetActive(true);
            ProceedText(isContinue, false);
        }
        else if (eventID == 29)
        {
            tsMainScript.DialogIndex = 30;
            tsSpritesManager.BackgroundUpdate("FluttershysCottage");
            if (!isContinue)
            {
                tsMainScript.Clickable = false;
                tsSpritesManager.dialogBox.SetActive(false);
                tsSpritesManager.TwilightStandExplain.GetComponent<SpriteRenderer>().DOFade(0, .25f);
                tsSpritesManager.WhiteScreen.GetComponent<Image>().DOFade(0, 0);
                Invoke("Event29Delay", 2.75f);
                Invoke("Event29Delay2", 3f);
                Invoke("Event29Delay3", 4.25f);
            }
            else
            {
                tsMainScript.Clickable = true;
                tsSpritesManager.dialogBox.SetActive(true);
                tsSpritesManager.fluttershyStandNormal.gameObject.SetActive(true);
                ProceedText(true, false);
            }
        }
        else if (eventID == 30)
        {
            tsMainScript.Clickable = true;
            tsSpritesManager.dialogBox.SetActive(true);
            tsMainScript.DialogIndex = 31;
            tsSpritesManager.BackgroundUpdate("FluttershysCottage");
            tsSpritesManager.fluttershyStandNormal.gameObject.SetActive(true);
            ProceedText(isContinue, false);
        }
        else if (eventID == 31)
        {
            tsMainScript.Clickable = true;
            tsSpritesManager.dialogBox.SetActive(true);
            tsMainScript.DialogIndex = 32;
            tsSpritesManager.BackgroundUpdate("FluttershysCottage");
            tsSpritesManager.fluttershyStandNormal.gameObject.SetActive(true);
            ProceedText(isContinue, false);
        }
        else if (eventID == 32)
        {
            tsMainScript.Clickable = true;
            tsSpritesManager.dialogBox.SetActive(true);
            tsMainScript.DialogIndex = 33;
            tsSpritesManager.BackgroundUpdate("FluttershysCottage");
            if (!isContinue)
            {
                tsSpritesManager.fluttershyStandNormal.gameObject.SetActive(false);
                Invoke("Event32Delay", .5f);
            }
            else
            {
                AudioManager.Instance.PlayBGM(BGMID.Pearl_Fey);
            }
            tsSpritesManager.fluttershyStandSurprised.gameObject.SetActive(true);
            ProceedText(isContinue, false);
        }
        else if (eventID == 33)
        {
            tsMainScript.Clickable = true;
            tsSpritesManager.dialogBox.SetActive(true);
            tsMainScript.DialogIndex = 34;
            AudioManager.Instance.PlayBGM(BGMID.Pearl_Fey);
            tsSpritesManager.BackgroundUpdate("FluttershysCottage");
            tsSpritesManager.fluttershyStandSurprised.gameObject.SetActive(true);
            ProceedText(isContinue, false);
        }
        else if (eventID == 34)
        {
            tsMainScript.Clickable = true;
            tsSpritesManager.dialogBox.SetActive(true);
            tsMainScript.DialogIndex = 35;
            AudioManager.Instance.PlayBGM(BGMID.Pearl_Fey);
            tsSpritesManager.BackgroundUpdate("FluttershysCottage");
            if (!isContinue)
            {
                tsSpritesManager.fluttershyStandSurprised.gameObject.SetActive(false);
            }
            tsSpritesManager.fluttershyStandSmile.gameObject.SetActive(true);
            ProceedText(isContinue, false);
        }
        else if (eventID == 35)
        {
            tsMainScript.Clickable = true;
            tsSpritesManager.dialogBox.SetActive(true);
            tsMainScript.DialogIndex = 36;
            AudioManager.Instance.PlayBGM(BGMID.Pearl_Fey);
            tsSpritesManager.BackgroundUpdate("FluttershysCottage");
            if (!isContinue)
            {
                tsSpritesManager.fluttershyStandSmile.gameObject.SetActive(false);
            }
            tsSpritesManager.fluttershyStandWondering.gameObject.SetActive(true);
            ProceedText(isContinue, false);
        }
        else if (eventID == 36)
        {
            tsMainScript.Clickable = true;
            tsSpritesManager.dialogBox.SetActive(true);
            tsMainScript.DialogIndex = 37;
            AudioManager.Instance.PlayBGM(BGMID.Pearl_Fey);
            tsSpritesManager.BackgroundUpdate("FluttershysCottage");
            tsSpritesManager.fluttershyStandWondering.gameObject.SetActive(true);
            ProceedText(isContinue, false);
        }
        else if (eventID == 37)
        {
            tsMainScript.Clickable = true;
            tsSpritesManager.dialogBox.SetActive(true);
            tsMainScript.DialogIndex = 38;
            AudioManager.Instance.PlayBGM(BGMID.Pearl_Fey);
            tsSpritesManager.BackgroundUpdate("FluttershysCottage");
            tsSpritesManager.fluttershyStandWondering.gameObject.SetActive(true);
            ProceedText(isContinue, false);
        }
        else if (eventID == 38)
        {
            tsMainScript.Clickable = true;
            tsSpritesManager.dialogBox.SetActive(true);
            tsMainScript.DialogIndex = 39;
            AudioManager.Instance.PlayBGM(BGMID.Pearl_Fey);
            tsSpritesManager.BackgroundUpdate("FluttershysCottage");
            if (!isContinue)
            {
                tsSpritesManager.fluttershyStandWondering.gameObject.SetActive(false);
            }
            tsSpritesManager.fluttershyStandSmile.gameObject.SetActive(true);
            ProceedText(isContinue, false);
        }
        else if (eventID == 39)
        {
            tsMainScript.Clickable = false;
            tsMainScript.DialogIndex = 40;
            ProceedText(false, false);
            Invoke("Event39Delay", .8f);
        }
        else if (eventID == 40)
        {
            tsMainScript.Clickable = true;
            tsSpritesManager.dialogBox.SetActive(true);
            tsMainScript.DialogIndex = 41;
            AudioManager.Instance.PlayBGM(BGMID.Pearl_Fey);
            tsSpritesManager.BackgroundUpdate("FluttershysCottage");
            if (!isContinue)
            {
                tsSpritesManager.fluttershyStandSmile.gameObject.SetActive(false);
            }
            tsSpritesManager.twilightStandHey.gameObject.SetActive(true);
            ProceedText(isContinue, false);
        }
        else if (eventID == 41)
        {
            tsMainScript.Clickable = true;
            tsSpritesManager.dialogBox.SetActive(true);
            tsMainScript.DialogIndex = 42;
            AudioManager.Instance.PlayBGM(BGMID.Pearl_Fey);
            tsSpritesManager.BackgroundUpdate("FluttershysCottage");
            tsSpritesManager.twilightStandHey.gameObject.SetActive(true);
            ProceedText(isContinue, false);
        }
        else if (eventID == 42)
        {
            tsSpritesManager.dialogBox.SetActive(true);
            tsMainScript.DialogIndex = 43;
            AudioManager.Instance.PlayBGM(BGMID.Pearl_Fey);
            tsSpritesManager.BackgroundUpdate("FluttershysCottage");
            if (!isContinue)
            {
                tsMainScript.Clickable = false;
                Invoke("Event42Delay", 1.7f);
            }
            else
            {
                tsMainScript.Clickable = true;
                tsSpritesManager.TwilightStandNormal.SetActive(true);
            }
            ProceedText(isContinue, false);
        }
        else if (eventID == 43)
        {
            tsMainScript.Clickable = true;
            tsSpritesManager.dialogBox.SetActive(true);
            tsMainScript.DialogIndex = 44;
            AudioManager.Instance.PlayBGM(BGMID.Pearl_Fey);
            tsSpritesManager.BackgroundUpdate("FluttershysCottage");
            tsSpritesManager.TwilightStandNormal.SetActive(true);
            ProceedText(isContinue, false);
        }
        else if (eventID == 44)
        {
            tsSpritesManager.dialogBox.SetActive(true);
            tsMainScript.DialogIndex = 45;
            AudioManager.Instance.PlayBGM(BGMID.Pearl_Fey);
            tsSpritesManager.BackgroundUpdate("FluttershysCottage");
            if (!isContinue)
            {
                tsMainScript.Clickable = false;
                tsSpritesManager.TwilightStandNormal.GetComponent<SpriteRenderer>().DOFade(0, .25f);
                tsSpritesManager.fluttershyStandSmile.DOFade(0, 0);
                Invoke("Event44Delay", .25f);
                Invoke("Event44Delay2", .75f);
            }
            else
            {
                tsMainScript.Clickable = true;
                ProceedText(true, false);
            }
        }
        else if (eventID == 45)
        {
            tsMainScript.DialogIndex = 46;
            AudioManager.Instance.PlayBGM(BGMID.Pearl_Fey);
            tsSpritesManager.BackgroundUpdate("FluttershysCottage");
            tsSpritesManager.fluttershyStandGuessing.gameObject.SetActive(true);
            if (!isContinue)
            {
                tsMainScript.Clickable = false;
                tsSpritesManager.dialogBox.SetActive(false);
                tsSpritesManager.fluttershyStandSmile.gameObject.SetActive(false);
                AudioManager.Instance.PlaySE(SEID.se_script_007);
                Invoke("Event45Delay", .94f);
            }
            else
            {
                tsMainScript.Clickable = true;
                tsSpritesManager.dialogBox.SetActive(true);
                ProceedText(true, false);
            }
        }
        else if (eventID == 46)
        {
            tsMainScript.Clickable = true;
            tsSpritesManager.dialogBox.SetActive(true);
            tsMainScript.DialogIndex = 47;
            AudioManager.Instance.PlayBGM(BGMID.Pearl_Fey);
            tsSpritesManager.BackgroundUpdate("FluttershysCottage");
            if (!isContinue)
            {
                tsSpritesManager.fluttershyStandGuessing.gameObject.SetActive(false);
            }
            tsSpritesManager.fluttershyStandSurprised.gameObject.SetActive(true);
            ProceedText(isContinue, false);
        }
        else if (eventID == 47)
        {
            tsMainScript.Clickable = true;
            tsSpritesManager.dialogBox.SetActive(true);
            tsMainScript.DialogIndex = 48;
            AudioManager.Instance.PlayBGM(BGMID.Pearl_Fey);
            tsSpritesManager.BackgroundUpdate("FluttershysCottage");
            tsSpritesManager.fluttershyStandSurprised.gameObject.SetActive(true);
            ProceedText(isContinue, false);
        }
        else if (eventID == 48)
        {
            tsMainScript.Clickable = true;
            tsSpritesManager.dialogBox.SetActive(true);
            tsMainScript.DialogIndex = 49;
            AudioManager.Instance.PlayBGM(BGMID.Pearl_Fey);
            tsSpritesManager.BackgroundUpdate("FluttershysCottage");
            tsSpritesManager.fluttershyStandSurprised.gameObject.SetActive(true);
            ProceedText(isContinue, false);
        }
        else if (eventID == 49)
        {
            tsMainScript.Clickable = true;
            tsSpritesManager.dialogBox.SetActive(true);
            tsMainScript.DialogIndex = 50;
            AudioManager.Instance.PlayBGM(BGMID.Pearl_Fey);
            tsSpritesManager.BackgroundUpdate("FluttershysCottage");
            if (!isContinue)
            {
                tsSpritesManager.fluttershyStandSurprised.gameObject.SetActive(false);
            }
            tsSpritesManager.fluttershyStandNormal.gameObject.SetActive(true);
            ProceedText(isContinue, false);
        }
        else if (eventID == 50)
        {
            tsMainScript.Clickable = true;
            tsSpritesManager.dialogBox.SetActive(true);
            tsMainScript.DialogIndex = 51;
            AudioManager.Instance.PlayBGM(BGMID.Pearl_Fey);
            tsSpritesManager.BackgroundUpdate("FluttershysCottage");
            if (!isContinue)
            {
                tsSpritesManager.fluttershyStandNormal.gameObject.SetActive(false);
            }
            tsSpritesManager.fluttershySitScared.gameObject.SetActive(true);
            ProceedText(isContinue, false);
        }
        else if (eventID == 51)
        {
            tsMainScript.Clickable = true;
            tsSpritesManager.dialogBox.SetActive(true);
            tsMainScript.DialogIndex = 52;
            AudioManager.Instance.PlayBGM(BGMID.Pearl_Fey);
            tsSpritesManager.BackgroundUpdate("FluttershysCottage");
            tsSpritesManager.fluttershySitScared.gameObject.SetActive(true);
            ProceedText(isContinue, false);
        }
        else if (eventID == 52)
        {
            tsMainScript.Clickable = true;
            tsSpritesManager.dialogBox.SetActive(true);
            tsMainScript.DialogIndex = 53;
            AudioManager.Instance.PlayBGM(BGMID.Pearl_Fey);
            tsSpritesManager.BackgroundUpdate("FluttershysCottage");
            if (!isContinue)
            {
                tsSpritesManager.fluttershySitScared.gameObject.SetActive(false);
            }
            tsSpritesManager.fluttershyStandNormal.gameObject.SetActive(true);
            ProceedText(isContinue, false);
        }
        else if (eventID == 53)
        {
            tsMainScript.Clickable = true;
            tsSpritesManager.dialogBox.SetActive(true);
            tsMainScript.DialogIndex = 54;
            AudioManager.Instance.PlayBGM(BGMID.Pearl_Fey);
            tsSpritesManager.BackgroundUpdate("FluttershysCottage");
            tsSpritesManager.fluttershyStandNormal.gameObject.SetActive(true);
            ProceedText(isContinue, false);
        }
        else if (eventID == 54)
        {
            tsMainScript.Clickable = true;
            tsSpritesManager.dialogBox.SetActive(true);
            tsMainScript.DialogIndex = 55;
            AudioManager.Instance.PlayBGM(BGMID.Pearl_Fey);
            tsSpritesManager.BackgroundUpdate("FluttershysCottage");
            tsSpritesManager.fluttershyStandNormal.gameObject.SetActive(true);
            ProceedText(isContinue, false);
        }
        else if (eventID == 55)
        {
            tsMainScript.Clickable = true;
            tsSpritesManager.dialogBox.SetActive(true);
            tsMainScript.DialogIndex = 56;
            AudioManager.Instance.PlayBGM(BGMID.Pearl_Fey);
            tsSpritesManager.BackgroundUpdate("FluttershysCottage");
            if (!isContinue)
            {
                tsSpritesManager.fluttershyStandNormal.gameObject.SetActive(false);
            }
            tsSpritesManager.fluttershyStandGuessing.gameObject.SetActive(true);
            ProceedText(isContinue, false);
        }
        else if (eventID == 56)
        {
            tsMainScript.Clickable = true;
            tsSpritesManager.dialogBox.SetActive(true);
            tsMainScript.DialogIndex = 57;
            AudioManager.Instance.PlayBGM(BGMID.Pearl_Fey);
            tsSpritesManager.BackgroundUpdate("FluttershysCottage");
            tsSpritesManager.fluttershyStandGuessing.gameObject.SetActive(true);
            ProceedText(isContinue, false);
        }
        else if (eventID == 57)
        {
            tsMainScript.Clickable = false;
            tsMainScript.DialogIndex = 58;
            tsSpritesManager.fluttershyStandGuessing.gameObject.SetActive(false);
            tsSpritesManager.fluttershyStandNormal.gameObject.SetActive(true);
            ProceedText(false, false);
            tsSpritesManager.WhiteScreen.GetComponent<Image>().DOFade(0, 0);
            Invoke("Event57Delay", 1.05f);
            Invoke("Event57Delay2", 1.3f);
            Invoke("Event57Delay3", 2.05f);
        }
        else if (eventID == 58)
        {
            tsMainScript.Clickable = true;
            tsSpritesManager.dialogBox.SetActive(true);
            tsMainScript.DialogIndex = 59;
            AudioManager.Instance.PlayBGM(BGMID.Pearl_Fey);
            tsSpritesManager.BackgroundUpdate("FluttershysCottage");
            if (!isContinue)
            {
                tsSpritesManager.WhiteScreen.SetActive(false);
                tsSpritesManager.WhiteScreen.GetComponent<Image>().DOFade(1, 0);
                tsSpritesManager.fluttershyStandShocked.gameObject.SetActive(false);
            }
            tsSpritesManager.fluttershySitScared.gameObject.SetActive(true);
            ProceedText(isContinue, false);
        }
        else if (eventID == 59)
        {
            tsMainScript.Clickable = true;
            tsSpritesManager.dialogBox.SetActive(true);
            tsMainScript.DialogIndex = 60;
            AudioManager.Instance.PlayBGM(BGMID.Pearl_Fey);
            tsSpritesManager.BackgroundUpdate("FluttershysCottage");
            tsSpritesManager.fluttershySitScared.gameObject.SetActive(true);
            ProceedText(isContinue, false);
        }
        else if (eventID == 60)
        {
            tsMainScript.Clickable = true;
            tsSpritesManager.dialogBox.SetActive(true);
            tsMainScript.DialogIndex = 61;
            AudioManager.Instance.PlayBGM(BGMID.Pearl_Fey);
            tsSpritesManager.BackgroundUpdate("FluttershysCottage");
            tsSpritesManager.fluttershySitScared.gameObject.SetActive(true);
            ProceedText(isContinue, false);
        }
        else if (eventID == 61)
        {
            tsSpritesManager.dialogBox.SetActive(true);
            tsMainScript.DialogIndex = 62;
            AudioManager.Instance.PlayBGM(BGMID.Pearl_Fey);
            tsSpritesManager.BackgroundUpdate("FluttershysCottage");
            if (!isContinue)
            {
                tsMainScript.Clickable = false;
                Invoke("Event61Delay", 1.5f);
            }
            else
            {
                tsMainScript.Clickable = true;
            }
            tsSpritesManager.fluttershySitScared.gameObject.SetActive(true);
            ProceedText(isContinue, false);
        }
        else if (eventID == 62)
        {
            tsMainScript.Clickable = true;
            tsSpritesManager.dialogBox.SetActive(true);
            tsMainScript.DialogIndex = 63;
            AudioManager.Instance.PlayBGM(BGMID.Pearl_Fey);
            tsSpritesManager.BackgroundUpdate("FluttershysCottage");
            if (!isContinue)
            {
                tsSpritesManager.fluttershySitScared.gameObject.SetActive(false);
            }
            tsSpritesManager.fluttershyStandGuessing.gameObject.SetActive(true);
            ProceedText(isContinue, false);
        }
        else if (eventID == 63)
        {
            tsMainScript.Clickable = true;
            tsSpritesManager.dialogBox.SetActive(true);
            tsMainScript.DialogIndex = 64;
            AudioManager.Instance.PlayBGM(BGMID.Pearl_Fey);
            tsSpritesManager.BackgroundUpdate("FluttershysCottage");
            if (!isContinue)
            {
                tsSpritesManager.fluttershySitScared.gameObject.SetActive(false);
            }
            tsSpritesManager.fluttershyStandGuessing.gameObject.SetActive(true);
            ProceedText(isContinue, false);
        }
        else if (eventID == 64)
        {
            tsMainScript.Clickable = true;
            tsSpritesManager.dialogBox.SetActive(true);
            tsMainScript.DialogIndex = 65;
            AudioManager.Instance.PlayBGM(BGMID.Pearl_Fey);
            tsSpritesManager.BackgroundUpdate("FluttershysCottage");
            if (!isContinue)
            {
                tsSpritesManager.fluttershyStandGuessing.gameObject.SetActive(false);
            }
            tsSpritesManager.fluttershyStandNormal.gameObject.SetActive(true);
            ProceedText(isContinue, false);
        }
        else if (eventID == 65)
        {
            tsMainScript.DialogIndex = 66;
            AudioManager.Instance.PlayBGM(BGMID.Pearl_Fey);
            tsSpritesManager.BackgroundUpdate("FluttershysCottage");
            if (!isContinue)
            {
                tsMainScript.Clickable = false;
                tsSpritesManager.dialogBox.SetActive(false);
                tsSpritesManager.fluttershyStandNormal.DOFade(0, .25f);
                tsSpritesManager.TwilightStandNormal.GetComponent<SpriteRenderer>().DOFade(0, 0);
                Invoke("Event65Delay", .25f);
                Invoke("Event65Delay2", .5f);
            }
            else
            {
                tsMainScript.Clickable = true;
                tsSpritesManager.dialogBox.SetActive(true);
                tsSpritesManager.TwilightStandNormal.SetActive(true);
                ProceedText(true, false);
            }
        }
        else if (eventID == 66)
        {
            tsMainScript.DialogIndex = 67;
            AudioManager.Instance.PlayBGM(BGMID.Pearl_Fey);
            tsSpritesManager.BackgroundUpdate("FluttershysCottage");
            if (!isContinue)
            {
                tsMainScript.Clickable = false;
                tsSpritesManager.dialogBox.SetActive(false);
                tsSpritesManager.TwilightStandNormal.GetComponent<SpriteRenderer>().DOFade(0, .25f);
                tsSpritesManager.fluttershySitScared.DOFade(0, 0);
                Invoke("Event66Delay", .25f);
                Invoke("Event66Delay2", .5f);
            }
            else
            {
                tsMainScript.Clickable = true;
                tsSpritesManager.dialogBox.SetActive(true);
                tsSpritesManager.fluttershySitScared.gameObject.SetActive(true);
                ProceedText(true, false);
            }
        }
        else if (eventID == 67)
        {
            tsMainScript.Clickable = true;
            tsSpritesManager.dialogBox.SetActive(true);
            tsMainScript.DialogIndex = 68;
            AudioManager.Instance.PlayBGM(BGMID.Pearl_Fey);
            tsSpritesManager.BackgroundUpdate("FluttershysCottage");
            tsSpritesManager.fluttershySitScared.gameObject.SetActive(true);
            ProceedText(isContinue, false);
        }
        else if (eventID == 68)
        {
            tsMainScript.Clickable = true;
            tsSpritesManager.dialogBox.SetActive(true);
            tsMainScript.DialogIndex = 69;
            AudioManager.Instance.PlayBGM(BGMID.Pearl_Fey);
            tsSpritesManager.BackgroundUpdate("FluttershysCottage");
            tsSpritesManager.fluttershySitScared.gameObject.SetActive(true);
            ProceedText(isContinue, false);
        }
        else if (eventID == 69)
        {
            tsMainScript.Clickable = true;
            tsSpritesManager.dialogBox.SetActive(true);
            tsMainScript.DialogIndex = 70;
            AudioManager.Instance.PlayBGM(BGMID.Pearl_Fey);
            tsSpritesManager.BackgroundUpdate("FluttershysCottage");
            if (!isContinue)
            {
                tsSpritesManager.fluttershySitScared.gameObject.SetActive(false);
            }
            tsSpritesManager.fluttershyStandSoundsGood.gameObject.SetActive(true);
            ProceedText(isContinue, false);
        }
        else if (eventID == 70)
        {
            tsMainScript.Clickable = true;
            tsSpritesManager.dialogBox.SetActive(true);
            tsMainScript.DialogIndex = 71;
            AudioManager.Instance.PlayBGM(BGMID.Pearl_Fey);
            tsSpritesManager.BackgroundUpdate("FluttershysCottage");
            if (!isContinue)
            {
                tsSpritesManager.fluttershyStandSoundsGood.gameObject.SetActive(false);
            }
            tsSpritesManager.fluttershyStandSmile.gameObject.SetActive(true);
            ProceedText(isContinue, false);
        }
        else if (eventID == 71)
        {
            tsMainScript.Clickable = true;
            tsSpritesManager.dialogBox.SetActive(true);
            tsMainScript.DialogIndex = 72;
            AudioManager.Instance.PlayBGM(BGMID.Pearl_Fey);
            tsSpritesManager.BackgroundUpdate("FluttershysCottage");
            tsSpritesManager.fluttershyStandSmile.gameObject.SetActive(true);
            ProceedText(isContinue, false);
        }
        else if (eventID == 72)
        {
            tsMainScript.Clickable = true;
            tsSpritesManager.dialogBox.SetActive(true);
            tsMainScript.DialogIndex = 73;
            AudioManager.Instance.PlayBGM(BGMID.Pearl_Fey);
            tsSpritesManager.BackgroundUpdate("FluttershysCottage");
            if (!isContinue)
            {
                tsSpritesManager.fluttershyStandSmile.gameObject.SetActive(false);
            }
            tsSpritesManager.fluttershyStandSurprised.gameObject.SetActive(true);
            ProceedText(isContinue, false);
        }
        else if (eventID == 73)
        {
            tsMainScript.Clickable = true;
            tsSpritesManager.dialogBox.SetActive(true);
            tsMainScript.DialogIndex = 74;
            AudioManager.Instance.PlayBGM(BGMID.Pearl_Fey);
            tsSpritesManager.BackgroundUpdate("FluttershysCottage");
            tsSpritesManager.fluttershyStandSurprised.gameObject.SetActive(true);
            ProceedText(isContinue, false);
        }
        else if (eventID == 74)
        {
            tsMainScript.Clickable = true;
            tsSpritesManager.dialogBox.SetActive(true);
            tsMainScript.DialogIndex = 75;
            AudioManager.Instance.PlayBGM(BGMID.Pearl_Fey);
            tsSpritesManager.BackgroundUpdate("FluttershysCottage");
            if (!isContinue)
            {
                tsSpritesManager.fluttershyStandSurprised.gameObject.SetActive(false);
            }
            tsSpritesManager.fluttershyStandOhMy.gameObject.SetActive(true);
            ProceedText(isContinue, false);
        }
        else if (eventID == 75)
        {
            tsMainScript.Clickable = true;
            tsSpritesManager.dialogBox.SetActive(true);
            tsMainScript.DialogIndex = 76;
            AudioManager.Instance.PlayBGM(BGMID.Pearl_Fey);
            tsSpritesManager.BackgroundUpdate("FluttershysCottage");
            if (!isContinue)
            {
                tsSpritesManager.fluttershyStandOhMy.gameObject.SetActive(false);
            }
            tsSpritesManager.fluttershySitScared.gameObject.SetActive(true);
            ProceedText(isContinue, false);
        }
        else if (eventID == 76)
        {
            tsMainScript.Clickable = true;
            tsSpritesManager.dialogBox.SetActive(true);
            tsMainScript.DialogIndex = 77;
            AudioManager.Instance.PlayBGM(BGMID.Pearl_Fey);
            tsSpritesManager.BackgroundUpdate("FluttershysCottage");
            tsSpritesManager.fluttershySitScared.gameObject.SetActive(true);
            ProceedText(isContinue, false);
        }
        else if (eventID == 77)
        {
            tsMainScript.DialogIndex = 78;
            AudioManager.Instance.PlayBGM(BGMID.Pearl_Fey);
            tsSpritesManager.BackgroundUpdate("FluttershysCottage");
            if (!isContinue)
            {
                tsMainScript.Clickable = false;
                tsSpritesManager.dialogBox.SetActive(false);
                tsSpritesManager.fluttershySitScared.DOFade(0, .25f);
                tsSpritesManager.TwilightStandNormal.GetComponent<SpriteRenderer>().DOFade(0, 0);
                Invoke("Event77Delay", .25f);
                Invoke("Event77Delay2", .5f);
            }
            else
            {
                tsMainScript.Clickable = true;
                tsSpritesManager.dialogBox.SetActive(true);
                tsSpritesManager.TwilightStandNormal.SetActive(true);
                ProceedText(true, false);
            }
        }
        else if (eventID == 78)
        {
            tsSpritesManager.dialogBox.SetActive(true);
            tsMainScript.DialogIndex = 79;
            AudioManager.Instance.PlayBGM(BGMID.Pearl_Fey);
            tsSpritesManager.BackgroundUpdate("FluttershysCottage");
            if (!isContinue)
            {
                tsMainScript.Clickable = false;
                tsSpritesManager.TwilightStandNormal.GetComponent<SpriteRenderer>().DOFade(0, .25f);
                tsSpritesManager.fluttershyStandSmile.DOFade(0, 0);
                Invoke("Event78Delay", .25f);
                Invoke("Event78Delay2", .5f);
            }
            else
            {
                tsMainScript.Clickable = true;
                tsSpritesManager.fluttershyStandSmile.gameObject.SetActive(true);
                ProceedText(true, false);
            }
        }
        else if (eventID == 79)
        {
            tsMainScript.DialogIndex = 80;
            AudioManager.Instance.PlayBGM(BGMID.Pearl_Fey);
            tsSpritesManager.BackgroundUpdate("FluttershysCottage");
            if (!isContinue)
            {
                tsMainScript.Clickable = false;
                tsSpritesManager.dialogBox.SetActive(false);
                tsSpritesManager.fluttershyStandSmile.DOFade(0, .5f);
                tsSpritesManager.TwilightStandNormal.GetComponent<SpriteRenderer>().DOFade(0, 0);
                if (!courtRecordsSystem.DoIHaveThisProfile(4))
                {
                    courtRecordsSystem.GetNewProfile(4);
                }
                Invoke("Event79Delay", 1f);
                Invoke("Event79Delay2", 1.5f);
            }
            else
            {
                tsMainScript.Clickable = true;
                tsSpritesManager.dialogBox.SetActive(true);
                tsSpritesManager.TwilightStandNormal.gameObject.SetActive(true);
                ProceedText(true, false);
            }
        }
        else if (eventID == 80)
        {
            tsMainScript.Clickable = true;
            tsSpritesManager.dialogBox.SetActive(true);
            tsMainScript.DialogIndex = 81;
            AudioManager.Instance.PlayBGM(BGMID.Pearl_Fey);
            tsSpritesManager.BackgroundUpdate("FluttershysCottage");
            tsSpritesManager.TwilightStandNormal.gameObject.SetActive(true);
            ProceedText(isContinue, false);
        }
        else if (eventID == 81)
        {
            tsMainScript.Clickable = true;
            tsSpritesManager.dialogBox.SetActive(true);
            tsMainScript.DialogIndex = 82;
            AudioManager.Instance.PlayBGM(BGMID.Pearl_Fey);
            tsSpritesManager.BackgroundUpdate("FluttershysCottage");
            if (!isContinue)
            {
                tsSpritesManager.TwilightStandNormal.gameObject.SetActive(false);
            }
            tsSpritesManager.TwilightStandConfused.gameObject.SetActive(true);
            ProceedText(isContinue, false);
        }
        else if (eventID == 82)
        {
            tsMainScript.Clickable = true;
            tsSpritesManager.dialogBox.SetActive(true);
            tsMainScript.DialogIndex = 83;
            AudioManager.Instance.PlayBGM(BGMID.Pearl_Fey);
            tsSpritesManager.BackgroundUpdate("FluttershysCottage");
            tsSpritesManager.WhiteScreen.GetComponent<Image>().DOFade(0, 0);
            if (!isContinue)
            {
                tsSpritesManager.TwilightStandConfused.gameObject.SetActive(false);
            }
            tsSpritesManager.TwilightStandNormal.gameObject.SetActive(true);
            ProceedText(isContinue, false);
        }
        else if (eventID == 83)
        {
            tsMainScript.Clickable = false;
            tsSpritesManager.dialogBox.SetActive(false);
            tsMainScript.DialogIndex = 84;
            AudioManager.Instance.StopBGM(false);
            AudioManager.Instance.PlaySE(SEID.se_script_011);
            tsSpritesManager.WhiteScreen.SetActive(true);
            tsSpritesManager.WhiteScreen.GetComponent<Image>().DOFade(1, .25f);
            Invoke("Event83Delay", .25f);
            Invoke("Event83Delay2", 1.21f);
            Invoke("Event83Delay3", 1.41f);
            Invoke("Event83Delay4", 2.81f);
            Invoke("Event83Delay5", 3.06f);
            Invoke("Event83Delay6", 3.31f);
        }
        else if (eventID == 84)
        {
            tsSpritesManager.dialogBox.SetActive(true);
            tsMainScript.DialogIndex = 85;
            ProceedText(false, false);
            Invoke("Event84Delay", 1.2f);
            Invoke("Event84Delay2", 1.45f);
            Invoke("Event84Delay3", 1.7f);
        }
        else if (eventID == 85)
        {
            tsMainScript.Clickable = true;
            tsSpritesManager.dialogBox.SetActive(true);
            tsMainScript.DialogIndex = 86;
            tsSpritesManager.BackgroundUpdate("FluttershysCottage");
            tsSpritesManager.TwilightStandNormal.gameObject.SetActive(true);
            ProceedText(isContinue, false);
        }
        else if (eventID == 86)
        {
            tsMainScript.Clickable = true;
            tsSpritesManager.dialogBox.SetActive(true);
            tsMainScript.DialogIndex = 87;
            tsSpritesManager.BackgroundUpdate("FluttershysCottage");
            if (!isContinue)
            {
                tsSpritesManager.TwilightStandNormal.gameObject.SetActive(false);
            }
            tsSpritesManager.TwilightStandConfused.gameObject.SetActive(true);
            ProceedText(isContinue, false);
        }
        else if (eventID == 87)
        {
            tsMainScript.Clickable = true;
            tsSpritesManager.dialogBox.SetActive(true);
            tsMainScript.DialogIndex = 88;
            tsSpritesManager.BackgroundUpdate("FluttershysCottage");
            if (!isContinue)
            {
                tsSpritesManager.TwilightStandConfused.gameObject.SetActive(false);
            }
            tsSpritesManager.TwilightStandNormal.gameObject.SetActive(true);
            ProceedText(isContinue, false);
        }
        else if (eventID == 88)
        {
            tsMainScript.Clickable = true;
            tsSpritesManager.dialogBox.SetActive(true);
            tsMainScript.DialogIndex = 89;
            tsSpritesManager.BackgroundUpdate("FluttershysCottage");
            tsSpritesManager.TwilightStandNormal.gameObject.SetActive(true);
            ProceedText(isContinue, false);
        }
        else if (eventID == 89)
        {
            tsMainScript.Clickable = true;
            tsSpritesManager.dialogBox.SetActive(true);
            tsMainScript.DialogIndex = 90;
            tsSpritesManager.BackgroundUpdate("FluttershysCottage");
            if (!isContinue)
            {
                tsSpritesManager.TwilightStandNormal.gameObject.SetActive(false);
            }
            tsSpritesManager.TwilightStandStartled.gameObject.SetActive(true);
            ProceedText(isContinue, false);
        }
        else if (eventID == 90)
        {
            tsMainScript.Clickable = true;
            tsSpritesManager.dialogBox.SetActive(true);
            tsMainScript.DialogIndex = 91;
            tsSpritesManager.BackgroundUpdate("FluttershysCottage");
            if (!isContinue)
            {
                tsSpritesManager.TwilightStandStartled.gameObject.SetActive(false);
            }
            tsSpritesManager.twilightStandOMG.gameObject.SetActive(true);
            ProceedText(isContinue, false);
        }
        else if (eventID == 91)
        {
            tsMainScript.Clickable = true;
            tsSpritesManager.dialogBox.SetActive(true);
            tsMainScript.DialogIndex = 92;
            tsSpritesManager.BackgroundUpdate("FluttershysCottage");
            if (!isContinue)
            {
                tsSpritesManager.twilightStandOMG.gameObject.SetActive(false);
            }
            tsSpritesManager.TwilightStandNormal.gameObject.SetActive(true);
            ProceedText(isContinue, false);
        }
        else if (eventID == 92)
        {
            tsSpritesManager.dialogBox.SetActive(true);
            tsMainScript.DialogIndex = 93;
            tsSpritesManager.BackgroundUpdate("FluttershysCottage");
            if (!isContinue)
            {
                tsMainScript.Clickable = false;
                Invoke("Event92Delay", 4.1f);
            }
            else
            {
                tsMainScript.Clickable = true;
                tsSpritesManager.TwilightSitSad.SetActive(true);
            }
            ProceedText(isContinue, false);
        }
        else if (eventID == 93)
        {
            tsMainScript.Clickable = true;
            tsSpritesManager.dialogBox.SetActive(true);
            tsMainScript.DialogIndex = 94;
            tsSpritesManager.BackgroundUpdate("FluttershysCottage");
            tsSpritesManager.TwilightSitSad.SetActive(true);
            ProceedText(isContinue, false);
        }
        else if (eventID == 94)
        {
            tsMainScript.Clickable = true;
            tsSpritesManager.dialogBox.SetActive(true);
            tsMainScript.DialogIndex = 95;
            tsSpritesManager.BackgroundUpdate("FluttershysCottage");
            if (!isContinue)
            {
                tsSpritesManager.TwilightSitSad.SetActive(false);
            }
            tsSpritesManager.TwilightStandHappy.SetActive(true);
            ProceedText(isContinue, false);
        }
        else if (eventID == 95)
        {
            tsMainScript.Clickable = true;
            tsSpritesManager.dialogBox.SetActive(true);
            tsMainScript.DialogIndex = 96;
            tsSpritesManager.BackgroundUpdate("FluttershysCottage");
            if (!isContinue)
            {
                tsSpritesManager.TwilightStandHappy.SetActive(false);
            }
            tsSpritesManager.TwilightStandNormal.SetActive(true);
            ProceedText(isContinue, false);
        }
        else if (eventID == 96)
        {
            tsMainScript.Clickable = true;
            tsSpritesManager.dialogBox.SetActive(true);
            tsMainScript.DialogIndex = 97;
            tsSpritesManager.BackgroundUpdate("FluttershysCottage");
            tsSpritesManager.TwilightStandNormal.SetActive(true);
            tsSpritesManager.blackScreen.DOFade(0, 0);
            ProceedText(isContinue, false);
        }
        else if (eventID == 97)
        {
            tsMainScript.Clickable = false;
            tsSpritesManager.dialogBox.SetActive(false);
            tsSpritesManager.blackScreen.gameObject.SetActive(true);
            tsSpritesManager.blackScreen.DOFade(1, 5f);
            Invoke("Event97Delay", 7.5f);
        }
        else
        {
            tsMainScript.EventID -= 1;
            Debug.Log("Event " + eventID + "无对应事件。");
            tsMainScript.Proceed = false;
            tsMainScript.DialogProcessing = false;
        }
    }

    public void Event0Delay()
    {
        tsSpritesManager.blackScreen.gameObject.SetActive(false);
        tsSpritesManager.blackScreen.DOFade(1, 0f);
        ProceedText(false, false);
        tsMainScript.Clickable = true;
    }
    public void Event1Delay()
    {
        tsSpritesManager.TwilightStandNormal.SetActive(true);
        tsSpritesManager.TwilightStandNormal.GetComponent<SpriteRenderer>().DOFade(1, .5f);
    }
    public void Event1Delay2()
    {
        tsSpritesManager.dialogBox.SetActive(true);
        ProceedText(false, false);
        tsMainScript.Clickable = true;
    }
    public void Event6Delay()
    {
        tsSpritesManager.TwilightStandNormal.SetActive(false);
        tsSpritesManager.TwilightStandNormal.GetComponent<SpriteRenderer>().DOFade(1, 0f);
        tsSpritesManager.WhiteScreen.SetActive(true);
        tsSpritesManager.WhiteScreen.GetComponent<Image>().DOFade(1, .25f);
    }
    public void Event6Delay2()
    {
        tsSpritesManager.fluttershyStandShocked.gameObject.SetActive(true);
        tsSpritesManager.WhiteScreen.GetComponent<Image>().DOFade(0, .25f);
        AudioManager.Instance.PlaySE(SEID.se_script_007);
    }
    public void Event6Delay3()
    {
        tsSpritesManager.WhiteScreen.SetActive(false);
        tsSpritesManager.WhiteScreen.GetComponent<Image>().DOFade(1, 0);
        tsSpritesManager.dialogBox.SetActive(true);
        ProceedText(false, false);
        tsMainScript.Clickable = true;
    }
    public void Event8Delay()
    {
        tsMainScript.Clickable = true;
        tsSpritesManager.dialogBox.SetActive(true);
        ProceedText(false, false);
    }
    public void Event12Delay()
    {
        tsSpritesManager.WhiteScreen.SetActive(true);
    }
    public void Event12Delay2()
    {
        tsSpritesManager.WhiteScreen.GetComponent<Image>().DOFade(0, .25f);
        AudioManager.Instance.PlaySE(SEID.se_script_011);
        tsSpritesManager.fluttershySitScared.gameObject.SetActive(false);
        tsSpritesManager.fluttershyStandUmm.gameObject.SetActive(true);
        tsMainScript.Clickable = true;
        tsSpritesManager.dialogBox.SetActive(true);
        ProceedText(false, false);
    }
    public void Event12Delay3()
    {
        tsSpritesManager.WhiteScreen.SetActive(false);
        tsSpritesManager.WhiteScreen.GetComponent<Image>().DOFade(1, 0);
    }
    public void Event22Delay()
    {
        tsMainScript.Clickable = true;
        ProceedText(false, false);
    }
    public void Event24Delay()
    {
        tsMainScript.Clickable = true;
        tsSpritesManager.TwilightStandNormal.SetActive(false);
        tsSpritesManager.TwilightStandConfused.SetActive(true);
    }
    public void Event29Delay()
    {
        tsSpritesManager.WhiteScreen.SetActive(true);
        tsSpritesManager.WhiteScreen.GetComponent<Image>().DOFade(1, .25f);
    }
    public void Event29Delay2()
    {
        tsSpritesManager.fluttershyStandNormal.gameObject.SetActive(true);
        tsSpritesManager.WhiteScreen.GetComponent<Image>().DOFade(0, .25f);
        AudioManager.Instance.PlaySE(SEID.se_script_011);
    }
    public void Event29Delay3()
    {
        tsSpritesManager.WhiteScreen.SetActive(false);
        tsSpritesManager.WhiteScreen.GetComponent<Image>().DOFade(1, 0);
        tsMainScript.Clickable = true;
        tsSpritesManager.dialogBox.SetActive(true);
        ProceedText(false, false);
    }
    public void Event32Delay()
    {
        AudioManager.Instance.PlayBGM(BGMID.Pearl_Fey);
    }
    public void Event39Delay()
    {
        tsMainScript.EventID = 40;
        tsMainScript.Proceed = true;
    }
    public void Event42Delay()
    {
        tsMainScript.Clickable = true;
        tsSpritesManager.twilightStandHey.gameObject.SetActive(false);
        tsSpritesManager.TwilightStandNormal.SetActive(true);
    }
    public void Event44Delay()
    {
        tsSpritesManager.TwilightStandNormal.SetActive(false);
        tsSpritesManager.TwilightStandNormal.GetComponent<SpriteRenderer>().DOFade(1, 0);
        tsSpritesManager.fluttershyStandSmile.gameObject.SetActive(true);
        tsSpritesManager.fluttershyStandSmile.DOFade(1, .25f);
    }
    public void Event44Delay2()
    {
        tsMainScript.Clickable = true;
        ProceedText(false, false);
    }
    public void Event45Delay()
    {
        tsMainScript.Clickable = true;
        tsSpritesManager.dialogBox.SetActive(true);
        ProceedText(false, false);
    }
    public void Event57Delay()
    {
        tsSpritesManager.WhiteScreen.SetActive(true);
        tsSpritesManager.WhiteScreen.GetComponent<Image>().DOFade(1, .25f);
    }
    public void Event57Delay2()
    {
        AudioManager.Instance.PlaySE(SEID.se_script_007);
        tsSpritesManager.WhiteScreen.GetComponent<Image>().DOFade(0, .25f);
        tsSpritesManager.dialogBox.SetActive(false);
        tsSpritesManager.fluttershyStandNormal.gameObject.SetActive(false);
        tsSpritesManager.fluttershyStandShocked.gameObject.SetActive(true);
    }
    public void Event57Delay3()
    {
        tsMainScript.EventID = 58;
        tsMainScript.Proceed = true;
    }
    public void Event61Delay()
    {
        AudioManager.Instance.PlaySE(SEID.explode);
        tsSpritesManager.fluttershysCottage.GetComponent<Transform>().DOShakePosition(.3f, new Vector3(2, 2, 0)).SetLoops(1, LoopType.Yoyo);
        tsMainScript.Clickable = true;
    }
    public void Event65Delay()
    {
        tsSpritesManager.TwilightStandNormal.SetActive(true);
        tsSpritesManager.TwilightStandNormal.GetComponent<SpriteRenderer>().DOFade(1, .25f);
        tsSpritesManager.fluttershyStandNormal.gameObject.SetActive(false);
        tsSpritesManager.fluttershyStandNormal.DOFade(1, 0);
    }
    public void Event65Delay2()
    {
        tsMainScript.Clickable = true;
        tsSpritesManager.dialogBox.SetActive(true);
        ProceedText(false, false);
    }
    public void Event66Delay()
    {
        tsSpritesManager.fluttershySitScared.gameObject.SetActive(true);
        tsSpritesManager.fluttershySitScared.DOFade(1, .25f);
        tsSpritesManager.TwilightStandNormal.SetActive(false);
        tsSpritesManager.TwilightStandNormal.GetComponent<SpriteRenderer>().DOFade(1, 0);
    }
    public void Event66Delay2()
    {
        tsMainScript.Clickable = true;
        tsSpritesManager.dialogBox.SetActive(true);
        ProceedText(false, false);
    }
    public void Event77Delay()
    {
        tsSpritesManager.TwilightStandNormal.SetActive(true);
        tsSpritesManager.TwilightStandNormal.GetComponent<SpriteRenderer>().DOFade(1, .25f);
        tsSpritesManager.fluttershySitScared.gameObject.SetActive(false);
        tsSpritesManager.fluttershySitScared.DOFade(1, 0);
    }
    public void Event77Delay2()
    {
        tsMainScript.Clickable = true;
        tsSpritesManager.dialogBox.SetActive(true);
        ProceedText(false, false);
    }
    public void Event78Delay()
    {
        tsSpritesManager.fluttershyStandSmile.gameObject.SetActive(true);
        tsSpritesManager.fluttershyStandSmile.DOFade(1, .25f);
        tsSpritesManager.TwilightStandNormal.SetActive(false);
        tsSpritesManager.TwilightStandNormal.GetComponent<SpriteRenderer>().DOFade(1, 0);
    }
    public void Event78Delay2()
    {
        tsMainScript.Clickable = true;
        ProceedText(false, false);
    }
    public void Event79Delay()
    {
        tsSpritesManager.TwilightStandNormal.SetActive(true);
        tsSpritesManager.TwilightStandNormal.GetComponent<SpriteRenderer>().DOFade(1, .5f);
        tsSpritesManager.fluttershyStandSmile.gameObject.SetActive(false);
        tsSpritesManager.fluttershyStandSmile.DOFade(1, 0);
    }
    public void Event79Delay2()
    {
        tsMainScript.Clickable = true;
        tsSpritesManager.dialogBox.SetActive(true);
        ProceedText(false, false);
    }
    public void Event83Delay()
    {
        tsSpritesManager.WhiteScreen.GetComponent<Image>().DOFade(0, .25f);
    }
    public void Event83Delay2()
    {
        tsSpritesManager.WhiteScreen.SetActive(false);
        tsSpritesManager.WhiteScreen.GetComponent<Image>().DOFade(1, 0);
        tsSpritesManager.dialogBox.SetActive(true);
        ProceedText(false, false);
    }
    public void Event83Delay3()
    {
        AudioManager.Instance.PlaySE(SEID.se_script_001);
        tsSpritesManager.fluttershysCottage.GetComponent<Transform>().DOShakePosition(.3f, new Vector3(2, 2, 0)).SetLoops(1, LoopType.Yoyo);
        tsSpritesManager.TwilightStandNormal.gameObject.SetActive(false);
        tsSpritesManager.TwilightStandStartled.SetActive(true);
    }
    public void Event83Delay4()
    {
        tsSpritesManager.dialogBox.SetActive(false);
        tsSpritesManager.TwilightStandStartled.GetComponent<SpriteRenderer>().DOFade(0, .25f);
        tsSpritesManager.fluttershyStandAhhh.DOFade(0, 0);
    }
    public void Event83Delay5()
    {
        tsSpritesManager.TwilightStandStartled.SetActive(false);
        tsSpritesManager.TwilightStandStartled.GetComponent<SpriteRenderer>().DOFade(1, 0);
        tsSpritesManager.fluttershyStandAhhh.gameObject.SetActive(true);
        tsSpritesManager.fluttershyStandAhhh.DOFade(1, .25f);
    }
    public void Event83Delay6()
    {
        tsMainScript.EventID = 84;
        tsMainScript.Proceed = true;
    }
    public void Event84Delay()
    {
        tsSpritesManager.dialogBox.SetActive(false);
        tsSpritesManager.TwilightStandNormal.GetComponent<SpriteRenderer>().DOFade(0, 0);
        tsSpritesManager.fluttershyStandAhhh.DOFade(0, .25f);
    }
    public void Event84Delay2()
    {
        tsSpritesManager.fluttershyStandAhhh.gameObject.SetActive(false);
        tsSpritesManager.fluttershyStandAhhh.DOFade(1, 0);
        tsSpritesManager.TwilightStandNormal.SetActive(true);
        tsSpritesManager.TwilightStandNormal.GetComponent<SpriteRenderer>().DOFade(1, .25f);
    }
    public void Event84Delay3()
    {
        tsMainScript.EventID = 85;
        tsMainScript.Proceed = true;
        tsMainScript.Clickable = true;
    }
    public void Event92Delay()
    {
        tsMainScript.Clickable = true;
        tsSpritesManager.TwilightStandNormal.SetActive(false);
        tsSpritesManager.TwilightSitSad.SetActive(true);
    }
    public void Event97Delay()
    {
        tsSpritesManager.ClearAllBG();
        tsSpritesManager.TwilightStandNormal.SetActive(false);
        tsMainScript.AreaID = 6;
        tsMainScript.EventID = 0;
        tsMainScript.ProceedGame(tsMainScript.ChapterID, tsMainScript.AreaID, false);
    }
}
