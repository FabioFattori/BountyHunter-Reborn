using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class followPlayer : MonoBehaviour
{
    private Vector3 offset = new Vector3(0f, 0f, -10f);
    private float smoothTime = 0f;
    private Vector3 velocity = Vector3.zero;
    [SerializeField] private Transform player;
    public loadTile map;

    [SerializeField] public Camera cam;


    // Update is called once per frame
    void Update()
    {
        bool outOfBounds = false;
        var borders = map.getBorderds();
        var newPosition = player.position.x;


        if (borders[0] + cam.orthographicSize + 4 > player.position.x)
        {
            outOfBounds = true;
            Vector3 targetPosition = new Vector3(borders[0] + cam.orthographicSize + 4, player.position.y, transform.position.z);
            transform.position = Vector3.SmoothDamp(transform.position, targetPosition, ref velocity, smoothTime);
            newPosition = borders[0] + cam.orthographicSize + 4;
        }
        else if (borders[2] - cam.orthographicSize - 4 < player.position.x)
        {
            outOfBounds = true;
            Vector3 targetPosition = new Vector3(borders[2] - cam.orthographicSize - 4, player.position.y, transform.position.z);
            transform.position = Vector3.SmoothDamp(transform.position, targetPosition, ref velocity, smoothTime);
            newPosition = borders[2] - cam.orthographicSize - 4;
        }
        if (borders[1] + cam.orthographicSize > player.position.y)
        {
            outOfBounds = true;
            Vector3 targetPosition = new Vector3(newPosition, borders[1] + cam.orthographicSize, transform.position.z);
            //check if target position is equal to the current position of the camera to avoid the camera to move when the player is in the same position


            transform.position = Vector3.SmoothDamp(transform.position, targetPosition, ref velocity, smoothTime);

        }
        else if (borders[3] - cam.orthographicSize < player.position.y)
        {
            outOfBounds = true;
            Vector3 targetPosition = new Vector3(newPosition, borders[3] - cam.orthographicSize, transform.position.z);

            transform.position = Vector3.SmoothDamp(transform.position, targetPosition, ref velocity, smoothTime);


        }

        if (!outOfBounds)
        {
            Vector3 targetPosition = player.position + offset;
            transform.position = Vector3.SmoothDamp(transform.position, targetPosition, ref velocity, smoothTime);
        }
    }
}
