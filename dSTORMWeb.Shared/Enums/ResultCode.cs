using System;
using System.Runtime.Serialization;

namespace dSTORMWeb.Shared.Enums
{
    [DataContract]
    public enum ResultCode : int
    {
        [EnumMember]
        Success = 0,
        [EnumMember]
        ServerError = 1,
        [EnumMember]
        Unauthorized = 2,
        [EnumMember]
        AccessBlocked = 3,
        [EnumMember]
        NotFound = 4,
        [EnumMember]
        NotValidData = 5,
        [EnumMember]
        Expired = 6,
        [EnumMember]
        AlreadyExists = 7,
        [EnumMember]
        NotValidStatus = 8,
        [EnumMember]
        AccessRestricted = 9,
        [EnumMember]
        NoChanges = 10,
        [EnumMember]
        NeedAdditionalParams = 10
    }
}
