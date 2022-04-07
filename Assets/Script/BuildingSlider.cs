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
        sliderValue = Adjuster.value;
        Vector3 temp = transform.position;
        temp.y = sliderValue * modifier;
        transform.localPosition = temp;
    }
}
