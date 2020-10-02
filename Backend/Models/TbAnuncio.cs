using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Backend.Models
{
    [Table("tb_anuncio")]
    public partial class TbAnuncio
    {
        public TbAnuncio()
        {
            TbFavoritos = new HashSet<TbFavoritos>();
            TbImagem = new HashSet<TbImagem>();
        }

        [Key]
        [Column("id_anuncio")]
        public int IdAnuncio { get; set; }
        [Column("ds_titulo", TypeName = "varchar(255)")]
        public string DsTitulo { get; set; }
        [Column("ds_descricao", TypeName = "varchar(255)")]
        public string DsDescricao { get; set; }
        [Column("tp_produto", TypeName = "varchar(255)")]
        public string TpProduto { get; set; }
        [Column("ds_condicao", TypeName = "varchar(255)")]
        public string DsCondicao { get; set; }
        [Column("ds_genero", TypeName = "varchar(60)")]
        public string DsGenero { get; set; }
        [Column("nm_marca", TypeName = "varchar(255)")]
        public string NmMarca { get; set; }
        [Column("ds_tamanho", TypeName = "varchar(50)")]
        public string DsTamanho { get; set; }
        [Column("vl_preco", TypeName = "decimal(15,2)")]
        public decimal? VlPreco { get; set; }
        [Column("ds_cep", TypeName = "varchar(50)")]
        public string DsCep { get; set; }
        [Column("bt_vendido")]
        public bool? BtVendido { get; set; }
        [Column("ds_situacao", TypeName = "varchar(255)")]
        public string DsSituacao { get; set; }
        [Column("dt_publicacao", TypeName = "datetime")]
        public DateTime? DtPublicacao { get; set; }
        [Column("id_usuario")]
        public int? IdUsuario { get; set; }

        [ForeignKey(nameof(IdUsuario))]
        [InverseProperty(nameof(TbUsuario.TbAnuncio))]
        public virtual TbUsuario IdUsuarioNavigation { get; set; }
        [InverseProperty("IdAnuncioNavigation")]
        public virtual ICollection<TbFavoritos> TbFavoritos { get; set; }
        [InverseProperty("IdAnuncioNavigation")]
        public virtual ICollection<TbImagem> TbImagem { get; set; }
    }
}
