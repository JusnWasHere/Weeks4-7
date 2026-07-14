using UnityEngine;
using UnityEngine.UI;

public class Bullet : MonoBehaviour
{
    public float speed;//speed of bullet
    public GameObject turret;//turret game object
    public Vector3 direction;//direction bullet should travel in
    Vector3 position;//variable to convert transform pos to screen space

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        direction = turret.transform.up;//makes the directions its transform.up value(green arrow)
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += direction * speed * Time.deltaTime;//moves bullet in direction using set speed
        position = Camera.main.WorldToScreenPoint(transform.position);//converts world space pos to screen space pos
        if (Mathf.Abs(position.x) > Screen.width || Mathf.Abs(position.y) > Screen.height)//checks if bullet has gone off screen. uses math.abs and screen width and screen height so I dont have to check negatives and screen can be any size
        {
            Destroy(gameObject);//destroys itself
            //Debug.Log("out of bounds");
        }

    }
}
