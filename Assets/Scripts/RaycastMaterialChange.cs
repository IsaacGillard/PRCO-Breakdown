using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RaycastMaterialChange : MonoBehaviour {

    public Material[] material;

    public void OnHoverOver (GameObject target)
    {
        target.GetComponent<Renderer>().material = material[0];
    }

    public void ResetMaterial(GameObject target)
    {
        target.GetComponent<Renderer>().material = material[1];
    }
}
