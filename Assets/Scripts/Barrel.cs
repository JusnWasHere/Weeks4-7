 using UnityEngine;
using UnityEngine.InputSystem;

public class Barrel : MonoBehaviour
{
    public Camera gameCamera;

    Transform target;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {


        Vector3 mousePosition = Mouse.current.position.ReadValue();
        Vector3 worldMousePosition = gameCamera.ScreenToWorldPoint(mousePosition);
        worldMousePosition.z = 0f;

        Vector3 directionToTarget = target.position - transform.position;
        transform.up = directionToTarget;

    }
}
