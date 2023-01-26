namespace Web_Institucional_Api.Entities.Componentes
{
    public class Header1
    {
        public static string read(int idSitio)
        {
            Entities.Institucional objDatos = Entities.Institucional.getByPk(idSitio);
            string html =
        @"<div id=""headerPC"">
        <header class=""main-header-two clearfix"" style=""margin-top: 0px; height: 233px;"">
            <div class=""main-header-two__top"" style=""background-color: transparent; height: 40px;"">
                <div class=""container"" style=""padding-top: 0px;"">
                    <div class=""main-header-two__top-inner"">
                        <div class=""main-header-two__top-left"">
                            <p class=""main-header-two__top-left-text""></p>
                        </div>
                        <div class=""main-header-two__top-right"">
                            <div class=""main-header-two__top-social"">";
            if (objDatos.facebook != string.Empty)
            {
                html += string.Format(
                @"<a href=""{0}"" style=""margin-right: 10px;"">
                    <i class=""fab fa-facebook-square"" style=""font-size: 28px;""></i>
                  </a>", objDatos.facebook);
            }
            if (objDatos.instagram != string.Empty)
            {
                html += string.Format(
                @"<a href=""{0}"" style=""margin-right: 10px;"">
                    <i class=""fab fa-instagram"" style=""font-size: 28px;""></i>
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
            <div class=""main-header-two__middle""
                style=""background-color: var(--roofsie-blanco); height: 103px;"">
                <div class=""container"" style=""padding-top: 0px; padding-bottom: 0px;"">
                    <div class=""main-header-two__middle-inner clearfix"">
                        <div class=""main-header-two__shape-1"" style=""border-top: 144px solid rgb(15, 153, 202);""></div>
                        <div class=""main-header-two__shape-2"" style=""border-top: 96px solid var(--roofsie-white);""></div>
                        <div class=""main-header-two__shape-3""></div>
                        <div class=""main-header-two__shape-4"" style=""background-color: var(--roofsie-base);""></div>
                        <div class=""main-header-two__shape-5""></div>
                        <div class=""main-header-two__shape-6"" style=""border-bottom: 93px solid var(--roofsie-white);""></div>
                        <div class=""main-header-two__shape-7""></div>
                        <div class=""main-header-two__logo"">
                            <a href=""index.html"">
                                <img src=""img/{0}"" alt="""">
                            </a>
                        </div>
                        <div class=""main-header-two__address"">
                            <ul class=""list-unstyled main-header-two__address-list"">", objDatos.logo);
            List<Entities.AccionesPrincipales> lstAcciones = Entities.AccionesPrincipales.read(idSitio);
            for (int i = 0; i < 4; i++)
            {
                html += string.Format(
        @"
                <li>
                    <div class=""icon"" style=""top: 14px;"">
                        <span class=""{0}"" style=""font-size: 36px; color: var(--roofsie-white);""></span>
                    </div>
                    <div class=""content"" style=""top: 0px !important;"">
                        <h5 style=""margin-top: 15px;"">
                            <a href=""{1}"" target=""{2}"">
                                <span>Guia de <br> Tramites</span>
                            </a>
                        </h5>
                    </div>
                </li>
                ", lstAcciones[i].icono, lstAcciones[i].callToActionLink, lstAcciones[i].callToActionTarget);
            }
            html +=
            @"
                            </ul>
                        </div>
                    </div>
                </div>
            </div>
            <nav class=""main-menu main-menu-two clearfix"" style=""height: 90px;"">
                <div class=""main-menu-two__wrapper clearfix"" style=""height: 90px;"">
                    <div class=""container"" style=""padding-top: 0px;"">
                        <div class=""main-menu-two__wrapper-inner clearfix"" 
                            style=""min-height: 90px; max-height: 90px; background-color: var(--roofsie-base);"">
                            <div class=""main-menu-two__wrapper-inner-bg"" style=""background-color: var(--roofsie-base);""></div>
                            <div class=""main-menu-two__left""></div>
                            <div class=""main-menu-two__right"" style=""height: 90px;"">
                                <div class=""main-menu-two__main-menu-box"">
                                    <a href=""#"" class=""mobile-nav__toggler"">
                                        <i class=""fa fa-bars""></i>
                                    </a>
                                    <ul class=""main-menu__list one-page-scroll-menu"">";

            List<Entities.Menu> lstMenu = Entities.Menu.readActivos(0, idSitio);
            foreach (Entities.Menu menu in lstMenu)
            {
                string destino = string.Empty;
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
                        ",destino, item._target, item.texto);
                    }
                    html += @"</ul>
                         </li>";
                }
                if (menu.tipo == 1)
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
            @"
                                    </ul>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </nav>
        </header>  
        </div>
            ";

            html += string.Format(@"
    <div id=""headerPC"">  
        <header class=""main-header-two clearfix"" style=""margin-top: 0px; height: 150px;"">
            <div class="""" style=""background-color: var(--roofsie-blanco); height: 103px;"">
                <div class=""container"" style=""padding-top: 20px; padding-bottom: 0px; text-align: center; display: block;"">
                    <a href=""/"">
                        <img src=""img/"" alt="""">
                    </a>
                </div>
            </div>
            <nav class=""main-menu main-menu-two clearfix"" style=""margin-top: -130px;"">
                <div class=""main-menu-two__wrapper clearfix"" style="""">
                    <div class=""main-menu-two__right"" style=""margin-right: 20px;"">
                        <div class=""main-menu-two__main-menu-box"" style="""">
                            <a href=""#"" class=""mobile-nav__toggler"">
                                <i class=""fa fa-bars""></i>
                            </a>
                        </div>
                    </div>
                </div>
            </nav>
        </header>

            ", );

            /*

        
            
                




        <aside class=""v-navigation-drawer v-navigation-drawer--absolute v-navigation-drawer--is-mobile
                v-navigation-drawer--open v-navigation-drawer--temporary theme--light""
               data-booted=""true"" style=""height: 100vh; top: 0px; transform: translateX(0%);
                width: 286px; z-index: 2000; position: fixed;"">
            <div class=""v-navigation-drawer__content"">
                <div role=""list"" class=""v-list v-sheet theme--light"">
                    <div class=""v-list-group"" style=""font-size: 16px !important;"">
                        <div tabindex=""0"" aria-expanded=""false"" role=""button""
                             class=""v-list-group__header v-list-item v-list-item--link theme--light"">
                            <div class=""v-list-item__icon v-list-group__header__prepend-icon"">
                                <i aria-hidden=""true"" class=""v-icon notranslate fa fa fa fa-chevron-down theme--light""></i>
                            </div>
                            <div class=""v-list-item__title"">Ciudad</div>
                            <div class=""v-list-item__icon v-list-group__header__append-icon"">
                                <i aria-hidden=""true"" class=""v-icon notranslate mdi mdi-chevron-down theme--light""></i>
                            </div>
                        </div>
                        <div class=""v-list-group__items"" style=""display: none;"">
                            <div class=""v-list-group v-list-group--no-action v-list-group--sub-group"">
                                <div tabindex=""0"" aria-expanded=""false"" role=""button""
                                     class=""v-list-group__header v-list-item v-list-item--link theme--light"">
                                    <div class=""v-list-item__icon v-list-group__header__prepend-icon"">
                                        <i aria-hidden=""true"" class=""v-icon notranslate mdi mdi-menu-down theme--light""></i>
                                    </div>
                                    <div class=""v-list-item__content"">
                                        <div class=""v-list-item__title"">
                                            <a target="""" href=""/Page/4"">Historia</a>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                    <hr role=""separator"" aria-orientation=""horizontal"" class=""v-divider theme--light"">
                    <div tabindex=""-1"" role=""listitem"" class=""v-list-item theme--light"">
                        <div class=""v-list-item__icon"">
                            <i aria-hidden=""true"" class=""v-icon notranslate fa fa-chevron-right material-icons theme--light""></i>
                        </div>
                        <div class=""v-list-item__content"">
                            <div class=""v-list-item__title"">
                                <a target=""_self"" href=""/#services"">Noticias</a>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
            <div class=""v-navigation-drawer__border""></div>
        </aside>
    </div>
             */


            return html;
        }
    }
}
