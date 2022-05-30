namespace DuelingTraditions;


//interface for what the player can 'sense' at a given location
// it is assumed that CanSense will be called, and if it is true, then ReportSense will be called.
public interface ISense
{
    //the various senses should determine if... well they can be sensed.
    public bool CanSense(FountainOfObjectsGame game);
    //if the sense in question can be experienced, then report that sense to the player!
    public void ReportSense(FountainOfObjectsGame game);
}
