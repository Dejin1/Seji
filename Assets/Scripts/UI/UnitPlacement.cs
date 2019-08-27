using UnityEngine;
using System.Collections;

public class UnitPlacement : MonoBehaviour
{

    public GameObject Prefab;
    public int RayDistance = 10;
    private Vector3 Point;
    public LayerMask Whatever;

    public void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Vector2 mousePos2D = new Vector2(mousePos.x, mousePos.y);
            //Debug.Log(mousePos2D);
            RaycastHit2D click = Physics2D.Raycast(mousePos2D, Vector2.zero);
            if (click.collider != null)
                Debug.Log(click.collider.gameObject.name);


            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            Point.z = 0;
            //Debug.Log(ray);


            if (click.collider == null)
                Instantiate(Prefab, ray.origin, Quaternion.identity);
            
        }
    }
}