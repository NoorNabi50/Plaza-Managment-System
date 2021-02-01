$(document).ready(function () {

    $('.closeModal').trigger("click");

    $("#savefloor").click(function () {
        $('#closeFloorModal').trigger("click");
        SuccessAlert();
       
        var object = $('#SaveFloorForm').serialize();

        JsonRequest("/ParkingFloors/SaveParkingFloors", "POST", object, function () {

            window.location.href = "/ParkingFloors/Index";
        });

    });
    
    $(".DeleteFloor").click(function () {

      
        SuccessAlert();

        JsonRequest("/ParkingFloors/DeleteParkingFloors", "POST", { Id: $(this).attr("id") }, function () {
            window.location.href = "/ParkingFloors/Index";

        });


    });



    $('.Edit').click(function () {

        JsonRequest("/ParkingFloors/GetParkingFloorById", "GET", { Id: $(this).attr('id') }, function (data) {


            $('#FNameE').val(data.FloorName);
            $('#FloorId').val(data.FloorId);
            console.log(data.FloorId);
            $('#TotalSpaceE').val(data.TotalSpace);



        });


    });



    



    $('#updatefloor').click(function () {
        console.log($('#FloorId').val());
       
        JsonRequest("/ParkingFloors/UpdateParkingFloor", 'POST', {


            FloorId: $('#FloorId').val(),
            TotalSpace: $('#TotalSpaceE').val(),
            FloorName: $('#FNameE').val()


        }, function (data) {
            $('.closeModal').trigger("click");
            JsonRequest("/ParkingFloors/List", 'GET', null, function (data) {

                $('.myFloorbody').empty();
                
                var html;
                $(data).each(function (i, elem) {

                    html += '<tr><td>' + elem.FloorName + '</td><td>' + elem.TotalSpace + '</td><td><div class="row"><div class="col-md-6"><span style="color:white" class="Edit text-blue cpointer" data-toggle="modal" data-target="#UpdateFloorForm" id="' + elem.FloorId + '"><i class="icon-pencil7"></i></span><span class="DeleteFloor text-danger cpointer" id="' + elem.FloorId + '"><i class="icon-trash"></i></span></div></div></td></tr >';



                });
                $('.myFloorbody').append(html);
                SuccessAlert();
            })

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