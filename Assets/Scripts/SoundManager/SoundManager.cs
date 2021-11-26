using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    private static SoundManager _instance;

    public static SoundManager Instance => _instance;

    private void Awake()
    {
        if (_instance != null)
        {
            Destroy(gameObject);
            return;
        }
        _instance = this;
        DontDestroyOnLoad(gameObject);
    }
    /*
    private void PlaySoundInternal(string soundName, bool pausable)
    {
        if (string.IsNullOrEmpty(soundName))
        {
            Debug.Log("Sound null or empty");
            return;
        }

        int sameCountGuard = 0;
        foreach (AudioSourse audioSource in _sounds)
        {
            if (audioSource.clip.name == soundName)
                sameCountGuard++;
        }

        if (_sounds.Count > 16)
        {
            Debug.Log("To much sounds");
            return;
        }
        StartCoroutine(PlaySoundInternalSoon(soundName, pausable));
    }

    IEnumerable PlaySoundInternalSoon(string soundName, bool pausable)
    {
        ResourceRequest request = LoadClipAsync("Sounds/" + soundName);
        while (!request.isDone)
        {
            yield return null;
        }

        AudioClip soundClip = (AudioClip)request.asset;
        if (null == soundClip)
            Debug.Log("Sound not loaded: " + soundName);
    }

    GameObject sound = (GameObject)Instantiate(soundPrefab);
    sound.transform.parent = transform;

    AudioSource soundSource = sound.GetComponent<AudioSource>();
    soundSource.mute = _mutedSound;
    soundSource.volume = _volumeSound* DefaultSoumdVolume;
    */
}
