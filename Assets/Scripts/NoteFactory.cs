using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoteFactory : MonoBehaviour
{

    public GameObject notePrefab;

    KeyCode[] availableKeys = {
        KeyCode.UpArrow,
        KeyCode.DownArrow,
        KeyCode.RightArrow,
        KeyCode.LeftArrow
    };

    Queue<KeyCode> myQueue = new Queue<KeyCode>();

    void Start()
    {
        AddNotesToQueue();
        AddNotesToQueue();

        InvokeRepeating("InstantiateNote", 1f, 1.0f);
    }

    void InstantiateNote()
    {
        KeyCode currentNote = myQueue.Dequeue();

        GameObject newNoteInstance = Instantiate(
            notePrefab,
            new Vector3(transform.position.x, transform.position.y, transform.position.z),
            Quaternion.identity
        );
        newNoteInstance.transform.parent = gameObject.transform;
        newNoteInstance.GetComponent<NoteObject>().key = currentNote;

        if (myQueue.Count <= 8)
        {
            AddNotesToQueue();
        }
    }

    void AddNotesToQueue()
    {   
        for (int i = 0; i < 8; i++) 
        {
            myQueue.Enqueue(availableKeys[Random.Range(0, availableKeys.Length)]);
        }
    }
}
