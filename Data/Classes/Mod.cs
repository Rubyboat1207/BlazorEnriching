using SOS.Data;


public class Mod{

    public Course course;

    public int seats;

    public EnrichedDate date;
    public bool availiable;

    public Mod(Course newCourse, int newSeats, EnrichedDate newDate, bool availiable)
    {

        this.course = newCourse;
        this.seats = newSeats;
        this.date = newDate;
        this.availiable = availiable;
    }

}