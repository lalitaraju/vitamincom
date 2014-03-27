function emailsignup() {
    var inputVal = $("#emailcontactus").val();
    var email = $("#emailcontactus").val();
    var acqSource = $("#Acqsource").val();
    var acqSubSource = $("#Acqsubsource").val();
    var division = $("#Division").val();
    var language = $("#Language").val();
//    $.post("/Home/EmailOptIn", { email: email, acqSource: acqSource, acqSubSource: acqSubSource, DivisionName: division, Language: language },
//                                  function (data) {
//                                      if (data == null) {
//                                          //                        errorMsg.text("This email address already exists.");
//                                          //                        errorMsg.show();
//                                      }
//                                      else {
//                                          $("#thankyou").css("display", "block");
//                                          $("#offerwindow").css("display", "none");

//                                      }


//                                      return data;
//                                  });
    if (validateEmail(inputVal)) {
        $("#contactus").submit(function () {
            $.post("/Home/EmailOptIn", { email: email, acqSource: acqSource, acqSubSource: acqSubSource, DivisionName: division, Language: language },
                                  function (data) {
                                      if (data == null) {
                                          //                        errorMsg.text("This email address already exists.");
                                          //                        errorMsg.show();
                                      }
                                      else {
                                          $("#thankyou").css("display", "block");
                                          $("#offerwindow").css("display", "none");

                                      }


                                      return data;
                                  });

        });
    };

      $("#emailcontactus").change(function () {                              
             
        if (!validateEmail(inputVal)) {
            //$("#emailcontactus").after('<span id="cspan" style="color:red">Please enter valid email.</span>').css("color", "#FFCCCC");
            //$("#emailcontactus").css("border-color", "red");
            //  var formId = this.id;
            $('#contactus' + ' :input[type=submit]').attr('disabled', true);
            //this.submit();

        }
        else if (inputVal == '') {
            alert("test");
            //$("#emailcontactus").after('<span style="color:red">Email is Required.</span>').css("color", "#FFCCCC");
            //$("#emailcontactus").css("border-color", "red");
            $('#contactus' + ' :input[type=submit]').attr('disabled', true);

        }
    });
   

}

function validateEmail(email) {
    var pattern = new RegExp(/^((([a-z]|\d|[!#\$%&'\*\+\-\/=\?\^_`{\|}~]|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])+(\.([a-z]|\d|[!#\$%&'\*\+\-\/=\?\^_`{\|}~]|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])+)*)|((\x22)((((\x20|\x09)*(\x0d\x0a))?(\x20|\x09)+)?(([\x01-\x08\x0b\x0c\x0e-\x1f\x7f]|\x21|[\x23-\x5b]|[\x5d-\x7e]|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])|(\\([\x01-\x09\x0b\x0c\x0d-\x7f]|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF]))))*(((\x20|\x09)*(\x0d\x0a))?(\x20|\x09)+)?(\x22)))@((([a-z]|\d|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])|(([a-z]|\d|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])([a-z]|\d|-|\.|_|~|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])*([a-z]|\d|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])))\.)+(([a-z]|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])|(([a-z]|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])([a-z]|\d|-|\.|_|~|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])*([a-z]|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])))\.?$/i);
    return pattern.test(email);
}

