# Artado Search Theme and Extension Documentation

Welcome to the Artado Search Theme and Extension Documentation! This guide will provide you with step-by-step instructions on how to customize the Artado Search interface using themes (CSS files) and enhance its functionality with extensions (JavaScript files). You'll also learn how to publish your creations, including themes, extensions, and logos, through Artado Developers.

## Table of Contents

1. [Introduction to Themes and Extensions](#introduction-to-themes-and-extensions)
2. [Customizing the Interface with Themes](#customizing-the-interface-with-themes)
3. [Enhancing Functionality with Extensions](#enhancing-functionality-with-extensions)
4. [Publishing on Artado Developers](#publishing-on-artado-developers)

## Introduction to Themes and Extensions

Artado Search offers the ability to customize its appearance and extend its capabilities through themes and extensions. Themes are CSS files that allow you to modify the visual design, while extensions are JavaScript files that enable you to add new features and functionality.

## Customizing the Interface with Themes

You can create and apply custom themes to personalize the Artado Search interface. Here's a basic example of how to do it using the provided HTML code:

1. **Identify Elements**: Use browser developer tools to inspect the HTML elements you want to style.

2. **Write CSS Code**: Create a new CSS file for your theme. Add styles to target specific elements. For instance, to change the background color of the search input, you can use:

```css
/* Custom Theme Example */
#searchinput {
    background-color: #f2f2f2;
}
```

3. **Link Your Theme**: In the HTML file, link your custom theme CSS file within the `<head>` section:

```html
<head>
    <link rel="stylesheet" href="path-to-your-theme.css">
</head>
```

## Enhancing Functionality with Extensions

Extensions enable you to add new functionality to Artado Search. Here's a simple example using the provided HTML code:

1. **Identify Desired Functionality**: Decide what feature you want to add. For instance, let's add a tooltip to the search button.

2. **Write JavaScript Code**: Create a new JavaScript file for your extension. Add the necessary code to implement the feature. For instance, to create a tooltip on hover:

```javascript
// Custom Extension Example
const searchButton = document.getElementById('ImageButton1');
searchButton.addEventListener('mouseover', () => {
    searchButton.title = 'Search the Internet';
});
```

3. **Link Your Extension**: In the HTML file, link your extension JavaScript file before the closing `</body>` tag:

```html
<script src="path-to-your-extension.js"></script>
</body>
```

## Publishing on Artado Developers

To share your themes, extensions, and logos, follow these steps on Artado Developers:

1. **Create an Account**: Visit [Artado Developers](https://devs.artado.xyz/) and create an account.

2. **Log In and Access Workshop**: After creating an account, log in to Artado Developers. Navigate to the "Workshop" tab.

3. **Create a Project**: Click on "Create a project" and provide details about your theme or extension.

4. **Upload Your Files**: Upload your theme's CSS file and/or extension's JavaScript file.

5. **Submit and Share**: Submit your project. Once approved, your creation will be available for others to explore and use.

## Conclusion

Customizing the Artado Search interface with themes and extending its capabilities with extensions can significantly enhance your browsing experience. By publishing your creations through Artado Developers, you contribute to the Artado Search ecosystem and share your innovations with the community.

If you have any questions or need assistance, please reach out to us at [support@artadosearch.com](mailto:support@artadosearch.com).

Happy theming and extending!

---

Thank you for your dedication to making Artado Search a personalized and feature-rich search engine. Your contributions play a crucial role in creating a diverse and dynamic search experience for users.
