namespace Web_Institucional_Api.Entities.Componentes
{
    public class Acordion
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
                                    <div class=""accrodion-grp faq-one-accrodion"" 
                                    data-grp-name=""faq-one-accrodion"">",
                    seccion.background_color,
                    idPagina, idSeccion, seccion.titulo, seccion.subtitulo);
            int i = 0;
            foreach (var item in seccion.lstContenido)
            {
                if (i == 0)
                {
                    html += string.Format(
                        @"
                        <div class=""accrodion active"">
                            <div class=""accrodion-title"">
                                <h4>{0}</h4>
                            </div>
                            <div class=""accrodion-content"">
                                <div class=""inner"">{1}",
                                item.titulo_contenido, item.contenido_contenido);
                }
                else
                {
                    html += string.Format(
                        @"
                        <div class=""accrodion"">
                            <div class=""accrodion-title"">
                                <h4>{0}</h4>
                            </div>
                            <div class=""accrodion-content"" style=""display: none;"">
                                <div class=""inner"">{1}",
                                item.titulo_contenido, item.contenido_contenido);
                }
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
                i ++;
            }
            /*

                                            
                        </div>
                    </div>
                </div>
             </div>
             */
            html += @"</div>";
            html += @"</div>";
            html += @"</div>";
            html += @"</div>";
            html += @"</section>";
            return html;
        }
    }
}
