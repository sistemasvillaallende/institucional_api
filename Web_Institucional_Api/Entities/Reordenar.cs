namespace Web_Institucional_Api.Entities
{
    public class Reordenar
    {
        public int idPagina { get; set; }
        public List<int> ids { get; set; }

        Reordenar()
        { 
            idPagina = 0;
            ids = new List<int>();  
        }
    }
}
