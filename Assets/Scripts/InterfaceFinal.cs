using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class InterfaceFinal : MonoBehaviour
{
    public Text textThrown;
    public Text textDestroyed;
    // Start is called before the first frame update
    void Start()
    {
        textThrown.text = "Number of Stones Thrown: " + GameManager.currentNumberStonesThrown;
        textDestroyed.text = "Number of Stones Destroyed: " + GameManager.currentNumberDestroyedStones;
    }

    public void Click()
    {
        SceneManager.LoadScene("Awake");
    }
}
