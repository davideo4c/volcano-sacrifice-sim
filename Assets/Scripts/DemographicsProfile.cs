using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Demographics Profile", menuName ="Scriptable Objects/Demographics")]
public class DemographicsProfile : ScriptableObject
{
    public AnimationCurve ageRange;

    public string[] birthplaces;
}
