using UnityEngine;

public class Rotator : MonoBehaviour
{

    void Update()
    {
        transform.Rotate(new Vector3(0f,0f, 90f*Time.deltaTime));
    }
}
