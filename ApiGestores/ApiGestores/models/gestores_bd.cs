using System.ComponentModel.DataAnnotations;

namespace ApiGestores.models
{
    public class gestores_bd
    {
        [Key]
        public int id { get; set; }
        public string nombre { get; set; }
        public int lanzamiento { get; set; }
        public string desarrolador { get; set; }

    }
}
