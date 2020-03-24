using UnityEngine;

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

    private void Start()
    {
        CreateHouse();
        InvokeRepeating("Shake", 0, 3);
    }

    /// <summary>
    /// 建立房子
    /// </summary>
    private void CreateHouse()
    {
        tempHouse = Instantiate(houses[0], pointShake);
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
        Invoke("CreateHouse", 1);
        startHouse = true;
        height += tempHouse.GetComponent<BoxCollider>().size.y * tempHouse.transform.localScale.y;
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
}
