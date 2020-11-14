using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Note
{
    public KeyCode Key;
    public float Rotation;

    public Note(KeyCode key, float rotation)
    {
        Key = key;
        Rotation = rotation;
    }
}

public class NoteFactory : MonoBehaviour
{
    public GameObject notePrefab;

    public float delay = 1f;

    Note[] availableKeys = {
        new Note(KeyCode.UpArrow, 180f),
        new Note(KeyCode.DownArrow, 0f),
        new Note(KeyCode.RightArrow, 90f),
        new Note(KeyCode.LeftArrow, -90f)
    };

    Queue<Note> myQueue = new Queue<Note>();

    void Start()
    {
        AddNotesToQueue();
        AddNotesToQueue();

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
        Note currentNote = myQueue.Dequeue();

        GameObject newNoteInstance = Instantiate(
            notePrefab,
            new Vector3(transform.position.x, transform.position.y, transform.position.z),
            Quaternion.identity
        );
        newNoteInstance.transform.parent = gameObject.transform;
        newNoteInstance.GetComponent<NoteObject>().key = currentNote.Key;
        newNoteInstance.transform.GetChild(0).eulerAngles = new Vector3(
            0f,
            0f,
            currentNote.Rotation
        );

        if (myQueue.Count <= 10)
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
