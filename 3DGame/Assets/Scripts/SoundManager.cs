using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class SoundManager : MonoBehaviour
{
    /// <summary>
    /// 音效來源：喇叭
    /// </summary>
    private AudioSource aud;

    private void Start()
    {
        // 音效來源 = 取得元件<音效來源>()
        aud = GetComponent<AudioSource>();
    }

    /// <summary>
    /// 播放指定音效
    /// </summary>
    /// <param name="sound">想要播放的音效</param>
    public void PlaySound(AudioClip sound)
    {
        aud.PlayOneShot(sound);
    }

    /// <summary>
    /// 播放背景音樂
    /// </summary>
    /// <param name="sound">想要播放的音樂</param>
    /// <param name="loop">是否需要循環</param>
    public void PlayBGM(AudioClip sound, bool loop)
    {
        aud.loop = loop;
        aud.clip = sound;
        aud.Play();
    }
}
