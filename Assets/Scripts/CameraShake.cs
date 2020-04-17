using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraShake : MonoBehaviour
{
    public bool Shaking;
    private float ShakeDecay;
    private float ShakeIntensity;
    private Vector3 OriginalPos;
    private Quaternion OriginalRot;

    void Start()
    {
        Shaking = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (ShakeIntensity > 0)
        {
            transform.position = OriginalPos + Random.insideUnitSphere * ShakeIntensity;
            transform.rotation = new Quaternion(OriginalRot.x + Random.Range(-ShakeIntensity, ShakeIntensity) * .2f,
                                      OriginalRot.y + Random.Range(-ShakeIntensity, ShakeIntensity) * .2f,
                                      OriginalRot.z + Random.Range(-ShakeIntensity, ShakeIntensity) * .2f,
                                      OriginalRot.w + Random.Range(-ShakeIntensity, ShakeIntensity) * .2f);

            ShakeIntensity -= ShakeDecay;
        }
        else if (Shaking)
        {
            Shaking = false;
            transform.position = new Vector3(0, 0, -10); 
            transform.rotation = Quaternion.Euler(0, 0, 0);
        }
    }

    public void DoShake()
    {
        OriginalPos = new Vector3(0,0,-10);
        OriginalRot = Quaternion.Euler(0, 0, 0); 

        ShakeIntensity = 0.2f;
        ShakeDecay = 0.02f;
        Shaking = true;
    }
}