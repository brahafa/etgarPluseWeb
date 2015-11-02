
var images = [];
images[0] = "../images/1.png";
images[1] = "../images/2.png";
images[2] = "../images/3.png";
//images[3] = "http://i1.ytimg.com/vi/XzFmOKNf8sc/default.jpg";
//images[4] = "http://i2.ytimg.com/vi/-2m1e4g2MFM/default.jpg";
//images[5] = "http://i1.ytimg.com/vi/lK2TSYBh7fw/default.jpg";

var i = -1;
setInterval(fadeDivs, 10000);

function fadeDivs() {
        if (i <= (images.length-1)) {
            i++;
        }
        else {
            i = 0;
        }
        // i = i < images.length ? i : 0;
        $('.MainImage').fadeOut(1590, function () {
            $(this).attr('src', images[i]).fadeIn(1000);
        })
    
}

function openProperties(bikeId) {
    document.getElementById('left_column_Body_properties').style.display = 'block';
    document.getElementById('left_column_Body_fade').style.display = 'block';
}
function closeProperties() {
    document.getElementById('left_column_Body_properties').style.display = 'none';
    document.getElementById('left_column_Body_fade').style.display = 'none';
    $("#bikeId").val("-1");
}

function openAddToList(bikeId) {
    document.getElementById('left_column_Body_addTOBasket').style.display = 'block';
    document.getElementById('left_column_Body_fade2').style.display = 'block';
}
function closeAddToList() {
    document.getElementById('left_column_Body_properties').style.display = 'none';
    document.getElementById('left_column_Body_fade').style.display = 'none';
    document.getElementById('left_column_Body_addTOBasket').style.display = 'none';
    document.getElementById('left_column_Body_fade2').style.display = 'none';
    $("#bikeId").val("-1");
}

function closeAll() {

    if (document.getElementById('left_column_Body_newListBikeDiv').style.display == 'block') {


        document.getElementById('left_column_Body_sendSucsses').style.display = 'none';
        document.getElementById('left_column_Body_newListBikeDiv').style.display = 'none';
        document.getElementById('left_column_Body_fade').style.display = 'none';
        location.reload();
    }
    else {
        document.getElementById('left_column_Body_sendSucsses').style.display = 'none';
        document.getElementById('left_column_Body_newListBikeDiv').style.display = 'none';
        document.getElementById('left_column_Body_fade').style.display = 'none';
    }
}

function setBikeID(id) {
    $("#left_column_Body_bikeId").val(id);
}

$(document).ready(function () {
    $(".StatusButton").click(function () {
        var id = ($(this).attr("id")).split("_")[5];
        var idLevel = ($(this).attr("id")).split("_")[4] + "_" + ($(this).attr("id")).split("_")[5];
        var level = $("#left_column_Body_LevelStatus_" + idLevel).val();
        if (level == "-1") {
            alert("יש לבחור דרגה");
            return;
        }
        console.log("client id: " + id + ", new status: " + level);
        console.log(id + ',' + level);
        $.ajax({

            type: "POST",
            url: "ManagerPage.aspx/updateLevelAndStatus",
            data: '{idLevel: "' + id + ',' + level + '" }',
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            success: function (data) {
                location.reload();
            },
            failure: function (response) {
            }
        });
    });
});
//////////submit update producer/////////////
$(document).ready(function () {
    $("#left_column_Body_DeleteProducer").click(function () {
        var selected = $("#left_column_Body_selected_producer").val();
        var elseproduce = $("#left_column_Body_elseProducer").val();
        if (selected == "-2") {

            $.ajax({

                type: "POST",
                url: "ManagerPage.aspx/updateProd",
                data: '{param: "' + elseproduce + '" }',
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: function (data) {
                    alert(data.d + " הוסף בהצלחה");
                    location.reload();
                },
                failure: function (response) {
                }
            });
        }
        else {
            var selected = $("#left_column_Body_selected_producer").val();
            $.ajax({

                type: "POST",
                url: "ManagerPage.aspx/deleteProd",
                data: '{param: "' + selected + '" }',
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: function (data) {
                    //alert(data.d + "נמחק בהצלחה");
                    location.reload();
                },
                failure: function (response) {
                }
            });
        }
    });
});
/////////// submit update Category///////////////

