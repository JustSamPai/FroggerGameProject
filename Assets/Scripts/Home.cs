using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Home : MonoBehaviour
{
    public GameObject HomeFrog;

    private void OnEnable()
    {
        HomeFrog.SetActive(true);
    }

    private void OnDisable()
    {
        HomeFrog.SetActive(false);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            enabled = true;
        
            FindObjectOfType<GameManager>().HomeOccupied();
            
            
        }
    }
}
