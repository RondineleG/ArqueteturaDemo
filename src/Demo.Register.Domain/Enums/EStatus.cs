using System.ComponentModel;

namespace Demo.Register.Domain.Enums
{
    public enum EStatus
    {
        [Description("Active")]
        Active = 0,

        [Description("Inactive")]
        Inactive = 1
    }
}