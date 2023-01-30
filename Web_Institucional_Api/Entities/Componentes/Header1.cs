namespace Web_Institucional_Api.Entities.Componentes
{
    public class Header1
    {
        public static string read(int idSitio)
        {
            Entities.Institucional objDatos = Entities.Institucional.getByPk(idSitio);
            List<Entities.Menu> lstMenu = Entities.Menu.readActivos(0, idSitio);
            string destino = string.Empty;
            string html =
        @"<header class=""main-header-two clearfix"">
            <div class=""main-header-two__top"">
                <div class=""container"">
                    <div class=""main-header-two__top-inner"">
                        <div class=""main-header-two__top-left"">
                            <p class=""main-header-two__top-left-text""></p>
                        </div>
                        <div class=""main-header-two__top-right"">
                            <div class=""main-header-two__top-social"">";
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
            <div class=""main-header-two__middle"">
                <div class=""container"">
                    <div class=""main-header-two__middle-inner clearfix"">
                        <div class=""main-header-two__shape-1""></div>
                        <div class=""main-header-two__shape-2""></div>
                        <div class=""main-header-two__shape-3""></div>
                        <div class=""main-header-two__shape-4""></div>
                        <div class=""main-header-two__shape-5""></div>
                        <div class=""main-header-two__shape-6""></div>
                        <div class=""main-header-two__shape-7""></div>
                        <div class=""main-header-two__logo"">
                            <a href=""index.html"">
                                <img src=""img/{0}"" alt="""">
                            </a>
                        </div>
                        <div class=""main-header-two__address"">
                            <ul class=""list-unstyled main-header-two__address-list"">", objDatos.logo);
            List<Entities.AccionesPrincipales> lstAcciones = Entities.AccionesPrincipales.read(idSitio);
            for (int i = 0; i < 3; i++)
            {
                html += string.Format(
        @"
                <li>
                    <div class=""icon"">
                        <span class=""{0}"" style=""font-size: 36px;""></span>
                    </div>
                    <div class=""content"" style=""top: 0px !important;"">
                        <h5 style=""margin-top: 15px;"">
                            <a href=""{1}"" target=""{2}"">
                                <span>{3}</span>
                            </a>
                        </h5>
                    </div>
                </li>
                ", lstAcciones[i].icono, lstAcciones[i].callToActionLink, lstAcciones[i].callToActionTarget,
                    lstAcciones[i].titulo);
            }
            html +=
            @"
                            </ul>
                        </div>
                    </div>
                </div>
            </div>
            <nav class=""main-menu main-menu-two clearfix"">
                <div class=""main-menu-two__wrapper clearfix"">
                    <div class=""container"">
                        <div class=""main-menu-two__wrapper-inner clearfix"">
                            <div class=""main-menu-two__wrapper-inner-bg""></div>
                            <div class=""main-menu-two__left""></div>
                            <div class=""main-menu-two__right"">
                                <div class=""main-menu-two__main-menu-box"">
                                    <a href=""#"" class=""mobile-nav__toggler"">
                                        <i class=""fa fa-bars""></i>
                                    </a>
                                    <ul class=""main-menu__list one-page-scroll-menu"">";
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
            html +=
            string.Format(@"
                                    </ul>
                                </div>
                            </div>
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
<<<<<<< HEAD
                <div class=""mobile-nav__container"">
=======
                <div class=""mobile-nav__container""> 
>>>>>>> 4ebcfeba3d024e9118f551d7b5836e69a31e21ab
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

<<<<<<< HEAD
            html += @"</div>
=======
            html += @"</ul></div>
>>>>>>> 4ebcfeba3d024e9118f551d7b5836e69a31e21ab
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
