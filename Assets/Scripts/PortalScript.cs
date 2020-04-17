using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortalScript : MonoBehaviour
{
	public GameObject[] portals;
	public GameObject projectilePrefab;
    public GameObject fastProjectilePrefab;
    public GameObject slowProjectilePrefab;
    private const float BASE_PROJECTILE_SPEED = 1.25f;
    private float lastFireTime;
//  private float timeToFire = 2f;
    private float spawnRate = 1.33f;
    private float projectileSpeed = BASE_PROJECTILE_SPEED;
	GameObject projectile;
    ShieldScript shieldScript;
    int temp = 0;
    public bool player;
    private int portalIndex;
    Vector3 v3;
    void Start()
	{

        if (player)
        {

            portals = new GameObject[] {GameObject.Find("Portal (0)"), GameObject.Find("Portal (1)"),
                                    GameObject.Find("Portal (2)"), GameObject.Find("Portal (3)") };
            shieldScript = GameObject.Find("Shield").GetComponent<ShieldScript>();
        }
        else
        {
            portals = new GameObject[] {GameObject.Find("Portal (0)P2"), GameObject.Find("Portal (1)P2"),
                                    GameObject.Find("Portal (2)P2"), GameObject.Find("Portal (3)P2") };
            shieldScript = GameObject.Find("ShieldP2").GetComponent<ShieldScript>();
        }
        lastFireTime = Time.time;
    }

	void Update()
	{
        //Debug.Log(player+"   "+portals[0].name);
        if(Time.time - lastFireTime > spawnRate)
        {
            shootProjectile();
            lastFireTime = Time.time;
        }
    }

    public void shootProjectile()
    {
        int rngesus = Random.Range(0, 100);
        if (rngesus <= 66)
        {
            portalIndex = Random.Range(0, portals.Length);
            Vector3 v3 = portals[portalIndex].transform.position;
            Debug.Log(portalIndex+ "   " + v3);
            if (portalIndex == 0)
                Instantiate(projectilePrefab, v3, Quaternion.Euler(0, 0, 270));
            else if (portalIndex == 1)
                Instantiate(projectilePrefab, v3, Quaternion.Euler(0, 0, 180));
            else if (portalIndex == 2)
                Instantiate(projectilePrefab, v3, Quaternion.Euler(0, 0, 90));
            else if (portalIndex == 3)
                Instantiate(projectilePrefab, v3, Quaternion.Euler(0, 0, 0));
        }
        else if (rngesus <= 80)
        {
            portalIndex = Random.Range(0, portals.Length);
            Vector3 v3 = portals[portalIndex].transform.position;
            if (portalIndex == 0)
                Instantiate(slowProjectilePrefab, v3, Quaternion.Euler(0, 0, 270));
            else if (portalIndex == 1)
                Instantiate(slowProjectilePrefab, v3, Quaternion.Euler(0, 0, 180));
            else if (portalIndex == 2)
                Instantiate(slowProjectilePrefab, v3, Quaternion.Euler(0, 0, 90));
            else if (portalIndex == 3)
                Instantiate(slowProjectilePrefab, v3, Quaternion.Euler(0, 0, 0));

        }
        else
        {
            portalIndex = Random.Range(0, portals.Length);
            Vector3 v3 = portals[portalIndex].transform.position;
            Debug.Log("" + v3);
            if(portalIndex==0)
                Instantiate(fastProjectilePrefab, v3, Quaternion.Euler(0, 0, 270));
            else if (portalIndex == 1)
                Instantiate(fastProjectilePrefab, v3, Quaternion.Euler(0, 0, 180));
            else if (portalIndex == 2)
                Instantiate(fastProjectilePrefab, v3, Quaternion.Euler(0, 0, 90));
            else if (portalIndex == 3)
                Instantiate(fastProjectilePrefab, v3, Quaternion.Euler(0, 0, 0));
        }
        if (shieldScript.getBlockCount() < 100)
        {
            
            projectileSpeed += .01f;
            if(shieldScript.getBlockCount() % 4 == 0&&temp!= shieldScript.getBlockCount())
            {
                spawnRate -= .035f;
            }
            temp = shieldScript.getBlockCount();
        }
        else
        {
            if(shieldScript.getBlockCount() % 6 == 0 && temp != shieldScript.getBlockCount())
            {
                spawnRate -= .01f;
                if(spawnRate < .1)
                {
                    spawnRate = .1f;
                }
                projectileSpeed += .008f;
            }
            temp = shieldScript.getBlockCount();
        }
    }
    public void attackSpawn(int portal)
    {

        Vector3 v3 = portals[portal].transform.position;
        if(portal==0)
            Instantiate(slowProjectilePrefab, v3, Quaternion.Euler(0, 0, 270));
        else if (portal == 1)
            Instantiate(slowProjectilePrefab, v3, Quaternion.Euler(0, 0, 180));
        else if (portal == 2)
            
            Instantiate(slowProjectilePrefab, v3, Quaternion.Euler(0, 0, 90));
        else if (portal == 3)
            Instantiate(slowProjectilePrefab, v3, Quaternion.Euler(0, 0, 0));


    }
    public float GetBaseSpeed()
    {
        return projectileSpeed;
    }
}
