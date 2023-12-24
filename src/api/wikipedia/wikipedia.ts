import axios from 'axios';

interface WikipediaResponse {
    batchcomplete: string;
    query: {
        pages: Record<string, {
            pageid: number,
            ns: number,
            title: string,
            extract: string,
        }>;
    };
}

async function searchWikipedia(query: string, country_code: string): Promise<void> {
    try {
        const apiUrl = `https://${country_code}.wikipedia.org/w/api.php`;
        const response = await axios.get<WikipediaResponse>(apiUrl, {
            params: {
                action: 'query',
                format: 'json',
                prop: 'extracts',
                titles: query,
                exintro: true,
                explaintext: true,
            }
        });

        if (response.data && response.data.query && response.data.query.pages) {
            const pages = response.data.query.pages;

            for (const pageId in pages) {
                const page = pages[pageId];
                console.log(`Title: ${page.title}`);
                console.log(`Extract: ${page.extract}`);
            }
        } else {
            console.error('Unexpected response format from Wikipedia API');
        }
    } catch (error: any) {
        console.error('Error fetching data from Wikipedia:', error.message);
    }
}

const country_code = 'tr';
const query = 'istanbul';
searchWikipedia(query, country_code).then(r => console.log('Code finished'));