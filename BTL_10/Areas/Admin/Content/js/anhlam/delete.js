
//Xóa bảng TOUR
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
//Xóa bảng DIEMTHAMQUAN
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

//Xóa bảng KHACHSAN
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
//Xóa bảng PHUONGTIEN
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

//Xóa bảng HDV
function deletehdv(id) {
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
                    url: '/Admin/HUONGDANVIENs/DeleteConfirmed',
                    contentType: "application/json; charset=utf-8",
                    data: jsData,
                    dataType: "json",
                    success: function (result) {
                        if (result == true) {
                            window.location = "/Admin/HUONGDANVIENs/Index";
                        }
                    }
                });
            } else {
                swal("Đã có lỗi xảy ra")
            }
        })
}

//Xóa bảng kHACHHANG
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

//Xóa bảng ADMIN
function deletead(id) {
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
                    url: '/Admin/ADMINs/DeleteConfirmed',
                    contentType: "application/json; charset=utf-8",
                    data: jsData,
                    dataType: "json",
                    success: function (result) {
                        if (result == true) {
                            window.location = "/Admin/ADMINs/Index";
                        }
                    }
                });
            } else {
                swal("Đã có lỗi xảy ra")
            }
        })
}

//Xóa bảng BLOG
function deletebl(id) {
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
                    url: '/Admin/BLOGs/DeleteConfirmed',
                    contentType: "application/json; charset=utf-8",
                    data: jsData,
                    dataType: "json",
                    success: function (result) {
                        if (result == true) {
                            window.location = "/Admin/BLOGs/Index";
                        }
                    }
                });
            } else {
                swal("Đã có lỗi xảy ra")
            }
        })
}

//Xóa bảng DANHMUCBLOG
function deletedmbl(id) {
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
                    url: '/Admin/DANHMUCBLOGs/DeleteConfirmed',
                    contentType: "application/json; charset=utf-8",
                    data: jsData,
                    dataType: "json",
                    success: function (result) {
                        if (result == true) {
                            window.location = "/Admin/DANHMUCBLOGs/Index";
                        }
                    }
                });
            } else {
                swal("Đã có lỗi xảy ra")
            }
        })
}