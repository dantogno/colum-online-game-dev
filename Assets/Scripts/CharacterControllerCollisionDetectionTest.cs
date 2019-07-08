using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterControllerCollisionDetectionTest : MonoBehaviour
{
    private void OnControllerColliderHit(ControllerColliderHit hit)
    {
        //if (hit.gameObject.name == "Special Cube")
        //    Debug.Log("Character hit the special cube.");

        if (hit.gameObject.tag != "Floor")
            Debug.Log("We hit something not tagged floor.");
    }
}
