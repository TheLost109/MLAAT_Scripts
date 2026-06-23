using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GameBaseController : MonoBehaviour
{
    [Header("底部导航")]
    // 法庭记录
    public Button btnOpenCourtRecords;
    // 历史记录
    public Button btnShowBacklog;
    // 设定
    public Button btnOptions;

    [Header("单击遮罩")]
    public GameObject ClickOverlay;

    [Header("调查系统")]
    public CanvasGroup actionMovePanel;
    public Button btnCloseDetectiveInvest;
    public Button btnCloseDetectiveMove;
    public Button btnCloseDetectiveTalk;
    public Button btnDetectivePresent;
    public Button btnCloseDetectivePresent;

    [Header("其他")]
    // 角色姓名Object
    public GameObject NameText;
    // 对话内容Object
    public GameObject DialogText;
    // 区域介绍Object
    public GameObject NewAreaText;
    // 台词位置
    public int DialogIndex = 0;
    // 台词行
    public string[] DialogRows;
    // 章节ID
    public int ChapterID = 0;
    // 区域ID
    public int AreaID = 0;
    // 本句话是否静音
    private bool IsSilent = false;
    // 打字机效果延迟
    private float Delay;
    // 用于控制角色Sprite是否动嘴型
    public bool IsCharacterTalking = false;
    // 当前是否可点击进行下一句
    public bool Clickable = false;
    // 血量
    public int Health = 10;
    // 当前音乐
    public string CurrentMusic = "";
    // 当前背景
    public string CurrentBG = "";
    // 对话者性别
    private int Gender;
    // 对话状态
    public bool DialogProcessing = false;
    // 事件ID
    public int EventID = 0;
    // 底部按钮
    public GameObject bottomNav;
    // 继续游戏
    public bool Proceed = false;
    // 法庭记录-证物
    public List<Records> RecordsEvidence = new List<Records>();
    // 法庭记录-档案
    public List<Records> RecordsProfile = new List<Records>();
    // 说话音效速度
    public float TalkingSFXSpeed = 0.08f;
    // 历史记录队列
    public Queue<Backlog> backlogList = new Queue<Backlog>();
    // 对话行
    private string[] cells;
    // 已完成对话
    public List<int> completedTalk = new List<int>();
    // 已完成调查
    public List<int> completedInvest = new List<int>();
    // 游戏类型
    public int gameType;
    // 用户操作遮挡
    //public GameObject UIBlock;

    private void Awake()
    {
        AudioManager.Instance.StopBGM(false);
    }

    private void Start()
    {

    }
    private void Update()
    {

    }

    public void UpdateText()
    {
        DOTween.Kill("SpeechAnim");
        DOTween.Kill("NewAreaAnim");
        cells = DialogRows[DialogIndex].Split(',');
        NameText.GetComponent<TextMeshProUGUI>().text = cells[2];
        if (int.Parse(cells[0]) == 0)
        {
            NewAreaText.GetComponent<TextMeshProUGUI>().text = cells[3].Replace("@", "");
        }
        else
        {
            // 文本颜色
            if (cells[6] != "" || cells[6] != null)
            {
                ColorUtility.TryParseHtmlString(cells[6], out Color textColor);
                DialogText.GetComponent<TextMeshProUGUI>().color = textColor;
            }
            DialogText.GetComponent<TextMeshProUGUI>().text = cells[3].Replace("@", "");
        }
    }
    public void ReadText(TextAsset _textAsset)
    {
        DialogRows = _textAsset.text.Split('\n');
        Debug.Log("对话读取成功");
    }
    public void ShowDialogRow()
    {
        DialogProcessing = true;
        cells = DialogRows[DialogIndex].Split(',');
        Delay = float.Parse(cells[4]);
        NameText.GetComponent<TextMeshProUGUI>().text = cells[2];
        DialogText.GetComponent<TextMeshProUGUI>().text = "";
        NewAreaText.GetComponent<TextMeshProUGUI>().text = "";
        string textNoAT;
        string textNoBR;
        string textNoATandBR;
        List<int> stopPos = new List<int>();
        // 标记当前对话是否静音
        if (int.Parse(cells[5]) == 1)
        {
            IsSilent = true;
        }
        else
        {
            IsSilent = false;
        }
        // 文本颜色
        if (cells[6] != "" || cells[6] != null)
        {
            ColorUtility.TryParseHtmlString(cells[6], out Color textColor);
            DialogText.GetComponent<TextMeshProUGUI>().color = textColor;
        }
        // 检测是绿色的区域信息还是正常人物对话
        if (int.Parse(cells[0]) == 0)
        {
            // 打字音效速度
            TalkingSFXSpeed = 0.08f;
            ShowArea(cells[3], float.Parse(cells[4]));
            StartCoroutine(NewAreaSFXs(float.Parse(cells[4])));
            Invoke("FinishedTalking", Delay * (cells[3].Length - 4));
        }
        else
        {
            // 打字音效速度
            TalkingSFXSpeed = 0.08f * (float.Parse(cells[4]) / 0.1f);
            textNoAT = cells[3].Replace("@", "");
            textNoBR = cells[3].Replace("<br>", "");
            textNoATandBR = textNoAT.Replace("<br>", "");
            // 统计停顿符号@的出现次数与位置
            for (int i = 0; i < textNoBR.Length; i++)
            {
                if (textNoBR[i] == '@')
                {
                    stopPos.Add(i);
                }
            }
            int howManyColors = Regex.Matches(cells[3], "</color>").Count;
            if (!IsSilent)
            {
                Gender = int.Parse(cells[1]);
                StartCoroutine(TalkingSFX(Gender, TalkingSFXSpeed));
                ShowText(textNoAT, float.Parse(cells[4]), stopPos, howManyColors);
            }
            else
            {
                ShowText(textNoAT, float.Parse(cells[4]), stopPos, howManyColors);
            }
            if (stopPos.Count >= 1)
            {
                Invoke("FinishedTalking", Delay * (textNoATandBR.Length - howManyColors * 23) + 1f * stopPos.Count);
            }
            else
            {
                Invoke("FinishedTalking", Delay * (textNoATandBR.Length - howManyColors * 23));
            }
        }
        // 历史记录
        Backlog backlog = new Backlog();
        backlog.name = cells[2];
        backlog.content = cells[3].Replace("@", "");
        if (int.Parse(cells[0]) == 0)
        {
            backlog.color = "#00FF00";
        }
        else if (cells[6] != "" || cells[6] != null)
        {
            backlog.color = cells[6];
        }
        else
        {
            backlog.color = "#FFFFFF";
        }
        if (backlogList.Count > 50) backlogList.Dequeue();
        backlogList.Enqueue(backlog);
    }
    // 对话执行完毕后，将IsCharacterTalking标记为false
    public void FinishedTalking()
    {
        IsCharacterTalking = false;
        DialogProcessing = false;
    }
    // 遍历文本产生打字机效果
    public void ShowText(string textNoAT, float delay, List<int> stopPos, int howManyColors)
    {
        string textNoATandBR = textNoAT.Replace("<br>", "");
        var t = DOTween.To(()=>string.Empty, value => DialogText.GetComponent<TextMeshProUGUI>().text = value, textNoAT, delay * (textNoATandBR.Length - howManyColors * 23)).SetEase(Ease.Linear).SetId("SpeechAnim");
        // 富文本
        t.SetOptions(true);
        for(int i = 0; i < stopPos.Count; i++)
        {
            if (stopPos[i] > 0)
            {
                Invoke("PauseText", stopPos[i] * delay - delay * i + 1f * i);
                Invoke("UnpauseText", stopPos[i] * delay - delay * i + 1f * (i + 1));
            }
        }
    }
    public void PauseText()
    {
        DOTween.Pause("SpeechAnim");
        StopAllCoroutines();
    }
    public void UnpauseText()
    {
        DOTween.Play("SpeechAnim");
        if(!IsSilent) StartCoroutine(TalkingSFX(Gender, TalkingSFXSpeed));
    }
    // 展示新区域
    public void ShowArea(string _text, float delay)
    {
        var t = DOTween.To(() => string.Empty, value => NewAreaText.GetComponent<TextMeshProUGUI>().text = value, _text, delay * (_text.Length - 4)).SetEase(Ease.Linear).SetId("NewAreaAnim");
        // 富文本
        t.SetOptions(true);
    }
    public void ClicktoNext()
    {
        if (Clickable)
        {
            if (DialogProcessing)
            {
                StopAllCoroutines();
                CancelInvoke();
                UpdateText();
                FinishedTalking();
            }
            else if (!Proceed)
            {
                if (EventID != 999) EventID = EventID + 1;
                Proceed = true;
                AudioManager.Instance.PlaySE(SEID.se_com_005);
            }
        }
    }
    IEnumerator TalkingSFX(int gender, float delay)
    {
        while (DialogProcessing)
        {
            if (gender == 0)
            {
                AudioManager.Instance.PlaySE(SEID.se_com_004);
                yield return new WaitForSeconds(delay);
            }
            else if (gender == 1)
            {
                AudioManager.Instance.PlaySE(SEID.se_com_003);
                yield return new WaitForSeconds(delay);
            }
        }
    }
    IEnumerator NewAreaSFXs(float delay)
    {
        while (DialogProcessing)
        {
            AudioManager.Instance.PlaySE(SEID.se_com_006);
            yield return new WaitForSeconds(delay);
        }
    }
}
