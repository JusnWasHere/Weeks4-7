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

        //Direction to B from A: B-A
        Vector3 directionToTarget = worldMousePosition - transform.position;
        transform.right = directionToTarget;

    }
}
