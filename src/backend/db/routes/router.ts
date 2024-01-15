import express, { Request, Response } from 'express';
import Result from '../models/result';

const router = express.Router();

router.get('/api', async (req: Request, res: Response) => {
  try {
    // Extract the "q" parameter from the URL
    const searchTerm: string = req.query.q as string;

    // Customize the query based on the search term
    const query = { fieldName: { $regex: new RegExp(searchTerm, 'i') } };

    const results = await Result.find(query);
    res.json(results);
  } catch (error) {
    console.error('Error fetching data:', error);
    res.status(500).json({'Internal Server Error' : error});
  }
});

export default router;