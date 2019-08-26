
using UnityEngine;
using System.Collections;
using UnityEditor;


[CreateAssetMenu(fileName = "New Unit", menuName = "Unit")]
public class ScriptableUnits : ScriptableObject
{
    public string unitName;
    public string unitType;
    public int unitCost;            
    public Sprite unitImage;          
}