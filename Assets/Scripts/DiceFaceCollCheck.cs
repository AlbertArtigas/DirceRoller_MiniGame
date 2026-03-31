using UnityEngine;

public class DiceFaceCollCheck : MonoBehaviour
{
    public DiceResultCheck resultCheck;
    void OnTriggerEnter(Collider other)
    {
        resultCheck.CheckResult(gameObject.name);
    }
}
