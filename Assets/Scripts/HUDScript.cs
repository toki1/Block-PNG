using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class HUDScript : MonoBehaviour
{
	PlayerManager pManagerScript;
    PlayerManager pManagerScriptP2;
    public Sprite deadheart;
	public GameObject[] lives;
    public Image gameBG;
    public bool player;
    public bool gg;
    float timeLeft;
    Color targetColor;
    void Start()
	{
		pManagerScript = GameObject.Find("Player").GetComponent<PlayerManager>();
        if(player)
            pManagerScriptP2 = GameObject.Find("PlayerP2").GetComponent<PlayerManager>();
    }

	void Update()
	{
//      pManagerScript.lives++;
        //Debug.Log(pManagerScript.lives);
        if (pManagerScript.lives==2)
        {
            GameObject temp = GameObject.Find("Life Point 3");
            
            Image sr = temp.GetComponent<Image>();
            sr.sprite = deadheart;
        }
        else if (pManagerScript.lives == 1)
        {
            GameObject temp = GameObject.Find("Life Point 2");
            Image sr = temp.GetComponent<Image>();
            sr.sprite = deadheart;
        }
        else if (pManagerScript.lives == 0)
        {
            GameObject temp = GameObject.Find("Life Point 1");
            Image sr = temp.GetComponent<Image>();
            sr.sprite = deadheart;
        }
        //pManagerScriptP2.lives++;
        if (player)
        {
            if (pManagerScriptP2.lives == 2)
            {
                GameObject temp2 = GameObject.Find("Life Point 3P2");

                Image sr2 = temp2.GetComponent<Image>();
                sr2.sprite = deadheart;
            }
            else if (pManagerScriptP2.lives == 1)
            {
                GameObject temp2 = GameObject.Find("Life Point 2P2");
                Image sr2 = temp2.GetComponent<Image>();
                sr2.sprite = deadheart;
            }
            else if (pManagerScriptP2.lives == 0)
            {
                GameObject temp2 = GameObject.Find("Life Point 1P2");
                Image sr2 = temp2.GetComponent<Image>();
                sr2.sprite = deadheart;
            }
        }
        
        if(pManagerScript.lives<=0||(player&&pManagerScriptP2.lives<=0))
        {
            //                Destroy(gameObject);
            if(pManagerScript.lives <= 0)
            {
                gg = true;
            }
            else
            {
                gg = false;
            }
            StartCoroutine(Example());




        }
        ChangeBGColor(gameBG);
        //GameObject temp2 = GameObject.Find("Score");
        //temp2.GetComponent<Text>().text = "Time: "+Time.time.ToString("0.00"); ;
    }
    void ChangeBGColor(Image bg)
    {
        if (timeLeft <= Time.deltaTime)
        {
            // transition complete
            // assign the target color
            gameBG.color = targetColor;

            // start a new transition
            targetColor = new Color(Random.value, Random.value, Random.value,0.2f);
            timeLeft = 5f;
        }
        else
        {
            // transition in progress
            // calculate interpolated color
            gameBG.color = Color.Lerp(gameBG.color, targetColor, Time.deltaTime / timeLeft);

            // update the timer
            timeLeft -= Time.deltaTime;
        }
    }
    IEnumerator Example()
    {

        yield return new WaitForSeconds(0.5f);
        Destroy(GameObject.Find("LifePoints"));
        Destroy(GameObject.Find("Image"));
        GameObject g = GameObject.Find("Score");
        if(player)
        {
            if(gg)
                g.GetComponent<Text>().text = "player1 win";
            else
                g.GetComponent<Text>().text = "player2 win";
        }
        RectTransform r =g.GetComponent<RectTransform>();
        r.anchoredPosition= new Vector2(0,0);
        SceneManager.LoadScene("EndingScene");

    }
}
