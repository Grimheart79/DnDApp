using UnityEngine;
using UnityEngine.UI;

public class Dice : MonoBehaviour
{
    public Text resultText;
    private int rollResult;

    //d4
    public Text numberOfRolls;
    private int numberOfDieRolled = 1;

    public Text dieModInput;
    private int dieMod = 0;

    public Text totalModInput;
    private int totalMod = 0;

    public void UpdateNumberOfDieRolled()
    {
        numberOfDieRolled = int.Parse(numberOfRolls.text);
        //if (numberOfDieRolled == 0)
        //{
        //    numberOfDieRolled = 1;
        //}
        print(numberOfDieRolled);
    }

    public void UpdateDieMod()
    {
        dieMod = int.Parse(dieModInput.text);
        print(dieMod);
    }

    public void UpdateTotalMod()
    {
        totalMod = int.Parse(totalModInput.text);
        print(totalMod);
    }

    public void RollDice(int dieMax)
    {
        int result = 0;
        print("Number of die rolled = " + numberOfDieRolled);
        for (int i = 1; i <= numberOfDieRolled; i++)
        {
            print("i = " + i);
            result += RollSingleDie(dieMax);
            print("Base roll = " + result);
            result = result + dieMod;
            print("Base roll + mod = " + result);

        }

        result = result + totalMod;

        resultText.text = result.ToString();
    }

    public int RollSingleDie(int dieType)
    {
        int result = (Random.Range(1, dieType+1));
        return result;
    }

    public int RollMultipleDice(int dieType, int numberOfRolls)
    {
        int result = 0;
        for (int i = 0; i < numberOfRolls; i++)
        {
            result += RollSingleDie(dieType);
        }
        return result;
    }

    public int ApplyModifier(int total, int modifier)
    {
        int result = total + modifier;
        return result;
    }
}
