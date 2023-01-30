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
                    @"<section style=""margin-top:80px;"" id=""seccion_p{0}s_{1}"">
                        <div class=""container"">
                            <div class=""row"">
                                <div class=""col"">
                                    <h2 style=""position: relative; color: var(--roofsie-gray);
                                        font-weight: 800; line-height: 40px; margin-bottom: 10px; "">
                                            {2}
                                    </h2>
                                    <p style=""font-size:18px; color: var(--roofsie-gray);
                                        line-height:18px; margin-bottom:10px; "">
                                        {3}
                                    </p>
                                </div>
                            </div>
                            <div class=""row"" style=""margin-top:25px;"">
                                <div class=""col col-12"">
                                    <div class=""v-item-group theme--light v-expansion-panels"">",
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


            /*
             <div class=""col col-12"">
                <div class=""v-tabs theme--light"">
                    <div role=""tablist"" class=""v-item-group theme--light v-slide-group 
                        v-tabs-bar primary--text"" data-booted=""true"">
                        <div class=""v-slide-group__prev v-slide-group__prev--disabled""></div>
                        <div class=""v-slide-group__wrapper"">
                            <div class=""v-slide-group__content v-tabs-bar__content"">
                                <div class=""v-tabs-slider-wrapper"" 
                                    style=""height: 2px; left: 0px; width: 130px;"">
                                    <div class=""v-tabs-slider""></div>
                                </div>
                                <div tabindex=""0"" aria-selected=""true"" role=""tab"" 
                                    class=""v-tab v-tab--active""> Pestaña 2
                                </div>
                            </div>
                        </div>
                        <div class="v-slide-group__next v-slide-group__next--disabled"></div>
                    </div>
                </div>
                <div class=""v-window v-item-group theme--light v-tabs-items"">
                    <div class=""v-window__container"">
                        <div class=""v-window-item v-window-item--active"">
                            <div class=""v-card v-card--flat v-sheet theme--light"" 
                                style=""padding-top: 40px;"">
                                <div>
                                    
                                </div>
                                <div style=""margin-top: 15px; padding: 15px 20px; border: 1px solid lightgray; 
                                    border-radius: 15px;"">
                                    <a href="https://vecino.villaallende.gov.ar/institucional_api/Assets/Archivos_Pagina_Institucional/Pagina_1/Archivo_1_Seccion_3_contenido_2.pdf" 
                                        target=""_blank"" style=""width: 100%; display: block;"">
                                        Archivo de prueba 
                                        <span class=""fa fa-download"" style=""float: right;""></span>
                                    </a>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
             
             */
        }
    }
}
