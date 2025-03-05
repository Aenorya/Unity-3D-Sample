using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName ="Product Data")]
public class ProductData : ScriptableObject
{
    public string label;
    public string description;
    public Sprite icon;
    public float price;
}
