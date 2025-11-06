using System.Collections;
using System.Collections.Generic;
//using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Death : MonoBehaviour
{
    //How many lives and the health of the player
    public int livesRemaining = 3;
    private int health = 100;


    //Serialized fields means that you can allocate it from within the unity editor!
    //This is where the player gets respawned - can be reallocated later
    [SerializeField] private GameObject spawnPoint;

    //These next two are reference to the text boxes shown on screen
    [SerializeField] private Text lifeCounter;
    [SerializeField] private Text HPCounter;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        //This is called if an object with tag "Death" is collided with.
        if (collision.gameObject.CompareTag("Death"))
        {
            if(livesRemaining >0)
            {
                //If the player has lives remaining, the respawn function is run
                Die();
            }
            else
            {
                //game over logic here
            }
        }
        //This is called if an object with tag hazard is hit
        if(collision.gameObject.CompareTag("Hazard"))
        {
            //as opposed to the death collider, with the health collider the player merely takes damage. If this damage takes them to 0 - then they die!
            health -= collision.gameObject.GetComponent<MyDamage>().myDamage;
            if (health <= 0)
            {
                if(livesRemaining > 0)
                    Die();
                else
                    ReloadScene();
            }
            //This updates the text that says the players health
            HPCounter.text = "HP: " + health.ToString();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //The reason this is in a different function is that it is for triggers! Objects can move through triggers and it will then call this script but will not interact with them
        if (collision.gameObject.CompareTag("Checkpoint"))
        {
            //This updates the player's spawn point when they pass through a checkpoint
            spawnPoint = collision.gameObject;
        }
        else if(collision.gameObject.CompareTag("Finish"))
        {
            //!! UNCOMMENT THE LINE BELOW AND CHANGE "LevelTwo" to the name of the level you want it to load
            //SceneManager.LoadScene("LevelTwo");
        }
    }

    void ReloadScene()
    {
        //Change LevelOne to the name of your scene
        SceneManager.LoadScene("LevelOne");
    }

    //this is the death script as called above
    void Die()
    {
        //Reduces the remaining lives
        livesRemaining--;

        //Moves the player to the checkpoint
        gameObject.transform.position = spawnPoint.transform.position;

        //Updates the onscreen life counter
        lifeCounter.text = "Lives: " + livesRemaining.ToString();

        //Resets the players health to 100!
        health = 100;
    }
}
