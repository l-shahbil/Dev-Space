let displayButtonMore = 0;
let isScroll = false;
let homePage = document.querySelector('.center-side');
let button = document.querySelector('#home-update-btn');
const navItems = document.querySelectorAll(".nav");



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
    if (eleClass == 'code-box') {
        element.value = "";
    }
}

//for button delete 
function DeletePost(id) {
    //for Delete
    document.getElementById('DeleteButton').href = `/Post/DeletePost?id=${id}`; 
}
function EditPost(number) {
    //for Update
    let text = document.getElementById(`post-text${number}`);
    let code = document.getElementById(`post-code${number}`);
    let img = document.getElementById(`post-img${number}`);

    document.getElementById('input-edit-twitt-code').value = "";
    document.getElementById('input-edit-twitt-text').value = "";
    document.getElementById('edit-twitt-img').src = "";

    document.getElementById('input-edit-twitt-id').value = document.getElementById(`id-post${number}`).value;
    if (text) {

        document.getElementById('input-edit-twitt-text').value = text.innerHTML;
    }
    if (code) {
        document.getElementById('input-edit-twitt-code').value = code.innerHTML;
    }
    if (img) {
        document.getElementById('edit-twitt-img').src = img.src;

    }
}

//for follow 
function follow(element,userName, pageName, wordSearch) {
        //This code for follow from the search page
        if (wordSearch != '') {
            window.location.href = `/Accounts/Follow?userName=${userName}&pageName=${pageName}&wordSearch=${wordSearch}`;
        }
        //This code for follow from the profileFriend page
        else {
            window.location.href = `/Accounts/Follow?userName=${userName}&pageName=${pageName}&wordSearch=''`;
        }
}
//for Unfollow
function unFollow(element, userName, pageName, wordSearch) {
    //This code for unfollow from the search page
    if (wordSearch != '') {
        window.location.href = `/Accounts/unFollow?userName=${userName}&pageName=${pageName}&wordSearch=${wordSearch}`;
    }
    //This code for unfollow from the profileFriend page
    else {
        window.location.href = `/Accounts/unFollow?userName=${userName}&pageName=${pageName}&wordSearch=''`;
    }
}
function AddBookMark(icon, postId, pageAction, userNameFriend) {
    //Add BookMark
    //userFriend in order to the user added bookMark from the profileFriend. the profileFriend controller accept userName for friend
    icon.src = "~/lib/assites/Icons/outline-bookmark.svg";
    window.location.href = `/Bookmarks/addBookMarks?postID=${postId}&pageAction=${pageAction}&userFriend=${userNameFriend}`;

}
function removeBookMark(icon, archiveId, pageAction, userNameFriend) {
    //Remove BookMark
    //userFriend in order to the user remove bookMark from the profileFriend. the profileFriend controller accept userName for friend
    icon.src = "~/lib/assites/Icons/Hover-outline-bookmark.svg";
    window.location.href = `/Bookmarks/DeleteBookMarks?archiveID=${archiveId}&pageAction=${pageAction}&userFriend=${userNameFriend}`;

}
//for Like
function like(icon, postId, pageAction, userNameFriend) {
    //userFriend in order to the user liked from the profileFriend. the profileFriend controller accept userName for friend
    icon.src = "~/lib/assites/Icons/Hover-outline-heart.svg";
    window.location.href = `/Accounts/Like?postID=${postId}&pageAction=${pageAction}&userFriend=${userNameFriend}`;

}
//for dislike
function disLike(icon, likeId, pageAction, userNameFriend) {
   //userFriend in order to the user dislike from the profileFriend. the profileFriend controller accept userName for friend
    icon.src = "~/lib/assites/Icons/outline-heart.svg";
    window.location.href = `/Accounts/DisLike?likeId=${likeId}&pageAction=${pageAction}&userFriend=${userNameFriend}`;


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




function opne(selector) {
    let input = document.getElementById(`${selector}`);
    input.click();
}


function updateHomePage() {
    setTimeout(function () {
        button.classList.add('down');
        updateHomePage();
    }, 1800000)
}


