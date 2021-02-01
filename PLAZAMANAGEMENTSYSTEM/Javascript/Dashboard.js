$(document).ready(function () {


    $('#Receipt').hide();


    $('#Receipt').click(function () {

        $('#Receipt').hide();



    });


    AjaxRequest("/VehicleInfo/NumberofCarsParked", "GET", null, function (data) {
        debugger;
        $('#carsParked').text(data);
        console.log(data);

      

    });

    AjaxRequest("/VehicleInfo/AmountcollectedForDay", "GET", null, function (data) {

        $('#amountcollected').text(data);
        console.log(data);

       

    });


    AjaxRequest("/ParkingFloors/TotalSpaceAvailable", "GET", null, function (data) {

        $('#soltsAvailable').text(data);
        console.log(data);



    });











    $('.selectpicker').selectpicker({

        liveSearch: true,
        showSubtext: true
    });




   
    $('.closeModal').trigger("click");

    AjaxRequest("/ParkingSlot/GetFloorNameBySlotId", "GET", { Id: $("#SlotId").val() }, function (data) {

        $('#FName').val(data.FloorName);
        $('#floorId').val(data.FloorId);

    });


    AjaxRequest("/AmountForEachVechileType/GetAmountByVehicleType", "GET", { Id: $("#VehicleTypeId").val() }, function (data) {

        $("#VAmount").val(data);

    });



    $("#VehicleTypeId").change(function () {


        AjaxRequest("/AmountForEachVechileType/GetAmountByVehicleType", "GET", { Id: $(this).val() }, function (data) {

            $("#VAmount").val(data);

        });


    });

    $('#saveVinfo').click(function () {
        debugger;
          var object = {
            VehicleNoPlate: $('#VehicleNoPlate').val(),
            Color: $('#Color').val(),
            VehicleTypeId: $('#VehicleTypeId').val(),
            SlotId: $('#SlotId').val(),
            FloorId: parseInt($('#floorId').val()),
            Amount: $('#VAmount').val()
    }
        AjaxRequest("/VehicleInfo/SaveVehicleInfo", "Post", object, function (data) {


            $('#Receipt').show();
             
            $('#VehicleNoPlate').val('');
            $('#Color').val('');
            $('#VAmount').val('');
            $('#floorId').val('');
            $('#VId').val(parseInt(data));
            console.log(data);
            AjaxRequest("/VehicleInfo/NumberofCarsParked", "GET", null, function (data) {

                $('#carsParked').text(data);
                console.log(data);

                
                AjaxRequest("/VehicleInfo/AmountcollectedForDay", "GET", null, function (data) {

                    $('#amountcollected').text(data);
                    console.log(data);


                    AjaxRequest("/ParkingFloors/TotalSpaceAvailable", "GET", null, function (data) {

                        $('#soltsAvailable').text(data);
                        console.log(data);

                      

                    });



                    SavedAlert('Data Saved');

                });

            });
        });


    });


    $("#Receipt").click(function () {
       
        AjaxRequest("/VehicleInfo/Receipt", "GET", { Id: $('#VId').val() }, function (data) {

           
            $(data).printThis();


            console.log(data);
        });
    });
   


    $("#SlotId").change(function () {

        AjaxRequest("/ParkingSlot/GetFloorNameBySlotId", "GET", { Id: $(this).val() }, function (data) {

            $('#FName').val(data.FloorName);

        });

    });



    $("#emailBtn").click(function () {

       
        AjaxRequest("/SendEmail/SendEmail", "POST", {

            email: $('#email').val(),
            message: $("#message").val()


        }, function (data) {

            if (data == 'EmailSent') {

                SavedAlert('Email Sent');


                $('#email').val('');
                $('#message').val('');
            }

        });

    });

    
});


function AjaxRequest(Url, Type, obj = 0, CallBack = 0) {

    $.ajax({
        type: Type,
        url: Url,
        data: obj,
        success: CallBack


    });
       
       
} 

