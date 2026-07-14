using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.UI;

public class toyEnemy : MonoBehaviour
{
    public Vector3 direction;//what direction enemy should move in
    public Vector3 turretPos;//position of the turret
    public float speed;//how fast they should go

    public Image enemyBarFillImage;//image for their health bar

    //their health
    public float currentHealth = 100f;
    public float maxHealth = 100f;

    public SpriteRenderer tEnemy;//their sprite

    public Turret turretScript;//the turret script

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        turretPos = Vector3.zero;//sets turret pos to 0 since thats where it is in scene
        direction = turretPos - transform.position;//sets the direction the enemyh should go in to be towards the turrets position(i know this is techncially redundant wasnt sure where I wanted turret before)
        tEnemy = GetComponent<SpriteRenderer>();//gets the sprite renderer
        

    }

    // Update is called once per frame
    void Update()
    {
        float distance = Vector3.Distance(turretPos, transform.position);//gets the distance between this game object and the turrets position
        transform.position += direction * speed * Time.deltaTime;//moves the enemy towards the direction of the turret

        //movement
        if (distance <= 0.1f)//if it touches the turret
        {
            turretScript.currentHealth -= 10f;//reduce the health of the turret
            Destroy(gameObject);//destroy itself
        }

        //Hit detection
        foreach(GameObject bullet in turretScript.bullets)//for every bullet in the bullet list
        {
            if(bullet != null)//if there is actually a bullet in the index
            {
                if (tEnemy.bounds.Contains(bullet.transform.position))//if the sprite bounds of this game object overlap with the position of the current bullet
                {
                    //Debug.Log("hit");
                    Destroy(bullet);//destroy that current bullet
                    currentHealth -= 25;//reduce the health of this game object
                }

            }
           
        }

        //dies
        if(currentHealth <=0)//if this game objects health reaches 0 or below
        {
            Destroy(gameObject);//destroy this object
            turretScript.killCount++;//increase the kill count int in the turret script by 1
        }
            

        enemyBarFillImage.fillAmount = currentHealth / maxHealth;//makes the healthbar display the current health of this game object

    }
}
