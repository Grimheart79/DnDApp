using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Utilities {

	public static float GetAbilityMod(int abilityScore)
    {
        float mod = Mathf.Floor(((float)abilityScore - 10)/2);
        return mod;
    }
}
