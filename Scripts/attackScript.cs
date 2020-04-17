using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class attackScript : MonoBehaviour {

    public float moveSpeed;
    private int portalIndex;
    public PortalScript portalScript;
    public bool player;
    
    void Awake()
    {

    }

    void Start()
    {

    }

    void Update()
    {
        float move = 1.25f * Time.deltaTime;
        transform.Translate(new Vector3(move, 0, 0));
    }
}
