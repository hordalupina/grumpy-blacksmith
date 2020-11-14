using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoteObject : MonoBehaviour
{

    public bool canBePressed;
    public KeyCode key;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (canBePressed && Input.GetKey(key))
        {
            print("up arrow key is held down");
            GameManager.instance.audioPlayer.Play();
            canBePressed = false;
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        canBePressed = true;
        if (other.CompareTag("Destroy")) {
            Destroy(gameObject);
        }
        // Debug.Log(other.gameObject.name + " : " + gameObject.name + " : " + Time.time);
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        canBePressed = false;
        // Debug.Log(other.gameObject.name + " : " + gameObject.name + " : " + Time.time);
    }
}
