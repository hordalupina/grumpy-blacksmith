using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoteFactory : MonoBehaviour
{
    public GameObject notePrefab;

    public float delay = 1f;

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

        // InvokeRepeating("InstantiateNote", 1f, 1.0f);
        StartCoroutine(InstantiationLoop());
        
    }

    IEnumerator InstantiationLoop()
    {
        int spawnedNotes = 0;
        
        while(true)
        {
            delay = (spawnedNotes % 8 == 0 && delay > 0.4f) ? (delay - 0.05f) : delay;
            yield return new WaitForSeconds(delay);
            InstantiateNote();
            spawnedNotes++;
        }
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
