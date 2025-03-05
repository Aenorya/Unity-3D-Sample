using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CartManager : MonoBehaviour
{
    public static CartManager Instance;
    
    private List<ProductData> _products = new List<ProductData>();
    [SerializeField] private GameObject _cartItemPrefab;
    [SerializeField] private GameObject _cartUiContainer;
    [SerializeField] private TextMeshProUGUI _cartLabel;

    private float _totalPrice = 0;

    private void Awake()
    {
        if (!Instance)
        {
            Instance = this;
        }
    }

    public void AddToCart(ProductData product)
    {
        _products.Add(product);
        _totalPrice += product.price;
        GameObject go = Instantiate(_cartItemPrefab, _cartUiContainer.transform);
        go.GetComponentInChildren<Image>().sprite = product.icon;
        go.GetComponentInChildren<TextMeshProUGUI>().text = product.name;
        _cartLabel.text = $"Total : {_totalPrice}$";
    }
    
}
