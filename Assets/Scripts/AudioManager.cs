using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance { get; private set; }

    [Header("Sources")]
    public AudioSource MusicSource;
    public AudioSource SFXSource;

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);
    }

    public void PlayMusic(AudioClip clip, bool loop = true)
    {
        if (MusicSource.clip == clip) return;
        MusicSource.clip = clip;
        MusicSource.loop = loop;
        MusicSource.Play();
    }

    public void PlaySFX(AudioClip clip)
    {
        SFXSource.PlayOneShot(clip);
    }
    public void PlaySFX(AudioClip clip, bool randomizePitch)
    {
        SFXSource.pitch = Random.Range(0.95f, 1.05f);
        SFXSource.PlayOneShot(clip);
    }

    public void SetMusicVolume(float volume)
    {
        MusicSource.volume = Mathf.Clamp01(volume);
    }
    public void SetSFXVolume(float volume)
    {
        SFXSource.volume = Mathf.Clamp01(volume);
    }

    public void MuteMusic() 
    {
        if (!MusicSource)
            return;

        if (MusicSource.volume > 0)
            MusicSource.volume = 0;
        else
            MusicSource.volume = 0.75f;
    }
    public void MuteSFX()
    {
        if (!SFXSource)
            return;

        if (SFXSource.volume > 0)
            SFXSource.volume = 0;
        else
            SFXSource.volume = 0.75f;
    }

    public void StopMusic()
    {
        MusicSource.Stop();
    }
}