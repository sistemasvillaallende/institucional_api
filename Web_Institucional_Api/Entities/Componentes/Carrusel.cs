namespace Web_Institucional_Api.Entities.Componentes
{
    public class Carrusel
    {
        public static string get(int idPagina)
        {
            string html = string.Empty;
            List<Entities.Carrusel> lstSlides = Entities.Carrusel.readActivos(idPagina);
            html = 
                @"
                <div class=""main-slider clearfix"" id=""home"">
                    <div style=""width:100%;"" class=""swiper-container thm-swiper__slider 
                        swiper-container-fade swiper-container-initialized swiper-container-horizontal""
                        data-swiper-options=""{&quot;slidesPerView&quot;: 1, &quot;loop&quot;: true,
                            &quot;effect&quot;: &quot;fade&quot;,
                            &quot;pagination&quot;: {
                            &quot;el&quot;: &quot;#main-slider-pagination&quot;,
                            &quot;type&quot;: &quot;bullets&quot;,
                            &quot;clickable&quot;: true
                            },
                            &quot;navigation&quot;: {
                            &quot;nextEl&quot;: &quot;#main-slider__swiper-button-next&quot;,
                            &quot;prevEl&quot;: &quot;#main-slider__swiper-button-prev&quot;
                            },
                            &quot;autoplay&quot;: {
                            &quot;delay&quot;: 5000
                            }}"">
                        <div class=""swiper-wrapper"" style=""transition-duration: 0ms;"">";
            foreach (var item in lstSlides)
            {
                html += string.Format(
                    @"
                    <div class=""swiper-slide swiper-slide-prev"" data-swiper-slide-index=""1""
                        v-for=""(item, index) in carrusel"" :key=""index""
                        style=""width: 1583px; transition-duration: 0ms; opacity: 1; 
                        transform: translate3d(-1583px, 0px, 0px);"">
.                       <div class=""image-layer""
                            style=""background-image: url('img/Pagina_{0}/{1}')"">
                        </div>
                    ", idPagina, item.img);
                html += string.Format(
                    @"
                    <div class=""container"" style=""padding-top:90px;"">
                        <div class=""row"">
                            <div class=""col-xl-7 col-lg-8"">
                                <div class=""main-slider__content"">
                                    <p class=""main-slider__sub-title"">{0}</p>
                                    <h2 class=""main-slider__title"">{1}</h2>
                                    <p class=""main-slider__text"">{2}</p>
                                    <div class=""main-slider__btn-box"">
                                        <a href=""{3}"" class=""thm-btn main-slider__btn""
                                            target=""{4}"" style=""padding:15px; font-weight:700""> {5} </a>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>", item.resenia, item.titulo, item.bajada, item.callToActionLink,
                    item.callToActionTarget, item.callToAction);
            }
            html += @"
                <div class=""main-slider__nav"">
                    <div class=""swiper-button-prev"" id=""main-slider__swiper-button-next"" tabindex=""0"" role=""button""
                        aria-label=""Next slide"">
                        <i class=""fa fa-chevron-left""></i>
                    </div>
                    <div class=""swiper-button-next"" id=""main-slider__swiper-button-prev"" tabindex=""0"" role=""button""
                        aria-label=""Previous slide"">
                        <i class=""fa fa-chevron-right""></i>
                    </div>
                </div>

                <span class=""swiper-notification"" aria-live=""assertive"" aria-atomic=""true""></span>
            </div>
        </div>
    </div>
                    ";
            return html;
        }
    }
}
