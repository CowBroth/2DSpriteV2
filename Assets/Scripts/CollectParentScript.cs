using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CollectParentScript : MonoBehaviour
{

    public int amount = 0;

    public GameObject TMP;
    private TMP_Text Ctext;

    // Start is called before the first frame update
    void Start()
    {
        Ctext = TMP.GetComponent<TMP_Text>();
    }

    // Update is called once per frame
    void Update()
    {
        Ctext.text = ("C     " + amount);
    }

}
