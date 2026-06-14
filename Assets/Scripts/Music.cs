using UnityEngine;
using UnityEngine.UI;

public class Music : MonoBehaviour
{
    public AudioSource music;
    public Slider mSlider;
    bool Playing;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        mSlider.maxValue = music.clip.length;
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Playing)
        {
            mSlider.value = music.time;
        }

        
        
    }

    public void OnPlayClick()
    {
        music.Play();
        Playing = true;

    }

    public void OnStopClick()
    {
        music.Stop();

    }
}
