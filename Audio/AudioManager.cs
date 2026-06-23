using UnityEngine;
using FMODUnity;
using FMOD.Studio;
using System.Collections;

public class AudioManager : MonoBehaviour
{
    private string currentBGM = "";
    private EventInstance BGM;
    private IEnumerator coroutineFadeIn;
    private IEnumerator coroutineFadeOut;

    // 单例模式
    public static AudioManager Instance;
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

    void Start()
    {
        
    }

    void Update()
    {
        
    }

    public void StopBGM(bool fade)
    {
        StopCoroutines();
        if (!fade)
        {
            BGM.stop(FMOD.Studio.STOP_MODE.IMMEDIATE);
        }
        else
        {
            BGM.stop(FMOD.Studio.STOP_MODE.ALLOWFADEOUT);
        }
        BGM.release();
        currentBGM = "";
    }

    public void PlayBGM(string bgmName)
    {
        if (currentBGM != bgmName)
        {
            if (currentBGM != "") StopBGM(false);
            BGM = RuntimeManager.CreateInstance(bgmName);
            BGM.start();
            currentBGM = bgmName;
        }
    }

    public void PlaySE(string seName)
    {
        EventInstance SE;
        SE = RuntimeManager.CreateInstance(seName);
        SE.start();
        SE.release();
    }

    public void BGMFadeIn(string paramName, float durtime)
    {
        StopCoroutines();
        coroutineFadeIn = FadeIn(paramName, durtime);
        StartCoroutine(coroutineFadeIn);
    }

    public void BGMFadeOut(string paramName, float durtime)
    {
        StopCoroutines();
        coroutineFadeOut = FadeOut(paramName, durtime);
        StartCoroutine(coroutineFadeOut);
    }

    IEnumerator FadeIn(string paramName, float durtime)
    {
        float time = 0f;

        while (time < durtime)
        {
            time += Time.deltaTime;
            float value = Mathf.Clamp01(time / durtime);

            BGM.setParameterByName(paramName, value);

            yield return null;
        }

        BGM.setParameterByName(paramName, 1f);
    }

    IEnumerator FadeOut(string paramName, float durtime)
    {
        float time = 0f;

        while (time < durtime)
        {
            time += Time.deltaTime;
            float value = 1f - Mathf.Clamp01(time / durtime);

            BGM.setParameterByName(paramName, value);

            yield return null;
        }

        BGM.setParameterByName(paramName, 0f);
    }

    public void StopCoroutines()
    {
        if (coroutineFadeIn != null)
        {
            StopCoroutine(coroutineFadeIn);
        }
        if (coroutineFadeOut != null)
        {
            StopCoroutine(coroutineFadeOut);
        }
    }

    public void MuteBGM()
    {
        BGM.setVolume(0f);
    }

    public void UnmuteBGM()
    {
        BGM.setVolume(1f);
    }

}