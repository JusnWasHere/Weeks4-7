using UnityEngine;
using UnityEngine.UI;

public class Bullet : MonoBehaviour
{
    public float speed;
    public GameObject turret;
    public Vector3 direction;
    Vector3 position;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        direction = turret.transform.up;
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += direction * speed * Time.deltaTime;
        position = Camera.main.WorldToScreenPoint(transform.position);

        if (position.x > Screen.width || position.y > Screen.height)
        {
            Destroy(gameObject);
            //Debug.Log("out of bounds");
        }
        
    }
}
