using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Backend.Models
{
    [Table("tb_favorito")]
    public partial class TbFavorito
    {
        [Key]
        [Column("id_favorito")]
        public int IdFavorito { get; set; }
        [Column("bt_favorito")]
        public bool? BtFavorito { get; set; }
        [Column("id_usuario")]
        public int? IdUsuario { get; set; }
        [Column("id_anuncio")]
        public int? IdAnuncio { get; set; }

        [ForeignKey(nameof(IdAnuncio))]
        [InverseProperty(nameof(TbAnuncio.TbFavorito))]
        public virtual TbAnuncio IdAnuncioNavigation { get; set; }
        [ForeignKey(nameof(IdUsuario))]
        [InverseProperty(nameof(TbUsuario.TbFavorito))]
        public virtual TbUsuario IdUsuarioNavigation { get; set; }
    }
}
