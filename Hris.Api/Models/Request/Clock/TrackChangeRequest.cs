namespace Hris.Api.Models.Request.Clock
{
    public class ChangeRequest
    {
        public Guid TrackChangeId { get; set; }
        public bool IsApproved { get; set; }
    }
}
