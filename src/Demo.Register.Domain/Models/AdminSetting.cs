using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Proton.Register.Domain.Models
{
    [Table("adminsetting")]
    public class AdminSetting
    {
        [Key]
        [Column("idadminsetting")]
        public int? IdAdminSetting { get; set; }

        [Column("logo")]
        public byte[]? Logo { get; set; }


        [Column("primarycolor")]
        public string PrimaryColor { get; set; }

        [Column("secondarycolor")]
        public string SecondaryColor { get; set; }

        [Column("idcurrency")]
        public int? CurrencyIdCurrency { get; set; }

        [Column("acronymcurrency")]
        public string AcronymCurrency { get; set; }
    }
}



