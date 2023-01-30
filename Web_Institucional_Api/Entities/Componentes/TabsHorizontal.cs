namespace Web_Institucional_Api.Entities.Componentes
{
    public class TabsHorizontal
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
                                    <nav>
		                                <div class=""nav nav-tabs"" id=""nav-tab"" role=""tablist"">",
                    seccion.background_color,
                    idPagina, idSeccion, seccion.titulo, seccion.subtitulo);
            int i = 0;
            foreach (var item in seccion.lstContenido)
            {
                if (i == 0)
                {
                    html += string.Format(
                        @"
                        <button class=""nav-link active"" id=""nav-home-tab-{0}"" 
                            data-bs-toggle=""tab"" data-bs-target=""#nav-{0}"" type=""button"" 
                            role=""tab"" aria-controls=""nav-{0}"" aria-selected=""true"">{1}</button>", 
                            item.id, item.titulo_contenido);
                }
                else
                {
                    html += string.Format(
                        @"
                        <button class=""nav-link"" id=""nav-home-tab-{0}"" 
                            data-bs-toggle=""tab"" data-bs-target=""#nav-{0}"" type=""button"" 
                            role=""tab"" aria-controls=""nav-{0}"" aria-selected=""false"">{1}</button>",
                            item.id, item.titulo_contenido);
                }
                i++;
            }
            html += @"</div>
		        </nav>
                <div class=""tab-content"" id=""nav-tabContent"">";
            i = 0;
            foreach (var item in seccion.lstContenido)
            {
                if (i == 0)
                {
                    html += string.Format(
                        @"<div class=""tab-pane fade show active"" id=""nav-{0}"" role=""tabpanel"" 
                            style=""padding-top:30px; padding-bottom:30px;""
                            aria-labelledby=""nav-{0}-tab"">{1}", item.id, item.contenido_contenido);
                }
                else
                {
                    html += string.Format(
                        @"<div class=""tab-pane fade"" id=""nav-{0}"" role=""tabpanel"" 
                            style=""padding-top:30px; padding-bottom:30px;""
                            aria-labelledby=""nav-{0}-tab"">{1}", item.id, item.contenido_contenido);
                }
                foreach (var item2 in item.lstArchivos)
                {
                    html += string.Format(
                        @"
                        <div style=""margin-top: 15px; padding: 15px 20px; border: 1px solid lightgray; 
                            border-radius: 15px;"">
                            <a href=""{0}"" target = ""_blank"" style = ""width: 100 %; display: block; "">
                                {1}
                                <span class=""fa fa-download"" style=""float: right;""></span>
                            </a>
                        </div>", item2.nombre_archivo, item2.link_archivo);
                    i++;
                }
                html += @"</div>";
                i++;
            }
            html += @"
                                </div>
                            </div>  
                        </div>
                    </section>";

            return html;
        }
    }
}
