using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float horizontalInput;
    public float speed;
    public float xRange = 15;
    public Transform blaster;
    public GameObject lazer;
    public bool hasPowerup;


    // Update is called once per frame
    void Update()
    {
        // Set HorizontalInput to receive values from keyboard
        horizontalInput = Input.GetAxis("Horizontal");
    
        // Moves player left and right
        transform.Translate(Vector3.right * horizontalInput * Time.deltaTime * speed);
    
        //Boundary for left and right
        if(transform.position.x < -xRange)
        {
            transform.position = new Vector3(-xRange, transform.position.y, transform.position.z);
        }
        if(transform.position.x > xRange)
        {
            transform.position = new Vector3(xRange, transform.position.y, transform.position.z);
        }

        if(Input.GetKeyDown(KeyCode.Space))
        {
            //Creates lazer at the blaster
            Instantiate(lazer, blaster.transform.position, lazer.transform.rotation);
        }

    }

    //Powerup Coding and delete any object that hits the player.
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Powerup"))
        {
            hasPowerup = true;
            Destroy(other.gameObject);
            StartCoroutine(PowerupCountdownRoutine());
        }
    }

    IEnumerator PowerupCountdownRoutine()
    {
        yield return new WaitForSeconds(7);
        hasPowerup = false;
    }
}
