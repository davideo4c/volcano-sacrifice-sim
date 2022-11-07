using System;
using System.Collections.Generic;
using Unity;
using UnityEngine;

public class Citizen : MonoBehaviour
{
    public Demographics demographics = new Demographics();
    public DemographicsProfile demographicsProfile;
    public bool isSacrificed;

    public void Awake()
    {
        demographics.demographicsProfile = demographicsProfile;
    }

    public void Start()
    {
        // Establish init conditions, not sacrificed
        isSacrificed = false;
        demographics.GenerateDemographics();
        Debug.Log("The generated age is " + demographics.age + " they were born in " + demographics.birthplace +
            ". Their sex is " + demographics.citizenSex + "and a peerage of " + demographics.peerage);
    }

}
