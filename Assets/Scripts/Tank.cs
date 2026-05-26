using NUnit.Framework;
using UnityEngine;
using UnityEngine.InputSystem;
using System.Collections.Generic;

public class Tank : MonoBehaviour
{
    public float moveSpeed;
    public List<SpriteRenderer> sprites;
    public SpriteRenderer body;
    public SpriteRenderer tracks;
    public GameObject barrel;
    Vector3 barrelPos;
    public bool flipped;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        sprites.Add(body);
        sprites.Add(tracks);
        bool flipped = false;
    }

    // Update is called once per frame
    void Update()
    {
        bool leftKey = Keyboard.current.leftArrowKey.isPressed;
        bool rightKey = Keyboard.current.rightArrowKey.isPressed;

        if(leftKey)
        {
            transform.position -= transform.right * moveSpeed * Time.deltaTime;
            flipped = true;
        }

        if (rightKey)
        {
            transform.position += transform.right * moveSpeed * Time.deltaTime;
            flipped = false;
        }

        if (flipped)
        {
            for (int i = 0; i < sprites.Count; i++)
            {
                sprites[i].flipX = true;
            }
            
        }
        if(!flipped)
        {
            for (int i = 0; i < sprites.Count; i++)
            {
                sprites[i].flipX = false;
            }
        }

    }
}
