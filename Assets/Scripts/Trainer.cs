using UnityEngine;
using UnityEngine.InputSystem;
using System.Collections.Generic;

public class Trainer : MonoBehaviour
{
    public SpriteRenderer creatureRenderer;
    public Camera gameCamera;
    public Color caughtColor;

    public List<SpriteRenderer> uncaughtCreatures;
    public List<SpriteRenderer> caughtCreatures;



    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        bool isClicked = Mouse.current.leftButton.wasPressedThisFrame;

        Vector3 mousePosition = Mouse.current.position.ReadValue();
        Vector3 worldMousePosition = gameCamera.ScreenToWorldPoint(mousePosition);
        worldMousePosition.z = 0f;

        if(isClicked)
        {
            for(int i = 0; i < caughtCreatures.Count; i++) {
                Debug.Log(caughtCreatures[i]);
            }
            
        }

        if(isClicked && creatureRenderer.bounds.Contains(worldMousePosition))
        {
            creatureRenderer.color = caughtColor;
            
            if(!caughtCreatures.Contains(creatureRenderer)) 
            {
              caughtCreatures.Add(creatureRenderer);

            }

            uncaughtCreatures.Remove(creatureRenderer);
            


        }
        
    }
}
