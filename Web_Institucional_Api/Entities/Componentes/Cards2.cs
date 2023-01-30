namespace Web_Institucional_Api.Entities.Componentes
{
    public class Cards2
    {
        public static string getCards(int idPagina, int idSeccion)
        {
            string html = "";
            Entities.Secciones seccion = new Entities.Secciones();
            Entities.Cards cards = new Entities.Cards();

            seccion = Secciones.getByPk(idSeccion);
            List<Entities.Cards> cardsList = Entities.Cards.readActivos(idSeccion);

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
                            </div>", idPagina, idSeccion, seccion.titulo, seccion.subtitulo);

            for (int i = 0; i <= cardsList.Count / 3; i++)
            {
                html += @"<div class=""row"" style=""margin-top:25px;"">";
                if ((i + 1) * 3 - 3 < cardsList.Count)
                {
                    html += string.Format(
                    @"
                        <div style=""padding-top:25px;"" class=""col-12 col-lg-4 col-xl-4 col-md-6 col-sm-12 col-xs-12"">
                            <div class=""owl-item active"">
                                <div class=""item"">
                                    <div style=""box-shadow: 0px 0px 30px 0px rgb(0 0 0 / 10%); height: 183px;
                                        border: 1px solid transparent; border-left: solid 10px #ede8e4; position: relative;
                                        display: block;
                                        border: 1px solid #ede8e4;
                                        border-radius: var(--roofsie-bdr-radius);
                                        background-color: rgb(255, 255, 255);
                                        padding: 20px 20px 15px;
                                        -webkit-transition: all 500ms ease;
                                        transition: all 500ms ease;"">
                                        <div class=""testimonial-one__client-info"" style=""height:100px;"">
                                            <div class=""testimonial-one__client-img-box"" 
                                                style=""position: absolute; border-radius: 0; 
                                                    background: no-repeat;"">
                                                <div class=""testimonial-one__client-img"" 
                                                    style=""padding-right: 5px; border-right: 
                                                    solid 6px #6f6f6e;"">
                                                    <img style=""width: 95% !important; height: 85px; border-radius: 0;"" 
                                                        src=""img/Pagina_{0}/{1}"" alt="""">
                                                </div>
                                            </div>
                                            <div class=""testimonial-one__client-details"" style=""margin-left: 100px;"">
                                                <h4 class=""testimonial-one__client-name"" 
                                                    style=""font-size:16px; font-size:16px; font-weight: 500; 
                                                        line-height: 20px;"">{2}</h4>
                                                <p class=""testimonial-one__client-sub-title"" 
                                                    style=""font-size: 18px; font-weight: 800;"">{3}</p>
                                            </div>
                                        </div>
                                        <hr style=""margin-bottom: 7px; padding-top: 2px;""/>
                                        <div style=""padding-top: 5px; text-align: center;"" 
                                            class=""testimonial-one__text"">{4}
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                    ", idPagina, cardsList[(i + 1) * 3 - 3].imagen, cardsList[(i + 1) * 3 - 3].titulo,
                        cardsList[(i + 1) * 3 - 3].subtitulo, cardsList[(i + 1) * 3 - 3].bajada);
                }
                if ((i + 1) * 3 - 2 < cardsList.Count)
                {
                    html += string.Format(
@"
                        <div style=""padding-top:25px;"" class=""col-12 col-lg-4 col-xl-4 col-md-6 col-sm-12 col-xs-12"">
                            <div class=""owl-item active"">
                                <div class=""item"">
                                    <div style=""box-shadow: 0px 0px 30px 0px rgb(0 0 0 / 10%); height: 183px;
                                        border: 1px solid transparent; border-left: solid 10px #ede8e4; position: relative;
                                        display: block;
                                        border: 1px solid #ede8e4;
                                        border-radius: var(--roofsie-bdr-radius);
                                        background-color: rgb(255, 255, 255);
                                        padding: 20px 20px 15px;
                                        -webkit-transition: all 500ms ease;
                                        transition: all 500ms ease;"">
                                        <div class=""testimonial-one__client-info"" style=""height:100px;"">
                                            <div class=""testimonial-one__client-img-box"" 
                                                style=""position: absolute; border-radius: 0; 
                                                    background: no-repeat;"">
                                                <div class=""testimonial-one__client-img"" 
                                                    style=""padding-right: 5px; border-right: 
                                                    solid 6px #6f6f6e;"">
                                                    <img style=""width: 95% !important; height: 85px; border-radius: 0;"" 
                                                        src=""img/Pagina_{0}/{1}"" alt="""">
                                                </div>
                                            </div>
                                            <div class=""testimonial-one__client-details"" style=""margin-left: 100px;"">
                                                <h4 class=""testimonial-one__client-name"" 
                                                    style=""font-size:16px; font-size:16px; font-weight: 500; 
                                                        line-height: 20px;"">{2}</h4>
                                                <p class=""testimonial-one__client-sub-title"" 
                                                    style=""font-size: 18px; font-weight: 800;"">{3}</p>
                                            </div>
                                        </div>
                                        <hr style=""margin-bottom: 7px; padding-top: 2px;""/>
                                        <div style=""padding-top: 5px; text-align: center;"" 
                                            class=""testimonial-one__text"">{4}
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                    ", idPagina, cardsList[(i + 1) * 3 - 2].imagen, cardsList[(i + 1) * 3 - 2].titulo,
                        cardsList[(i + 1) * 3 - 2].subtitulo, cardsList[(i + 1) * 3 - 2].bajada);
                }
                if ((i + 1) * 3 - 1 < cardsList.Count)
                {
                    html += string.Format(
@"
                        <div style=""padding-top:25px;"" class=""col-12 col-lg-4 col-xl-4 col-md-6 col-sm-12 col-xs-12"">
                            <div class=""owl-item active"">
                                <div class=""item"">
                                    <div style=""box-shadow: 0px 0px 30px 0px rgb(0 0 0 / 10%); height: 183px;
                                        border: 1px solid transparent; border-left: solid 10px #ede8e4; position: relative;
                                        display: block;
                                        border: 1px solid #ede8e4;
                                        border-radius: var(--roofsie-bdr-radius);
                                        background-color: rgb(255, 255, 255);
                                        padding: 20px 20px 15px;
                                        -webkit-transition: all 500ms ease;
                                        transition: all 500ms ease;"">
                                        <div class=""testimonial-one__client-info"" style=""height:100px;"">
                                            <div class=""testimonial-one__client-img-box"" 
                                                style=""position: absolute; border-radius: 0; 
                                                    background: no-repeat;"">
                                                <div class=""testimonial-one__client-img"" 
                                                    style=""padding-right: 5px; border-right: 
                                                    solid 6px #6f6f6e;"">
                                                    <img style=""width: 95% !important; height: 85px; border-radius: 0;"" 
                                                        src=""img/Pagina_{0}/{1}"" alt="""">
                                                </div>
                                            </div>
                                            <div class=""testimonial-one__client-details"" style=""margin-left: 100px;"">
                                                <h4 class=""testimonial-one__client-name"" 
                                                    style=""font-size:16px; font-size:16px; font-weight: 500; 
                                                        line-height: 20px;"">{2}</h4>
                                                <p class=""testimonial-one__client-sub-title"" 
                                                    style=""font-size: 18px; font-weight: 800;"">{3}</p>
                                            </div>
                                        </div>
                                        <hr style=""margin-bottom: 7px; padding-top: 2px;""/>
                                        <div style=""padding-top: 5px; text-align: center;"" 
                                            class=""testimonial-one__text"">{4}
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                    ", idPagina, cardsList[(i + 1) * 3 - 1].imagen, cardsList[(i + 1) * 3 - 1].titulo,
                        cardsList[(i + 1) * 3 - 1].subtitulo, cardsList[(i + 1) * 3 - 1].bajada);
                }
                html += @"</div>";
            }

            html += @"</div>";
            html += @"</section>";
            return html;
        }
    }
}
