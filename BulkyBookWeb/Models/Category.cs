using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace BulkyBookWeb.Models
{
    public class Category
    {
        [Key]                                                           /*Legger inn "using System.ComponentModel.DataAnnotations" for å gjøre Id til PK*/
        public int Id { get; set; }
        [Required]                                                      /*Får "Name" attribude og de under til å bli NOT NULL, altså Required field.*/
        public string Name { get; set; }
        [DisplayName("Display Order")]                                  /*Denne tvinger DisplayOrder til å få en mellom Display og Order.*/
        [Range(1, 100, ErrorMessage = "Display Order must be between 1 and 100 only!!")]    /*Denne viser en feilmelding i DisplayName hvis antallet er over 100 stk.*/
        public int DisplayOrder { get; set; }
        /*[DisplayName("Date Created")]*/                                   /*Viser navnet CreatedDateTime som Date Created*/  
        public DateTime CreatedDateTime { get; set; } = DateTime.Now;   /* = D.Time.Now, Setter nåtids dato/kl.slett.*/
    }
}
