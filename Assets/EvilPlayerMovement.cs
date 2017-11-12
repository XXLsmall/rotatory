using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class EvilPlayerMovement : MonoBehaviour {

    public float speed = 100;
    public int score = 0;
    public GameObject enemy;
    public GameObject Scoretext;
    public Transform enemySpawnLeft;
    public Transform enemySpawnRight;
    public GameObject restartPanel;
    Vector3 originalCameraPosition = new Vector3(0,0,-10);
    float shakeAmt = 0;
    public Camera mainCamera;
    int scoreToSpawn = 4;
    bool finished = false;
    public Text scoredText;
    public Text bestText;
    int highscore;
    bool started = false;

    private void Start()
    {
        /*
        switch (Random.Range(1, 6))
        {
            case 1: Camera.main.backgroundColor = new Color32(113,140,202, 225);
                break;
            case 2:
                Camera.main.backgroundColor = new Color32(156, 110, 172, 225);
                break;
            case 3:
                Camera.main.backgroundColor = new Color32(208,193,73, 225);
                break;
            case 4:
                Camera.main.backgroundColor = new Color32(225,126,126, 225);
                break;
            case 5:
                Camera.main.backgroundColor = new Color32(86,186,124, 225);
                break;
        }
        */

        score = 0;

        //highscore = PlayerPrefs.GetInt("highscore", highscore);

        StartCoroutine(StartGame());

        restartPanel.SetActive(false);
    }


    void Update () {

        if (started)
        {
            //highscore
            if (score > highscore)
            {
                highscore = score;
                //PlayerPrefs.SetInt("highscore2", highscore); non era attivo prima, non attivare
            }



            //controls
            if (!finished)
                transform.Rotate(Vector3.back * speed * Time.deltaTime);

            foreach (Touch touch in Input.touches)
            {
                if (touch.position.x > Screen.width / 2 && !finished)
                {
                    speed = 200;
                }
                if (touch.position.x < Screen.width / 2 && !finished)
                {
                    speed = 50;
                }
                if (touch.phase == TouchPhase.Ended || touch.phase == TouchPhase.Canceled && !finished)
                {
                    speed = 100;
                }
            }


            //spawn enemy

            if (score >= scoreToSpawn)
            {

                scoreToSpawn += 4;
                GameObject enemyClone;
                float n = Random.value;
                if(n < 0.5f)
                {
                    enemyClone = Instantiate(enemy, enemySpawnLeft.position, enemy.transform.rotation);
                    enemyClone.transform.parent = enemySpawnLeft.transform;
                }
                else
                {
                    enemyClone = Instantiate(enemy, enemySpawnRight.position, enemy.transform.rotation);
                    enemyClone.transform.parent = enemySpawnRight.transform;
                }

                 
                
            }
        }
        Scoretext.GetComponent<TextMesh>().text = score.ToString();


       
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Start")
        {
            score++;
        }
        if (collision.gameObject.tag == "Enemy")
        {
            scoredText.text = score.ToString();
            bestText.text = PlayerPrefs.GetInt("highscore2", highscore).ToString();
            shakeAmt = speed/3 * .0025f;
            InvokeRepeating("CameraShake", 0, .01f);
            Invoke("StopShaking", 0.3f);
            finished = true;
            speed = 0;
            GameObject[] enms = GameObject.FindGameObjectsWithTag("Enemy");
            for(int i = 0; i < enms.Length; i++)
            {
                
                enms[i].GetComponent<EnemyScript>().speed = 0;
                restartPanel.SetActive(true);
            }
            GameObject.FindGameObjectWithTag("GameController").GetComponent<Highscores>().AddMyScore();
        }
    }

    void CameraShake()
    {
        if (shakeAmt > 0)
        {
            float quakeAmt = Random.value * shakeAmt * 2 - shakeAmt;
            Vector3 pp = mainCamera.transform.position;
            pp.y += quakeAmt;
            pp.x += quakeAmt;
            pp.z += quakeAmt;
            mainCamera.transform.position = pp;
        }
    }

    void StopShaking()
    {
        CancelInvoke("CameraShake");
        mainCamera.transform.position = originalCameraPosition;
    }


    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    public void MenuGame()
    {
        SceneManager.LoadScene("Menu");
    }


    IEnumerator StartGame()
    {
        yield return new WaitForSeconds(2);
        started = true;
        GameObject enemyClone = Instantiate(enemy, enemySpawnRight.position, enemy.transform.rotation);
        enemyClone.transform.parent = enemySpawnRight.transform;
    }

}
