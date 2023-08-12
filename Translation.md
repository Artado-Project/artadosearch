# Artado Search Translation Documentation

Welcome to the Artado Search Translation Documentation! This guide will help you understand how translations are managed using resource files (.resx) in ASP.NET and how you can contribute to translating the Artado Search platform into different languages.

## Table of Contents

- [Introduction to Resource Files](#introduction-to-resource-files)
- [Translating Artado Search](#translating-artado-search)
- [Contributing Translations](#contributing-translations)
- [Testing Translations](#testing-translations)
- [Adding a New Language](#adding-a-new-language)
- [Conclusion](#conclusion)

## Introduction to Resource Files

Resource files, often denoted with the extension `.resx`, are XML-based files used in ASP.NET projects to store strings and other values that need to be localized. They allow you to separate your application's content from its code, making it easier to provide translations for different languages without modifying the source code.

Resource files consist of key-value pairs, where each key represents a unique identifier for a specific string or value. These keys are associated with their corresponding values in different languages. At runtime, ASP.NET selects the appropriate resource file based on the user's preferred language and displays the correct translation.

## Translating Artado Search

Artado Search uses resource files to manage translations. Each language has its own set of resource files containing translations for the platform's text elements, labels, and messages. These files are located in the [`App_GlobalResources`](https://github.com/Artado-Project/artadosearch/tree/main/artadosearch/App_GlobalResources) directory of the project.

For example, if you want to translate Artado Search into French, you'll find a set of resource files like this:

- `App_GlobalResources/Langs.fr.resx`: Contains translations for French.

## Contributing Translations

To contribute translations to Artado Search, follow these steps:

1. **Fork the Repository**: Start by forking the Artado Search repository to your GitHub account.

2. **Clone the Repository**: Clone your forked repository to your local machine using the following command:
   ```bash
   git clone https://github.com/Artado-Project/artadosearch
   ```

3. **Identify Resource Files**: Navigate to the [`App_GlobalResources`](https://github.com/Artado-Project/artadosearch/tree/main/artadosearch/App_GlobalResources) directory and locate the appropriate resource files for the language you want to contribute to.

4. **Translate Content**: Open the `.resx` files in a text editor, XML editor or Visual Studio. For each key, provide the translated value in the target language.

5. **Commit and Push Changes**: After translating, commit your changes to your local repository and push them to your GitHub fork.

6. **Create a Pull Request**: Go to your GitHub fork and create a pull request from your branch to the main Artado Search repository.

## Adding a New Language

If you want to add a new language for translation:

1. Create a new set of `.resx` files with the appropriate language code (e.g., `Langs.de.resx` for German).

2. Translate the content as mentioned above.

3. Update the `Languages` DropDownList in the [`Default.aspx`](https://github.com/Artado-Project/artadosearch/blob/cb57d308cc2123819b722820eafb62676d45dc75/artadosearch/Default.aspx#L104C53-L104C53),
[`search.aspx`](https://github.com/Artado-Project/artadosearch/blob/cb57d308cc2123819b722820eafb62676d45dc75/artadosearch/search.aspx#L57) and
[`basics.aspx`](https://github.com/Artado-Project/artadosearch/blob/cb57d308cc2123819b722820eafb62676d45dc75/artadosearch/Settings_Pages/basics.aspx#L84C33-L84C33) files to include the new language.

## Conclusion

Thank you for your interest in contributing translations to Artado Search. Your efforts help make the platform accessible to users from different linguistic backgrounds. If you have any questions or need assistance, feel free to contact us at [support@artadosearch.com](mailto:support@artadosearch.com).

Happy translating!

---

We appreciate your dedication to making Artado Search available to a wider audience through translation contributions. Your work contributes to a more inclusive search experience for all users.
