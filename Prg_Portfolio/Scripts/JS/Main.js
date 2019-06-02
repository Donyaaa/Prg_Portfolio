//---------------------Subscribe Email
$("#Btn_SubmitSubscribe").click(function () {
 
    var data = $("#Frm_Subscribe").serialize();
    $.ajax({
        type: "Post",
        url: "/Home/Subscribe",
        data: data,
        success: function (response) {
            if (response == "Success") {
                alert("Email Registered !");
            }
            else if (response == "Failed") {
                alert("Fail To Register !");
            }
            else if (response == "Exist") {
                alert("Email Is Alrady Exist !");
            }
            else {
                alert(response);
            }
        }
    });
});


//---------------------Submit The Contact Us
$("#Btn_SubmitCountactUs").click(function () {
  
    var data = $("#Frm_CountactUs").serialize();
    $.ajax({
        type: "Post",
        url: "/Home/ContactUs",
        data: data,
        success: function (response) {
            if (response == "Success") {
                alert("Your Message Succesfull Resived To Us!");
            }
            else if (response == "Failed") {
                alert("Fail To Send Your Message! Please Try Again!");
            }
            else {
                alert(response);
            }
        }
    });
});


});