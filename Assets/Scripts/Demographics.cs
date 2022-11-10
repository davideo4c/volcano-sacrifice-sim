using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Demographics
{
    // --------------------------- VARIABLES -------------------------------- //
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

    public bool isCriminal;
    public string crime;

    public Texture2D headshot;
    public DemographicsProfile demographicsProfile;

    // ----------------------------- HELPER STRUCTS --------------------------- //

    public void OnAwake()
    {
    }

    public void GenerateDemographics()
    {
        GetBirthplace();
        GetSex();
        GetPeerage();
        GetName();
        GetAge();
        GetEducation(age);
        GetOccupation(education);
        GetMarriage(age);
        GetOrphaned(age);
        GetCriminal(age);
        GetHeadshot(age, citizenSex, birthplace);
    }

    public void GetBirthplace()
    {
        // NEEDS TO BE WEIGHTED
        birthplace = demographicsProfile.birthplaces[Random.Range(0, demographicsProfile.birthplaces.Length)];
    }

    public void GetSex()
    {
        float randSample = Random.value * 100;
        if (randSample < 5)
        {
            citizenSex = Sex.NB;
        } else { citizenSex = (Sex)Random.Range(0, 2); }
    }

    public void GetPeerage()
    {
        float randSample = Random.value;
        // Chance of not being in the peerage
        if (randSample < 0.95f)
        {
            peerage = Peerage.None;
        } else
        {
            peerage = (Peerage)(1 + Random.Range(0, 3));
        }
    }

    public void GetName()
    {
        int randName = Random.Range(0, demographicsProfile.surnames.Length);
        surname = demographicsProfile.surnames[randName];
    }

    public void GetAge()
    {
        // Return Age from Sample of Demographics Profile Animation Curve provided
        float randSample = Random.value;
        randSample = demographicsProfile.ageRange.Evaluate(randSample);
        age = (int)Mathf.RoundToInt(randSample);
    }

    public void GetEducation(int age)
    {
        // Based on buckets of age have chance to be educated
        float randSample = Random.value;
        if (age < 8)
        {
            education = Education.None;
        }
        else if (age < 14 && randSample < 0.8f)
        {
            education = (Education)Random.Range(0, 2);
        }
        else if (age < 18 && randSample < 0.6f)
        {
            education = (Education)Random.Range(0, 3);
        }
        else if (age < 24 && randSample < 0.6f)
        {
            education = (Education)Random.Range(0, 3);
        }
        else if (randSample < 0.3f)
        {
            education = (Education)Random.Range(2, 5);
        }
        else { education = Education.None; }
    }

    public void GetOccupation(Education education)
    {
        if (education == Education.None | education == Education.Primary)
        {
            int occupationsLength = demographicsProfile.lowoccupations.Length;
            occupation = demographicsProfile.lowoccupations[Random.Range(0, occupationsLength)];
        } else
        {
            int occupationsLength = demographicsProfile.highoccupations.Length;
            occupation = demographicsProfile.highoccupations[Random.Range(0, occupationsLength)];
        }
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

    public void GetCriminal(int age)
    {
        float randSample = Random.value;
        if (randSample < 0.15f)
        {
            isCriminal = true;
            crime = demographicsProfile.crimes[Random.Range(0, demographicsProfile.crimes.Length)];
            occupation = "None";
        } else
        {
            isCriminal = false;
            crime = null;
        }
    }

    public void GetHeadshot(int age, Sex citizenSex, string birthplace)
    {
        // pseudocode to return texture2d headshot
    }

}