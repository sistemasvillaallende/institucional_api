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
    <script src=""https://cdnjs.cloudflare.com/ajax/libs/stacktable.js/1.0.3/stacktable.min.js""
        integrity=""sha512-cz2xHIVB1JdqImhx3csqiWDNvdjh1QeRBlXpO3dMkoPXqDA59axTzDsLl8SmUUetVoONwu6L/SXGiG5meJ3OJg==""
        crossorigin=""anonymous"" referrerpolicy=""no-referrer""></script>
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
                <link rel=""shortcut icon"" href=""https://villaallende.gob.ar/sites/default/files/favicon_0.ico""
                    type=""image/vnd.microsoft.icon"">
                <link rel=""preconnect"" href=""https://fonts.googleapis.com/"">
                <link rel=""preconnect"" href=""https://fonts.gstatic.com/"" crossorigin="""">
                <link href=""css/chunk-vendors.506c8c2b.css"" rel=""stylesheet"">
                <link href=""css/app.b508f9be.css"" rel=""stylesheet"">
                <link href=""css/Home.148d7ec8.css"" rel=""stylesheet"">
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
                <link rel=""stylesheet"" href=""css/demo.css"">
                <link rel=""stylesheet"" href=""css/icon-moon.css"">
                <link rel=""stylesheet"" href=""css/roofsie.css?v=1"">
                <link rel=""stylesheet"" href=""css/roofsie-responsive.css"">
                <link rel=""stylesheet"" href=""https://cdn.datatables.net/1.13.1/css/jquery.dataTables.min.css"">
                <style id=""jarallax-clip-0"">
                    #jarallax-container-0 {
                        clip: rect(0 1583px 493px 0);
                        clip: rect(0, 1583px, 493px, 0);
                        -webkit-clip-path: polygon(0 0, 100% 0, 100% 100%, 0 100%);
                        clip-path: polygon(0 0, 100% 0, 100% 100%, 0 100%);
                    }

                    .btn-check:focus+.btn,
                    .btn:focus {
                        outline: 0;
                        border: none !important;
                        box-shadow: 0 0 0 0.25rem rgb(255 209 66 / 85%);
                    }

                    :root {
                        --roofsie-font: 'Manrope', sans-serif;
                        --roofsie-reey-font: ""reeyregular"";
                        --roofsie-gray: #6F6F6E;
                        --roofsie-gray-rgb: 111, 111, 110;
                        --roofsie-white: #FFD300;
                        --roofsie-white-rgb: 255, 211, 0;
                        --roofsie-base: #F3F0ED;
                        --roofsie-base-rgb: 243, 240, 237;
                        --roofsie-black: #1c1b1f;
                        --roofsie-black-rgb: 28, 27, 31;
                        --roofsie-primary: #C6C6C5;
                        --roofsie-primary-rgb: 198, 198, 197;
                        --roofsie-bdr-radius: 5px;
                        --roofsie-blanco: white;
                    }

                    .main-timeline {
                        position: relative;
                    }

                    .main-timeline:before,
                    .main-timeline:after {
                        content: """";
                        display: block;
                        width: 100%;
                        clear: both;
                    }

                    .main-timeline:before {
                        content: """";
                        width: 3px;
                        height: 100%;
                        background: #bababa;
                        position: absolute;
                        top: 0;
                        left: 50%;
                    }

                    .main-timeline .timeline {
                        width: 50%;
                        float: left;
                        position: relative;
                        z-index: 1;
                    }

                    .main-timeline .timeline:before,
                    .main-timeline .timeline:after {
                        content: """";
                        display: block;
                        width: 100%;
                        clear: both;
                    }

                    .main-timeline .timeline:first-child:before,
                    .main-timeline .timeline:last-child:before {
                        content: """";
                        width: 25px;
                        height: 25px;
                        border-radius: 50%;
                        background: #fff;
                        border: 4px solid rgba(211, 207, 205, 1);
                        position: absolute;
                        top: 0;
                        right: -14px;
                        z-index: 1;
                    }

                    .main-timeline .timeline:last-child:before {
                        top: auto;
                        bottom: 0;
                    }

                    .main-timeline .timeline:last-child:nth-child(even):before {
                        right: auto;
                        left: -12px;
                        bottom: -2px;
                    }

                    .main-timeline .timeline-content {
                        text-align: center;
                        margin-top: 8px;
                        position: relative;
                        transition: all 0.3s ease 0s;
                    }

                    .main-timeline .timeline-content:before {
                        content: """";
                        width: 100%;
                        height: 5px;
                        background: rgba(211, 207, 205, 1);
                        position: absolute;
                        top: 88px;
                        left: 0;
                        z-index: -1;
                    }

                    .main-timeline .circle {
                        width: 180px;
                        height: 180px;
                        border-radius: 50%;
                        background: #fff;
                        border: 8px solid rgba(211, 207, 205, 1);
                        float: left;
                        margin-right: 25px;
                        position: relative;
                    }

                    .main-timeline .circle:before {
                        content: """";
                        width: 26px;
                        height: 30px;
                        background: rgba(211, 207, 205, 1);
                        margin: auto;
                        position: absolute;
                        top: 0;
                        right: -33px;
                        bottom: 0;
                        z-index: -1;
                        box-shadow: inset 7px 0 9px -7px #444;
                    }

                    .main-timeline .circle span {
                        display: block;
                        width: 100%;
                        height: 100%;
                        border-radius: 50%;
                        line-height: 268px;
                        font-size: 80px;
                        color: #454344;
                    }

                    .main-timeline .circle span:before,
                    .main-timeline .circle span:after {
                        content: """";
                        width: 28px;
                        height: 50px;
                        background: #fff;
                        border-radius: 0 0 0 21px;
                        margin: auto;
                        position: absolute;
                        top: -54px;
                        right: -33px;
                        bottom: 0;
                        z-index: -1;
                    }

                    .main-timeline .circle span:after {
                        border-radius: 21px 0 0 0;
                        top: 0;
                        bottom: -56px;
                    }

                    .main-timeline .circle .img {
                        vertical-align: initial;
                        border-radius: 50%;
                    }

                    .main-timeline .content {
                        display: table;
                        padding-right: 40px;
                        position: relative;
                    }

                    .main-timeline .year {
                        display: block;
                        padding: 10px;
                        margin: 10px 0 50px 0;
                        background: rgba(211, 207, 205, 1);
                        border-radius: 7px;
                        font-size: 25px;
                        color: #fff;
                    }

                    .main-timeline .title {
                        font-size: 25px;
                        font-weight: bold;
                        color: rgba(211, 207, 205, 1);
                        margin-top: 0;
                    }

                    .main-timeline .description {
                        font-size: 14px;
                        color: #333;
                        text-align: justify;
                    }

                    .main-timeline .icon {
                        width: 25px;
                        height: 25px;
                        border-radius: 50%;
                        background: #fff;
                        border: 4px solid rgba(211, 207, 205, 1);
                        position: absolute;
                        top: 78px;
                        right: -14px;
                    }

                    .main-timeline .icon:before {
                        content: """";
                        width: 15px;
                        height: 25px;
                        background: rgba(211, 207, 205, 1);
                        margin: auto;
                        position: absolute;
                        top: -1px;
                        left: -15px;
                        bottom: 0;
                        z-index: -1;
                    }

                    .main-timeline .icon span:before,
                    .main-timeline .icon span:after {
                        content: """";
                        width: 21px;
                        height: 25px;
                        background: #fff;
                        border-radius: 0 0 21px 0;
                        margin: auto;
                        position: absolute;
                        top: -30px;
                        left: -15px;
                        bottom: 0;
                        z-index: -1;
                    }

                    .main-timeline .icon span:after {
                        border-radius: 0 21px 0 0;
                        top: 0;
                        left: -15px;
                        bottom: -30px;
                    }

                    .main-timeline .timeline:nth-child(2n) .timeline-content,
                    .main-timeline .timeline:nth-child(2n) .circle {
                        float: right;
                    }

                    .main-timeline .timeline:nth-child(2n) .circle {
                        margin: 0 0 0 25px;
                    }

                    .main-timeline .timeline:nth-child(2n) .circle:before {
                        right: auto;
                        left: -33px;
                        box-shadow: -7px 0 9px -7px #444 inset;
                    }

                    .main-timeline .timeline:nth-child(2n) .circle span:before,
                    .main-timeline .timeline:nth-child(2n) .circle span:after {
                        right: auto;
                        left: -33px;
                        border-radius: 0 0 21px 0;
                    }

                    .main-timeline .timeline:nth-child(2n) .circle span:after {
                        border-radius: 0 21px 0 0;
                    }

                    .main-timeline .timeline:nth-child(2n) .content {
                        padding: 0 0 0 40px;
                        margin-left: 2px;
                    }

                    .main-timeline .timeline:nth-child(2n) .icon {
                        right: auto;
                        left: -14px;
                    }

                    .main-timeline .timeline:nth-child(2n) .icon:before,
                    .main-timeline .timeline:nth-child(2n) .icon span:before,
                    .main-timeline .timeline:nth-child(2n) .icon span:after {
                        left: auto;
                        right: -15px;
                    }

                    .main-timeline .timeline:nth-child(2n) .icon span:before {
                        border-radius: 0 0 0 21px;
                    }

                    .main-timeline .timeline:nth-child(2n) .icon span:after {
                        border-radius: 21px 0 0 0;
                    }

                    .main-timeline .timeline:nth-child(2) {
                        margin-top: 180px;
                    }

                    .main-timeline .timeline:nth-child(odd) {
                        margin: -175px 0 0 0;
                    }

                    .main-timeline .timeline:nth-child(even) {
                        margin-bottom: 180px;
                    }

                    .main-timeline .timeline:first-child,
                    .main-timeline .timeline:last-child:nth-child(even) {
                        margin: 0;
                    }

                    @media only screen and (max-width: 990px) {
                        .main-timeline:before {
                            left: 100%;
                        }

                        .main-timeline .timeline {
                            width: 100%;
                            float: none;
                            margin-bottom: 20px !important;
                        }

                        .main-timeline .timeline:first-child:before,
                        .main-timeline .timeline:last-child:before {
                            left: auto !important;
                            right: -13px !important;
                        }

                        .main-timeline .timeline:nth-child(2n) .circle {
                            float: left;
                            margin: 0 25px 0 0;
                        }

                        .main-timeline .timeline:nth-child(2n) .circle:before {
                            right: -33px;
                            left: auto;
                            box-shadow: 7px 0 9px -7px #444 inset;
                        }

                        .main-timeline .timeline:nth-child(2n) .circle span:before,
                        .main-timeline .timeline:nth-child(2n) .circle span:after {
                            right: -33px;
                            left: auto;
                            border-radius: 0 0 0 21px;
                        }

                        .main-timeline .timeline:nth-child(2n) .circle span:after {
                            border-radius: 21px 0 0 0;
                        }

                        .main-timeline .timeline:nth-child(2n) .content {
                            padding: 0 40px 0 0;
                            margin-left: 0;
                        }

                        .main-timeline .timeline:nth-child(2n) .icon {
                            right: -14px;
                            left: auto;
                        }

                        .main-timeline .timeline:nth-child(2n) .icon:before,
                        .main-timeline .timeline:nth-child(2n) .icon span:before,
                        .main-timeline .timeline:nth-child(2n) .icon span:after {
                            left: -15px;
                            right: auto;
                        }

                        .main-timeline .timeline:nth-child(2n) .icon span:before {
                            border-radius: 0 0 21px 0;
                        }

                        .main-timeline .timeline:nth-child(2n) .icon span:after {
                            border-radius: 0 21px 0 0;
                        }

                        .main-timeline .timeline:nth-child(2),
                        .main-timeline .timeline:nth-child(odd),
                        .main-timeline .timeline:nth-child(even) {
                            margin: 0;
                        }
                    }

                    @media only screen and (max-width: 480px) {
                        .main-timeline:before {
                            left: 0;
                        }

                        .main-timeline .timeline:first-child:before,
                        .main-timeline .timeline:last-child:before {
                            left: -12px !important;
                            right: auto !important;
                        }

                        .main-timeline .circle,
                        .main-timeline .timeline:nth-child(2n) .circle {
                            width: 130px;
                            height: 130px;
                            float: none;
                            margin: 0 auto;
                        }

                        .main-timeline .timeline-content:before {
                            width: 99.5%;
                            top: 68px;
                            left: 0.5%;
                        }

                        .main-timeline .circle span {
                            line-height: 115px;
                            font-size: 60px;
                        }

                        .main-timeline .circle:before,
                        .main-timeline .circle span:before,
                        .main-timeline .circle span:after,
                        .main-timeline .icon {
                            display: none;
                        }

                        .main-timeline .content,
                        .main-timeline .timeline:nth-child(2n) .content {
                            padding: 0 10px;
                        }

                        .main-timeline .year {
                            margin-bottom: 15px;
                        }

                        .main-timeline .description {
                            text-align: center;
                        }
                    }
                </style>
                <link rel=""stylesheet"" href=""css/stacktable.css"" />
                <link rel=""stylesheet"" href=""https://cdnjs.cloudflare.com/ajax/libs/font-awesome/6.1.2/css/all.min.css""
                    integrity=""sha512-1sCRPdkRXhBV2PBLUdRb4tMg1w2YPf37qatUFeS7zlBy7jJI8Lf4VHwWfZZfpXtYSLy85pkm9GaYVYMfw5BC1A==""
                    crossorigin=""anonymous"" referrerpolicy=""no-referrer"" />
                <style>
                    html,
                    body,
                    div,
                    p,
                    a,
                    button,
                    h1,
                    h2,
                    h3,
                    h4,
                    h5,
                    h6,
                    ul,
                    li,
                    span {
                        font-family: 'Encode Sans', sans-serif;
                    }
                    .elipsis {
                        display: block;
                        display: -webkit-box;
                        max-width: 100%;
                        margin: 0 auto;
                        line-height: 1.5;
                        -webkit-line-clamp: 5;
                        -webkit-box-orient: vertical;
                        overflow: hidden;
                        text-overflow: ellipsis;
                    }
                </style>
                <script defer=""defer"" type=""module"" src=""js/chunk-vendors.b7215bf1.js""></script>
                <script defer=""defer"" type=""module"" src=""js/app.eb298af3.js""></script>
                <script defer=""defer"" src=""js/chunk-vendors-legacy.41bb6c99.js"" nomodule></script>
                <script defer=""defer"" src=""js/app-legacy.f3eb9095.js"" nomodule></script>

            </head>";
            return html;
        }
    }
}
