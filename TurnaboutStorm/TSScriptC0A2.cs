using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;
using TMPro;

public class TSScriptC0A2 : MonoBehaviour
{
    // 逆转风暴基础脚本
    public TSMainScript tsMainScript;
    // 逆转风暴 - 贴图管理器
    public TSSpritesManager tsSpritesManager;
    // 法庭记录系统
    public CourtRecordsSystem courtRecordsSystem;
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

    #region 游戏进程脚本
    public void ProceedGame(int EventID, bool IsContinue)
    {
        if (tsMainScript.CurrentScript != "TSScriptC0A2")
        {
            // 读取 TextAsset
            tsMainScript.CurrentScript = "TSScriptC0A2";
            tsMainScript.SendMessage("ReadText", DialogFile);
            Debug.Log("已读取对话文本TSScriptC0A2");
        }
        print(tsMainScript.EventID);
        // Area 2 初见暮光闪闪
        if (EventID == 0)
        {
            tsMainScript.DialogIndex = 1;
            tsSpritesManager.NameTag.SetActive(false);
            tsSpritesManager.dialogBox.SetActive(true);
            tsSpritesManager.SpeechText.SetActive(false);
            tsSpritesManager.NewAreaText.SetActive(true);
            tsMainScript.Clickable = true;
            ProceedText(IsContinue, false);
        }
        else if (EventID == 1)
        {
            tsMainScript.DialogIndex = 2;
            tsSpritesManager.NameTag.SetActive(true);
            tsSpritesManager.dialogBox.SetActive(true);
            tsSpritesManager.SpeechText.SetActive(true);
            tsSpritesManager.NewAreaText.SetActive(false);
            tsMainScript.Clickable = true;
            ProceedText(IsContinue, false);
        }
        else if (EventID == 2)
        {
            tsMainScript.DialogIndex = 3;
            tsSpritesManager.dialogBox.SetActive(true);
            tsMainScript.Clickable = true;
            ProceedText(IsContinue, false);
        }
        else if (EventID == 3)
        {
            tsMainScript.DialogIndex = 4;
            tsSpritesManager.dialogBox.SetActive(true);
            tsMainScript.Clickable = true;
            ProceedText(IsContinue, false);
        }
        else if (EventID == 4)
        {
            tsMainScript.DialogIndex = 5;
            tsSpritesManager.dialogBox.SetActive(true);
            tsMainScript.Clickable = true;
            ProceedText(IsContinue, false);
        }
        else if (EventID == 5)
        {
            tsMainScript.DialogIndex = 6;
            tsSpritesManager.dialogBox.SetActive(true);
            tsMainScript.Clickable = true;
            ProceedText(IsContinue, false);
        }
        else if (EventID == 6)
        {
            tsMainScript.DialogIndex = 7;
            tsSpritesManager.dialogBox.SetActive(true);
            tsMainScript.Clickable = true;
            ProceedText(IsContinue, false);
        }
        else if (EventID == 7)
        {
            tsMainScript.DialogIndex = 8;
            tsSpritesManager.dialogBox.SetActive(true);
            tsMainScript.Clickable = true;
            if (IsContinue)
            {
                ProceedText(true, false);
            }
            else if (!IsContinue)
            {
                ProceedText(false, false);
                AudioManager.Instance.PlaySE(SEID.se_script_012);
            }
        }
        else if (EventID == 8)
        {
            tsMainScript.DialogIndex = 9;
            tsSpritesManager.dialogBox.SetActive(true);
            tsMainScript.Clickable = true;
            ProceedText(IsContinue, false);
        }
        else if (EventID == 9)
        {
            tsSpritesManager.BackgroundUpdate("TwilightsBedroom");
            tsMainScript.DialogIndex = 10;
            if (IsContinue)
            {
                tsSpritesManager.dialogBox.SetActive(true);
                tsMainScript.Clickable = true;
                ProceedText(true, false);
            }
            else if (!IsContinue)
            {
                tsSpritesManager.dialogBox.SetActive(false);
                tsSpritesManager.TwilightsBedroom.GetComponent<SpriteRenderer>().DOFade(0, 0f);
                tsSpritesManager.TwilightsBedroom.GetComponent<SpriteRenderer>().DOFade(1, 3f);
                tsMainScript.Clickable = false;
                Invoke("Event9Delay", 4f);
                Invoke("Event9Delay2", 4.15f);
            }
        }
        else if (EventID == 10)
        {
            tsSpritesManager.BackgroundUpdate("TwilightsBedroom");
            tsMainScript.DialogIndex = 11;
            tsSpritesManager.dialogBox.SetActive(true);
            tsSpritesManager.TwilightStandNormal.SetActive(true);
            if (IsContinue)
            {
                tsMainScript.Clickable = true;
                ProceedText(true, false);
            }
            else if (!IsContinue)
            {
                tsMainScript.Clickable = false;
                tsSpritesManager.TwilightStandNormal.GetComponent<SpriteRenderer>().DOFade(0, 0f);
                tsSpritesManager.TwilightStandNormal.GetComponent<SpriteRenderer>().DOFade(1, 1f);
                Invoke("Event10Delay", 2f);
            }
        }
        else if (EventID == 11)
        {
            tsMainScript.Clickable = false;
            tsMainScript.DialogIndex = 12;
            ProceedText(false, false);
            Invoke("Event11Delay", 2f);
        }
        else if (EventID == 12)
        {
            tsSpritesManager.BackgroundUpdate("TwilightsBedroom");
            tsMainScript.DialogIndex = 13;
            tsSpritesManager.dialogBox.SetActive(true);
            tsSpritesManager.TwilightStandNormal.SetActive(true);
            if (IsContinue)
            {
                tsSpritesManager.dialogBox.SetActive(true);
                tsMainScript.Clickable = true;
                ProceedText(true, false);
            }
            else if (!IsContinue)
            {
                Invoke("Event12Delay", 0.15f);
            }
        }
        else if (EventID == 13)
        {
            tsSpritesManager.BackgroundUpdate("TwilightsBedroom");
            tsMainScript.DialogIndex = 14;
            tsSpritesManager.dialogBox.SetActive(true);
            if (!IsContinue)
            {
                tsSpritesManager.TwilightStandNormal.SetActive(false);
            }
            tsSpritesManager.TwilightStandHappy.SetActive(true);
            tsMainScript.Clickable = true;
            ProceedText(IsContinue, false);
            AudioManager.Instance.PlayBGM(BGMID.ChildOfMagic);
        }
        else if (EventID == 14)
        {
            tsSpritesManager.BackgroundUpdate("TwilightsBedroom");
            tsMainScript.DialogIndex = 15;
            tsSpritesManager.dialogBox.SetActive(true);
            tsSpritesManager.TwilightStandHappy.SetActive(true);
            tsMainScript.Clickable = true;
            ProceedText(IsContinue, false);
            AudioManager.Instance.PlayBGM(BGMID.ChildOfMagic);
        }
        else if (EventID == 15)
        {
            tsSpritesManager.BackgroundUpdate("TwilightsBedroom");
            tsMainScript.DialogIndex = 16;
            tsSpritesManager.dialogBox.SetActive(true);
            if (!IsContinue)
            {
                tsSpritesManager.TwilightStandHappy.SetActive(false);
            }
            tsSpritesManager.TwilightStandConfused.SetActive(true);
            tsMainScript.Clickable = true;
            ProceedText(IsContinue, false);
            AudioManager.Instance.PlayBGM(BGMID.ChildOfMagic);
        }
        else if (EventID == 16)
        {
            tsSpritesManager.BackgroundUpdate("TwilightsBedroom");
            tsMainScript.DialogIndex = 17;
            tsSpritesManager.dialogBox.SetActive(true);
            if (!IsContinue)
            {
                tsSpritesManager.TwilightStandConfused.SetActive(false);
            }
            tsSpritesManager.TwilightStandNormal.SetActive(true);
            tsMainScript.Clickable = true;
            ProceedText(IsContinue, false);
            AudioManager.Instance.PlayBGM(BGMID.ChildOfMagic);
        }
        else if (EventID == 17)
        {
            tsSpritesManager.BackgroundUpdate("TwilightsBedroom");
            tsMainScript.DialogIndex = 18;
            tsSpritesManager.dialogBox.SetActive(true);
            tsSpritesManager.TwilightStandNormal.SetActive(true);
            tsMainScript.Clickable = true;
            ProceedText(IsContinue, false);
            AudioManager.Instance.PlayBGM(BGMID.ChildOfMagic);
        }
        else if (EventID == 18)
        {
            tsSpritesManager.BackgroundUpdate("TwilightsBedroom");
            AudioManager.Instance.PlayBGM(BGMID.ChildOfMagic);
            tsMainScript.DialogIndex = 19;
            tsSpritesManager.dialogBox.SetActive(true);
            tsMainScript.Clickable = false;
            tsSpritesManager.TwilightStandNormal.SetActive(false);
            tsSpritesManager.TwilightStandConfused.SetActive(true);
            ProceedText(IsContinue, false);
            Invoke("Event18Delay", 2.2f);
            Invoke("Event18Delay2", 5f);
        }
        else if (EventID == 19)
        {
            tsSpritesManager.dialogBox.SetActive(false);
            tsSpritesManager.TwilightsBedroom.GetComponent<Transform>().DOShakePosition(.3f, new Vector3(2, 2, 0)).SetLoops(1, LoopType.Yoyo);
            AudioManager.Instance.PlaySE(SEID.se_script_082);
            Invoke("Event19Delay", .7f);
        }
        else if (EventID == 20)
        {
            tsSpritesManager.BackgroundUpdate("TwilightsBedroom");
            AudioManager.Instance.PlayBGM(BGMID.ChildOfMagic);
            tsMainScript.Clickable = true;
            if (!IsContinue)
            {
                tsSpritesManager.TwilightStandHappy.SetActive(false);
            }
            tsSpritesManager.TwilightStandPanic.SetActive(true);
            tsMainScript.DialogIndex = 21;
            tsSpritesManager.dialogBox.SetActive(true);
            ProceedText(IsContinue, false);
        }
        else if (EventID == 21)
        {
            tsSpritesManager.BackgroundUpdate("TwilightsBedroom");
            AudioManager.Instance.PlayBGM(BGMID.ChildOfMagic);
            tsMainScript.Clickable = true;
            tsSpritesManager.TwilightStandPanic.SetActive(true);
            tsMainScript.DialogIndex = 22;
            tsSpritesManager.dialogBox.SetActive(true);
            ProceedText(IsContinue, false);
        }
        else if (EventID == 22)
        {
            tsSpritesManager.BackgroundUpdate("TwilightsBedroom");
            AudioManager.Instance.PlayBGM(BGMID.ChildOfMagic);
            tsMainScript.Clickable = true;
            if (!IsContinue)
            {
                tsSpritesManager.TwilightStandPanic.SetActive(false);
            }
            tsSpritesManager.TwilightStandNormal.SetActive(true);
            tsMainScript.DialogIndex = 23;
            tsSpritesManager.dialogBox.SetActive(true);
            ProceedText(IsContinue, false);
        }
        else if (EventID == 23)
        {
            tsSpritesManager.BackgroundUpdate("TwilightsBedroom");
            AudioManager.Instance.PlayBGM(BGMID.ChildOfMagic);
            tsMainScript.Clickable = true;
            tsSpritesManager.TwilightStandNormal.SetActive(true);
            tsMainScript.DialogIndex = 24;
            tsSpritesManager.dialogBox.SetActive(true);
            ProceedText(IsContinue, false);
        }
        else if (EventID == 24)
        {
            tsSpritesManager.BackgroundUpdate("TwilightsBedroom");
            AudioManager.Instance.PlayBGM(BGMID.ChildOfMagic);
            tsMainScript.Clickable = true;
            tsSpritesManager.TwilightStandNormal.SetActive(true);
            tsMainScript.DialogIndex = 25;
            tsSpritesManager.dialogBox.SetActive(true);
            ProceedText(IsContinue, false);
        }
        else if (EventID == 25)
        {
            tsSpritesManager.BackgroundUpdate("TwilightsBedroom");
            AudioManager.Instance.PlayBGM(BGMID.ChildOfMagic);
            tsMainScript.Clickable = true;
            if (!IsContinue)
            {
                tsSpritesManager.TwilightStandNormal.SetActive(false);
            }
            tsSpritesManager.TwilightSitOops.SetActive(true);
            tsMainScript.DialogIndex = 26;
            tsSpritesManager.dialogBox.SetActive(true);
            ProceedText(IsContinue, false);
        }
        else if (EventID == 26)
        {
            tsSpritesManager.BackgroundUpdate("TwilightsBedroom");
            AudioManager.Instance.PlayBGM(BGMID.ChildOfMagic);
            tsMainScript.Clickable = true;
            tsSpritesManager.TwilightSitOops.SetActive(true);
            tsMainScript.DialogIndex = 27;
            tsSpritesManager.dialogBox.SetActive(true);
            ProceedText(IsContinue, false);
        }
        else if (EventID == 27)
        {
            tsSpritesManager.BackgroundUpdate("TwilightsBedroom");
            AudioManager.Instance.PlayBGM(BGMID.ChildOfMagic);
            tsMainScript.Clickable = true;
            if (!IsContinue)
            {
                tsSpritesManager.TwilightSitOops.SetActive(false);
            }
            tsSpritesManager.TwilightStandConfused.SetActive(true);
            tsMainScript.DialogIndex = 28;
            tsSpritesManager.dialogBox.SetActive(true);
            ProceedText(IsContinue, false);
        }
        else if (EventID == 28)
        {
            tsSpritesManager.BackgroundUpdate("TwilightsBedroom");
            AudioManager.Instance.PlayBGM(BGMID.ChildOfMagic);
            tsMainScript.Clickable = true;
            tsSpritesManager.TwilightStandConfused.SetActive(true);
            tsMainScript.DialogIndex = 29;
            tsSpritesManager.dialogBox.SetActive(true);
            ProceedText(IsContinue, false);
        }
        else if (EventID == 29)
        {
            tsSpritesManager.BackgroundUpdate("TwilightsBedroom");
            AudioManager.Instance.PlayBGM(BGMID.ChildOfMagic);
            tsMainScript.Clickable = true;
            if (!IsContinue)
            {
                tsSpritesManager.TwilightStandConfused.SetActive(false);
            }
            tsSpritesManager.TwilightStandExplain.SetActive(true);
            tsMainScript.DialogIndex = 30;
            tsSpritesManager.dialogBox.SetActive(true);
            ProceedText(IsContinue, false);
        }
        else if (EventID == 30)
        {
            tsSpritesManager.BackgroundUpdate("TwilightsBedroom");
            AudioManager.Instance.PlayBGM(BGMID.ChildOfMagic);
            if (!IsContinue)
            {
                tsMainScript.Clickable = false;
                AudioManager.Instance.PlaySE(SEID.se_script_001);
                tsSpritesManager.TwilightStandExplain.SetActive(false);
                tsSpritesManager.TwilightStandStartled.SetActive(true);
                tsSpritesManager.TwilightsBedroom.GetComponent<Transform>().DOShakePosition(.3f, new Vector3(2, 2, 0)).SetLoops(1, LoopType.Yoyo);
                Invoke("Event30Delay", 1f);
            }
            else if(IsContinue)
            {
                tsMainScript.Clickable = true;
                tsSpritesManager.TwilightStandWhat.SetActive(true);
            }
            tsMainScript.DialogIndex = 31;
            tsSpritesManager.dialogBox.SetActive(true);
            ProceedText(IsContinue, false);
        }
        else if (EventID == 31)
        {
            tsSpritesManager.BackgroundUpdate("TwilightsBedroom");
            AudioManager.Instance.PlayBGM(BGMID.ChildOfMagic);
            tsMainScript.Clickable = true;
            if (!IsContinue)
            {
                tsSpritesManager.TwilightStandWhat.SetActive(false);
            }
            tsSpritesManager.TwilightStandExplain.SetActive(true);
            tsMainScript.DialogIndex = 32;
            tsSpritesManager.dialogBox.SetActive(true);
            ProceedText(IsContinue, false);
        }
        else if (EventID == 32)
        {
            tsSpritesManager.BackgroundUpdate("TwilightsBedroom");
            AudioManager.Instance.PlayBGM(BGMID.ChildOfMagic);
            tsMainScript.Clickable = true;
            if (!IsContinue)
            {
                tsSpritesManager.TwilightStandExplain.SetActive(false);
            }
            tsSpritesManager.TwilightSitOops.SetActive(true);
            tsMainScript.DialogIndex = 33;
            tsSpritesManager.dialogBox.SetActive(true);
            ProceedText(IsContinue, false);
        }
        else if (EventID == 33)
        {
            tsSpritesManager.BackgroundUpdate("TwilightsBedroom");
            AudioManager.Instance.PlayBGM(BGMID.ChildOfMagic);
            tsMainScript.Clickable = true;
            tsSpritesManager.TwilightSitOops.SetActive(true);
            tsMainScript.DialogIndex = 34;
            tsSpritesManager.dialogBox.SetActive(true);
            ProceedText(IsContinue, false);
        }
        else if (EventID == 34)
        {
            tsSpritesManager.BackgroundUpdate("TwilightsBedroom");
            AudioManager.Instance.PlayBGM(BGMID.ChildOfMagic);
            tsMainScript.Clickable = true;
            tsSpritesManager.TwilightSitOops.SetActive(true);
            tsMainScript.DialogIndex = 35;
            tsSpritesManager.dialogBox.SetActive(true);
            ProceedText(IsContinue, false);
        }
        else if (EventID == 35)
        {
            tsSpritesManager.BackgroundUpdate("TwilightsBedroom");
            AudioManager.Instance.PlayBGM(BGMID.ChildOfMagic);
            tsMainScript.Clickable = true;
            if (!IsContinue)
            {
                tsSpritesManager.TwilightSitOops.SetActive(false);
            }
            tsSpritesManager.TwilightStandNormal.SetActive(true);
            tsMainScript.DialogIndex = 36;
            tsSpritesManager.dialogBox.SetActive(true);
            ProceedText(IsContinue, false);
        }
        else if (EventID == 36)
        {
            tsSpritesManager.BackgroundUpdate("TwilightsBedroom");
            AudioManager.Instance.PlayBGM(BGMID.ChildOfMagic);
            tsMainScript.Clickable = true;
            if (!IsContinue)
            {
                tsSpritesManager.TwilightStandNormal.SetActive(false);
            }
            tsSpritesManager.TwilightStandExplain.SetActive(true);
            tsMainScript.DialogIndex = 37;
            tsSpritesManager.dialogBox.SetActive(true);
            ProceedText(IsContinue, false);
        }
        else if (EventID == 37)
        {
            tsSpritesManager.BackgroundUpdate("TwilightsBedroom");
            AudioManager.Instance.PlayBGM(BGMID.ChildOfMagic);
            tsSpritesManager.dialogBox.SetActive(true);
            tsMainScript.DialogIndex = 38;
            tsMainScript.Clickable = true;
            if (!IsContinue)
            {
                tsSpritesManager.WhiteScreen.GetComponent<Image>().DOFade(0, 0f);
                tsSpritesManager.WhiteScreen.SetActive(true);
                tsSpritesManager.WhiteScreen.GetComponent<Image>().DOFade(1, .3f);
                Invoke("Event37Delay", .3f);
                Invoke("Event37Delay2", .6f);
            }
            else if(IsContinue)
            {
                tsSpritesManager.TwilightStandExplain.SetActive(true);
                ProceedText(true, false);
            }
        }
        else if (EventID == 38)
        {
            tsSpritesManager.BackgroundUpdate("TwilightsBedroom");
            AudioManager.Instance.PlayBGM(BGMID.ChildOfMagic);
            tsMainScript.Clickable = true;
            tsSpritesManager.TwilightStandHappy.SetActive(true);
            tsSpritesManager.dialogBox.SetActive(true);
            tsMainScript.DialogIndex = 39;
            ProceedText(IsContinue, false);
        }
        else if (EventID == 39)
        {
            tsSpritesManager.BackgroundUpdate("TwilightsBedroom");
            AudioManager.Instance.PlayBGM(BGMID.ChildOfMagic);
            tsMainScript.Clickable = true;
            if (!IsContinue)
            {
                tsSpritesManager.TwilightStandHappy.SetActive(false);
            }
            tsSpritesManager.TwilightStandExplain.SetActive(true);
            tsSpritesManager.dialogBox.SetActive(true);
            tsMainScript.DialogIndex = 40;
            ProceedText(IsContinue, false);
        }
        else if (EventID == 40)
        {
            tsSpritesManager.BackgroundUpdate("TwilightsBedroom");
            AudioManager.Instance.PlayBGM(BGMID.ChildOfMagic);
            tsMainScript.Clickable = true;
            tsSpritesManager.TwilightStandExplain.SetActive(true);
            tsSpritesManager.dialogBox.SetActive(true);
            tsMainScript.DialogIndex = 41;
            ProceedText(IsContinue, false);
        }
        else if (EventID == 41)
        {
            tsSpritesManager.BackgroundUpdate("TwilightsBedroom");
            AudioManager.Instance.PlayBGM(BGMID.ChildOfMagic);
            tsMainScript.Clickable = true;
            if (!IsContinue)
            {
                tsSpritesManager.TwilightStandExplain.SetActive(false);
            }
            tsSpritesManager.TwilightStandHappy.SetActive(true);
            tsSpritesManager.dialogBox.SetActive(true);
            tsMainScript.DialogIndex = 42;
            ProceedText(IsContinue, false);
        }
        else if (EventID == 42)
        {
            tsSpritesManager.BackgroundUpdate("TwilightsBedroom");
            AudioManager.Instance.PlayBGM(BGMID.ChildOfMagic);
            tsMainScript.Clickable = true;
            if (!IsContinue)
            {
                tsSpritesManager.TwilightStandHappy.SetActive(false);
            }
            tsSpritesManager.TwilightStandWhat.SetActive(true);
            tsSpritesManager.dialogBox.SetActive(true);
            tsMainScript.DialogIndex = 43;
            ProceedText(IsContinue, false);
        }
        else if (EventID == 43)
        {
            tsSpritesManager.BackgroundUpdate("TwilightsBedroom");
            AudioManager.Instance.PlayBGM(BGMID.ChildOfMagic);
            tsMainScript.Clickable = true;
            if (!IsContinue)
            {
                tsSpritesManager.TwilightStandWhat.SetActive(false);
            }
            tsSpritesManager.TwilightStandConfused.SetActive(true);
            tsSpritesManager.dialogBox.SetActive(true);
            tsMainScript.DialogIndex = 44;
            ProceedText(IsContinue, false);
        }
        else if (EventID == 44)
        {
            tsSpritesManager.BackgroundUpdate("TwilightsBedroom");
            AudioManager.Instance.PlayBGM(BGMID.ChildOfMagic);
            tsMainScript.Clickable = true;
            tsSpritesManager.TwilightStandConfused.SetActive(true);
            tsSpritesManager.dialogBox.SetActive(true);
            tsMainScript.DialogIndex = 45;
            ProceedText(IsContinue, false);
        }
        else if (EventID == 45)
        {
            tsSpritesManager.BackgroundUpdate("TwilightsBedroom");
            AudioManager.Instance.PlayBGM(BGMID.ChildOfMagic);
            tsMainScript.Clickable = true;
            if (!IsContinue)
            {
                tsSpritesManager.TwilightStandConfused.SetActive(false);
            }
            tsSpritesManager.TwilightStandHappy.SetActive(true);
            tsSpritesManager.dialogBox.SetActive(true);
            tsMainScript.DialogIndex = 46;
            ProceedText(IsContinue, false);
        }
        else if (EventID == 46)
        {
            tsSpritesManager.BackgroundUpdate("TwilightsBedroom");
            AudioManager.Instance.PlayBGM(BGMID.ChildOfMagic);
            tsMainScript.Clickable = true;
            if (!IsContinue)
            {
                tsSpritesManager.TwilightStandHappy.SetActive(false);
            }
            tsSpritesManager.TwilightStandNormal.SetActive(true);
            tsSpritesManager.dialogBox.SetActive(true);
            tsMainScript.DialogIndex = 47;
            ProceedText(IsContinue, false);
        }
        else if (EventID == 47)
        {
            tsSpritesManager.BackgroundUpdate("TwilightsBedroom");
            AudioManager.Instance.PlayBGM(BGMID.ChildOfMagic);
            tsMainScript.Clickable = true;
            tsSpritesManager.TwilightStandNormal.SetActive(true);
            tsSpritesManager.dialogBox.SetActive(true);
            tsMainScript.DialogIndex = 48;
            ProceedText(IsContinue, false);
        }
        else if (EventID == 48)
        {
            tsSpritesManager.BackgroundUpdate("TwilightsBedroom");
            AudioManager.Instance.PlayBGM(BGMID.ChildOfMagic);
            tsMainScript.Clickable = true;
            if (!IsContinue)
            {
                tsSpritesManager.TwilightStandNormal.SetActive(false);
            }
            tsSpritesManager.TwilightSitSad.SetActive(true);
            tsSpritesManager.dialogBox.SetActive(true);
            tsMainScript.DialogIndex = 49;
            ProceedText(IsContinue, false);
        }
        else if (EventID == 49)
        {
            tsSpritesManager.BackgroundUpdate("TwilightsBedroom");
            AudioManager.Instance.PlayBGM(BGMID.ChildOfMagic);
            tsMainScript.Clickable = true;
            if (!IsContinue)
            {
                tsSpritesManager.TwilightSitSad.SetActive(false);
            }
            tsSpritesManager.TwilightStandNormal.SetActive(true);
            tsSpritesManager.dialogBox.SetActive(true);
            tsMainScript.DialogIndex = 50;
            ProceedText(IsContinue, false);
        }
        else if (EventID == 50)
        {
            tsSpritesManager.BackgroundUpdate("TwilightsBedroom");
            AudioManager.Instance.PlayBGM(BGMID.ChildOfMagic);
            tsMainScript.Clickable = true;
            tsSpritesManager.TwilightStandNormal.SetActive(true);
            tsSpritesManager.dialogBox.SetActive(true);
            tsMainScript.DialogIndex = 51;
            ProceedText(IsContinue, false);
        }
        else if (EventID == 51)
        {
            tsSpritesManager.BackgroundUpdate("TwilightsBedroom");
            AudioManager.Instance.PlayBGM(BGMID.ChildOfMagic);
            tsMainScript.Clickable = true;
            if (!IsContinue)
            {
                courtRecordsSystem.GetNewProfile(1);
                tsSpritesManager.TwilightStandNormal.SetActive(false);
            }
            tsSpritesManager.TwilightStandExplain.SetActive(true);
            tsSpritesManager.dialogBox.SetActive(true);
            tsMainScript.DialogIndex = 52;
            ProceedText(IsContinue, false);
        }
        else if (EventID == 52)
        {
            tsSpritesManager.BackgroundUpdate("TwilightsBedroom");
            AudioManager.Instance.PlayBGM(BGMID.ChildOfMagic);
            tsMainScript.Clickable = true;
            tsSpritesManager.TwilightStandExplain.SetActive(true);
            tsSpritesManager.dialogBox.SetActive(true);
            tsMainScript.DialogIndex = 53;
            ProceedText(IsContinue, false);
        }
        else if (EventID == 53)
        {
            tsSpritesManager.BackgroundUpdate("TwilightsBedroom");
            AudioManager.Instance.PlayBGM(BGMID.ChildOfMagic);
            tsMainScript.Clickable = true;
            if (!IsContinue)
            {
                tsSpritesManager.TwilightStandExplain.SetActive(false);
            }
            tsSpritesManager.TwilightStandNormal.SetActive(true);
            tsSpritesManager.dialogBox.SetActive(true);
            tsMainScript.DialogIndex = 54;
            ProceedText(IsContinue, false);
        }
        else if (EventID == 54)
        {
            tsSpritesManager.BackgroundUpdate("TwilightsBedroom");
            AudioManager.Instance.PlayBGM(BGMID.ChildOfMagic);
            tsMainScript.Clickable = true;
            if (!IsContinue)
            {
                tsSpritesManager.TwilightStandNormal.SetActive(false);
            }
            tsSpritesManager.TwilightStandHappy.SetActive(true);
            tsSpritesManager.dialogBox.SetActive(true);
            tsMainScript.DialogIndex = 55;
            ProceedText(IsContinue, false);
        }
        else if (EventID == 55)
        {
            tsSpritesManager.BackgroundUpdate("TwilightsBedroom");
            AudioManager.Instance.PlayBGM(BGMID.ChildOfMagic);
            tsMainScript.Clickable = true;
            tsSpritesManager.TwilightStandHappy.SetActive(true);
            tsSpritesManager.dialogBox.SetActive(true);
            tsMainScript.DialogIndex = 56;
            ProceedText(IsContinue, false);
        }
        else if (EventID == 56)
        {
            tsSpritesManager.BackgroundUpdate("TwilightsBedroom");
            AudioManager.Instance.PlayBGM(BGMID.ChildOfMagic);
            tsMainScript.Clickable = true;
            if (!IsContinue)
            {
                tsSpritesManager.TwilightStandHappy.SetActive(false);
            }
            tsSpritesManager.TwilightStandExplain.SetActive(true);
            tsSpritesManager.dialogBox.SetActive(true);
            tsMainScript.DialogIndex = 57;
            ProceedText(IsContinue, false);
        }
        else if (EventID == 57)
        {
            tsSpritesManager.BackgroundUpdate("TwilightsBedroom");
            AudioManager.Instance.PlayBGM(BGMID.ChildOfMagic);
            tsSpritesManager.dialogBox.SetActive(true);
            tsMainScript.DialogIndex = 58;
            if (!IsContinue)
            {
                tsMainScript.Clickable = false;
                tsSpritesManager.TwilightStandExplain.GetComponent<SpriteRenderer>().DOFade(0, .3f);
                Invoke("Event57Delay", 1.3f);
            }
            else if (IsContinue)
            {
                tsMainScript.Clickable = true;
                ProceedText(true, false);
            }
        }
        else if (EventID == 58)
        {
            tsSpritesManager.BackgroundUpdate("TwilightsBedroom");
            AudioManager.Instance.PlayBGM(BGMID.ChildOfMagic);
            tsSpritesManager.dialogBox.SetActive(true);
            tsMainScript.DialogIndex = 59;
            if (!IsContinue)
            {
                tsMainScript.Clickable = false;
                tsSpritesManager.TwilightStandHappy.GetComponent<SpriteRenderer>().DOFade(0, 0);
                tsSpritesManager.TwilightStandHappy.SetActive(true);
                tsSpritesManager.TwilightStandHappy.GetComponent<SpriteRenderer>().DOFade(1, .3f);
                Invoke("Event58Delay", 1.3f);
                Invoke("Event58Delay2", 3.5f);
                Invoke("Event58Delay3", 4.5f);
            }
            else if (IsContinue)
            {
                tsSpritesManager.TwilightStandHappy.SetActive(true);
                tsMainScript.Clickable = true;
                ProceedText(true, false);
            }
        }
        else if (EventID == 59)
        {
            tsSpritesManager.BackgroundUpdate("TwilightsBedroom");
            AudioManager.Instance.PlayBGM(BGMID.ChildOfMagic);
            tsSpritesManager.TwilightStandHappy.SetActive(true);
            tsSpritesManager.dialogBox.SetActive(true);
            tsMainScript.DialogIndex = 60;
            tsSpritesManager.TheFilliesGuideToPonies.SetActive(true);
            tsSpritesManager.ItemHolder.SetActive(true);
            if (!IsContinue)
            {
                AudioManager.Instance.PlaySE(SEID.item_pop);
                tsMainScript.Clickable = false;
                Invoke("Event59Delay", 2f);
            }
            else if (IsContinue)
            {
                tsMainScript.Clickable = true;
                ProceedText(true, false);
            }
        }
        else if (EventID == 60)
        {
            tsSpritesManager.BackgroundUpdate("TwilightsBedroom");
            AudioManager.Instance.PlayBGM(BGMID.ChildOfMagic);
            tsSpritesManager.TwilightStandHappy.SetActive(true);
            tsSpritesManager.dialogBox.SetActive(true);
            tsMainScript.DialogIndex = 61;
            tsSpritesManager.TheFilliesGuideToPonies.SetActive(true);
            tsSpritesManager.ItemHolder.SetActive(true);
            tsMainScript.Clickable = true;
            if (!IsContinue)
            {
                AudioManager.Instance.PlaySE(SEID.se_script_082);
                tsSpritesManager.TwilightsBedroom.GetComponent<Transform>().DOShakePosition(.3f, new Vector3(2, 2, 0)).SetLoops(1, LoopType.Yoyo);
            }
            ProceedText(IsContinue, false);
        }
        else if (EventID == 61)
        {
            tsSpritesManager.BackgroundUpdate("TwilightsBedroom");
            AudioManager.Instance.PlayBGM(BGMID.ChildOfMagic);
            tsSpritesManager.dialogBox.SetActive(true);
            tsMainScript.DialogIndex = 62;
            tsSpritesManager.TheFilliesGuideToPonies.SetActive(true);
            tsSpritesManager.ItemHolder.SetActive(true);
            tsMainScript.Clickable = true;
            if (!IsContinue)
            {
                tsSpritesManager.TwilightStandHappy.SetActive(false);
            }
            tsSpritesManager.TwilightSitOops.SetActive(true);
            ProceedText(IsContinue, false);
        }
        else if (EventID == 62)
        {
            tsSpritesManager.BackgroundUpdate("TwilightsBedroom");
            AudioManager.Instance.PlayBGM(BGMID.ChildOfMagic);
            tsSpritesManager.dialogBox.SetActive(true);
            tsSpritesManager.NameTag.SetActive(false);
            tsMainScript.DialogIndex = 63;
            tsSpritesManager.TwilightSitOops.SetActive(true);
            if (!IsContinue)
            {
                AudioManager.Instance.PlaySE(SEID.se_com_017);
                courtRecordsSystem.GetNewEvidence(2);
                courtRecordsSystem.NewEvidenceShow();
                tsSpritesManager.ItemHolder.SetActive(false);
                tsSpritesManager.TheFilliesGuideToPonies.SetActive(false);
                tsMainScript.CourtRecordsHideOverlay.SetActive(true);
            }
            else if (IsContinue)
            {
                tsMainScript.Clickable = true;
            }
            ProceedText(IsContinue, false);
        }
        else if (EventID == 63)
        {
            tsSpritesManager.BackgroundUpdate("TwilightsBedroom");
            AudioManager.Instance.PlayBGM(BGMID.ChildOfMagic);
            tsMainScript.Clickable = true;
            tsSpritesManager.dialogBox.SetActive(true);
            tsMainScript.DialogIndex = 64;
            tsSpritesManager.TwilightSitOops.SetActive(true);
            if (!IsContinue)
            {
                tsSpritesManager.NameTag.SetActive(true);
            }
            ProceedText(IsContinue, false);
        }
        else if (EventID == 64)
        {
            tsSpritesManager.BackgroundUpdate("TwilightsBedroom");
            tsMainScript.Clickable = true;
            tsSpritesManager.dialogBox.SetActive(true);
            tsMainScript.DialogIndex = 65;
            if (!IsContinue)
            {
                tsSpritesManager.WhiteScreen.GetComponent<Image>().DOFade(0, 0f);
                tsSpritesManager.WhiteScreen.SetActive(true);
                tsSpritesManager.WhiteScreen.GetComponent<Image>().DOFade(1, .3f);
                Invoke("Event64Delay", .3f);
                Invoke("Event64Delay2", .6f);
            }
            else if(IsContinue)
            {
                tsSpritesManager.TwilightSitSad.SetActive(true);
                ProceedText(true, false);
            }
        }
        else if (EventID == 65)
        {
            tsSpritesManager.BackgroundUpdate("TwilightsBedroom");
            tsSpritesManager.TwilightSitSad.SetActive(true);
            tsMainScript.Clickable = true;
            tsSpritesManager.dialogBox.SetActive(true);
            tsMainScript.DialogIndex = 66;
            ProceedText(IsContinue, false);
        }
        else if (EventID == 66)
        {
            tsSpritesManager.BackgroundUpdate("TwilightsBedroom");
            tsSpritesManager.TwilightSitSad.SetActive(true);
            tsMainScript.Clickable = true;
            tsSpritesManager.dialogBox.SetActive(true);
            tsMainScript.DialogIndex = 67;
            ProceedText(IsContinue, false);
        }
        else if (EventID == 67)
        {
            tsSpritesManager.BackgroundUpdate("TwilightsBedroom");
            tsSpritesManager.TwilightSitSad.SetActive(true);
            tsMainScript.Clickable = true;
            tsSpritesManager.dialogBox.SetActive(true);
            tsMainScript.DialogIndex = 68;
            ProceedText(IsContinue, false);
        }
        else if (EventID == 68)
        {
            tsSpritesManager.BackgroundUpdate("TwilightsBedroom");
            tsSpritesManager.TwilightSitSad.SetActive(true);
            tsMainScript.Clickable = true;
            tsSpritesManager.dialogBox.SetActive(true);
            tsMainScript.DialogIndex = 69;
            ProceedText(IsContinue, false);
        }
        else if (EventID == 69)
        {
            tsSpritesManager.BackgroundUpdate("TwilightsBedroom");
            tsSpritesManager.TwilightSitSad.SetActive(true);
            tsMainScript.Clickable = true;
            tsSpritesManager.dialogBox.SetActive(true);
            tsMainScript.DialogIndex = 70;
            ProceedText(IsContinue, false);
        }
        else if (EventID == 70)
        {
            tsSpritesManager.BackgroundUpdate("TwilightsBedroom");
            tsSpritesManager.TwilightSitSad.SetActive(true);
            tsMainScript.Clickable = true;
            tsSpritesManager.dialogBox.SetActive(true);
            tsMainScript.DialogIndex = 71;
            ProceedText(IsContinue, false);
        }
        else if (EventID == 71)
        {
            tsSpritesManager.BackgroundUpdate("TwilightsBedroom");
            tsSpritesManager.TwilightSitSad.SetActive(true);
            tsMainScript.Clickable = true;
            tsSpritesManager.dialogBox.SetActive(true);
            tsMainScript.DialogIndex = 72;
            ProceedText(IsContinue, false);
        }
        else if (EventID == 72)
        {
            tsSpritesManager.BackgroundUpdate("TwilightsBedroom");
            tsSpritesManager.TwilightSitSad.SetActive(true);
            tsMainScript.Clickable = true;
            tsSpritesManager.dialogBox.SetActive(true);
            tsMainScript.DialogIndex = 73;
            ProceedText(IsContinue, false);
        }
        else if (EventID == 73)
        {
            tsSpritesManager.BackgroundUpdate("TwilightsBedroom");
            tsSpritesManager.TwilightSitSad.SetActive(true);
            tsMainScript.Clickable = true;
            tsSpritesManager.dialogBox.SetActive(true);
            tsMainScript.DialogIndex = 74;
            ProceedText(IsContinue, false);
        }
        else if (EventID == 74)
        {
            tsMainScript.Clickable = false;
            tsMainScript.DialogIndex = 75;
            Invoke("Event74Delay", 1.4f);
            ProceedText(false, false);
        }
        else if (EventID == 75)
        {
            tsSpritesManager.BackgroundUpdate("TwilightsBedroom");
            tsSpritesManager.TwilightSitSad.SetActive(true);
            tsMainScript.Clickable = true;
            tsSpritesManager.dialogBox.SetActive(true);
            tsMainScript.DialogIndex = 76;
            ProceedText(IsContinue, false);
        }
        else if (EventID == 76)
        {
            tsSpritesManager.BackgroundUpdate("TwilightsBedroom");
            tsSpritesManager.TwilightSitSad.SetActive(true);
            tsMainScript.Clickable = true;
            tsSpritesManager.dialogBox.SetActive(true);
            tsMainScript.DialogIndex = 77;
            ProceedText(IsContinue, false);
        }
        else if (EventID == 77)
        {
            tsSpritesManager.BackgroundUpdate("TwilightsBedroom");
            tsSpritesManager.TwilightSitSad.SetActive(true);
            tsMainScript.Clickable = true;
            tsSpritesManager.dialogBox.SetActive(true);
            tsMainScript.DialogIndex = 78;
            ProceedText(IsContinue, false);
        }
        else if (EventID == 78)
        {
            tsSpritesManager.BackgroundUpdate("TwilightsBedroom");
            tsSpritesManager.TwilightSitSad.SetActive(true);
            tsMainScript.Clickable = true;
            tsSpritesManager.dialogBox.SetActive(true);
            tsMainScript.DialogIndex = 79;
            ProceedText(IsContinue, false);
        }
        else if (EventID == 79)
        {
            tsSpritesManager.BackgroundUpdate("TwilightsBedroom");
            tsSpritesManager.TwilightSitSad.SetActive(true);
            tsMainScript.Clickable = true;
            tsSpritesManager.dialogBox.SetActive(true);
            tsMainScript.DialogIndex = 80;
            ProceedText(IsContinue, false);
        }
        else if (EventID == 80)
        {
            tsSpritesManager.BackgroundUpdate("TwilightsBedroom");
            tsSpritesManager.TwilightSitSad.SetActive(true);
            tsMainScript.Clickable = true;
            tsSpritesManager.dialogBox.SetActive(true);
            tsMainScript.DialogIndex = 81;
            ProceedText(IsContinue, false);
        }
        else if (EventID == 81)
        {
            tsSpritesManager.BackgroundUpdate("TwilightsBedroom");
            tsSpritesManager.TwilightSitSad.SetActive(true);
            tsMainScript.Clickable = true;
            tsSpritesManager.dialogBox.SetActive(true);
            tsMainScript.DialogIndex = 82;
            ProceedText(IsContinue, false);
        }
        else if (EventID == 82)
        {
            tsSpritesManager.BackgroundUpdate("TwilightsBedroom");
            tsSpritesManager.TwilightSitSad.SetActive(true);
            tsMainScript.Clickable = true;
            tsSpritesManager.dialogBox.SetActive(true);
            tsMainScript.DialogIndex = 83;
            ProceedText(IsContinue, false);
        }
        else if (EventID == 83)
        {
            tsSpritesManager.BackgroundUpdate("TwilightsBedroom");
            if (!IsContinue)
            {
                tsSpritesManager.TwilightSitSad.SetActive(false);
            }
            tsSpritesManager.TwilightStandNormal.SetActive(true);
            tsMainScript.Clickable = true;
            tsSpritesManager.dialogBox.SetActive(true);
            tsMainScript.DialogIndex = 84;
            ProceedText(IsContinue, false);
        }
        else if (EventID == 84)
        {
            tsSpritesManager.BackgroundUpdate("TwilightsBedroom");
            tsSpritesManager.TwilightStandNormal.SetActive(true);
            tsMainScript.Clickable = true;
            tsSpritesManager.dialogBox.SetActive(true);
            tsMainScript.DialogIndex = 85;
            ProceedText(IsContinue, false);
        }
        else if (EventID == 85)
        {
            tsSpritesManager.BackgroundUpdate("TwilightsBedroom");
            if (!IsContinue)
            {
                tsSpritesManager.TwilightStandNormal.SetActive(false);
            }
            tsSpritesManager.TwilightSitSad.SetActive(true);
            tsMainScript.Clickable = true;
            tsSpritesManager.dialogBox.SetActive(true);
            tsMainScript.DialogIndex = 86;
            ProceedText(IsContinue, false);
        }
        else if (EventID == 86)
        {
            tsSpritesManager.BackgroundUpdate("TwilightsBedroom");
            tsSpritesManager.TwilightSitSad.SetActive(true);
            tsMainScript.Clickable = true;
            tsSpritesManager.dialogBox.SetActive(true);
            tsMainScript.DialogIndex = 87;
            ProceedText(IsContinue, false);
        }
        else if (EventID == 87)
        {
            tsSpritesManager.BackgroundUpdate("TwilightsBedroom");
            AudioManager.Instance.PlayBGM(BGMID.ChildOfMagic);
            if (!IsContinue)
            {
                tsSpritesManager.TwilightSitSad.SetActive(false);
            }
            tsSpritesManager.TwilightStandHappy.SetActive(true);
            tsMainScript.Clickable = true;
            tsSpritesManager.dialogBox.SetActive(true);
            tsMainScript.DialogIndex = 88;
            ProceedText(IsContinue, false);
        }
        else if (EventID == 88)
        {
            tsSpritesManager.BackgroundUpdate("TwilightsBedroom");
            AudioManager.Instance.PlayBGM(BGMID.ChildOfMagic);
            tsSpritesManager.TwilightStandHappy.SetActive(true);
            tsMainScript.Clickable = true;
            tsSpritesManager.dialogBox.SetActive(true);
            tsMainScript.DialogIndex = 89;
            ProceedText(IsContinue, false);
        }
        else if (EventID == 89)
        {
            tsSpritesManager.BackgroundUpdate("TwilightsBedroom");
            AudioManager.Instance.PlayBGM(BGMID.ChildOfMagic);
            tsSpritesManager.TwilightStandHappy.SetActive(true);
            tsMainScript.Clickable = true;
            tsSpritesManager.dialogBox.SetActive(true);
            tsMainScript.DialogIndex = 90;
            ProceedText(IsContinue, false);
        }
        else if (EventID == 90)
        {
            tsSpritesManager.BackgroundUpdate("TwilightsBedroom");
            tsSpritesManager.dialogBox.SetActive(true);
            tsMainScript.DialogIndex = 91;
            if (!IsContinue)
            {
                AudioManager.Instance.StopBGM(false);
                AudioManager.Instance.PlaySE(SEID.se_script_011);
                tsMainScript.Clickable = false;
                Invoke("Event90Delay", 2f);
            }
            else if (IsContinue)
            {
                tsMainScript.Clickable = true;
                tsSpritesManager.TwilightStandNormal.SetActive(true);
                ProceedText(true, false);
            }
        }
        else if (EventID == 91)
        {
            tsSpritesManager.BackgroundUpdate("TwilightsBedroom");
            if (!IsContinue)
            {
                tsSpritesManager.TwilightStandNormal.SetActive(false);
            }
            tsSpritesManager.TwilightStandScared.SetActive(true);
            tsMainScript.Clickable = true;
            tsSpritesManager.dialogBox.SetActive(true);
            tsMainScript.DialogIndex = 92;
            ProceedText(IsContinue, false);
        }
        else if (EventID == 92)
        {
            tsSpritesManager.BackgroundUpdate("TwilightsBedroom");
            tsSpritesManager.TwilightStandScared.SetActive(true);
            tsMainScript.Clickable = true;
            tsSpritesManager.dialogBox.SetActive(true);
            tsMainScript.DialogIndex = 93;
            ProceedText(IsContinue, false);
        }
        else if (EventID == 93)
        {
            tsSpritesManager.BackgroundUpdate("TwilightsBedroom");
            tsSpritesManager.dialogBox.SetActive(true);
            tsMainScript.DialogIndex = 94;
            ProceedText(IsContinue, false);
            if (!IsContinue)
            {
                tsMainScript.Clickable = false;
                tsSpritesManager.TwilightStandScared.SetActive(false);
                tsSpritesManager.TwilightStandExplain.SetActive(true);
                Invoke("Event93Delay", 3.3f);
            }
            else if (IsContinue)
            {
                tsMainScript.Clickable = true;
                tsSpritesManager.TwilightStandHappy.SetActive(true);
            }
        }
        else if (EventID == 94)
        {
            tsSpritesManager.BackgroundUpdate("TwilightsBedroom");
            tsSpritesManager.dialogBox.SetActive(true);
            tsMainScript.DialogIndex = 95;
            if (!IsContinue)
            {
                tsMainScript.Clickable = false;
                tsSpritesManager.TwilightStandHappy.GetComponent<SpriteRenderer>().DOFade(0, 1f);
                Invoke("Event94Delay", 2f);
            }
            else if (IsContinue)
            {
                tsMainScript.Clickable = true;
                ProceedText(true, false);
            }
        }
        else if (EventID == 95)
        {
            tsMainScript.EventID = 94;
            tsSpritesManager.dialogBox.SetActive(false);
            tsSpritesManager.SpeechText.GetComponent<TMP_Text>().text = "";
            tsSpritesManager.NewAreaText.GetComponent<TMP_Text>().text = "";
            tsMainScript.Clickable = false;
            tsSpritesManager.TwilightsBedroom.GetComponent<SpriteRenderer>().DOFade(0, 3f);
            Invoke("Event95Delay", 5f);
        }
    }
    #endregion

