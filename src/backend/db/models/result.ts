import mongoose, { Schema, Document } from 'mongoose';

export interface ResultInterface extends Document {
  // Define model fields here (later, might be useful)
}

const ResultSchema: Schema = new Schema({
  title: String,
  url: String,
  desc: String,
  type: String
});

const Result = mongoose.model<ResultInterface>('Result', ResultSchema);

export default Result;