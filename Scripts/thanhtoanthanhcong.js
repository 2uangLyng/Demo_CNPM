// Khi thanh toán thành công (bạn có thể thay đổi điều này dựa vào cơ chế xác nhận thanh toán của bạn)
function onPaymentSuccess() {
    // Hiển thị thông báo thành công cho người dùng (tuỳ chọn)
    var successMessage = document.getElementById('paymentSuccessMessage');
    successMessage.textContent = "Thanh toán thành công! Đang chuyển hướng về trang chủ sau 10 giây...";

    // Đếm ngược
    var countDown = 10; // 10 giây
    var timer = setInterval(function () {
        countDown--;
        successMessage.textContent = "Thanh toán thành công! Đang chuyển hướng về trang chủ sau " + countDown + " giây...";

        if (countDown <= 0) {
            clearInterval(timer);
            window.location.href = "https://localhost:44308/H%C3%A0ng_H%C3%B3a/Proview"; // Thay đổi URL trang chủ tùy theo trang web của bạn
        }
    }, 1000); // 1 giây (1000 mili giây)
}
