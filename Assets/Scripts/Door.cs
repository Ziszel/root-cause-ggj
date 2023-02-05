using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Door : MonoBehaviour
{
    //1209
    public Button btn1;
    //1026
    public Button btn2;
    //meeting room
    public Button btn3;
    public List<Sprite> sprites = new List<Sprite>();
    // Start is called before the first frame update
    void Start()
    {
        if(!GameManager.Instance.door(1))
        {
            btn2.interactable = false;
        }
        if(!GameManager.Instance.door(2))
        {
            btn3.interactable = false;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ChangeRoom(int doorNumber)
    {
        switch(doorNumber)
        {
            case 0:
                SceneManager.LoadScene("1209");
                btn2.interactable = true;
                GameManager.Instance.canOpenDoorArray[1] = true;
                btn1.image.sprite = sprites[1];
                StartCoroutine("ClickEffect");
                break;
            case 1:
                SceneManager.LoadScene("1206-1");
                btn3.interactable = true;
                GameManager.Instance.canOpenDoorArray[2] = true;
                btn2.image.sprite = sprites[3];
                StartCoroutine("ClickEffect2");
                break;
            case 2:
                SceneManager.LoadScene("MeetingRoom");
                btn3.image.color = new Color(255, 255, 255, 255);
                StartCoroutine("ClickEffect3");
                break;
            default:
                break;
        }
    }

    IEnumerator ClickEffect()
    {
        yield return new WaitForSeconds(1);
        btn1.image.sprite = sprites[0];
    }

    IEnumerator ClickEffect2()
    {
        yield return new WaitForSeconds(1);
        btn2.image.sprite = sprites[2];
    }

    IEnumerator ClickEffect3()
    {
        yield return new WaitForSeconds(1);
        btn3.image.color = new Color(255, 255, 255, 0);
    }
}
