using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

[CreateAssetMenu(fileName = "Demographics Profile", menuName ="Scriptable Objects/Demographics")]
public class DemographicsProfile : ScriptableObject
{
    // Variables
    public AnimationCurve ageRange;

    public string[] birthplaces;

    public string[] surnames;
    public TextAsset SurnamesText;

    public string[] lowoccupations;
    public TextAsset LowOccupationsText;

    public string[] highoccupations;
    private TextAsset HighOccupationsText;

    public string[] crimes;
    public TextAsset CrimesText;

/// <summary>
/// Splits a TextAsset by line into a array of strings.
/// </summary>
/// <param name="textAsset"></param>
/// <returns></returns>
    public string[] SplitTextAsset(TextAsset textAsset)
    {
        string[] splitText;
        try
        {
            splitText = textAsset.ToString().Split('\n');
            Debug.Log("Loaded all " + splitText.Length + " lines of TextAsset " + textAsset.name + " successfully.");
        } catch
        {
            Debug.Log("Something wrong occured loading a textAsset.");
            splitText = null;
        }
        return splitText;
    }
/// <summary>
/// Validates Scriptable Object and moves data to string arrays.
/// </summary>
    public void OnValidate()
    {
        surnames = SplitTextAsset(SurnamesText);
        lowoccupations = SplitTextAsset(LowOccupationsText);
        highoccupations = SplitTextAsset(HighOccupationsText);
        crimes = SplitTextAsset(CrimesText);
    }
}
