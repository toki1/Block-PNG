using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShieldScript : MonoBehaviour
{
    private int counter = 0;
	AudioSource deflectSound;

	void Start()
	{
		deflectSound = GetComponent<AudioSource>();
	}
	
	void Update()
	{
		
	}

    void OnCollisionEnter(Collision col)
    {
		deflectSound.Play();
        if (col.gameObject.tag.Equals("Projectile"))
        {
            Destroy(col.gameObject);
            ++counter;
        }
    }

    public int getBlockCount()
    {
        return counter;
    }
}
