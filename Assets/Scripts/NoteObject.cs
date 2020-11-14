using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

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
            //Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Destroy")) {
            //Destroy(gameObject);
        }

        if (other.CompareTag("Collider")) {
            canBePressed = true;
        }

        // Debug.Log(other.gameObject.name + " : " + gameObject.name + " : " + Time.time);
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        canBePressed = false;
        // Debug.Log(other.gameObject.name + " : " + gameObject.name + " : " + Time.time);
    }
}
