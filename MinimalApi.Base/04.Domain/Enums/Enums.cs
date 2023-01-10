using System.ComponentModel;

namespace MinimalApi.Base.Domain.Enums
{
    public enum ResultStatus
    {
        [field: Description("OutOfUse")]
        OutOfUse,

        [field: Description("Success")]
        Success,

        [field: Description("Error")]
        Error,

        [field: Description("NoRecords")]
        NoRecords,

        [field: Description("ExpiredCode")]
        ExpiredCode,

    }
}
