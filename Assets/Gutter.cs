using UnityEngine;

public class Gutter : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    public void OnTriggerEnter(Collider triggeredBody)
    {
        if (triggeredBody.CompareTag("Ball"))
        {
            //Store RigidBody of ball in ballRigidBody
            Rigidbody ballRigidBody = triggeredBody.GetComponent<Rigidbody>();
            //Store velocity magnitude before resetting the velocity
            float velocityMagnitude = ballRigidBody.linearVelocity.magnitude;
            //Reset linear and angular velocity because ball rotates on ground when moving
            ballRigidBody.linearVelocity = Vector3.zero;
            ballRigidBody.angularVelocity = Vector3.zero;
            //Adds the force that propels the ball to the direction of the gutter
            ballRigidBody.AddForce(transform.forward * velocityMagnitude, ForceMode.VelocityChange);
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
