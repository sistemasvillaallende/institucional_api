namespace Web_Institucional_Api.Entities.Componentes
{
    public class ExpansionPanels
    {
        public static string getCards(int idPagina, int idSeccion)
        {
            string html = "";
            Entities.Secciones seccion = new Entities.Secciones();
            Entities.Cards cards = new Entities.Cards();

            seccion = Secciones.getByPk(idSeccion);

            html = string.Format(
                    @"<section style=""padding-top:80px; padding-bottom:40px; background-color:{0}""
                        id=""seccion_p{1}s_{2}"">
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
                            <div class=""row"" style=""margin-top:25px;"">
                                <div class=""col col-12"">
                                    <div class=""v-item-group theme--light v-expansion-panels"">", 
                    seccion.background_color,
                    idPagina, idSeccion, seccion.titulo, seccion.subtitulo);
            foreach (var item in seccion.lstContenido)
            {
                html += string.Format(
                    @"<div aria-expanded=""false"" class=""v-expansion-panel"" style=""margin-bottom: 20px;
                        border-radius: 5px;"">
                        <button type=""button"" class=""thm-btn main-slider__btn collapsible""
                            style=""font-size: 18px; text-align: left; width: 100%; border: none;""> {0}
                            <div class=""v-expansion-panel-header__icon"" style=""float: right;"">
                                <i aria-hidden=""true"" style=""height: 30px; width: 30px; top: 
                                    5px;font-size: 16px; line-height: 33px;""
                                    class=""fa fa-chevron-down""></i>
                            </div>
                        </button>
                        <div class=""v-expansion-panel-content content-expansion-panels"" style=""display: none;"">
                            <div class=""v-expansion-panel-content__wrap"">{1}", 
                    item.titulo_contenido, item.contenido_contenido);
                foreach (var item2 in item.lstArchivos)
                {
                    html += string.Format(
                    @"
                    <div style=""margin-top: 15px; padding: 15px 20px; border: 1px solid lightgray; 
                        border-radius: 15px;"">
                        <a href=""archivos/Pagina_{0}/{1}"" 
                            target=""_blank"" style=""width: 100%; display: block;"">{2} 
                            <span class=""fa fa-download"" style=""float: right;""></span>
                        </a>
                    </div>
                    ", idPagina, item2.link_archivo, item2.nombre_archivo);
                }

                html += @" </div>";
                html += @"</div>";
                html += @"</div>";
            }

            html += @"</div>";
            html += @"</div>";
            html += @"</section>";
            return html;
        }
    }
}
