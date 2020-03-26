using UnityEngine;

public class HouseSound : MonoBehaviour
{
    [Header("房子碰撞音效")]
    public AudioClip soundHit;

    /// <summary>
    /// 音效管理器
    /// </summary>
    private SoundManager soundManager;

    private void Start()
    {
        soundManager = FindObjectOfType<SoundManager>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "房子" || collision.gameObject.name == "地板")
        {
            soundManager.PlaySound(soundHit);
        }
    }
}
