using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class BuildingSliderNegative : MonoBehaviour
{

    public Slider Adjuster;
    public float sliderValue;
    void Update()
    {
        sliderValue = Adjuster.value;
        Vector3 temp = transform.position;
        temp.y = -sliderValue;
        transform.localPosition = temp;
    }
}
