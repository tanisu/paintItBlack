using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{

    [SerializeField] public AudioSource bgmAudioSource;
    [SerializeField] public AudioSource seAudioSource;
    [SerializeField] List<SESoundData> SESoundDatas;
    [SerializeField] List<BGMSoundData> BGMSoundDatas;
    public float mastarVolume = 1;
    public float bgmVolume = 1;
    public float playVolume = 1;
    public float seVolume = 1;
    public static SoundManager I { get; private set; }
    private void Awake()
    {
        if (I == null)
        {
            I = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        PlayBGM(BGMSoundData.BGM.GAME);
    }

    public void PlayBGM(BGMSoundData.BGM bgm)
    {
        BGMSoundData data = BGMSoundDatas.Find(data => data.bgm == bgm);
        bgmAudioSource.clip = data.audioClip;
        bgmAudioSource.volume = data.volume * bgmVolume * mastarVolume;

        bgmAudioSource.Play();
    }

    public void PlaySE(SESoundData.SE se)
    {
        SESoundData data = SESoundDatas.Find(data => data.se == se);
        seAudioSource.PlayOneShot(data.audioClip);
    }
}


[System.Serializable]
public class BGMSoundData
{
    public enum BGM
    {
        GAME
    }

    public BGM bgm;
    public AudioClip audioClip;
    [Range(0, 1)]
    public float volume = 1;
}

[System.Serializable]
public class SESoundData
{
    public enum SE
    {
        HIT,
        MISS
    }

    public SE se;
    public AudioClip audioClip;
    [Range(0, 1)]
    public float volume = 1;
}