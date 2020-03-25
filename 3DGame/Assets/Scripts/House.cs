using UnityEngine;

public class House : MonoBehaviour
{
    /// <summary>
    /// 是否掉落中
    /// </summary>
    [HideInInspector]
    public bool down;

    /// <summary>
    /// 房子管理器
    /// </summary>
    private HouseManager houseManager;

    private void Start()
    {
        houseManager = FindObjectOfType<HouseManager>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (down && other.tag == "失敗區域")
        {
            houseManager.Invoke("GameOver", 0.5f);
        }
    }
}
