using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoteFactory : MonoBehaviour
{

    public GameObject notePrefab;

    Queue<KeyCode> myQueue = new Queue<KeyCode>();

    void Start()
    {
        AddNotesToQueue();
        AddNotesToQueue();
        AddNotesToQueue();
        AddNotesToQueue();
        AddNotesToQueue();

        InvokeRepeating("InstantiateNote", 2f, 2.0f);
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
    }

    void AddNotesToQueue()
    {   
        myQueue.Enqueue(KeyCode.UpArrow);
        myQueue.Enqueue(KeyCode.DownArrow);
        myQueue.Enqueue(KeyCode.LeftArrow);
        myQueue.Enqueue(KeyCode.RightArrow);
        myQueue.Enqueue(KeyCode.UpArrow);
        myQueue.Enqueue(KeyCode.DownArrow);
        myQueue.Enqueue(KeyCode.LeftArrow);
        myQueue.Enqueue(KeyCode.RightArrow);
    }
}
