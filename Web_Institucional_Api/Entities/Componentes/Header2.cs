namespace Web_Institucional_Api.Entities.Componentes
{
    public class Header2
    {
        public static string read(int idSitio)
        {
            Entities.Institucional objDatos = Entities.Institucional.getByPk(idSitio);
            List<Entities.Menu> lstMenu = Entities.Menu.readActivos(0, idSitio);
            string destino = string.Empty;

            string html = string.Format(
        @"<header class=""main-header clearfix"">
            <div class=""main-header__logo"">
                <a href=""index.html""><img src=""img/{0}"" alt=""""></a>
            </div>
            <div class=""main-header__top"">
                <div class=""main-header__top-inner"">
                    <div class=""main-header__top-address"">
                        
                    </div>
                    <div class=""main-header__top-right"">
                        <div class=""main-header__top-menu-box"">

                        </div>
                        <div class=""main-header__top-social-box"">
                            <div class=""main-header__top-social"">", objDatos.logo);

            if (objDatos.facebook != string.Empty)
            {
                html += string.Format(
                @"<a href=""{0}"">
                    <i class=""fab fa-facebook-square""></i>
                  </a>", objDatos.facebook);
            }
            if (objDatos.instagram != string.Empty)
            {
                html += string.Format(
                @"<a href=""{0}"">
                    <i class=""fab fa-instagram""></i>
                  </a>", objDatos.instagram);
            }
            if (objDatos.youtube != string.Empty)
            {
                html += string.Format(
                @"<a href=""{0}"" style=""margin-right: 10px;"">
                    <i class=""fab fa-youtube"" style=""font-size: 28px;""></i>
                  </a>", objDatos.youtube);
            }
            if (objDatos.twitter != string.Empty)
            {
                html += string.Format(
                @"<a href=""{0}"" style=""margin-right: 10px;"">
                    <i class=""fab fa-twitter"" style=""font-size: 28px;""></i>
                  </a>", objDatos.twitter);
            }
            html += string.Format(
        @"
                            </div>
                        </div>
                    </div>
                </div>
            </div>
            <nav class=""main-menu clearfix"">
                <div class=""main-menu__wrapper clearfix"">
                    <div class=""main-menu__wrapper-inner clearfix"">
                        <div class=""main-menu__left"">
                            <div class=""main-menu__main-menu-box"">
                                <a href=""#"" class=""mobile-nav__toggler""><i class=""fa fa-bars""></i></a>
                                <ul class=""main-menu__list"">", objDatos.logo);

            foreach (Entities.Menu menu in lstMenu)
            {
                if (menu.tipo == 1)
                {
                    html += string.Format(
                        @"<li class=""dropdown"">
                            <a href=""#"">{0}</a>
                                <ul class=""border-top-2px"">
                        ", menu.texto);
                    foreach (var item in menu.lstHijos)
                    {
                        if (item.destino == "interna")
                            destino = string.Format("Pagina_{0}.html", item.id_page);
                        else
                            destino = item.url;

                        html += string.Format(
                        @"<li>
                            <a href=""{0}"" target=""{1}"">{2}</a>
                          </li>", destino, item._target, item.texto);
                    }
                    html += @"</ul>
                         </li>";
                }
                if (menu.tipo == 0)
                {
                    if (menu.destino == "interna")
                        destino = string.Format("Pagina_{0}.html", menu.id_page);
                    else
                        destino = menu.url;

                    html += string.Format(
                        @"<li>
                            <a href=""{0}"" target=""{1}"">{2}</a>
                          </li>
                        ", destino, menu._target, menu.texto);
                }
            }
            html +=
            string.Format(@"
                                    </ul>
                            </div>
                        </div>
                        <div class=""main-menu__right"">

                        </div>
                    </div>
                </div>
            </nav>
        </header>
        <div class=""mobile-nav__wrapper"">
            <div class=""mobile-nav__overlay mobile-nav__toggler""></div>
            <div class=""mobile-nav__content"">
                <span class=""mobile-nav__close mobile-nav__toggler""><i class=""fa fa-times""></i></span>
                <div class=""logo-box"">
                    <a href=""index.html"" aria-label=""logo image"">
					    <img src=""img/{0}"" width=""143"" alt="""">
				    </a>
                </div>
                <div class=""mobile-nav__container""> 
                    <ul class=""main-menu__list"">", objDatos.logo);
            foreach (Entities.Menu menu in lstMenu)
            {
                if (menu.tipo == 1)
                {
                    html += string.Format(
                        @"<li class=""dropdown"">
                            <a href=""#"">{0}

                            </a>
                            <ul class=""border-top-2px"">
                        ", menu.texto);
                    foreach (var item in menu.lstHijos)
                    {
                        if (item.destino == "interna")
                            destino = string.Format("Pagina_{0}.html", item.id_page);
                        else
                            destino = item.url;

                        html += string.Format(
                        @"<li>
                            <a href=""Page_{0}.html"" target=""{1}"">{2}</a>
                          </li>
                        ", destino, item._target, item.texto);
                    }
                    html += @"</ul>
                         </li>";
                }
                if (menu.tipo == 0)
                {
                    if (menu.destino == "interna")
                        destino = string.Format("Pagina_{0}.html", menu.id_page);
                    else
                        destino = menu.url;

                    html += string.Format(
                        @"<li class=""scrollToLink"">
                            <a href=""{0}"" target=""{1}"">{2}</a>
                          </li>
                        ", destino, menu._target, menu.texto);
                }
            }

            html += @"</ul></div>
                <ul class=""mobile-nav__contact list-unstyled"">
                    <li>
                        <i class=""fa fa-envelope""></i>
                        <a href=""mailto:needhelp@packageName__.com"">needhelp@roofsie.com</a>
                    </li>
                    <li>
                        <i class=""fa fa-phone-alt""></i>
                        <a href=""tel:666-888-0000"">666 888 0000</a>
                    </li>
                </ul>
                <div class=""mobile-nav__top"">
                    <div class=""mobile-nav__social"">";


            if (objDatos.facebook != string.Empty)
            {
                html += string.Format(
                @"<a href=""{0}"">
                    <i class=""fab fa-facebook-square""></i>
                  </a>", objDatos.facebook);
            }
            if (objDatos.instagram != string.Empty)
            {
                html += string.Format(
                @"<a href=""{0}"">
                    <i class=""fab fa-instagram""></i>
                  </a>", objDatos.instagram);
            }
            if (objDatos.youtube != string.Empty)
            {
                html += string.Format(
                @"<a href=""{0}"" style=""margin-right: 10px;"">
                    <i class=""fab fa-youtube"" style=""font-size: 28px;""></i>
                  </a>", objDatos.youtube);
            }
            if (objDatos.twitter != string.Empty)
            {
                html += string.Format(
                @"<a href=""{0}"" style=""margin-right: 10px;"">
                    <i class=""fab fa-twitter"" style=""font-size: 28px;""></i>
                  </a>", objDatos.twitter);
            }
            html += @"
                    </div>
                </div>
            </div>
        </div>";




            return html;
        }
    }
}