$(document).ready(function () {
    $("#left_column_Body_DeleteelseCategory").click(function () {
        var selected = $("#left_column_Body_selected_Category").val();
        var elseCategory = $("#left_column_Body_elseCategory").val();
        if (selected == "-2") {

            $.ajax({

                type: "POST",
                url: "ManagerPage.aspx/updateCategory",
                data: '{param: "' + elseCategory + '" }',
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: function (data) {
                    alert(data.d + " הוסף בהצלחה");
                    location.reload();
                },
                failure: function (response) {
                }
            });
        }
        else {
            var selected = $("#left_column_Body_selected_Category").val();
            $.ajax({

                type: "POST",
                url: "ManagerPage.aspx/deleteCategort",
                data: '{param: "' + selected + '" }',
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: function (data) {
                    //alert(data.d + "נמחק בהצלחה");
                    location.reload();
                },
                failure: function (response) {
                }
            });
        }
    });
});
/////////// submit update subCategory///////////////

$(document).ready(function () {
    $("#left_column_Body_DeleteElseSubCategory").click(function () {
        var selected = $("#left_column_Body_selected_SubCategory").val();
        var elseSubCategory = $("#left_column_Body_elseSubCategory").val();
        if (selected == "-2") {

            $.ajax({

                type: "POST",
                url: "ManagerPage.aspx/updateSubCategory",
                data: '{param: "' + elseSubCategory + '" }',
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: function (data) {
                    alert(data.d + " הוסף בהצלחה");
                    location.reload();
                },
                failure: function (response) {
                }
            });
        }
        else {
            var selected = $("#left_column_Body_selected_SubCategory").val();
            $.ajax({

                type: "POST",
                url: "ManagerPage.aspx/deleteSubCategort",
                data: '{param: "' + selected + '" }',
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: function (data) {
                    //alert(data.d + "נמחק בהצלחה");
                    location.reload();
                },
                failure: function (response) {
                }
            });
        }
    });
});

/////////// submit update size///////////////
$(document).ready(function () {
    $("#left_column_Body_DeleteElseSize").click(function () {
        var selected = $("#left_column_Body_selected_Size").val();
        var elseSubCategory = $("#left_column_Body_elseSize").val();
        if (selected == "-2") {

            $.ajax({

                type: "POST",
                url: "ManagerPage.aspx/updateSize",
                data: '{param: "' + elseSubCategory + '" }',
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: function (data) {
                    alert(data.d + " הוסף בהצלחה");
                    location.reload();
                },
                failure: function (response) {
                }
            });
        }
        else {
            var selected = $("#left_column_Body_selected_Size").val();
            $.ajax({

                type: "POST",
                url: "ManagerPage.aspx/deleteSize",
                data: '{param: "' + selected + '" }',
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: function (data) {
                    //alert(data.d + "נמחק בהצלחה");
                    location.reload();
                },
                failure: function (response) {
                }
            });
        }
    });
});
/////////// submit update color///////////////
$(document).ready(function () {
    $("#left_column_Body_DeleteElseColor").click(function () {
        var selected = $("#left_column_Body_selected_Color").val();
        var elseSubCategory = $("#left_column_Body_elseColor").val();
        if (selected == "-2") {

            $.ajax({

                type: "POST",
                url: "ManagerPage.aspx/updateColor",
                data: '{param: "' + elseSubCategory + '" }',
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: function (data) {
                    alert(data.d + " הוסף בהצלחה");
                    location.reload();
                },
                failure: function (response) {
                }
            });
        }
        else {
            var selected = $("#left_column_Body_selected_Color").val();
            $.ajax({

                type: "POST",
                url: "ManagerPage.aspx/deleteColor",
                data: '{param: "' + selected + '" }',
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: function (data) {
                    //alert(data.d + "נמחק בהצלחה");
                    location.reload();
                },
                failure: function (response) {
                }
            });
        }
    });
});
///////////////////////////////////////////////////////////////////////////////////////////////////
$(document).ready(function () {
    $("#left_column_Body_selected_producer").change(function () {
        if ($("#left_column_Body_selected_producer").val() == '-2') {
            document.getElementById('left_column_Body_elseProducer').style.display = 'inline';
            $('#left_column_Body_DeleteProducer').val("הוסף");
        }
        else {
            document.getElementById('left_column_Body_elseProducer').style.display = 'none';
            $('#left_column_Body_DeleteProducer').val("מחק");
        }
    });
});


