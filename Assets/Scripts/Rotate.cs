using UnityEngine;

public class Rotate : MonoBehaviour
{
    public bool rotateOnX;
    public bool rotateOnY;
    public bool rotateOnZ;

	void Update ()
    {
        if (rotateOnX)
        {
            transform.Rotate(Vector3.right * Time.deltaTime * 25f);
        }

        if (rotateOnY)
        {
            transform.Rotate(Vector3.up * Time.deltaTime * 25f);
        }

        if (rotateOnZ)
        {
            transform.Rotate(Vector3.forward * Time.deltaTime * 25f);
        }
       
        
    }
}
