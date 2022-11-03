using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stone : MonoBehaviour
{
    private const float yDie = -30.0f;
    public GameObject expolosion;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(transform.position.y < yDie)
        {
            Destroy(gameObject);
        }
    }
    private void OnMouseDown()
    {
        Destroy(Instantiate(expolosion, transform.position, Quaternion.identity), 2.0f);
        Destroy(gameObject);
        GameManager.currentNumberDestroyedStones++;
    }
}
