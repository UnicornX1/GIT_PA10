using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    private Animation thisAnimation;

    private Rigidbody rb;

    public float jumpForce = 7;

    public SphereCollider col;

    public bool IsFlying = false;

    public Text score;

    private float scores=0;

    void Start()
    {
        thisAnimation = GetComponent<Animation>();
        thisAnimation["Flap_Legacy"].speed = 3;

        rb = GetComponent<Rigidbody>();
        col = GetComponent<SphereCollider>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            IsFlying = true;
        }
        else
        {
            IsFlying = false;
        }
        if (IsFlying == true)
        {
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        }
            thisAnimation.Play();

        score.text = "SCORE : " + scores;
    }

    public void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Bad")
        {
            print("Died");
            SceneManager.LoadScene("GameOver");
        }
    }
    public void OnTriggerEnter(Collider collision)
    {
        if(collision.gameObject.tag == "Floor")
        {
            print("Died");
            SceneManager.LoadScene("GameOver");
        }
        if(collision.gameObject.tag == "Score")
        {
            print("Score");
            scores++;   
        }
    }
}
