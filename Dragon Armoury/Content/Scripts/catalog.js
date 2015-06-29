$(document).ready(function () {
    var catagoryId = {
        CatagoryId: $('#Catagory').val()
    };  
    var subCatagoryId = {
        SubCatagoryId: $('#SubCatagory').val()
    };
    if (Catagory.value != "" && SubCatagory.value == "0") {
            $.ajax({
                type: "GET",
                url: "http://localhost:52177/Catalog/RetriveCategorySubCatergories",
                data: catagoryId,
                dataType: "json",
                success: function (data) {
                    var iteration = 1;
                    $.each(data, function (idx, obj) {
                        if (iteration == 1) {
                            $(".center-area").append('<div class="first-book front-page-book col-md-4"><h2>' + obj.Name + '</h2><div class="thumbnail-div"><img class="catalog-thumbnail" src="' + obj.ImageUrl + '" /></div><div class="descriptionDiv"><p>' + obj.Description + '</p></div><div><p><a class="btn btn-default" href="http://localhost:52177/Catalog/Catalog?catagoryId=1&subCatagoryId='+ obj.Id +'">View ' + obj.Name + ' &raquo;</a></p></div></div>');
                        }
                        else {
                            $(".center-area").append('<div class="front-page-book col-md-4"><h2>' + obj.Name + '</h2><div class="thumbnail-div"><img class="catalog-thumbnail" src="' + obj.ImageUrl + '" /></div><div class="descriptionDiv"><p>' + obj.Description + '</p></div><div><p><a class="btn btn-default" href="http://localhost:52177/Catalog/Catalog?catagoryId=1&subCatagoryId=' + obj.Id + '">View ' + obj.Name + ' &raquo;</a></p></div></div>');
                        }
                        if (iteration == 3) {
                            iteration = 1;
                        }
                        else {
                            iteration++; 
                        }
                    });
                },
            });
    }
    if (Catagory.value != "" && SubCatagory.value != "" && SubCatagory.value != "0") {
        $.ajax({
            type: "GET",
            url: "http://localhost:52177/Catalog/RetriveSubcategoryProducts?subCatagoryId=" + SubCatagory.value,
            dataType: "json",
            success: function (data) {
                var iteration = 1;
                $.each(data, function (idx, obj) {
                    if (iteration == 1) {
                        $(".center-area").append('<div class="first-book front-page-book col-md-4"><h2>' + obj.Name + '</h2><div class="thumbnail-div"><img class="catalog-thumbnail" src="' + obj.ImageUrl + '" /></div><div class="descriptionDiv"><p>' + obj.Description + '</p></div><div><p><a class="btn btn-default" href="http://localhost:52177/Catalog/Catalog?catagoryId=1&subCatagoryId=' + obj.Id + '">View ' + obj.Name + ' &raquo;</a></p></div></div>');
                    }
                    else {
                        $(".center-area").append('<div class="front-page-book col-md-4"><h2>' + obj.Name + '</h2><div class="thumbnail-div"><img class="catalog-thumbnail" src="' + obj.ImageUrl + '" /></div><div class="descriptionDiv"><p>' + obj.Description + '</p></div><div><p><a class="btn btn-default" href="http://localhost:52177/Catalog/Catalog?catagoryId=1&subCatagoryId=' + obj.Id + '">View ' + obj.Name + ' &raquo;</a></p></div></div>');
                    }
                    if (iteration == 3) {
                        iteration = 1;
                    }
                    else {
                        iteration++;
                    }
                });
            },
        });
    }
});


//<p><div class="actionButton btn btn-default">@Html.ActionLink("Weapons", "Catalog", "Catalog", new { catalogId = 1, }, null)</div></p>
//subCatagoryId = 0
//$(".center-area").append('<div class="first-book front-page-book col-md-4"><h2>' + obj.Name + '</h2><div class="thumbnail-div"><img class="catalog-thumbnail" src="' + obj.ImageUrl + '" /></div><div class="descriptionDiv"><p>' + obj.Description + '</p></div><div><p><div class="actionButton btn btn-default">@Html.ActionLink("Weapons &raquo;", "Catalog", "Catalog", new { catalogId = 1, }, null)</div></p></div></div>');