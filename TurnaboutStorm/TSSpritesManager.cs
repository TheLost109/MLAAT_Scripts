using DG.Tweening;
using UnityEngine;

public class TSSpritesManager : MonoBehaviour
{
    [Header("逆转风暴基础脚本")]
    public TSMainScript tsMainScript;

    [Header("游戏对话框")]
    // 对话框
    public GameObject dialogBox;
    // 对话框上方名称标签
    public GameObject NameTag;
    // 对话文本
    public GameObject SpeechText;
    // 区域介绍文本
    public GameObject NewAreaText;

    [Header("游戏背景")]
    // 背景图片 - 纯黑
    public SpriteRenderer blackScreen;
    // 背景图片 - 纯白
    public GameObject WhiteScreen;
    // 背景图片 - 成步堂法律事务所
    public GameObject OfficeBG;
    // 背景图片 - 暮光的卧室
    public GameObject TwilightsBedroom;
    // 背景图片 - 小马镇夜晚
    public GameObject PonyvilleNight;
    // 背景图片 - 看守所
    public GameObject detentionCenter;
    // 背景图片 - 看守所 - 反色
    public SpriteRenderer detentionCenterInverted;
    // 背景图片 - 看守所窗口
    public GameObject detentionCenterOverlay;
    // 背景图片 - 看守所窗口 - 反色
    public SpriteRenderer detentionCenterOverlayInverted;
    // 学级裁判
    public SpriteRenderer theClassTrial;
    public SpriteRenderer theClassTrialPhoenix;
    public SpriteRenderer theClassTrialEdgeworth;
    // 4代及之前的旧法庭
    public SpriteRenderer oldCourtroomExamine;
    public SpriteRenderer oldCourtroomExamineTable;
    public SpriteRenderer oldCourtroomDefense;
    public SpriteRenderer oldCourtroomDefenseTable;
    // 背景图片 - 小蝶家
    public SpriteRenderer fluttershysCottage;
    // 背景图片 - 永恒之森案发地点
    public SpriteRenderer everfreecrimeScene;

    [Header("证物相关")]
    // 证物弹出窗口
    public GameObject ItemHolder;
    // 证物图片 - 成步堂的手机
    public GameObject WrightPhoneSpr;
    // 证物图片 - 律师徽章
    public GameObject AttorneyBadge;
    // 证物图片 - 勾玉
    public GameObject Magatama;
    // 证物图片 - 给小小马驹的小马指南
    public GameObject TheFilliesGuideToPonies;
    // 证物图片 - 小马国律师徽章
    public GameObject EquestrianAttorneyBadge;
    // 证物图片 - 烧焦的东西
    public GameObject burntObject;
    // 证物图片 - 棕色羽毛
    public GameObject brownFeather;

    [Header("所有精灵")]
    public Transform allSpritesObj;
    public Transform twilightAllSprObj;

    [Header("精灵 暮光闪闪")]
    // 普通站立、开心站立、困惑站立、恐慌站立、Oops坐下、解释站立、吓我一跳站立、What站立、难过坐下、害怕站立、不耐烦站立、微笑站立
    public GameObject TwilightStandNormal;
    public GameObject TwilightStandHappy;
    public GameObject TwilightStandConfused;
    public GameObject TwilightStandPanic;
    public GameObject TwilightSitOops;
    public GameObject TwilightStandExplain;
    public GameObject TwilightStandStartled;
    public GameObject TwilightStandWhat;
    public GameObject TwilightSitSad;
    public GameObject TwilightStandScared;
    public GameObject TwilightStandImpatient;
    public SpriteRenderer twilightStandSmile;
    public SpriteRenderer twilightStandHey;
    public SpriteRenderer twilightStandOMG;
    public SpriteRenderer twilightMagicAura;

    [Header("精灵 皇家卫兵")]
    public GameObject RoyalGuard1Body;
    public GameObject RoyalGuard1MouthMask;
    public GameObject RoyalGuard1MouthTalking;
    public GameObject RoyalGuard2Body;
    public GameObject RoyalGuard2MouthMask;
    public GameObject RoyalGuard2MouthTalking;

