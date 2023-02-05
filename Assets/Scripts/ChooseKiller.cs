using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ChooseKiller : MonoBehaviour
{
    public TMP_Text _Text;
    public TMP_Text _Text2;
    public TMP_Text _Text3;
    public List<Button> buttons = new List<Button>();
    public List<Button> buttons2 = new List<Button>();
    private float Timer = 2.5f;
    private bool isWin = false;
    private bool isReduce = false;
    public GameObject Q1;
    public GameObject Q2;
    public GameObject Q3;
    // Start is called before the first frame update
    void Start()
    {
        Q2.SetActive(false);
        Q3.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void End(int endNumber)
    {
        //Q1
        if (endNumber == 0)
        {
            isWin = true;
            StartCoroutine("ChangeScene1");
            buttonInteractable(2);
        }
        else if (endNumber == 1)
        {
            StartCoroutine("ChangeScene2");
            buttonInteractable(2);
        }
        else if(endNumber==2)
        {
            StartCoroutine("ChangeScene3");
            buttonInteractable(2);
        }
        
        //Q2
        if (endNumber == 3)
        {
            StartCoroutine("ChangeScene4");
            buttonInteractable(4);
        }
        else if (endNumber == 4)
        {
            isReduce = true;
            StartCoroutine("ChangeScene5");
            buttonInteractable(4);
        }
    }

    IEnumerator ChangeScene1()
    {
        _Text.text = "Donald defended a defendant in a murder case some years ago";
        yield return new WaitForSeconds(Timer);
        _Text.text = "and got him acquitted. The victim in that case was my wife.";
        yield return new WaitForSeconds(Timer);
        _Text.text = "I want to avenge my wife's death, so I switched the room numbers";
        yield return new WaitForSeconds(Timer);
        //change to the HappyEnding
        //SceneManager.LoadScene("HappyEnding");
        Q1.SetActive(false);
        Q2.SetActive(true);
    }

    IEnumerator ChangeScene2()
    {
        _Text.text = "I asked him to do a job and he blackmailed me";
        yield return new WaitForSeconds(Timer);
        _Text.text = "saying he would expose my scandal if I didn't give him more money";
        yield return new WaitForSeconds(Timer);
        _Text.text = "So I gave him a knife and tried to kill him, not realizing";
        yield return new WaitForSeconds(Timer);
        _Text.text = "that I had not poked Donald in the vitals according to forensics";
        yield return new WaitForSeconds(Timer);
        //change to the SadEnding
        //SceneManager.LoadScene("SadEnding");
        Q1.SetActive(false);
        Q2.SetActive(true);
    }

    IEnumerator ChangeScene3()
    {
        _Text.text = "He kept domestically abusing me";
        yield return new WaitForSeconds(Timer);
        _Text.text = "and I had no way to fight back. He killed my child and I hated him.";
        yield return new WaitForSeconds(Timer);
        _Text.text = "So I poisoned him and tried to kill him slowly,";
        yield return new WaitForSeconds(Timer);
        _Text.text = "but I didn't expect the dose to be enough to kill Donald";
        yield return new WaitForSeconds(Timer);
        //SceneManager.LoadScene("SadEnding");
        StartCoroutine("ChangeScene3");
        Q1.SetActive(false);
        Q2.SetActive(true);
    }

    IEnumerator ChangeScene4()
    {
        Q2.SetActive(false);
        Q3.SetActive(true);
        if(!isWin)
        {
            SceneManager.LoadScene("BadEnding");
        }
        else if(isWin && !isReduce)
        {
            _Text3.text = "You proved that you didn't kill this man, but you had something to do with it, " +
                "and the police arrested you and sentenced you to five years in prison";
            yield return new WaitForSeconds(5);
            SceneManager.LoadScene("HappyEnding");
        }
    }
    IEnumerator ChangeScene5()
    {
        _Text2.text = "I killed Philips, so I found a group: Donald, Walter, and Brix to help me cover it up";
        yield return new WaitForSeconds(Timer);
        Q2.SetActive(false);
        Q3.SetActive(true);
        if (!isWin)
        {
            SceneManager.LoadScene("BadEnding");
        }
        else if (isWin && isReduce)
        {
            _Text3.text = "You proved that you didn't kill this man, and you helped the police solve another murder, " +
                "which went a long way in the courtroom, and you got three years off a five-year sentence.";
            yield return new WaitForSeconds(5);
            SceneManager.LoadScene("HappyEnding");
        }
    }

    void buttonInteractable(int temp)
    {
        if(temp==4)
        {
            for (int i = 0; i <= temp; i++)
            {
                buttons2[i].interactable = false;
            }
        }
        else if(temp==2)
        {
            for (int i = 0; i <= temp; i++)
            {
                buttons[i].interactable = false;
            }
        }
    }
}
