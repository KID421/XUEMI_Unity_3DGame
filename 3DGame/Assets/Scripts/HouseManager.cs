using UnityEngine;
using UnityEngine.UI;

public class HouseManager : MonoBehaviour
{
    [Header("懸吊房子物件")]
    public Transform pointSuspention;
    [Header("晃動位置")]
    public Transform pointShake;
    [Header("晃動位置剛體")]
    public Rigidbody pointShakeRig;
    [Header("房子預製物陣列")]
    public GameObject[] houses;
    [Header("晃動力道"), Range(0.5f, 10)]
    public float shakePower = 2;
    [Header("攝影機")]
    public Transform myCamera;
    [Header("檢查遊戲失敗")]
    public Transform checkWall;
    [Header("遊戲結算")]
    public GameObject final;
    [Header("房子數量文字介面")]
    public Text textHouseCount;
    [Header("最佳數量文字介面")]
    public Text textBest;
    [Header("本次數量文字介面")]
    public Text textCurrent;
    [Header("生成房子音效")]
    public AudioClip soundCreateHouse;
    [Header("蓋房子音樂")]
    public AudioClip soundBGMStart;
    [Header("遊戲結束音樂")]
    public AudioClip soundBGMGameOver;

    /// <summary>
    /// 用來儲存生成的房子物件
    /// </summary>
    private GameObject tempHouse;
    /// <summary>
    /// 開始蓋房子
    /// </summary>
    private bool startHouse;
    /// <summary>
    /// 房子總高度
    /// </summary>
    private float height;
    /// <summary>
    /// 第一個房子
    /// </summary>
    private Transform firstHouse;
    /// <summary>
    /// 房子總數
    /// </summary>
    private int count;
    /// <summary>
    /// 音效管理器
    /// </summary>
    private SoundManager soundManager;

    private void Start()
    {
        soundManager = FindObjectOfType<SoundManager>();
        soundManager.PlayBGM(soundBGMStart, true);
        CreateHouse();
        InvokeRepeating("Shake", 0, 3);
    }

    /// <summary>
    /// 建立房子
    /// </summary>
    private void CreateHouse()
    {
        tempHouse = Instantiate(houses[0], pointShake);
        soundManager.PlaySound(soundCreateHouse);
    }

    /// <summary>
    /// 晃動房子
    /// </summary>
    private void Shake()
    {
        pointShakeRig.velocity = pointShake.right * shakePower;
    }

    /// <summary>
    /// 蓋房子
    /// </summary>
    public void HouseDown()
    {
        tempHouse.transform.SetParent(null);
        tempHouse.GetComponent<Rigidbody>().isKinematic = false;
        tempHouse.GetComponent<House>().down = true;
        Invoke("CreateHouse", 1);
        startHouse = true;
        height += tempHouse.GetComponent<BoxCollider>().size.y * tempHouse.transform.localScale.y;

        if (!firstHouse)
        {
            firstHouse = tempHouse.transform;
            Invoke("CreateCheckWall", 1.2f);
            Destroy(firstHouse.GetComponent<House>());
        }

        count++;
        textHouseCount.text = "房子數量：" + count;
    }

    private void Update()
    {
        Track();
    }

    /// <summary>
    /// 攝影機追蹤
    /// 懸吊房子物件位移
    /// </summary>
    private void Track()
    {
        if (startHouse)
        {
            Vector3 posCam = new Vector3(0, height, -10);
            myCamera.position = Vector3.Lerp(myCamera.position, posCam, 0.3f * 10 * Time.deltaTime);

            Vector3 posSus = new Vector3(0, height + 6, 0);
            pointSuspention.position = Vector3.Lerp(pointSuspention.position, posSus, 0.3f * 10 * Time.deltaTime);
        }
    }

    /// <summary>
    /// 建立檢查遊戲失敗牆壁
    /// </summary>
    private void CreateCheckWall()
    {
        Instantiate(checkWall, firstHouse.position, Quaternion.identity);
    }

    /// <summary>
    /// 遊戲結束：顯示結算畫面
    /// </summary>
    public void GameOver()
    {
        final.SetActive(true);

        textCurrent.text = "本次數量：" + count;

        if (count > PlayerPrefs.GetInt("最佳數量"))
            PlayerPrefs.SetInt("最佳數量", count);

        textBest.text = "最佳數量：" + PlayerPrefs.GetInt("最佳數量");

        soundManager.PlayBGM(soundBGMGameOver, false);
    }
}
