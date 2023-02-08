using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    private Vector3 player_Position = Vector3.zero;
    private Vector3 velocity = Vector3.zero;
    private Vector3 acceleration = Vector3.zero;
    private Vector3 direction = Vector3.right;

    private Vector3 Position
    {
        get
        {
            float _x = (transform.position.x - 5.0f) / 10.0f;
            float _y = (transform.position.y - 2.5f) / 5.0f;

            float scaledX = Mathf.Lerp(_x, 0, Screen.width);
            float scaledY = Mathf.Lerp(_y, 0, Screen.height);

            return new Vector3(scaledX, scaledY, 0);
        }

        set
        {
            float _x = value.x / Screen.width;
            float _y = value.y / Screen.height;

            float scaledX = Mathf.Lerp(_x, -5.0f, 5.0f);
            float scaledY = Mathf.Lerp(_y, 2.5f, 2.5f);

            transform.position = new Vector3(scaledX, scaledY, 0);
        }
    }

    [SerializeField]
    float strength = 10f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 mousePos = Input.mousePosition;

        direction = Vector3.Normalize(mousePos - Position);

        /**
        acceleration = (strength / Vector3.SqrMagnitude(mousePos - player_Position)) * direction;

        velocity += acceleration * Time.deltaTime;
        player_Position += velocity * Time.deltaTime;

        transform.position = player_Position;
        */

        Position += strength * direction * Time.deltaTime;
    }
}