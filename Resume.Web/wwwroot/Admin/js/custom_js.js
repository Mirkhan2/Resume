function StartLoading(element = 'body') {
    $(element).waitMe({
        effect: 'bounce',
        text: 'لطفا صبر کنید ...',
        bg: 'rgba(255, 255, 255, 0.7)',
        color: '#000'
    });
}

function CloseLoading(element = 'body') {
    $(element).waitMe('hide');
}


function LoadThingIDoFormModal(id) {
    $.ajax({
        url: "/Admin/ThingIDo/LoadThingIDoFormModal",
        type: "get",
        data: {
            id: id
        },
        beforSend: function () {
            StartLoading();
        },
        success: function (res) {
            CloseLoading();

            $("#modal-left-content").html(res);

            $('#ThingIDoForm').data('validator', null);
            $.validator.unobtrusive.parse("#ThingIDoForm");

            $('#modal-left').modal('show');

        },
        error: function () {
            CloseLoading();
        }
    });
}

function ThingIDoFormSubmited(res) {
    CloseLoading();

    if (res.status === 'Success') {
        ShowMessage('عملیات با موفقیت انجام شد.', 'پیغام موفقیت', 'success')
        $('#modal-left').modal('hide');
        $('#data-table-box').load(location.href + ' #data-table-box');
        $.getScript('/admin/js/data-table.js', function (data, textStatus, jqxhr) { });
    } else {
        showMessage('عملیات با شکست مواجه شد', 'پیغام خطا', 'error')
    }

}

function DeleteThingIDo(id) {
    swal.fire({
        title: "اخطار",
        text: "آیا از حذف این آیتم اطمینان دارید ؟",
        icon: "warning",
        dangerMode: true,
        showDenyButton: true,
        confirmButtonText: 'حذف',
        denyButtonText: 'خیر'
    }).then((willDelete) => {
        if (willDelete.isConfirmed) {

            $.ajax({
                url: "/Admin/ThingIDo/DeleteThingIDO",
                type: "get",
                data: {
                    id: id
                },
                beforSend: function () {
                    StartLoading();
                },
                success: function (res) {
                    CloseLoading();

                    if (res.status === "Success") {
                        ShowMessage('عملیات با موفقیت انجام شد.', 'پیغام موفقیت', 'success');
                        $(`#ListItem-${id}`).remove();
                    } else {
                        ShowMessage('عملیات با شکست مواجه شد.', 'پیغام خطا', 'error');
                    }

                },
                error: function () {
                    CloseLoading();
                }
            });

        }
    });
}



function LoadEducationFormModal(id) {
    $.ajax({
        url: "/Admin/Education/LoadEducationFormModal",
        type: "get",
        data: {
            id: id
        },
        beforSend: function () {
            StartLoading();
        },
        success: function (res) {
            CloseLoading();

            $("#modal-left-content").html(res);

            $('#EducationForm').data('validator', null);
            $.validator.unobtrusive.parse("#EducationForm");

            $('#modal-left').modal('show');

        },
        error: function () {
            CloseLoading();
        }
    });
}

function EducationFormSubmited(res) {
    CloseLoading();

    if (res.status === 'Success') {
        ShowMessage('عملیات با موفقیت انجام شد.', 'پیغام موفقیت', 'success')
        $('#modal-left').modal('hide');
        $('#data-table-box').load(location.href + ' #data-table-box');
        $.getScript('/admin/js/data-table.js', function (data, textStatus, jqxhr) { });
    } else {
        showMessage('عملیات با شکست مواجه شد', 'پیغام خطا', 'error')
    }

}

function DeleteEducation(id) {
    swal.fire({
        title: "اخطار",
        text: "آیا از حذف این آیتم اطمینان دارید ؟",
        icon: "warning",
        dangerMode: true,
        showDenyButton: true,
        confirmButtonText: 'حذف',
        denyButtonText: 'خیر'
    }).then((willDelete) => {
        if (willDelete.isConfirmed) {

            $.ajax({
                url: "/Admin/Education/DeleteEducation",
                type: "get",
                data: {
                    id: id
                },
                beforSend: function () {
                    StartLoading();
                },
                success: function (res) {
                    CloseLoading();

                    if (res.status === "Success") {
                        ShowMessage('عملیات با موفقیت انجام شد.', 'پیغام موفقیت', 'success');
                        $(`#ListItem-${id}`).remove();
                    } else {
                        ShowMessage('عملیات با شکست مواجه شد.', 'پیغام خطا', 'error');
                    }

                },
                error: function () {
                    CloseLoading();
                }
            });

        }
    });
}


function LoadCustomerFeedbackFormModal(id) {
    $.ajax({
        url: "/Admin/CustomerFeedback/LoadCustomrFeedbackFormModal",
        type: "get",
        data: {
            id: id
        },
        beforSend: function () {
            StartLoading();
        },
        success: function (res) {
            CloseLoading();

            $("#modal-left-content").html(res);

            $('#CustomerFeedbackForm').data('validator', null);
            $.validator.unobtrusive.parse("#CustomerFeedbackForm");

            $('#modal-left').modal('show');

        },
        error: function () {
            CloseLoading();
        }
    });
}

function CustomerFeedbackFormSubmited(res) {
    CloseLoading();

    if (res.status === 'Success') {
        ShowMessage('عملیات با موفقیت انجام شد.', 'پیغام موفقیت', 'success')
        $('#modal-left').modal('hide');
        $('#data-table-box').load(location.href + ' #data-table-box');
        $.getScript('/admin/js/data-table.js', function (data, textStatus, jqxhr) { });
    } else {
        showMessage('عملیات با شکست مواجه شد', 'پیغام خطا', 'error')
    }

}

function DeleteCustomerFeedback(id) {
    swal.fire({
        title: "اخطار",
        text: "آیا از حذف این آیتم اطمینان دارید ؟",
        icon: "warning",
        dangerMode: true,
        showDenyButton: true,
        confirmButtonText: 'حذف',
        denyButtonText: 'خیر'
    }).then((willDelete) => {
        if (willDelete.isConfirmed) {

            $.ajax({
                url: "/Admin/CustomerFeedback/DeleteCustomerFeedback",
                type: "get",
                data: {
                    id: id
                },
                beforSend: function () {
                    StartLoading();
                },
                success: function (res) {
                    CloseLoading();

                    if (res.status === "Success") {
                        ShowMessage('عملیات با موفقیت انجام شد.', 'پیغام موفقیت', 'success');
                        $(`#ListItem-${id}`).remove();
                    } else {
                        ShowMessage('عملیات با شکست مواجه شد.', 'پیغام خطا', 'error');
                    }

                },
                error: function () {
                    CloseLoading();
                }
            });

        }
    });
}