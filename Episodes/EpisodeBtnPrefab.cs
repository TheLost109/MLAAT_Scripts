using DG.Tweening;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class EpisodeBtnPrefab : MonoBehaviour
{
    public Button btn;
    public GameObject btnImgLink;
    public RectTransform btnImgHover;
    public TextMeshProUGUI episodeName;

    public void MouseEnter()
    {
        btnImgHover.gameObject.SetActive(true);
        btnImgLink.SetActive(false);
        btnImgHover.DOSizeDelta(new Vector2(788, 74), .25f).SetId("hoverTween");
        episodeName.color = new Color32(0, 8, 26, 255);
    }
    public void MouseExit()
    {
        DOTween.Kill("hoverTween");
        btnImgLink.SetActive(true);
        btnImgHover.gameObject.SetActive(false);
        btnImgHover.DOSizeDelta(new Vector2(758, 74), 0);
        episodeName.color = new Color32(255, 255, 255, 255);
    }
}
