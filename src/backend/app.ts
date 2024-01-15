import express from 'express';
import mongoose from './database';
import router from './db/routes/router';

const app = express();
const PORT = process.env.PORT || 3000;

app.use('/api', router);

app.listen(PORT, () => {
  console.log(`Server is running on port ${PORT}`);
});