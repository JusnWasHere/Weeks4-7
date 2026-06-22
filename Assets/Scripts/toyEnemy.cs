using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.UI;

public class toyEnemy : MonoBehaviour
{
    public Vector3 direction;
    public Vector3 turretPos;
    public float speed;

    public Image enemyBarFillImage;

    public float currentHealth = 100f;
    public float maxHealth = 100f;

    public SpriteRenderer tEnemy;

    public Turret turretScript;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        turretPos = Vector3.zero;
        direction = turretPos - transform.position;
        tEnemy = GetComponent<SpriteRenderer>();
        

    }

    // Update is called once per frame
    void Update()
    {
        float distance = Vector3.Distance(turretPos, transform.position);
        transform.position += direction * speed * Time.deltaTime;

        if (distance <= 0.1f)
        {
            Destroy(gameObject);
        }

        foreach(GameObject bullet in turretScript.bullets)
        {
            if(bullet != null)
            {
                if (tEnemy.bounds.Contains(bullet.transform.position))
                {
                    //Debug.Log("hit");
                    Destroy(bullet);
                    currentHealth -= 25;
                }

            }
           
        }
        if(currentHealth <=0)
        {
            Destroy(gameObject);
            turretScript.killCount++;
        }
            

        enemyBarFillImage.fillAmount = currentHealth / maxHealth;

    }
}
