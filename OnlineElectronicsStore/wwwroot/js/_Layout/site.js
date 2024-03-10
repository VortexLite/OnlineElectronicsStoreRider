// Навігація
document.addEventListener("DOMContentLoaded", function() {
    const btnCatalog = document.querySelector(".btnCatalog");
    const navigationFull = document.getElementById("navigationFull");
    const article = document.querySelector("article");

    let isNavigationVisible = false; // флаг, що вказує на видимість навігації

    // При натисканні на кнопку
    btnCatalog.addEventListener("click", function() {
        if (isNavigationVisible) {
            hideNavigation();
        } else {
            showNavigation();
        }
    });

    // При наведенні миші на кнопку
    btnCatalog.addEventListener("mouseover", function() {
        if (!isNavigationVisible) {
            showNavigation();
        }
    });

    // При наведенні миші на меню
    navigationFull.addEventListener("mouseover", function() {
        showNavigation();
    });


    // При відведенні миші від меню
    navigationFull.addEventListener("mouseout", function(event) {
        if (!btnCatalog.contains(event.relatedTarget)) {
            hideNavigation();
        }
    });

    // Функція показу навігації
    function showNavigation() {
        navigationFull.style.display = "inherit";
        navigationFull.style.zIndex = "999";
        article.style.zIndex = "3";
        isNavigationVisible = true;
    }

    // Функція приховування навігації
    function hideNavigation() {
        navigationFull.style.display = "none";
        isNavigationVisible = false;
    }
});

//