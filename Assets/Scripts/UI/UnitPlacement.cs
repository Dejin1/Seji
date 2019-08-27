using UnityEngine;
using System.Collections;

public class UnitPlacement : MonoBehaviour
{

    public GameObject Prefab;
    public GameObject u1;
    public GameObject u2;
    public GameObject u3;
    public int RayDistance = 10;
    private Vector3 Point;
    public LayerMask Whatever;
    bool playerHasCash = false;
    //public int currency = 0;

    public struct Unit
    {
        public int cost;
        public GameObject unitObject;
    }

    public Unit currentUnit;
    public Unit Unit1;
    public Unit Unit2;
    public Unit Unit3;

    private void Start()
    {
        //Set Units
        Prefab = u1;
        Unit1.unitObject = u1;
        Unit1.cost = 100;
        Unit2.unitObject = u2;
        Unit2.cost = 200;
        Unit3.unitObject = u3;
        Unit3.cost = 300;

        currentUnit = Unit1;
    }

    public void Update()
    {
        if (GameManager.currency >= currentUnit.cost)
        {
            playerHasCash = true;
        }
        else
        {
            playerHasCash = false;
        }

        if (playerHasCash)
        {
            if (Input.GetMouseButtonDown(0))
            {
                Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                Vector2 mousePos2D = new Vector2(mousePos.x, mousePos.y);
                Debug.Log(mousePos2D);
                RaycastHit2D click = Physics2D.Raycast(mousePos2D, Vector2.zero);
                //if (click.collider != null)
                   // Debug.Log(click.collider.gameObject.name);


                //RaycastHit hit;
                Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                Point.z = 0;
                //Debug.Log(ray);

                if (click.collider == null && mousePos2D.y > -3)
                {
                    Instantiate(Prefab, ray.origin, Quaternion.identity);
                    GameManager.currency -= currentUnit.cost;
                }

            }
        }
        
    }

    public void setUnit1()
    {
        Prefab = u1;
        currentUnit = Unit1;
    }

    public void setUnit2()
    {
        Prefab = u2;
        currentUnit = Unit2;
    }

    public void setUnit3()
    {
        Prefab = u3;
        currentUnit = Unit3;
    }

}