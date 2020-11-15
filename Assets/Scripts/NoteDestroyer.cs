using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NoteDestroyer : MonoBehaviour
{

    GameManager gm;

    // Start is called before the first frame update
    void Start()
    {
        gm = GameManager.instance;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        NoteObject currentNote = other.GetComponentInParent<NoteObject>();

        if (other.CompareTag("Collider") && !currentNote.played) {
            //Game Over Condition
            gm.GameOver();
        }
    }
}
