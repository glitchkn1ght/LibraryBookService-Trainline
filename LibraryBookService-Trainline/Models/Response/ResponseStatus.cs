namespace LibraryBookService_Trainline.Models.Response
{
    public class ResponseStatus
    {
        public int? Code { get; set; } = null;

        public string Message { get; set; } = string.Empty;

        public IDictionary<string, string[]>? ValidationErrorDetails { get; set; }
    }
}
