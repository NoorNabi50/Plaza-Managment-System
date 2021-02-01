$(document).ready(function () {


    $('.closeModal').trigger("click");


    $("#savetype").click(function () {

        $('.closeModal').trigger("click");
        SuccessAlert();

        var object = $('#vehicleTypeForm').serialize();


        JsonRequest("/VehicleType/SaveVehicleType", "Post", object, function () {

            window.location.href = "/VehicleType/Index";


        });

    });








    $(".TypeDelete").click(function () {


          SuccessAlert();

        JsonRequest("/VehicleType/DeleteVehicleType", "POST", { Id: $(this).attr("id") }, function () {
            window.location.href = "/VehicleType/Index";

        });


    });
    
    $('.Edit').click(function () {

        JsonRequest("/VehicleType/GetVehicleTypeById", "GET", { Id: $(this).attr('id') }, function (data) {


            $('#ETypeName').val(data.TypeName);
            $('#VtypeId').val(data.VehicleTypeId);



        });


    });

    $('#updatetype').click(function () {

        JsonRequest("/VehicleType/UpdateVehicleType", 'POST', { VehicleTypeId: $('#VtypeId').val(), TypeName: $('#ETypeName').val() }, function (data) {

            window.location.href = "/VehicleType/Index";

        });

    });






});


function JsonRequest(Url, Type, obj = 0, CallBack = 0) {
    $.ajax({
        type: Type,
        url: Url,
        data: obj,
        success: CallBack


    });


} 