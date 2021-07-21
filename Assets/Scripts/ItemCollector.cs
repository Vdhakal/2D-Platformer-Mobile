using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class ItemCollector : MonoBehaviour
{
    [SerializeField] private TMP_Text bananasText;
    private int bananas = 0;
   
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Bananan")) 
        {
            Destroy(collision.gameObject);
            bananas++;
            bananasText.text = "Kera: " + bananas + "/2100";
        }
    }
}
