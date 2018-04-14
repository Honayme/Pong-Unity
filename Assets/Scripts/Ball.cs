using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class Ball : MonoBehaviour {

    public float force = 1000f;

    public Text scoreTextP1;
    public Text scoreTextP2;
    public Text winTextText;
    public int scoreP1;
    public int scoreP2;
    public string winText;

    public float x;
    public float y;
    public float rand;

    public Rigidbody rb;
    public Vector3 v3; 

    public bool gameIsStarting; 
    //WinText, partie qui va en 10 ou en 5
    //Dire qu'il faut appuyer sur espace pour lancer et la touche échap pour revenir au menu
    void Start () {

        //Application.LoadLevel(Application.loadedLevel);
        winText = "";
        scoreP1 = 0;
        scoreP2 = 0;
        gameIsStarting = false; 
        SetScore();
        Begin();
    }

    private void Begin()
    {
        GetComponent<Rigidbody>().position = new Vector3(0, 1, 1);
        GetComponent<Rigidbody>().Sleep();
    }

    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
        }

        if (Input.GetKeyDown(KeyCode.Space) && gameIsStarting != true)
        {
            GetComponent<Rigidbody>().WakeUp();
            DrawBall();
        }

        if (scoreP1 == 1)
        {
            winTextText.enabled = true;
            winText = "P1 WIN";
            winTextText.text = winText.ToString();
            gameIsStarting = true;
        }
        else if(scoreP2 == 1){
            winTextText.enabled = true;
            winText = "P2 WIN";
            winTextText.text = winText.ToString();
            gameIsStarting = true;
        }
    }


    private void DrawBall()
    {
        gameIsStarting = true;
        winTextText.enabled = false; 

        rand = Random.value;
        if (rand < 0.5f)
        {
            x = 1;
            if(rand < 0.25f)
            {
                y = 0.3f;
            }
            else
            {
                y = -0.3f;
            }
        }
        else
        {
            x = -1;
            if (rand > 0.75f)
            {
                y = 0.3f;
            }
            else
            {
                y = -0.3f;
            }
        }

        Vector3 mvt = new Vector3(x, y, 0);
        GetComponent<Rigidbody>().AddForce(mvt * force);
    }

    private void OnCollisionEnter(Collision collision)
    {
        float distRight = this.transform.position.y - GameObject.Find("PadRight").transform.position.y;
        float distLeft = this.transform.position.y - GameObject.Find("PadLeft").transform.position.y;

        rb = GetComponent<Rigidbody>();
        if (collision.gameObject.CompareTag("PadRight"))
        {
            this.GetComponent<Rigidbody>().velocity = new Vector3(-16, distRight *4f , 0f);
            v3 = new Vector3(-16, distRight * 3f, 0f);
            rb.AddForce(v3 * 5);
        }
        if (collision.gameObject.CompareTag("PadLeft"))
        {
            this.GetComponent<Rigidbody>().velocity = new Vector3(16f, distLeft *4f , 0f);
            v3 = new Vector3(16, distRight * 3f, 0f);
            rb.AddForce(v3 * 5);
        }

        if (collision.gameObject.CompareTag("WallLeft"))
        {
            scoreP2++;
            SetScore();
            gameIsStarting = false;
            Sound("win");
            Begin();
        }
        else if (collision.gameObject.CompareTag("WallRight"))
        {
            scoreP1++;
            SetScore();
            gameIsStarting = false;
            Sound("win");
            Begin();
        }

        Sound("hit");
    }

    private void SetScore()
    {
        scoreTextP1.text =  scoreP1.ToString();
        scoreTextP2.text =  scoreP2.ToString();
    }

    private void Sound(string type)
    {
        AudioSource hit;
        AudioSource win;
        AudioSource[] audio = GetComponents<AudioSource>();

        hit = audio[0];
        win = audio[1];

        if (type == "hit")
        {
            hit.pitch = Random.Range(0.8f, 1.2f);
            hit.Play();
        }
        else
        {
            win.Play();
        }
    }
}

   

