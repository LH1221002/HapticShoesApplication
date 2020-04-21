using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Slider))]
public class ChangeAnimationSpeed : MonoBehaviour
{
    private Animator[] animators;
    private float[] defaultSpeeds;
    private Slider slider;
    void Start()
    {
        slider = GetComponent<Slider>();
        animators = GameObject.FindObjectsOfType<Animator>();
        defaultSpeeds = new float[animators.Length];
        for(int i=0; i<animators.Length; i++)
        {
            defaultSpeeds[i] = animators[i].speed;
        }
    }

    public void ChangeSpeed()
    {
        for(int i=0; i<animators.Length; i++)
        {
            animators[i].speed = defaultSpeeds[i]*(slider.value/10)* (slider.value / 10);
        }
    }
}
