using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Events;

public class GameManager : MonoBehaviour
{
    [System.NonSerialized]
    public UnityEvent gotKeyEvent = new UnityEvent();
    public UnityEvent<int> TrashCollected = new UnityEvent<int>();
    public int collectedTrash = 0;

    public void GetKey()
    {
        gotKeyEvent.Invoke();
    }

    public void addTrash()
    {
        collectedTrash++;
        Debug.Log(collectedTrash);

        TrashCollected.Invoke(collectedTrash);

    }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
}
