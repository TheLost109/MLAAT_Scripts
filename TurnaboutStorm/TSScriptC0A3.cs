using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

public class TSScriptC0A3 : MonoBehaviour
{
    // 主摄像机
    public GameObject MainCamera;
    // 逆转风暴基础脚本
    public TSMainScript tsMainScript;
    // 逆转风暴 - 贴图管理器
    public TSSpritesManager tsSpritesManager;
    // 法庭记录系统
    public CourtRecordsSystem courtRecordsSystem;
    // 对话文件
    public TextAsset DialogFile;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ProceedGame(int EventID, bool IsContinue)
    {
        if (tsMainScript.CurrentScript != "TSScriptC0A3")
        {
            // 读取 TextAsset
            tsMainScript.CurrentScript = "TSScriptC0A3";
            tsMainScript.ReadText(DialogFile);
            Debug.Log("已读取对话文本TSScriptC0A3");
        }
        print(tsMainScript.EventID);
        // Area 3 去看守所的路上
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
                tsSpritesManager.PonyvilleNight.GetComponent<SpriteRenderer>().DOFade(0, 0f);
                Invoke("Event0Delay", .1f);
                Invoke("Event0Delay2", 1f);
            }
            else
            {
                tsMainScript.Clickable = true;
                tsSpritesManager.BackgroundUpdate("PonyvilleNight");
                ProceedText(true, false);
            }
        }
        else if (EventID == 1)
        {
            tsMainScript.DialogIndex = 2;
            tsMainScript.Clickable = true;
            tsSpritesManager.BackgroundUpdate("PonyvilleNight");
            if (!IsContinue)
            {
                tsSpritesManager.NameTag.SetActive(true);
                tsSpritesManager.SpeechText.SetActive(true);
                tsSpritesManager.NewAreaText.SetActive(false);
                ProceedText(false, false);
            }
            else
            {
                tsSpritesManager.dialogBox.SetActive(true);
                ProceedText(true, false);
            }
        }
        else if (EventID == 2)
        {
            tsMainScript.DialogIndex = 3;
            tsSpritesManager.dialogBox.SetActive(true);
            tsSpritesManager.BackgroundUpdate("PonyvilleNight");
            if (!IsContinue)
            {
                tsMainScript.Clickable = false;
                tsSpritesManager.TwilightStandNormal.GetComponent<SpriteRenderer>().DOFade(0, 0f);
                Invoke("Event2Delay", .1f);
                Invoke("Event2Delay2", 1f);
            }
            else
            {
                tsMainScript.Clickable = true;
                tsSpritesManager.TwilightStandConfused.SetActive(true);
                ProceedText(true, false);
            }
        }
        else if (EventID == 3)
        {
            tsMainScript.Clickable = true;
            tsMainScript.DialogIndex = 4;
            tsSpritesManager.dialogBox.SetActive(true);
            tsSpritesManager.BackgroundUpdate("PonyvilleNight");
            tsSpritesManager.TwilightStandConfused.SetActive(true);
            ProceedText(IsContinue, false);
        }
        else if (EventID == 4)
        {
            tsMainScript.Clickable = true;
            tsMainScript.DialogIndex = 5;
            tsSpritesManager.dialogBox.SetActive(true);
            tsSpritesManager.BackgroundUpdate("PonyvilleNight");
            tsSpritesManager.TwilightStandConfused.SetActive(false);
            tsSpritesManager.TwilightStandNormal.SetActive(true);
            ProceedText(IsContinue, false);
        }
        else if (EventID == 5)
        {
            tsMainScript.Clickable = true;
            tsMainScript.DialogIndex = 6;
            tsSpritesManager.dialogBox.SetActive(true);
            tsSpritesManager.BackgroundUpdate("PonyvilleNight");
            tsSpritesManager.TwilightStandNormal.SetActive(false);
            tsSpritesManager.TwilightStandConfused.SetActive(true);
            ProceedText(IsContinue, false);
        }
        else if (EventID == 6)
        {
            tsMainScript.Clickable = true;
            tsMainScript.DialogIndex = 7;
            tsSpritesManager.dialogBox.SetActive(true);
            tsSpritesManager.BackgroundUpdate("PonyvilleNight");
            tsSpritesManager.TwilightStandConfused.SetActive(false);
            tsSpritesManager.TwilightStandHappy.SetActive(true);
            ProceedText(IsContinue, false);
        }
        else if (EventID == 7)
        {
            tsMainScript.Clickable = true;
            tsMainScript.DialogIndex = 8;
            tsSpritesManager.dialogBox.SetActive(true);
            tsSpritesManager.BackgroundUpdate("PonyvilleNight");
            tsSpritesManager.TwilightStandHappy.SetActive(true);
            ProceedText(IsContinue, false);
        }
        else if (EventID == 8)
        {
            tsMainScript.Clickable = true;
            tsMainScript.DialogIndex = 9;
            tsSpritesManager.dialogBox.SetActive(true);
            tsSpritesManager.BackgroundUpdate("PonyvilleNight");
            tsSpritesManager.TwilightStandHappy.SetActive(true);
            ProceedText(IsContinue, false);
        }
        else if (EventID == 9)
        {
            tsMainScript.Clickable = true;
            tsMainScript.DialogIndex = 10;
            tsSpritesManager.dialogBox.SetActive(true);
            tsSpritesManager.BackgroundUpdate("PonyvilleNight");
            tsSpritesManager.TwilightStandHappy.SetActive(true);
            ProceedText(IsContinue, false);
        }
        else if (EventID == 10)
        {
            tsMainScript.Clickable = true;
            tsMainScript.DialogIndex = 11;
            tsSpritesManager.dialogBox.SetActive(true);
            tsSpritesManager.BackgroundUpdate("PonyvilleNight");
            tsSpritesManager.TwilightStandHappy.SetActive(false);
            tsSpritesManager.TwilightStandExplain.SetActive(true);
            ProceedText(IsContinue, false);
        }
        else if (EventID == 11)
        {
            tsMainScript.Clickable = true;
            tsMainScript.DialogIndex = 12;
            tsSpritesManager.dialogBox.SetActive(true);
            tsSpritesManager.BackgroundUpdate("PonyvilleNight");
            tsSpritesManager.TwilightStandExplain.SetActive(true);
            ProceedText(IsContinue, false);
        }
        else if (EventID == 12)
        {
            tsMainScript.Clickable = true;
            tsMainScript.DialogIndex = 13;
            tsSpritesManager.dialogBox.SetActive(true);
            tsSpritesManager.BackgroundUpdate("PonyvilleNight");
            tsSpritesManager.TwilightStandExplain.SetActive(false);
            tsSpritesManager.TwilightStandHappy.SetActive(true);
            ProceedText(IsContinue, false);
        }
        else if (EventID == 13)
        {
            tsMainScript.Clickable = true;
            tsMainScript.DialogIndex = 14;
            tsSpritesManager.dialogBox.SetActive(true);
            tsSpritesManager.BackgroundUpdate("PonyvilleNight");
            tsSpritesManager.TwilightStandHappy.SetActive(true);
            ProceedText(IsContinue, false);
        }
        else if (EventID == 14)
        {
            tsMainScript.Clickable = true;
            tsMainScript.DialogIndex = 15;
            tsSpritesManager.dialogBox.SetActive(true);
            tsSpritesManager.BackgroundUpdate("PonyvilleNight");
            tsSpritesManager.TwilightStandHappy.SetActive(false);
            tsSpritesManager.TwilightStandNormal.SetActive(true);
            ProceedText(IsContinue, false);
        }
        else if (EventID == 15)
        {
            tsMainScript.Clickable = false;
            tsMainScript.DialogIndex = 16;
            tsSpritesManager.dialogBox.SetActive(true);
            tsSpritesManager.BackgroundUpdate("PonyvilleNight");
            if (!IsContinue)
            {
                tsSpritesManager.TwilightStandNormal.GetComponent<SpriteRenderer>().DOFade(0, .25f);
                tsSpritesManager.RoyalGuard1Body.GetComponent<SpriteRenderer>().DOFade(0, 0f);
                tsSpritesManager.RoyalGuard2Body.GetComponent<SpriteRenderer>().DOFade(0, 0f);
                Invoke("Event15Delay", .25f);
                Invoke("Event15Delay2", .5f);
            }
            else
            {
                tsMainScript.Clickable = true;
                tsSpritesManager.RoyalGuard1Body.SetActive(true);
                tsSpritesManager.RoyalGuard1MouthMask.SetActive(true);
                tsSpritesManager.RoyalGuard1MouthTalking.SetActive(true);
                tsSpritesManager.RoyalGuard2Body.SetActive(true);
                ProceedText(true, false);
            }
        }
        else if (EventID == 16)
        {
            tsMainScript.Clickable = false;
            tsMainScript.DialogIndex = 17;
            tsSpritesManager.dialogBox.SetActive(true);
            tsSpritesManager.BackgroundUpdate("PonyvilleNight");
            if (!IsContinue)
            {
                tsSpritesManager.RoyalGuard1MouthMask.SetActive(false);
                tsSpritesManager.RoyalGuard1MouthTalking.SetActive(false);
                tsSpritesManager.RoyalGuard1Body.GetComponent<SpriteRenderer>().DOFade(0, .25f);
                tsSpritesManager.RoyalGuard2Body.GetComponent<SpriteRenderer>().DOFade(0, .25f);
                tsSpritesManager.TwilightStandNormal.GetComponent<SpriteRenderer>().DOFade(0, 0f);
                Invoke("Event16Delay", .25f);
                Invoke("Event16Delay2", .5f);
            }
            else
            {
                tsMainScript.Clickable = true;
                tsSpritesManager.TwilightStandConfused.SetActive(true);
                ProceedText(true, false);
            }
        }
        else if (EventID == 17)
        {
            tsMainScript.Clickable = false;
            tsMainScript.DialogIndex = 18;
            tsSpritesManager.dialogBox.SetActive(true);
            tsSpritesManager.BackgroundUpdate("PonyvilleNight");
            if (!IsContinue)
            {
                tsSpritesManager.TwilightStandConfused.GetComponent<SpriteRenderer>().DOFade(0, .25f);
                tsSpritesManager.RoyalGuard1Body.GetComponent<SpriteRenderer>().DOFade(0, 0f);
                tsSpritesManager.RoyalGuard2Body.GetComponent<SpriteRenderer>().DOFade(0, 0f);
                Invoke("Event17Delay", .26f);
                Invoke("Event17Delay2", .51f);
            }
            else
            {
                tsMainScript.Clickable = true;
                tsSpritesManager.RoyalGuard1Body.SetActive(true);
                tsSpritesManager.RoyalGuard2Body.SetActive(true);
                ProceedText(true, false);
            }
        }
        else if (EventID == 18)
        {
            tsMainScript.Clickable = true;
            tsMainScript.DialogIndex = 19;
            tsSpritesManager.dialogBox.SetActive(true);
            tsSpritesManager.BackgroundUpdate("PonyvilleNight");
            tsSpritesManager.RoyalGuard1Body.SetActive(true);
            tsSpritesManager.RoyalGuard2Body.SetActive(true);
            tsSpritesManager.RoyalGuard2MouthMask.SetActive(true);
            tsSpritesManager.RoyalGuard2MouthTalking.SetActive(true);
            ProceedText(IsContinue, false);
        }
        else if (EventID == 19)
        {
            tsMainScript.Clickable = false;
            tsMainScript.DialogIndex = 20;
            tsSpritesManager.dialogBox.SetActive(true);
            tsSpritesManager.BackgroundUpdate("PonyvilleNight");
            if (!IsContinue)
            {
                tsSpritesManager.RoyalGuard2MouthMask.SetActive(false);
                tsSpritesManager.RoyalGuard2MouthTalking.SetActive(false);
                ProceedText(false, false);
                Invoke("Event19Delay", 0.7f);
                Invoke("Event19Delay2", 1.2f);
            }
            else
            {
                tsMainScript.Clickable = true;
                tsSpritesManager.RoyalGuard1Body.SetActive(true);
                tsSpritesManager.RoyalGuard2Body.SetActive(true);
                tsSpritesManager.ItemHolder.SetActive(true);
                tsSpritesManager.AttorneyBadge.SetActive(true);
                ProceedText(true, false);
            }
        }
        else if (EventID == 20)
        {
            tsMainScript.Clickable = true;
            tsMainScript.DialogIndex = 21;
            tsSpritesManager.dialogBox.SetActive(true);
            tsSpritesManager.BackgroundUpdate("PonyvilleNight");
            tsSpritesManager.RoyalGuard1Body.SetActive(true);
            tsSpritesManager.RoyalGuard2Body.SetActive(true);
            tsSpritesManager.ItemHolder.SetActive(true);
            tsSpritesManager.AttorneyBadge.SetActive(true);
            ProceedText(IsContinue, false);
        }
        else if (EventID == 21)
        {
            tsMainScript.Clickable = true;
            tsMainScript.DialogIndex = 22;
            tsSpritesManager.dialogBox.SetActive(true);
            tsSpritesManager.BackgroundUpdate("PonyvilleNight");
            tsSpritesManager.RoyalGuard1Body.SetActive(true);
            tsSpritesManager.RoyalGuard1MouthMask.SetActive(true);
            tsSpritesManager.RoyalGuard1MouthTalking.SetActive(true);
            tsSpritesManager.RoyalGuard2Body.SetActive(true);
            tsSpritesManager.ItemHolder.SetActive(true);
            tsSpritesManager.AttorneyBadge.SetActive(true);
            ProceedText(IsContinue, false);
        }
        else if (EventID == 22)
        {
            tsMainScript.Clickable = true;
            tsMainScript.DialogIndex = 23;
            tsSpritesManager.dialogBox.SetActive(true);
            tsSpritesManager.BackgroundUpdate("PonyvilleNight");
            if (!IsContinue)
            {
                tsSpritesManager.RoyalGuard1MouthMask.SetActive(false);
                tsSpritesManager.RoyalGuard1MouthTalking.SetActive(false);
            }
            tsSpritesManager.RoyalGuard1Body.SetActive(true);
            tsSpritesManager.RoyalGuard2MouthMask.SetActive(true);
            tsSpritesManager.RoyalGuard2MouthTalking.SetActive(true);
            tsSpritesManager.RoyalGuard2Body.SetActive(true);
            tsSpritesManager.ItemHolder.SetActive(true);
            tsSpritesManager.AttorneyBadge.SetActive(true);
            ProceedText(IsContinue, false);
        }
        else if (EventID == 23)
        {
            tsMainScript.Clickable = true;
            tsMainScript.DialogIndex = 24;
            tsSpritesManager.dialogBox.SetActive(true);
            tsSpritesManager.BackgroundUpdate("PonyvilleNight");
            if (!IsContinue)
            {
                tsSpritesManager.RoyalGuard2MouthMask.SetActive(false);
                tsSpritesManager.RoyalGuard2MouthTalking.SetActive(false);
            }
            tsSpritesManager.RoyalGuard1Body.SetActive(true);
            tsSpritesManager.RoyalGuard2Body.SetActive(true);
            tsSpritesManager.ItemHolder.SetActive(true);
            tsSpritesManager.AttorneyBadge.SetActive(true);
            ProceedText(IsContinue, false);
        }
        else if (EventID == 24)
        {
            tsMainScript.DialogIndex = 25;
            tsSpritesManager.dialogBox.SetActive(true);
            tsSpritesManager.BackgroundUpdate("PonyvilleNight");
            if (!IsContinue)
            {
                tsMainScript.Clickable = false;
                tsSpritesManager.ItemHolder.GetComponent<RectTransform>().DOScale(new Vector3(0, 0, 0), .5f);
                AudioManager.Instance.PlaySE(SEID.se_com_008);
                Invoke("Event24Delay", 1.5f);
            }
            else
            {
                tsMainScript.Clickable = true;
                tsSpritesManager.RoyalGuard1Body.SetActive(true);
                tsSpritesManager.RoyalGuard1MouthMask.SetActive(true);
                tsSpritesManager.RoyalGuard1MouthTalking.SetActive(true);
                tsSpritesManager.RoyalGuard2Body.SetActive(true);
                ProceedText(true, false);
            }
        }
        else if (EventID == 25)
        {
            tsMainScript.Clickable = true;
            tsMainScript.DialogIndex = 26;
            tsSpritesManager.dialogBox.SetActive(true);
            tsSpritesManager.BackgroundUpdate("PonyvilleNight");
            if (!IsContinue)
            {
                tsSpritesManager.RoyalGuard1MouthMask.SetActive(false);
                tsSpritesManager.RoyalGuard1MouthTalking.SetActive(false);
            }
            tsSpritesManager.RoyalGuard1Body.SetActive(true);
            tsSpritesManager.RoyalGuard2Body.SetActive(true);
            ProceedText(IsContinue, false);
        }
        else if (EventID == 26)
        {
            tsMainScript.Clickable = true;
            tsMainScript.DialogIndex = 27;
            tsSpritesManager.dialogBox.SetActive(true);
            tsSpritesManager.BackgroundUpdate("PonyvilleNight");
            tsSpritesManager.RoyalGuard1Body.SetActive(true);
            tsSpritesManager.RoyalGuard2Body.SetActive(true);
            tsSpritesManager.RoyalGuard2MouthMask.SetActive(true);
            tsSpritesManager.RoyalGuard2MouthTalking.SetActive(true);
            ProceedText(IsContinue, false);
        }
        else if (EventID == 27)
        {
            tsMainScript.DialogIndex = 28;
            tsSpritesManager.dialogBox.SetActive(true);
            tsSpritesManager.BackgroundUpdate("PonyvilleNight");
            if (!IsContinue)
            {
                tsMainScript.Clickable = false;
                tsSpritesManager.RoyalGuard2MouthMask.SetActive(false);
                tsSpritesManager.RoyalGuard2MouthTalking.SetActive(false);
                tsSpritesManager.RoyalGuard1Body.GetComponent<SpriteRenderer>().DOFade(0, .25f);
                tsSpritesManager.RoyalGuard2Body.GetComponent<SpriteRenderer>().DOFade(0, .25f);
                tsSpritesManager.TwilightStandNormal.GetComponent<SpriteRenderer>().DOFade(0, 0f);
                Invoke("Event27Delay", .25f);
                Invoke("Event27Delay2", 1f);
            }
            else
            {
                tsMainScript.Clickable = true;
                tsSpritesManager.TwilightStandNormal.SetActive(true);
                ProceedText(true, false);
            }
        }
        else if (EventID == 28)
        {
            tsMainScript.Clickable = true;
            tsMainScript.DialogIndex = 29;
            tsSpritesManager.dialogBox.SetActive(true);
            tsSpritesManager.BackgroundUpdate("PonyvilleNight");
            if (!IsContinue)
            {
                tsSpritesManager.TwilightStandNormal.SetActive(false);
            }
            tsSpritesManager.TwilightStandHappy.SetActive(true);
            ProceedText(IsContinue, false);
        }
        else if (EventID == 29)
        {
            tsMainScript.DialogIndex = 30;
            tsSpritesManager.dialogBox.SetActive(true);
            tsSpritesManager.BackgroundUpdate("PonyvilleNight");
            tsSpritesManager.EquestrianAttorneyBadge.SetActive(true);
            tsSpritesManager.ItemHolder.SetActive(true);
            tsSpritesManager.TwilightStandHappy.SetActive(true);
            if (!IsContinue)
            {
                tsMainScript.Clickable = false;
                AudioManager.Instance.PlaySE(SEID.item_pop);
                Invoke("Event29Delay", .83f);
            }
            else
            {
                tsMainScript.Clickable = true;
                ProceedText(true, false);
            }
        }
        else if (EventID == 30)
        {
            tsMainScript.Clickable = true;
            tsMainScript.DialogIndex = 31;
            tsSpritesManager.dialogBox.SetActive(true);
            tsSpritesManager.BackgroundUpdate("PonyvilleNight");
            tsSpritesManager.EquestrianAttorneyBadge.SetActive(true);
            tsSpritesManager.ItemHolder.SetActive(true);
            tsSpritesManager.TwilightStandHappy.SetActive(true);
            ProceedText(IsContinue, false);
        }
        else if (EventID == 31)
        {
            tsMainScript.Clickable = true;
            tsMainScript.DialogIndex = 32;
            tsSpritesManager.dialogBox.SetActive(true);
            tsSpritesManager.BackgroundUpdate("PonyvilleNight");
            if (!IsContinue)
            {
                tsSpritesManager.TwilightStandHappy.SetActive(false);
            }
            tsSpritesManager.EquestrianAttorneyBadge.SetActive(true);
            tsSpritesManager.ItemHolder.SetActive(true);
            tsSpritesManager.TwilightStandNormal.SetActive(true);
            ProceedText(IsContinue, false);
        }
        else if (EventID == 32)
        {
            tsMainScript.Clickable = true;
            tsMainScript.DialogIndex = 33;
            tsSpritesManager.dialogBox.SetActive(true);
            tsSpritesManager.BackgroundUpdate("PonyvilleNight");
            if (!IsContinue)
            {
                tsSpritesManager.TwilightStandNormal.SetActive(false);
            }
            tsSpritesManager.EquestrianAttorneyBadge.SetActive(true);
            tsSpritesManager.ItemHolder.SetActive(true);
            tsSpritesManager.TwilightStandScared.SetActive(true);
            ProceedText(IsContinue, false);
        }
        else if (EventID == 33)
        {
            tsMainScript.Clickable = true;
            tsMainScript.DialogIndex = 34;
            tsSpritesManager.dialogBox.SetActive(true);
            tsSpritesManager.BackgroundUpdate("PonyvilleNight");
            tsSpritesManager.EquestrianAttorneyBadge.SetActive(true);
            tsSpritesManager.ItemHolder.SetActive(true);
            tsSpritesManager.TwilightStandScared.SetActive(true);
            ProceedText(IsContinue, false);
        }
        else if (EventID == 34)
        {
            tsMainScript.Clickable = true;
            tsMainScript.DialogIndex = 35;
            tsSpritesManager.dialogBox.SetActive(true);
            tsSpritesManager.BackgroundUpdate("PonyvilleNight");
            if (!IsContinue)
            {
                tsSpritesManager.TwilightStandScared.SetActive(false);
            }
            tsSpritesManager.EquestrianAttorneyBadge.SetActive(true);
            tsSpritesManager.ItemHolder.SetActive(true);
            tsSpritesManager.TwilightStandNormal.SetActive(true);
            ProceedText(IsContinue, false);
        }
        else if (EventID == 35)
        {
            tsMainScript.Clickable = true;
            tsMainScript.DialogIndex = 36;
            tsSpritesManager.dialogBox.SetActive(true);
            tsSpritesManager.BackgroundUpdate("PonyvilleNight");
            if (!IsContinue)
            {
                tsSpritesManager.TwilightStandNormal.SetActive(false);
            }
            tsSpritesManager.EquestrianAttorneyBadge.SetActive(true);
            tsSpritesManager.ItemHolder.SetActive(true);
            tsSpritesManager.TwilightStandExplain.SetActive(true);
            ProceedText(IsContinue, false);
        }
        else if (EventID == 36)
        {
            tsMainScript.Clickable = true;
            tsMainScript.DialogIndex = 37;
            tsSpritesManager.dialogBox.SetActive(true);
            tsSpritesManager.BackgroundUpdate("PonyvilleNight");
            if (!IsContinue)
            {
                tsSpritesManager.TwilightStandExplain.SetActive(false);
            }
            tsSpritesManager.EquestrianAttorneyBadge.SetActive(true);
            tsSpritesManager.ItemHolder.SetActive(true);
            tsSpritesManager.TwilightStandWhat.SetActive(true);
            ProceedText(IsContinue, false);
        }
        else if (EventID == 37)
        {
            tsMainScript.Clickable = true;
            tsMainScript.DialogIndex = 38;
            tsSpritesManager.dialogBox.SetActive(true);
            tsSpritesManager.BackgroundUpdate("PonyvilleNight");
            if (!IsContinue)
            {
                tsSpritesManager.TwilightStandWhat.SetActive(false);
            }
            tsSpritesManager.EquestrianAttorneyBadge.SetActive(true);
            tsSpritesManager.ItemHolder.SetActive(true);
            tsSpritesManager.TwilightStandImpatient.SetActive(true);
            ProceedText(IsContinue, false);
        }
        else if (EventID == 38)
        {
            tsMainScript.Clickable = true;
            tsMainScript.DialogIndex = 39;
            tsSpritesManager.dialogBox.SetActive(true);
            tsSpritesManager.BackgroundUpdate("PonyvilleNight");
            tsSpritesManager.EquestrianAttorneyBadge.SetActive(true);
            tsSpritesManager.ItemHolder.SetActive(true);
            tsSpritesManager.TwilightStandImpatient.SetActive(true);
            ProceedText(IsContinue, false);
        }
        else if (EventID == 39)
        {
            tsMainScript.Clickable = true;
            tsMainScript.DialogIndex = 40;
            tsSpritesManager.dialogBox.SetActive(true);
            tsSpritesManager.NameTag.SetActive(false);
            tsSpritesManager.BackgroundUpdate("PonyvilleNight");
            if (!IsContinue)
            {
                AudioManager.Instance.PlaySE(SEID.se_com_017);
                courtRecordsSystem.GetNewEvidence(3);
                courtRecordsSystem.NewEvidenceShow();
                tsSpritesManager.ItemHolder.SetActive(false);
                tsSpritesManager.EquestrianAttorneyBadge.SetActive(false);
                tsMainScript.CourtRecordsHideOverlay.SetActive(true);
            }
            tsSpritesManager.TwilightStandImpatient.SetActive(true);
            ProceedText(IsContinue, false);
        }
        else if (EventID == 40)
        {
            tsMainScript.Clickable = true;
            tsMainScript.DialogIndex = 41;
            tsSpritesManager.dialogBox.SetActive(true);
            tsSpritesManager.BackgroundUpdate("PonyvilleNight");
            if (!IsContinue)
            {
                tsSpritesManager.NameTag.SetActive(true);
                tsSpritesManager.TwilightStandImpatient.SetActive(false);
            }
            tsSpritesManager.TwilightStandNormal.SetActive(true);
            ProceedText(IsContinue, false);
        }
        else if (EventID == 41)
        {
            tsMainScript.Clickable = true;
            tsMainScript.DialogIndex = 42;
            tsSpritesManager.dialogBox.SetActive(true);
            tsSpritesManager.BackgroundUpdate("PonyvilleNight");
            tsSpritesManager.TwilightStandNormal.SetActive(true);
            ProceedText(IsContinue, false);
        }
        else if (EventID == 42)
        {
            tsMainScript.Clickable = true;
            tsMainScript.DialogIndex = 43;
            tsSpritesManager.dialogBox.SetActive(true);
            tsSpritesManager.BackgroundUpdate("PonyvilleNight");
            if (!IsContinue)
            {
                tsSpritesManager.TwilightStandNormal.SetActive(false);
            }
            tsSpritesManager.TwilightStandImpatient.SetActive(true);
            ProceedText(IsContinue, false);
        }
        else if (EventID == 43)
        {
            tsMainScript.Clickable = true;
            tsMainScript.DialogIndex = 44;
            tsSpritesManager.dialogBox.SetActive(true);
            tsSpritesManager.BackgroundUpdate("PonyvilleNight");
            tsSpritesManager.TwilightStandImpatient.SetActive(true);
            ProceedText(IsContinue, false);
        }
        else if (EventID == 44)
        {
            tsMainScript.DialogIndex = 45;
            tsSpritesManager.dialogBox.SetActive(true);
            tsSpritesManager.BackgroundUpdate("PonyvilleNight");
            if (!IsContinue)
            {
                tsMainScript.Clickable = false;
                tsSpritesManager.TwilightStandImpatient.GetComponent<SpriteRenderer>().DOFade(0, .25f);
                tsSpritesManager.RoyalGuard1Body.GetComponent<SpriteRenderer>().DOFade(0, 0f);
                tsSpritesManager.RoyalGuard2Body.GetComponent<SpriteRenderer>().DOFade(0, 0f);
                Invoke("Event44Delay", .25f);
                Invoke("Event44Delay2", 1f);
                Invoke("Event44Delay3", 2.33f);
                Invoke("Event44Delay4", 3f);
            }
            else
            {
                tsMainScript.Clickable = true;
                tsSpritesManager.RoyalGuard1Body.SetActive(true);
                tsSpritesManager.RoyalGuard2Body.SetActive(true);
                tsSpritesManager.EquestrianAttorneyBadge.SetActive(true);
                tsSpritesManager.ItemHolder.SetActive(true);
                ProceedText(true, false);
            }
        }
        else if (EventID == 45)
        {
            tsMainScript.Clickable = true;
            tsMainScript.DialogIndex = 46;
            tsSpritesManager.dialogBox.SetActive(true);
            tsSpritesManager.BackgroundUpdate("PonyvilleNight");
            tsSpritesManager.RoyalGuard1Body.SetActive(true);
            tsSpritesManager.RoyalGuard2Body.SetActive(true);
            tsSpritesManager.EquestrianAttorneyBadge.SetActive(true);
            tsSpritesManager.ItemHolder.SetActive(true);
            ProceedText(IsContinue, false);
        }
        else if (EventID == 46)
        {
            tsMainScript.Clickable = true;
            tsMainScript.DialogIndex = 47;
            tsSpritesManager.dialogBox.SetActive(true);
            tsSpritesManager.BackgroundUpdate("PonyvilleNight");
            tsSpritesManager.RoyalGuard1Body.SetActive(true);
            tsSpritesManager.RoyalGuard1MouthMask.SetActive(true);
            tsSpritesManager.RoyalGuard1MouthTalking.SetActive(true);
            tsSpritesManager.RoyalGuard2Body.SetActive(true);
            tsSpritesManager.RoyalGuard2MouthMask.SetActive(true);
            tsSpritesManager.RoyalGuard2MouthTalking.SetActive(true);
            tsSpritesManager.EquestrianAttorneyBadge.SetActive(true);
            tsSpritesManager.ItemHolder.SetActive(true);
            ProceedText(IsContinue, false);
        }
        else if (EventID == 47)
        {
            tsMainScript.DialogIndex = 48;
            tsSpritesManager.dialogBox.SetActive(true);
            tsSpritesManager.BackgroundUpdate("PonyvilleNight");
            if (!IsContinue)
            {
                tsMainScript.Clickable = false;
                tsSpritesManager.RoyalGuard1MouthMask.SetActive(false);
                tsSpritesManager.RoyalGuard1MouthTalking.SetActive(false);
                tsSpritesManager.RoyalGuard2MouthMask.SetActive(false);
                tsSpritesManager.RoyalGuard2MouthTalking.SetActive(false);
                tsSpritesManager.RoyalGuard1Body.GetComponent<SpriteRenderer>().DOFade(0, .25f);
                tsSpritesManager.RoyalGuard2Body.GetComponent<SpriteRenderer>().DOFade(0, .25f);
                Invoke("Event47Delay", .75f);
                Invoke("Event47Delay2", 1.75f);
            }
            else
            {
                tsMainScript.Clickable = true;
                ProceedText(true, false);
            }
        }
        else if (EventID == 48)
        {
            tsMainScript.DialogIndex = 49;
            tsSpritesManager.dialogBox.SetActive(true);
            tsSpritesManager.BackgroundUpdate("PonyvilleNight");
            if (!IsContinue)
            {
                tsMainScript.Clickable = false;
                tsSpritesManager.TwilightStandNormal.GetComponent<SpriteRenderer>().DOFade(0, 0f);
                tsSpritesManager.TwilightStandNormal.SetActive(true);
                tsSpritesManager.TwilightStandNormal.GetComponent<SpriteRenderer>().DOFade(1, .25f);
                Invoke("Event48Delay", .75f);
            }
            else
            {
                tsSpritesManager.TwilightStandNormal.SetActive(true);
                tsMainScript.Clickable = true;
                ProceedText(true, false);
            }
        }
        else if (EventID == 49)
        {
            tsMainScript.Clickable = true;
            tsMainScript.DialogIndex = 50;
            tsSpritesManager.dialogBox.SetActive(true);
            tsSpritesManager.BackgroundUpdate("PonyvilleNight");
            if (!IsContinue)
            {
                tsSpritesManager.TwilightStandNormal.SetActive(false);
            }
            tsSpritesManager.TwilightSitSad.SetActive(true);
            ProceedText(IsContinue, false);
        }
        else if (EventID == 50)
        {
            tsMainScript.Clickable = true;
            tsMainScript.DialogIndex = 51;
            tsSpritesManager.dialogBox.SetActive(true);
            tsSpritesManager.BackgroundUpdate("PonyvilleNight");
            tsSpritesManager.TwilightSitSad.SetActive(true);
            ProceedText(IsContinue, false);
        }
        else if (EventID == 51)
        {
            tsMainScript.Clickable = true;
            tsMainScript.DialogIndex = 52;
            tsSpritesManager.dialogBox.SetActive(true);
            tsSpritesManager.BackgroundUpdate("PonyvilleNight");
            tsSpritesManager.TwilightSitSad.SetActive(true);
            ProceedText(IsContinue, false);
        }
        else if (EventID == 52)
        {
            tsMainScript.Clickable = false;
            tsMainScript.DialogIndex = 53;
            tsSpritesManager.dialogBox.SetActive(true);
            tsSpritesManager.BackgroundUpdate("PonyvilleNight");
            ProceedText(false, false);
            Invoke("Event52Delay", 1.3f);
        }
        else if (EventID == 53)
        {
            tsMainScript.Clickable = true;
            tsMainScript.DialogIndex = 54;
            tsSpritesManager.dialogBox.SetActive(true);
            tsSpritesManager.BackgroundUpdate("PonyvilleNight");
            if (!IsContinue)
            {
                tsSpritesManager.TwilightSitSad.SetActive(false);
            }
            tsSpritesManager.TwilightStandNormal.SetActive(true);
            ProceedText(IsContinue, false);
        }
        else if (EventID == 54)
        {
            tsMainScript.Clickable = true;
            tsMainScript.DialogIndex = 55;
            tsSpritesManager.dialogBox.SetActive(true);
            tsSpritesManager.BackgroundUpdate("PonyvilleNight");
            tsSpritesManager.TwilightStandNormal.SetActive(true);
            ProceedText(IsContinue, false);
        }
        else if (EventID == 55)
        {
            tsMainScript.Clickable = true;
            tsMainScript.DialogIndex = 56;
            tsSpritesManager.dialogBox.SetActive(true);
            tsSpritesManager.BackgroundUpdate("PonyvilleNight");
            if (!IsContinue)
            {
                tsSpritesManager.TwilightStandNormal.SetActive(false);
            }
            tsSpritesManager.TwilightSitSad.SetActive(true);
            ProceedText(IsContinue, false);
        }
        else if (EventID == 56)
        {
            tsMainScript.Clickable = true;
            tsMainScript.DialogIndex = 57;
            tsSpritesManager.dialogBox.SetActive(true);
            tsSpritesManager.BackgroundUpdate("PonyvilleNight");
            tsSpritesManager.TwilightSitSad.SetActive(true);
            ProceedText(IsContinue, false);
        }
        else if (EventID == 57)
        {
            tsMainScript.Clickable = true;
            tsMainScript.DialogIndex = 58;
            tsSpritesManager.dialogBox.SetActive(true);
            tsSpritesManager.BackgroundUpdate("PonyvilleNight");
            tsSpritesManager.TwilightSitSad.SetActive(true);
            ProceedText(IsContinue, false);
        }
        else if (EventID == 58)
        {
            tsMainScript.Clickable = true;
            tsMainScript.DialogIndex = 59;
            tsSpritesManager.dialogBox.SetActive(true);
            tsSpritesManager.BackgroundUpdate("PonyvilleNight");
            tsSpritesManager.TwilightSitSad.SetActive(true);
            ProceedText(IsContinue, false);
        }
        else if (EventID == 59)
        {
            tsMainScript.Clickable = true;
            tsMainScript.DialogIndex = 60;
            tsSpritesManager.dialogBox.SetActive(true);
            tsSpritesManager.BackgroundUpdate("PonyvilleNight");
            tsSpritesManager.TwilightSitSad.SetActive(true);
            ProceedText(IsContinue, false);
        }
        else if (EventID == 60)
        {
            tsMainScript.Clickable = true;
            tsMainScript.DialogIndex = 61;
            tsSpritesManager.dialogBox.SetActive(true);
            tsSpritesManager.BackgroundUpdate("PonyvilleNight");
            tsSpritesManager.TwilightSitSad.SetActive(true);
            ProceedText(IsContinue, false);
        }
        else if (EventID == 61)
        {
            tsMainScript.Clickable = true;
            tsMainScript.DialogIndex = 62;
            tsSpritesManager.dialogBox.SetActive(true);
            tsSpritesManager.BackgroundUpdate("PonyvilleNight");
            {
                tsSpritesManager.TwilightSitSad.SetActive(false);
            }
            tsSpritesManager.TwilightStandHappy.SetActive(true);
            ProceedText(IsContinue, false);
        }
        else if (EventID == 62)
        {
            tsMainScript.Clickable = false;
            tsSpritesManager.dialogBox.SetActive(false);
            tsSpritesManager.PonyvilleNight.GetComponent<SpriteRenderer>().DOFade(0, 5f);
            tsSpritesManager.TwilightStandHappy.GetComponent<SpriteRenderer>().DOFade(0, 5f);
            Invoke("Event62Delay", 8f);
        }
        else if (EventID == 63)
        {
            tsMainScript.DialogIndex = 64;
            tsSpritesManager.NameTag.SetActive(false);
            tsSpritesManager.dialogBox.SetActive(true);
            tsSpritesManager.SpeechText.SetActive(false);
            tsSpritesManager.NewAreaText.SetActive(true);
            if (!IsContinue)
            {
                tsMainScript.Clickable = false;
                tsSpritesManager.PonyvilleNight.GetComponent<SpriteRenderer>().DOFade(0, 0f);
                Invoke("Event63Delay", .1f);
                Invoke("Event63Delay2", 1f);
            }
            else
            {
                tsMainScript.Clickable = true;
                tsSpritesManager.BackgroundUpdate("PonyvilleNight");
                ProceedText(true, false);
            }
        }
        else if (EventID == 64)
        {
            tsMainScript.DialogIndex = 65;
            tsSpritesManager.BackgroundUpdate("PonyvilleNight");
            if (!IsContinue)
            {
                tsMainScript.Clickable = false;
                tsSpritesManager.dialogBox.SetActive(false);
                tsSpritesManager.NameTag.SetActive(true);
                tsSpritesManager.SpeechText.SetActive(true);
                tsSpritesManager.NewAreaText.SetActive(false);
                tsSpritesManager.WhiteScreen.GetComponent<Image>().DOFade(0, 0);
                Invoke("Event64Delay", 1f);
                Invoke("Event64Delay2", 1.25f);
                Invoke("Event64Delay3", 1.5f);
            }
            else
            {
                tsMainScript.Clickable = true;
                tsSpritesManager.dialogBox.SetActive(true);
                tsSpritesManager.TwilightStandHappy.SetActive(true);
                ProceedText(true, false);
            }
        }
        else if (EventID == 65)
        {
            tsMainScript.Clickable = true;
            tsMainScript.DialogIndex = 66;
            tsSpritesManager.dialogBox.SetActive(true);
            tsSpritesManager.BackgroundUpdate("PonyvilleNight");
            if (!IsContinue)
            {
                tsSpritesManager.TwilightStandHappy.SetActive(false);
            }
            tsSpritesManager.TwilightStandNormal.SetActive(true);
            ProceedText(IsContinue, false);
        }
        else if (EventID == 66)
        {
            tsMainScript.Clickable = true;
            tsMainScript.DialogIndex = 67;
            tsSpritesManager.dialogBox.SetActive(true);
            tsSpritesManager.BackgroundUpdate("PonyvilleNight");
            if (!IsContinue)
            {
                tsSpritesManager.TwilightStandNormal.SetActive(false);
            }
            tsSpritesManager.TwilightStandHappy.SetActive(true);
            ProceedText(IsContinue, false);
        }
        else if (EventID == 67)
        {
            tsMainScript.Clickable = true;
            tsMainScript.DialogIndex = 68;
            tsSpritesManager.dialogBox.SetActive(true);
            tsSpritesManager.BackgroundUpdate("PonyvilleNight");
            tsSpritesManager.TwilightStandHappy.SetActive(true);
            ProceedText(IsContinue, false);
        }
        else if (EventID == 68)
        {
            tsMainScript.Clickable = true;
            tsMainScript.DialogIndex = 69;
            tsSpritesManager.dialogBox.SetActive(true);
            tsSpritesManager.BackgroundUpdate("PonyvilleNight");
            if (!IsContinue)
            {
                tsSpritesManager.TwilightStandHappy.SetActive(false);
            }
            tsSpritesManager.TwilightStandExplain.SetActive(true);
            ProceedText(IsContinue, false);
        }
        else if (EventID == 69)
        {
            tsMainScript.Clickable = true;
            tsMainScript.DialogIndex = 70;
            tsSpritesManager.dialogBox.SetActive(true);
            tsSpritesManager.BackgroundUpdate("PonyvilleNight");
            tsSpritesManager.TwilightStandExplain.SetActive(true);
            ProceedText(IsContinue, false);
        }
        else if (EventID == 70)
        {
            tsMainScript.Clickable = true;
            tsMainScript.DialogIndex = 71;
            tsSpritesManager.dialogBox.SetActive(true);
            tsSpritesManager.BackgroundUpdate("PonyvilleNight");
            if (!IsContinue)
            {
                tsSpritesManager.TwilightStandExplain.SetActive(false);
            }
            tsSpritesManager.TwilightStandHappy.SetActive(true);
            ProceedText(IsContinue, false);
        }
        else if (EventID == 71)
        {
            tsMainScript.Clickable = true;
            tsMainScript.DialogIndex = 72;
            tsSpritesManager.dialogBox.SetActive(true);
            tsSpritesManager.BackgroundUpdate("PonyvilleNight");
            tsSpritesManager.TwilightStandHappy.SetActive(true);
            ProceedText(IsContinue, false);
        }
        else if (EventID == 72)
        {
            tsMainScript.Clickable = true;
            tsMainScript.DialogIndex = 73;
            tsSpritesManager.dialogBox.SetActive(true);
            tsSpritesManager.BackgroundUpdate("PonyvilleNight");
            tsSpritesManager.TwilightStandHappy.SetActive(true);
            ProceedText(IsContinue, false);
        }
        else if (EventID == 73)
        {
            tsMainScript.Clickable = true;
            tsMainScript.DialogIndex = 74;
            tsSpritesManager.dialogBox.SetActive(true);
            tsSpritesManager.BackgroundUpdate("PonyvilleNight");
            if (!IsContinue)
            {
                tsSpritesManager.TwilightStandHappy.SetActive(false);
            }
            tsSpritesManager.TwilightStandNormal.SetActive(true);
            ProceedText(IsContinue, false);
        }
        else if (EventID == 74)
        {
            tsMainScript.Clickable = true;
            tsMainScript.DialogIndex = 75;
            tsSpritesManager.dialogBox.SetActive(true);
            tsSpritesManager.BackgroundUpdate("PonyvilleNight");
            if (!IsContinue)
            {
                tsSpritesManager.TwilightStandNormal.SetActive(false);
            }
            tsSpritesManager.TwilightSitSad.SetActive(true);
            ProceedText(IsContinue, false);
        }
        else if (EventID == 75)
        {
            tsMainScript.Clickable = true;
            tsMainScript.DialogIndex = 76;
            tsSpritesManager.dialogBox.SetActive(true);
            tsSpritesManager.BackgroundUpdate("PonyvilleNight");
            tsSpritesManager.TwilightSitSad.SetActive(true);
            ProceedText(IsContinue, false);
        }
        else if (EventID == 76)
        {
            tsMainScript.Clickable = true;
            tsMainScript.DialogIndex = 77;
            tsSpritesManager.dialogBox.SetActive(true);
            tsSpritesManager.BackgroundUpdate("PonyvilleNight");
            if (!IsContinue)
            {
                tsSpritesManager.TwilightSitSad.SetActive(false);
            }
            tsSpritesManager.TwilightStandNormal.SetActive(true);
            ProceedText(IsContinue, false);
        }
        else if (EventID == 77)
        {
            tsMainScript.DialogIndex = 78;
            tsSpritesManager.dialogBox.SetActive(true);
            tsSpritesManager.BackgroundUpdate("PonyvilleNight");
            if (!IsContinue)
            {
                tsMainScript.Clickable = false;
                tsSpritesManager.WhiteScreen.GetComponent<Image>().DOFade(0, 0);
                tsSpritesManager.WhiteScreen.SetActive(true);
                tsSpritesManager.WhiteScreen.GetComponent<Image>().DOFade(1, .25f);
                Invoke("Event77Delay", .25f);
                Invoke("Event77Delay2", .5f);
            }
            else
            {
                tsMainScript.Clickable = true;
                tsSpritesManager.TwilightStandWhat.SetActive(true);
                ProceedText(true, false);
            }
        }
        else if (EventID == 78)
        {
            tsMainScript.Clickable = true;
            tsMainScript.DialogIndex = 79;
            tsSpritesManager.dialogBox.SetActive(true);
            tsSpritesManager.BackgroundUpdate("PonyvilleNight");
            if (!IsContinue)
            {
                tsSpritesManager.TwilightStandWhat.SetActive(false);
                Invoke("Event78Delay", .5f);
            }
            else
            {
                AudioManager.Instance.PlayBGM(BGMID.The_Class_Trial);
            }
            tsSpritesManager.TwilightStandNormal.SetActive(true);
            ProceedText(IsContinue, false);
        }
        else if (EventID == 79)
        {
            tsMainScript.DialogIndex = 80;
            tsSpritesManager.dialogBox.SetActive(true);
            AudioManager.Instance.PlayBGM(BGMID.The_Class_Trial);
            if (!IsContinue)
            {
                tsMainScript.Clickable = false;
                tsSpritesManager.blackScreen.DOFade(0, 0);
                tsSpritesManager.blackScreen.gameObject.SetActive(true);
                tsSpritesManager.blackScreen.DOFade(1, .5f);
                Invoke("Event79Delay", 1f);
            }
            else
            {
                tsSpritesManager.blackScreen.gameObject.SetActive(true);
                ProceedText(true, false);
            }
        }
        else if (EventID == 80)
        {
            tsMainScript.Clickable = true;
            tsMainScript.DialogIndex = 81;
            tsSpritesManager.dialogBox.SetActive(true);
            AudioManager.Instance.PlayBGM(BGMID.The_Class_Trial);
            tsSpritesManager.BackgroundUpdate("TheClassTrial");
            ProceedText(IsContinue, false);
            if (!IsContinue)
            {
                Invoke("Event80Delay", 1f);
                Invoke("Event80Delay2", 2f);
            }
        }
        else if (EventID == 81)
        {
            tsMainScript.Clickable = true;
            tsMainScript.DialogIndex = 82;
            tsSpritesManager.dialogBox.SetActive(true);
            AudioManager.Instance.PlayBGM(BGMID.The_Class_Trial);
            tsSpritesManager.blackScreen.gameObject.SetActive(true);
            ProceedText(IsContinue, false);
        }
        else if (EventID == 82)
        {
            tsMainScript.Clickable = true;
            tsMainScript.DialogIndex = 83;
            tsSpritesManager.dialogBox.SetActive(true);
            AudioManager.Instance.PlayBGM(BGMID.The_Class_Trial);
            if (!IsContinue)
            {
                tsSpritesManager.theClassTrialPhoenix.DOFade(0, 0);
                tsSpritesManager.theClassTrialPhoenix.gameObject.SetActive(true);
                tsSpritesManager.theClassTrialPhoenix.DOFade(1, 1f);
                Invoke("Event82Delay", 1f);
            }
            else
            {
                tsSpritesManager.BackgroundUpdate("TheClassTrialPhoenix");
            }
            ProceedText(IsContinue, false);
        }
        else if (EventID == 83)
        {
            tsMainScript.DialogIndex = 84;
            tsSpritesManager.dialogBox.SetActive(true);
            AudioManager.Instance.PlayBGM(BGMID.The_Class_Trial);
            if (!IsContinue)
            {
                tsSpritesManager.blackScreen.DOFade(0, 0);
                tsMainScript.Clickable = false;
                Invoke("Event83Delay", 1f);
                Invoke("Event83Delay2", 1.51f);
            }
            else
            {
                tsMainScript.Clickable = true;
                tsSpritesManager.blackScreen.gameObject.SetActive(true);
            }
            ProceedText(IsContinue, false);
        }
        else if (EventID == 84)
        {
            tsMainScript.DialogIndex = 85;
            AudioManager.Instance.PlayBGM(BGMID.The_Class_Trial);
            tsSpritesManager.BackgroundUpdate("OldCourtroomExamine");
            tsSpritesManager.DahliaImpatient.SetActive(true);
            tsSpritesManager.oldCourtroomExamineTable.gameObject.SetActive(true);
            if (!IsContinue)
            {
                tsMainScript.Clickable = false;
                tsSpritesManager.dialogBox.SetActive(false);
                tsSpritesManager.blackScreen.DOFade(0, 2f);
                Invoke("Event84Delay", 2.01f);
            }
            else
            {
                tsMainScript.Clickable = true;
                tsSpritesManager.dialogBox.SetActive(true);
                ProceedText(true, false);
            }
        }
        else if (EventID == 85)
        {
            tsMainScript.DialogIndex = 86;
            tsSpritesManager.dialogBox.SetActive(true);
            tsSpritesManager.BackgroundUpdate("OldCourtroomExamine");
            tsSpritesManager.oldCourtroomExamineTable.gameObject.SetActive(true);
            ProceedText(IsContinue, false);
            if (!IsContinue)
            {
                tsMainScript.Clickable = false;
                Invoke("Event85Delay", 1f);
                Invoke("Event85Delay2", 2f);
                Invoke("Event85Delay3", 4.09f);
            }
            else
            {
                tsMainScript.Clickable = true;
                tsSpritesManager.dialogBox.SetActive(true);
                tsSpritesManager.DahliaImpatient.SetActive(true);
            }
        }
        else if (EventID == 86)
        {
            tsMainScript.DialogIndex = 87;
            if (!IsContinue)
            {
                tsMainScript.Clickable = false;
                tsSpritesManager.dialogBox.SetActive(false);
                tsSpritesManager.blackScreen.DOFade(0, 0);
                tsSpritesManager.blackScreen.gameObject.SetActive(true);
                tsSpritesManager.blackScreen.DOFade(1, 1f);
                Invoke("Event86Delay", 2f);
                Invoke("Event86Delay2", 2.5f);
                Invoke("Event86Delay3", 3.5f);
            }
            else
            {
                tsMainScript.Clickable = true;
                tsSpritesManager.dialogBox.SetActive(true);
                tsSpritesManager.BackgroundUpdate("TheClassTrialEdgeworth");
                AudioManager.Instance.PlayBGM(BGMID.Turnabout_Sisters_Ballad);
                tsSpritesManager.dialogBox.SetActive(true);
                ProceedText(true, false);
            }
        }
        else if (EventID == 87)
        {
            tsMainScript.Clickable = true;
            tsMainScript.DialogIndex = 88;
            tsSpritesManager.dialogBox.SetActive(true);
            tsSpritesManager.BackgroundUpdate("TheClassTrialEdgeworth");
            AudioManager.Instance.PlayBGM(BGMID.Turnabout_Sisters_Ballad);
            ProceedText(IsContinue, false);
        }
        else if (EventID == 88)
        {
            tsMainScript.Clickable = true;
            tsMainScript.DialogIndex = 89;
            tsSpritesManager.dialogBox.SetActive(true);
            tsSpritesManager.BackgroundUpdate("TheClassTrialEdgeworth");
            AudioManager.Instance.PlayBGM(BGMID.Turnabout_Sisters_Ballad);
            ProceedText(IsContinue, false);
        }
        else if (EventID == 89)
        {
            tsMainScript.DialogIndex = 90;
            AudioManager.Instance.PlayBGM(BGMID.Turnabout_Sisters_Ballad);
            if (!IsContinue)
            {
                tsMainScript.Clickable = false;
                tsSpritesManager.dialogBox.SetActive(false);
                tsSpritesManager.blackScreen.DOFade(0, 0);
                tsSpritesManager.blackScreen.gameObject.SetActive(true);
                tsSpritesManager.blackScreen.DOFade(1, 2f);
                Invoke("Event89Delay", 3f);
                Invoke("Event89Delay2", 5f);
            }
            else
            {
                tsMainScript.Clickable = true;
                tsSpritesManager.dialogBox.SetActive(true);
                tsSpritesManager.BackgroundUpdate("OldCourtroomDefense");
                tsSpritesManager.oldCourtroomDefenseTable.gameObject.SetActive(true);
                tsSpritesManager.miaCourtHandsOnDesk.gameObject.SetActive(true);
                ProceedText(true, false);
            }
        }
        else if (EventID == 90)
        {
            tsMainScript.Clickable = true;
            tsMainScript.DialogIndex = 91;
            tsSpritesManager.dialogBox.SetActive(true);
            AudioManager.Instance.PlayBGM(BGMID.Turnabout_Sisters_Ballad);
            tsSpritesManager.BackgroundUpdate("OldCourtroomDefense");
            tsSpritesManager.oldCourtroomDefenseTable.gameObject.SetActive(true);
            tsSpritesManager.miaCourtHandsOnDesk.gameObject.SetActive(true);
            ProceedText(IsContinue, false);
        }
        else if (EventID == 91)
        {
            tsMainScript.DialogIndex = 92;
            tsSpritesManager.dialogBox.SetActive(true);
            AudioManager.Instance.PlayBGM(BGMID.Turnabout_Sisters_Ballad);
            tsSpritesManager.edgeworthPleased.GetComponent<Transform>().DOLocalMoveX(-4.3f, 0);
            tsSpritesManager.mayaGiggle.GetComponent<Transform>().DOLocalMoveX(5.7f, 0);
            tsSpritesManager.miaNormal.GetComponent<Transform>().DOLocalMoveZ(-1, 0);
            if (!IsContinue)
            {
                tsMainScript.Clickable = false;
                tsSpritesManager.blackScreen.DOFade(0, 0);
                tsSpritesManager.blackScreen.gameObject.SetActive(true);
                tsSpritesManager.blackScreen.DOFade(1, 1f);
                SpriteRenderer[] spriteRenderers = tsSpritesManager.edgeworthPleased.GetComponentsInChildren<SpriteRenderer>();
                foreach (SpriteRenderer child in spriteRenderers)
                {
                    child.DOColor(new Color32(255, 255, 255, 0), 0);
                }
                SpriteRenderer[] spriteRenderers2 = tsSpritesManager.mayaGiggle.GetComponentsInChildren<SpriteRenderer>();
                foreach (SpriteRenderer child in spriteRenderers2)
                {
                    child.DOColor(new Color32(255, 255, 255, 0), 0);
                }
                SpriteRenderer[] spriteRenderers3 = tsSpritesManager.miaNormal.GetComponentsInChildren<SpriteRenderer>();
                foreach (SpriteRenderer child in spriteRenderers3)
                {
                    child.DOColor(new Color32(255, 255, 255, 0), 0);
                }
                Invoke("Event91Delay", 1.5f);
                Invoke("Event91Delay2", 3f);
                Invoke("Event91Delay3", 4.5f);
                Invoke("Event91Delay4", 5f);
            }
            else
            {
                tsSpritesManager.edgeworthPleased.SetActive(true);
                tsSpritesManager.mayaGiggle.SetActive(true);
                tsSpritesManager.miaNormal.SetActive(true);
            }
            ProceedText(IsContinue, false);
        }
        else if (EventID == 92)
        {
            tsMainScript.DialogIndex = 93;
            if (!IsContinue)
            {
                tsMainScript.Clickable = false;
                tsMainScript.dialogBox.SetActive(false);
                tsSpritesManager.blackScreen.DOFade(0, 0);
                tsSpritesManager.blackScreen.gameObject.SetActive(true);
                tsSpritesManager.blackScreen.DOFade(1, 1f);
                Invoke("Event92Delay", 1f);
                Invoke("Event92Delay2", 3f);
                Invoke("Event92Delay3", 4f);
            }
            else
            {
                tsMainScript.Clickable = true;
                tsSpritesManager.dialogBox.SetActive(true);
                tsSpritesManager.BackgroundUpdate("PonyvilleNight");
                tsSpritesManager.twilightStandSmile.gameObject.SetActive(true);
                ProceedText(true, false);
            }
        }
        else if (EventID == 93)
        {
            tsMainScript.Clickable = true;
            tsMainScript.dialogBox.SetActive(true);
            tsMainScript.DialogIndex = 94;
            tsSpritesManager.BackgroundUpdate("PonyvilleNight");
            if (!IsContinue)
            {
                tsSpritesManager.twilightStandSmile.gameObject.SetActive(false);
            }
            tsSpritesManager.TwilightStandExplain.SetActive(true);
            ProceedText(IsContinue, false);
        }
        else if (EventID == 94)
        {
            tsMainScript.Clickable = true;
            tsMainScript.dialogBox.SetActive(true);
            tsMainScript.DialogIndex = 95;
            tsSpritesManager.BackgroundUpdate("PonyvilleNight");
            if (!IsContinue)
            {
                tsSpritesManager.TwilightStandExplain.SetActive(false);
            }
            tsSpritesManager.TwilightStandHappy.SetActive(true);
            ProceedText(IsContinue, false);
        }
        else if (EventID == 95)
        {
            tsMainScript.Clickable = true;
            tsMainScript.dialogBox.SetActive(true);
            tsMainScript.DialogIndex = 96;
            tsSpritesManager.BackgroundUpdate("PonyvilleNight");
            tsSpritesManager.TwilightStandHappy.SetActive(true);
            ProceedText(IsContinue, false);
        }
        else if (EventID == 96)
        {
            tsMainScript.Clickable = true;
            tsMainScript.dialogBox.SetActive(true);
            tsMainScript.DialogIndex = 97;
            tsSpritesManager.BackgroundUpdate("PonyvilleNight");
            if (!IsContinue)
            {
                tsSpritesManager.TwilightStandHappy.SetActive(false);
            }
            tsSpritesManager.TwilightStandNormal.SetActive(true);
            ProceedText(IsContinue, false);
        }
        else if (EventID == 97)
        {
            tsMainScript.Clickable = true;
            tsMainScript.dialogBox.SetActive(true);
            tsMainScript.DialogIndex = 98;
            tsSpritesManager.BackgroundUpdate("PonyvilleNight");
            tsSpritesManager.TwilightStandNormal.SetActive(true);
            ProceedText(IsContinue, false);
        }
        else if (EventID == 98)
        {
            tsMainScript.Clickable = true;
            tsMainScript.dialogBox.SetActive(true);
            tsMainScript.DialogIndex = 99;
            tsSpritesManager.BackgroundUpdate("PonyvilleNight");
            if (!IsContinue)
            {
                tsSpritesManager.TwilightStandNormal.SetActive(false);
            }
            tsSpritesManager.TwilightStandConfused.SetActive(true);
            ProceedText(IsContinue, false);
        }
        else if (EventID == 99)
        {
            tsMainScript.Clickable = true;
            tsMainScript.dialogBox.SetActive(true);
            tsMainScript.DialogIndex = 100;
            tsSpritesManager.BackgroundUpdate("PonyvilleNight");
            if (!IsContinue)
            {
                tsSpritesManager.TwilightStandConfused.SetActive(false);
            }
            tsSpritesManager.TwilightStandHappy.SetActive(true);
            ProceedText(IsContinue, false);
        }
        else if (EventID == 100)
        {
            tsMainScript.Clickable = true;
            tsMainScript.dialogBox.SetActive(true);
            tsMainScript.DialogIndex = 101;
            tsSpritesManager.BackgroundUpdate("PonyvilleNight");
            tsSpritesManager.TwilightStandHappy.SetActive(true);
            ProceedText(IsContinue, false);
        }
        else if (EventID == 101)
        {
            tsMainScript.Clickable = true;
            tsMainScript.dialogBox.SetActive(true);
            tsMainScript.DialogIndex = 102;
            tsSpritesManager.BackgroundUpdate("PonyvilleNight");
            if (!IsContinue)
            {
                tsSpritesManager.TwilightStandHappy.SetActive(false);
            }
            tsSpritesManager.TwilightStandExplain.SetActive(true);
            ProceedText(IsContinue, false);
        }
        else if (EventID == 102)
        {
            tsMainScript.Clickable = true;
            tsMainScript.dialogBox.SetActive(true);
            tsMainScript.DialogIndex = 103;
            tsSpritesManager.BackgroundUpdate("PonyvilleNight");
            tsSpritesManager.TwilightStandExplain.SetActive(true);
            ProceedText(IsContinue, false);
        }
        else if (EventID == 103)
        {
            tsMainScript.Clickable = false;
            tsSpritesManager.dialogBox.SetActive(false);
            tsSpritesManager.blackScreen.DOFade(0, 0);
            tsSpritesManager.blackScreen.gameObject.SetActive(true);
            tsSpritesManager.blackScreen.DOFade(1, 5f);
            Invoke("Event103Delay", 7.5f);
        }
        else
        {
            tsMainScript.EventID -= 1;
            Debug.Log("EventID " + EventID + "无对应事件。");
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
    public void Event0Delay()
    {
        tsSpritesManager.BackgroundUpdate("PonyvilleNight");
        tsSpritesManager.PonyvilleNight.GetComponent<SpriteRenderer>().DOFade(1, .5f);
    }
    public void Event0Delay2()
    {
        ProceedText(false, false);
        tsMainScript.Clickable = true;
    }
    public void Event2Delay()
    {
        tsSpritesManager.TwilightStandNormal.SetActive(true);
        tsSpritesManager.TwilightStandNormal.GetComponent<SpriteRenderer>().DOFade(1, .5f);
    }
    public void Event2Delay2()
    {
        tsMainScript.Clickable = true;
        tsSpritesManager.TwilightStandNormal.SetActive(false);
        tsSpritesManager.TwilightStandConfused.SetActive(true);
        ProceedText(false, false);
    }
    public void Event15Delay()
    {
        tsSpritesManager.TwilightStandNormal.SetActive(false);
        tsSpritesManager.TwilightStandNormal.GetComponent<SpriteRenderer>().DOFade(1, 0f);
        tsSpritesManager.RoyalGuard1Body.SetActive(true);
        tsSpritesManager.RoyalGuard2Body.SetActive(true);
        tsSpritesManager.RoyalGuard1Body.GetComponent<SpriteRenderer>().DOFade(1, .25f);
        tsSpritesManager.RoyalGuard2Body.GetComponent<SpriteRenderer>().DOFade(1, .25f);
        tsSpritesManager.RoyalGuard1MouthMask.SetActive(true);
        tsSpritesManager.RoyalGuard1MouthTalking.SetActive(true);
    }
    public void Event15Delay2()
    {
        tsMainScript.Clickable = true;
        ProceedText(false, false);
    }
    public void Event16Delay()
    {
        tsSpritesManager.RoyalGuard1Body.SetActive(false);
        tsSpritesManager.RoyalGuard2Body.SetActive(false);
        tsSpritesManager.RoyalGuard1Body.GetComponent<SpriteRenderer>().DOFade(1, 0f);
        tsSpritesManager.RoyalGuard2Body.GetComponent<SpriteRenderer>().DOFade(1, 0f);
        tsSpritesManager.TwilightStandNormal.SetActive(true);
        tsSpritesManager.TwilightStandNormal.GetComponent<SpriteRenderer>().DOFade(1, .25f);
    }
    public void Event16Delay2()
    {
        tsSpritesManager.TwilightStandNormal.SetActive(false);
        tsSpritesManager.TwilightStandConfused.SetActive(true);
        tsMainScript.Clickable = true;
        ProceedText(false, false);
    }
    public void Event17Delay()
    {
        tsSpritesManager.TwilightStandConfused.SetActive(false);
        tsSpritesManager.TwilightStandConfused.GetComponent<SpriteRenderer>().DOFade(1, 0);
        tsSpritesManager.RoyalGuard1Body.SetActive(true);
        tsSpritesManager.RoyalGuard2Body.SetActive(true);
        tsSpritesManager.RoyalGuard1Body.GetComponent<SpriteRenderer>().DOFade(1, .25f);
        tsSpritesManager.RoyalGuard2Body.GetComponent<SpriteRenderer>().DOFade(1, .25f);
    }
    public void Event17Delay2()
    {
        tsMainScript.Clickable = true;
        ProceedText(false, false);
    }
    public void Event19Delay()
    {
        tsSpritesManager.ItemHolder.SetActive(true);
        tsSpritesManager.AttorneyBadge.SetActive(true);
        AudioManager.Instance.PlaySE(SEID.item_pop);
    }
    public void Event19Delay2()
    {
        tsMainScript.Clickable = true;
    }
    public void Event24Delay()
    {
        tsSpritesManager.RoyalGuard1MouthMask.SetActive(true);
        tsSpritesManager.RoyalGuard1MouthTalking.SetActive(true);
        tsSpritesManager.ItemHolder.SetActive(false);
        tsSpritesManager.AttorneyBadge.SetActive(false);
        tsMainScript.Clickable = true;
        ProceedText(false, false);
    }
    public void Event27Delay()
    {
        tsSpritesManager.RoyalGuard1Body.SetActive(false);
        tsSpritesManager.RoyalGuard2Body.SetActive(false);
        tsSpritesManager.RoyalGuard1Body.GetComponent<SpriteRenderer>().DOFade(1, 0f);
        tsSpritesManager.RoyalGuard2Body.GetComponent<SpriteRenderer>().DOFade(1, 0f);
        tsSpritesManager.TwilightStandNormal.SetActive(true);
        tsSpritesManager.TwilightStandNormal.GetComponent<SpriteRenderer>().DOFade(1, .25f);
    }
    public void Event27Delay2()
    {
        tsMainScript.Clickable = true;
        ProceedText(false, false);
    }
    public void Event29Delay()
    {
        tsMainScript.Clickable = true;
        ProceedText(false, false);
    }
    public void Event44Delay()
    {
        tsSpritesManager.TwilightStandImpatient.SetActive(false);
        tsSpritesManager.TwilightStandImpatient.GetComponent<SpriteRenderer>().DOFade(1, 0f);
        tsSpritesManager.RoyalGuard1Body.SetActive(true);
        tsSpritesManager.RoyalGuard2Body.SetActive(true);
        tsSpritesManager.RoyalGuard1Body.GetComponent<SpriteRenderer>().DOFade(1, .25f);
        tsSpritesManager.RoyalGuard2Body.GetComponent<SpriteRenderer>().DOFade(1, .25f);
    }
    public void Event44Delay2()
    {
        ProceedText(false, false);
    }
    public void Event44Delay3()
    {
        AudioManager.Instance.PlaySE(SEID.item_pop);
        tsSpritesManager.EquestrianAttorneyBadge.SetActive(true);
        tsSpritesManager.ItemHolder.SetActive(true);
    }
    public void Event44Delay4()
    {
        tsMainScript.Clickable = true;
    }
    public void Event47Delay()
    {
        tsSpritesManager.RoyalGuard1Body.SetActive(false);
        tsSpritesManager.RoyalGuard2Body.SetActive(false);
        tsSpritesManager.RoyalGuard1Body.GetComponent<SpriteRenderer>().DOFade(1, 0f);
        tsSpritesManager.RoyalGuard2Body.GetComponent<SpriteRenderer>().DOFade(1, 0f);
        AudioManager.Instance.PlaySE(SEID.se_com_008);
        tsSpritesManager.ItemHolder.GetComponent<RectTransform>().DOScale(new Vector3(0, 0, 0), .5f);
    }
    public void Event47Delay2()
    {
        tsSpritesManager.ItemHolder.SetActive(false);
        tsSpritesManager.EquestrianAttorneyBadge.SetActive(false);
        tsMainScript.Clickable = true;
        ProceedText(false, false);
    }
    public void Event48Delay()
    {
        tsMainScript.Clickable = true;
        ProceedText(false, false);
    }
    public void Event52Delay()
    {
        tsMainScript.EventID += 1;
        tsMainScript.Proceed = true;
    }
    public void Event62Delay()
    {
        tsSpritesManager.ClearAllBG();
        tsSpritesManager.TwilightStandHappy.SetActive(false);
        tsSpritesManager.PonyvilleNight.GetComponent<SpriteRenderer>().DOFade(1, 0f);
        tsSpritesManager.TwilightStandHappy.GetComponent<SpriteRenderer>().DOFade(1, 0f);
        tsMainScript.AreaID = 4;
        tsMainScript.EventID = 0;
        tsMainScript.ProceedGame(tsMainScript.ChapterID, tsMainScript.AreaID, false);
    }
    public void Event63Delay()
    {
        tsSpritesManager.BackgroundUpdate("PonyvilleNight");
        tsSpritesManager.PonyvilleNight.GetComponent<SpriteRenderer>().DOFade(1, .5f);
    }
    public void Event63Delay2()
    {
        ProceedText(false, false);
        tsMainScript.Clickable = true;
    }
    public void Event64Delay()
    {
        tsSpritesManager.WhiteScreen.SetActive(true);
        tsSpritesManager.WhiteScreen.GetComponent<Image>().DOFade(1, .25f);
    }
    public void Event64Delay2()
    {
        AudioManager.Instance.PlaySE(SEID.se_script_011);
        tsSpritesManager.WhiteScreen.GetComponent<Image>().DOFade(0, .25f);
        tsSpritesManager.dialogBox.SetActive(true);
        ProceedText(false, false);
        tsMainScript.Clickable = true;
        tsSpritesManager.TwilightStandHappy.SetActive(true);
    }
    public void Event64Delay3()
    {
        tsSpritesManager.WhiteScreen.SetActive(false);
        tsSpritesManager.WhiteScreen.GetComponent<Image>().DOFade(1, 0);
    }
    public void Event77Delay()
    {
        AudioManager.Instance.PlaySE(SEID.se_script_011);
        tsSpritesManager.TwilightStandNormal.SetActive(false);
        tsSpritesManager.TwilightStandWhat.SetActive(true);
        tsSpritesManager.WhiteScreen.GetComponent<Image>().DOFade(0, .25f);
        ProceedText(false, false);
        tsMainScript.Clickable = true;
    }
    public void Event77Delay2()
    {
        tsSpritesManager.WhiteScreen.SetActive(false);
        tsSpritesManager.WhiteScreen.GetComponent<Image>().DOFade(1, 0);
    }
    public void Event78Delay()
    {
        AudioManager.Instance.PlayBGM(BGMID.The_Class_Trial);
    }
    public void Event79Delay()
    {
        ProceedText(false, false);
        tsMainScript.Clickable = true;
        tsSpritesManager.TwilightStandNormal.SetActive(false);
        tsSpritesManager.ClearAllBG();
    }
    public void Event80Delay()
    {
        tsSpritesManager.blackScreen.DOFade(0, 1f);
    }
    public void Event81Delay()
    {
        tsSpritesManager.blackScreen.gameObject.SetActive(false);
        tsSpritesManager.blackScreen.DOFade(1, 0);
    }
    public void Event82Delay()
    {
        tsSpritesManager.theClassTrialPhoenix.gameObject.SetActive(false);
        tsSpritesManager.theClassTrialPhoenix.DOFade(1, 0);
        tsSpritesManager.BackgroundUpdate("TheClassTrialPhoenix");
    }
    public void Event83Delay()
    {
        tsSpritesManager.blackScreen.gameObject.SetActive(true);
        tsSpritesManager.blackScreen.DOFade(1, .5f);
    }
    public void Event83Delay2()
    {
        tsSpritesManager.ClearAllBG();
        tsMainScript.Clickable = true;
    }
    public void Event84Delay()
    {
        tsMainScript.Clickable = true;
        tsSpritesManager.dialogBox.SetActive(true);
        ProceedText(false, false);
        tsSpritesManager.blackScreen.gameObject.SetActive(false);
        tsSpritesManager.blackScreen.DOFade(1, 0);
    }
    public void Event85Delay()
    {
        AudioManager.Instance.StopBGM(true);
    }
    public void Event85Delay2()
    {
        tsSpritesManager.DahliaPullingHair.SetActive(true);
        tsSpritesManager.DahliaImpatient.SetActive(false);
    }
    public void Event85Delay3()
    {
        tsMainScript.Clickable = true;
        tsSpritesManager.DahliaPullingHair.SetActive(false);
        tsSpritesManager.DahliaImpatient.SetActive(true);
    }
    public void Event86Delay()
    {
        tsSpritesManager.oldCourtroomExamineTable.gameObject.SetActive(false);
        tsSpritesManager.DahliaImpatient.SetActive(false);
        tsSpritesManager.BackgroundUpdate("TheClassTrialEdgeworth");
        tsSpritesManager.blackScreen.DOFade(0, 1f);
    }
    public void Event86Delay2()
    {
        AudioManager.Instance.PlayBGM(BGMID.Turnabout_Sisters_Ballad);
    }
    public void Event86Delay3()
    {
        tsMainScript.Clickable = true;
        tsSpritesManager.dialogBox.SetActive(true);
        tsSpritesManager.blackScreen.gameObject.SetActive(false);
        tsSpritesManager.blackScreen.DOFade(1, 0);
        ProceedText(false, false);
    }
    public void Event89Delay()
    {
        tsSpritesManager.blackScreen.DOFade(0, 2f);
        tsSpritesManager.BackgroundUpdate("OldCourtroomDefense");
        tsSpritesManager.oldCourtroomDefenseTable.gameObject.SetActive(true);
        tsSpritesManager.miaCourtHandsOnDesk.SetActive(true);
    }
    public void Event89Delay2()
    {
        tsSpritesManager.blackScreen.gameObject.SetActive(false);
        tsSpritesManager.blackScreen.DOFade(1, 0);
        tsMainScript.Clickable = true;
        tsSpritesManager.dialogBox.SetActive(true);
        ProceedText(false, false);
    }
    public void Event91Delay()
    {
        tsSpritesManager.ClearAllBG();
        tsSpritesManager.oldCourtroomDefenseTable.gameObject.SetActive(false);
        tsSpritesManager.miaCourtHandsOnDesk.SetActive(false);
        tsSpritesManager.blackScreen.gameObject.SetActive(false);
        tsSpritesManager.edgeworthPleased.SetActive(true);
        SpriteRenderer[] spriteRenderers = tsSpritesManager.edgeworthPleased.GetComponentsInChildren<SpriteRenderer>();
        foreach (SpriteRenderer child in spriteRenderers)
        {
            child.DOColor(new Color32(255, 255, 255, 255), .5f);
        }
    }
    public void Event91Delay2()
    {
        tsSpritesManager.mayaGiggle.SetActive(true);
        SpriteRenderer[] spriteRenderers = tsSpritesManager.mayaGiggle.GetComponentsInChildren<SpriteRenderer>();
        foreach (SpriteRenderer child in spriteRenderers)
        {
            child.DOColor(new Color32(255, 255, 255, 255), .5f);
        }
    }
    public void Event91Delay3()
    {
        tsSpritesManager.miaNormal.SetActive(true);
        SpriteRenderer[] spriteRenderers = tsSpritesManager.miaNormal.GetComponentsInChildren<SpriteRenderer>();
        foreach (SpriteRenderer child in spriteRenderers)
        {
            child.DOColor(new Color32(255, 255, 255, 255), .5f);
        }
    }
    public void Event91Delay4()
    {
        tsMainScript.Clickable = true;
    }
    public void Event92Delay()
    {
        AudioManager.Instance.StopBGM(true);
    }
    public void Event92Delay2()
    {
        tsSpritesManager.edgeworthPleased.SetActive(false);
        tsSpritesManager.mayaGiggle.SetActive(false);
        tsSpritesManager.miaNormal.SetActive(false);
        tsSpritesManager.BackgroundUpdate("PonyvilleNight");
        tsSpritesManager.twilightStandSmile.gameObject.SetActive(true);
        tsSpritesManager.blackScreen.DOFade(0, 1f);
    }
    public void Event92Delay3()
    {
        tsSpritesManager.blackScreen.gameObject.SetActive(false);
        tsSpritesManager.blackScreen.DOFade(1, 0);
        tsMainScript.Clickable = true;
        tsMainScript.dialogBox.SetActive(true);
        ProceedText(false, false);
    }
    public void Event103Delay()
    {
        tsSpritesManager.ClearAllBG();
        tsSpritesManager.TwilightStandExplain.SetActive(false);
        tsSpritesManager.PonyvilleNight.GetComponent<SpriteRenderer>().DOFade(1, 0f);
        tsSpritesManager.TwilightStandExplain.GetComponent<SpriteRenderer>().DOFade(1, 0f);
        tsMainScript.AreaID = 5;
        tsMainScript.EventID = 0;
        tsMainScript.ProceedGame(tsMainScript.ChapterID, tsMainScript.AreaID, false);
    }
}
