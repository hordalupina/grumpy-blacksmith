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
        if (!gm.canPlay)
            return;


        CheckPressWhenKeyIsNotInDetector();

        CheckKeyInDetectorIsRight();

        CheckKeyInDetectorIsWrong();
   
    }

    void CheckPressWhenKeyIsNotInDetector()
    {
        if (!canBePressed 
            & (Input.GetKeyDown(KeyCode.UpArrow)
                || Input.GetKeyDown(KeyCode.DownArrow)
                || Input.GetKeyDown(KeyCode.LeftArrow)
                || Input.GetKeyDown(KeyCode.RightArrow)
            )
        )
        {
            canBePressed = false;
            GetComponent<Collider2D>().enabled = false;
            Destroy(gameObject, .5f);

            gm.GameOver();

            return;
        }
    }

    void CheckKeyInDetectorIsRight()
    {
        if (canBePressed && latestNote != null && Input.GetKeyDown(latestNote.key))
        {
            //evento para ativação de visuais/sonoras
            latestNote.Play();
            gm.scoreHandler.AddScore(1);

            canBePressed = false;

            return;
        }
    }

    void CheckKeyInDetectorIsWrong()
    {
        if (canBePressed && latestNote != null && (
            (Input.GetKeyDown(KeyCode.UpArrow) && KeyCode.UpArrow != latestNote.key)
            || (Input.GetKeyDown(KeyCode.DownArrow) && KeyCode.DownArrow != latestNote.key)
            || (Input.GetKeyDown(KeyCode.LeftArrow) && KeyCode.LeftArrow != latestNote.key)
            || (Input.GetKeyDown(KeyCode.RightArrow) && KeyCode.RightArrow != latestNote.key)
        ))
        {
            canBePressed = false;
            GetComponent<Collider2D>().enabled = false;
            Destroy(gameObject, .5f);

            gm.GameOver();
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
            latestNote = null;
        }
    }
}
