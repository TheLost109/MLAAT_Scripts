using UnityEngine;

public class BacklogSystem : MonoBehaviour
{
    public GameBaseController gameMainScript;

    public GameObject backlogPanel;
    public Transform backlogContent;
    public BacklogItem backlogPrefab;
    [HideInInspector]
    public bool flag = false;

    void Start()
    {

    }
    void Update()
    {

    }

    public void ShowBacklog()
    {
        foreach(Backlog item in gameMainScript.backlogList)
        {
            var newPrefab = backlogPrefab;
            Color fontColor = new Color(1, 1, 1, 1);
            newPrefab.backlogItemName.text = item.name;
            newPrefab.backlogItemContent.text = item.content;
            ColorUtility.TryParseHtmlString(item.color, out fontColor);
            newPrefab.backlogItemContent.color = fontColor;
            Instantiate(newPrefab, backlogContent);
        }
        backlogPanel.SetActive(true);
        flag = true;
    }

    public void HideBacklog()
    {
        int i;
        for (i = backlogContent.childCount - 1; i >= 0; i--)
        {
            Destroy(backlogContent.GetChild(i).gameObject);
        }
        backlogPanel.SetActive(false);
        flag = false;
    }
}