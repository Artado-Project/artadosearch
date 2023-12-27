import axios, {AxiosRequestConfig} from "axios";

interface WikipediaResponse {
    batchcomplete: string;
    query: {
        pages: Record<string, {
            pageid: number;
            ns: number;
            title: string;
            extract: string;
            thumbnail?: {
                source: string;
                width: number;
                height: number;
            };
        }>;
    };
}

const config = (query: string): AxiosRequestConfig => ({
    headers: {
        "Access-Control-Allow-Origin": "*",
        "Access-Control-Allow-Methods": "GET, POST",
        "Access-Control-Allow-Headers": "Content-Type",
    },
    params: {
        action: 'query',
        format: 'json',
        prop: 'extracts|pageimages',
        titles: query,
        exintro: true,
        explaintext: true,
        pithumbsize: 200,
    },
});

export async function searchWikipedia(countryCode: string, query: string): Promise<string | undefined> {
    try {
        const apiUrl = `https://${countryCode}.wikipedia.org/w/api.php`;
        const response = await axios.get<WikipediaResponse>(apiUrl, config(query));

        if (response.data && response.data.query && response.data.query.pages) {
            const pages = response.data.query.pages;
            for (const pageId in pages) {
                const page = pages[pageId];
                if (page.thumbnail && page.thumbnail.source) {
                    return page.thumbnail.source; // Return the image URL
                }
            }
        } else {
            console.error('Unexpected response format from Wikipedia API');
        }
    } catch (error: any) {
        console.error('Error fetching data from Wikipedia:', error.message);
    }

    return undefined;
}


const countryCode = 'tr';
const query = 'Türkiye';

searchWikipedia(countryCode, query).then((result) => {
    console.log('Result:', result);
});

