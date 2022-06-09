using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputTest : MonoBehaviour
{
    // Start is called before the first frame update
    public Transform m_Camera;
    public float fRS = 1.0f;
    public float fMS = 5.0f;
    public float roateLimit = 45.0f;
    private Vector3 horzontalVector;
    private float fCurrentRoateAngle=0.0f;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float fMX = Input.GetAxis("Mouse X");
        float fMY = Input.GetAxis("Mouse Y");
        transform.Rotate(0, fMX * fRS, 0);
        horzontalVector = transform.forward;
        fCurrentRoateAngle += fMY;
        if (fCurrentRoateAngle > 45.0f)
        {
            fCurrentRoateAngle = 45.0f;
        } else if (fCurrentRoateAngle<-45.0f)
        {
            fCurrentRoateAngle = -45.0f;
        }
        m_Camera.forward = horzontalVector;
        m_Camera.Rotate(-fCurrentRoateAngle, 0.0f, 0.0f);

        //m_Camera.Rotate(-fMY * fRS, 0.0f, 0.0f);
        //Vector3 vFor = m_Camera.forward;
        //Vector3 vForH = vFor;

        //vForH.y = 0.0f;
        //float fAngle = Vector3.Angle(vFor, vForH);
        Debug.Log("Agngle" + fCurrentRoateAngle);
        //if (fAngle > 45) 
        //{
        //    m_Camera.forward = transform.forward;
        //    if(vForH.y > 0)
        //    {
        //        m_Camera.Rotate(-45.0f, 0.0f, 0.0f);
        //    }
        //    else 
        //    {
        //        m_Camera.Rotate(45.0f, 0.0f, 0.0f);
        //    }

        //}

        float fH = Input.GetAxis("Horizontal");
        float fV = Input.GetAxis("Vertical");//-1~1

        //float fMoveSpeed = 1.0f;
        //Debug.Log(fV);
        float vMoveAmount= fMS * Time.deltaTime;
        Vector3 vMoveH = transform.right * fH;
        Vector3 vMoveV = transform.forward * fV;
        transform.position = transform.position+(vMoveV+ vMoveH)*vMoveAmount;
    }
}
