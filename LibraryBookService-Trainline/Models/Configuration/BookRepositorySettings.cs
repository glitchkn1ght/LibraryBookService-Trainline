namespace LibraryBookService_Trainline.Models.Configuration
{
    public class BookRepositorySettings
    {
        public string InsertProc { get; set; } = string.Empty;
        
        public string UpdateProc { get; set; } = string.Empty;
        
        public string GetProc { get; set; } = string.Empty;

        public string GetAllProc { get; set; } = string.Empty;

        public string DeleteProc { get; set; } = string.Empty;
    }
}
