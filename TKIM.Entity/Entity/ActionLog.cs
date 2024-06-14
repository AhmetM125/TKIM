namespace TKIM.Entity.Entity;

public class ActionLog
{
    public Guid Id { get; set; }
    public string Action { get; set; }
    public string Controller { get; set; }
    public DateTime? ActionDate { get; set; }
    public Guid UserId { get; set; }
    public string IpAddress { get; set; }
    public string Browser { get; set; }

}
