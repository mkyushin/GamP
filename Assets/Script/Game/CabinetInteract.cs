using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractCabinet : MonoBehaviour
{
    public Transform doorL;
    public Transform doorR;



    public void OpenCabinet()
    {   
        Vector3 currentVector_doorL = doorL.transform.position;
        Vector3 rotationAxis_doorL = new Vector3(currentVector_doorL.x, currentVector_doorL.y, currentVector_doorL.z - 1.0f );
        Quaternion rotationQuaternion = Quaternion.AngleAxis(90.0f, rotationAxis_doorL);

        doorL.transform.rotation = rotationQuaternion;

    }
    // Start is called before the first frame update


    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {   

    }
}
