namespace WorkIn.Domain.Common
{
    public class Response
    {
        public Response()
        {
        }
        public Response(object data, string message = null, bool succees = true, int code = 200)
        {
            Success = succees;
            Message = message;
            Data = data;
            Code = code;
        }
        public Response(string message, int code = 200)
        {
            Success = false;
            Message = message;
            Code = code == 0 ? 200 : code;
        }


        public int Code { get; set; }
        public bool Success { get; set; }
        public string Message { get; set; }
        public object Errors { get; set; }
        public object Data { get; set; }
        public string BaseUrl { get; set; }
    }

    public enum code
    {
        BadRequest = 400,
        UnAuthorized = 401,
        PermissionFailed = 403,
        NotFound = 404,
        Success = 200,
        PendingUser = 425,
        UpgradeRequired = 426,
        UnPaidOrder = 9954,
        SubscribtionExpired = 9955,
        SubscribtionUserLimitExceeded = 9956,
        SignOut = 205
    }
}
