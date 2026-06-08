using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;
using TMPro;

public class Enemy : MonoBehaviour
{
    SpriteRenderer body;
    public TextMeshProUGUI healthDisplay;
    public float health = 100f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        body = GetComponent<SpriteRenderer>();
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 currentMousePosition = Mouse.current.position.ReadValue();
        Vector3 worldMousePosition = Camera.main.ScreenToWorldPoint(currentMousePosition);
        worldMousePosition.z = 0f;

        bool click = Mouse.current.leftButton.wasPressedThisFrame;

        if (click&&body.bounds.Contains(worldMousePosition))
        {
            health -= 10f;
        }

        healthDisplay.text = health.ToString();

        if (health <= 0f)
            Destroy(gameObject);



    }
}
