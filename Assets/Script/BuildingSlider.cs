using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BuildingSlider : MonoBehaviour
{
    public Slider Adjuster;
    public float sliderValue;
    public int modifier = 1;
    void FixedUpdate()
    {
        if (Adjuster == null) // If this variable is null, then skip this script entirely. I have a feeling this script isn't even in use anymore, but I won't take the responsibility of removing it. I did remove the error this produced by being 'null' though. - Talha
            return;

        sliderValue = Adjuster.value;
        Vector3 temp = transform.position;
        temp.y = sliderValue * modifier;
        transform.localPosition = temp;
    }
}
