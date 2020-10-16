using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Backend.Models
{
    [Table("tb_pergunta_resposta")]
    public partial class TbPerguntaResposta
    {
        [Key]
        [Column("id_pergunta_respota")]
        public int IdPerguntaRespota { get; set; }
        [Column("ds_pergunta", TypeName = "varchar(255)")]
        public string DsPergunta { get; set; }
        [Column("dt_pergunta", TypeName = "datetime")]
        public DateTime? DtPergunta { get; set; }
        [Column("bt_respondida")]
        public bool? BtRespondida { get; set; }
        [Column("ds_resposta", TypeName = "varchar(255)")]
        public string DsResposta { get; set; }
        [Column("id_usuario")]
        public int? IdUsuario { get; set; }
        [Column("id_anuncio")]
        public int? IdAnuncio { get; set; }

        [ForeignKey(nameof(IdAnuncio))]
        [InverseProperty(nameof(TbAnuncio.TbPerguntaResposta))]
        public virtual TbAnuncio IdAnuncioNavigation { get; set; }
        [ForeignKey(nameof(IdUsuario))]
        [InverseProperty(nameof(TbUsuario.TbPerguntaResposta))]
        public virtual TbUsuario IdUsuarioNavigation { get; set; }
    }
}
