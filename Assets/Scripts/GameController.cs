using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    private PlayerController player;

    public Camera cam;

    public float playerX;
    public float playerY;

    public Slider forceBar;

    public float offsetX, offsetY, limitedLeft, limitedRight, limitedDown, limitedUp, smoothTime;

    void Start()
    {
        player = FindObjectOfType<PlayerController>();
        
    }

    // Update is called once per frame
    void Update()
    {
        
        forceBar.value = player.jumpForce;

        playerX = Mathf.Clamp(player.transform.position.x + offsetX, limitedLeft, limitedRight);
        playerY = Mathf.Clamp(player.transform.position.y + offsetY, limitedDown, limitedUp);

        cam.transform.position = Vector3.Lerp(cam.transform.position, new Vector3(playerX, playerY, cam.transform.position.z), smoothTime);
        
    }





}
