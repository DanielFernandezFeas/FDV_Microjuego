using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class Player : MonoBehaviour
{
    public static int SCORF = 0;
    public float thrustforce = 300f;
    public float rotationSpeed = 200f;
    public float yBorder;
    public float xBorder;
    public static int score = 0;
    
    public GameObject gun, bulletPrefab;

    private Rigidbody _rigid;
    // Start is called before the first frame update
    void Start()
    {
        _rigid = GetComponent<Rigidbody>();
        
        yBorder = (Camera.main.orthographicSize);
        xBorder =(Camera.main.orthographicSize * Screen.width / Screen.height) + 0.5f;  
        
        
    }

    // Update is called once per frame
    void Update()
    {

        var newPos = transform.position;
        if (newPos.x > xBorder)
        {
            newPos.x = -xBorder+1;
        }
        else if (newPos.x < -xBorder)
        {
            newPos.x = xBorder-1;
        }
        else if (newPos.y > yBorder)
        {
            newPos.y = -yBorder+1;
        }
        else if (newPos.y < -yBorder)
        {
            newPos.y = yBorder-1;
        }
        transform.position = newPos;


        float rotation = Input.GetAxis("Horizontal") * Time.deltaTime;

        float thrust = Input.GetAxis("Thrust") * Time.deltaTime;

        Vector3 thrustDirection = transform.right;

        _rigid.AddForce(thrustDirection * thrust * thrustforce);

        transform.Rotate(Vector3.back, rotation * rotationSpeed);

        if(Input.GetKeyDown(KeyCode.Space))
        {
            GameObject bullet = Instantiate(bulletPrefab, gun.transform.position, gun.transform.rotation);
            
        }
    }
    private void OnCollisionEnter(Collision collision){
        if(collision.gameObject.tag == "Meteor"){
            score = 0;
            Destroy(gameObject);
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);

        }
    }
    
}
