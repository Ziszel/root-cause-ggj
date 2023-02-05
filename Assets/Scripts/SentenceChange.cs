using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SentenceChange : MonoBehaviour
{
    public List<string> ScentenceList = new List<string>();
    public int listIndex;
    public TMP_Text text;
    public GameObject scentencePanel;
    public List<Sprite> sprites = new List<Sprite>();
    public Image image;
    public int SceneID;
    public int max;
    public Image image2;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(listIndex<max)
        {
            flip();
        }
        else
        {
            if (Input.GetMouseButtonDown(0))
            {
                SceneChange();
            }

        }
    }

    void flip()
    {
        if(Input.GetMouseButtonDown(0))
        {
            text.text = ScentenceList[listIndex].ToString();
            listIndex++;
            imageChange();
        }
    }

    void imageChange()
    {
        if (SceneID == 1)
        {
            if(listIndex==1)
            {
                image2.enabled = true;
            }
            if (listIndex == 4)
            {
                image.sprite = sprites[1];
                text.fontStyle = FontStyles.Italic;
            }
        }
        else if(SceneID==6)
        {
            if(listIndex==3)
            {
                image.sprite = sprites[1];
            }
            if(listIndex==4)
            {
                image.sprite = sprites[0];
            }
        }
        else if(SceneID==8)
        {

        }
        else if(SceneID==9)
        {
            if(listIndex==2)
            {
                image.sprite = sprites[1];
            }
            else if(listIndex==3)
            {
                image.sprite = sprites[0];
                text.fontStyle = FontStyles.Italic;
            }
            else if (listIndex == 5)
            {
                image.sprite = sprites[1];
                text.fontStyle = FontStyles.Bold;
            }
        }
    }

    void SceneChange()
    {
        if(SceneID==1)
        {
            SceneManager.LoadScene("Corridor");
        }
        else if(SceneID==9)
        {
            SceneManager.LoadScene("Corridor");
        }
        else if(SceneID==6)
        {
            SceneManager.LoadScene("Corridor");
        }
        else if(SceneID==8)
        {
            SceneManager.LoadScene("MurdererIdentification");
        }
    }

    void PanelAppear()
    {
        scentencePanel.SetActive(true);
    }

    void PanelDisappear()
    {
        scentencePanel.SetActive(false);
    }
}
