using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float fSpeed;
    private float fLifeTime = 5.0f;
    public ParticleSystem m_Ps;
    // Start is called before the first frame update
    void Start()
    {
        gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        float fMoveAount = fSpeed * Time.deltaTime;
        transform.position = transform.position + transform.forward * fMoveAount;
        if (fLifeTime<0)
        {
            gameObject.SetActive(false);
        }
    }
    public void fire(Vector3 vDirection)
    {
        gameObject.SetActive(true);
        gameObject.transform.forward = vDirection;
        fLifeTime = 5.0f;
    }
    private void OnTriggerEnter(Collider other)
    {
        gameObject.SetActive(false);
        //m_Ps.transform.position = gameObject.transform.position;
        GameObject go= Instantiate(m_Ps.gameObject);
        go.transform.position = gameObject.transform.position;
        go.SetActive(true);
        //m_Ps.Play();
    }
}
