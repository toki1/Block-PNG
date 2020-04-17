using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControllerP2 : MonoBehaviour
{
    public GameObject attackPrefab;
    public bool pmode;
    bool playerstatus=true;
    GameObject shield;
    Quaternion temp;
    private float lastFire;
    private const float secondsBetweenShots = 1.5f;

    void Start()
    {
        shield = GameObject.Find("ShieldP2");
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Tab)&&pmode)
        {
            if (playerstatus)
            {
                playerstatus = false;
                shield.SetActive(false);

            }
            else
            {
                playerstatus = true;
                shield.SetActive(true);

                
            }
        }



        if (Input.GetKeyDown(KeyCode.A) && !playerstatus)
        {
            temp = Quaternion.Euler(0, 0, 90);

            if (Time.time - lastFire > secondsBetweenShots)
            {
                Instantiate(attackPrefab, this.transform.position, Quaternion.Euler(0, 0, 180));
                lastFire = Time.time;
            }
        }
        else if (Input.GetKeyDown(KeyCode.A))
        {
            temp = Quaternion.Euler(0, 0, 90);
        }
        if (Input.GetKeyDown(KeyCode.W) && !playerstatus)
        {
            temp = Quaternion.Euler(0, 0, 0);

            if (Time.time - lastFire > secondsBetweenShots)
            {
                Instantiate(attackPrefab, this.transform.position, Quaternion.Euler(0, 0, 90));
                lastFire = Time.time;
            }
        }
        else if (Input.GetKeyDown(KeyCode.W))
        {
            temp = Quaternion.Euler(0, 0, 0);
        }
        if (Input.GetKeyDown(KeyCode.D) && !playerstatus)
        {
            temp = Quaternion.Euler(0, 0, 270);
            if (Time.time - lastFire > secondsBetweenShots)
            {
                Instantiate(attackPrefab, this.transform.position, Quaternion.Euler(0, 0, 0));
                lastFire = Time.time;
            }
        }
        else if (Input.GetKeyDown(KeyCode.D))
        {
            temp = Quaternion.Euler(0, 0, 270);
        }
        if (Input.GetKeyDown(KeyCode.S) && !playerstatus)
        {
            temp = Quaternion.Euler(0, 0, 180);
            if (Time.time - lastFire > secondsBetweenShots)
            {
                Instantiate(attackPrefab, this.transform.position, Quaternion.Euler(0, 0, 270));
                lastFire = Time.time;
            }
        }
        else if (Input.GetKeyDown(KeyCode.S))
        {
            temp = Quaternion.Euler(0, 0, 180);
        }

        this.transform.rotation = Quaternion.Lerp(this.transform.rotation, temp, 10f * Time.deltaTime);


    }
}
