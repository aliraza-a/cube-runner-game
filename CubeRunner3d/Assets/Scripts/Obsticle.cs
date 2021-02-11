using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obsticle : MonoBehaviour
{
    //obsticle movement speed
    public float speed;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //move obsticle on z-axix with function
        transform.Translate(0, 0, speed * Time.deltaTime);

        //destroy obsticle when it passes the screen
        if(transform.position.z < -10f)
        {
            //call increase score function
            GameManager.instance.ScoreUp();

            //destroy obsticle object
            Destroy(gameObject);
        }
    }
}
