namespace FondoBTG.Utilities
{
    public enum ResponseMessage
    {
        OK,
        CREATED,
        CONFLICT,
        DATA_NOT_FOUND,
        INTERNAL_SERVER_ERROR,


    }

    public enum ResponseCode
    {
        OK = 200,
        CREATED = 201,
        CONFLICT = 409,
        DATA_NOT_FOUND = 404,
        INTERNAL_SERVER_ERROR = 500


    }
}
