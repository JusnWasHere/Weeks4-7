using NUnit.Framework;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;
using System.Collections.Generic;

public class Player : MonoBehaviour
{
    Vector3 PlayerPos;
    public float speed;

    public Canvas bubble;

    public GameObject alien;
    Vector3 alienPos;

    public List<Image> emotes;
    bool showingEmote;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        PlayerPos = transform.position;

        for (int i = 0; i < emotes.Count; i++)
        {
            emotes[i].enabled = false;
        }

        
    }

    // Update is called once per frame
    void Update()
    {
        bool left = Keyboard.current.leftArrowKey.isPressed;
        bool right = Keyboard.current.rightArrowKey.isPressed;
        bool up = Keyboard.current.upArrowKey.isPressed;
        bool down = Keyboard.current.downArrowKey.isPressed;

        if(left)
            PlayerPos.x -= speed * Time.deltaTime;
        if (right)
            PlayerPos.x += speed * Time.deltaTime;
        if (up)
            PlayerPos.y += speed * Time.deltaTime;
        if (down)
            PlayerPos.y -= speed * Time.deltaTime;

        transform.position = PlayerPos;

        alienPos = alien.transform.position;

        float distance = Vector3.Distance(alienPos, transform.position);

        if (distance <= 5f && !showingEmote)
        {
            showingEmote = true;

            int num = Random.Range(0, emotes.Count);
            emotes[num].enabled = true;
        }

        if (distance > 5f && showingEmote)
        {
            showingEmote = false;

            for (int i = 0; i < emotes.Count; i++)
            {
                emotes[i].enabled = false;
            }
        }
    }
}