    #region 游戏进程脚本（延迟）
    public void Event9Delay()
    {
        tsSpritesManager.WhiteScreen.SetActive(true);
    }
    public void Event9Delay2()
    {
        AudioManager.Instance.PlaySE(SEID.se_script_007);
        tsSpritesManager.WhiteScreen.SetActive(false);
        tsSpritesManager.dialogBox.SetActive(true);
        tsMainScript.Clickable = true;
        ProceedText(false, false);
    }
    public void Event10Delay()
    {
        AudioManager.Instance.PlaySE(SEID.se_script_011);
        ProceedText(false, false);
        tsMainScript.Clickable = true;
    }
    public void Event11Delay()
    {
        tsMainScript.EventID = 12;
        tsMainScript.Proceed = true;
        tsSpritesManager.WhiteScreen.SetActive(true);
    }
    public void Event12Delay()
    {
        tsSpritesManager.WhiteScreen.SetActive(false);
        MainCamera.GetComponent<Camera>().DOShakePosition(.3f, new Vector3(2, 0, 0)).SetLoops(1, LoopType.Yoyo);
        AudioManager.Instance.PlaySE(SEID.se_script_008);
        ProceedText(false, false);
        tsMainScript.Clickable = true;
    }
    public void Event18Delay()
    {
        tsSpritesManager.TwilightStandConfused.SetActive(false);
        tsSpritesManager.TwilightStandHappy.SetActive(true);
    }
    public void Event18Delay2()
    {
        tsMainScript.EventID = 19;
        tsMainScript.Proceed = true;
    }
    public void Event19Delay()
    {
        tsSpritesManager.dialogBox.SetActive(true);
        tsMainScript.DialogIndex = 20;
        tsMainScript.Clickable = true;
        ProceedText(false, false);
    }
    public void Event30Delay()
    {
        tsSpritesManager.TwilightStandStartled.SetActive(false);
        tsSpritesManager.TwilightStandWhat.SetActive(true);
        tsMainScript.Clickable = true;
    }
    public void Event37Delay()
    {
        AudioManager.Instance.PlaySE(SEID.se_script_011);
        tsSpritesManager.TwilightStandExplain.SetActive(false);
        tsSpritesManager.TwilightStandHappy.SetActive(true);
        tsSpritesManager.WhiteScreen.GetComponent<Image>().DOFade(0, .3f);
        ProceedText(false, false);
    }
    public void Event37Delay2()
    {
        tsSpritesManager.WhiteScreen.GetComponent<Image>().DOFade(1, 0f);
        tsSpritesManager.WhiteScreen.SetActive(false);
    }
    public void Event57Delay()
    {
        tsMainScript.Clickable = true;
        tsSpritesManager.TwilightStandExplain.SetActive(false);
        tsSpritesManager.TwilightStandExplain.GetComponent<SpriteRenderer>().DOFade(1, 0f);
        ProceedText(false, false);
    }
    public void Event58Delay()
    {
        AudioManager.Instance.PlaySE(SEID.se_script_011);
        ProceedText(false, false);
    }
    public void Event58Delay2()
    {
        tsSpritesManager.TwilightStandHappy.SetActive(false);
        tsSpritesManager.TwilightStandConfused.SetActive(true);
    }
    public void Event58Delay3()
    {
        tsMainScript.Clickable = true;
        tsSpritesManager.TwilightStandHappy.SetActive(true);
        tsSpritesManager.TwilightStandConfused.SetActive(false);
    }
    public void Event59Delay()
    {
        tsMainScript.Clickable = true;
        ProceedText(false, false);
    }
    public void Event64Delay()
    {
        AudioManager.Instance.StopBGM(false);
        AudioManager.Instance.PlaySE(SEID.se_script_011);
        tsSpritesManager.WhiteScreen.GetComponent<Image>().DOFade(0, .3f);
        tsSpritesManager.TwilightSitOops.SetActive(false);
        tsSpritesManager.TwilightSitSad.SetActive(true);
        ProceedText(false, false);
    }
    public void Event64Delay2()
    {
        tsSpritesManager.WhiteScreen.SetActive(false);
        tsSpritesManager.WhiteScreen.GetComponent<Image>().DOFade(1, 0f);
    }
    public void Event74Delay()
    {
        tsMainScript.EventID = 75;
        tsMainScript.Proceed = true;
    }
    public void Event90Delay()
    {
        tsMainScript.Clickable = true;
        tsSpritesManager.TwilightStandHappy.SetActive(false);
        tsSpritesManager.TwilightStandNormal.SetActive(true);
        ProceedText(false, false);
    }
    public void Event93Delay()
    {
        tsMainScript.Clickable = true;
        tsSpritesManager.TwilightStandExplain.SetActive(false);
        tsSpritesManager.TwilightStandHappy.SetActive(true);
    }
    public void Event94Delay()
    {
        tsMainScript.Clickable = true;
        tsSpritesManager.TwilightStandHappy.SetActive(false);
        tsSpritesManager.TwilightStandHappy.GetComponent<SpriteRenderer>().DOFade(1, 0f);
        ProceedText(false, false);
    }
    public void Event95Delay()
    {
        tsMainScript.AreaID = 3;
        tsMainScript.EventID = 0;
        tsMainScript.ProceedGame(tsMainScript.ChapterID, tsMainScript.AreaID, false);
    }
    #endregion

}
