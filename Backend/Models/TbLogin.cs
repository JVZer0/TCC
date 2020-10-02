using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Backend.Models
{
    [Table("tb_login")]
    public partial class TbLogin
    {
        public TbLogin()
        {
            TbUsuario = new HashSet<TbUsuario>();
        }

        [Key]
        [Column("id_login")]
        public int IdLogin { get; set; }
        [Required]
        [Column("ds_username", TypeName = "varchar(255)")]
        public string DsUsername { get; set; }
        [Required]
        [Column("ds_senha", TypeName = "varchar(255)")]
        public string DsSenha { get; set; }

        [InverseProperty("IdLoginNavigation")]
        public virtual ICollection<TbUsuario> TbUsuario { get; set; }
    }
}
