using UnityEngine;

public class DicePhysics : MonoBehaviour
{

    Rigidbody rb;
    Quaternion initialRotation;
    Vector3 initialAngularVelocity;
    Vector3 initialVelocity;
    void Start()
    {
        RandomizeInitialState();

        rb = GetComponent<Rigidbody>();
        transform.rotation = initialRotation;
        rb.linearVelocity = initialVelocity;
        rb.angularVelocity = initialAngularVelocity;
    }

    void Update()
    {
        
    }

    void RandomizeInitialState()
    {
        initialRotation = Random.rotation;
        initialAngularVelocity = new Vector3(
            Random.Range(-20f, 20f),
            Random.Range(-20f, 20f),
            Random.Range(-20f, 20f)
        );
        initialVelocity = new Vector3(
            Random.Range(-5f, 5f),
            Random.Range(-20f, -5f),
            Random.Range(10f, 40f)
        );
    }

    void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("KillBox"))
        {
            GetComponent<DiceResultCheck>().KillDice();           
        }
    }
}
