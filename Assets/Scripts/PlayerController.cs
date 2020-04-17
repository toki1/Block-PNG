using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public GameObject attackPrefab;
    public bool pmode;
    bool playerstatus = true;
    GameObject shield;
    Quaternion temp;
	public float rotSpeed;
    private float lastFire;
    private const float secondsBetweenShots = 1.5f;

    void Start()
    {
        shield = GameObject.Find("Shield");
		rotSpeed = 10f;
        lastFire = Time.time;
    }

    void Update()
    {



        if (Input.GetKeyDown(KeyCode.RightShift) && pmode)
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



        if (Input.GetKeyDown(KeyCode.LeftArrow)&& !playerstatus)
        {
            temp = Quaternion.Euler(0, 0, 90);
            if(Time.time - lastFire > secondsBetweenShots)
            {
                Instantiate(attackPrefab, transform.position, Quaternion.Euler(0, 0, 180));
                lastFire = Time.time;
            }
        }
        else if(Input.GetKeyDown(KeyCode.LeftArrow))
        {
            temp = Quaternion.Euler(0, 0, 90);
        }
        if (Input.GetKeyDown(KeyCode.UpArrow) && !playerstatus)
        {
            temp = Quaternion.Euler(0, 0, 0);
            if (Time.time - lastFire > secondsBetweenShots)
            {
                Instantiate(attackPrefab, transform.position, Quaternion.Euler(0, 0, 90));
                lastFire = Time.time;
            }
        }
        else if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            temp = Quaternion.Euler(0, 0, 0);
        }
        if (Input.GetKeyDown(KeyCode.RightArrow) && !playerstatus)
        {
            temp = Quaternion.Euler(0, 0, 270);
            if (Time.time - lastFire > secondsBetweenShots)
            {
                Instantiate(attackPrefab, transform.position, Quaternion.Euler(0, 0, 0));
                lastFire = Time.time;
            }
        }
        else if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            temp = Quaternion.Euler(0, 0, 270);
        }
        if (Input.GetKeyDown(KeyCode.DownArrow) && !playerstatus)
        {
            temp = Quaternion.Euler(0, 0, 180);
            if (Time.time - lastFire > secondsBetweenShots)
            {
                Instantiate(attackPrefab, transform.position, Quaternion.Euler(0, 0, 270));
                lastFire = Time.time;
            }
        }
        else if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            temp = Quaternion.Euler(0, 0, 180);
        }

        transform.rotation = Quaternion.Lerp(transform.rotation, temp, rotSpeed * Time.deltaTime);
    }
}
