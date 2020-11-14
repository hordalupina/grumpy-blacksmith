using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NoteDetector : MonoBehaviour
{

    GameManager gm;
    public bool canBePressed;

    private NoteObject latestNote;

    // Start is called before the first frame update
    void Start()
    {
        gm = GameManager.instance;
    }

    // Update is called once per frame
    void Update()
    {
        if (latestNote != null && latestNote.played)
        {
            return;
        }

        if (!canBePressed 
            && (Input.GetKey(KeyCode.UpArrow)
                || Input.GetKey(KeyCode.DownArrow)
                || Input.GetKey(KeyCode.LeftArrow)
                || Input.GetKey(KeyCode.RightArrow)
            )
        )
        {
            print("wrong arrow key is held down");
            canBePressed = false;
            GetComponent<Collider2D>().enabled = false;
            Destroy(gameObject, .5f);

            SceneManager.LoadSceneAsync("GameOver");

            return;
        }

        if (canBePressed && latestNote != null && Input.GetKey(latestNote.key))
        {
            //evento para ativação de visuais/sonoras
            latestNote.played = true;
            latestNote.Play();
            gm.scoreHandler.AddScore(1);

            print("correct arrow key is held down");
            canBePressed = false;

            return;
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Collider")) {
            canBePressed = true;
            latestNote = other.GetComponentInParent<NoteObject>();
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Collider")) {
            canBePressed = false;
        }
    }
}
