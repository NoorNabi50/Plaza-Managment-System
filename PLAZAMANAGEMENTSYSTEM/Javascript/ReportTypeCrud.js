$(document).ready(function () {


    $('.closeModal').trigger("click");


    $("#savereporttype").click(function () {

        $('.closeModal').trigger("click");
        SuccessAlert();

        var object = $('#reportTypeForm').serialize();


        JsonRequest("/ReportType/SaveReportType", "Post", object, function () {

            window.location.href = "/ReportType/Index";


        });

    });




    $('.Edit').click(function () {

        JsonRequest("/ReportType/GetReportTypeById", "GET", { Id: $(this).attr('id') }, function (data) {


            

            $('#ReportTId').val(data.ReportTypeId);
            $('#REName').val(data.ReportName);


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