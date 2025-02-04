using UnityEngine;
using UnityEngine.Events;

public class BallController : MonoBehaviour
{
    [SerializeField] private float force = 1f;
    [SerializeField] private InputManager inputManager;
    private Rigidbody ballRB;
    void Start()
    {
        ballRB = GetComponent<Rigidbody>();
        inputManager.OnSpacePressed.AddListener(LaunchBall);
    }

    void Update()
    {
        
    }

    private void LaunchBall()
    {
        ballRB.AddForce(transform.forward * force, ForceMode.Impulse);
    }
}
