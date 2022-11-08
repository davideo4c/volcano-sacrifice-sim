using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

[CreateAssetMenu(fileName = "Demographics Profile", menuName ="Scriptable Objects/Demographics")]
public class DemographicsProfile : ScriptableObject
{
    public AnimationCurve ageRange;

    public string[] birthplaces;

    public string[] MaleNames;
    public string[] FemaleNames;

    //public void On
}
