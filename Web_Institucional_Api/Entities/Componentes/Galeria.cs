namespace Web_Institucional_Api.Entities.Componentes
{
    public class Galeria
    {
        public static string getCards(int idPagina, int idSeccion)
        {
            string html = "";
            Entities.Secciones seccion = new Entities.Secciones();
            Entities.Cards cards = new Entities.Cards();

            seccion = Secciones.getByPk(idSeccion);

            html = string.Format(
                    @"<section style=""padding-top:80px; padding-bottom:40px; background-color:{0}""
                        id=""seccion_p{1}s_{2}"" class=""gallery-page"">
                        <div class=""container"">
                            <div class=""row"">
                                <div class=""col"">
                                    <h2 style=""position: relative; color: var(--roofsie-gray);
                                        font-weight: 800; line-height: 40px; margin-bottom: 10px; "">
                                            {3}
                                    </h2>
                                    <p style=""font-size:18px; color: var(--roofsie-gray);
                                        line-height:18px; margin-bottom:10px; "">
                                        {4}
                                    </p>
                                </div>
                            </div>
                            <div class=""row"" style=""margin-top:25px;"">",
                    seccion.background_color,
                    idPagina, idSeccion, seccion.titulo, seccion.subtitulo);
            foreach (var item in seccion.lstContenido)
            {
                html += string.Format(
                    @"
                        <div class=""col-xl-4 col-lg-6 col-md-6 wow fadeInUp animated"" 
                            data-wow-delay=""100ms"" style=""visibility: visible; animation-delay: 100ms; 
                            animation-name: fadeInUp;"">
                            <div class=""gallery-page__single"">
                                <div class=""gallery-page__img"">
                                    <img src=""img/Pagina_{0}/{1}"" alt="""">
                                    <div class=""gallery-page__icon"">
                                        <a class=""img-popup"" href=""img/Pagina_{0}/{1}"">
                                            <span class=""fas fa-plus""></span>
                                        </a>
                                    </div>
                                </div>
                            </div>
                        </div>
                    ", idPagina, item.imagen);
            }

            html += @"</div>
                </div>
            </section>";
            return html;
        }
    }
}
