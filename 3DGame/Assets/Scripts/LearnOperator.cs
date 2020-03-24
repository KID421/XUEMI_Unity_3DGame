using UnityEngine;

public class LearnOperator : MonoBehaviour
{
    public int A = 10, B = 3;

    private void Start()
    {
        print(A > B);       // T
        print(A < B);       // F
        print(A >= B);      // T
        print(A <= B);      // F
        print(A == B);      // F
        print(A != B);      // T

        print(true && true);    // T
        print(true && false);   // F
        print(false && true);   // F
        print(false && false);  // F

        print(true || true);    // T
        print(true || false);   // T
        print(false || true);   // T
        print(false || false);  // F

        print(!true);           // F
        print(!false);          // T
    }
}
