using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Backend.Models
{
    [Table("tb_imagem")]
    public partial class TbImagem
    {
        [Key]
        [Column("id_imagem")]
        public int IdImagem { get; set; }
        [Column("img_anuncio", TypeName = "varchar(255)")]
        public string ImgAnuncio { get; set; }
        [Column("id_anuncio")]
        public int? IdAnuncio { get; set; }

        [ForeignKey(nameof(IdAnuncio))]
        [InverseProperty(nameof(TbAnuncio.TbImagem))]
        public virtual TbAnuncio IdAnuncioNavigation { get; set; }
    }
}
