using SOS.Data;


public class Mod{

    public Course course;

    public int seats;

    public EnrichedDate date;

    public Mod(Course newCourse, int newSeats, EnrichedDate newDate)
    {

        this.course = newCourse;
        this.seats = newSeats;
        this.date = newDate;

    }

}