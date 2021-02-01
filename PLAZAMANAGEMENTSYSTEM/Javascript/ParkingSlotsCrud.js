$(document).ready(function () {

    $('.closeModal').trigger("click");

    
    $(".DeleteSlot").click(function () {

        SuccessAlert();

        JsonRequest("/ParkingSlot/DeleteParkingSlot", "POST", { Id: $(this).attr("id") }, function () {
            window.location.href = "/ParkingSlot/Index";

        });


    });







    $("#saveslot").click(function () {

        $('#closeSlotModal').trigger("click");
        SuccessAlert();

        var object = $('#SlotForm').serialize();
        JsonRequest("/ParkingSlot/SaveParkingSlot", "POST", object, function () {

            window.location.href = "/ParkingSlot/Index";
        });

    });


    

    $('.Edit').click(function () {

        JsonRequest("/ParkingSlot/GetParkingSlotById", "GET", { Id: $(this).attr('id') }, function (data) {


            //   console.log(data);

            $('#SlotId').val(data.SlotId);
            $('#ESlotName').val(data.SlotName);
            $('#floorId').val(data.FloorId);

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