    [Header("精灵 云宝黛茜")]
    // 站立、愤怒
    public SpriteRenderer rainbowStandAngry;
    public SpriteRenderer rainbowStandNormal;
    public SpriteRenderer rainbowStandSmile;
    public SpriteRenderer rainbowStandImpatient;
    public SpriteRenderer rainbowStandProud;
    public SpriteRenderer rainbowStretchThinking;
    public SpriteRenderer rainbowStandAnnoyed;
    public SpriteRenderer rainbowSitDashface;
    public SpriteRenderer rainbowStandFacehoof;
    public SpriteRenderer rainbowStandDisturbed;
    public SpriteRenderer rainbowStandSorry;

    [Header("精灵 心灵枷锁")]
    // 铁链
    public GameObject PsyLockChainB1;
    public GameObject PsyLockChainB2;
    public GameObject PsyLockChainB5;
    public GameObject PsyLockChainB6;
    public GameObject PsyLockChainF2;
    public GameObject PsyLockChainF3;
    public GameObject PsyLockChainF4;
    public GameObject PsyLockChainF6;
    // 锁
    public SpriteRenderer PsyLock1;
    public SpriteRenderer PsyLock2;
    public SpriteRenderer PsyLock3;
    public SpriteRenderer PsyLock4;
    public SpriteRenderer PsyLock5;

    [Header("精灵 美柳千奈美")]
    // 不耐烦、撩头发
    public GameObject DahliaImpatient;
    public GameObject DahliaPullingHair;

    [Header("精灵 绫里千寻")]
    public GameObject miaCourtHandsOnDesk;
    public GameObject miaNormal;

    [Header("精灵 御剑伶侍")]
    public GameObject edgeworthPleased;

    [Header("精灵 绫里真宵")]
    public GameObject mayaGiggle;

    [Header("精灵 小蝶")]
    public SpriteRenderer fluttershyStandShocked;
    public SpriteRenderer fluttershyStandWorried;
    public SpriteRenderer fluttershySitScared;
    public SpriteRenderer fluttershyStandUmm;
    public SpriteRenderer fluttershyStandNormal;
    public SpriteRenderer fluttershyStandSurprised;
    public SpriteRenderer fluttershyStandSmile;
    public SpriteRenderer fluttershyStandWondering;
    public SpriteRenderer fluttershyStandGuessing;
    public SpriteRenderer fluttershyStandSoundsGood;
    public SpriteRenderer fluttershyStandOhMy;
    public SpriteRenderer fluttershyStandAhhh;

    void Start()
    {
        
    }

