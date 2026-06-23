using DG.Tweening;
using FMODUnity;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class DetectiveSystem : MonoBehaviour
{
    [Header("关联脚本")]
    public GameBaseController gameBaseController;
    public CourtRecordsSystem courtRecordsSystem;

    [Header("动作按钮")]
    public RectTransform actionInvest;
    public RectTransform actionMove;
    public RectTransform actionTalk;
    public RectTransform actionPresent;

    [Header("调查相关")]
    public Texture2D cursorIdle;
    public Texture2D cursorFound;
    public Texture2D cursorChecked;
    public Image backgroundSlideBtnLeft;
    public Image backgroundSlideBtnRight;
    public int currentBackgroundPos = 0;
    public List<int> allBackgroundPos = new List<int>();
    public List<float> allBackgroundPosSpr = new List<float>();
    [HideInInspector]
    public Transform currentBackground;
    [HideInInspector]
    public RectTransform currentBackgroundSpots;
    public bool backgroundSlideBtnLeftActivated = false;
    public bool backgroundSlideBtnRightActivated = false;

    [Header("移动相关")]
    public Image moveAreaThumb;
    public GameObject moveAreaThumbUnknown;
    public List<SelectionMove> moveList = new List<SelectionMove>();
    public RectTransform moveParent;
    public List<SelectionPrefab> movePrefabList = new List<SelectionPrefab>();

    [Header("其他")]
    public RectTransform selectionsParent;
    public SelectionPrefab selectionPrefab;
    public List<Selection> talkList = new List<Selection>();
    public List<SelectionPrefab> selectionPrefabList = new List<SelectionPrefab>();
    public List<Selection> presentList = new List<Selection>();
    private int selectedPrefabId;
    private int newAreaId;
    private int newEventId;
    public bool flag = false;
    public int currentFunc = -1;
    public Image blackCover;
    //
    public SpriteRenderer hidedCharaSpr;
    public GameObject currentInvestSpots;
    private bool lockMousePos = false;
    private CursorPoint cp;

    void Start()
    {

    }

    void Update()
    {
        if (lockMousePos)
        {
            SetCursorPos(cp.X, cp.Y);
        }

    }

    [System.Runtime.InteropServices.DllImport("user32.dll")]
    public static extern bool GetCursorPos(out CursorPoint lpPoint);

    [StructLayout(LayoutKind.Sequential)]
    public struct CursorPoint
    {
        public int X;
        public int Y;
        public CursorPoint(int x, int y)
        {
            this.X = x;
            this.Y = y;

        }
    }

    [System.Runtime.InteropServices.DllImport("user32.dll")]
    public static extern int SetCursorPos(int x, int y);

    public void ClearOpenTweens()
    {
        DOTween.Kill("investOpen");
        DOTween.Kill("moveOpen");
        DOTween.Kill("talkOpen");
        DOTween.Kill("presentOpen");
    }

    public void ClearCloseTweens()
    {
        DOTween.Kill("investClose");
        DOTween.Kill("moveClose");
        DOTween.Kill("talkClose");
        DOTween.Kill("presentClose");
        CancelInvoke("CloseActionsDelay");
    }

    public void OpenActions(bool invest, bool move, bool talk, bool present)
    {
        flag = false;
        ClearCloseTweens();
        if (invest)
        {
            actionInvest.gameObject.SetActive(true);
            actionInvest.DOScaleY(1, .25f).SetId("investOpen");
        }
        if (move)
        {
            actionMove.gameObject.SetActive(true);
            actionMove.DOScaleY(1, .25f).SetId("moveOpen");
        }
        if (talk)
        {
            actionTalk.gameObject.SetActive(true);
            actionTalk.DOScaleY(1, .25f).SetId("talkOpen");
        }
        if (present)
        {
            actionPresent.gameObject.SetActive(true);
            actionPresent.DOScaleY(1, .25f).SetId("presentOpen");
        }
    }

    public void CloseActions()
    {
        gameBaseController.btnOpenCourtRecords.gameObject.SetActive(false);
        gameBaseController.btnShowBacklog.gameObject.SetActive(false);
        gameBaseController.btnOptions.gameObject.SetActive(false);
        ClearOpenTweens();
        if (actionInvest.gameObject.activeInHierarchy)
        {
            actionInvest.DOScaleY(0, .25f).SetId("investClose");
        }
        if (actionMove.gameObject.activeInHierarchy)
        {
            actionMove.DOScaleY(0, .25f).SetId("moveClose");
        }
        if (actionTalk.gameObject.activeInHierarchy)
        {
            actionTalk.DOScaleY(0, .25f).SetId("talkClose");
        }
        if (actionPresent.gameObject.activeInHierarchy)
        {
            actionPresent.DOScaleY(0, .25f).SetId("presentClose");
        }
        Invoke("CloseActionsDelay", .26f);
    }

    public void CloseActionsDelay()
    {
        actionInvest.gameObject.SetActive(false);
        actionMove.gameObject.SetActive(false);
        actionTalk.gameObject.SetActive(false);
        actionPresent.gameObject.SetActive(false);
    }

    public void OpenTalk()
    {
        flag = true;
        currentFunc = 2;
        for (int i = 0; i < talkList.Count; i++)
        {
            if (talkList[i].prevSelection == -1 || gameBaseController.completedTalk.Contains(talkList[i].prevSelection))
            {
                if (talkList[i].isPsyLock == false)
                {
                    var newPrefab = Instantiate(selectionPrefab, selectionsParent);
                    selectionPrefabList.Add(newPrefab);
                    int count = selectionPrefabList.Count - 1;
                    int eventId = talkList[i].eventId;
                    newPrefab.content.text = talkList[i].description;
                    newPrefab.checkmark.SetActive(gameBaseController.completedTalk.Contains(talkList[i].id));
                    newPrefab.button.onClick.AddListener(() => SelectTalk(count, eventId));
                }
                else if (!(gameBaseController.completedTalk.Contains(talkList[i].id + 1)))
                {
                    var newPrefab = Instantiate(selectionPrefab, selectionsParent);
                    selectionPrefabList.Add(newPrefab);
                    int count = selectionPrefabList.Count - 1;
                    int eventId = talkList[i].eventId;
                    newPrefab.content.text = talkList[i].description;
                    newPrefab.iconPsyLock.SetActive(gameBaseController.completedTalk.Contains(talkList[i].id));
                    newPrefab.button.onClick.AddListener(() => SelectTalk(count, eventId));
                }
            }
        }
    }

    public void SelectTalk(int prefabId, int eventId)
    {
        currentFunc = -1;
        gameBaseController.btnCloseDetectiveTalk.gameObject.SetActive(false);
        if (gameBaseController.gameType == 0) AudioManager.Instance.PlaySE(SEID.se_com_001);
        selectedPrefabId = prefabId;
        newEventId = eventId;
        for (int i = 0; i < selectionPrefabList.Count; i++)
        {
            if (i != prefabId)
            {
                selectionPrefabList[i].rectTransform.DOScale(0, .25f);
            }
        }
        selectionPrefabList[prefabId].btnBgLink.SetActive(false);
        selectionPrefabList[prefabId].btnBgHover.SetActive(false);
        selectionPrefabList[prefabId].btnBgActive.SetActive(true);
        selectionPrefabList[prefabId].button.enabled = false;
        selectionPrefabList[prefabId].GetComponent<EventTrigger>().enabled = false;
        selectionPrefabList[prefabId].GetComponent<StudioEventEmitter>().enabled = false;
        Invoke("SelectTalkDelay", .25f);
        Invoke("SelectTalkDelay2", 1.25f);
    }

    public void SelectTalkDelay()
    {
        selectionPrefabList[selectedPrefabId].rectTransform.DOMoveY(-1080, 1f);
    }

    public void SelectTalkDelay2()
    {
        flag = false;
        gameBaseController.EventID = newEventId;
        gameBaseController.Proceed = true;
        ClearTalkList();
    }

    public void ClearTalkList()
    {
        flag = false;
        int i, j;
        j = selectionPrefabList.Count;
        for (i = 0; i < j; i++)
        {
            Destroy(selectionPrefabList[0].gameObject);
            selectionPrefabList.RemoveAt(0);
        }
    }

    public void CloseTalk()
    {
        currentFunc = -1;
        gameBaseController.btnCloseDetectiveTalk.gameObject.SetActive(false);
        for (int i = 0; i < selectionPrefabList.Count; i++)
        {
            selectionPrefabList[i].GetComponent<Animation>().Stop();
            selectionPrefabList[i].rectTransform.DOScale(0, .25f);
        }
        Invoke("ClearTalkList", .26f);
    }

    public void SelectPresent()
    {
        gameBaseController.btnDetectivePresent.gameObject.SetActive(false);
        gameBaseController.btnCloseDetectivePresent.gameObject.SetActive(false);
        AudioManager.Instance.PlaySE(SEID.se_com_001);
        courtRecordsSystem.PanelTrigger();
        currentFunc = -1;
        Invoke("SelectPresentDelay", .51f);
    }
    public void SelectPresentDelay()
    {
        for (int i = 1; i < presentList.Count; i++)
        {
            if (presentList[i].prevSelection == courtRecordsSystem.curSelected)
            {
                flag = false;
                gameBaseController.EventID = presentList[i].eventId;
                gameBaseController.Proceed = true;
            }
            else if (i == presentList.Count - 1)
            {
                flag = false;
                gameBaseController.EventID = presentList[0].eventId;
                gameBaseController.Proceed = true;
            }
        }
    }
    public void ShowMoveAreaThumb(Sprite thumb)
    {
        moveAreaThumbUnknown.SetActive(false);
        moveAreaThumb.sprite = thumb;
        moveAreaThumb.gameObject.SetActive(true);
    }
    public void ClearMoveAreaThumb()
    {
        moveAreaThumbUnknown.SetActive(true);
        moveAreaThumb.gameObject.SetActive(false);
    }

    public void OpenMove()
    {
        flag = true;
        currentFunc = 1;
        for (int i = 0; i < moveList.Count; i++)
        {
            var newPrefab = Instantiate(selectionPrefab, moveParent);
            movePrefabList.Add(newPrefab);
            int count = movePrefabList.Count - 1;
            int areaId = moveList[i].areaId;
            int eventId = moveList[i].newEventId;
            Sprite areaThumb = moveList[i].areaThumb;
            newPrefab.content.text = moveList[i].areaName;
            newPrefab.button.onClick.AddListener(() => SelectMove(count, areaId, eventId));
            // 定义 PointerEnter 事件
            EventTrigger.Entry entry = new EventTrigger.Entry
            {
                eventID = EventTriggerType.PointerEnter
            };
            if (areaThumb)
            {
                // 绑定回调方法
                entry.callback.AddListener((data) => ShowMoveAreaThumb(areaThumb));
                // 将事件添加到 EventTrigger
                newPrefab.GetComponent<EventTrigger>().triggers.Add(entry);
            }
            else
            {
                // 绑定回调方法
                entry.callback.AddListener((data) => ClearMoveAreaThumb());
                // 将事件添加到 EventTrigger
                newPrefab.GetComponent<EventTrigger>().triggers.Add(entry);
            }
        }
    }

    public void SelectMove(int prefabId, int areaId, int eventId)
    {
        currentFunc = -1;
        gameBaseController.btnCloseDetectiveMove.gameObject.SetActive(false);
        if (gameBaseController.gameType == 0) AudioManager.Instance.PlaySE(SEID.se_com_001);
        selectedPrefabId = prefabId;
        newAreaId = areaId;
        newEventId = eventId;
        for (int i = 0; i < movePrefabList.Count; i++)
        {
            if (i != prefabId)
            {
                movePrefabList[i].rectTransform.DOScale(0, .25f);
            }
        }
        movePrefabList[prefabId].btnBgLink.SetActive(false);
        movePrefabList[prefabId].btnBgHover.SetActive(false);
        movePrefabList[prefabId].btnBgActive.SetActive(true);
        movePrefabList[prefabId].button.enabled = false;
        movePrefabList[prefabId].GetComponent<EventTrigger>().enabled = false;
        movePrefabList[prefabId].GetComponent<StudioEventEmitter>().enabled = false;
        Invoke("SelectMoveDelay", .5f);
        Invoke("SelectMoveDelay2", 1f);
        Invoke("SelectMoveDelay3", 1.25f);
    }

    public void SelectMoveDelay()
    {
        blackCover.DOFade(0, 0);
        blackCover.gameObject.SetActive(true);
        blackCover.DOFade(1, .25f);
    }

    public void SelectMoveDelay2()
    {
        ClearMoveList();
        gameBaseController.actionMovePanel.gameObject.SetActive(false);
        gameBaseController.AreaID = newAreaId;
        gameBaseController.EventID = newEventId;
        gameBaseController.Proceed = true;
    }

    public void SelectMoveDelay3()
    {
        flag = false;
        blackCover.gameObject.SetActive(false);
        gameBaseController.btnOpenCourtRecords.gameObject.SetActive(true);
        gameBaseController.btnShowBacklog.gameObject.SetActive(true);
        gameBaseController.btnOptions.gameObject.SetActive(true);
        gameBaseController.ClickOverlay.SetActive(true);
    }

    public void CloseMove()
    {
        currentFunc = -1;
        ClearMoveAreaThumb();
        gameBaseController.btnCloseDetectiveMove.gameObject.SetActive(false);
        gameBaseController.actionMovePanel.DOFade(0, .25f);
        Invoke("ClearMoveList", .26f);
        Invoke("HideMovePanel", .27f);
    }

    public void ClearMoveList()
    {
        int i, j;
        j = movePrefabList.Count;
        for (i = 0; i < j; i++)
        {
            Destroy(movePrefabList[0].gameObject);
            movePrefabList.RemoveAt(0);
        }
    }

    public void HideMovePanel()
    {
        flag = false;
        gameBaseController.actionMovePanel.blocksRaycasts = false;
        gameBaseController.actionMovePanel.gameObject.SetActive(false);
    }

    public void OpenInvest(SpriteRenderer hideCharaSpr, GameObject investSpots)
    {
        hideCharaSpr.DOFade(0, .25f);
        hidedCharaSpr = hideCharaSpr;
        investSpots.SetActive(true);
        currentInvestSpots = investSpots;
        Cursor.lockState = CursorLockMode.Locked;
        Invoke("OpenInvestDelay", .25f);
    }

    public void OpenInvestDelay()
    {
        currentFunc = 0;
        Cursor.SetCursor(cursorIdle, new Vector2(29, 0), CursorMode.ForceSoftware);
        Cursor.lockState = CursorLockMode.None;
        if (currentBackgroundPos > 0 && backgroundSlideBtnLeftActivated)
        {
            backgroundSlideBtnLeft.gameObject.SetActive(true);
        }
        if (currentBackgroundPos < allBackgroundPos.Count - 1 && backgroundSlideBtnRightActivated)
        {
            backgroundSlideBtnRight.gameObject.SetActive(true);
        }
    }
    public void CloseInvest()
    {
        gameBaseController.btnCloseDetectiveInvest.gameObject.SetActive(false);
        backgroundSlideBtnLeft.gameObject.SetActive(false);
        backgroundSlideBtnRight.gameObject.SetActive(false);
        Cursor.SetCursor(null, Vector2.zero, CursorMode.Auto);
        currentFunc = -1;
        hidedCharaSpr.DOFade(1, .25f);
        hidedCharaSpr = null;
        currentInvestSpots.SetActive(false);
        currentInvestSpots = null;
    }
    public void HoverInvestSpot(int investId)
    {
        if (gameBaseController.completedInvest.Contains(investId))
        {
            Cursor.SetCursor(cursorChecked, new Vector2(29, 0), CursorMode.ForceSoftware);
        }
        else
        {
            Cursor.SetCursor(cursorFound, new Vector2(29, 0), CursorMode.ForceSoftware);
        }
    }
    public void ExitInvestSpot()
    {
        Cursor.SetCursor(cursorIdle, new Vector2(29, 0), CursorMode.ForceSoftware);
    }
    public void ClickInvestSpot(int eventId)
    {
        currentFunc = -1;
        gameBaseController.btnCloseDetectiveInvest.gameObject.SetActive(false);
        newEventId = eventId;
        AudioManager.Instance.PlaySE(SEID.se_com_001);
        GetCursorPos(out cp);
        lockMousePos = true;
        currentInvestSpots.SetActive(false);
        Invoke("ClickInvestSpotDelay", .25f);
    }
    public void ClickInvestSpotDelay()
    {
        lockMousePos = false;
        hidedCharaSpr.gameObject.SetActive(false);
        CloseInvest();
        flag = false;
        gameBaseController.EventID = newEventId;
        gameBaseController.Proceed = true;
    }
    public void BackgroundSlideLeft()
    {
        if (currentBackgroundPos > 0)
        {
            AudioManager.Instance.PlaySE(SEID.se_com_001);
            currentBackgroundPos -= 1;
            currentBackground.DOMoveX(allBackgroundPosSpr[currentBackgroundPos], 1f);
            currentBackgroundSpots.DOLocalMoveX(allBackgroundPos[currentBackgroundPos], 1f);
            if (backgroundSlideBtnRightActivated)
            {
                backgroundSlideBtnRight.gameObject.SetActive(true);
            }
            if (currentBackgroundPos == 0)
            {
                backgroundSlideBtnLeft.gameObject.SetActive(false);
            }
        }
    }
    public void BackgroundSlideRight()
    {
        if (currentBackgroundPos < allBackgroundPos.Count - 1)
        {
            AudioManager.Instance.PlaySE(SEID.se_com_001);
            currentBackgroundPos += 1;
            currentBackground.DOMoveX(allBackgroundPosSpr[currentBackgroundPos], 1f);
            currentBackgroundSpots.DOLocalMoveX(allBackgroundPos[currentBackgroundPos], 1f);
            if (backgroundSlideBtnLeftActivated)
            {
                backgroundSlideBtnLeft.gameObject.SetActive(true);
            }
            if (currentBackgroundPos == allBackgroundPos.Count - 1)
            {
                backgroundSlideBtnRight.gameObject.SetActive(false);
            }
        }
    }
}