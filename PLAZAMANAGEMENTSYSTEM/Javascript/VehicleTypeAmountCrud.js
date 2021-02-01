$(document).ready(function () {


    $('.closeModal').trigger("click");

    
    $('#saveamount').click(function () {

        $('.closeModal').trigger("click");


        SuccessAlert();

        var object = $('#AmountForVehicleForm').serialize();

        JsonRequest("/AmountForEachVechileType/SaveAmountForEachVechileType", "POST", object, function (data) {

            window.location.href = "/AmountForEachVechileType/Index";
        });

    });



    $('.Edit').click(function () {

        JsonRequest("/AmountForEachVechileType/AmountForEachVechileTypeById", "GET", { Id: $(this).attr('id') }, function (data) {


            //   console.log(data);

            $('#AmId').val(data.AmId);
            $('#EAmount').val(data.Amount);
            $('#vehicleTypeId').val(data.VehicleTypeId);

        });


    });

    $('#updateamount').click(function () {

        JsonRequest("/AmountForEachVechileType/UpdateAmountForEachVechileType", 'POST', {

            AmId: $('#AmId').val(),
            VehicleTypeId: $('#vehicleTypeId').val(),
            Amount: $('#EAmount').val()
        }, function (data) {
            debugger;
            $('.closeModal').trigger("click");
            window.location.href = "/AmountForEachVechileType/Index";

        });

    });


    $(".DeleteVAmount").click(function () {

        SuccessAlert();

        JsonRequest("/AmountForEachVechileType/DeleteAmountForEachVechileType", "POST", { Id: $(this).attr("id") }, function () {
            window.location.href = "/AmountForEachVechileType/Index";

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