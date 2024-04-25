const navItems = document.querySelectorAll(".nav");
// let a = document.createElement("div");

document.addEventListener("click", (ele) => {
    if (ele.target.className === "nav") {
        for (let i = 0; i < navItems.length; i++) {
            navItems[i].classList.remove("active-bar");
        }
        ele.target.classList.add("active-bar");
    }
});

function showAndHide(eleClass) {
    let element;
    element = document.querySelector(`.${eleClass}`);
    element.classList.toggle("active");

}


}
//for button delete and update
function getPostId(id) {
    console.log(id);
    document.getElementById('DeleteButton').href = `/Home/DeletePost?id=${id}`;
}

//for follow 
function follow(element,userName, pageName, wordSearch) {
        //This code for follow from the search page
        if (wordSearch != '') {
            window.location.href = `/Home/Follow?userName=${userName}&pageName=${pageName}&wordSearch=${wordSearch}`;
        }
        //This code for follow from the profileFriend page
        else {
            window.location.href = `/Home/Follow?userName=${userName}&pageName=${pageName}&wordSearch=''`;
        }
}
//for Unfollow
function unFollow(element, userName, pageName, wordSearch) {
    //This code for unfollow from the search page
    if (wordSearch != '') {
        window.location.href = `/Home/unFollow?userName=${userName}&pageName=${pageName}&wordSearch=${wordSearch}`;
    }
    //This code for unfollow from the profileFriend page
    else {
        window.location.href = `/Home/unFollow?userName=${userName}&pageName=${pageName}&wordSearch=''`;
    }
}

function copyCode(eleClass) {
    const copyBtn = document.querySelector(".copy-code-btn");
    const textToCopy = document.querySelector(`.${eleClass}`).textContent;
    navigator.clipboard.writeText(textToCopy).then(() => {
        // success
        copyBtn.style.backgroundColor = "#4fb04f";
        copyBtn.textContent = "تم نسخ الكود";
        copyBtn.style.color = "white";
        setTimeout(() => {
            copyBtn.style.backgroundColor = "white";
            copyBtn.textContent = "نسخ الكود";
            copyBtn.style.color = "black";
        }, 2000);
    });
}



function changeProfileImage(imageClass) {
    let image = document.querySelector(`.${imageClass}`);
    var input = document.createElement("input");
    input.type = "file";
    input.accept = "image/*"; // Accept only image files

    // Trigger the file selection dialog when clicked
    input.click();

    // Listen for changes in the selected file
    input.addEventListener("change", function () {
        var file = input.files[0];
        if (file) {
            // You can use FileReader to read the file
            var reader = new FileReader();
            reader.onload = function (e) {

                image.src = e.target.result;

            };
            reader.readAsDataURL(file);
        }
    });
}

function openImageDailog(inputImageClass) {
    let image = document.querySelector(".image-of-new-twit");
    let imageContainer = document.getElementById("new-twit-image-container");
    let span = document.querySelector(
        ".media-buttons > div:nth-child(1) > span"
    );

    if (span.textContent == "إضافة صورة") {
        // Create an input element
        var input = document.querySelector(`.${inputImageClass}`);

        // Trigger the file selection dialog when clicked
        input.click();

        // Listen for changes in the selected file
        input.addEventListener("change", function () {
            var file = input.files[0];
            if (file) {
                // You can use FileReader to read the file
                var reader = new FileReader();
                reader.onload = function (e) {
                    // Do something with the image data, for example:
                    image.src = e.target.result;
                    imageContainer.style.display = "flex";
                    span.textContent = "إزالة الصورة";
                };
                reader.readAsDataURL(file);
            }
        });
    }
    // if the span text is delet image
    else {
        imageContainer.style.display = "none";
        image.src = "";
        span.textContent = "إضافة صورة";
    }
}

function changeStatusToHover(icone) {
    if (icone.src.includes("heart")) {
        if (icone.src.includes("Hover"))
            icone.src = "assites/Icons/outline-heart.svg";
        else icone.src = "assites/Icons/Hover-outline-heart.svg";
    } else {
        if (icone.src.includes("Hover"))
            icone.src = "assites/Icons/outline-bookmark.svg";
        else icone.src = "assites/Icons/Hover-outline-bookmark.svg";
    }
}


function opne(selector) {
    let input = document.getElementById(`${selector}`);
    input.click();
}

