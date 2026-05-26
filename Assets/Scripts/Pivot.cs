using UnityEngine;
using UnityEngine.InputSystem;

public class Pivot : MonoBehaviour
{

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {


        Vector3 currentMousePosition = Mouse.current.position.ReadValue();
        Vector3 worldMousePosition = Camera.main.ScreenToWorldPoint(currentMousePosition);
        worldMousePosition.z = 0f;


        bool leftMouse = Mouse.current.leftButton.IsPressed();

        bool leftMousePressed = Mouse.current.leftButton.wasPressedThisFrame;
        bool leftMouseReleased = Mouse.current.leftButton.wasReleasedThisFrame;

        //Direction to B from A: B-A
        Vector3 directionToTarget = worldMousePosition - transform.position;
        transform.right = directionToTarget;

    }
}
