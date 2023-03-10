using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    private const float TEXT_TIMER = 2.0f;

    public TMP_Text textBox;
    public static GameManager Instance;
    public AudioSource song;
    private static string _currentText;
    private PlayerController _player;
    private Vector2 _textOffset;
    private readonly float _offsetAmount = 2.0f;
    private float textDisplayTimer;
    public bool imageOverlayOn;

    public void Awake()
    {
        if (Instance != null)
        {
            // We already have an instance so destroy the newly created one.
            Destroy(gameObject);
            return;
        }
        Instance = this;
        DontDestroyOnLoad(gameObject); // don't destroy the empty game object when loading a new scene
        //_player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
        _textOffset = new Vector2(_offsetAmount, 1.0f);
        textDisplayTimer = TEXT_TIMER;
        imageOverlayOn = false;
    }

    public void Update()
    {
        if (SceneManager.GetActiveScene().name =="HappyEnding")
        {
            song.Stop();
        }
    }

    public void PresentText(string text, Transform itemTransform)
    {
        ResetTimer();
        SetOffset(itemTransform);
        _currentText = text;
        textBox.text = _currentText;
        Debug.Log(text);
    }

    public void ImageOnScreen(ItemImage item)
    {
        item.HandleUI();
    }

    private void SetOffset(Transform itemTransform)
    {
        if (itemTransform.position.x < _player.transform.position.x)
        {
            _textOffset.x = _offsetAmount;
        }
        else if (itemTransform.position.x > _player.transform.position.x)
        {
            _textOffset.x = -_offsetAmount;
        }
    }

    private void ResetTimer()
    {
        textDisplayTimer = TEXT_TIMER;
    }

    //Di wrote the code below
    //Change to the endScene
    private int bookCurrentPage = 0;
    public int AddBookPage(int page)
    {
        bookCurrentPage += page;
        return bookCurrentPage;
    }
    public int GetBookPage()
    {
        return bookCurrentPage;
    }
    public bool[] canOpenDoorArray = new bool[3];
    public bool door(int id)
    {
        if (canOpenDoorArray[id])
        {
            return true;
        }
        else
        {
            return false;
        }
    }
}
