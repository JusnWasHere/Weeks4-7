using UnityEngine;
using UnityEngine.InputSystem;

public class Spawner : MonoBehaviour
{
    public GameObject runnerPrefab;
    //public GameObject existingRunner;
    public Vector3 spawnPosition;
    public float spawnSpeed;
    Runner runner;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnSpawnPress()
    {
        //Spawn a runner!
        //Instantiate(runnerPrefab);

        //Spawn a runner that is a child of this object
        //Instantiate(runnerPrefab, transform);

        //Spawn a runner at a specific position with no rotation:
        GameObject spawnedObject = Instantiate(runnerPrefab, transform.position, Quaternion.identity);

        runner = spawnedObject.GetComponent<Runner>();
        if (runner != null)
        {
           
            runner.speed = spawnSpeed;
        }




        //POSITION OF ZERO:
        //Vector3 zeroVector = Vector3.zero;

        //ROTATION OF ZERO:
        //Quaternion zeroRotation = Quaternion.identity;
    }
}
