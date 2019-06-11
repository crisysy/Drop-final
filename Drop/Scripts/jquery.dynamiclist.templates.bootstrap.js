/// <reference path="jquery.dynamiclist.js"/>

(function(jQuery)
{
    //
    // plugin defaults
    //
    jQuery.fn.dynamiclist.defaults.templates = {
        table: {
            container: "<div class='dynamic-list-container'><\/div>",
            addItem: "<div class=\"add-item-container\"><button class=\"add-item btn btn-default\"><span class='glyphicon glyphicon-plus'><\/span>{addLabel}<\/button><\/div>",
            removeItem: "<button type=\"button\" class=\"delete-item btn btn-danger\"><span class=\"glyphicon glyphicon-remove\"><\/span>{removeLabel}</button>"
        },
        list: {
            container: "<div class='dynamic-list-container'><\/div>",
            addItem: "<li class=\"add-item-container\"><button class=\"add-item btn btn-default\"><span class='glyphicon glyphicon-plus'><\/span>{addLabel}<\/button><\/li>",
            removeItem: "<button type=\"button\" class=\"delete-item btn btn-danger\"><span class=\"glyphicon glyphicon-remove\"><\/span>{removeLabel}</button>"
        },
        div: {
            container: "<div class='dynamic-list-container'><\/div>",
            addItem: "<div class=\"add-item-container row\"><button class=\"add-item btn btn-default\"><span class='glyphicon glyphicon-plus'><\/span>{addLabel}<\/button><\/div>",
            removeItem: "<div class=\"row\"><button type=\"button\" class=\"delete-item btn btn-danger pull-right\"><span class=\"glyphicon glyphicon-remove\"><\/span>{removeLabel}</button><\/div>"
        }
    };
})(jQuery);