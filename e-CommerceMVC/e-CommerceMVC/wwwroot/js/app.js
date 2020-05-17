$('#Cart-button').click(clickCart)

function clickCart() {
    let count = 1;
    $('.sidebar').toggle();
    count++;
    $('#main-body-box').toggleClass();

}

$('.sidebar').hide();
$('#main-body-box').toggleClass();

