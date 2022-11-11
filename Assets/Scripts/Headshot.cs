using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Headshot
{
    // Variables
    public HeadshotTextures headshotTextures;
    public Material headshotMaterial;

    public void Awake()
    {
    }

/// <summary>
/// Generate a headshot from the age and gender of the citizen, and generate a material for them.
/// </summary>
/// <param name="age"></param>
/// <param name="sex"></param>
    public Material GetHeadshot(int age, Demographics.Sex sex)
    {
        switch (sex)
        {
            case Demographics.Sex.Male:
                // Debug.Log("Headshot texture is male.");
                headshotMaterial.SetTexture("_headProfile", headshotTextures.ProfileMaleAdult[Random.Range(0, headshotTextures.ProfileMaleAdult.Length)]);
                headshotMaterial.SetTexture("_headHair", headshotTextures.MaleHair[Random.Range(0, headshotTextures.MaleHair.Length)]);
                break;
            case Demographics.Sex.Female:
                // Debug.Log("Headshot texture is female.");
                headshotMaterial.SetTexture("_headProfile", headshotTextures.ProfileFemaleAdult[Random.Range(0, headshotTextures.ProfileFemaleAdult.Length)]);
                headshotMaterial.SetTexture("_headHair", headshotTextures.FemaleHair[Random.Range(0, headshotTextures.FemaleHair.Length)]);
                break;
            case Demographics.Sex.NB:
                // Debug.Log("Headshot texture is NB.");
                if (Random.value < 0.5f)
                {
                    headshotMaterial.SetTexture("_headProfile", headshotTextures.ProfileMaleAdult[Random.Range(0, headshotTextures.ProfileMaleAdult.Length)]);
                    headshotMaterial.SetTexture("_headHair", headshotTextures.MaleHair[Random.Range(0, headshotTextures.MaleHair.Length)]);
                }
                else
                {
                    headshotMaterial.SetTexture("_headProfile", headshotTextures.ProfileFemaleAdult[Random.Range(0, headshotTextures.ProfileFemaleAdult.Length)]);
                    headshotMaterial.SetTexture("_headHair", headshotTextures.FemaleHair[Random.Range(0, headshotTextures.FemaleHair.Length)]);
                }
                break;
        }
        return headshotMaterial;
    }
}
