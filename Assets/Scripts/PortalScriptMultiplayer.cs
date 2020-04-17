using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortalScriptMultiplayer : MonoBehaviour {
    public int number;
    public bool player;
    public GameObject attackPrefab;
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    void OnCollisionEnter(Collision col)
    {
        //Debug.Log("working");
        if(col.gameObject.tag.Equals("attack"))
        {
            Destroy(col.gameObject);
            if (player)
            {

                PortalScript ps = GameObject.Find("Portals"  + "P2").GetComponent<PortalScript>();
                ps.attackSpawn(number);
                

            }
            else
            {
                PortalScript ps = GameObject.Find("Portals" + "").GetComponent<PortalScript>();
                ps.attackSpawn(number);
            }
        }
    }
}
