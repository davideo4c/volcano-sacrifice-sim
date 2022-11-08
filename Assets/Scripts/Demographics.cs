using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Demographics
{
    public string citizenName;
    public string surname;
    public string birthplace;
    public enum Peerage { None, Esquire, Baron, Duke };
    public Peerage peerage;
    public int age;
    public enum Sex { Male, Female, NB }
    public Sex citizenSex;
    public bool isMarried;
    public bool isOrphaned;
    public enum FamilyRole { Father, Mother, Son, Daughter, Husband, Wife };
    public FamilyRole familyRole;
    public enum Education { None, Primary, Secondary, Graduate, Doctorate };
    public Education education;
    public string occupation;
    public Texture2D headshot;
    public DemographicsProfile demographicsProfile;

    public void OnAwake()
    {
    }

    public void GenerateDemographics()
    {
        GetBirthplace();
        GetSex();
        GetPeerage();
        GetName(citizenSex, birthplace);
        GetAge();
        GetEducation(age, peerage);
        GetOccupation(birthplace, education);
        GetMarriage(age);
        GetOrphaned(age);
        GetHeadshot(age, citizenSex, birthplace, occupation);
    }
    public void GetBirthplace()
    {
        // NEEDS TO BE WEIGHTED
        birthplace = demographicsProfile.birthplaces[Random.Range(0,demographicsProfile.birthplaces.Length)];
    }

    public void GetSex()
    {
        // STILL NEEDS TO BE WEIGHTED. OR DOES IT? I DON'T GIVE A FUCK
        citizenSex = (Sex)Mathf.Round(Random.Range(0, 2));
    }

    public void GetPeerage()
    {
        // Need a convenient way to iterate over a set of enums or array of things.
    }

    public void GetName(Sex citizenSex, string nationality)
    {
    }

    public void GetAge()
    {
        // pseudocode to return age
        float randSample = Random.value;
        randSample = demographicsProfile.ageRange.Evaluate(randSample);
        age = (int)Mathf.RoundToInt(randSample);
    }

    public void GetEducation(int age, Peerage peerage)
    {
        // pseudocode to return education
    }

    public void GetOccupation(string birthplace, Education education)
    {
        // pseudocode to return occupation
    }

    public void GetMarriage(int age)
    {
        if (age < 16)
        {
            isMarried = false;
        } else if (16 < age || age > 55)
        {
            if (Random.value * age > (55 - 16))
            {
                isMarried = true;
            }
            else isMarried = false;
        } else
        {
            if (Random.value * age < 40)
            {
                isMarried = true;
            }
            else isMarried = false;
        }
    }

    public void GetOrphaned(int age)
    {
        // pseudocode to return orphaned
        float randSample = Random.value;
        if (randSample * age > (.7f * 50))
        {
            isOrphaned = true;
        }
        else isOrphaned = false;
    }

    public void GetHeadshot(int age, Sex citizenSex, string nationality, string occupation)
    {
        // pseudocode to return texture2d headshot
    }

}
