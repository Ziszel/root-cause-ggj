using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Player1 : MonoBehaviour
{
    [SerializeField] private float speed;
    private Rigidbody2D rb;
    private Vector2 _movement;
    public GameObject ItemPanel;
    public Image image;
    public TMP_Text _Text;
    public TMP_Text _Text2;
    public List<Sprite> sprites = new List<Sprite>();
    public bool isShow = false;
    public List<string> strings = new List<string>();
    private int itemNum = 0;
    public Button yes;
    public Button no;
    // Start is called before the first frame update
    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        _movement.x = Input.GetAxisRaw("Horizontal");
        _movement.y = Input.GetAxisRaw("Vertical");
    }

    private void FixedUpdate()
    {
        MovePlayer();
    }

    private void MovePlayer()
    {
        rb.MovePosition(rb.position + _movement.normalized * speed * Time.fixedDeltaTime);
    }


    bool knives=false;
    bool redwine=false;
    bool room1blood=false;
    bool lamp=false;
    bool plant=false;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("knives"))
        {
            if (!isShow)
            {
                ShowUI();
                _Text.text = strings[0];
                image.sprite = sprites[0];
                //image.GetComponent<Image>().sprite = sprites[0];
                knives = true;
            }
        }
        else if (collision.CompareTag("redwine"))
        {
            if (!isShow)
            {
                ShowUI();
                _Text.text = strings[1];
                image.sprite = sprites[0];
                //image.GetComponent<Image>().sprite = sprites[0];
                redwine = true;
            }
        }
        else if (collision.CompareTag("room1blood"))
        {
            if (!isShow)
            {
                ShowUI();
                _Text.text = strings[2];
                image.sprite = sprites[0];
                //image.GetComponent<Image>().sprite = sprites[0];
                room1blood = true;
            }
        }
        else if (collision.CompareTag("lamp"))
        {
            if (!isShow)
            {
                ShowUI();
                _Text.text = strings[3];
                //image.GetComponent<Image>().sprite = sprites[0];
                image.sprite = sprites[1];
                lamp = true;
            }
        }
        else if (collision.CompareTag("plant"))
        {
            if (!isShow)
            {
                ShowUI();
                _Text.text = strings[4];
                //image.GetComponent<Image>().sprite = sprites[0];
                image.sprite = sprites[1];
                plant = true;
            }
        }
        else if (collision.CompareTag("Door"))
        {
            if (!isShow)
            {
                ShowUI();
                //image.GetComponent<Image>().sprite = sprites[0];
                if (knives&&redwine&&room1blood&&lamp&&plant)
                {
                    image.enabled = false;
                    SceneManager.LoadScene("Conversation");
                }
                else
                {
                    _Text2.text = "That's weird. Do you want to explore more?";
                    yes.image.enabled = true;
                    no.image.enabled = true;
                    yes.enabled = true;
                    no.enabled = true;
                }
            }
        }
        else if (collision.CompareTag("Body"))
        {
            SceneManager.LoadScene("1206-2");
        }


    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        CloseUI();
        _Text.text = strings[6];
    }

    void ShowUI()
    {
        image.enabled = true;
        isShow = true;
    }

    void CloseUI()
    {
        image.enabled = false;
        isShow = false;
    }

    public void Yes()
    {
        SceneManager.LoadScene("BadEnding");
    }

    public void No()
    {
        yes.image.enabled = false;
        no.image.enabled = false;
        yes.enabled = false;
        no.enabled = false;
        _Text2.text = "";
    }
}
