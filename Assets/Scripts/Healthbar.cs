using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class Healthbar : MonoBehaviour
{
    public Image healthbarFillImage;

    public float currentHealth = 100f;
    public float maxHealth = 100f;

    public SpriteRenderer enemyRenderer;
    public AudioSource damageSound;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 currentMousePosition = Mouse.current.position.ReadValue();
        Vector3 worldMousePosition = Camera.main.ScreenToWorldPoint(currentMousePosition);
        worldMousePosition.z = 0f;

        bool click = Mouse.current.leftButton.wasPressedThisFrame;

        if (click && enemyRenderer.bounds.Contains(worldMousePosition))
        {
            damageSound.Play();
            currentHealth -= 10f;
            if(currentHealth <= 0f)
            {
                enemyRenderer.gameObject.SetActive(false);
            }
            healthbarFillImage.fillAmount = currentHealth / maxHealth;
        }


    }
}
