import mongoose from 'mongoose';

const MONGODB_URI = 'mongodb://localhost';

//Connect to the MongoDB database
mongoose.connect(MONGODB_URI);

const db = mongoose.connection;

db.on('error', console.error.bind(console, 'MongoDB connection error:'));
db.once('open', () => {
  console.log('Connected to MongoDB');
});

export default mongoose;
