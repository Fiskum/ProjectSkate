using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyBuilding : MonoBehaviour
{
    void OnBecameInvisible()
        {
            Destroy(this.gameObject);
        }
    }
