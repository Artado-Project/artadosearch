import express, { Request, Response } from 'express';
import getResults from '../models/result';

const router = express.Router();

router.get('/api', async (req: Request, res: Response) => {
  try {
    // Extract the "q" parameter from the URL
    const q: string = req.query.q as string;

    const results = await getResults(q);
    res.json(results);
  } catch (error) {
    console.error('Error fetching data:', error);
    res.status(500).json({'Internal Server Error' : error});
  }
});

export default router;