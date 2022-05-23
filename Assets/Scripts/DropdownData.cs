using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Dropdown Data", menuName = "Dropdown/Data")]
public class DropdownData : ScriptableObject
{
    public List<string> options = new List<string>();
}