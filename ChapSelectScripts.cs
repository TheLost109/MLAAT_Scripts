using DG.Tweening;
using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ChapSelectScripts : MonoBehaviour
{
    [Header("场景Canvas")]
    public GameObject SceneCanvas;

    [Header("进场动画")]
    public GameObject EnterAnim;

    [Header("各游戏菜单和切换效果")]
    public GameObject TSPanel;
    public GameObject TSBeginObj;
    public GameObject TSBeginLogo;
    public GameObject MLIPanel;
    public GameObject EoJPanel;
    public GameObject MuseumPanel;
    public GameObject TransitionQ;
    public GameObject TransitionE;

    [Header("BGM名称显示")]
    public string BGMName = "None";
    public GameObject BGMNameArea;
    public TMP_Text BGMNameText;

    [Header("按钮交互动画")]
    public Vector4 BtnMaskPadding0;
    public Vector4 BtnMaskPadding441;
    public GameObject TSStartGameBtnMask;
    public GameObject TSContinueBtnMask;
    public GameObject TSEpisodesBtnMask;
    public GameObject MLIComingSoonBtnMask;
    public GameObject EoJComingSoonBtnMask;
    public GameObject OrchestraHallBtnMask;
    public GameObject ArtLibraryBtnMask;
    public GameObject AnimStudioBtnMask;

    [Header("底部导航")]
    public GameObject BottomNav;
    public GameObject BottomNavGrad;

    [Header("选择章节_菜单_小")]
    public GameObject Episodes;
    public GameObject EpisodesNavGrad;
    public GameObject EpisodesNav;
    public GameObject EpisodesTS;

    [Header("选择章节_菜单_大")]
    public CanvasGroup episodesMenu;
    public Image episodesMenuThumb;
    public RectTransform episodesMenuBGImg;
    public TextMeshProUGUI episodesMenuChapterNum;
    public RectTransform episodeBtnsContent;
    public EpisodeBtnPrefab episodeBtnPrefab;
    private List<EpisodeBtnPrefab> episodeBtnPrefabList = new List<EpisodeBtnPrefab>();
    public CanvasGroup episodeSelectedAlert;
    public TextMeshProUGUI episodeSelectedChapterNum;
    public TextMeshProUGUI episodeSelectedGameName;
    public TextMeshProUGUI episodeSelectedChapterName;
    public CanvasGroup episodeLoadSuccess;
    private int newEpisodeId = 0;
    private int newAreaId = 0;
    private int newEventId = 0;

    [Header("选择章节_缩略图_逆转风暴")]
    public Sprite TSE1Thumb;
    public Sprite TSE2Thumb;
    public Sprite TSE3Thumb;
    public Sprite TSE3_2Thumb;
    public Sprite TSE4Thumb;
    public Sprite TSE5Thumb;

    [Header("读档与设置脚本")]
    public SettingsPanelScript settingsPanelScript;
    public LoadGameScript loadGameScript;

    [Header("美术馆Logo")]
    public GameObject MuseumLogo;
    public GameObject MuseumLogoZH;

    // 功能锁
    [HideInInspector]
    public bool InAnimStudio = false;
    [HideInInspector]
    public bool InOrchestra = false;
    private bool EnteringGame = false;
    private bool InAlertPage = false;
    private bool InEpisodes = false;
    private bool InEpisodesAlert = false;
    private bool InEpisodesMenu = false;
    private bool OnTransition = false;

    private void Awake()
    {

    }
    private void Start()
    {
        AudioManager.Instance.PlaySE(SEID.entering_titlesel);
        AudioManager.Instance.PlayBGM(BGMID.ANewEraBegins);
        SettingsScript.Instance.CurrentGame = 0;
        EnteringGame = true;
        Invoke("PlayEnterAnim", 1f);
    }

    private void Update()
    {
        if(settingsPanelScript.Hided == 0 || loadGameScript.Hided == 0 || EnteringGame || InOrchestra || InEpisodes || InEpisodesMenu)
        {
            BottomNav.SetActive(false);
        }
        // 调整返回操作优先级
        if (loadGameScript.Hided == 1 && settingsPanelScript.Hided == 1 && !InAlertPage && !EnteringGame)
        {
            if (!InAnimStudio && !InOrchestra && !InEpisodes && !InEpisodesMenu)
            {
                BottomNav.SetActive(true);
                if (Input.GetKeyDown(KeyCode.Z) || Input.GetKeyDown(KeyCode.Escape) || Input.GetMouseButtonDown(1))
                {
                    BacktoMenu();
                }
                if (Input.GetKeyDown(KeyCode.G))
                {
                    settingsPanelScript.OpenSettings();
                    AudioManager.Instance.PlaySE(SEID.menu_open);
                }
                // 切换游戏Q
                if (Input.GetKeyDown(KeyCode.Q))
                {
                    SwitchGameQ();
                }
                // 切换游戏E
                if (Input.GetKeyDown(KeyCode.E))
                {
                    SwitchGameE();
                }
            }
            else if (InEpisodesMenu)
            {
                if (!InEpisodesAlert)
                {
                    if (Input.GetKeyDown(KeyCode.Z) || Input.GetKeyDown(KeyCode.Escape) || Input.GetMouseButtonDown(1))
                    {
                        CloseEpisodesMenu();
                    }
                }
            }
            else if (InEpisodes)
            {
                if (Input.GetKeyDown(KeyCode.Z) || Input.GetKeyDown(KeyCode.Escape) || Input.GetMouseButtonDown(1))
                {
                    ExitEpisodes();
                }
            }
        }

        if (BGMName == "None")
        {
            BGMNameText.text = "";
            BGMNameArea.SetActive(false);
        }
        else
        {
            BGMNameText.text = BGMName;
            BGMNameArea.SetActive(true);
        }

        if(SettingsScript.Instance.CurrentGame == 0)
        {
            if (SettingsScript.Instance.Language == "Chinese")
            {
                BGMName = "♪ 王泥喜法介 ~ 新章开庭!";
            }
            else if (SettingsScript.Instance.Language == "English")
            {
                BGMName = "♪ Apollo Justice ~ A New Era Begins!";
            }
        }
        else if(SettingsScript.Instance.CurrentGame == 1)
        {
            if (SettingsScript.Instance.Language == "Chinese")
            {
                BGMName = "♪ 等一下! ~ 真相之闪光";
            }
            else if (SettingsScript.Instance.Language == "English")
            {
                BGMName = "♪ Wait A Second! ~ A Spark of Truth";
            }
        }
        else if (SettingsScript.Instance.CurrentGame == 2)
        {
            if (SettingsScript.Instance.Language == "Chinese")
            {
                BGMName = "♪ 王泥喜法介 ~ 新章开庭! 2013";
            }
            else if (SettingsScript.Instance.Language == "English")
            {
                BGMName = "♪ Apollo Justice ~ A New Era Begins! 2013";
            }
        }
        else if (SettingsScript.Instance.CurrentGame == 3)
        {
            if (SettingsScript.Instance.Language == "Chinese")
            {
                BGMName = "♪ 王泥喜法介 ~ 新章开庭! 2024";
            }
            else if (SettingsScript.Instance.Language == "English")
            {
                BGMName = "♪ Apollo Justice ~ A New Era Begins! 2024";
            }
        }
        else
        {
            BGMName = "";
        }
        //
        if (InAnimStudio || InOrchestra)
        {
            SceneCanvas.SetActive(false);
        }
        else
        {
            SceneCanvas.SetActive(true);
        }
        // 美术馆Logo
        if (SettingsScript.Instance.Language == "Chinese")
        {
            MuseumLogo.SetActive(false);
            MuseumLogoZH.SetActive(true);
        }
        else
        {
            MuseumLogo.SetActive(true);
            MuseumLogoZH.SetActive(false);
        }
    }
    public void PlayEnterAnim()
    {
        EnterAnim.SetActive(true);
        TSPanel.SetActive(true);
        Invoke("ShowTSPanel", 1f);
        Invoke("ExitEnterAnim", 2.92f);
    }
    public void ExitEnterAnim()
    {
        EnterAnim.SetActive(false);
        EnteringGame = false;
    }
    public void ShowTSPanel()
    {
        TSPanel.SetActive(true);
        EpisodesTS.SetActive(true);
    }
    public void BeginTS()
    {
        AudioManager.Instance.PlaySE(SEID.kettei);
        EnteringGame = true;
        TSBeginObj.SetActive(true);
        AudioManager.Instance.StopBGM(true);
        Invoke("ShowTSLogo", 1f);
        Invoke("LoadTSScene", 7f);
    }
    public void LoadTSScene()
    {
        SceneManager.LoadScene("TSGame");
    }
    public void ShowTSLogo()
    {
        TSBeginLogo.SetActive(true);
    }
    public void BacktoMenu()
    {
        AudioManager.Instance.PlaySE(SEID.cancel);
        AudioManager.Instance.StopBGM(false);
        SceneManager.LoadScene("Menu");
    }

    public void SwitchGameQ()
    {
        if (!OnTransition)
        {
            OnTransition = true;
            TransitionQ.SetActive(true);
            AudioManager.Instance.PlaySE(SEID.cursor);
            Invoke("HideEpisodes", .25f);
            if (SettingsScript.Instance.CurrentGame == 0)
            {
                SettingsScript.Instance.CurrentGame = 3;
                AudioManager.Instance.PlayBGM(BGMID.ANewEraBegins2024);
                Invoke("CloseTS", .25f);
                Invoke("OpenMuseum", .75f);
            }
            else if (SettingsScript.Instance.CurrentGame == 1)
            {
                SettingsScript.Instance.CurrentGame = 0;
                AudioManager.Instance.PlayBGM(BGMID.ANewEraBegins);
                Invoke("CloseMLI", .25f);
                Invoke("OpenTS", .75f);
            }
            else if (SettingsScript.Instance.CurrentGame == 2)
            {
                SettingsScript.Instance.CurrentGame = 1;
                AudioManager.Instance.PlayBGM(BGMID.WaitASecondEoJ);
                Invoke("CloseEoJ", .25f);
                Invoke("OpenMLI", .75f);
            }
            else if (SettingsScript.Instance.CurrentGame == 3)
            {
                SettingsScript.Instance.CurrentGame = 2;
                AudioManager.Instance.PlayBGM(BGMID.ANewEraBegins2013);
                Invoke("CloseMuseum", .25f);
                Invoke("OpenEoJ", .75f);
            }
            Invoke("DisplayEpisodes", .75f);
            Invoke("TransQEnd", 1f);
        }
    }
    public void SwitchGameE()
    {
        if (!OnTransition)
        {
            OnTransition = true;
            TransitionE.SetActive(true);
            AudioManager.Instance.PlaySE(SEID.cursor);
            Invoke("HideEpisodes", .25f);
            if (SettingsScript.Instance.CurrentGame == 0)
            {
                SettingsScript.Instance.CurrentGame = 1;
                AudioManager.Instance.PlayBGM(BGMID.WaitASecondEoJ);
                Invoke("CloseTS", .25f);
                Invoke("OpenMLI", .75f);
            }
            else if (SettingsScript.Instance.CurrentGame == 1)
            {
                SettingsScript.Instance.CurrentGame = 2;
                AudioManager.Instance.PlayBGM(BGMID.ANewEraBegins2013);
                Invoke("CloseMLI", .25f);
                Invoke("OpenEoJ", .75f);
            }
            else if (SettingsScript.Instance.CurrentGame == 2)
            {
                SettingsScript.Instance.CurrentGame = 3;
                AudioManager.Instance.PlayBGM(BGMID.ANewEraBegins2024);
                Invoke("CloseEoJ", .25f);
                Invoke("OpenMuseum", .75f);
            }
            else if (SettingsScript.Instance.CurrentGame == 3)
            {
                SettingsScript.Instance.CurrentGame = 0;
                AudioManager.Instance.PlayBGM(BGMID.ANewEraBegins);
                Invoke("CloseMuseum", .25f);
                Invoke("OpenTS", .75f);
            }
            Invoke("DisplayEpisodes", .75f);
            Invoke("TransEEnd", 1f);
        }
    }
    private void CloseTS()
    {
        TSPanel.SetActive(false);
    }
    private void OpenTS()
    {
        TSPanel.SetActive(true);
    }
    private void CloseMLI()
    {
        MLIPanel.SetActive(false);
    }
    private void OpenMLI()
    {
        MLIPanel.SetActive(true);
    }
    private void CloseEoJ()
    {
        EoJPanel.SetActive(false);
    }
    private void OpenEoJ()
    {
        EoJPanel.SetActive(true);
    }
    private void CloseMuseum()
    {
        MuseumPanel.SetActive(false);
    }
    private void OpenMuseum()
    {
        MuseumPanel.SetActive(true);
    }
    private void TransQEnd()
    {
        TransitionQ.SetActive(false);
        OnTransition = false;
    }
    private void TransEEnd()
    {
        TransitionE.SetActive(false);
        OnTransition = false;
    }

    public void GoAnimStudio()
    {
        AudioManager.Instance.PlaySE(SEID.kettei);
        AudioManager.Instance.BGMFadeOut("MelodyVolume", 2f);
        SceneManager.LoadScene("AnimStudio", LoadSceneMode.Additive);
        // 改变底部导航
        InAnimStudio = true;
    }

    public void GoToOrchestra()
    {
        AudioManager.Instance.PlaySE(SEID.kettei);
        AudioManager.Instance.BGMFadeOut("MelodyVolume", 2f);
        SceneManager.LoadScene("OrchestraHall", LoadSceneMode.Additive);
        // 改变底部导航
        InOrchestra = true;
    }

    public void GoToTestScene()
    {
        SceneManager.LoadScene("TestScene");
    }

    public void BtnSelEffect(string BtnName)
    {
        float time = .2f;
        if (BtnName == "TSNewGame")
        {
            DOTween.Kill("TSStartGameBtn");
            TSStartGameBtnMask.GetComponent<RectMask2D>().padding = BtnMaskPadding441;
            TSStartGameBtnMask.SetActive(true);
            DOTween.To(() => TSStartGameBtnMask.GetComponent<RectMask2D>().padding, x => TSStartGameBtnMask.GetComponent<RectMask2D>().padding = x, BtnMaskPadding0, time).SetId("TSStartGameBtn");
        }
        else if(BtnName == "TSContinue")
        {
            DOTween.Kill("TSContinueBtn");
            TSContinueBtnMask.GetComponent<RectMask2D>().padding = BtnMaskPadding441;
            TSContinueBtnMask.SetActive(true);
            DOTween.To(() => TSContinueBtnMask.GetComponent<RectMask2D>().padding, x => TSContinueBtnMask.GetComponent<RectMask2D>().padding = x, BtnMaskPadding0, time).SetId("TSContinueBtn");
        }
        else if (BtnName == "TSEpisodes")
        {
            DOTween.Kill("TSEpisodesBtn");
            TSEpisodesBtnMask.GetComponent<RectMask2D>().padding = BtnMaskPadding441;
            TSEpisodesBtnMask.SetActive(true);
            DOTween.To(() => TSEpisodesBtnMask.GetComponent<RectMask2D>().padding, x => TSEpisodesBtnMask.GetComponent<RectMask2D>().padding = x, BtnMaskPadding0, time).SetId("TSEpisodesBtn");
        }
        else if (BtnName == "MLIComingSoon")
        {
            DOTween.Kill("MLIComingSoonBtn");
            MLIComingSoonBtnMask.GetComponent<RectMask2D>().padding = BtnMaskPadding441;
            MLIComingSoonBtnMask.SetActive(true);
            DOTween.To(() => MLIComingSoonBtnMask.GetComponent<RectMask2D>().padding, x => MLIComingSoonBtnMask.GetComponent<RectMask2D>().padding = x, BtnMaskPadding0, time).SetId("MLIComingSoonBtn");
        }
        else if (BtnName == "EoJComingSoon")
        {
            DOTween.Kill("EoJComingSoonBtn");
            EoJComingSoonBtnMask.GetComponent<RectMask2D>().padding = BtnMaskPadding441;
            EoJComingSoonBtnMask.SetActive(true);
            DOTween.To(() => EoJComingSoonBtnMask.GetComponent<RectMask2D>().padding, x => EoJComingSoonBtnMask.GetComponent<RectMask2D>().padding = x, BtnMaskPadding0, time).SetId("EoJComingSoonBtn");
        }
        else if (BtnName == "OrchestraHall")
        {
            DOTween.Kill("OrchestraHallBtn");
            OrchestraHallBtnMask.GetComponent<RectMask2D>().padding = BtnMaskPadding441;
            OrchestraHallBtnMask.SetActive(true);
            DOTween.To(() => OrchestraHallBtnMask.GetComponent<RectMask2D>().padding, x => OrchestraHallBtnMask.GetComponent<RectMask2D>().padding = x, BtnMaskPadding0, time).SetId("OrchestraHallBtn");
        }
        else if (BtnName == "ArtLibrary")
        {
            DOTween.Kill("ArtLibraryBtn");
            ArtLibraryBtnMask.GetComponent<RectMask2D>().padding = BtnMaskPadding441;
            ArtLibraryBtnMask.SetActive(true);
            DOTween.To(() => ArtLibraryBtnMask.GetComponent<RectMask2D>().padding, x => ArtLibraryBtnMask.GetComponent<RectMask2D>().padding = x, BtnMaskPadding0, time).SetId("ArtLibraryBtn");
        }
        else if (BtnName == "AnimStudio")
        {
            DOTween.Kill("AnimStudioBtn");
            AnimStudioBtnMask.GetComponent<RectMask2D>().padding = BtnMaskPadding441;
            AnimStudioBtnMask.SetActive(true);
            DOTween.To(() => AnimStudioBtnMask.GetComponent<RectMask2D>().padding, x => AnimStudioBtnMask.GetComponent<RectMask2D>().padding = x, BtnMaskPadding0, time).SetId("AnimStudioBtn");
        }
    }
    public void BtnSelDeEffect(string BtnName)
    {
        if (BtnName == "TSNewGame")
        {
            TSStartGameBtnMask.SetActive(false);
        }
        else if (BtnName == "TSContinue")
        {
            TSContinueBtnMask.SetActive(false);
        }
        else if (BtnName == "TSEpisodes")
        {
            TSEpisodesBtnMask.SetActive(false);
        }
        else if (BtnName == "MLIComingSoon")
        {
            MLIComingSoonBtnMask.SetActive(false);
        }
        else if (BtnName == "EoJComingSoon")
        {
            EoJComingSoonBtnMask.SetActive(false);
        }
        else if (BtnName == "OrchestraHall")
        {
            OrchestraHallBtnMask.SetActive(false);
        }
        else if (BtnName == "ArtLibrary")
        {
            ArtLibraryBtnMask.SetActive(false);
        }
        else if (BtnName == "AnimStudio")
        {
            AnimStudioBtnMask.SetActive(false);
        }
    }

    public void EnterEpisodes()
    {
        AudioManager.Instance.PlaySE(SEID.cursor);
        InEpisodes = true;
        Episodes.GetComponent<RectTransform>().DOLocalMoveY(-323, .5f);
        Episodes.GetComponent<CanvasGroup>().blocksRaycasts = true;
        //BottomNav.SetActive(false);
        BottomNavGrad.SetActive(false);
        EpisodesNav.SetActive(true);
        EpisodesNavGrad.SetActive(true);
    }
    public void ExitEpisodes()
    {
        AudioManager.Instance.PlaySE(SEID.cancel);
        InEpisodes = false;
        Episodes.GetComponent<RectTransform>().DOLocalMoveY(-352, .5f);
        Episodes.GetComponent<CanvasGroup>().blocksRaycasts = false;
        //BottomNav.SetActive(true);
        BottomNavGrad.SetActive(true);
        EpisodesNav.SetActive(false);
        EpisodesNavGrad.SetActive(false);
    }
    public void DisplayEpisodes()
    {
        if (SettingsScript.Instance.CurrentGame == 0)
        {
            EpisodesTS.SetActive(true);
        }
        else
        {
            EpisodesTS.SetActive(false);
        }
        Episodes.SetActive(true);
    }
    public void HideEpisodes()
    {
        Episodes.SetActive(false);
    }
    public void ComingSoon()
    {
        AudioManager.Instance.PlaySE(SEID.sentaku_fukanou);
    }
    public void OpenOptions()
    {
        AudioManager.Instance.PlaySE(SEID.menu_open);
    }
    public void LoadGame()
    {
        AudioManager.Instance.PlaySE(SEID.kettei);
    }
    public void OpenEpisodesMenu(int episodeId)
    {
        newEpisodeId = episodeId;
        AudioManager.Instance.PlaySE(SEID.kettei);
        InEpisodesMenu = true;
        episodesMenu.gameObject.SetActive(true);
        if (SettingsScript.Instance.CurrentGame == 0)
        {
            switch(episodeId)
            {
                case 0:
                    episodesMenuThumb.sprite = TSE1Thumb;
                    episodesMenuChapterNum.text = "第 1 章";
                    var prefab0 = Instantiate(episodeBtnPrefab, episodeBtnsContent);
                    prefab0.episodeName.text = "开场动画";
                    prefab0.btn.onClick.AddListener(() => ClickEpisodeBtn(0));
                    episodeBtnPrefabList.Add(prefab0);
                    var prefab1 = Instantiate(episodeBtnPrefab, episodeBtnsContent); ;
                    prefab1.episodeName.text = "成步堂法律事务所";
                    prefab1.btn.onClick.AddListener(() => ClickEpisodeBtn(1));
                    episodeBtnPrefabList.Add(prefab1);
                    var prefab2 = Instantiate(episodeBtnPrefab, episodeBtnsContent); ;
                    prefab2.episodeName.text = "初见 暮光闪闪";
                    prefab2.btn.onClick.AddListener(() => ClickEpisodeBtn(2));
                    episodeBtnPrefabList.Add(prefab2);
                    var prefab3 = Instantiate(episodeBtnPrefab, episodeBtnsContent); ;
                    prefab3.episodeName.text = "去看守所的路上";
                    prefab3.btn.onClick.AddListener(() => ClickEpisodeBtn(3));
                    episodeBtnPrefabList.Add(prefab3);
                    var prefab4 = Instantiate(episodeBtnPrefab, episodeBtnsContent); ;
                    prefab4.episodeName.text = "初见 云宝黛茜";
                    prefab4.btn.onClick.AddListener(() => ClickEpisodeBtn(4));
                    episodeBtnPrefabList.Add(prefab4);
                    var prefab5 = Instantiate(episodeBtnPrefab, episodeBtnsContent); ;
                    prefab5.episodeName.text = "会面结束后";
                    prefab5.btn.onClick.AddListener(() => ClickEpisodeBtn(5));
                    episodeBtnPrefabList.Add(prefab5);
                    var prefab6 = Instantiate(episodeBtnPrefab, episodeBtnsContent); ;
                    prefab6.episodeName.text = "小蝶的木屋";
                    prefab6.btn.onClick.AddListener(() => ClickEpisodeBtn(6));
                    episodeBtnPrefabList.Add(prefab6);
                    var prefab7 = Instantiate(episodeBtnPrefab, episodeBtnsContent); ;
                    prefab7.episodeName.text = "调查案发现场";
                    prefab7.btn.onClick.AddListener(() => ClickEpisodeBtn(7));
                    episodeBtnPrefabList.Add(prefab7);
                    break;
                default:
                    episodesMenuChapterNum.text = "第 ? 章";
                    break;
            }
        }
        episodesMenu.DOFade(1f, .5f).SetId("EpisodesMenuFadeIn");
        episodesMenu.blocksRaycasts = true;
        Invoke("OpenEpisodesMenuDelay", .5f);
    }
    public void CloseEpisodesMenu()
    {
        newEpisodeId = -1;
        CancelInvoke("OpenEpisodesMenuDelay");
        DOTween.Kill("EpisodesMenuBGImgScale");
        DOTween.Kill("EpisodesMenuFadeIn");
        AudioManager.Instance.PlaySE(SEID.cancel);
        InEpisodesMenu = false;
        int j = episodeBtnPrefabList.Count;
        for (int i = 0; i < j; i++)
        {
            Destroy(episodeBtnPrefabList[0].gameObject);
            episodeBtnPrefabList.RemoveAt(0);
        }
        episodesMenu.blocksRaycasts = false;
        episodesMenu.DOFade(0, 0);
        episodesMenuBGImg.DOScale(new Vector3(1.1f, 1.1f, 1.1f), 0);
        episodesMenu.gameObject.SetActive(false);
    }
    public void OpenEpisodesMenuDelay()
    {
        episodesMenuBGImg.DOScale(new Vector3(1, 1, 1), .5f).SetId("EpisodesMenuBGImgScale");
    }
    public void ClickEpisodeBtn(int segmentId)
    {
        AudioManager.Instance.PlaySE(SEID.kettei);
        InEpisodesAlert = true;
        episodeSelectedAlert.DOFade(1, .25f);
        episodeSelectedAlert.blocksRaycasts = true;
        switch (SettingsScript.Instance.CurrentGame)
        {
            case 0:
                switch (newEpisodeId)
                {
                    case 0:
                        switch (segmentId)
                        {
                            case 0:
                                newAreaId = 0;
                                newEventId = 0;
                                break;
                            case 1:
                                newAreaId = 1;
                                newEventId = 0;
                                break;
                            case 2:
                                newAreaId = 2;
                                newEventId = 0;
                                break;
                            case 3:
                                newAreaId = 3;
                                newEventId = 0;
                                break;
                            case 4:
                                newAreaId = 4;
                                newEventId = 0;
                                break;
                            case 5:
                                newAreaId = 3;
                                newEventId = 63;
                                break;
                            case 6:
                                newAreaId = 5;
                                newEventId = 0;
                                break;
                            case 7:
                                newAreaId = 6;
                                newEventId = 0;
                                break;
                        }
                        break;
                }
                break;
        }
        episodeSelectedChapterNum.text = "第<size=72>" + (newEpisodeId + 1) + "</size>章";
        switch (SettingsScript.Instance.CurrentGame)
        {
            case 0:
                episodeSelectedGameName.text = "逆转风暴";
                switch (newEpisodeId)
                {
                    case 0:
                        switch (newAreaId)
                        {
                            case 0:
                                episodeSelectedChapterName.text = "开场动画";
                                break;
                            case 1:
                                episodeSelectedChapterName.text = "成步堂法律事务所";
                                break;
                            case 2:
                                episodeSelectedChapterName.text = "初见 暮光闪闪";
                                break;
                            case 3:
                                if (newEventId == 0)
                                {
                                    episodeSelectedChapterName.text = "去看守所的路上";
                                }
                                else if (newEventId == 63)
                                {
                                    episodeSelectedChapterName.text = "会面结束后";
                                }
                                else
                                {
                                    episodeSelectedChapterName.text = "未知进度";
                                }
                                break;
                            case 4:
                                episodeSelectedChapterName.text = "初见 云宝黛茜";
                                break;
                            case 5:
                                episodeSelectedChapterName.text = "小蝶的木屋";
                                break;
                            case 6:
                                episodeSelectedChapterName.text = "调查案发现场";
                                break;
                            default:
                                episodeSelectedChapterName.text = "未知进度";
                                break;
                        }
                        break;
                }
                break;
            case 1:
                episodeSelectedGameName.text = "小马调查员";
                episodeSelectedChapterName.text = "未知进度";
                break;
            case 2:
                episodeSelectedGameName.text = "正义之元";
                episodeSelectedChapterName.text = "未知进度";
                break;
            default:
                episodeSelectedGameName.text = "未知游戏";
                episodeSelectedChapterName.text = "未知进度";
                break;
        }
    }
    public void EnterGameByEpisodesYes()
    {
        AudioManager.Instance.PlaySE(SEID.kettei);
        SettingsScript.Instance.loadSlotId = 999;
        var newSaveData = new SaveDataScripts.SaveData();
        newSaveData.dateTime = DateTime.Now;
        newSaveData.ChapterID = newEpisodeId;
        newSaveData.AreaID = newAreaId;
        newSaveData.EventID = newEventId;
        newSaveData.Health = 10;
        newSaveData.RecordsEvidence = new List<Records>();
        newSaveData.RecordsProfile = new List<Records>();
        newSaveData.backlogList = new Queue<Backlog>();
        newSaveData.completedTalk = new List<int>();
        newSaveData.completedInvest = new List<int>();

        BinaryFormatter bf = new BinaryFormatter();
        switch (SettingsScript.Instance.CurrentGame)
        {
            case 0:
                Records E0 = new Records();
                E0.id = 0;
                E0.state = 0;

                Records E1 = new Records();
                E1.id = 1;
                E1.state = 0;

                Records E2 = new Records();
                E2.id = 2;
                E2.state = 0;

                Records E3 = new Records();
                E3.id = 3;
                E3.state = 0;

                Records P0 = new Records();
                P0.id = 0;
                P0.state = 0;

                Records P1 = new Records();
                P1.id = 1;
                P1.state = 0;

                Records P2 = new Records();
                P2.id = 2;
                P2.state = 0;

                Records P3 = new Records();
                P3.id = 3;
                P3.state = 0;

                Records P4 = new Records();
                P4.id = 4;
                P4.state = 0;

                switch (newEpisodeId)
                {
                    case 0:
                        switch (newAreaId)
                        {
                            case 1:
                            case 2:
                                newSaveData.RecordsEvidence.Add(E0);
                                newSaveData.RecordsEvidence.Add(E1);
                                newSaveData.RecordsProfile.Add(P0);
                                break;
                            case 3:
                                newSaveData.RecordsEvidence.Add(E0);
                                newSaveData.RecordsEvidence.Add(E1);
                                newSaveData.RecordsProfile.Add(P0);
                                newSaveData.RecordsProfile.Add(P1);
                                newSaveData.RecordsEvidence.Add(E2);
                                if (newEventId == 63)
                                {
                                    newSaveData.RecordsEvidence.Add(E3);
                                    newSaveData.RecordsProfile.Add(P2);
                                    newSaveData.RecordsProfile.Add(P3);
                                    newSaveData.completedTalk.Add(0);
                                    newSaveData.completedTalk.Add(1);
                                    newSaveData.completedTalk.Add(2);
                                    newSaveData.completedTalk.Add(3);
                                    newSaveData.completedTalk.Add(4);
                                    newSaveData.completedTalk.Add(5);
                                }
                                break;
                            case 4:
                                newSaveData.RecordsEvidence.Add(E0);
                                newSaveData.RecordsEvidence.Add(E1);
                                newSaveData.RecordsProfile.Add(P0);
                                newSaveData.RecordsProfile.Add(P1);
                                newSaveData.RecordsEvidence.Add(E2);
                                newSaveData.RecordsEvidence.Add(E3);
                                break;
                            case 5:
                                newSaveData.RecordsEvidence.Add(E0);
                                newSaveData.RecordsEvidence.Add(E1);
                                newSaveData.RecordsProfile.Add(P0);
                                newSaveData.RecordsProfile.Add(P1);
                                newSaveData.RecordsEvidence.Add(E2);
                                newSaveData.RecordsEvidence.Add(E3);
                                newSaveData.completedTalk.Add(0);
                                newSaveData.completedTalk.Add(1);
                                newSaveData.completedTalk.Add(2);
                                newSaveData.completedTalk.Add(3);
                                newSaveData.completedTalk.Add(4);
                                newSaveData.completedTalk.Add(5);
                                newSaveData.RecordsProfile.Add(P2);
                                newSaveData.RecordsProfile.Add(P3);
                                break;
                            case 6:
                                newSaveData.RecordsEvidence.Add(E0);
                                newSaveData.RecordsEvidence.Add(E1);
                                newSaveData.RecordsProfile.Add(P0);
                                newSaveData.RecordsProfile.Add(P1);
                                newSaveData.RecordsEvidence.Add(E2);
                                newSaveData.RecordsEvidence.Add(E3);
                                newSaveData.completedTalk.Add(0);
                                newSaveData.completedTalk.Add(1);
                                newSaveData.completedTalk.Add(2);
                                newSaveData.completedTalk.Add(3);
                                newSaveData.completedTalk.Add(4);
                                newSaveData.completedTalk.Add(5);
                                newSaveData.RecordsProfile.Add(P2);
                                newSaveData.RecordsProfile.Add(P3);
                                newSaveData.RecordsProfile.Add(P4);
                                break;
                        }
                        break;
                }

                FileStream fs = File.Create(Application.persistentDataPath + "/Save/Save_TS_999");
                bf.Serialize(fs, newSaveData);
                fs.Close();
                episodeLoadSuccess.DOFade(1, .25f);
                episodeLoadSuccess.blocksRaycasts = true;
                Invoke("LoadTSScene", 3.5f);
                break;
            case 1:
                episodeLoadSuccess.DOFade(1, .25f);
                episodeLoadSuccess.blocksRaycasts = true;
                break;
            case 2:
                episodeLoadSuccess.DOFade(1, .25f);
                episodeLoadSuccess.blocksRaycasts = true;
                break;
            default:
                episodeLoadSuccess.DOFade(1, .25f);
                episodeLoadSuccess.blocksRaycasts = true;
                break;
        }
    }
    public void EnterGameByEpisodesNo()
    {
        InEpisodesAlert = false;
        AudioManager.Instance.PlaySE(SEID.cancel);
        episodeSelectedAlert.DOFade(0, 0);
        episodeSelectedAlert.blocksRaycasts = false;
        newAreaId = -1;
    }
}
