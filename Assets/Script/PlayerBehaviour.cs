using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBehaviour : MonoBehaviour
{

    public GameObject Respawn;

    Rigidbody2D rb;
    public int movementSpeed;

    public GameObject winTitle;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        transform.position = Respawn.transform.position;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
            movement();
    }

    void movement()
    {
        if (rb != null)
        {
            if (Input.GetKey(KeyCode.LeftArrow))
            {
                rb.AddForce(-transform.right * movementSpeed, ForceMode2D.Force);
                Debug.Log("Move Charecter to the Left");
            }
            if (Input.GetKey(KeyCode.RightArrow))
            {
                rb.AddForce(transform.right * movementSpeed, ForceMode2D.Force);
                Debug.Log("Move Charecter to the Right");
            }
            if (Input.GetKey(KeyCode.Space))
            {
                rb.AddForce(new Vector2(0,5) * movementSpeed);
                Debug.Log("Jump Charecter");
            }
        }
        void OnCollisionEnter2D(Collider2D collision2D)
        {
            Debug.Log(collision2D.gameObject.name + " : " + gameObject.name + " : " + Time.time);
            if (collision2D.gameObject.tag == "End Point")
            {
                //Win Condition
                winTitle.SetActive(true);
            }
            if (collision2D.gameObject.tag == "traps")
            {
                transform.position = Respawn.transform.position;
            }
            if (collision2D.gameObject.tag == "Ladders")
            {
                if (Input.GetKeyDown(KeyCode.W))
                {
                    transform.position = new Vector2(Respawn.transform.position.x, transform.position.y + Respawn.transform.position.y);
                }
            }
        }
    }
}
