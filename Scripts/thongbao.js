// Gán hành động khi người dùng nhấn nút "Thanh toán"
$('#btn-pay').click(function () {
    $.ajax({
        url: '/ShoppingCart/CheckOut', // Thay '/ShoppingCart/CheckOut' bằng địa chỉ hành động CheckOut của bạn trong Controller
        method: 'POST',
        success: function (response) {
            if (response.success) {
                // Nếu phản hồi từ máy chủ thành công, hiển thị thông báo thanh toán thành công
                $('#payment-message').text('Thanh toán thành công!');
            } else {
                // Xử lý nếu có lỗi trong quá trình thanh toán
                $('#payment-message').text('Đã xảy ra lỗi trong quá trình thanh toán.');
            }
        },
        error: function (error) {
            // Xử lý lỗi nếu cần thiết
            console.error('Đã xảy ra lỗi trong quá trình thanh toán.');
        }
    });
});