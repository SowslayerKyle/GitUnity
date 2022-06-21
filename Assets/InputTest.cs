using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputTest : MonoBehaviour
{
    // Start is called before the first frame update
    public Camera m_Camera;
    public float fRS = 1.0f;
    public float fMS = 5.0f;
    public float roateLimit = 45.0f;
    private Vector3 horzontalVector;
    private float fCurrentRoateAngle = 0.0f;
    public LayerMask mHitLayers;
    public Transform mEmitPoint;
    public float mMinHitDistance;
    public Bullet bullet;
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        float fMX = Input.GetAxis("Mouse X");
        float fMY = -Input.GetAxis("Mouse Y");
        transform.Rotate(0, fMX * fRS, 0);
        horzontalVector = transform.forward;
        fCurrentRoateAngle += fMY;
        //控制視角最大為45度
        if (fCurrentRoateAngle > 45.0f)
        {
            fCurrentRoateAngle = 45.0f;
        }
        else if (fCurrentRoateAngle < -45.0f)
        {
            fCurrentRoateAngle = -45.0f;
        }

        Vector3 newFor = Quaternion.AngleAxis(fCurrentRoateAngle, transform.right) * horzontalVector;
        m_Camera.transform.forward = newFor;
        //m_Camera.transform.forward = horzontalVector;
        //m_Camera.transform.Rotate(fCurrentRoateAngle, 0.0f, 0.0f);

        //m_Camera.transform.Rotate(-fMY * fRS, 0.0f, 0.0f);
        //Vector3 vFor = m_Camera.transform.forward;
        //Vector3 vForH = vFor;

        //vForH.y = 0.0f;
        //float fAngle = Vector3.Angle(vFor, vForH);
        Debug.Log("Agngle" + fCurrentRoateAngle);
        //if (fAngle > 45) 
        //{
        //    m_Camera.transform.forward = transform.forward;
        //    if(vForH.y > 0)
        //    {
        //        m_Camera.transform.Rotate(-45.0f, 0.0f, 0.0f);
        //    }
        //    else 
        //    {
        //        m_Camera.transform.Rotate(45.0f, 0.0f, 0.0f);
        //    }

        //}

        //使用WASD移動
        float fH = Input.GetAxis("Horizontal");
        float fV = Input.GetAxis("Vertical");
        //float fMoveSpeed = 1.0f;
        //Debug.Log(fV);
        float vMoveAmount = fMS * Time.deltaTime;
        Vector3 vMoveH = transform.right * fH;
        Vector3 vMoveV = transform.forward * fV;
        transform.position = transform.position + (vMoveV + vMoveH) * vMoveAmount;
        //按下空白鍵射擊
        if (Input.GetKeyDown(KeyCode.Space))
        {
            //取得螢幕中心點
            Ray r = new Ray(m_Camera.transform.position, m_Camera.transform.forward);
            //Ray r= m_Camera.ScreenPointToRay(new Vector3(Screen.width/2,Screen.height/2,0.0f));
            RaycastHit rh;
            Vector3 vTarget = m_Camera.transform.position + m_Camera.transform.forward * 10.0f;

            if (Physics.Raycast(r, out rh, 1000.0f, mHitLayers))
            {
                vTarget = rh.point;

                float fHDist = rh.distance;
                if (fHDist < mMinHitDistance)
                {
                    fHDist = mMinHitDistance;
                    vTarget = m_Camera.transform.position + m_Camera.transform.forward * fHDist;
                }
            }
            Vector3 vec = vTarget - mEmitPoint.position;
            bullet.transform.position = mEmitPoint.position;
            bullet.fire(vec);
        }
    }
}
