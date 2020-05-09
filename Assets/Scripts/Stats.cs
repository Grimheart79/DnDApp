

using System.Collections.Generic;

public class Stats
{
    
   

    //forestGnome, skyGnome, , lightfootHalfling, stoorHalfling, }
	
}

//Inherits Stats, Appearance, Personality 
public class Race
{
    public enum race { DWARF, ELF, GNOME, HALFLING, HUMAN, DRAGONBORN, TIEFLING, HALFORC, HALFELF };
    public race ChosenRace = race.HUMAN;

    public enum dwarfSubrace { gemDwarf, ironDwarf };
    public enum elfSubrace { wildElf, sunElf, moonElf };
    public enum gnomeSubrace { gemDwarf, ironDwarf };
    public enum halflingSubrace { wildElf, sunElf, moonElf };

    private string name;
    private bool isMale = true;
    private int age;
    private int height;
    private int weight;

    private List<string> personalityTraits = new List<string>();
}

//Inherits 
public class PCClass
{

}

public class NPC
{
    private List<string> appearance = new List<string>();
    //appearance.
}