$(document).ready(function () {
    $("#left_column_Body_selected_Category").change(function () {
        if ($("#left_column_Body_selected_Category").val() == '-2') {
            document.getElementById('left_column_Body_elseCategory').style.display = 'inline';
            $('#left_column_Body_DeleteelseCategory').val("הוסף");
        }
        else {
            document.getElementById('left_column_Body_elseCategory').style.display = 'none';
            $('#left_column_Body_DeleteelseCategory').val("מחק");
        }
    });
});
$(document).ready(function () {
    $("#left_column_Body_selected_SubCategory").change(function () {
        if ($("#left_column_Body_selected_SubCategory").val() == '-2') {
            document.getElementById('left_column_Body_elseSubCategory').style.display = 'inline';
            $('#left_column_Body_DeleteElseSubCategory').val("הוסף");
        }
        else {
            document.getElementById('left_column_Body_elseSubCategory').style.display = 'none';
            $('#left_column_Body_DeleteElseSubCategory').val("מחק");
        }
    });
});
$(document).ready(function () {
    $("#left_column_Body_selected_Size").change(function () {
        if ($("#left_column_Body_selected_Size").val() == '-2') {
            document.getElementById('left_column_Body_elseSize').style.display = 'inline';
            $('#left_column_Body_DeleteElseSize').val("הוסף");
        }
        else {
            document.getElementById('left_column_Body_elseSize').style.display = 'none';
            $('#left_column_Body_DeleteElseSize').val("מחק");
        }
    });
});
$(document).ready(function () {
    $("#left_column_Body_selected_Color").change(function () {
        if ($("#left_column_Body_selected_Color").val() == '-2') {
            document.getElementById('left_column_Body_elseColor').style.display = 'inline';
            $('#left_column_Body_DeleteElseColor').val("הוסף");
        }
        else {
            document.getElementById('left_column_Body_elseColor').style.display = 'none';
            $('#left_column_Body_DeleteElseColor').val("מחק");
        }
    });
});
///////////////////////////////////////////////////////////////////
$(document).ready(function () {
    $("#ViewAllClientButton").click(function () {
        document.getElementById('left_column_Body_allClientDiv').style.display = 'inline';
        document.getElementById('left_column_Body_newClientDiv').style.display = 'none';
        document.getElementById('ViewAllClientButton').style.display = 'none';
        document.getElementById('ViewNewClientButton').style.display = 'inline';
        document.getElementById('left_column_Body_UpdateDiv').style.display = 'none';
        document.getElementById('left_column_Body_allProductDiv').style.display = 'none';
    });
});
$(document).ready(function () {
    $("#ViewNewClientButton").click(function () {
        document.getElementById('left_column_Body_newClientDiv').style.display = 'inline';
        document.getElementById('left_column_Body_allClientDiv').style.display = 'none';
        document.getElementById('ViewAllClientButton').style.display = 'inline';
        document.getElementById('ViewNewClientButton').style.display = 'none';
        document.getElementById('left_column_Body_UpdateDiv').style.display = 'none';
        document.getElementById('left_column_Body_allProductDiv').style.display = 'none';
    });
});
$(document).ready(function () {
    $("#ViewUpdateButton").click(function () {
        document.getElementById('left_column_Body_UpdateDiv').style.display = 'inline';
        document.getElementById('left_column_Body_newClientDiv').style.display = 'none';
        document.getElementById('left_column_Body_allClientDiv').style.display = 'none';
        document.getElementById('left_column_Body_allProductDiv').style.display = 'none';

    });
});

$(document).ready(function () {
    $("#ViewAllproductButton").click(function () {
        document.getElementById('left_column_Body_allProductDiv').style.display = 'inline';
        document.getElementById('left_column_Body_UpdateDiv').style.display = 'none';
        document.getElementById('left_column_Body_newClientDiv').style.display = 'none';
        document.getElementById('left_column_Body_allClientDiv').style.display = 'none';

    });
});


$(document).ready(function () {
    $("#left_column_Body_FromPriceInput").focusout(function () {
        if (isNaN($(this).val())) // this is the code I need to change
        {
            alert("יש למלא ספרות בלבד");
            $(this).focus();
        }
    });
});
$(document).ready(function () {
    $("#left_column_Body_ToPriceInput").focusout(function () {
        if (isNaN($(this).val())) // this is the code I need to change
        {
            alert("יש למלא ספרות בלבד");
            $(this).focus();
        }
    });
});

$(document).ready(function () {
    $("#left_column_Body_addButton").click(function () {
        if (isNaN($("#left_column_Body_selectQuantity").val())) // this is the code I need to change
        {
            alert("יש לבחור כמות");

        }
    });
});


$(document).ready(function () {
    $(".AccountField").focus(function () {
        $(this).blur();
    });
});