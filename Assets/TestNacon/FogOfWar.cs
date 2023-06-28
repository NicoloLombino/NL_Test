using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FogOfWar : MonoBehaviour
{
    [SerializeField]
    private GameObject fogOfWarPlane;
    [SerializeField]
    private Transform player;
    [SerializeField]
    private LayerMask fogLayer;
    [SerializeField]
    private float radius;
    [SerializeField]
    private float radiusSqr;
    [SerializeField]
    private Mesh fogOfWarPlaneMesh;

    private Vector3[] verticles;
    private Color[] colors;

    public bool aa = true;
    Ray ray;

    private void Awake()
    {
        fogOfWarPlaneMesh = fogOfWarPlane.GetComponent<MeshFilter>().mesh;
        verticles = fogOfWarPlaneMesh.vertices;
        colors = new Color[verticles.Length];
        for(int i = 0; i < colors.Length; i++)
        {
            colors[i] = Color.black;
        }
    }
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        ray = new Ray(transform.position, transform.forward);

        //if (Physics.Raycast(transform.position, Vector3.up, out RaycastHit hit, 1000, fogLayer, QueryTriggerInteraction.Collide))
        //if (Physics.BoxCast(transform.position, player.localScale, transform.forward,  out RaycastHit hit, transform.rotation, 1000, fogLayer, QueryTriggerInteraction.Collide))
        if(Physics.Raycast(ray, out RaycastHit hit, 1000, fogLayer, QueryTriggerInteraction.Collide))
        {
            for (int i = 0; i < verticles.Length; i++)
            {
                Vector3 vector = fogOfWarPlane.transform.TransformPoint(verticles[i]);
                float distance = Vector3.SqrMagnitude(vector - hit.point);
                if (distance < radiusSqr)
                {
                    if (aa) { Debug.Log(i + " " + distance); }
                    //float alpha = Mathf.Min(colors[i].a, distance / radiusSqr);
                    colors[i].a = 0;
                }
            }
            UpdateColors();
            aa = false;
        }
    }

    private void OnDrawGizmos()
    {
        //Gizmos.DrawWireCube(transform.position - transform.forward * 10, transform.localScale);
        //Gizmos.DrawLine(transform.position, transform.position + new Vector3(0,0,10));
        Gizmos.DrawRay(ray);
    }

    private void UpdateColors()
    {
        fogOfWarPlaneMesh.colors = colors;
    }
}
