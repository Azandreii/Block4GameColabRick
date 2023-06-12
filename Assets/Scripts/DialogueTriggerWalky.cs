using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueTriggerWalky : MonoBehaviour
{

    [Header("Ink JSON")]
    [SerializeField] private TextAsset inkJSON;
    [SerializeField] private Animator WalkyTalkyAnimator;
    //[SerializeField] private GameObject Player;
    [SerializeField] private GameObject toBeDestroyed;
    [SerializeField] private GameObject WalkyTalky;
    //[SerializeField] private AudioSource audioSource;
    public bool audioDone = false;
    public bool displayedDialogue = false;
    public bool WalkyHid = false;
    public bool WalkyHid2 = false;
    public bool dialogueStillOnScreen = false;
    public GameObject dialoguebox;

    private bool playerInRange;

    public AudioClip WalkyTalkySound;

    private void Awake()
    {
        playerInRange = false;
    }

    private void Start()
    {
        GetComponent<AudioSource>().playOnAwake = false;
        GetComponent<AudioSource>().clip = WalkyTalkySound;
    }

    private void Update()
    {
        dialogueStillOnScreen = dialoguebox.activeSelf;

        if (playerInRange && !DialogueManager.GetInstance().dialogueIsPlaying && !displayedDialogue)
        {
            if (!audioDone)
            {
                StartCoroutine(ShowWalkyTalky());
                StartCoroutine(startDialogue());
            }
        }

        if (displayedDialogue && !dialoguebox.activeSelf && !WalkyHid)
        {
            StartCoroutine(HideWalkyAnim());

            //Destroy(toBeDestroyed);
            
            
        }

        if (WalkyHid2 && !dialoguebox.activeSelf)
        {
            WalkyTalkyAnimator.Play("PutWalkyBack");
            //WalkyTalky.SetActive(false);

        }


    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            playerInRange = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            playerInRange = false;
        }

    }

    IEnumerator ShowWalkyTalky()
    {
        GetComponent<AudioSource>().Play();


        //WalkyTalky.SetActive(true);
        WalkyTalkyAnimator.Play("PullUpWalky");

        audioDone = true;
        yield return new WaitForSeconds(1f);
    }

    IEnumerator startDialogue()
    {
        displayedDialogue = true;
        Debug.Log("startDialogue started");
        yield return new WaitForSecondsRealtime(4);
        DialogueManager.GetInstance().EnterDialogueMode(inkJSON);
        Debug.Log("startDialogue done");
    }

    IEnumerator HideWalkyAnim()
    {
        WalkyHid = true;
        Debug.Log("HideWalky started");
        yield return new WaitForSecondsRealtime(4);
        Debug.Log("HideWalky done");
        WalkyHid2 = true;

    }

}


