namespace Web_Institucional_Api.Entities
{
    public class Principal
    {
        public static string crearPagina(int idPagina)
        {
            string html =
                @"<!doctype html>
                    <html lang=""en"" style=""overflow-x:hidden;"">";
            html += crearHead();
            html += crearBody();
            html += Entities.Componentes.Header1.read(1);
            html += Entities.Componentes.Cards.getCards(idPagina, 10);
            html += @"</body>
                    </html>";
            return html;
        }
        public static string crearBody()
        {
            string html =
@"
<body>
    <script src=""js/jquery-3.6.0.min.js""></script>
    <script src=""js/bootstrap.bundle.min.js""></script>
    <script src=""js/jarallax.min.js""></script>
    <script src=""js/jquery.ajaxchimp.min.js""></script>
    <script src=""js/jquery.appear.min.js""></script>
    <script src=""js/jquery.circle-progress.min.js""></script>
    <script src=""js/jquery.magnific-popup.min.js""></script>
    <script src=""js/jquery.validate.min.js""></script>
    <script src=""js/nouislider.min.js""></script>
    <script src=""js/odometer.min.js""></script>
    <script src=""js/swiper.min.js""></script>
    <script src=""js/tiny-slider.min.js""></script>
    <script src=""js/wNumb.min.js""></script>
    <script src=""js/wow.js""></script>
    <script src=""js/isotope.js""></script>
    <script src=""js/countdown.min.js""></script>
    <script src=""js/owl.carousel.min.js""></script>
    <script src=""js/jquery.bxslider.min.js""></script>
    <script src=""js/bootstrap-select.min.js""></script>
    <script src=""js/vegas.min.js""></script>
    <script src=""js/jquery-ui.js""></script>
    <script src=""js/timePicker.js""></script>
    <script src=""js/jquery.circleType.js""></script>
    <script src=""js/jquery.lettering.min.js""></script>
    <script src=""js/roofsie.js""></script>
    ";
            return html;
        }
        public static string crearHead()
        {
            string html =
            @"
            <head>
                <meta http-equiv=""Content-Type"" content=""text/html; charset=UTF-8"">
                <meta name=""viewport"" content=""width=device-width,initial-scale=1"">
                <title>Municipalidad de Villa Allende</title>
    
                <link rel=""preconnect"" href=""https://fonts.googleapis.com/"">
                <link rel=""preconnect"" href=""https://fonts.gstatic.com/"">
                <link href=""css/css2.css"" rel=""stylesheet"">
                <link rel=""stylesheet"" href=""css/bootstrap.min.css"">
                <link rel=""stylesheet"" href=""css/animate.min.css"">
                <link rel=""stylesheet"" href=""css/custom-animate.css"">
                <link rel=""stylesheet"" href=""css/all.min.css"">
                <link rel=""stylesheet"" href=""css/jarallax.css"">
                <link rel=""stylesheet"" href=""css/jquery.magnific-popup.css"">
                <link rel=""stylesheet"" href=""css/nouislider.min.css"">
                <link rel=""stylesheet"" href=""css/nouislider.pips.css"">
                <link rel=""stylesheet"" href=""css/odometer.min.css"">
                <link rel=""stylesheet"" href=""css/swiper.min.css"">
                <link rel=""stylesheet"" href=""css/style.css"">
                <link rel=""stylesheet"" href=""css/tiny-slider.min.css"">
                <link rel=""stylesheet"" href=""css/stylesheet.css"">
                <link rel=""stylesheet"" href=""css/owl.carousel.min.css"">
                <link rel=""stylesheet"" href=""css/owl.theme.default.min.css"">
                <link rel=""stylesheet"" href=""css/jquery.bxslider.css"">
                <link rel=""stylesheet"" href=""css/bootstrap-select.min.css"">
                <link rel=""stylesheet"" href=""css/vegas.min.css"">
                <link rel=""stylesheet"" href=""css/jquery-ui.css"">
                <link rel=""stylesheet"" href=""css/timePicker.css"">
                <link rel=""stylesheet"" href=""css/roofsie.css"">
                <link rel=""stylesheet"" href=""css/roofsie-responsive.css"">
            </head>";
            return html;
        }
    }
}
