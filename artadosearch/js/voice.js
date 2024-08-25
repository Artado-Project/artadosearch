document.addEventListener('DOMContentLoaded', function () {
    const searchInput = document.getElementById('searchinput');
    const voiceSearchBtn = document.getElementById('mic-button');
    const listeningStatus = document.getElementById('listeningStatus');

    // Check for browser support
    const SpeechRecognition = window.SpeechRecognition || window.webkitSpeechRecognition;

    voiceSearchBtn.addEventListener('click', (event) => {
        event.preventDefault(); // Prevent the page from refreshing

        if (!SpeechRecognition) {
            listeningStatus.innerHTML = "Your browser does not support voice recognition. <br/> If you are using a modern browser and having problems please check <a href='https://github.com/Artado-Project/artadosearch-docs/blob/main/FAQ.md#12-im-having-trouble-with-voice-search-what-should-i-do'>here</a>";
            return;
        }

        const recognition = new SpeechRecognition();
        recognition.lang = 'en-US';
        recognition.interimResults = false;
        recognition.maxAlternatives = 1;

        listeningStatus.textContent = "Listening...";
        recognition.start();

        recognition.addEventListener('result', (event) => {
            let transcript = event.results[0][0].transcript;
            // Remove trailing dot or any punctuation at the end
            transcript = transcript.replace(/[.,!?;:]$/, '');
            searchInput.value = transcript;
            console.log('Voice input:', transcript);

            // Automatically perform the search after capturing the voice input
            performSearch(transcript);
        });

        recognition.addEventListener('speechend', () => {
            recognition.stop();
            listeningStatus.textContent = ""; // Clear the "Listening..." status
        });

        recognition.addEventListener('error', (event) => {
            console.error('Speech recognition error:', event.error);
            listeningStatus.textContent = `Error: ${event.error}`;
        });
    });

    function performSearch(query) {
        if (query) {
            window.location.href = `/search?q=${encodeURIComponent(query)}`;
        }
    }
});