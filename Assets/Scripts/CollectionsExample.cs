using NUnit.Framework;
using UnityEngine;
using System.Collections.Generic;

public class CollectionsExample : MonoBehaviour
{
    private List<string> animals;
    public SpriteRenderer sprite;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        animals.Add("Raccoon");
        animals.Remove("Fish");

        /*
        for(int i = 0; i < animals.Count; i++)
        {
            Debug.Log(animals[i]);
        }
        */
        foreach(string animal in animals)
        {
            Debug.Log(animal);
        }

        Vector3 position = new Vector3();
        Color gray = new Color(0.5f, 0.5f, 0.5f, 1f);
        gray.b = 0.75f;
        sprite.color = gray;

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
