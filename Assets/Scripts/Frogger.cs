using System.Collections;
using System.Collections.Generic;

using UnityEngine;

public class Frogger : MonoBehaviour
{
    public Frogger _frogger;
    private SpriteRenderer spriteRenderer;
    private Vector3 spawnPoint;
    public Sprite idleSprite;
    public Sprite leapSprite;
    public Sprite deadSprite;
    private float farthestRow;
    public GameManager gameManager;
    
 

    private void Awake()
    {
        
        spriteRenderer = GetComponent<SpriteRenderer>();
        spawnPoint = transform.position;
    }

    // Update is called once per frame
    private void Update()
    {
        // if (!PauseMenu.isPaused)
        // {
        //     if (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow))
        //     {
        //         ICommand storedCommand = new MoveCommand(this, Vector3.up);
        //         transform.rotation = Quaternion.Euler(0f, 0f, 0f);
        //         storedCommand.Execute();
        //         // transform.rotation = Quaternion.Euler(0f, 0f, 0f);
        //         // Move(Vector3.up);
        //     }
        //     else if (Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.DownArrow))
        //     {
        //         ICommand storedCommand = new MoveCommand(this, Vector3.down);
        //         transform.rotation = Quaternion.Euler(0f, 0f, 180f);
        //         storedCommand.Execute();
        //         // transform.rotation = Quaternion.Euler(0f, 0f, 180f);
        //         // Move(Vector3.down);
        //     }
        //     else if (Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.LeftArrow))
        //     {
        //         ICommand storedCommand = new MoveCommand(this, Vector3.left);
        //         transform.rotation = Quaternion.Euler(0f, 0f, 90f);
        //         storedCommand.Execute();
        //         // transform.rotation = Quaternion.Euler(0f, 0f, 90f);
        //         // Move(Vector3.left);
        //     }
        //     else if (Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.RightArrow))
        //     {
        //         ICommand storedCommand = new MoveCommand(this, Vector3.right);
        //         transform.rotation = Quaternion.Euler(0f, 0f, -90f);
        //         storedCommand.Execute();
        //         // transform.rotation = Quaternion.Euler(0f, 0f, -90f);
        //         // Move(Vector3.right);
        //     }
        // }
    }
    public void Move(Vector3 direction)
    {
        //transform.position += direction;
        Vector3 destination = transform.position + direction;

        Collider2D barrier = Physics2D.OverlapBox(destination, Vector2.zero, 0f, LayerMask.GetMask("Barrier"));
        Collider2D platform = Physics2D.OverlapBox(destination, Vector2.zero, 0f, LayerMask.GetMask("Platform"));
        Collider2D obstacle = Physics2D.OverlapBox(destination, Vector2.zero, 0f, LayerMask.GetMask("Obstacle")); 
        
        if (barrier != null)
        {
            return;
        }

        if (platform != null)
        {
            transform.SetParent(platform.transform);
        } else
        {
            transform.SetParent(null);
        }
        if(obstacle != null && platform == null)
        {
            transform.position = destination;
            Death();
        } 
        else
        {
            if (destination.y > farthestRow)
            {
                farthestRow = destination.y;
                FindObjectOfType<GameManager>().AdvancedRow();
            }
            StartCoroutine(Leap(destination));
        }
    }
    private IEnumerator Leap(Vector3 destination)
    {
        Vector3 startPosition = transform.position;
        float elapsed = 0f;
        float duration = 0.125f;

        spriteRenderer.sprite = leapSprite;

        while (elapsed < duration)
        {
            float t = elapsed / duration;
            transform.position = Vector3.Lerp(startPosition, destination, t);
            elapsed += Time.unscaledDeltaTime;
            yield return null;
        }
        transform.position = destination;
        spriteRenderer.sprite = idleSprite;

    }
    public void Death()
    {   
        StopAllCoroutines();
        gameManager.allowInput = false;
        enabled = false;

        transform.rotation = Quaternion.identity;
        spriteRenderer.sprite = deadSprite;


        FindObjectOfType<GameManager>().Died();
    }

    public void Respawn()
    {
        StopAllCoroutines();

        transform.rotation = Quaternion.identity;
        transform.position = spawnPoint;
        farthestRow= spawnPoint.y;
        spriteRenderer.sprite = idleSprite;
        gameObject.SetActive(true);
        enabled = true;
        gameManager.allowInput = true;
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (enabled && collision.gameObject.layer == LayerMask.NameToLayer("Obstacle") && transform.parent == null)
        {
            Death();
        }
    }


}
