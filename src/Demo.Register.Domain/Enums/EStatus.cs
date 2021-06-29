using System.ComponentModel;

namespace Proton.Register.Domain.Enums
{
    public enum EStatus
    {
        [Description("Active")]
        Active = 0,

        [Description("Inactive")]
        Inactive = 1
    }
}