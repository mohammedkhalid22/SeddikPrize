
// ********************************* About Page and Feilds *****************************
function myFunction() {
    var dots = document.getElementById("dots");
    var moreText = document.getElementById("more");
    var btnText = document.getElementById("myBtn");

    if (dots.style.display === "none") {
        dots.style.display = "inline";
        btnText.innerHTML = "قراءه المزيد";
        moreText.style.display = "none";
    } else {
        dots.style.display = "none";
        btnText.innerHTML = "قراءه الاقل";
        moreText.style.display = "inline";
    }
}

function ourbutton() {
    var dots = document.getElementById("dotsm");
    var moreText = document.getElementById("morem");
    var btnText = document.getElementById("myBtnm");

    if (dots.style.display === "none") {
        dots.style.display = "inline";
        btnText.innerHTML = "قراءه المزيد";
        moreText.style.display = "none";
    } else {
        dots.style.display = "none";
        btnText.innerHTML = "قراءه الاقل";
        moreText.style.display = "inline";
    }
} 

// ***************************************** register prize page **********************

var fullname = document.getElementById("full-name");
var email = document.getElementById("e-mail");
var idNumber = document.getElementById("id-number");
var mobile = document.getElementById("mobile");
var birthday = document.getElementById("birthday");

var contestantDataContainer = [];

function addData(){
    
    var contestantData = {
        name:fullname.value,
        email: email.value,
        idnumber: idNumber.value,
        mobile: mobile.value,
        birthday: birthday.value
    };
    contestantDataContainer.push(contestantData);
    console.log(contestantDataContainer);

    fullname.value = " ";
    email.value = " ";
    idNumber.value = " ";
    mobile.value = " ";
    birthday.value = " ";
};

var img = document.querySelector("th.none");
var view = document.querySelector("#none");

img.addEventListener("click", function () {
    view.classList.toggle("activee")
})