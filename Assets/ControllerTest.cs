using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControllerTest : MonoBehaviour
{
    private CharacterController m_cc;
    public float m_fSpeed;
    private Vector3 vUpMotion;
    // Start is called before the first frame update
    void Start()
    {
        m_cc = GetComponent<CharacterController>();
        vUpMotion = Vector3.zero;
    }

    // Update is called once per frame
    void Update()
    {
        float fH = Input.GetAxis("Horizontal");
        float fV = Input.GetAxis("Vertical");
        Vector3 vMoveH = transform.right * fH;
        Vector3 vMoveV = transform.forward * fV;
        Vector3 vUp = Physics.gravity;        
        if (Input.GetKeyDown(KeyCode.Space))
        {
            vUp = Vector3.up * 1000.0f;
        }
        else 
        {
            if (Physics.Linecast(transform.position + Vector3.up * 0.01f, transform.position - transform.up * 1.1f, 1 << LayerMask.NameToLayer("Terrain")))
            {
                Debug.Log("got hit");
                vUpMotion = Vector3.zero;
            }
        }
        vUpMotion = vUpMotion+ vUp*Time.deltaTime;
        Debug.Log(vUpMotion);
        //vUp *= Time.deltaTime;
        m_cc.Move(m_fSpeed * Time.deltaTime * (vMoveH + vMoveV)+vUpMotion*Time.deltaTime);
        
        //m_cc.SimpleMove(m_fSpeed*(vMoveH+ vMoveV));   
    }
    private void OnDrawGizmos()
    {
        Gizmos.DrawLine(transform.position + Vector3.up * 0.01f, transform.position - transform.up * 2.0f);
    }
}
