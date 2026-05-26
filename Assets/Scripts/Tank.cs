using UnityEngine;
using UnityEngine.InputSystem;

public class Tank : MonoBehaviour
{
    public float moveSpeed;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        bool leftKey = Keyboard.current.leftArrowKey.isPressed;
        bool rightKey = Keyboard.current.rightArrowKey.isPressed;

        if(leftKey)
        {
            transform.position -= transform.right * moveSpeed * Time.deltaTime;
        }

        if (rightKey)
        {
            transform.position += transform.right * moveSpeed * Time.deltaTime;
        }

    }
}
