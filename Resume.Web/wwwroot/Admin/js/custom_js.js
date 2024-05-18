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



function LoadSkillFormModal(id) {
    $.ajax({
        url: "/Admin/Skill/LoadSkillFormModal",
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

            $('#SkillForm').data('validator', null);
            $.validator.unobtrusive.parse("#SkillForm");

            $('#modal-left').modal('show');

        },
        error: function () {
            CloseLoading();
        }
    });
}

function SkillFormSubmited(res) {
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

function DeleteSkill(id) {
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
                url: "/Admin/Skill/DeleteSkill",
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




function LoadPortfolioCategoryFormModal(id) {
    $.ajax({
        url: "/Admin/PortfolioCategory/LoadPortfolioCategoryFormModal",
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

            $('#PortfolioCategoryForm').data('validator', null);
            $.validator.unobtrusive.parse("#PortfolioCategorySkillForm");

            $('#modal-left').modal('show');

        },
        error: function () {
            CloseLoading();
        }
    });
}

function PortfolioCategoryFormSubmited(res) {
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

function DeletePortfolioCategory(id) {
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
                url: "/Admin/PortfolioCategory/DeletePortfolioCategory",
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



function LoadPortfolioFormModal(id) {
    $.ajax({
        url: "/Admin/Portfolio/LoadPortfolioFormModal",
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

            $('#PortfolioForm').data('validator', null);
            $.validator.unobtrusive.parse("#PortfolioSkillForm");

            $('#modal-left').modal('show');

        },
        error: function () {
            CloseLoading();
        }
    });
}

function PortfolioFormSubmited(res) {
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

function DeletePortfolio(id) {
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
                url: "/Admin/Portfolio/DeletePortfolio",
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



function LoadInformationFormModal() {
    $.ajax({
        url: "/Admin/Information/LoadInformationFormModal",
        type: "get",
        data: {
        },
        beforSend: function () {
            StartLoading();
        },
        success: function (res) {
            CloseLoading();

            $("#modal-left-content").html(res);

            $('#InformationForm').data('validator', null);
            $.validator.unobtrusive.parse("#InformationForm");

            $('#modal-left').modal('show');

        },
        error: function () {
            CloseLoading();
        }
    });
}

function InformationFormSubmited(res) {
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


function DeleteMessage(id) {
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
                url: "/Admin/Message/DeleteMessage",
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