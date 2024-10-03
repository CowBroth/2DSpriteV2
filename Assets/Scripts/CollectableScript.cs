using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectableScript : MonoBehaviour
{

    public GameObject parent;
    private CollectParentScript pScript;

    // Start is called before the first frame update
    void Start()
    {
        pScript = parent.GetComponent<CollectParentScript>();
    }

    // Update is called once per frame
    void Update()
    {
       
    }

    private void OnTriggerEnter2D(Collider2D other)
    {

        if (other.CompareTag("PlayerTag"))
        {

            pScript.amount++;

            print("collectable");
            Destroy(gameObject);

        }

    }

}
