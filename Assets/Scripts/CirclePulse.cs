using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CirclePulse : MonoBehaviour
{
    private Transform pulseTransform;
    [SerializeField] private float range = 3f;
    [SerializeField] private float rangeMax = 5f;
    [SerializeField] private float BPM = 60f;
    [SerializeField] private float rangeSpeed = 2f;
    [SerializeField] private float timeSinceLastPulse = 0f;

    private void Awake()
    {
        pulseTransform = transform.Find("Circle");
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
        if (timeSinceLastPulse >= BPM)
        {
            range = rangeMax;
        }
    }
}