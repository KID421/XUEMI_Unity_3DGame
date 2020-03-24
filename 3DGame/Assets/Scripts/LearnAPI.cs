using UnityEngine;

public class LearnAPI : MonoBehaviour
{
    public Light myLight;

    private void Start()
    {
        print(Random.value);
        print(Random.Range(0f, 10f));
        print(Random.Range(0, 10));

        myLight.color = Color.blue;

        myLight.Reset();
    }
}
