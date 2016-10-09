using UnityEngine;
using System.Collections;

public class ViveCutter : MonoBehaviour
{
    public Vector3 m_LastPosition;
    public float m_Speed;
    public Material capMaterial;

    void Awake()
    {
        m_LastPosition = transform.position;
    }

    void Update()
    {
        Vector3 velocity = (transform.position - m_LastPosition) / Time.deltaTime;
        m_Speed = velocity.magnitude;
        m_LastPosition = transform.position;
        Debug.Log("velocity is " + velocity.magnitude);
    }

    void OnCollisionEnter(Collision collision)
    {
        Rigidbody rigid = GetComponent<Rigidbody>();
        Debug.Log("collision speed " + rigid.velocity.magnitude);
        if (m_Speed < 4f)
            return;

        GameObject victim = collision.collider.gameObject;

        GameObject[] pieces = BLINDED_AM_ME.MeshCut.Cut(victim, transform.position, transform.right, capMaterial);

        if (!pieces[1].GetComponent<Rigidbody>())
            pieces[1].AddComponent<Rigidbody>();

        if (!pieces[0].GetComponent<Rigidbody>())
            pieces[0].AddComponent<Rigidbody>();

        if (pieces[0].GetComponent<BoxCollider>())
            Destroy(pieces[0].GetComponent<BoxCollider>());
        if (pieces[1].GetComponent<BoxCollider>())
            Destroy(pieces[1].GetComponent<BoxCollider>());
        
        MeshCollider leftCollider = pieces[0].AddComponent<MeshCollider>();
        MeshCollider rightCollider = pieces[1].AddComponent<MeshCollider>();
        pieces[0].layer = LayerMask.NameToLayer("NonInteracting");
        pieces[1].layer = LayerMask.NameToLayer("NonInteracting");

        leftCollider.convex = true;
        rightCollider.convex = true;

        StartCoroutine(ResetLayer(pieces[0]));
        StartCoroutine(ResetLayer(pieces[1]));
    }

    IEnumerator ResetLayer(GameObject piece)
    {
        yield return new WaitForSeconds(0.25f);
        piece.layer = LayerMask.NameToLayer("Default");
    }

}
