using UnityEngine;
using System;
using UnityEngine.Events;

public class InputManager : MonoBehaviour
{
    public UnityEvent<Vector2> OnMove = new UnityEvent<Vector2>();
    public UnityEvent OnSpacePressed = new UnityEvent();
    void Start()
    {
        
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space)) {
            OnSpacePressed.Invoke();
        }
        Vector2 input = Vector2.zero;
        if (Input.GetKeyUp(KeyCode.A))
        {
            input += Vector2.left;
        }
        if (Input.GetKeyUp(KeyCode.D))
        {
            input += Vector2.right;
        }
        OnMove?.Invoke(input);
    }
}
