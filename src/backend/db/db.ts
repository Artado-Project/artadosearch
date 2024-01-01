import * as mongodb from 'mongodb';
import * as dotenv from 'dotenv';
import "path-browserify";
import * as path from 'path';

const rootPath = process.cwd();
const envPath = path.resolve(rootPath, 'src', 'config', '.env');

dotenv.config({ path: envPath });

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
