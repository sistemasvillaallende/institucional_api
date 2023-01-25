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
                    @"<section>
                        <div class=""row"">
                            <div class=""col"">
                                <h2 style=""position: relative; color: var(--roofsie - gray);
                                    font-weight: 800; line-height: 40px; margin-bottom: 10px; "">
                                        {0}
                                </h2>
                                <p style=""font-size:18px; color: var(--roofsie - gray);
                                    line-height:18px; margin-bottom:10px; "">
                                    {1}
                                </p>
                            </div>
                        </div>", seccion.titulo, seccion.subtitulo);

            for (int i = 0; i < cardsList.Count / 3; i++)
            {
                
                if (i * 3 - 3 < cardsList.Count)
                {
                    html += @"<div class=""row"">";
                    html += string.Format(
                    @"
                        <div class=""col-12 col-lg-4 col-xl-4 col-md-6 col-sm-12 col-xs-12"">
                            <div class=""mx-auto my-12 v-card v-sheet theme--light elevation-10"">
                                <div class=""v-image v-responsive theme--light"" 
                                    style=""height: 250px;"">
                                    <div class=""v-responsive__sizer"" style=""padding-bottom: 60%;""></div>
                                    <div class=""v-image__image v-image__image--cover"" 
                                        style=""background-image: url(img/{0}); background-position: center center;"">
                                    </div>
                                    <div class=""v-responsive__content"" style=""width: 500px;""></div>
                                </div>
                                <div class=""v-card__title"">{1}</div>
                                <div class=""v-card__text"">
                                    <div class=""elipsis"">
                                        {2}
                                    </div>
                                </div>
                                <hr role=""separator"" aria-orientation=""horizontal"" 
                                    class=""mx-4 v-divider theme--light"">
                                <div class=""v-card__actions"" style=""text-align: center; display: 
                                    block; padding: 20px;"">
                                    <a target=""{3}"" href=""{4}"" 
                                        color=""deep-purple lighten-2"" class=""btn"" 
                                        style=""background-color: var(--roofsie-gray); 
                                        color: var(--roofsie-white) !important;""> 
                                        {5}
                                    </a>
                                </div>
                            </div>                        
                        </div>
                    ", cardsList[i * 3 - 3].imagen, cardsList[i * 3 - 3].titulo,
                        cardsList[i * 3 - 3].bajada, cardsList[i * 3 - 3].callToActionTarget,
                        cardsList[i * 3 - 3].callToActionlink, cardsList[i * 3 - 3].callToActionTexto);
                    html += @"</div>";
                }
                if (i * 3 - 2 < cardsList.Count)
                {
                    html += @"<div class=""row"">";
                    html += string.Format(
                    @"
                        <div class=""col-12 col-lg-4 col-xl-4 col-md-6 col-sm-12 col-xs-12"">
                            <div class=""mx-auto my-12 v-card v-sheet theme--light elevation-10"">
                                <div class=""v-image v-responsive theme--light"" 
                                    style=""height: 250px;"">
                                    <div class=""v-responsive__sizer"" style=""padding-bottom: 60%;""></div>
                                    <div class=""v-image__image v-image__image--cover"" 
                                        style=""background-image: url(img/{0}); background-position: center center;"">
                                    </div>
                                    <div class=""v-responsive__content"" style=""width: 500px;""></div>
                                </div>
                                <div class=""v-card__title"">{1}</div>
                                <div class=""v-card__text"">
                                    <div class=""elipsis"">
                                        {2}
                                    </div>
                                </div>
                                <hr role=""separator"" aria-orientation=""horizontal"" 
                                    class=""mx-4 v-divider theme--light"">
                                <div class=""v-card__actions"" style=""text-align: center; display: 
                                    block; padding: 20px;"">
                                    <a target=""{3}"" href=""{4}"" 
                                        color=""deep-purple lighten-2"" class=""btn"" 
                                        style=""background-color: var(--roofsie-gray); 
                                        color: var(--roofsie-white) !important;""> 
                                        {5}
                                    </a>
                                </div>
                            </div>                        
                        </div>
                    ", cardsList[i * 3 - 2].imagen, cardsList[i * 3 - 2].titulo,
                        cardsList[i * 3 - 2].bajada, cardsList[i * 3 - 2].callToActionTarget,
                        cardsList[i * 3 - 2].callToActionlink, cardsList[i * 3 - 2].callToActionTexto);
                    html += @"</div>";
                }
                if (i * 3 - 1 < cardsList.Count)
                {
                    html += @"<div class=""row"">";
                    html += string.Format(
                    @"
                        <div class=""col-12 col-lg-4 col-xl-4 col-md-6 col-sm-12 col-xs-12"">
                            <div class=""mx-auto my-12 v-card v-sheet theme--light elevation-10"">
                                <div class=""v-image v-responsive theme--light"" 
                                    style=""height: 250px;"">
                                    <div class=""v-responsive__sizer"" style=""padding-bottom: 60%;""></div>
                                    <div class=""v-image__image v-image__image--cover"" 
                                        style=""background-image: url(img/{0}); background-position: center center;"">
                                    </div>
                                    <div class=""v-responsive__content"" style=""width: 500px;""></div>
                                </div>
                                <div class=""v-card__title"">{1}</div>
                                <div class=""v-card__text"">
                                    <div class=""elipsis"">
                                        {2}
                                    </div>
                                </div>
                                <hr role=""separator"" aria-orientation=""horizontal"" 
                                    class=""mx-4 v-divider theme--light"">
                                <div class=""v-card__actions"" style=""text-align: center; display: 
                                    block; padding: 20px;"">
                                    <a target=""{3}"" href=""{4}"" 
                                        color=""deep-purple lighten-2"" class=""btn"" 
                                        style=""background-color: var(--roofsie-gray); 
                                        color: var(--roofsie-white) !important;""> 
                                        {5}
                                    </a>
                                </div>
                            </div>                        
                        </div>
                    ", cardsList[i * 3 - 1].imagen, cardsList[i * 3 - 1].titulo,
                        cardsList[i * 3 - 1].bajada, cardsList[i * 3 - 1].callToActionTarget,
                        cardsList[i * 3 - 1].callToActionlink, cardsList[i * 3 - 1].callToActionTexto);
                    html += @"</div>";
                }
            }
            html += @"</section>";
            return html;
        }
    }
}
