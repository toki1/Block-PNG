using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class PlayerManager : MonoBehaviour
{
    public int lives = 3;
    public Sprite cracked, broken;
    GameObject body;
    public bool pmode;

    private float startTime;
    void Start()
	{
 
        startTime = Time.time;
        if (pmode)
        {
            body = GameObject.Find("BodyP2");
        }
        else
        {
            body = GameObject.Find("Body");
        }
	}





    void Update()
	{
        float t = Time.time - startTime;

        string minutes = ((int)t / 60).ToString();
        string seconds = (t % 60).ToString("f2");

        GameObject temp2 = GameObject.Find("Score");
        temp2.GetComponent<Text>().text = "Time: "+minutes+":"+seconds ;
        
    }

    void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.tag.Equals("Projectile"))
        {

            lives--;
            Destroy(col.gameObject);
            GameObject.Find("Main Camera").GetComponent<CameraShake>().DoShake();
            this.GetComponent<AudioSource>().Play();
            if (lives == 2)
            {
                body.GetComponent<SpriteRenderer>().sprite = cracked;
            }
            else if (lives == 1)
            {
                body.GetComponent<SpriteRenderer>().sprite = broken;
            }

        }
    }
}
