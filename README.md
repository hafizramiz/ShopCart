#<!DOCTYPE html>
<html lang="en">
<head>
    <meta charset="utf-8">
    <title>@ViewBag.Title</title>
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <meta name="description" content="">
    <meta name="author" content="">
    <!-- Bootstrap styles -->
    <link href=" ~/Contents/assets/css/bootstrap.css" rel="stylesheet" />
    <!-- Customize styles -->
    <link href="~/Contents/assets/style.css" rel="stylesheet" />
    <!-- font awesome styles -->
    <link href=" ~/Contents/assets/font-awesome/css/font-awesome.css" rel="stylesheet">
    <!--[if IE 7]>
        <link href="css/font-awesome-ie7.min.css" rel="stylesheet">
    <![endif]-->
    <!--[if lt IE 9]>
        <script src="http://html5shim.googlecode.com/svn/trunk/html5.js"></script>
    <![endif]-->
    <!-- Favicons -->
    <link rel="shortcut icon" href=" ~/Contents/assets/ico/favicon.ico">
</head>
<body>
    <!--
        Upper Header Section
    -->
    <div class="navbar navbar-inverse navbar-fixed-top">
        <div class="topNav">
            <div class="container">
                <div class="alignR">
                    <div class="pull-left socialNw">
                        <a href="#"><span class="icon-twitter"></span></a>
                        <a href="#"><span class="icon-facebook"></span></a>
                        <a href="#"><span class="icon-youtube"></span></a>
                        <a href="#"><span class="icon-tumblr"></span></a>
                        <!--
        Iceri giren kullanicinin bilgilerini alma  @HttpContext.Current.User.Identity.Name
        -->
                    </div>
                    <a href="#"><span class="icon-user"></span> Kullanici: @HttpContext.Current.User.Identity.Name</a>
                    <!--  Iceri girmis kullanicinin Log out yapmasi icin gerekli actioni burda belirttim-->
                    <a href="/Guvenlik/LogOut"><span class="icon-signout"></span> Log Out </a>
                </div>
            </div>
        </div>
    </div>

    <!--
    Lower Header Section
    -->
    <div class="container">
        <div id="gototop"> </div>
        <header id="header">
            <div class="row">
                <div class="span4">
                    <h1>
                        <a class="logo" href="index.html">
                            <span>Twitter Bootstrap ecommerce template</span>
                            <img src=" ~/Contents/assets/img/logo-bootstrap-shoping-cart.png" alt="bootstrap sexy shop">
                        </a>
                    </h1>
                </div>
                <div class="span4">
                </div>
            </div>
        </header>
        </div>
        <!--
        Navigation Bar Section
        -->
        <div class="navbar">
            <div class="navbar-inner">
                <div class="container">
                    <a data-target=".nav-collapse" data-toggle="collapse" class="btn btn-navbar">
                        <span class="icon-bar"></span>
                        <span class="icon-bar"></span>
                        <span class="icon-bar"></span>
                    </a>
                    <div class="nav-collapse">
                        <ul class="nav">
                            <li class="active"><a href="index.html">Home	</a></li>
                            <li class=""><a href="list-view.html">List View</a></li>
                            <li class=""><a href="grid-view.html">Grid View</a></li>
                            <li class=""><a href="three-col.html">Three Column</a></li>
                            <li class=""><a href="four-col.html">Four Column</a></li>
                            <li class=""><a href="general.html">General Content</a></li>
                        </ul>
                        
                    </div>
                </div>
            </div>
        </div>

        <!--
        Body Section
        -->
        <div class="row">
            <div id="sidebar" class="span3">
                <div class="well well-small">
                    <ul class="nav nav-list">
                        <li><a href="products.html"><span class="icon-chevron-right"></span>Fashion</a></li>
                        <li><a href="products.html"><span class="icon-chevron-right"></span>Watches</a></li>
                        <li><a href="products.html"><span class="icon-chevron-right"></span>Fine Jewelry</a></li>
                        <li><a href="products.html"><span class="icon-chevron-right"></span>Fashion Jewelry</a></li>
                        <li><a href="products.html"><span class="icon-chevron-right"></span>Engagement & Wedding</a></li>
                        <li><a href="products.html"><span class="icon-chevron-right"></span>Men's Jewelry</a></li>
                        <li><a href="products.html"><span class="icon-chevron-right"></span>Vintage & Antique</a></li>
                        <li><a href="products.html"><span class="icon-chevron-right"></span>Loose Diamonds </a></li>
                        <li><a href="products.html"><span class="icon-chevron-right"></span>Loose Beads</a></li>
                        <li><a href="products.html"><span class="icon-chevron-right"></span>See All Jewelry & Watches</a></li>
                        <li style="border:0"> &nbsp;</li>
                        @if (!User.IsInRole("kullanici"))
                        {
                            <li> <a class="totalInCart" href="cart.html"><strong>Total Amount  <span class="badge badge-warning pull-right" style="line-height:18px;">$448.42</span></strong></a></li>
                        }
                    </ul>
                </div>

                <br>
                <br>
                <ul class="nav nav-list promowrapper">
                    <li>
                        <div class="thumbnail">
                            <a class="zoomTool" href="product_details.html" title="add to cart"><span class="icon-search"></span> QUICK VIEW</a>
                            <img src=" ~/Contents/assets/img/bootstrap-ecommerce-templates.png" alt="bootstrap ecommerce templates">
                            <div class="caption">
                                <h4><a class="defaultBtn" href="product_details.html">VIEW</a> <span class="pull-right">$22.00</span></h4>
                            </div>
                        </div>
                    </li>
                    <li style="border:0"> &nbsp;</li>
                    <li>
                        <div class="thumbnail">
                            <a class="zoomTool" href="product_details.html" title="add to cart"><span class="icon-search"></span> QUICK VIEW</a>
                            <img src=" ~/Contents/assets/img/shopping-cart-template.png" alt="shopping cart template">
                            <div class="caption">
                                <h4><a class="defaultBtn" href="product_details.html">VIEW</a> <span class="pull-right">$22.00</span></h4>
                            </div>
                        </div>
                    </li>
                    <li style="border:0"> &nbsp;</li>
                    <li>
                        <div class="thumbnail">
                            <a class="zoomTool" href="product_details.html" title="add to cart"><span class="icon-search"></span> QUICK VIEW</a>
                            <img src=" ~/Contents/assets/img/bootstrap-template.png" alt="bootstrap template">
                            <div class="caption">
                                <h4><a class="defaultBtn" href="product_details.html">VIEW</a> <span class="pull-right">$22.00</span></h4>
                            </div>
                        </div>
                    </li>
                </ul>

            </div>
            <div class="span9">
                @RenderBody()
                
            </div>
           
        </div><!-- /container -->
