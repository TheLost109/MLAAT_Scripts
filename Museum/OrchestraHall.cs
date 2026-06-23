using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class OrchestraHall : MonoBehaviour
{
    private string currentMusic = "";
    public TMP_Text MusicAlbum;
    public TMP_Text MusicArtist;
    public GameObject Music1Checkmark;
    public GameObject Music2Checkmark;
    public GameObject Music3Checkmark;
    public GameObject GyakutenSaibanSoundBox;
    public GameObject TrueBlueScootaloo;

    void Start ()
    {

    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Z) || Input.GetKeyDown(KeyCode.Escape) || Input.GetMouseButtonDown(1))
        {
            ExitOrchestra();
        }

        if (currentMusic == "" || currentMusic == null)
        {
            ClearMusicCheckmarks();
            ClearAllAlbums();
            MusicAlbum.text = "";
            MusicArtist.text = "";
        }
        else if (currentMusic == "PWObjection2001")
        {
            Music1Checkmark.SetActive(true);
            ClearAllAlbums();
            GyakutenSaibanSoundBox.SetActive(true);
            MusicAlbum.text = "专辑：逆转裁判 SOUND BOX";
            MusicArtist.text = "艺术家：杉森雅和";
        }
        else if (currentMusic == "MayaFey2001")
        {
            Music2Checkmark.SetActive(true);
            ClearAllAlbums();
            GyakutenSaibanSoundBox.SetActive(true);
            MusicAlbum.text = "专辑：逆转裁判 SOUND BOX";
            MusicArtist.text = "艺术家：杉森雅和";
        }
        else if (currentMusic == "WaitASecond")
        {
            Music3Checkmark.SetActive(true);
            ClearAllAlbums();
            TrueBlueScootaloo.SetActive(true);
            MusicAlbum.text = "专辑：True Blue Scootaloo ~ The Music Behind the Mystery";
            MusicArtist.text = "艺术家：Trot Pilgrim";
        }
    }

    public void ExitOrchestra()
    {
        AudioManager.Instance.PlaySE(SEID.cancel);
        if (currentMusic == "")
        {
            AudioManager.Instance.BGMFadeIn("MelodyVolume", 1f);
        }
        else
        {
            AudioManager.Instance.BGMFadeIn("MelodyVolume", 0f);
            AudioManager.Instance.PlayBGM(BGMID.ANewEraBegins2024);
            currentMusic = "";
        }
        ChapSelectScripts ChapSelectScript = GameObject.Find("ChapSelectScript").GetComponent<ChapSelectScripts>();
        ChapSelectScript.InOrchestra = false;
        SceneManager.UnloadSceneAsync("OrchestraHall");
    }

    public void PlayMusic(string MusicName)
    {
        ClearMusicCheckmarks();
        if (MusicName == "MayaFey2001")
        {
            currentMusic = "MayaFey2001";
            AudioManager.Instance.PlayBGM(BGMID.MayaFey2001);
        }
        else if (MusicName == "PWObjection2001")
        {
            currentMusic = "PWObjection2001";
            AudioManager.Instance.PlayBGM(BGMID.PWObjection2001);
        }
        else if (MusicName == "WaitASecond")
        {
            currentMusic = "WaitASecond";
            AudioManager.Instance.PlayBGM(BGMID.WaitASecond);
        }
    }

    public void ClearMusicCheckmarks()
    {
        Music1Checkmark.SetActive(false);
        Music2Checkmark.SetActive(false);
        Music3Checkmark.SetActive(false);
    }
    public void ClearAllAlbums()
    {
        GyakutenSaibanSoundBox.SetActive(false);
        TrueBlueScootaloo.SetActive(false);
    }
}
