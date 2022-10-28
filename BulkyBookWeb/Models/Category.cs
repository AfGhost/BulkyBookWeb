using System.ComponentModel.DataAnnotations;

namespace BulkyBookWeb.Models
{
    public class Category
    {
        [Key]                                                           /*Legger inn "using System.ComponentModel.DataAnnotations" for å gjøre Id til PK*/
        public int Id { get; set; }
        [Required]                                                      /*Får "Name" attribude til å bli NOT NULL*/
        public string Name { get; set; }
        public int DisplayOrder { get; set; }
        public DateTime CreatedDateTime { get; set; } = DateTime.Now;   /* = D.Time.Now, Setter nåtids dato/kl.slett.*/
    }
}
