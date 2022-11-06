using System;
using System.Collections.Generic;

public class Citizen
{
    public string _name;

    public string surname;
    public enum FamilyRole
    {
        Father,Mother,Son,Daughter,Husband,Wife
    }

    public int age;

    public bool isMarried;

    public bool isOrphaned;
    public string birthplace;
    public string nationality;
    public enum Education
    {
        None,Primary,Secondary,Graduate,Doctorate
    }

    public string employer;

    public List<Citizen> children;
}
