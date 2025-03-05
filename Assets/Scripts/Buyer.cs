using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Buyer : MonoBehaviour
{
    [SerializeField] private LayerMask _mask;
    [SerializeField] private Image _cursor;
    void FixedUpdate()
    {
        Debug.DrawRay(Camera.main.transform.position, Camera.main.transform.forward * 1000f, Color.red);
        if (Physics.Raycast(Camera.main.transform.position, Camera.main.transform.forward, out RaycastHit hit, 1000, _mask))
        {
            if (hit.transform.CompareTag("Product"))
            {
                _cursor.color = Color.red;
                Debug.Log(hit.transform.GetComponent<Product>().GetData().name);
            }
        }
        else
        {
            _cursor.color = Color.white;
        }
    }
}
