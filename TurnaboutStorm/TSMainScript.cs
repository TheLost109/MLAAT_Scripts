using DG.Tweening;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class TSMainScript : GameBaseController
{
    [Header("存档脚本")]
    public SaveDataScripts saveDataScripts;
    public LoadGameScript loadGameScript;

    [Header("剧情脚本")]
    public string CurrentScript = "";
    public TSScriptC0A0 tsScriptC0A0;
    public TSScriptC0A1 tsScriptC0A1;
    public TSScriptC0A2 tsScriptC0A2;
    public TSScriptC0A3 tsScriptC0A3;
    public TSScriptC0A4 tsScriptC0A4;
    public TSScriptC0A5 tsScriptC0A5;
    public TSScriptC0A6 tsScriptC0A6;

    [Header("对话系统")]
    // 对话框
    public GameObject dialogBox;
    // 点击图层遮挡
    public GameObject ClickOverlayBlock;
    // 点击后隐藏法庭记录
    public GameObject CourtRecordsHideOverlay;
    // 点击箭头
    public GameObject ProcessingArrow;

    [Header("法庭记录")]
    public CourtRecordsSystem courtRecordsSystem;
    public GameObject BtnCloseCourtRecords;

    [Header("历史记录")]
    public BacklogSystem backlogSystem;
    public Button BtnHideBacklog;

    [Header("设定面板")]
    public SettingsPanelScript settingsPanelScript;

    [Header("退出画面")]
    // 保存画面
    public GameObject ExitScreen;
    public GameObject ExitPanel;

    [Header("Demo结束画面")]
    // Demo结束背景
    public GameObject DemoEndScreen;
    // Demo结束面板
    public CanvasGroup DemoEndPanel;
    // Demo结束 存档按钮
    public Button DemoEndSaveBtn;
    // Demo结束 返回标题按钮
    public Button DemoEndBacktoTitleBtn;

    [Header("调查系统")]
    public DetectiveSystem detectiveSystem;
    public bool investEnabled = false;
    public bool moveEnabled = false;
    public bool talkEnabled = false;
    public bool presentEnabled = false;

    private void Awake()
    {

    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private void Start()
    {
        gameType = 0;
        AudioManager.Instance.StopBGM(false);
        if (SettingsScript.Instance.loadSlotId == -1)
        {
            ProceedGame(ChapterID, AreaID, false);
        }
        else
        {
            saveDataScripts.LoadBySerialization(0, SettingsScript.Instance.loadSlotId);
            if (SettingsScript.Instance.loadSlotId == 999)
            {
                saveDataScripts.DeleteSaveData("Save_TS_999");
            }
            SettingsScript.Instance.loadSlotId = -1;
            //SystemDataScripts.Instance.SaveBySerialization();
            ProceedGame(ChapterID, AreaID, true);
        }
    }

    // Update is called once per frame
    private void Update()
    {
        if (Proceed)
        {
            Proceed = false;
            ProceedGame(ChapterID, AreaID, false);
        }
        // 当前是否可存档
        if (Clickable)
        {
            bottomNav.SetActive(true);
        }
        else
        {
            bottomNav.SetActive(false);
        }

        // Mirgated from TSGameFunc.cs
        if (Input.GetKeyDown(KeyCode.E) && !backlogSystem.flag && settingsPanelScript.Hided == 1)
        {
            if (detectiveSystem.flag)
            {
                if (detectiveSystem.currentFunc == 3)
                {
                    detectiveSystem.SelectPresent();
                }
            }
            else if (courtRecordsSystem.IsPanelHided)
            {
                if (Clickable)
                {
                    ShowCourtRecords();
                }
            }
        }
        if (Input.GetKeyDown(KeyCode.T) && courtRecordsSystem.IsPanelHided && settingsPanelScript.Hided == 1 && !detectiveSystem.flag)
        {
            if (backlogSystem.flag)
            {
                HideBacklog();
            }
            else
            {
                if (Clickable)
                {
                    ShowBacklog();
                }
            }
        }
        if (Input.GetKeyDown(KeyCode.G) && !backlogSystem.flag && courtRecordsSystem.IsPanelHided && !detectiveSystem.flag)
        {
            if (settingsPanelScript.Hided == 1)
            {
                if (Clickable)
                {
                    settingsPanelScript.OpenSettings();
                    AudioManager.Instance.PlaySE(SEID.se_com_007);
                }
            }
        }
        if (Input.GetKeyDown(KeyCode.Z) || Input.GetKeyDown(KeyCode.Escape) || Input.GetMouseButtonDown(1))
        {
            if (backlogSystem.flag)
            {
                HideBacklog();
            }
            else if (!courtRecordsSystem.IsPanelHided)
            {
                if (detectiveSystem.flag && detectiveSystem.currentFunc == 3)
                {
                    HideCourtRecordsPresent();
                }
                else
                {
                    HideCourtRecords();
                }
            }
            else if (detectiveSystem.flag)
            {
                if (detectiveSystem.currentFunc == 2)
                {
                    CloseDetectiveTalk();
                }
                else if (detectiveSystem.currentFunc == 1)
                {
                    CloseDetectiveMove();
                }
                else if (detectiveSystem.currentFunc == 0)
                {
                    CloseDetectiveInvest();
                }
            }
        }
        if (Clickable == true && DialogProcessing == false)
        {
            ProcessingArrow.SetActive(true);
        }
        if (Clickable == false || DialogProcessing == true)
        {
            ProcessingArrow.SetActive(false);
        }
    }

    public void ProceedGame(int ChapterID, int AreaID, bool IsContinue)
    {
        if (ChapterID == 0)
        {
            if (AreaID == 0)
            {
                tsScriptC0A0.ProceedGame();
            }
            else if (AreaID == 1)
            {
                tsScriptC0A1.ProceedGame(EventID, IsContinue);
            }
            else if (AreaID == 2)
            {
                tsScriptC0A2.ProceedGame(EventID, IsContinue);
            }
            else if (AreaID == 3)
            {
                tsScriptC0A3.ProceedGame(EventID, IsContinue);
            }
            else if (AreaID == 4)
            {
                tsScriptC0A4.ProceedGame(EventID, IsContinue);
            }
            else if (AreaID == 5)
            {
                tsScriptC0A5.ProceedGame(EventID, IsContinue);
            }
            else if (AreaID == 6)
            {
                tsScriptC0A6.ProceedGame(EventID, IsContinue);
            }
        }
    }

    public void DemoEnded()
    {
        DemoEndScreen.GetComponent<Image>().DOFade(0, 0f);
        DemoEndScreen.SetActive(true);
        DemoEndScreen.GetComponent<Image>().DOFade(1, 1f);
        Invoke("DemoEndedDelay", 1.5f);
    }
    public void DemoEndedDelay()
    {
        AudioManager.Instance.PlayBGM(BGMID.Jingle_2001);
        DemoEndPanel.alpha = 1;
        DemoEndPanel.blocksRaycasts = true;
        DemoEndSaveBtn.onClick.AddListener(loadGameScript.OpenSaveGame);
        DemoEndSaveBtn.onClick.AddListener(() => AudioManager.Instance.PlaySE(SEID.se_com_001));
        DemoEndBacktoTitleBtn.onClick.AddListener(DemoEndedBacktoTitle);
        DemoEndBacktoTitleBtn.onClick.AddListener(() => AudioManager.Instance.PlaySE(SEID.se_com_002));
    }

    public void DemoEndedBacktoTitle()
    {
        DemoEndScreen.GetComponent<Image>().DOFade(0, 3f);
        DemoEndPanel.blocksRaycasts = false;
        DemoEndPanel.DOFade(0, 3f);
        Invoke("GoToChapSel", 3.5f);
    }

    public void GoToChapSel()
    {
        SceneManager.LoadScene("ChapSelect");
    }

    public void OpenOptions()
    {
        AudioManager.Instance.PlaySE(SEID.se_com_007);

    }

    // Mirgated from TSGameFunc.cs
    public void ShowCourtRecords()
    {
        courtRecordsSystem.PanelTrigger();
        AudioManager.Instance.PlaySE(SEID.se_com_007);
        BtnCloseCourtRecords.SetActive(true);
        btnOpenCourtRecords.gameObject.SetActive(false);
        btnShowBacklog.gameObject.SetActive(false);
        btnOptions.gameObject.SetActive(false);
        ClickOverlayBlock.SetActive(true);
    }
    public void HideCourtRecords()
    {
        courtRecordsSystem.PanelTrigger();
        AudioManager.Instance.PlaySE(SEID.se_com_002);
        BtnCloseCourtRecords.SetActive(false);
        btnOpenCourtRecords.gameObject.SetActive(true);
        btnShowBacklog.gameObject.SetActive(true);
        btnOptions.gameObject.SetActive(true);
        ClickOverlayBlock.SetActive(false);
    }
    public void ClickToHideCourtRecords()
    {
        courtRecordsSystem.NewEvidenceHide();
        Clickable = true;
        AudioManager.Instance.PlaySE(SEID.se_com_001);
    }
    public void ShowCourtRecordsPresent()
    {
        detectiveSystem.flag = true;
        detectiveSystem.currentFunc = 3;
        AudioManager.Instance.PlaySE(SEID.se_com_007);
        courtRecordsSystem.PanelTrigger();
        courtRecordsSystem.RecordTags.SetActive(false);
        btnDetectivePresent.gameObject.SetActive(true);
        btnCloseDetectivePresent.gameObject.SetActive(true);
    }
    public void HideCourtRecordsPresent()
    {
        AudioManager.Instance.PlaySE(SEID.se_com_002);
        detectiveSystem.currentFunc = -1;
        btnDetectivePresent.gameObject.SetActive(false);
        btnCloseDetectivePresent.gameObject.SetActive(false);
        courtRecordsSystem.PanelTrigger();
        Invoke("HideCourtRecordsPresentDelay", .51f);
    }
    public void HideCourtRecordsPresentDelay()
    {
        detectiveSystem.flag = false;
        courtRecordsSystem.RecordTags.SetActive(true);
        ShowActions();
    }
    public void ShowBacklog()
    {
        AudioManager.Instance.PlaySE(SEID.se_com_007);
        btnOpenCourtRecords.gameObject.SetActive(false);
        btnShowBacklog.gameObject.SetActive(false);
        btnOptions.gameObject.SetActive(false);
        BtnHideBacklog.gameObject.SetActive(true);
        if (EventID >= 99990 && EventID <= 99999)
        {
            detectiveSystem.CloseActions();
        }
        else
        {
            dialogBox.SetActive(false);
        }
        backlogSystem.ShowBacklog();
    }

    public void HideBacklog()
    {
        AudioManager.Instance.PlaySE(SEID.se_com_002);
        btnOpenCourtRecords.gameObject.SetActive(true);
        btnShowBacklog.gameObject.SetActive(true);
        btnOptions.gameObject.SetActive(true);
        BtnHideBacklog.gameObject.SetActive(false);
        if (EventID >= 99990 && EventID <= 99999)
        {
            ShowActions();
        }
        else
        {
            dialogBox.SetActive(true);
        }
        backlogSystem.HideBacklog();
    }

    // 显示退出确认
    public void ShowExitScreen()
    {
        SettingsScript.Instance.Halt = true;
        AudioManager.Instance.PlaySE(SEID.menu_open);
        ExitScreen.GetComponent<Graphic>().DOFade(0, 0f);
        ExitScreen.SetActive(true);
        ExitScreen.GetComponent<Graphic>().DOFade(.9f, .25f);
        Invoke("ShowExitPanel", .35f);
    }

    private void ShowExitPanel()
    {
        ExitPanel.SetActive(true);
    }
    // 确认存档
    public void OnConfirmExit()
    {
        SettingsScript.Instance.Halt = false;
        AudioManager.Instance.PlaySE(SEID.kettei);
        GoToChapSel();
    }
    // 取消退出
    public void OnCancelExit()
    {
        AudioManager.Instance.PlaySE(SEID.cancel);
        ExitScreen.SetActive(false);
        ExitScreen.GetComponent<Graphic>().DOFade(1, 0f);
        ExitPanel.SetActive(false);
        SettingsScript.Instance.Halt = false;
    }

    public void CloseDetectiveTalk()
    {
        AudioManager.Instance.PlaySE(SEID.se_com_002);
        detectiveSystem.CloseTalk();
        Invoke("ShowActions", 0.26f);
    }

    public void CloseDetectiveMove()
    {
        AudioManager.Instance.PlaySE(SEID.se_com_002);
        detectiveSystem.CloseMove();
        Invoke("ShowActions", 0.26f);
    }

    public void CloseDetectiveInvest()
    {
        AudioManager.Instance.PlaySE(SEID.se_com_002);
        detectiveSystem.CloseInvest();
        Invoke("ShowActions", 0.26f);
    }

    public void ShowActions()
    {
        detectiveSystem.OpenActions(investEnabled, moveEnabled, talkEnabled, presentEnabled);
        btnOpenCourtRecords.gameObject.SetActive(true);
        btnShowBacklog.gameObject.SetActive(true);
        btnOptions.gameObject.SetActive(true);
    }
}
