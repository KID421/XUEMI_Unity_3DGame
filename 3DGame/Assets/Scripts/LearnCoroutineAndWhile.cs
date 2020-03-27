using UnityEngine;
using System.Collections;

public class LearnCoroutineAndWhile : MonoBehaviour
{
    public IEnumerator CoroutineMethod()
    {
        print("嗨，我是第一段");
        yield return new WaitForSeconds(2);
        print("兩秒後會執行");
    }

    private void Start()
    {
        StartCoroutine(CoroutineMethod());

        int count = 1;

        while (count < 10)
        {
            print(count);
            count++;
        }

        StartCoroutine(CreateEnemy(10));
    }

    private IEnumerator CreateEnemy(int enemyCount)
    {
        int enemy = 1;

        while (enemy <= enemyCount)
        {
            print("生成怪物，編號為：" + enemy);
            enemy++;
            yield return new WaitForSeconds(0.5f);
        }
    }
}
