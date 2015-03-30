$(document).ready(function () {
    var catagoryId = {
        CatagoryId: $('#Catagory').val()
    };
    if (Catagory.value != "") {
            $.ajax({
                type: "GET",
                url: "http://localhost:52177/Catalog/RetriveCategorySubCatergories",
                data: catagoryId,
                dataType: "json",
                success: function (data) {
                    var iteration = 1;
                    $.each(data, function (idx, obj) {
                        if (iteration == 1) {
                            $(".center-area").append('<div class="first-book front-page-book col-md-4"><h2>' + obj.Name + '</h2><div class="thumbnail-div"><img class="catalog-thumbnail" src="' + obj.ImageUrl + '" /></div><div class="descriptionDiv"><p>' + obj.Description + '</p></div><div><p><a class="btn btn-default" href="mailto:Jay_cooling@yahoo.com">View ' + obj.Name + ' &raquo;</a></p></div></div>');
                        }
                        else {
                            $(".center-area").append('<div class="front-page-book col-md-4"><h2>' + obj.Name + '</h2><div class="thumbnail-div"><img class="catalog-thumbnail" src="' + obj.ImageUrl + '" /></div><div class="descriptionDiv"><p>' + obj.Description + '</p></div><div><p><a class="btn btn-default" href="mailto:Jay_cooling@yahoo.com">View ' + obj.Name + ' &raquo;</a></p></div></div>');
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
