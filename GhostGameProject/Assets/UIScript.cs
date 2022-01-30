using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIScript : MonoBehaviour
{

    public int NumbGhosts = 0;
    public int NumbTalisman = 0;
    public GameObject ghostsText;
    public GameObject talismanText;
    

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        ghostsText.GetComponent<UnityEngine.UI.Text>().text = "Ghosts: " + NumbGhosts.ToString();
        talismanText.GetComponent<UnityEngine.UI.Text>().text = "Talisman (Left Alt): " + NumbTalisman.ToString();
    }
}
