using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.Video;
using DG.Tweening;
using FMODUnity;
using System.IO;

public class MainMenuController : MonoBehaviour
{
    [Header("其他")]
    public GameObject JumpScreen;
    public GameObject JumpPanel;
    public GameObject CourtDoorVideo;
    public CanvasGroup ButtonsGroup;
    public CanvasGroup ExitButton;
    public Button BtnContinue;
    public RenderTexture title_bg;
    public GameObject title_bg_iml3;

    [Header("游戏Logo")]
    public Image MLAATLogo;
    public Image MLAATLogoEN;

    [Header("Credits 相关")]
    public GameObject CreditsScreen;
    private bool InCredits = false;

    [Header("结束游戏 相关")]
    public GameObject ExitScreen; // 结束画面
    public GameObject ExitPanel; // 结束面板

    [Header("结束游戏 按钮动效")]
    public Vector4 BtnMaskPadding0;
    public Vector4 BtnMaskPadding224;
    public GameObject ExitGameBtnMask;

    private void Awake()
    {

    }

    private void Start()
    {
        title_bg_iml3.GetComponent<Image>().DOFade(0, 0);
        Invoke("DoorStart", .5f);
        Invoke("BGMStart", 1.5f);
        if (SettingsScript.Instance.Language == "Chinese")
        {
            MLAATLogo.DOFade(0, 0);
            Invoke("ShowLogo", 2f);
        }
        else if (SettingsScript.Instance.Language == "English")
        {
            MLAATLogoEN.DOFade(0, 0);
            Invoke("ShowLogoEN", 2f);
        }
        Invoke("ShowButtons", 3f);
        Invoke("ShowBlurBG", 3.51f);

        // 隐藏对话框
        JumpScreen.GetComponent<Graphic>().CrossFadeAlpha(0f, 0f, false);

        //
        if (Directory.Exists(Application.persistentDataPath + "/Save"))
        {
            if (Directory.GetFiles(Application.persistentDataPath + "/Save").Length > 1)
            {
                BtnContinue.gameObject.SetActive(true);
            }
            else
            {
                BtnContinue.gameObject.SetActive(false);
            }
        }
        else
        {
            BtnContinue.gameObject.SetActive(false);
        }
    }
    private void Update()
    {
        // Credits 界面
        if (InCredits)
        {
            CreditsScreen.SetActive(true);
            if (Input.GetKeyDown(KeyCode.Z) || Input.GetKeyDown(KeyCode.Escape) || Input.GetMouseButtonDown(1))
            {
                ExitCredits();
            }
        }
        else if (!InCredits) {
            CreditsScreen.SetActive(false);
        }
    }
    public void ShowLogo()
    {
        MLAATLogo.gameObject.SetActive(true);
        MLAATLogo.DOFade(1, 1f);
    }
    public void ShowLogoEN()
    {
        MLAATLogoEN.gameObject.SetActive(true);
        MLAATLogoEN.DOFade(1, 1f);
    }

    public void StartGame()
    {
        AudioManager.Instance.PlaySE(SEID.enter_startup_screen);
        SceneManager.LoadScene("ChapSelect");
    }

    public void LookForCredits()
    {
        AudioManager.Instance.PlaySE(SEID.enter_startup_screen);
        InCredits = true;
        AudioManager.Instance.StopBGM(false);
        AudioManager.Instance.PlayBGM(BGMID.BringItInEveryone);
    }
    public void ExitCredits()
    {
        AudioManager.Instance.PlaySE(SEID.cancel);
        AudioManager.Instance.StopBGM(false);
        AudioManager.Instance.PlayBGM(BGMID.ANewEraBegins2024);
        InCredits = false;
    }
    public void GonnaJump()
    {
        //CrossSceneAudio.Instance.enter_startup_screen.Play();
        AudioManager.Instance.PlaySE(SEID.enter_startup_screen);
        JumpScreen.SetActive(true);
        JumpScreen.GetComponent<Graphic>().CrossFadeAlpha(.99f, .25f, false);
        Invoke("ShowJumpPanel", .35f);
    }

    public void ShowJumpPanel()
    {
        JumpPanel.SetActive(true);
    }

    public void OnConfirmJump(string url)
    {
        if (url != "")
        {
            Application.OpenURL(url);
        }
        OnCancelJump();
    }
    public void OnCancelJump()
    {
        AudioManager.Instance.PlaySE(SEID.cancel);
        JumpScreen.SetActive(false);
        JumpScreen.GetComponent<Graphic>().CrossFadeAlpha(0f, 0f, false);
        JumpPanel.SetActive(false);
    }
    public void DoorStart()
    {
        title_bg.Release();
        CourtDoorVideo.SetActive(true);
        CourtDoorVideo.GetComponent<VideoPlayer>().Play();
        AudioManager.Instance.PlaySE(SEID.door_startup_screen);
    }
    public void BGMStart()
    {
        AudioManager.Instance.PlayBGM(BGMID.ANewEraBegins2024);
    }
    public void ShowButtons()
    {
        ButtonsGroup.DOFade(1, 1f);
        ButtonsGroup.blocksRaycasts = true;
        ExitButton.DOFade(1, 1f);
        ExitButton.blocksRaycasts = true;
    }
    public void ShowBlurBG()
    {
        title_bg_iml3.SetActive(true);
        title_bg_iml3.GetComponent<Image>().DOFade(1, .5f);
    }
    // 结束游戏相关事件
    // 显示结束画面
    public void ShowExitScreen()
    {
        //CrossSceneAudio.Instance.enter_startup_screen.Play();
        AudioManager.Instance.PlaySE(SEID.enter_startup_screen);
        // 隐藏对话框
        ExitScreen.GetComponent<Graphic>().CrossFadeAlpha(0f, 0f, false);
        ExitScreen.SetActive(true);
        ExitScreen.GetComponent<Graphic>().CrossFadeAlpha(.99f, .25f, false);
        Invoke("ShowExitPanel", .35f);
    }

    private void ShowExitPanel()
    {
        ExitPanel.SetActive(true);
    }

    public void OnConfirmExit()
    {
        AudioManager.Instance.PlaySE(SEID.kettei);
        Debug.Log("退出游戏！");
        Application.Quit();
    }

    // 取消退出
    public void OnCancelExit()
    {
        //CrossSceneAudio.Instance.cancel.Play();
        AudioManager.Instance.PlaySE(SEID.cancel);
        ExitScreen.SetActive(false);
        ExitScreen.GetComponent<Graphic>().CrossFadeAlpha(0f, 0f, false);
        ExitPanel.SetActive(false);
    }
    public void ExitGameBtnSelEffect()
    {
        float time = .1f;
        DOTween.To(() => ExitGameBtnMask.GetComponent<RectMask2D>().padding, x => ExitGameBtnMask.GetComponent<RectMask2D>().padding = x, BtnMaskPadding0, time);
    }
    public void ExitGameBtnSelDeEffect()
    {
        float time = .1f;
        DOTween.To(() => ExitGameBtnMask.GetComponent<RectMask2D>().padding, x => ExitGameBtnMask.GetComponent<RectMask2D>().padding = x, BtnMaskPadding224, time);
    }
    public void PlayHammerSE()
    {
        AudioManager.Instance.PlaySE(SEID.enter_startup_screen);
    }
}

