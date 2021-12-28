function dangnhap() {
    var name = document.querySelector('#username');
    var pass = document.querySelector('#password');

    var datatk = "{'username' : '" + name.value + "', 'password' :'" + pass.value + "'}";

    if (!pass.value && !name.value) {
        toastr.error(
            "Chưa nhập thông tin -.-!!",
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
            "Tài khoản không được để trống",
            "Lỗi !!!",
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
            "Quên nhập mật khẩu !!!",
            "Lỗi !!!",
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
            "Đang xử lí vui lòng chờ đợi",
            "OK", {
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
                            "Nhập sai tài khoản hoặc mật khẩu",
                            "Lỗi !!!",
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
                            "Tài khoản của bạn đã bị khóa !!",
                            "Khóa",
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
            "Chưa điền thông tin",
            "Lỗi !!!",
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
            "Lỗi !!!",
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
            "Lỗi !!!",
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
            "Lỗi !!!",
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
            "Lỗi !!!",
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
            "Lỗi !!!",
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
            "Lỗi !!1",
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
            "Đang xử lí, vui lòng chờ :3",
            "OK", {
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
                            "Lỗi !!!",
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