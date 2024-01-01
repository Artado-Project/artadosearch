import * as mongodb from 'mongodb';
import * as dotenv from 'dotenv';

// Load environment variables from .env file, where API keys and passwords are configured
dotenv.config({ path: 'config/.env' });

// Connection URL
export async function connection() {
    const client: mongodb.MongoClient
        = new mongodb.MongoClient(
            process.env.DB_CONN_STRING
        );

    await client.connect();

    return client.db(process.env.DB_NAME);
}

const db = connection();
db.then((db) => {
    console.log(`Connected to ${db.databaseName} database`);
}).catch((err) => {
    console.log(err);
});
