// Function to read cookie by name
function getCookie(name) {
    let value = "; " + document.cookie;
    let parts = value.split("; " + name + "=");
    if (parts.length === 2) return parts.pop().split(";").shift();
}

// Function to apply styles to elements
function applyStylesFromCookie() {
    // Get the adjustments cookie value
    let cookieValue = getCookie('adjustments');
    if (cookieValue) {
        // Parse the JSON from the cookie
        let stylesArray = JSON.parse(cookieValue);

        // Apply styles to elements
        stylesArray.forEach(styleObj => {
            console.log(styleObj.name)
            if (styleObj.name) {
                let element = document.getElementById(`${styleObj.name}`);
                if (element) {
                    if (styleObj.left) element.style.left = styleObj.left;
                    if (styleObj.top) element.style.top = styleObj.top;
                    if (styleObj.backgroundColor) element.style.backgroundColor = styleObj.backgroundColor;
                    if (styleObj.width) element.style.width = styleObj.width;
                    if (styleObj.height) element.style.height = styleObj.height;
                    if (styleObj.display) element.style.display = styleObj.display;
                    if (styleObj.position) element.style.position = styleObj.position;
                }
            }
        });
    }

    // Get the background color and text color from cookies
    let bgColor = getCookie('bgColor');
    let textColor = getCookie('textColor');

    // Apply the background color and text color
    if (bgColor && textColor) {
        document.body.style.cssText = 'background-color: ' + bgColor + '; color: ' + textColor + ' !important;';
    }
    if (textColor) {
        document.body.style.cssText = 'color: ' + textColor + ' !important;';
    }
    if (bgColor) {
        document.body.style.backgroundColor = bgColor;
    }
}

// Call the function on page load
window.onload = applyStylesFromCookie;
