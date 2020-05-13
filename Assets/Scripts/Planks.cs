using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Planks : MonoBehaviour
{
    // variable for rotating plank
    float zRotation;

    private SpriteRenderer spr;
    bool isVisible;
    public AudioSource collisionSound;
    // for scoring
    int score = 0;
    public Text score_txt;
    int highscore;
    public Text highscore_txt;



    // Start is called before the first frame update
    void Start()
    {
        // initializing rotating variable
        zRotation = 0f;
        




        spr = gameObject.GetComponent<SpriteRenderer>();
        spr.enabled = true;
        isVisible = true;
        highscore_txt.text = "HighScore: " + PlayerPrefs.GetInt("highscore");
    }

    private void Update()
    {

        //for rotating plank to make game some difficult
        transform.Rotate(new Vector3(0f, 0f, zRotation));
        zRotation += 0.0005f;
        



        //for touch input
        if (Input.touchCount > 0)
        {
            //geting new position from touch input
            Debug.Log("touch input is taken");
            Touch touch = Input.GetTouch(0);
            Vector3 touchPosition = Camera.main.ScreenToWorldPoint(touch.position);
            touchPosition.z = 0f;
            transform.position = touchPosition;

            if (isVisible == false) {
                //for enabling collider 2d
                this.GetComponent<BoxCollider2D>().enabled = true;

                spr.enabled = true;
                isVisible = true;
                Debug.Log("visible after position changed");
             
            }
      
        }
    }

    private void OnCollisionEnter2D(Collision2D collision){
     
        collisionSound.Play();
        //if plank is collided with ball when it is visiable
        if (isVisible){
            spr.enabled = false;
            isVisible = false;
            Debug.Log("Invisible");
            //for disable 2d collider 
            this.GetComponent<BoxCollider2D>().enabled = false;
        }

        //for scoring in game
        highscore = PlayerPrefs.GetInt("highscore");
        score = score + 5;
        if (score > highscore)
        {

            highscore = score;
            PlayerPrefs.SetInt("highscore", highscore);
            highscore_txt.text = "HighScore: " + PlayerPrefs.GetInt("highscore");

        }
        score_txt.text = "Score: " + score;


    }





}
