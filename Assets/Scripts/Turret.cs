using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class Turret : MonoBehaviour
{
    public float speed;

    Vector3 currentRotation;

    public GameObject bullet;
    public Bullet bulletScript;

    public List<GameObject> bullets;

    public int killCount = 0;
    public TMP_Text killCountText;

    private void Start()
    {
        
    }

    void Update()
    {
        bool turningRight = Keyboard.current.rightArrowKey.isPressed;
        bool turningLeft = Keyboard.current.leftArrowKey.isPressed;
        bool fire = Keyboard.current.spaceKey.wasPressedThisFrame;

        if (turningRight)
        {
            currentRotation.z -= speed * Time.deltaTime;
        }
        else if (turningLeft)
        {
            currentRotation.z += speed * Time.deltaTime;
        }


        if(fire)
        {
            GameObject newBullet = Instantiate(bullet, transform.position, Quaternion.identity);
            bulletScript = newBullet.GetComponent<Bullet>();
            bulletScript.turret = gameObject;
            bullets.Add(newBullet);

        }

        for (int i = 0; i < bullets.Count; i++)
        {
            if (bullets[i] == null)
                bullets.RemoveAt(i);
        }

        killCountText.text = "Kills: " + killCount;


        transform.eulerAngles = currentRotation;
    }
}
