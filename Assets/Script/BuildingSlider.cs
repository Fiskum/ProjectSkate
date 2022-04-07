using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BuildingSlider : MonoBehaviour
{
    public Slider Adjuster;
    public float sliderValue;
    void FixedUpdate()
    {
        sliderValue = Adjuster.value -21;
        Vector3 temp = transform.position;
        temp.y = sliderValue;
        transform.localPosition = temp;
    }
}
