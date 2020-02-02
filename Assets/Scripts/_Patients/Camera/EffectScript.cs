using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EffectScript : MonoBehaviour
{
    public GameObject blackScreen;
    public float scalingFactor = 0.001f;
    public float scalingFactorDark = 0.001f;
    public SpriteRenderer blackScreenSpriteRenderer;


    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (blackScreen.transform.localScale.x > 3 && blackScreen.transform.localScale.y > 2)
        {
            blackScreen.transform.localScale = new Vector3(blackScreen.transform.localScale.x - blackScreen.transform.localScale.x * scalingFactor * Time.deltaTime,
            blackScreen.transform.localScale.y - blackScreen.transform.localScale.y * scalingFactor * Time.deltaTime,
            blackScreen.transform.localScale.z - blackScreen.transform.localScale.z * scalingFactor * Time.deltaTime);
        }
        else {
            //Debug.Log("I should fade now");
            Color col = blackScreenSpriteRenderer.color;
            col.a +=  scalingFactorDark * Time.deltaTime;
            //col.a = 1;
            blackScreenSpriteRenderer.color = col;
        }

    }
}
