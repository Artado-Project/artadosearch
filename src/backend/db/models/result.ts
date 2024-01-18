import db from '../database';
import * as sql from 'mssql';

const getResults = async (q: string) => {
  const pool = await db();
  const result = await pool.request()
                .input('q', sql.NVarChar, q)
                .query('SELECT * FROM WebResults WHERE (Title Like @q or Description Like @q or Keywords Like @q) order by Rank desc');
  return result.recordset;
};

export default getResults;