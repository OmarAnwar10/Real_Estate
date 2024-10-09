document.addEventListener("DOMContentLoaded", function () {
    // Function to load a partial view dynamically and handle the active class
    async function loadPartialView(url, clickedLink) {
        try {
            let response = await fetch(url);
            if (!response.ok) throw new Error("Network response was not ok");

            let html = await response.text();
            document.getElementById("partialViewContainer").innerHTML = html;

            var links = document.querySelectorAll('.partial-btn');
            links.forEach(function (link) {
                link.classList.remove('active');
            });

            clickedLink.classList.add('active');
        } catch (error) {
            console.error("Error loading partial view:", error);
        }
    }


    // Automatically load "My Profile" partial view on page load
    if (val!=2) {
        loadPartialView('/User/Profile', document.getElementById("loadPartial1Btn"));
    }
    else {
        loadPartialView('/User/SubmitProperty', document.getElementById("loadPartial5Btn"));
    }



    // Add event listeners to both buttons
    document.getElementById("loadPartial1Btn").addEventListener("click", function () {
        loadPartialView('/User/Profile', this);
    });
    document.getElementById("loadPartial2Btn").addEventListener("click", function () {
        loadPartialView('/User/Property', this);
    });
    document.getElementById("loadPartial3Btn").addEventListener("click", function () {
        loadPartialView('/User/Favorite', this);
    });
    document.getElementById("loadPartial4Btn").addEventListener("click", function () {
        loadPartialView('/User/Messages', this);
    });
    document.getElementById("loadPartial5Btn").addEventListener("click", function () {
        loadPartialView('/User/SubmitProperty', this);
    });
    document.getElementById("loadPartial6Btn").addEventListener("click", function () {
        loadPartialView('/User/ChangePassword', this);
    });

    document.getElementById("loadPartial7Btn").addEventListener("click", function () {///edit log out
        window.location.href = '/Home/Index';
    });
});