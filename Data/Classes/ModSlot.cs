using SOS.Data;

public class ModSlot
{

    public static List<ModSlot> slotList = new List<ModSlot>();

    public int id;

    public string name;

    public ModSlot(int newId, string newName)
    {
        
        this.id = newId;
        this.name = newName;
        slotList.Add(this);
    }

    public static ModSlot MOD1 = new ModSlot(1, "Mod 1");
    public static ModSlot MOD2 = new ModSlot(2, "Mod 2");
    public static ModSlot MOD3 = new ModSlot(3, "Mod 3");
    public static ModSlot MOD4 = new ModSlot(4, "Mod 4");
    public static ModSlot MOD5 = new ModSlot(5, "Mod 5");
    public static ModSlot MOD6 = new ModSlot(6, "Mod 6");
    public static ModSlot MOD7 = new ModSlot(7, "Mod 7");
    public static ModSlot MOD8 = new ModSlot(8, "Mod 8");
    public static ModSlot TITAN_TIME = new ModSlot(9, "Titan Time");
    public static ModSlot FLEX_MOD1 = new ModSlot(10, "Flex Mod 1");
    public static ModSlot FLEX_MOD2 = new ModSlot(11, "Flex Mod 2");
    public static ModSlot FLEX_MOD3 = new ModSlot(12, "Flex Mod 3");
    public static ModSlot FLEX_MOD4 = new ModSlot(13, "Flex Mod 4");
    public static ModSlot FLEX_MOD5 = new ModSlot(14, "Flex Mod 5");
    public static ModSlot LUNCH_1 = new ModSlot(15, "Lunch 12:30-1:00");
    public static ModSlot LUNCH_2 = new ModSlot(16, "Lunch 1:00-1:13");

    public static ModSlot getMod(int id)
    {
        for (int i = 0; i < ModSlot.slotList.Count; i++)
        {
            if (ModSlot.slotList[i].id == id)
            {
                return ModSlot.slotList[i];
            }
        }
        return null;
    }

}

