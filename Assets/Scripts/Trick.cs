using System.Security.Cryptography;
using UnityEditor;
using UnityEngine;
using UnityEngine.InputSystem;

public class Trick : MonoBehaviour
{
    public float speed;
    Vector3 pos;

    float progress;
    float duration = 1;
    public bool timerIsRunning = false;
    public AnimationCurve curve;
    public AnimationCurve spin;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        pos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        bool Space = Keyboard.current.spaceKey.wasPressedThisFrame;

        if(Space)
            timerIsRunning = true;

        Vector3 currentRotation = transform.eulerAngles;
        if (timerIsRunning)
        {
            progress += Time.deltaTime;

            pos.y = curve.Evaluate(progress / duration);
            currentRotation.z = spin.Evaluate(progress / duration);
            if (progress >= duration)
            {
                timerIsRunning = false;
                progress = 0f;
            }

        }
        Vector3 camPos = Camera.main.WorldToViewportPoint(transform.position);
        //Debug.Log(camPos.x);
        if (camPos.x >= 0.93f || camPos.x <= 0.06f)
        {
            speed *= -1f;
        }
        if(speed > 0f)
            currentRotation.z *= -1f;
        pos.x += speed * Time.deltaTime;
        transform.position = pos;
        transform.eulerAngles = currentRotation;
    }
}
