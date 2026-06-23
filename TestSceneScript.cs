using UnityEngine;
using FMODUnity;
using FMOD.Studio;
using System.Collections;
using DG.Tweening;

public class TestSceneScript : MonoBehaviour
{
    public Camera mainCamera;
    public EventInstance Music;
    public bool IsFadeIn = false;
    void Start()
    {
        Music = RuntimeManager.CreateInstance("event:/BGM/MLAAT/A New Era Begins 2024");
        //Music.start();
    }

    void Update()
    {

    }

    public void MelodyFade()
    {
        StopCoroutine(MelodyFadeIn());
        StopCoroutine(MelodyFadeOut());
        if (IsFadeIn)
        {
            StartCoroutine(MelodyFadeIn());
            IsFadeIn = false;
        }
        else
        {
            StartCoroutine(MelodyFadeOut());
            IsFadeIn = true;
        }
    }

    IEnumerator MelodyFadeIn()
    {
        float time = 0f;

        while (time < 1f)
        {
            time += Time.deltaTime;
            float value = Mathf.Clamp01(time / 1f);

            Music.setParameterByName("MelodyVolume", value);

            yield return null;
        }

        Music.setParameterByName("MelodyVolume", 1f);
    }

    IEnumerator MelodyFadeOut()
    {
        float time = 0f;

        while (time < 2f)
        {
            time += Time.deltaTime;
            float value = 1f - Mathf.Clamp01(time / 2f);

            Music.setParameterByName("MelodyVolume", value);

            yield return null;
        }

        Music.setParameterByName("MelodyVolume", 0f);
    }
    public void CameraShake()
    {
        mainCamera.DOShakePosition(1.33f, new Vector3(.5f, .05f, 0), 10, 90, false, ShakeRandomnessMode.Harmonic);
    }
}