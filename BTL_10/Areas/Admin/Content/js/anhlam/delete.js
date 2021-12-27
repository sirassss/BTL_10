
//Xóa bảng TOUR
function deletetour(id) {
    var jsData = "{'id' : '" + id + "'}";
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
                            swal("Xóa thành công ","Đã xóa rồi nhé !!","success",);
                            setTimeout(function () {
                                window.location = "/Admin/TOURs/Index";
                            }, 1000);
                            //window.location = "/Admin/TOURs/Index";
                        };
                    }
                });
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
                            swal("Xóa thành công ", "Đã xóa rồi nhé !!", "success",);
                            setTimeout(function () {
                                window.location = "/Admin/DIEMTHAMQUANs/Index";
                            }, 1000);
                            
                        }
                    },
                });
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
                            swal("Xóa thành công ", "Đã xóa rồi nhé !!", "success",);
                            setTimeout(function () {
                                window.location = "/Admin/KHACHSANs/Index";
                            }, 1000);
                            
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
                            swal("Xóa thành công ", "Đã xóa rồi nhé !!", "success",);
                            setTimeout(function () {
                                window.location = "/Admin/PHUONGTIENs/Index";
                            }, 1000);
                            
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
                            swal("Xóa thành công ", "Đã xóa rồi nhé !!", "success",);
                            setTimeout(function () {
                                window.location = "/Admin/HUONGDANVIENs/Index";
                            }, 1000);
                            
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
                            swal("Xóa thành công ", "Đã xóa rồi nhé !!", "success",);
                            setTimeout(function () {
                                window.location = "/Admin/KHACHes/Index";
                            }, 1000);
                            
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
                            swal("Xóa thành công ", "Đã xóa rồi nhé !!", "success",);
                            setTimeout(function () {
                                window.location = "/Admin/ADMINs/Index";
                            }, 1000);
                            
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
                            swal("Xóa thành công ", "Đã xóa rồi nhé !!", "success",);
                            setTimeout(function () {
                                window.location = "/Admin/BLOGs/Index";
                            }, 1000);
                            
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
                            swal("Xóa thành công ", "Đã xóa rồi nhé !!", "success",);
                            setTimeout(function () {
                                window.location = "/Admin/DANHMUCBLOGs/Index";
                            }, 1000);
                            
                        }
                    }
                });
            } else {
                swal("Đã có lỗi xảy ra")
            }
        })
}