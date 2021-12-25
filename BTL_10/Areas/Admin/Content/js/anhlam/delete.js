

function deletetour(id) {
    var jsData = "{Id : '" + id + "'}";
    swal({
        title: "Bạn có chắc muốn xóa ?",
        text: "Sẽ không thể khôi phục lại !!",
        type: "warning",
        showCancelButton: true,
        cancelButtonText: "Hủy",
        confirmButtonColor: "#DD6B55",
        confirmButtonText: "Xóa !!",
        closeOnConfirm: !1
    },
        function (isconfirm) {
            if (isconfirm) {
                $.ajax({
                    type: "POST",
                    url: '/Admin/TOURs/DeleteConfirmed',
                    contentType: "application/json; charset=utf-8",
                    data: jsData,
                    dataType: "json",
                    success: function (result) {
                        if (result == true) {
                            window.location = "/Admin/TOURs/Index";
                        }
                    }
                });
            } else {
                swal("Đã có lỗi xảy ra")
            }
        })
}

function deletedd(id) {
    var jsData = "{Id : '" + id + "'}";
    swal({
        title: "Bạn có chắc muốn xóa ?",
        text: "Sẽ không thể khôi phục lại !!",
        type: "warning",
        showCancelButton: true,
        cancelButtonText: "Hủy",
        confirmButtonColor: "#DD6B55",
        confirmButtonText: "Xóa !!",
        closeOnConfirm: !1
    },
        function (isconfirm) {
            if (isconfirm) {
                $.ajax({
                    type: "POST",
                    url: '/Admin/DIEMTHAMQUANs/DeleteConfirmed',
                    contentType: "application/json; charset=utf-8",
                    data: jsData,
                    dataType: "json",
                    success: function (result) {
                        if (result == true) {
                            window.location = "/Admin/DIEMTHAMQUANs/Index";
                        }
                    }
                });
            } else {
                swal("Đã có lỗi xảy ra")
            }
        })
}


function deleteks(id) {
    var jsData = "{Id : '" + id + "'}";
    swal({
        title: "Bạn có chắc muốn xóa ?",
        text: "Sẽ không thể khôi phục lại !!",
        type: "warning",
        showCancelButton: true,
        cancelButtonText: "Hủy",
        confirmButtonColor: "#DD6B55",
        confirmButtonText: "Xóa !!",
        closeOnConfirm: !1
    },
        function (isconfirm) {
            if (isconfirm) {
                $.ajax({
                    type: "POST",
                    url: '/Admin/KHACHSANs/DeleteConfirmed',
                    contentType: "application/json; charset=utf-8",
                    data: jsData,
                    dataType: "json",
                    success: function (result) {
                        if (result == true) {
                            window.location = "/Admin/KHACHSANs/Index";
                        }
                    }
                });
            } else {
                swal("Đã có lỗi xảy ra")
            }
        })
}

function deletept(id) {
    var jsData = "{Id : '" + id + "'}";
    swal({
        title: "Bạn có chắc muốn xóa ?",
        text: "Sẽ không thể khôi phục lại !!",
        type: "warning",
        showCancelButton: true,
        cancelButtonText: "Hủy",
        confirmButtonColor: "#DD6B55",
        confirmButtonText: "Xóa !!",
        closeOnConfirm: !1
    },
        function (isconfirm) {
            if (isconfirm) {
                $.ajax({
                    type: "POST",
                    url: '/Admin/PHUONGTIENs/DeleteConfirmed',
                    contentType: "application/json; charset=utf-8",
                    data: jsData,
                    dataType: "json",
                    success: function (result) {
                        if (result == true) {
                            window.location = "/Admin/PHUONGTIENs/Index";
                        }
                    }
                });
            } else {
                swal("Đã có lỗi xảy ra")
            }
        })
}

function deletekh(id) {
    var jsData = "{Id : '" + id + "'}";
    swal({
        title: "Bạn có chắc muốn xóa ?",
        text: "Sẽ không thể khôi phục lại !!",
        type: "warning",
        showCancelButton: true,
        cancelButtonText: "Hủy",
        confirmButtonColor: "#DD6B55",
        confirmButtonText: "Xóa !!",
        closeOnConfirm: !1
    },
        function (isconfirm) {
            if (isconfirm) {
                $.ajax({
                    type: "POST",
                    url: '/Admin/KHACHes/DeleteConfirmed',
                    contentType: "application/json; charset=utf-8",
                    data: jsData,
                    dataType: "json",
                    success: function (result) {
                        if (result == true) {
                            window.location = "/Admin/KHACHes/Index";
                        }
                    }
                });
            } else {
                swal("Đã có lỗi xảy ra")
            }
        })
}
