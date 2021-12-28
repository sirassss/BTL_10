function dangnhap() {
    var name = document.querySelector('#username');
    var pass = document.querySelector('#password');

    var datatk = "{'username' : '" + name.value + "', 'password' :'" + pass.value + "'}";

    if (!pass.value && !name.value) {
        toastr.error(
            "Đã nhập cái gì đâu bé -.-!!",
            "Lỗi nè",
            {
                positionClass: "toast-top-right",
                timeOut: 5e3,
                closeButton: !0,
                debug: !1,
                newestOnTop: !0,
                progressBar: !0,
                preventDuplicates: !0,
                onclick: null,
                showDuration: "300",
                hideDuration: "1000",
                extendedTimeOut: "1000",
                showEasing: "swing",
                hideEasing: "linear",
                showMethod: "fadeIn",
                hideMethod: "fadeOut",
                tapToDismiss: !1
            })
    } else if (!name.value) {
        toastr.error(
            "Quên nhập tài khoản bé ơi!!",
            "Lỗi nè",
            {
                positionClass: "toast-top-right",
                timeOut: 5e3,
                closeButton: !0,
                debug: !1,
                newestOnTop: !0,
                progressBar: !0,
                preventDuplicates: !0,
                onclick: null,
                showDuration: "300",
                hideDuration: "1000",
                extendedTimeOut: "1000",
                showEasing: "swing",
                hideEasing: "linear",
                showMethod: "fadeIn",
                hideMethod: "fadeOut",
                tapToDismiss: !1
            })
    } else if (!pass.value) {
        toastr.error(
            "Quên nhập mật khẩu bé ơi!!",
            "Lỗi nè",
            {
                positionClass: "toast-top-right",
                timeOut: 5e3,
                closeButton: !0,
                debug: !1,
                newestOnTop: !0,
                progressBar: !0,
                preventDuplicates: !0,
                onclick: null,
                showDuration: "300",
                hideDuration: "1000",
                extendedTimeOut: "1000",
                showEasing: "swing",
                hideEasing: "linear",
                showMethod: "fadeIn",
                hideMethod: "fadeOut",
                tapToDismiss: !1
            })
    } else if (pass.value && name.value) {
        toastr.success(
            "Đợi một chút để anh xử lý nhé :3",
            "Đủ rồi đó", {
            timeOut: 5e3,
            closeButton: !0,
            debug: !1,
            newestOnTop: !0,
            progressBar: !0,
            positionClass: "toast-top-right",
            preventDuplicates: !0,
            onclick: null,
            showDuration: "300",
            hideDuration: "1000",
            extendedTimeOut: "1000",
            showEasing: "swing",
            hideEasing: "linear",
            showMethod: "fadeIn",
            hideMethod: "fadeOut",
            tapToDismiss: !1
        });
        setTimeout(function () {
            $.ajax({
                type: "POST",
                url: '/Admin/Login/Login',
                contentType: "application/json; charset=utf-8",
                data: datatk,
                dataType: "json",
                success: function (res) {
                    if (res.status == "ok") {
                        window.location = "/Admin/Home/Index";
                    } else if (res.status == "not") {
                        toastr.error(
                            "Bé nhập sai tài khoản hoặc mật khẩu òi!!",
                            "Lỗi nè",
                            {
                                positionClass: "toast-top-right",
                                timeOut: 5e3,
                                closeButton: !0,
                                debug: !1,
                                newestOnTop: !0,
                                progressBar: !0,
                                preventDuplicates: !0,
                                onclick: null,
                                showDuration: "300",
                                hideDuration: "1000",
                                extendedTimeOut: "1000",
                                showEasing: "swing",
                                hideEasing: "linear",
                                showMethod: "fadeIn",
                                hideMethod: "fadeOut",
                                tapToDismiss: !1
                            })
                    } else if (res.status == "lock") {
                        toastr.error(
                            "Tài khoản của bé bị khóa mất òi!!",
                            "Khóa òi",
                            {
                                positionClass: "toast-top-right",
                                timeOut: 5e3,
                                closeButton: !0,
                                debug: !1,
                                newestOnTop: !0,
                                progressBar: !0,
                                preventDuplicates: !0,
                                onclick: null,
                                showDuration: "300",
                                hideDuration: "1000",
                                extendedTimeOut: "1000",
                                showEasing: "swing",
                                hideEasing: "linear",
                                showMethod: "fadeIn",
                                hideMethod: "fadeOut",
                                tapToDismiss: !1
                            })
                    }
                }
            })
        }, 2000)
    }
}

