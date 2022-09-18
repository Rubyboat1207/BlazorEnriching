using SOS.Data;

public class Course
{

    public string room;

    public string description;

    public string name;

    public string facilitator_name;

    public ModSlot period_id;

    public int id;

    public Course()
    {

        this.room = "";
        this.description = "";
        this.name = "";
        this.facilitator_name = "";
        this.period_id = null;
        this.id = -1;

    }

    public string turnToString()
    {

        if(this.facilitator_name != "")
        {
            return this.name + " in " + this.room + " for " + this.period_id.ToString() + " by " + this.facilitator_name;
        }
        if(this.room != "None")
        {
            return this.name + " in " + this.room + " for " + this.period_id.ToString();
        }

        return this.name + " for " + this.period_id.ToString();

    }

}

