using SOS.Data;

public class ModSlot
{

    public static List<ModSlot> modSlots = new List<ModSlot>();

    public int id;

    public string name;

    public ModSlot(int newId, string newName)
    {
        
        this.id = newId;
        this.name = newName;

    }

}

