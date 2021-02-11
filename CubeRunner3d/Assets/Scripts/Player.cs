using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    //player movement speed
    public float dodgeSpeed;

    //player movement limit x-axis
    public float maxX;

    //key press input
    float xInput;

    //player limit
    float limitedX;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //get key input from keyboard to move left and right
        xInput = Input.GetAxis("Horizontal");

        //get input from touch
        TouchInput();

        //move the player with function
        transform.Translate(xInput*dodgeSpeed*Time.deltaTime, 0, 0);

        //limit player movement x-axis with function
        limitedX = Mathf.Clamp(transform.position.x, -maxX, maxX);
        transform.position = new Vector3(limitedX, transform.position.y, transform.position.z);
    }

    //function to get touch input
    void TouchInput()
    {
        if (Input.GetMouseButton(0))
        {
            Vector3 touchPos = Input.mousePosition;
            float middle = Screen.width / 2;
            if(touchPos.x < middle)
            {
                xInput = -1;
            }
            else if(touchPos.x > middle)
            {
                xInput = 1;
            }
        }
    }
    //player collision
    private void OnTriggerEnter(Collider col)
    {
        if(col.gameObject.tag == "Obsticle")
        {
            GameManager.instance.Restart();
        }
    }
}
