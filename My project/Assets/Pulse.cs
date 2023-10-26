using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CirclePulse : MonoBehaviour
{
    private Transform pulseTransform;
    public float range = 3f;
    public float rangeMax = 5f;
    public float BPM = 60f;
    public float timeSinceLastPulse = 0f;
    public float rangeSpeed;
    


    private void Awake()
    {
        pulseTransform = transform.Find("Pulse");
        rangeSpeed = rangeMax - range;
    }

    private void Update()
    {
        range += rangeSpeed * Time.deltaTime;
        if (range > rangeMax)
        {
            range = 3f;
            timeSinceLastPulse = 0f;
        }

        pulseTransform.localScale = new Vector3(range, range);

        timeSinceLastPulse += Time.deltaTime;
        if (timeSinceLastPulse >= (60/BPM))
        {
            range = rangeMax;
        }
    }
}