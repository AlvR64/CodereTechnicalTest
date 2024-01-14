namespace ISF.FAF_RF.Domain.Common
{
    public class AppException : Exception
    {
        public CustomError Error { get; private set; }

        public AppException(CustomError error, string? message = null) : base($"{error.Code} - {error.Message}\n{message}")
        {
            Error = error;
        }
    }

    public class CustomError
    {
        public static CustomError UnhandledError { get => new("IDER", "Generic Error, please contact with the system admin."); }
        public static CustomError IdError { get => new("IDER", "Id of the given entity does not exist"); }
        public static CustomError SaveError { get => new("SAVE", "This show has been already saved"); }

        #region Class Structure
        public string Code { get; set; } = string.Empty;
        public string Message { get; set; } = string.Empty;

        private CustomError(string code, string message)
        {
            Code = code;
            Message = message;
        }
        #endregion
    }
}
