
(function () {

    //var main = $('main');

    //main.onmouseenter = function () {

    //    main.style = "background-color: #eee;";
    //}

    //main.onmouseleave = function () {

    //    main.style = "";
    //}

    //var menuItems = $("ul.menu li a");
    //menuItems.on("click", function () {
    //    var el = $(this);
    //    alert(el.text());
    //});

    var sidebarAndWrapper = $('#sidebar,#wrapper');
    var toggled = false;
    $("#sideBarToggle").on("click", function () {

        
        sidebarAndWrapper.toggleClass("hide-sidebar");
        toggled = !toggled;
        if (toggled) {
            $(this).removeClass('fa fa-toggle-on');
            $(this).addClass('fa fa-toggle-off');
        }
        else {
            $(this).removeClass('fa fa-toggle-off');
            $(this).addClass('fa fa-toggle-on');
          
        }
    });
})();
