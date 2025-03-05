using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Product : MonoBehaviour
{
    [SerializeField] private ProductData _data;

    void Start()
    {
        
    }

    void Update()
    {
        
    }

    public ProductData GetData()
    {
        return _data;
    }
}
