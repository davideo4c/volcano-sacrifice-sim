using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Headshots", menuName = "Scriptable Objects/Headshots")]
public class HeadshotTextures : ScriptableObject
{
    public Material headshotMaterial;
    public Texture2D[] ProfileMaleAdult;
    public Texture2D[] ProfileFemaleAdult;
    public Texture2D[] MaleHair;
    public Texture2D[] FemaleHair;
}
