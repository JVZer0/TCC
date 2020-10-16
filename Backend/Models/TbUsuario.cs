using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Backend.Models
{
    [Table("tb_usuario")]
    public partial class TbUsuario
    {
        public TbUsuario()
        {
            TbAnuncio = new HashSet<TbAnuncio>();
            TbFavorito = new HashSet<TbFavorito>();
            TbPerguntaResposta = new HashSet<TbPerguntaResposta>();
        }

        [Key]
        [Column("id_usuario")]
        public int IdUsuario { get; set; }
        [Column("nm_usuario", TypeName = "varchar(255)")]
        public string NmUsuario { get; set; }
        [Column("dt_nascimento", TypeName = "datetime")]
        public DateTime? DtNascimento { get; set; }
        [Column("ds_sexo", TypeName = "varchar(50)")]
        public string DsSexo { get; set; }
        [Column("ds_cpf", TypeName = "varchar(50)")]
        public string DsCpf { get; set; }
        [Column("ds_rg", TypeName = "varchar(50)")]
        public string DsRg { get; set; }
        [Column("ds_email", TypeName = "varchar(255)")]
        public string DsEmail { get; set; }
        [Column("ds_celular", TypeName = "varchar(50)")]
        public string DsCelular { get; set; }
        [Column("ds_estado", TypeName = "varchar(50)")]
        public string DsEstado { get; set; }
        [Column("ds_cidade", TypeName = "varchar(130)")]
        public string DsCidade { get; set; }
        [Column("ds_cep", TypeName = "varchar(50)")]
        public string DsCep { get; set; }
        [Column("ds_endereco", TypeName = "varchar(255)")]
        public string DsEndereco { get; set; }
        [Column("ds_bairro", TypeName = "varchar(255)")]
        public string DsBairro { get; set; }
        [Column("ds_n_endereco", TypeName = "varchar(50)")]
        public string DsNEndereco { get; set; }
        [Column("ds_complemento_endereco", TypeName = "varchar(255)")]
        public string DsComplementoEndereco { get; set; }
        [Column("bt_concordo_termos")]
        public bool? BtConcordoTermos { get; set; }
        [Column("id_login")]
        public int? IdLogin { get; set; }

        [ForeignKey(nameof(IdLogin))]
        [InverseProperty(nameof(TbLogin.TbUsuario))]
        public virtual TbLogin IdLoginNavigation { get; set; }
        [InverseProperty("IdUsuarioNavigation")]
        public virtual ICollection<TbAnuncio> TbAnuncio { get; set; }
        [InverseProperty("IdUsuarioNavigation")]
        public virtual ICollection<TbFavorito> TbFavorito { get; set; }
        [InverseProperty("IdUsuarioNavigation")]
        public virtual ICollection<TbPerguntaResposta> TbPerguntaResposta { get; set; }
    }
}
