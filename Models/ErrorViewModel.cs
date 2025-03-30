namespace PinedaStore.Models
{
    public class ErrorViewModel
    {
        internal string message;

        public string? RequestId { get; set; }

        public bool ShowRequestId => !string.IsNullOrEmpty(RequestId);
    }
}
