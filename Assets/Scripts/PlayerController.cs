using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] public Rigidbody2D rb;
    [SerializeField] private float distanceToItem;

    private float _hInput;
    private float _vInput;
    private Vector2 _movement;
    private GameObject[] _itemsObjects;
    private List<ItemImage> _items;

    private void Start()
    {
        _items = new List<ItemImage>();
        _itemsObjects = GameObject.FindGameObjectsWithTag("Item");
        for (int i = 0; i < _itemsObjects.Length; ++i)
        {
            //_items.Add(_itemsObjects[i].GetComponent<ItemText>());
            _items.Add(_itemsObjects[i].GetComponent<ItemImage>());
        }
        Debug.Log(_items.Count);
    }

    // Update is called once per frame
    void Update()
    {
        _movement.x = Input.GetAxisRaw("Horizontal");
        _movement.y = Input.GetAxisRaw("Vertical");
        // if player presses A
        // if within a distance less than tolerance -> return THAT item
        // call the method inside of GameManager, passing in that item
        if (Input.GetKeyDown("space"))
        {
            ItemImage closestItem = GetClosestItemWithinTolerance();
            if (closestItem) // might need a null check here
            {
                GameManager.Instance.ImageOnScreen(closestItem);
                //GameManager.Instance.PresentText(closestItem.text, closestItem.transform);
                //closestItem.CheckForTextUpdate();
            }
        }
    }

    private void FixedUpdate()
    {
        MovePlayer();
    }

    private void MovePlayer()
    {
        rb.MovePosition(rb.position + _movement.normalized * speed * Time.fixedDeltaTime);
    }

    private ItemImage GetClosestItemWithinTolerance()
    {
        // check the distance between list of items
        foreach (var item in _items)
        {
            if (DistanceBetween(item) < distanceToItem)
            {
                return item;
            }
        }

        return null;
    }

    private float DistanceBetween(ItemImage item)
    {
        return Vector2.Distance(this.transform.position, item.transform.position);
    }

}
