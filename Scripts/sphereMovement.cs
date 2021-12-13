using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class sphereMovement : MonoBehaviour
{
    Vector3 direction;
    public makingRoads makingroad;
    public static bool fall;
    int score;
    public Text text_score;
    float speed=2f;
    public Text text_speed;
    int i = 1;
    int highScore;
    public Text text_high_score;
    
    // Start is called before the first frame update
    void Start()
    {
        fall = false;
        text_score.text = "score:" + score.ToString();
        text_speed.text = "speed:" + speed.ToString();
        highScore = PlayerPrefs.GetInt("HighScore");
        text_high_score.text = "record:" + highScore.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        if (fall == true)
            return;

        if (Input.GetKeyDown(KeyCode.DownArrow))
            direction = Vector3.forward;
        else if (Input.GetKeyDown(KeyCode.RightArrow))
            direction = Vector3.left;
        else if (Input.GetKeyDown(KeyCode.LeftArrow))
            direction = Vector3.right;
        else if (Input.GetKeyDown(KeyCode.UpArrow))
            direction = Vector3.back;
        else if(Input.GetKeyDown(KeyCode.A))
            direction = Vector3.zero;

        if (transform.position.y < -0.5f)
        {
            Destroy(this.gameObject);
            fall = true;
        }
    }
    void FixedUpdate()
    {
        if (fall == true)
            return;

        if (score > i*10)
        {
            speed += 0.2f;
            text_speed.text = "speed:" + speed.ToString();
            i++;
        }
        if(highScore < score)
        {
            highScore = score;
            PlayerPrefs.SetInt("HighScore", highScore);
            text_high_score.text = "new record:" + highScore.ToString();
        }

        Vector3 spheremovement = direction * Time.deltaTime*speed;
        transform.position += spheremovement;
    }
    void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "myRoad")
        {
            StartCoroutine(destroyRoad(collision.gameObject));
            makingroad.makingRoad();
            score++;
            text_score.text = "score:" + score.ToString();
        }
    }
    public IEnumerator destroyRoad(GameObject destroyingRoad)
    {
        yield return new WaitForSeconds(1.5f);
        destroyingRoad.AddComponent<Rigidbody>();
        yield return new WaitForSeconds(1.2f);
        Destroy(destroyingRoad);
    }
}