    void Update()
    {

    }
    public void BackgroundUpdate(string NewBG)
    {
        if (tsMainScript.CurrentBG != NewBG)
        {
            ClearAllBG();
            if (NewBG == "WrightOffice")
            {
                OfficeBG.SetActive(true);
            }
            else if (NewBG == "TwilightsBedroom")
            {
                TwilightsBedroom.SetActive(true);
            }
            else if (NewBG == "PonyvilleNight")
            {
                PonyvilleNight.SetActive(true);
            }
            else if (NewBG == "DetentionCenter")
            {
                detentionCenter.SetActive(true);
                detentionCenterOverlay.SetActive(true);
            }
            else if (NewBG == "TheClassTrial")
            {
                theClassTrial.gameObject.SetActive(true);
            }
            else if (NewBG == "TheClassTrialPhoenix")
            {
                theClassTrialPhoenix.gameObject.SetActive(true);
            }
            else if (NewBG == "TheClassTrialEdgeworth")
            {
                theClassTrialEdgeworth.gameObject.SetActive(true);
            }
            else if (NewBG == "OldCourtroomExamine")
            {
                oldCourtroomExamine.gameObject.SetActive(true);
            }
            else if (NewBG == "OldCourtroomDefense")
            {
                oldCourtroomDefense.gameObject.SetActive(true);
            }
            else if (NewBG == "FluttershysCottage")
            {
                fluttershysCottage.gameObject.SetActive(true);
            }
            else if (NewBG == "EverfreeCrimeScene")
            {
                everfreecrimeScene.gameObject.SetActive(true);
            }
            tsMainScript.CurrentBG = NewBG;
        }
    }
    public void ClearAllBG()
    {
        OfficeBG.SetActive(false);
        TwilightsBedroom.SetActive(false);
        PonyvilleNight.SetActive(false);
        detentionCenter.SetActive(false);
        detentionCenterOverlay.SetActive(false);
        theClassTrial.gameObject.SetActive(false);
        theClassTrialPhoenix.gameObject.SetActive(false);
        theClassTrialEdgeworth.gameObject.SetActive(false);
        oldCourtroomExamine.gameObject.SetActive(false);
        oldCourtroomDefense.gameObject.SetActive(false);
        fluttershysCottage.gameObject.SetActive(false);
        everfreecrimeScene.gameObject.SetActive(false);
        tsMainScript.CurrentBG = "";
    }
    public void ClrAllCharaSpr(string charaName)
    {
        if (charaName == "Twilight")
        {
            TwilightStandNormal.SetActive(false);
            TwilightStandHappy.SetActive(false);
            TwilightStandConfused.SetActive(false);
            TwilightStandPanic.SetActive(false);
            TwilightSitOops.SetActive(false);
            TwilightStandExplain.SetActive(false);
            TwilightStandStartled.SetActive(false);
            TwilightStandWhat.SetActive(false);
            TwilightSitSad.SetActive(false);
            TwilightStandScared.SetActive(false);
            TwilightStandImpatient.SetActive(false);
            twilightStandSmile.gameObject.SetActive(false);
            twilightStandHey.gameObject.SetActive(false);
            twilightStandOMG.gameObject.SetActive(false);
            twilightMagicAura.gameObject.SetActive(false);
        }
        else if (charaName == "RoyalGuard1")
        {
            RoyalGuard1Body.SetActive(false);
            RoyalGuard1MouthMask.SetActive(false);
            RoyalGuard1MouthTalking.SetActive(false);
        }
        else if (charaName == "RoyalGuard2")
        {
            RoyalGuard2Body.SetActive(false);
            RoyalGuard2MouthMask.SetActive(false);
            RoyalGuard2MouthTalking.SetActive(false);
        }
        else if (charaName == "Rainbow")
        {
            rainbowStandAngry.gameObject.SetActive(false);
            rainbowStandNormal.gameObject.SetActive(false);
            rainbowStandSmile.gameObject.SetActive(false);
            rainbowStandImpatient.gameObject.SetActive(false);
            rainbowStandProud.gameObject.SetActive(false);
            rainbowStretchThinking.gameObject.SetActive(false);
            rainbowStandAnnoyed.gameObject.SetActive(false);
            rainbowSitDashface.gameObject.SetActive(false);
            rainbowStandDisturbed.gameObject.SetActive(false);
            rainbowStandSorry.gameObject.SetActive(false);
        }
        else if (charaName == "Fluttershy")
        {
            fluttershyStandShocked.gameObject.SetActive(false);
            fluttershyStandWorried.gameObject.SetActive(false);
            fluttershySitScared.gameObject.SetActive(false);
            fluttershyStandUmm.gameObject.SetActive(false);
            fluttershyStandNormal.gameObject.SetActive(false);
            fluttershyStandSurprised.gameObject.SetActive(false);
            fluttershyStandSmile.gameObject.SetActive(false);
            fluttershyStandWondering.gameObject.SetActive(false);
            fluttershyStandGuessing.gameObject.SetActive(false);
            fluttershyStandSoundsGood.gameObject.SetActive(false);
            fluttershyStandOhMy.gameObject.SetActive(false);
            fluttershyStandAhhh.gameObject.SetActive(false);
        }
        else
        {
            Debug.LogError("没有指定的角色Sprite。");
        }
    }
    public void FadeAllCharaSpr(string charaName, bool show)
    {
        if (charaName == "Twilight")
        {
            SpriteRenderer[] spriteRenderers = twilightAllSprObj.GetComponentsInChildren<SpriteRenderer>();
            foreach (SpriteRenderer child in spriteRenderers)
            {
                if (show)
                {
                    child.DOFade(1, 1f);
                }
                else
                {
                    child.DOFade(0, 1f);
                }
            }
        }
        else
        {
            Debug.LogError("没有指定的角色Sprite。");
        }
    }
}