function dangky() {
    var name = document.querySelector('#username');
    var pass = document.querySelector('#password');
    var hvt = document.querySelector('#hovaten');

    var datatk = "{'username' : '" + name.value + "', 'password' :'" + pass.value + "', 'hovaten' :'" + hvt.value + "'}";

    if (!pass.value && !name.value && !hvt.value) {
        toastr.error(
            "Đã nhập cái gì đâu bé -.-!!",
            "Lỗi nè",
            {
                positionClass: "toast-top-right",
                timeOut: 5e3,
                closeButton: !0,
                debug: !1,
                newestOnTop: !0,
                progressBar: !0,
                preventDuplicates: !0,
                onclick: null,
                showDuration: "300",
                hideDuration: "1000",
                extendedTimeOut: "1000",
                showEasing: "swing",
                hideEasing: "linear",
                showMethod: "fadeIn",
                hideMethod: "fadeOut",
                tapToDismiss: !1
            })
    } else if (pass.value && !name.value && hvt.value) {
        toastr.error(
            "Thiếu tên đăng nhập rồi -.-!!",
            "Lỗi nè",
            {
                positionClass: "toast-top-right",
                timeOut: 5e3,
                closeButton: !0,
                debug: !1,
                newestOnTop: !0,
                progressBar: !0,
                preventDuplicates: !0,
                onclick: null,
                showDuration: "300",
                hideDuration: "1000",
                extendedTimeOut: "1000",
                showEasing: "swing",
                hideEasing: "linear",
                showMethod: "fadeIn",
                hideMethod: "fadeOut",
                tapToDismiss: !1
            })
    } else if (pass.value && name.value && !hvt.value) {
        toastr.error(
            "Thiếu họ và tên rồi :((",
            "Lỗi nè",
            {
                positionClass: "toast-top-right",
                timeOut: 5e3,
                closeButton: !0,
                debug: !1,
                newestOnTop: !0,
                progressBar: !0,
                preventDuplicates: !0,
                onclick: null,
                showDuration: "300",
                hideDuration: "1000",
                extendedTimeOut: "1000",
                showEasing: "swing",
                hideEasing: "linear",
                showMethod: "fadeIn",
                hideMethod: "fadeOut",
                tapToDismiss: !1
            })
    } else if (!pass.value && name.value && hvt.value) {
        toastr.error(
            "Thiếu mật khẩu rồi :((",
            "Lỗi nè",
            {
                positionClass: "toast-top-right",
                timeOut: 5e3,
                closeButton: !0,
                debug: !1,
                newestOnTop: !0,
                progressBar: !0,
                preventDuplicates: !0,
                onclick: null,
                showDuration: "300",
                hideDuration: "1000",
                extendedTimeOut: "1000",
                showEasing: "swing",
                hideEasing: "linear",
                showMethod: "fadeIn",
                hideMethod: "fadeOut",
                tapToDismiss: !1
            })
    } else if (!pass.value && !name.value && hvt.value) {
        toastr.error(
            "Thiếu tên đăng nhập và mật khẩu rồi :((",
            "Lỗi nè",
            {
                positionClass: "toast-top-right",
                timeOut: 5e3,
                closeButton: !0,
                debug: !1,
                newestOnTop: !0,
                progressBar: !0,
                preventDuplicates: !0,
                onclick: null,
                showDuration: "300",
                hideDuration: "1000",
                extendedTimeOut: "1000",
                showEasing: "swing",
                hideEasing: "linear",
                showMethod: "fadeIn",
                hideMethod: "fadeOut",
                tapToDismiss: !1
            })
    } else if (!pass.value && name.value && !hvt.value) {
        toastr.error(
            "Thiếu họ và tên và mật khẩu rồi :((",
            "Lỗi nè",
            {
                positionClass: "toast-top-right",
                timeOut: 5e3,
                closeButton: !0,
                debug: !1,
                newestOnTop: !0,
                progressBar: !0,
                preventDuplicates: !0,
                onclick: null,
                showDuration: "300",
                hideDuration: "1000",
                extendedTimeOut: "1000",
                showEasing: "swing",
                hideEasing: "linear",
                showMethod: "fadeIn",
                hideMethod: "fadeOut",
                tapToDismiss: !1
            })
    } else if (pass.value && !name.value && !hvt.value) {
        toastr.error(
            "Thiếu tên đăng nhập và họ và tên rồi :((",
            "Lỗi nè",
            {
                positionClass: "toast-top-right",
                timeOut: 5e3,
                closeButton: !0,
                debug: !1,
                newestOnTop: !0,
                progressBar: !0,
                preventDuplicates: !0,
                onclick: null,
                showDuration: "300",
                hideDuration: "1000",
                extendedTimeOut: "1000",
                showEasing: "swing",
                hideEasing: "linear",
                showMethod: "fadeIn",
                hideMethod: "fadeOut",
                tapToDismiss: !1
            })
    } else if (pass.value && name.value && hvt.value) {
        toastr.success(
            "Đợi một chút để anh xử lý nhé :3",
            "Đủ rồi đó", {
            timeOut: 5e3,
            closeButton: !0,
            debug: !1,
            newestOnTop: !0,
            progressBar: !0,
            positionClass: "toast-top-right",
            preventDuplicates: !0,
            onclick: null,
            showDuration: "300",
            hideDuration: "1000",
            extendedTimeOut: "1000",
            showEasing: "swing",
            hideEasing: "linear",
            showMethod: "fadeIn",
            hideMethod: "fadeOut",
            tapToDismiss: !1
        });
        setTimeout(function () {
            $.ajax({
                type: "POST",
                url: '/Admin/Login/Register',
                contentType: "application/json; charset=utf-8",
                data: datatk,
                dataType: "json",
                success: function (res) {
                    if (res.status == "ok") {
                        window.location = "/Admin/Home/Index";
                    } else if (res.status == "not") {
                        toastr.error(
                            "Tài khoản này đã có người đăng ký mất òi :((",
                            "Lỗi nè",
                            {
                                positionClass: "toast-top-right",
                                timeOut: 5e3,
                                closeButton: !0,
                                debug: !1,
                                newestOnTop: !0,
                                progressBar: !0,
                                preventDuplicates: !0,
                                onclick: null,
                                showDuration: "300",
                                hideDuration: "1000",
                                extendedTimeOut: "1000",
                                showEasing: "swing",
                                hideEasing: "linear",
                                showMethod: "fadeIn",
                                hideMethod: "fadeOut",
                                tapToDismiss: !1
                            })
                    }
                }
            })
        }, 2000)
    }
}