using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class Buyer : MonoBehaviour
{
    [SerializeField] private LayerMask _mask;
    [SerializeField] private Image _cursor;
    [SerializeField] private GameObject _labelBackground;
    [SerializeField] private TextMeshProUGUI _label;
    [SerializeField] private float _maxDistance = 1.5f;

    private ProductData hoveredProduct;

    public void BuyAction(InputAction.CallbackContext context)
    {
        if (context.performed && hoveredProduct != null)
        {
            CartManager.Instance.AddToCart(hoveredProduct);
        }
    }

    void FixedUpdate()
    {
        Debug.DrawRay(Camera.main.transform.position, Camera.main.transform.forward * _maxDistance, Color.red);
        if (Physics.Raycast(Camera.main.transform.position, Camera.main.transform.forward, out RaycastHit hit, _maxDistance, _mask))
        {
            if (hit.transform.CompareTag("Product"))
            {
                _cursor.color = Color.red;
                hoveredProduct = hit.transform.GetComponent<Product>().GetData();
                _labelBackground.SetActive(true);
                _label.text = $"[E] Buy {hoveredProduct.name} : {hoveredProduct.price} $";
            }
        }
        else
        {
            _labelBackground.SetActive(false);
            _cursor.color = Color.white;
            hoveredProduct = null;
        }
    }
}
