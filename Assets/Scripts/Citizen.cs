using System;
using System.Collections.Generic;
using Unity;
using UnityEngine;
using UnityEngine.InputSystem;

public class Citizen : MonoBehaviour
{
    public Demographics demographics = new Demographics();
    public DemographicsProfile demographicsProfile;
    public bool isSacrificed;
    public InputAction mouseDown;

    public void Awake()
    {
        demographics.demographicsProfile = demographicsProfile;
    }

    public void Start()
    {
        // Establish init conditions, not sacrificed
        isSacrificed = false;
        demographics.GenerateDemographics();
        LogDemographics();
    }

    public void Update()
    {
        if (Mouse.current.leftButton.isPressed)
        {
            demographics.GenerateDemographics();
            LogDemographics();
        }
    }
    public void LogDemographics()
    {
        string demographicsLog;
        if (demographics.isCriminal)
        {
            demographicsLog = demographics.surname + " has a generated age is " + demographics.age + " they were born in " + demographics.birthplace +
             ". Their sex is " + demographics.citizenSex + " with a peerage of " + demographics.peerage + ". " +
             "it is also " + demographics.isOrphaned + " that they are orphaned and " + demographics.isMarried +
             " that they are married." + "They have " + demographics.education +
             " and they are a criminal, convicted of " + demographics.crime;
        }
        else
        {
            demographicsLog = demographics.surname + " has a generated age is " + demographics.age + " they were born in " + demographics.birthplace +
            ". Their sex is " + demographics.citizenSex + " with a peerage of " + demographics.peerage + ". " +
            "it is also " + demographics.isOrphaned + " that they are orphaned and " + demographics.isMarried +
            " that they are married." + "They have " + demographics.education +
            " education and are employed as a " + demographics.occupation;
        }
        Debug.Log(demographicsLog);
    }

}