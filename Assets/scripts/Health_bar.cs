using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Health_bar : MonoBehaviour
{
    public Slider slider;
    public void set_health(int health)
    {
     slider.value = health;
    }
}
