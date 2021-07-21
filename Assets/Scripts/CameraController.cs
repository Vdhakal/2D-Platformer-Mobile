using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField]private Transform player;
    [SerializeField]private Transform coin;
    private void Start()
    {
        transform.position = new Vector3(0f, player.position.y, -10);
    }
    private void Update()
    {
        float posX = transform.position.x;
        float posY = player.position.y;
        Debug.Log(player.position.x +"  "+ coin.position.x);
        if (player.position.x >= coin.position.x)
        {
            posX = player.position.x;
        }
        transform.position = new Vector3(posX, posY, -10);
    }
}
