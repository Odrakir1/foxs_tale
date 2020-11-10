using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LSCamera : MonoBehaviour
{
    public Vector2 minPos,maxPos;

    public Transform target;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void LateUpdate()
    {
        
        float posX = Mathf.Clamp(target.position.x,minPos.x,maxPos.x);
        float posY = Mathf.Clamp(target.position.y,minPos.y,maxPos.y);

        transform.position = new Vector3(posX,posY,transform.position.z);
    }
}
