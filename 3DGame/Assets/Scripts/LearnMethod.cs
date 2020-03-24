using UnityEngine;

public class LearnMethod : MonoBehaviour
{
    // 事件：開始 - 遊戲開始時執行一次
    private void Start()
    {
        MyMethod();             // 呼叫函式
        HelloPeople("小白");
        Walk("右邊", 60);
        Jump("強力跳躍", 9.9f);

        Shoot();
        Shoot("火箭");
    }

    // 修飾詞 傳回類型 函式名稱 (參數) { 敘述 }
    public void MyMethod()
    {
        print("哈囉，我是函式~");
    }

    public void Hello()
    {
        print("哈囉~");
    }

    public void HelloPeople(string people)
    {
        print("哈囉：" + people);
    }

    public void Walk(string direction, int speed)
    {
        print("走路方向：" + direction);
        print("走路速度：" + speed);
    }

    public void Jump(string type, float height = 3.9f)
    {
        print("跳躍方式：" + type);
        print("跳躍高度：" + height);
    }

    /// <summary>
    /// 發射子彈物件
    /// </summary>
    public void Shoot()
    {
        print("發射：子彈");
    }

    /// <summary>
    /// 發射指定物件
    /// </summary>
    /// <param name="prop">指定物件</param>
    public void Shoot(string prop)
    {
        print("發射：" + prop);
    }
}
