using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

[System.Serializable] public class NoteEvent : UnityEvent<KeyCode> { }

public class NoteObject : MonoBehaviour
{
    GameManager gm;
    public bool canBePressed;
    public KeyCode key;
    public bool played = false;

    [HideInInspector]
    public NoteEvent Hit;

    // Start is called before the first frame update
    void Start()
    {
        gm = GameManager.instance;
    }

    public void Play()
    {
        played = true;
        Hit.Invoke(key);
        GetComponent<Collider2D>().enabled = false;
        Destroy(gameObject, .5f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
