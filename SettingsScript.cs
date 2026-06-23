using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.Rendering.Universal;
using FMODUnity;
using FMOD.Studio;

public class SettingsScript : MonoBehaviour
{
    // 设置数据的版本号，防止冲突
    public string dataVersion = "alpha-0.3";

    // 是否首次运行游戏
    public bool FirstRun = true;

    // 语言设置 相关
    public string Language = "Chinese";
    public string VoiceLang = "Japanese";

    // BGM & SE 音量
    //public AudioMixer AudioMixer;
    public float BGMVol = 5;
    public float SEVol = 5;

    // PC设定
    public UniversalRenderPipelineAsset URPAsset;
    public int MSAA = 0;
    public bool VSyncEnabled = true;
    public int MaxFPS = 60;

    // 接下来要读取的存档槽ID
    public int loadSlotId = -1;

    // 是否挂起设置面板
    public bool Halt = false;

    public int CurrentGame = 0;

    // 单例模式
    public static SettingsScript Instance;
    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
        }
        else
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }

    private void Start()
    {
        SetBGMVolume(BGMVol);
        SetSEVolume(SEVol);
        SetMSAA(MSAA);
        SetVSync(VSyncEnabled);
        SetMaxFPS(MaxFPS);
    }

    private void Update()
    {

    }

    ///<summary>
    ///    https://www.cnblogs.com/alanshreck/p/14746347.html
    ///</summary>
    // 控制BGM音量
    public void SetBGMVolume(float v)
    {
        BGMVol = v;
        if (v == 5)
        {
            //AudioMixer.SetFloat("BGM", 0);
            RuntimeManager.GetBus("bus:/BGM").setVolume(1f);

        }
        else if (v == 4)
        {
            //AudioMixer.SetFloat("BGM", -8);
            RuntimeManager.GetBus("bus:/BGM").setVolume(0.8f);
        }
        else if (v == 3)
        {
            //AudioMixer.SetFloat("BGM", -16);
            RuntimeManager.GetBus("bus:/BGM").setVolume(0.6f);
        }
        else if (v == 2)
        {
            //AudioMixer.SetFloat("BGM", -24);
            RuntimeManager.GetBus("bus:/BGM").setVolume(0.4f);
        }
        else if (v == 1)
        {
            //AudioMixer.SetFloat("BGM", -32);
            RuntimeManager.GetBus("bus:/BGM").setVolume(0.2f);
        }
        else if (v == 0)
        {
            //AudioMixer.SetFloat("BGM", -80);
            RuntimeManager.GetBus("bus:/BGM").setVolume(0f);
        }
    }

    // 控制SE音量
    public void SetSEVolume(float v)
    {
        SEVol = v;
        if (v == 5)
        {
            //AudioMixer.SetFloat("SE", 0);
            RuntimeManager.GetBus("bus:/SE").setVolume(1f);
        }
        else if (v == 4)
        {
            //AudioMixer.SetFloat("SE", -8);
            RuntimeManager.GetBus("bus:/SE").setVolume(0.8f);
        }
        else if (v == 3)
        {
            //AudioMixer.SetFloat("SE", -16);
            RuntimeManager.GetBus("bus:/SE").setVolume(0.6f);
        }
        else if (v == 2)
        {
            //AudioMixer.SetFloat("SE", -24);
            RuntimeManager.GetBus("bus:/SE").setVolume(0.4f);
        }
        else if (v == 1)
        {
            //AudioMixer.SetFloat("SE", -32);
            RuntimeManager.GetBus("bus:/SE").setVolume(0.2f);
        }
        else if (v == 0)
        {
            //AudioMixer.SetFloat("SE", -80);
            RuntimeManager.GetBus("bus:/SE").setVolume(0f);
        }
    }
    // 设置MSAA
    public void SetMSAA(int MSAA)
    {
        URPAsset.msaaSampleCount = MSAA;
    }
    // 设置垂直同步
    public void SetVSync(bool VSyncEnabled)
    {
        if(VSyncEnabled){
            QualitySettings.vSyncCount = 1;
        }
        else
        {
            QualitySettings.vSyncCount = 0;
        }
    }
    // 设置帧数
    public void SetMaxFPS(int fps)
    {
        Application.targetFrameRate = fps;
    }
}
