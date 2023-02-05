using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class player2 : MonoBehaviour
{
    [SerializeField] private float speed;
    private Rigidbody2D rb;
    private Vector2 _movement;
    public TMP_Text _Text;
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
        Check();
    }

    private void FixedUpdate()
    {
        MovePlayer();
    }

    private void MovePlayer()
    {
        rb.MovePosition(rb.position + _movement.normalized * speed * Time.fixedDeltaTime);
    }


    bool Drag = false;
    bool Rubbish = false;
    bool Mobile = false;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Drag"))
        {
            _Text.text = "A medicine for the treatment of injuries";
            Drag = true;
        }
        else if(collision.CompareTag("Rubbish"))
        {
            _Text.text = "Unused potassium chloride";
            Rubbish = true;
        }
        else if(collision.CompareTag("Mobile"))
        {
            _Text.text = "Donald's wife and Brix's sexy messages were recorded on the phone, and the purchase of dry ice";
            Mobile = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Drag"))
        {
            _Text.text = "";
        }
        else if (collision.CompareTag("Rubbish"))
        {
            _Text.text = "";
        }
        else if (collision.CompareTag("Mobile"))
        {
            _Text.text = "";
        }
    }

    void Check()
    {
        if(Drag&&Mobile&&Rubbish)
        {
            StartCoroutine("ChangeScene");
        }
    }

    IEnumerator ChangeScene()
    {
        yield return new WaitForSeconds(3);
        SceneManager.LoadScene("PolicemanClue");
    }
}
