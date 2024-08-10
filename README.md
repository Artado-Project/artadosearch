# Artado Search

![Artado Search Logo](https://www.artadosearch.com/images/android-chrome-192x192.png)

Artado Search is a versatile and highly customizable search engine, designed to empower users with the ability to tailor their search experience to their unique needs. This project is based on the ASP.NET Framework and is proudly open source under the AGPL v3 license. It not only offers its own search results but also integrates results from other search engines, providing a comprehensive search solution.

## Features

- **Combined Results**: In addition to its own search algorithms, Artado Search aggregates results from other search engines, providing users with a holistic perspective and access to a wider range of information.

- **Customizability**: Artado Search goes beyond traditional search engines by offering extensive customization options. You can create personalized themes and extensions to enhance the user interface and functionality.

- **Workshop**: A place that you can share and use the themes, extensions and logos made by our users.

- **Developer-Friendly**: Artado Search's extensibility is one of its core strengths. Developers can create and publish themes, extensions, and logos through the Artado Developers platform. Themes are crafted using CSS, while extensions are powered by JavaScript.

- **Multi-language Support**: Artado Search supports over 20 languages out of the box. Users have the ability to contribute additional languages or correct translation errors to make the search experience more inclusive and accurate.
  
- **Bangs**: DuckDuckGo-style [!bang syntax](https://duckduckgo.com/bangs). Artado Search supports over 70 bangs.


## Getting Started

Follow these steps to get Artado Search up and running on your system:

1. **Prerequisites**: Make sure you have the ASP.NET Framework 4.8 installed on your machine.

2. **Clone the Repository**: Clone this repository to your local environment using the following command:
   ```bash
   git clone https://github.com/Artado-Project/artadosearch
   ```

3. **Configuration**: Configure the database connection in `web.config` as to adapt Artado Search to your specific use case.
Copy the `Web.example.config` to `Web.config` and fill in the database parameters.
   ```xml
   <connectionStrings>
	  <add name="con" connectionString="" />
	  <add name="admin" connectionString="" />
	  <add name="service" connectionString="" />
   </connectionStrings>
   ```
Also change the parameters in `Config.cs`. Copy the `Config.example.cs` to `Config.cs` and fill in the parameters.

4. **Build and Launch**: Utilize your preferred development environment or the command line to build the project. Once built, start the application and access the search engine via your web browser.

5. **Development**: If you're interested in creating themes or extensions for Artado Search, refer to the [Developer Documentation](Themes_and_Extensions.md) for comprehensive guidelines.

## Contributing

Thank you for your interest in contributing to Artado Search! Your support is crucial to helping us build and grow a better, open, and privacy-focused search engine. There are many ways you can contribute to the project, whether you're a developer, designer, or simply someone passionate about the future of online search. If you want to contribute, please follow the [contribution guidelines](CONTRIBUTING.md). Here’s how you can help:

1. **Use Artado Search**  
   Make Artado your default search engine and encourage others to do the same. By using Artado, you’re helping to spread our message and grow our community. You can read [this](https://github.com/Artado-Project/artadosearch-docs/blob/main/User%20Guide/User%20Guide.md#how-to-set-artado-as-your-default-search-engine) to set Artado your default search engine.

2. **Donate**  
   Support the ongoing development and maintenance of Artado by making a donation. Every contribution helps us stay independent and continue improving the platform.
   You can donate us from [Patreon](https://www.patreon.com/artadosoft) or [Kreosus](https://kreosus.com/artadosoft).

4. **Contribute to the Code**  
   If you’re a developer, we’d love your help in making Artado better. Check out the open issues or suggest new features. Every line of code you contribute helps.

5. **Host an Artado Proxy**  
   Enhance the network by hosting an Artado Proxy. This helps distribute the load and increase the resilience of the search engine. [Learn more about hosting an Artado Proxy.](https://github.com/Artado-Project/ArtadoProxy)

6. **Help with Documentation**  
   Great documentation is essential for any project. Help us write, improve, and maintain the documentation for Artado, making it easier for others to get involved and use the platform. [Learn more about documentations.](https://github.com/Artado-Project/artadosearch-docs)

7. **Develop Themes and Extensions**  
   Bring your creativity to Artado by developing themes and extensions. Customization is a key part of our vision, and we welcome contributions that enhance the user experience.

No matter how you choose to contribute, your involvement is greatly appreciated. Together, we can build something truly special. Thank you for your support!

---

Feel free to adjust the tone or add any additional details that fit your project!

## Language Contributions

If you're interested in contributing translations or correcting existing ones:

1. Visit the [Translation Documentation](Translation.md) for information on how to contribute new languages or improve existing translations.

## License

Artado Search operates under the [AGPL v3](LICENSE) license, which mandates that any modifications or derivatives must also be open source and adhere to the AGPL v3.

## Contact

For inquiries, collaboration opportunities, or any concerns, reach out to us at [support@artadosearch.com](mailto:support@artadosearch.com).

---

Explore the possibilities of Artado Search, and join us in building a search engine that adapts to your preferences and helps you discover information efficiently. Your contributions make a difference!
