document.addEventListener("DOMContentLoaded", function () {
    var searchInput = document.getElementById("searchinput");
    var autocompleteList = document.createElement("ul");
    autocompleteList.id = "autocomplete-list";
    searchInput.parentNode.insertBefore(autocompleteList, searchInput.nextSibling);

    var bangs = [
        { Keyword: "!g", Description: "Google" },
        { Keyword: "!w", Description: "Wikipedia" },
        { Keyword: "!yt", Description: "YouTube" },
        { Keyword: "!a", Description: "Amazon" },
        { Keyword: "!tw", Description: "Twitter" },
        { Keyword: "!fb", Description: "Facebook" },
        { Keyword: "!r", Description: "Reddit" },
        { Keyword: "!gh", Description: "GitHub" },
        { Keyword: "!ama", Description: "AMA (Ask Me Anything)" },
        { Keyword: "!d", Description: "DuckDuckGo" },
        { Keyword: "!imdb", Description: "IMDb" },
        { Keyword: "!ebay", Description: "eBay" },
        { Keyword: "!netflix", Description: "Netflix" },
        { Keyword: "!maps", Description: "Google Maps" },
        { Keyword: "!p", Description: "Pinterest" },
        { Keyword: "!so", Description: "Stack Overflow" },
        { Keyword: "!gmail", Description: "Gmail" },
        { Keyword: "!gnews", Description: "Google News" },
        { Keyword: "!wp", Description: "WhatsApp" },
        { Keyword: "!img", Description: "Google Images" },
        { Keyword: "!t", Description: "Tumblr" },
        { Keyword: "!dic", Description: "Dictionary.com" },
        { Keyword: "!th", Description: "TheHackerNews" },
        { Keyword: "!net", Description: "Netflix" },
        { Keyword: "!y", Description: "Yahoo" },
        { Keyword: "!q", Description: "Quora" },
        { Keyword: "!m", Description: "Medium" },
        { Keyword: "!eb", Description: "Etsy" },
        { Keyword: "!hr", Description: "HackerRank" },
        { Keyword: "!cra", Description: "Craigslist" },
        { Keyword: "!o", Description: "Outlook" },
        { Keyword: "!drib", Description: "Dribbble" },
        { Keyword: "!it", Description: "Instagram" },
        { Keyword: "!gcal", Description: "Google Calendar" },
        { Keyword: "!sc", Description: "SoundCloud" },
        { Keyword: "!wol", Description: "Wolfram Alpha" },
        { Keyword: "!mz", Description: "Moz" },
        { Keyword: "!npr", Description: "NPR" },
        { Keyword: "!ar", Description: "Airbnb" },
        { Keyword: "!cnn", Description: "CNN" },
        { Keyword: "!bbc", Description: "BBC" },
        { Keyword: "!v", Description: "Vimeo" },
        { Keyword: "!tpb", Description: "The Pirate Bay" },
        { Keyword: "!gdoc", Description: "Google Docs" },
        { Keyword: "!wo", Description: "WordPress" },
        { Keyword: "!rt", Description: "Rotten Tomatoes" },
        { Keyword: "!ars", Description: "Ars Technica" },
        { Keyword: "!ln", Description: "LinkedIn" },
        { Keyword: "!sl", Description: "SlideShare" },
        { Keyword: "!hn", Description: "Hacker News" },
        { Keyword: "!me", Description: "Meetup" },
        { Keyword: "!wik", Description: "Wikipedia" },
        { Keyword: "!ea", Description: "Etsy" },
        { Keyword: "!b", Description: "Bing" },
        { Keyword: "!pay", Description: "PayPal" },
        { Keyword: "!dp", Description: "Dropbox" },
        { Keyword: "!fc", Description: "Flickr" },
        { Keyword: "!yelp", Description: "Yelp" },
        { Keyword: "!vs", Description: "VSCO" },
        { Keyword: "!fm", Description: "Foursquare" },
        { Keyword: "!gd", Description: "Google" },
        { Keyword: "!sp", Description: "Spotify" },
        { Keyword: "!pg", Description: "Pocket" },
        { Keyword: "!ad", Description: "Adobe" },
        { Keyword: "!gif", Description: "Giphy" },
        { Keyword: "!ibm", Description: "IBM" },
        { Keyword: "!mf", Description: "MyFitnessPal" },
        { Keyword: "!sch", Description: "Scholar Google" },
        { Keyword: "!med", Description: "MedicineNet" },
        { Keyword: "!az", Description: "Azure" },
        { Keyword: "!c", Description: "CNET" },
        { Keyword: "!ga", Description: "Google Analytics" },
        { Keyword: "!md", Description: "Mozilla Developer Network" },
        { Keyword: "!al", Description: "AliExpress" }
    ];

    searchInput.addEventListener("input", function () {
        var query = searchInput.value;

        if (query.length >= 2 && !query.startsWith("!")) {
            fetch(`/api/autocomplete?q=${query}`)
                .then(response => response.json())
                .then(data => {
                    autocompleteList.innerHTML = "";
                    data.forEach(item => {
                        var listItem = document.createElement("li");
                        listItem.textContent = item.phrase || item.Keyword;
                        autocompleteList.appendChild(listItem);
                    });
                    autocompleteList.style.display = "block";
                });
        } else {
            autocompleteList.style.display = "none";
        }

        if (query.length >= 1) {
            var filteredBangs = bangs.filter(bang =>
                bang.Keyword.toLowerCase().startsWith(query.substring(0).toLowerCase())
            );

            autocompleteList.innerHTML = "";
            filteredBangs.forEach(bang => {
                var listItem = document.createElement("li");
                autocompleteList.appendChild(listItem);
                var listkey = document.createElement("il");
                listkey.textContent = bang.Keyword;
                var listdes = document.createElement("span");
                listdes.textContent = " - " + bang.Description;
                listItem.appendChild(listkey);
                listItem.appendChild(listdes);
            });
            autocompleteList.style.display = "block";
        } else {
            autocompleteList.style.display = "none";
        }
    });

    autocompleteList.addEventListener("click", function (event) {
        if (event.target.tagName === "LI") {
            searchInput.value = event.target.textContent.split(" - ")[0];
            autocompleteList.style.display = "none";
        }
    });

    document.addEventListener("click", function (event) {
        if (!autocompleteList.contains(event.target) && event.target !== searchInput) {
            autocompleteList.style.display = "none";
        }
    });
});