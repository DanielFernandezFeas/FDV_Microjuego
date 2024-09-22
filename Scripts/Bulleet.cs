using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Bulleet : MonoBehaviour
{
    public float speed = 10f;
    public float lifeDuration = 3f;
    public Vector3 targetVector;

    // Start is called before the first frame update
    void Start()
    {
        // La bala se destruye a los 3 segundos
        Destroy(gameObject, lifeDuration);
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(speed * targetVector * Time.deltaTime);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Meteor")
        {
            IncreaseScore();
            Destroy(collision.gameObject);
            Destroy(gameObject);
            
        }
    }

    private void IncreaseScore()
    {
        Player.score++;
        Debug.Log(Player.score);
        UpdateScoreText();
    }
    private void UpdateScoreText()
    {
        GameObject go = GameObject.FindGameObjectWithTag("UI");
        go.GetComponent<Text>().text = "Puntos: " + Player.score;
    }
}
