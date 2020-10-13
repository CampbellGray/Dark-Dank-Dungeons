using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HueShifter : MonoBehaviour
{

    public Light lightObject;
    public bool useRainbowColors;
    public Gradient colorGradient;
    public float duration = 20.0F;

    void Update()
    {
        if (useRainbowColors && lightObject)
        {
            float lerp = Mathf.PingPong(Time.time, duration) / duration;
            lightObject.color = colorGradient.Evaluate(lerp);
        }
    }

}
