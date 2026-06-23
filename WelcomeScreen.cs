using UnityEngine;
using DG.Tweening;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class WelcomeScreen : MonoBehaviour
{
    public SettingsScript settingsScript;
    public SystemDataScripts systemDataScripts;

    public GameObject Gear;
    public GameObject Gear2;
    public GameObject alertBG;
    public CanvasGroup selectLanguageBtns;
    public CanvasGroup Warning;
    public GameObject warningTextCN;
    public GameObject warningTextEN;

    public GameObject splashVideo;

    Vector3 clockwise;
    Vector3 counterClockwise;

    public CanvasGroup anzen;
    public TextMeshProUGUI anzenText;
    public TextMeshProUGUI anzenText2;
    public TextMeshProUGUI anzenText3;

    private void Awake()
    {

    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private void Start()
    {
        Invoke("StartGame", 4f);
    }

    // Update is called once per frame
    private void Update()
    {

    }

    public void StartGame()
    {
        splashVideo.SetActive(false);
        clockwise.Set(0, 0, -360f);
        counterClockwise.Set(0, 0, 360f);
        Gear.transform.DOLocalRotate(clockwise, 2f, RotateMode.FastBeyond360).SetEase(Ease.Linear).SetLoops(-1, LoopType.Restart);
        Gear2.transform.DOLocalRotate(counterClockwise, 2f, RotateMode.FastBeyond360).SetEase(Ease.Linear).SetLoops(-1, LoopType.Restart);
        //Invoke("DetectSystemData", 2.5f);
        Invoke("AnzenScreen", 2.5f);
        Invoke("AnzenScreenHide", 5.25f);
        Invoke("AnzenScreen2", 5.5f);
        Invoke("AnzenScreenHide", 8f);
        Invoke("AnzenScreen3", 8.25f);
        Invoke("AnzenScreenHide", 10.75f);
        Invoke("LoadMenu", 12f);
    }

    public void AnzenScreen()
    {
        settingsScript.FirstRun = false;
        Gear.SetActive(false);
        Gear2.SetActive(false);
        anzen.DOFade(1, .25f);
    }

    public void AnzenScreenHide()
    {
        anzen.DOFade(0, .25f);
    }

    public void AnzenScreen2()
    {
        anzenText.gameObject.SetActive(false);
        anzenText2.gameObject.SetActive(true);
        anzen.DOFade(1, .25f);
    }

    public void AnzenScreen3()
    {
        anzenText2.gameObject.SetActive(false);
        anzenText3.gameObject.SetActive(true);
        anzen.DOFade(1, .25f);
    }

    public void DetectSystemData()
    {
        Gear.transform.DOPause();
        Gear.SetActive(false);
        Gear2.transform.DOPause();
        Gear2.SetActive(false);
        DisplayAlertBG();
        if (settingsScript.FirstRun)
        {
            Invoke("SelectLanguage", .6f);
        }
        else
        {
            Invoke("ShowWarning", .6f);
        }
    }
    public void SelectLanguage()
    {
        selectLanguageBtns.alpha = 1;
        selectLanguageBtns.blocksRaycasts = true;
    }
    public void LanguageSelected(string Language)
    {
        AudioManager.Instance.PlaySE(SEID.kettei);
        if (Language == "Chinese")
        {
            settingsScript.Language = "Chinese";
        }
        else if (Language == "English")
        {
            settingsScript.Language = "English";
        }
        else
        {
            settingsScript.Language = "Chinese";
        }
        settingsScript.FirstRun = false;
        systemDataScripts.SaveBySerialization();
        alertBG.SetActive(false);
        alertBG.GetComponent<Image>().DOFade(0, 0f);
        selectLanguageBtns.alpha = 0;
        selectLanguageBtns.blocksRaycasts = false;
        Invoke("DisplayAlertBG", .5f);
        Invoke("ShowWarning", .6f);
    }
    public void DisplayAlertBG()
    {
        alertBG.SetActive(true);
        alertBG.GetComponent<Image>().DOFade(1, .5f);
    }
    public void WarningReaded()
    {
        AudioManager.Instance.PlaySE(SEID.kettei);
        Warning.alpha = 0;
        Warning.blocksRaycasts = false;
        alertBG.SetActive(false);
        Gear.SetActive(true);
        Gear.transform.DOPlay();
        Gear2.SetActive(true);
        Gear2.transform.DOPlay();
        Invoke("LoadMenu", 2f);
    }
    public void LoadMenu()
    {
        SceneManager.LoadScene("Menu");
    }

    public void ShowWarning()
    {
        if(settingsScript.Language == "Chinese")
        {
            warningTextCN.SetActive(true);
        }
        else if(settingsScript.Language == "English")
        {
            warningTextEN.SetActive(true);
        }
        Warning.alpha = 1;
        Warning.blocksRaycasts = true;
    }
}
