using UnityEngine;

public class Runner : MonoBehaviour
{
    public float speed;
    bool isMoving = false;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
        if (isMoving)
        {
            transform.position += Vector3.right * speed * Time.deltaTime;

        }
    }

    public void onMoveClick()
    {
        isMoving = true;
    
    }

    public void onStopClick()
    {
        isMoving = false;

    }

    public void onFlipClick()
    {
        speed *= -1;
    }
}