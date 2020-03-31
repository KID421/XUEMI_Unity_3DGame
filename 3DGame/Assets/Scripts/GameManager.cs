using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    /// <summary>
    /// 離開遊戲
    /// </summary>
    public void Quit()
    {
        Application.Quit();
    }

    /// <summary>
    /// 重新遊戲
    /// </summary>
    /// <param name="scene">想要重新玩的場景名稱</param>
    public void Replay(string scene)
    {
        SceneManager.LoadScene(scene);
    }
}
