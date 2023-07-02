using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ComicManager : MonoBehaviour
{

    [SerializeField] private GameObject scrollComic;
    public float scrollSpeed = 10f;
    public Vector3 from;
    public Vector3 to;
    public Vector3 tra;

    /* public void ScrollNextPage()
    {
        currentPos = scrollComic.transform.position;

        targetPos = new Vector3(currentPos.x, currentPos.y +1180, currentPos.z);

        currentPos = Vector3.Lerp(currentPos, targetPos, scrollSpeed);

        //targetPos = scrollComic.transform.position.y + 1180f;
    }

    public void ScrollLastPage()
    {
        currentPos = scrollComic.transform.position;

        targetPos = new Vector3(currentPos.x, currentPos.y - 1180, currentPos.z);

        currentPos = Vector3.Lerp(currentPos, targetPos, scrollSpeed);

        //targetPos = scrollComic.transform.position.y + 1180f;
    } 

    IEnumerator Next()
    {
        from = scrollComic.transform.position;
        to = new Vector3(from.x, from.y +1180, from.z);
        tra = trasnform


    } */

}
