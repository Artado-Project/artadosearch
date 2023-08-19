document.addEventListener("DOMContentLoaded", function () {
    var searchInput = document.getElementById("searchinput");
    var autocompleteList = document.createElement("ul");
    autocompleteList.id = "autocomplete-list";
    searchInput.parentNode.insertBefore(autocompleteList, searchInput.nextSibling);

    searchInput.addEventListener("input", function () {
        var query = searchInput.value;
        if (query.length >= 2) {
            fetch(`/api/autocomplete?q=${query}`)
                .then(response => response.json())
                .then(data => {
                    autocompleteList.innerHTML = "";
                    data.forEach(item => {
                        var listItem = document.createElement("li");
                        listItem.textContent = item.Keyword;
                        autocompleteList.appendChild(listItem);
                    });
                    autocompleteList.style.display = "block";
                });
        } else {
            autocompleteList.style.display = "none";
        }
    });

    autocompleteList.addEventListener("click", function (event) {
        if (event.target.tagName === "LI") {
            searchInput.value = event.target.textContent;
            autocompleteList.style.display = "none";
        }
    });

    document.addEventListener("click", function (event) {
        if (!autocompleteList.contains(event.target) && event.target !== searchInput) {
            autocompleteList.style.display = "none";
        }
    });
});