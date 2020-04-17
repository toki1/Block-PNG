using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FastProjectileScript : MonoBehaviour
{
    public float moveSpeed;
    private int portalIndex;
    public PortalScript portalScript;
    public bool player;
    void Awake()
    {
        if(player)
            portalScript = GameObject.Find("Portals").GetComponent<PortalScript>();
        else
            portalScript = GameObject.Find("PortalsP2").GetComponent<PortalScript>();
    }

    void Start()
    {
        moveSpeed = portalScript.GetBaseSpeed() * 2;

    }

    void Update()
    {
        float move = moveSpeed * Time.deltaTime;
    
            
                transform.Translate(new Vector3(move, 0, 0));
                
        
    }
}