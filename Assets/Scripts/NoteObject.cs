using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

[System.Serializable] public class NoteEvent : UnityEvent<int> { }

public class NoteObject : MonoBehaviour
{
    GameManager gm;
    public bool canBePressed;
    public KeyCode key;

    [HideInInspector]
    public NoteEvent Hit;

    // Start is called before the first frame update
    void Start()
    {
        gm = GameManager.instance;
    }

    // Update is called once per frame
    void Update()
    {
        if (canBePressed && Input.GetKey(key))
        {
            //evento para ativação de visuais/sonoras
            Hit.Invoke(0);

            print("up arrow key is held down");
            canBePressed = false;
            GetComponent<Collider2D>().enabled = false;
            Destroy(gameObject, .5f);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Destroy")) {
            //Game Over Condition
            SceneManager.LoadSceneAsync("GameOver");
        }

        if (other.CompareTag("Collider")) {
            canBePressed = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        canBePressed = false;
        // Debug.Log(other.gameObject.name + " : " + gameObject.name + " : " + Time.time);
    }
}
