namespace Web_Institucional_Api.Entities.Componentes
{
    public class Cards
    {
        public static string getCards(int idPagina, int idSeccion)
        {
            string html = "";
            Entities.Secciones seccion = new Entities.Secciones();
            Entities.Cards cards = new Entities.Cards();

            seccion = Secciones.getByPk(idSeccion);
            List<Entities.Cards> cardsList = Entities.Cards.readActivos(idSeccion);

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
                            </div>", 
                    seccion.background_color, idPagina, idSeccion, seccion.titulo, seccion.subtitulo);

            for (int i = 0; i <= cardsList.Count / 3; i++)
            {
                html += @"<div class=""row"" style=""margin-top:25px;"">";
                if ((i + 1) * 3 - 3 < cardsList.Count)
                {
                    html += string.Format(
                    @"
                        <div style=""padding-top:25px;"" class=""col-12 col-lg-4 col-xl-4 col-md-6 col-sm-12 col-xs-12"">
                            <div class=""mx-auto my-12 v-card v-sheet theme--light elevation-10"">
                                <div class=""v-image v-responsive theme--light"" 
                                    style=""height: 250px;"">
                                    <div class=""v-responsive__sizer"" style=""padding-bottom: 60%;""></div>
                                    <div class=""v-image__image v-image__image--cover"" 
                                        style=""background-image: url(img/Pagina_{0}/{1}); background-position: center center;"">
                                    </div>
                                    <div class=""v-responsive__content"" style=""width: 500px;""></div>
                                </div>
                                <div class=""v-card__title"">{2}</div>
                                <div class=""v-card__text"">
                                    <div class=""elipsis"">
                                        {3}
                                    </div>
                                </div>
                                <hr role=""separator"" aria-orientation=""horizontal"" 
                                    class=""mx-4 v-divider theme--light"">
                                <div class=""v-card__actions"" style=""text-align: center; display: 
                                    block; padding: 20px;"">
                                    <a target=""{4}"" href=""{5}"" 
                                        class=""thm-btn main-slider__btn""> 
                                        {6}
                                    </a>
                                </div>
                            </div>                        
                        </div>
                    ", idPagina, cardsList[(i + 1) * 3 - 3].imagen, cardsList[(i + 1) * 3 - 3].titulo,
                        cardsList[(i + 1) * 3 - 3].bajada, cardsList[(i + 1) * 3 - 3].callToActionTarget,
                        cardsList[(i + 1) * 3 - 3].callToActionlink, cardsList[(i + 1) * 3 - 3].callToActionTexto);
                }
                if ((i + 1) * 3 - 2 < cardsList.Count)
                {
                    html += string.Format(
                    @"
                        <div style=""padding-top:25px;"" class=""col-12 col-lg-4 col-xl-4 col-md-6 col-sm-12 col-xs-12"">
                            <div class=""mx-auto my-12 v-card v-sheet theme--light elevation-10"">
                                <div class=""v-image v-responsive theme--light"" 
                                    style=""height: 250px;"">
                                    <div class=""v-responsive__sizer"" style=""padding-bottom: 60%;""></div>
                                    <div class=""v-image__image v-image__image--cover"" 
                                        style=""background-image: url(img/Pagina_{0}/{1}); background-position: center center;"">
                                    </div>
                                    <div class=""v-responsive__content"" style=""width: 500px;""></div>
                                </div>
                                <div class=""v-card__title"">{2}</div>
                                <div class=""v-card__text"">
                                    <div class=""elipsis"">
                                        {3}
                                    </div>
                                </div>
                                <hr role=""separator"" aria-orientation=""horizontal"" 
                                    class=""mx-4 v-divider theme--light"">
                                <div class=""v-card__actions"" style=""text-align: center; display: 
                                    block; padding: 20px;"">
                                    <a target=""{4}"" href=""{5}"" 
                                        class=""thm-btn main-slider__btn""> 
                                        {6}
                                    </a>
                                </div>
                            </div>                        
                        </div>
                    ", idPagina, cardsList[(i + 1) * 3 - 2].imagen, cardsList[(i + 1) * 3 - 2].titulo,
                        cardsList[(i + 1) * 3 - 2].bajada, cardsList[(i + 1) * 3 - 2].callToActionTarget,
                        cardsList[(i + 1) * 3 - 2].callToActionlink, cardsList[(i + 1) * 3 - 2].callToActionTexto);
                }
                if ((i + 1) * 3 - 1 < cardsList.Count)
                {
                    html += string.Format(
                    @"
                        <div style=""padding-top:25px;"" class=""col-12 col-lg-4 col-xl-4 col-md-6 col-sm-12 col-xs-12"">
                            <div class=""mx-auto my-12 v-card v-sheet theme--light elevation-10"">
                                <div class=""v-image v-responsive theme--light"" 
                                    style=""height: 250px;"">
                                    <div class=""v-responsive__sizer"" style=""padding-bottom: 60%;""></div>
                                    <div class=""v-image__image v-image__image--cover"" 
                                        style=""background-image: url(img/Pagina_{0}/{1}); background-position: center center;"">
                                    </div>
                                    <div class=""v-responsive__content"" style=""width: 500px;""></div>
                                </div>
                                <div class=""v-card__title"">{2}</div>
                                <div class=""v-card__text"">
                                    <div class=""elipsis"">
                                        {3}
                                    </div>
                                </div>
                                <hr role=""separator"" aria-orientation=""horizontal"" 
                                    class=""mx-4 v-divider theme--light"">
                                <div class=""v-card__actions"" style=""text-align: center; display: 
                                    block; padding: 20px;"">
                                    <a target=""{4}"" href=""{5}"" 
                                        class=""thm-btn main-slider__btn""> 
                                        {6}
                                    </a>
                                </div>
                            </div>                        
                        </div>
                    ", idPagina, cardsList[(i + 1) * 3 - 1].imagen, cardsList[(i + 1) * 3 - 1].titulo,
                        cardsList[(i + 1) * 3 - 1].bajada, cardsList[(i + 1) * 3 - 1].callToActionTarget,
                        cardsList[(i + 1) * 3 - 1].callToActionlink, cardsList[(i + 1) * 3 - 1].callToActionTexto);

                }
                html += @"</div>";
            }

            html += @"</div>";
            html += @"</section>";
            return html;
        }
    }
}
