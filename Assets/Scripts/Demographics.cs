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
    public string[] criminalHistory;

    public Texture2D headshot;
    public DemographicsProfile demographicsProfile;

    // ----------------------------- HELPER STRUCTS --------------------------- //

    //helper structure
    public struct RandomSelection
    {
        private int minValue;
        private int maxValue;
        public float probability;

        public RandomSelection(int minValue, int maxValue, float probability)
        {
            this.minValue = minValue;
            this.maxValue = maxValue;
            this.probability = probability;
        }

        public int GetValue() { return Random.Range(minValue, maxValue + 1); }
    }

    public int GetRandomValue(params RandomSelection[] selections)
    {
        float rand = Random.value;
        float currentProb = 0;
        foreach (var selection in selections)
        {
            currentProb += selection.probability;
            if (rand <= currentProb)
                return selection.GetValue();
        }

        //will happen if the input's probabilities sums to less than 1
        //throw error here if that's appropriate
        return -1;
    }

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
        citizenSex = (Sex)Mathf.Round(Random.Range(0, 3));
    }

    public void GetPeerage()
    {
        // 95% chance of not being in the peerage
        float randSample = Random.value;
        if (randSample < .98)
        {
            peerage = Peerage.None;
        } else
        {
            peerage = (Peerage)(1+Random.Range(0, 3));
        }
    }

    public void GetName()
    {
        int randName = Random.Range(0, demographicsProfile._surnames.Length);
        surname = demographicsProfile._surnames[randName];
    }

    public void GetAge()
    {
        // Return Age from Sample of Demographics Profile Animation Curve provided
        float randSample = Random.value;
        randSample = demographicsProfile.ageRange.Evaluate(randSample);
        age = (int)Mathf.RoundToInt(randSample);
    }

    public void GetEducation(int age, Peerage peerage)
    {
        // Scale random chance to be educated by the peerage and age of the citizen.
        // ----------------------------- NEEDS TO BE FIXED, CURRENTLY A LOT OF 18 YEAR OLD DOCTORATES
        int random = GetRandomValue(
            new RandomSelection(0, 1, .5f * (4-(int)peerage)),
            new RandomSelection(1, 4, .5f * (age-12) * ((int)peerage)));
        education = (Education)random;
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
