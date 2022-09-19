using SOS.Data;


public class Mod{

    public Course course;

    public int seats;
    public int appointments;

    public EnrichedDate date;
    public bool availiable;

    public Mod(Course newCourse, int newSeats, int appointments, EnrichedDate newDate, bool availiable)
    {
        this.course = newCourse;
        this.seats = newSeats;
        this.appointments = appointments;
        this.date = newDate;
        this.availiable = availiable;
    }

}