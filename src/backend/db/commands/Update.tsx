import * as mongodb from 'mongodb';
import * as dotenv from 'dotenv';

// Load environment variables from .env file our .env file is in the ../config folder
dotenv.config({ path: './config/.env' });

export default class Update {
    private static readonly uri: string = process.env.MONGODB_URI ?? '';
    private static readonly client: mongodb.MongoClient = new mongodb.MongoClient(Update.uri);

    public static async updateOne(collection: string, filter: object, update: object): Promise<boolean> {
        try {
            await Update.client.connect();
            const database: mongodb.Db = Update.client.db(process.env.MONGODB_DB ?? '');
            const result: mongodb.UpdateResult = await database.collection(collection).updateOne(filter, update);

            return result.modifiedCount === 1;
        } catch (error) {
            console.error(error);
            return false;
        } finally {
            await Update.client.close();
        }
    }

    public static async updateMany(collection: string, filter: object, update: object): Promise<boolean> {
        try {
            await Update.client.connect();
            const database: mongodb.Db = Update.client.db(process.env.MONGODB_DB ?? '');
            const result: mongodb.UpdateResult = await database.collection(collection).updateMany(filter, update);

            return result.modifiedCount >= 1;
        } catch (error) {
            console.error(error);
            return false;
        } finally {
            await Update.client.close();
        }
    }
}

/*
    Example usage:
*/

// import Update from './Update';
//
// const update = async () => {
//     const filter = { name: 'John' };
//     const update = { $set: { name: 'John Doe' } };
//
//     const result = await Update.updateOne('users', filter, update);
//     console.log(result);
// };
