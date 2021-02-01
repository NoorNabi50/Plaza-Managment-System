$(document).ready(function () {




    $('.ReportBtn').click(function () {

        obj = {

            FromDate: $('#Fromdate').val(),
            ToDate: $('#Todate').val(),
            ReportTypeId: $('#ReportTypeId').val()
        }

        JsonRequest("/GenerateReport/GenerateReport", "GET", obj, function (data) {
           
            $(data).printThis();

            $("input[type=date]").val("");
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