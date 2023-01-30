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
            html += Entities.Componentes.Carrusel.get(1);
            html += Entities.Componentes.Cards.getCards(idPagina, 10);
            html += Entities.Componentes.Cards2.getCards(idPagina, 53);
            html += Entities.Componentes.Acordion.getCards(idPagina, 2);
            html += Entities.Componentes.TabsHorizontal.getCards(idPagina, 3);
            html += Entities.Componentes.TabsVertical.getCards(idPagina, 8);
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
    <script src=""js/home.js""></script>
    <script src=""js/roofsie.js""></script>
    <script>
        $(document).ready(function() {
              if ($("".accrodion-grp"").length) {
                var accrodionGrp = $("".accrodion-grp"");
                        accrodionGrp.each(function() {
                            var accrodionName = $(this).data(""grp-name"");
                            var Self = $(this);
                            var accordion = Self.find("".accrodion"");
                            Self.addClass(accrodionName);
                            Self.find("".accrodion .accrodion-content"").hide();
                            Self.find("".accrodion.active"").find("".accrodion-content"").show();
                            accordion.each(function() {
                    $(this)
                      .find("".accrodion-title"")
                      .on(""click"", function() {
                                    if ($(this).parent().hasClass(""active"") === false) {
                          $("".accrodion-grp."" + accrodionName)
                            .find("".accrodion"")
                            .removeClass(""active"");
                          $("".accrodion-grp."" + accrodionName)
                            .find("".accrodion"")
                            .find("".accrodion-content"")
                            .slideUp();
                          $(this).parent().addClass(""active"");
                          $(this).parent().find("".accrodion-content"").slideDown();
                                    }
                                });
                            });
                        });
                    }

            $("".mobile-nav__toggler"").on(""click"", function (e) {
                e.preventDefault();
                $("".mobile-nav__wrapper"").toggleClass(""expanded"");
                $(""body"").toggleClass(""locked"");
            });

                let dropdownAnchor = $(
                    "".mobile-nav__container .main-menu__list .dropdown > a""
                );
                dropdownAnchor.each(function() {
                    let self = $(this);
                    let toggleBtn = document.createElement(""BUTTON"");
                    toggleBtn.setAttribute(""aria-label"", ""dropdown toggler"");
                    toggleBtn.innerHTML = ""<i class='fa fa-angle-down'></i>"";
                    self.append(function() {
                        return toggleBtn;
                    });
                    self.find(""button"").on(""click"", function(e) {
                        e.preventDefault();
                        let self = $(this);
                        self.toggleClass(""expanded"");
                        self.parent().toggleClass(""expanded"");
                        self.parent().parent().children(""ul"").slideToggle();
                    });
                });
                    var coll = document.getElementsByClassName(""collapsible"");
                    var i;

                    for (i = 0; i < coll.length; i++)
                    {
                        coll[i].addEventListener(""click"", function() {
                            this.classList.toggle(""active"");
                            var content = this.nextElementSibling;
                            if (content.style.display === ""block"")
                            {
                                content.style.display = ""none"";
                            }
                            else
                            {
                                content.style.display = ""block"";
                            }
                        });
                    }
        });
    </script>
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
                <link rel=""stylesheet"" href=""css/style.css?v=1"">
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
