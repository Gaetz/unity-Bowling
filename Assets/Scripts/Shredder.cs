using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shredder : MonoBehaviour {


    private void OnTriggerExit(Collider collider)
    {
        if (collider.GetComponentInParent<Pin>())
        {
            Destroy(collider.transform.parent.gameObject);
        }
    }
}
